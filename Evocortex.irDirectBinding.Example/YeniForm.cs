using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evocortex.irDirectBinding.Example
{
    public partial class YeniForm : Form
    {
        public FormMain mainForm;
        public bool control = false;
        public YeniForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = mainForm._pbPaletteImage.Image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void YeniForm_Load(object sender, EventArgs e)
        {
            //pictureBox1.Width = this.Size.Width;
            //pictureBox1.Height = this.Size.Height-100;
            timer1.Start();
        }

        private void YeniForm_Resize(object sender, EventArgs e)
        {
            //lblDursun.Location = new Point((ClientSize.Width - lblDursun.Width) / 2,ClientSize.Height-50);
            //pictureBox1.Size = this.Size;
            //pictureBox1.Height = this.Size.Height - 100;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var bigWidth = pictureBox1.Width;
            var bigHeight = pictureBox1.Height;
            int smallWidth = 80;
            int smallHeight = 80;
            var bigX = e.X;
            var bigY = e.Y;

            int smallX = (int)((double)bigX / bigWidth * smallWidth);
            int smallY = (int)((double)bigY / bigHeight * smallHeight);

            var sicaklik = ((double)mainForm.termalGoruntu.ThermalImage[smallX, smallY]-1000)/10;

            lblSicaklik.Text = $"Sıcaklık:{sicaklik}";
        }
        
        public Point[] arr = new Point[100];
        public int i = 0;
        public bool per = false;
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            ++i;
            arr[i] = e.Location;
            per = true;

            Label lbl = new Label();
            lbl.Dock = DockStyle.Top;
            lbl.Text = "X:" + e.X + " - Y:" + e.Y;
            flowLayoutPanel1.Controls.Add(lbl);
        }

        public PaintEventArgs paintEventArgs;
        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            paintEventArgs = e;
            if (per)
            {
                //Graphics g = e.Graphics;
                //Pen pen = new Pen(BackColor, 2);
                //g.DrawEllipse(pen, arr[i].X, arr[i].Y, 20, 20);

                //    per = false;    

                foreach (var item in arr.Where(x=>x.Y != 0 && x.X != 0).ToList())
                {
                    Graphics g = e.Graphics;
                    Pen pen = new Pen(BackColor, 2);
                    g.DrawEllipse(pen, item.X, item.Y, 20, 20);
                }
            }
        }
        
        private void btnDursun_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManuelNoktaEkleme form = new ManuelNoktaEkleme(this);
            form.Show();
        }














        //private thermalDataDto GryYontemi(MouseEventArgs e)
        //{
        //    int bigWidth = pictureBox1.Width;
        //    int bigHeight = pictureBox1.Height;



        //    var bigX = e.X;
        //    var bigY = e.Y;

        //    double ratioX = (double)bigWidth / 80.0;
        //    double ratioY = (double)bigHeight / 80.0;
        //    int thermalImageX = (int)(bigX / ratioX);
        //    int thermalImageY = (int)(bigY / ratioY);
        //    var grySonuc = ((double)mainForm.termalGoruntu.ThermalImage[thermalImageX, thermalImageY] - 1000) / 10;

        //    return null;
        //}







        ////var sıcaklık = mainForm.termalGoruntu.ThermalImage[,];

        //int pictureBoxWidth = pictureBox1.Width;
        //int pictureBoxHeight = pictureBox1.Height;

        //normalKooordinatX = e.X;
        //    normalKooordinatY = e.Y;

        //    var mouseX = e.X;
        //var mouseY = e.Y;

        //double ratioX = (double)pictureBoxWidth / 80.0;
        //double ratioY = (double)pictureBoxHeight / 80.0;
        //int thermalImageX = (int)(mouseX / ratioX);
        //int thermalImageY = (int)(mouseY / ratioY);
        //var sonuc = ((double)mainForm.termalGoruntu.ThermalImage[thermalImageX, thermalImageY] - 1000) / 10;
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
