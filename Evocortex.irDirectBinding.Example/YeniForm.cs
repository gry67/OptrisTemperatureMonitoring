using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace Evocortex.irDirectBinding.Example
{
    public partial class MetalWorm : Form
    {
        //IR Camera
        public IrDirectInterface _irDirectInterface;
        public ThermalPaletteImage termalGoruntu;

        string filePath = Path.Combine(@"C:\\Users\\Güray\\Desktop\\optris form uygulaması", "metalworm icon.jpg");

        public bool control = false;
        public PaintEventArgs paintEventArgs;
        public int CircleCount { get; set; }

        //Seri eklemek için
        List<Point> points = new List<Point>();
        Pen yesilKare = new Pen(Color.Green, 5);


        DateTime LoadTime;
        DateTime EndTime;

        public MetalWorm()
        {
            InitializeComponent();
        }


        // loadl start time + 10 saniye end time
        //


        //Metotlar
        public void AddSeries()
        {
            Series s = new Series();
            s.Legend = "Legend1";
            s.ChartType = SeriesChartType.Line;
            chart1.Series.Add(s);
        }

        public int KoordinatOranlama(int mouseX, int mouseY)
        {
            int kacinciSutun = 0;
            int kacinciSatir = 0;

            for (int i = 0; i <= mouseX; i += 6)
            {
                kacinciSutun++;
            }
            for (int i = 0; i <= mouseY; i += 6)
            {
                kacinciSatir++;
            }

            return (termalGoruntu.ThermalImage[kacinciSutun, kacinciSatir] - 1000) / 10;
        }

        public MaxTemperatureAndCoordinateDto MaxTemperatureCoordinate()
        {
            int maxTemperature = 0;
            int lastRow = 0;
            int lastColumn = 0;

            for (int row = 0; row < 80; row++)
            {
                for (int column = 0; column < 80; column++)
                {
                    int value = (termalGoruntu.ThermalImage[row, column] - 1000) / 10;
                    if (value >= maxTemperature)
                    {
                        maxTemperature = value;
                        lastRow = row;
                        lastColumn = column;
                    }
                }
            }

            double pixelsPerUnitX = (double)pictureBox1.Width / 80;
            double pixelsPerUnitY = (double)pictureBox1.Height / 80;

            int yeniX = (int)(lastColumn * pixelsPerUnitX);
            int yeniY = (int)(lastRow * pixelsPerUnitY);
            return new MaxTemperatureAndCoordinateDto(maxTemperature, new Point(yeniX, yeniY));
        }

        public void AddLocation(MouseEventArgs e)
        {
            //eğer tıkladığım  yerde bir circle varsa o circle'ı array'dan çıkar
            bool isDeleted = false;

            for (int i = 0; i < points.Count(); i++)
            {
                if (points[i].X + 20 >= e.X && e.X >= points[i].X && points[i].Y + 20 >= e.Y && e.Y >= points[i].Y)
                {
                    points.Remove(points[i]);
                    CircleCount--;
                    isDeleted = true;
                    chart1.Series.RemoveAt(i);
                    break;
                }
            }

            if (!isDeleted)
            {
                points.Add(e.Location);
                ++CircleCount;
                AddSeries();
            }
            //isDeleted = false; //true idi false yaptım
        }

        public void AddLocationManual(int x, int y)
        {
            points.Add(new Point(x, y));
            CircleCount++;
            AddSeries();
        }

        public void AddHottestPointToChartSeries1(MaxTemperatureAndCoordinateDto data)
        {
            lblmaxSicaklik.Text = "En Yüksek Sıcaklık: " + data.MaxTemperature.ToString();
            chart1.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), data.MaxTemperature);
        }

        public void AddDataToChartSeries()
        {
            for (int i = 0; i < points.Count; i++) //1'i 0 yaptım
            {
                var sicaklik = KoordinatOranlama(Convert.ToInt32(points[i].X), Convert.ToInt32(points[i].Y));
                chart1.Series[i+1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), sicaklik.ToString());
            }
        }

        public void DrawEllipseAtCoordinates(Graphics g, Pen pen)
        {
            foreach (var item in points.Where(x => x.Y != 0 && x.X != 0).ToList())
            {
                g.DrawEllipse(pen, item.X, item.Y, 20, 20);
            }
        }

        public void ImageGrabber()
        {
            termalGoruntu = _irDirectInterface.GetThermalPaletteImage();
        }





        //Eventler

        private void timer1_Tick(object sender, EventArgs e)
        {
            ImageGrabber();
            pictureBox1.Image = termalGoruntu.PaletteImage;
        }

        private void YeniForm_Load(object sender, EventArgs e)
        {
            iconPicBox.Image = System.Drawing.Image.FromFile(filePath);
            iconPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            _irDirectInterface = IrDirectInterface.Instance;
            _irDirectInterface.Connect("generic.xml");
            termalGoruntu = _irDirectInterface.GetThermalPaletteImage();

            LoadTime = DateTime.Now;
            EndTime = LoadTime.AddSeconds(5);

            cmbColorPalette.Items.AddRange(Enum.GetNames(typeof(OptrisColoringPalette)));

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var sicaklik = KoordinatOranlama(e.X, e.Y);
            lblSicaklik.Text = $"Mouse Noktası Sıcaklığı: {sicaklik}";
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            AddLocation(e);
        }



        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (DateTime.Now < EndTime)
                return;

            Graphics g = e.Graphics;
            Pen pen = new Pen(BackColor, 2);

            var data = MaxTemperatureCoordinate();
            Point nokta = data.point;

            AddHottestPointToChartSeries1(data);

            g.DrawRectangle(yesilKare, nokta.X, nokta.Y, 15, 15);

            if (CircleCount > 0)
            {
                DrawEllipseAtCoordinates(g, pen);
            }


            //arr'deki koordinatları alır 80x80'e oranlar ve veri girişi yapar
            if (CircleCount > 0)
            {
                AddDataToChartSeries();
            }
            paintEventArgs = e;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ManuelNoktaEkleme form = new ManuelNoktaEkleme(this);
            form.Show();
        }

        private void btnDursun_Click(object sender, EventArgs e)
        {
            _irDirectInterface.TriggerShutterFlag();
        }

        private void cmbColorPalette_SelectedIndexChanged(object sender, EventArgs e)
        {
            _irDirectInterface.SetPaletteFormat(
                (OptrisColoringPalette)Enum.Parse(typeof(OptrisColoringPalette), (string)cmbColorPalette.SelectedItem),
                OptrisPaletteScalingMethod.MinMax);

            lblmaxSicaklik.Focus();
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #region Drag Drop
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        #endregion
    }


    public static class GraphicsExtensions
    {
        public static void DrawCircle(this Graphics g, Pen pen,
                                      float centerX, float centerY, float radius)
        {
            g.DrawEllipse(pen, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public static void FillCircle(this Graphics g, Brush brush,
                                      float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }

}


//var bigWidth = pictureBox1.Width;
//var bigHeight = pictureBox1.Height;
//int smallWidth = 80;
//int smallHeight = 80;
//int smallX = (int)((double)mouseX / bigWidth * smallWidth);
//int smallY = (int)((double)mouseY / bigHeight * smallHeight);

//var scaleX = 80 / pictureBox1.Width;
//var scaleY = 80 / pictureBox1.Height;

//var smallX = mouseX * scaleX;
//var smallY = mouseY * scaleY;


//public int SicaklikOranlama2(int mouseX, int mouseY)
//{
//    double pixelsPerUnitX = (double)80 / pictureBox1.Width;
//    double pixelsPerUnitY = (double)80 / pictureBox1.Height;
//    int yeniX = (int)(mouseX * pixelsPerUnitX);
//    int yeniY = (int)(mouseY * pixelsPerUnitY);
//    return ((int)mainForm.termalGoruntu.ThermalImage[yeniX, yeniY] - 1000) / 10;
//}



//if (chart1.Series[0].Points.Count >100)
//{
//    chart1.Series[0].Points.RemoveAt(0);
//}

//if (CircleCount ==2 )
//{
//    if (!added)
//    {
//        Series s = new Series();
//        added = true;
//        s.Legend = "Legend1";
//        s.ChartType = SeriesChartType.Line;

//        chart1.Series.Add(s);
//    }
//}

//if (CircleCount > 1)
//{
//    var sicaklik2 = SicaklikOranlama(Convert.ToInt32(arr[1].X), Convert.ToInt32(arr[1].Y));

//    chart1.Series[1].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), sicaklik2.ToString());


//    if (chart1.Series[1].Points.Count > 100)
//    {
//        chart1.Series[1].Points.RemoveAt(0);
//    }
//}