using System.Windows.Forms;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnDursun = new System.Windows.Forms.Button();
            this.lblSicaklik = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(467, 338);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
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
            this.btnDursun.Size = new System.Drawing.Size(467, 37);
            this.btnDursun.TabIndex = 3;
            this.btnDursun.Text = "Şuan boşum";
            this.btnDursun.UseVisualStyleBackColor = true;
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
            this.panel1.Location = new System.Drawing.Point(0, 344);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 100);
            this.panel1.TabIndex = 5;
            // 
            // YeniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "YeniForm";
            this.Text = "YeniForm";
            this.Load += new System.EventHandler(this.YeniForm_Load);
            this.Resize += new System.EventHandler(this.YeniForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnDursun;
        private Label lblSicaklik;
        private Panel panel1;
    }
}