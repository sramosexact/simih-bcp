namespace ExpedicionInternaPC
{
    partial class frmAsociarDocumentoAutogenerado
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
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.cboDestino = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTipoDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl7.Location = new System.Drawing.Point(659, 12);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(81, 18);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "Destinatario:";
            this.labelControl7.Visible = false;
            // 
            // cboDestino
            // 
            this.cboDestino.Location = new System.Drawing.Point(659, 36);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cboDestino.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.cboDestino.Properties.Appearance.Options.UseFont = true;
            this.cboDestino.Properties.Appearance.Options.UseForeColor = true;
            this.cboDestino.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDestino.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcion", "Descripcion")});
            this.cboDestino.Properties.NullText = "- Seleccione destino -";
            this.cboDestino.Properties.ShowFooter = false;
            this.cboDestino.Properties.ShowHeader = false;
            this.cboDestino.Size = new System.Drawing.Size(342, 24);
            this.cboDestino.TabIndex = 8;
            this.cboDestino.Visible = false;
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.Location = new System.Drawing.Point(25, 45);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.cboTipoDocumento.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.cboTipoDocumento.Properties.Appearance.Options.UseFont = true;
            this.cboTipoDocumento.Properties.Appearance.Options.UseForeColor = true;
            this.cboTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoDocumento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboTipoDocumento.Properties.NullText = "- Seleccione tipo de documento -";
            this.cboTipoDocumento.Properties.ShowFooter = false;
            this.cboTipoDocumento.Properties.ShowHeader = false;
            this.cboTipoDocumento.Size = new System.Drawing.Size(324, 24);
            this.cboTipoDocumento.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl1.Location = new System.Drawing.Point(25, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(132, 18);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Tipo de documento:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnCancelar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.Appearance.Options.UseForeColor = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.Location = new System.Drawing.Point(25, 85);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(159, 37);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnGuardar.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnGuardar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Appearance.Options.UseBackColor = true;
            this.btnGuardar.Appearance.Options.UseFont = true;
            this.btnGuardar.Appearance.Options.UseForeColor = true;
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.Location = new System.Drawing.Point(190, 85);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(159, 37);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmAsociarDocumentoAutogenerado
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 146);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.cboTipoDocumento);
            this.Controls.Add(this.cboDestino);
            this.Name = "frmAsociarDocumentoAutogenerado";
            this.Text = "frmAsociarDocumentoAutogenerado";
            this.Load += new System.EventHandler(this.frmAsociarDocumentoAutogenerado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboDestino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LookUpEdit cboDestino;
        private DevExpress.XtraEditors.LookUpEdit cboTipoDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;

    }
}