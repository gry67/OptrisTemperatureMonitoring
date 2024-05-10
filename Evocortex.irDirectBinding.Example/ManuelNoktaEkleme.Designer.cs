namespace Evocortex.irDirectBinding.Example
{
    partial class ManuelNoktaEkleme
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
            this.lblXekseni = new System.Windows.Forms.Label();
            this.lblYekseni = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.btnOlustur = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblXekseni
            // 
            this.lblXekseni.AutoSize = true;
            this.lblXekseni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblXekseni.Location = new System.Drawing.Point(70, 57);
            this.lblXekseni.Name = "lblXekseni";
            this.lblXekseni.Size = new System.Drawing.Size(75, 20);
            this.lblXekseni.TabIndex = 0;
            this.lblXekseni.Text = "X Ekseni";
            // 
            // lblYekseni
            // 
            this.lblYekseni.AutoSize = true;
            this.lblYekseni.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYekseni.Location = new System.Drawing.Point(71, 98);
            this.lblYekseni.Name = "lblYekseni";
            this.lblYekseni.Size = new System.Drawing.Size(74, 20);
            this.lblYekseni.TabIndex = 1;
            this.lblYekseni.Text = "Y Ekseni";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(150, 55);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(146, 22);
            this.txtX.TabIndex = 2;
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(150, 96);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(146, 22);
            this.txtY.TabIndex = 3;
            // 
            // btnOlustur
            // 
            this.btnOlustur.Location = new System.Drawing.Point(150, 146);
            this.btnOlustur.Name = "btnOlustur";
            this.btnOlustur.Size = new System.Drawing.Size(75, 38);
            this.btnOlustur.TabIndex = 4;
            this.btnOlustur.Text = "Oluştur";
            this.btnOlustur.UseVisualStyleBackColor = true;
            this.btnOlustur.Click += new System.EventHandler(this.btnOlustur_Click);
            // 
            // ManuelNoktaEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 215);
            this.Controls.Add(this.btnOlustur);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.lblYekseni);
            this.Controls.Add(this.lblXekseni);
            this.Name = "ManuelNoktaEkleme";
            this.Text = "Nokta Ekleme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblXekseni;
        private System.Windows.Forms.Label lblYekseni;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Button btnOlustur;
    }
}