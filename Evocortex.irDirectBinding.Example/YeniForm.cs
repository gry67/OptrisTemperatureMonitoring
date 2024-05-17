﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Net.Mime.MediaTypeNames;

namespace Evocortex.irDirectBinding.Example
{
    public partial class YeniForm : Form
    {
        public FormMain mainForm;
        public bool control = false;
        public PaintEventArgs paintEventArgs;

        public int CircleCount { get; set; }


        public YeniForm()
        {
            InitializeComponent();

        }

        public void AddSeries()
        {
            Series s = new Series();
            s.Legend = "Legend1";
            s.ChartType = SeriesChartType.Line;
            chart1.Series.Add(s);
        }


        public int KoordinatOranlama(int mouseX, int mouseY)
        {
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

            int kacinciSutun = 0;
            int kacinciSatir = 0;

            for (int i = 0; i <= mouseX;i+=6)
            {
                kacinciSutun++;
            }
            for (int i = 0; i <= mouseY;i+=6)
            {
                kacinciSatir++;
            }

            return (mainForm.termalGoruntu.ThermalImage[kacinciSutun, kacinciSatir]- 1000) / 10;
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
                    int value = (mainForm.termalGoruntu.ThermalImage[row, column]-1000)/10;
                    if (value>=maxTemperature)
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



        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = mainForm._pbPaletteImage.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        
        private void YeniForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var sicaklik = KoordinatOranlama(e.X, e.Y);
            lblSicaklik.Text = $"Sıcaklık:{sicaklik}";
        }
        


        public Point[] arr = new Point[100];
        public int i = 0;
        public bool per = false;
        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            arr[i] = e.Location;
            per = true;
            ++CircleCount;
            if (CircleCount != 1)
            {
                AddSeries(); 
            }
            ++i;
        }


        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(BackColor, 2);
            Pen yesilKare = new Pen(Color.Green, 5);
            
            var data = MaxTemperatureCoordinate();
            Point nokta = data.point;
            lblmaxSicaklik.Text = data.MaxTemperature.ToString();
            
            g.DrawRectangle(yesilKare, nokta.X, nokta.Y, 15, 15);

            if (per)
            {
                foreach (var item in arr.Where(x => x.Y != 0 && x.X != 0).ToList())
                {
                    g.DrawEllipse(pen, item.X, item.Y, 20, 20);
                }
            }

            if (per)
            {
                for (int i = 0; i < CircleCount; i++)
                {
                    var sicaklik = KoordinatOranlama(Convert.ToInt32(arr[i].X), Convert.ToInt32(arr[i].Y));
                    chart1.Series[i].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), sicaklik.ToString());
                }
                //var sicaklik = SicaklikOranlama(Convert.ToInt32(arr[0].X), Convert.ToInt32(arr[0].Y));
                //chart1.Series[0].Points.AddXY(DateTime.Now.ToString("hh:mm:ss"), sicaklik.ToString());
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
            var x = pictureBox1.Size.Width;
            var y = pictureBox1.Size.Height;
            MessageBox.Show($"X boyutu {x} Y boyutu {y}");
        }
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