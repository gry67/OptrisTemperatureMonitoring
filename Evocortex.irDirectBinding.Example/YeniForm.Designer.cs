using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Evocortex.irDirectBinding.Example
{
    partial class YeniForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDursun = new System.Windows.Forms.Button();
            this.lblSicaklik = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblmaxSicaklik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(37, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(474, 474);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnDursun
            // 
            this.btnDursun.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDursun.Location = new System.Drawing.Point(0, 63);
            this.btnDursun.Name = "btnDursun";
            this.btnDursun.Size = new System.Drawing.Size(1364, 37);
            this.btnDursun.TabIndex = 3;
            this.btnDursun.Text = "Tigger Shutter";
            this.btnDursun.UseVisualStyleBackColor = true;
            this.btnDursun.Click += new System.EventHandler(this.btnDursun_Click);
            // 
            // lblSicaklik
            // 
            this.lblSicaklik.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblSicaklik.Location = new System.Drawing.Point(94, 16);
            this.lblSicaklik.Name = "lblSicaklik";
            this.lblSicaklik.Size = new System.Drawing.Size(290, 34);
            this.lblSicaklik.TabIndex = 4;
            this.lblSicaklik.Text = "Şuan Boşum";
            this.lblSicaklik.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSicaklik);
            this.panel1.Controls.Add(this.btnDursun);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 600);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 100);
            this.panel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(328, 510);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Manuel Nokta Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(678, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(674, 514);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // lblmaxSicaklik
            // 
            this.lblmaxSicaklik.AutoSize = true;
            this.lblmaxSicaklik.Location = new System.Drawing.Point(34, 510);
            this.lblmaxSicaklik.Name = "lblmaxSicaklik";
            this.lblmaxSicaklik.Size = new System.Drawing.Size(121, 16);
            this.lblmaxSicaklik.TabIndex = 9;
            this.lblmaxSicaklik.Text = "En Yüksek Sıcaklık";
            // 
            // YeniForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1364, 700);
            this.Controls.Add(this.lblmaxSicaklik);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "YeniForm";
            this.Text = "TemizForm";
            this.Load += new System.EventHandler(this.YeniForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnDursun;
        private Label lblSicaklik;
        private Panel panel1;
        private Button button1;
        private Chart chart1;
        private Label lblmaxSicaklik;
    }
}