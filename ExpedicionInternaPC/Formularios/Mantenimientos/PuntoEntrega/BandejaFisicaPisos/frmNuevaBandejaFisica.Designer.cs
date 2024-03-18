namespace ExpedicionInternaPC.Formularios.Mantenimientos.PuntoEntrega.BandejaFisicaPisos
{
    partial class frmNuevaBandejaFisica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaBandejaFisica));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBandejaFisica = new DevExpress.XtraEditors.TextEdit();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtBandejaFisica.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Bandeja física";
            // 
            // txtBandejaFisica
            // 
            this.txtBandejaFisica.Location = new System.Drawing.Point(97, 43);
            this.txtBandejaFisica.Name = "txtBandejaFisica";
            this.txtBandejaFisica.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtBandejaFisica.Properties.Appearance.Options.UseFont = true;
            this.txtBandejaFisica.Size = new System.Drawing.Size(231, 22);
            this.txtBandejaFisica.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(235, 87);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(93, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmNuevaBandejaFisica
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 122);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtBandejaFisica);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmNuevaBandejaFisica";
            this.Text = "Nueva bandeja física";
            ((System.ComponentModel.ISupportInitialize)(this.txtBandejaFisica.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBandejaFisica;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
    }
}