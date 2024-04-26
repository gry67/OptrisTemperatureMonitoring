using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evocortex.irDirectBinding.Example
{
    public partial class YeniForm : Form
    {
        public FormMain mainForm;

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

}
