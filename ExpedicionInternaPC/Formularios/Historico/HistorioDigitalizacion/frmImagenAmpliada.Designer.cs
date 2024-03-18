namespace ExpedicionInternaPC
{
    partial class frmImagenAmpliada
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
            this.btnOriginal = new DevExpress.XtraEditors.SimpleButton();
            this.btnReducir = new DevExpress.XtraEditors.SimpleButton();
            this.btnAmpliar = new DevExpress.XtraEditors.SimpleButton();
            this.picImagen = new DevExpress.XtraEditors.PictureEdit();
            this.btnAjustar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.picImagen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOriginal
            // 
            this.btnOriginal.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnOriginal.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOriginal.Appearance.Options.UseBackColor = true;
            this.btnOriginal.Appearance.Options.UseForeColor = true;
            this.btnOriginal.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnOriginal.Location = new System.Drawing.Point(582, 671);
            this.btnOriginal.Name = "btnOriginal";
            this.btnOriginal.Size = new System.Drawing.Size(99, 40);
            this.btnOriginal.TabIndex = 1;
            this.btnOriginal.Text = "Tamaño Original";
            this.btnOriginal.Click += new System.EventHandler(this.btnOriginal_Click);
            // 
            // btnReducir
            // 
            this.btnReducir.Appearance.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnReducir.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnReducir.Appearance.Options.UseBackColor = true;
            this.btnReducir.Appearance.Options.UseForeColor = true;
            this.btnReducir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnReducir.Location = new System.Drawing.Point(396, 671);
            this.btnReducir.Name = "btnReducir";
            this.btnReducir.Size = new System.Drawing.Size(75, 40);
            this.btnReducir.TabIndex = 1;
            this.btnReducir.Text = "-  Reducir";
            this.btnReducir.Click += new System.EventHandler(this.btnReducir_Click);
            // 
            // btnAmpliar
            // 
            this.btnAmpliar.Appearance.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAmpliar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAmpliar.Appearance.Options.UseBackColor = true;
            this.btnAmpliar.Appearance.Options.UseForeColor = true;
            this.btnAmpliar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAmpliar.Location = new System.Drawing.Point(315, 671);
            this.btnAmpliar.Name = "btnAmpliar";
            this.btnAmpliar.Size = new System.Drawing.Size(75, 40);
            this.btnAmpliar.TabIndex = 1;
            this.btnAmpliar.Text = "+  Ampliar";
            this.btnAmpliar.Click += new System.EventHandler(this.btnAmpliar_Click);
            // 
            // picImagen
            // 
            this.picImagen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picImagen.Location = new System.Drawing.Point(12, 12);
            this.picImagen.Name = "picImagen";
            this.picImagen.Properties.AllowScrollViaMouseDrag = true;
            this.picImagen.Properties.Appearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.picImagen.Properties.Appearance.Options.UseBorderColor = true;
            this.picImagen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.picImagen.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picImagen.Properties.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.picImagen_Properties_MouseWheel);
            this.picImagen.Size = new System.Drawing.Size(986, 644);
            this.picImagen.TabIndex = 0;
            // 
            // btnAjustar
            // 
            this.btnAjustar.Appearance.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnAjustar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAjustar.Appearance.Options.UseBackColor = true;
            this.btnAjustar.Appearance.Options.UseForeColor = true;
            this.btnAjustar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAjustar.Location = new System.Drawing.Point(477, 671);
            this.btnAjustar.Name = "btnAjustar";
            this.btnAjustar.Size = new System.Drawing.Size(99, 40);
            this.btnAjustar.TabIndex = 1;
            this.btnAjustar.Text = "[ ] Ajustar";
            this.btnAjustar.Click += new System.EventHandler(this.btnAjustar_Click);
            // 
            // frmImagenAmpliada
            // 
            this.Appearance.BackColor = System.Drawing.Color.Azure;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 723);
            this.Controls.Add(this.btnAjustar);
            this.Controls.Add(this.btnOriginal);
            this.Controls.Add(this.btnReducir);
            this.Controls.Add(this.btnAmpliar);
            this.Controls.Add(this.picImagen);
            this.Name = "frmImagenAmpliada";
            this.Text = "Imagen";
            this.Load += new System.EventHandler(this.frmImagenAmpliada_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picImagen.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picImagen;
        private DevExpress.XtraEditors.SimpleButton btnAmpliar;
        private DevExpress.XtraEditors.SimpleButton btnReducir;
        private DevExpress.XtraEditors.SimpleButton btnOriginal;
        private DevExpress.XtraEditors.SimpleButton btnAjustar;
    }
}