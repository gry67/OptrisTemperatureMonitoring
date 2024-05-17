namespace Evocortex.irDirectBinding.Example {
    partial class FormMain {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent() {
            this._pbPaletteImage = new System.Windows.Forms.PictureBox();
            this._btnForceShutter = new System.Windows.Forms.Button();
            this._labTemp = new System.Windows.Forms.Label();
            this._cmbPalette = new System.Windows.Forms.ComboBox();
            this.btnYeniForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pbPaletteImage)).BeginInit();
            this.SuspendLayout();
            // 
            // _pbPaletteImage
            // 
            this._pbPaletteImage.Location = new System.Drawing.Point(0, 0);
            this._pbPaletteImage.Name = "_pbPaletteImage";
            this._pbPaletteImage.Size = new System.Drawing.Size(188, 203);
            this._pbPaletteImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._pbPaletteImage.TabIndex = 0;
            this._pbPaletteImage.TabStop = false;
            // 
            // _btnForceShutter
            // 
            this._btnForceShutter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._btnForceShutter.Location = new System.Drawing.Point(0, 238);
            this._btnForceShutter.Name = "_btnForceShutter";
            this._btnForceShutter.Size = new System.Drawing.Size(276, 23);
            this._btnForceShutter.TabIndex = 1;
            this._btnForceShutter.Text = "Trigger Shutter";
            this._btnForceShutter.UseVisualStyleBackColor = true;
            this._btnForceShutter.Click += new System.EventHandler(this._btnForceShutter_Click);
            // 
            // _labTemp
            // 
            this._labTemp.AutoSize = true;
            this._labTemp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._labTemp.Location = new System.Drawing.Point(0, 225);
            this._labTemp.Name = "_labTemp";
            this._labTemp.Size = new System.Drawing.Size(103, 13);
            this._labTemp.TabIndex = 2;
            this._labTemp.Text = "Min: 0° at Max: 0° at";
            // 
            // _cmbPalette
            // 
            this._cmbPalette.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbPalette.FormattingEnabled = true;
            this._cmbPalette.Location = new System.Drawing.Point(0, 204);
            this._cmbPalette.Name = "_cmbPalette";
            this._cmbPalette.Size = new System.Drawing.Size(276, 21);
            this._cmbPalette.TabIndex = 3;
            this._cmbPalette.SelectedIndexChanged += new System.EventHandler(this._cmbPalette_SelectedIndexChanged);
            // 
            // btnYeniForm
            // 
            this.btnYeniForm.Location = new System.Drawing.Point(198, 72);
            this.btnYeniForm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnYeniForm.Name = "btnYeniForm";
            this.btnYeniForm.Size = new System.Drawing.Size(56, 19);
            this.btnYeniForm.TabIndex = 4;
            this.btnYeniForm.Text = "YeniForm";
            this.btnYeniForm.UseVisualStyleBackColor = true;
            this.btnYeniForm.Click += new System.EventHandler(this.btnYeniForm_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 261);
            this.Controls.Add(this.btnYeniForm);
            this.Controls.Add(this._pbPaletteImage);
            this.Controls.Add(this._cmbPalette);
            this.Controls.Add(this._labTemp);
            this.Controls.Add(this._btnForceShutter);
            this.Name = "FormMain";
            this.Text = "irDirectBinding Example";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this._pbPaletteImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox _pbPaletteImage;
        private System.Windows.Forms.Button _btnForceShutter;
        private System.Windows.Forms.Label _labTemp;
        private System.Windows.Forms.ComboBox _cmbPalette;
        private System.Windows.Forms.Button btnYeniForm;
    }
}

