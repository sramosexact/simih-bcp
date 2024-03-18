namespace ExpedicionInternaPC.Formularios.Gestion
{
    partial class frmCodigoAutogenerado
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
            this.txtAutogenerado = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutogenerado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAutogenerado
            // 
            this.txtAutogenerado.EditValue = "201012120401";
            this.txtAutogenerado.Location = new System.Drawing.Point(12, 12);
            this.txtAutogenerado.Name = "txtAutogenerado";
            this.txtAutogenerado.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.txtAutogenerado.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Bold);
            this.txtAutogenerado.Properties.Appearance.ForeColor = System.Drawing.Color.Red;
            this.txtAutogenerado.Properties.Appearance.Options.UseBackColor = true;
            this.txtAutogenerado.Properties.Appearance.Options.UseFont = true;
            this.txtAutogenerado.Properties.Appearance.Options.UseForeColor = true;
            this.txtAutogenerado.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAutogenerado.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtAutogenerado.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtAutogenerado.Properties.ReadOnly = true;
            this.txtAutogenerado.Size = new System.Drawing.Size(483, 68);
            this.txtAutogenerado.TabIndex = 1;
            // 
            // frmCodigoAutogenerado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(507, 92);
            this.Controls.Add(this.txtAutogenerado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCodigoAutogenerado";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Autogenerado creado";
            this.Load += new System.EventHandler(this.frmCodigoAutogenerado_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCodigoAutogenerado_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.txtAutogenerado.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit txtAutogenerado;
    }
}