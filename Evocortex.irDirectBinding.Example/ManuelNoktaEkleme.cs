using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Schema;

namespace Evocortex.irDirectBinding.Example
{
    public partial class ManuelNoktaEkleme : Form
    {
        private MetalWorm yeniForm;
        public ManuelNoktaEkleme(MetalWorm yeniForm)
        {
            InitializeComponent();
            this.yeniForm = yeniForm;
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            int textX = Convert.ToInt32(txtX.Text);
            int textY = Convert.ToInt32(txtY.Text);

            if (textX<yeniForm.pictureBox1.Width && textY< yeniForm.pictureBox1.Height)
            {
                yeniForm.AddLocationManual(textX, textY);
                Close();
            }
            else
            {
                MessageBox.Show("Girdiğiniz koordinatlar kamera görüntüsüne uygun değil");
            }
        }

        private void ıconButton1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ıconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Drag Drop
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }
        #endregion
    }
}
