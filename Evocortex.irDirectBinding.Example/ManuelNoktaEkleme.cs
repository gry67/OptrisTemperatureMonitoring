﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Schema;

namespace Evocortex.irDirectBinding.Example
{
    public partial class ManuelNoktaEkleme : Form
    {
        private YeniForm yeniForm;
        public ManuelNoktaEkleme(YeniForm yeniForm)
        {
            InitializeComponent();
            this.yeniForm = yeniForm;
        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            int textX = Convert.ToInt32(txtX.Text);
            int textY = Convert.ToInt32(txtY.Text);

            if (textX<yeniForm.Size.Width && textY< yeniForm.Size.Height)
            {
                yeniForm.AddLocationManual(textX, textY);
                Close();
            }
            else
            {
                MessageBox.Show("Girdiğiniz koordinatlar kamera görüntüsüne uygun değil");
            }
        }

        
    }
}
