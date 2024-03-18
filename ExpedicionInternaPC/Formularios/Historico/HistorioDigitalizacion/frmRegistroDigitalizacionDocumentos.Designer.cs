namespace ExpedicionInternaPC
{
    partial class frmRegistroDigitalizacionDocumentos
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboTipoDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cboDestino = new DevExpress.XtraEditors.LookUpEdit();
            this.picDocumento = new DevExpress.XtraEditors.PictureEdit();
            this.btnAdquirirImagen = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCentimos = new DevExpress.XtraEditors.TextEdit();
            this.txtMonto = new DevExpress.XtraEditors.TextEdit();
            this.pnlMoneda = new DevExpress.XtraEditors.PanelControl();
            this.chkConAutogenerado = new DevExpress.XtraEditors.CheckEdit();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.btnPDF = new DevExpress.XtraEditors.SimpleButton();
            this.txtRutaArchivoPDF = new System.Windows.Forms.TextBox();
            this.lblRutaPDF = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCentimos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMoneda)).BeginInit();
            this.pnlMoneda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkConAutogenerado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cboTipoDocumento);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.cboDestino);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(399, 60);
            this.panelControl1.TabIndex = 12;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(29, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(91, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "TIPO DOCUMENTO";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.Location = new System.Drawing.Point(126, 6);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.cboTipoDocumento.Properties.Appearance.Options.UseForeColor = true;
            this.cboTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoDocumento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoDocumento", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoDocumento", "Descripcion")});
            this.cboTipoDocumento.Properties.NullText = "- Seleccione el tipo de documento -";
            this.cboTipoDocumento.Properties.ShowFooter = false;
            this.cboTipoDocumento.Properties.ShowHeader = false;
            this.cboTipoDocumento.Size = new System.Drawing.Size(246, 20);
            this.cboTipoDocumento.TabIndex = 0;
            this.cboTipoDocumento.EditValueChanged += new System.EventHandler(this.cboTipoDocumento_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(29, 35);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "DESTINO";
            // 
            // cboDestino
            // 
            this.cboDestino.Enabled = false;
            this.cboDestino.Location = new System.Drawing.Point(126, 32);
            this.cboDestino.Name = "cboDestino";
            this.cboDestino.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.cboDestino.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.cboDestino.Properties.Appearance.Options.UseFont = true;
            this.cboDestino.Properties.Appearance.Options.UseForeColor = true;
            this.cboDestino.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, false, false, editorButtonImageOptions1)});
            this.cboDestino.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboDestino.Properties.NullText = "";
            this.cboDestino.Properties.ReadOnly = true;
            this.cboDestino.Properties.ShowFooter = false;
            this.cboDestino.Properties.ShowHeader = false;
            this.cboDestino.Size = new System.Drawing.Size(246, 20);
            this.cboDestino.TabIndex = 50;
            // 
            // picDocumento
            // 
            this.picDocumento.Cursor = System.Windows.Forms.Cursors.Default;
            this.picDocumento.Location = new System.Drawing.Point(1160, 21);
            this.picDocumento.Name = "picDocumento";
            this.picDocumento.Properties.Appearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.picDocumento.Properties.Appearance.Options.UseBorderColor = true;
            this.picDocumento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.picDocumento.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picDocumento.Properties.ZoomAccelerationFactor = 1D;
            this.picDocumento.Size = new System.Drawing.Size(88, 516);
            this.picDocumento.TabIndex = 51;
            // 
            // btnAdquirirImagen
            // 
            this.btnAdquirirImagen.Appearance.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnAdquirirImagen.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnAdquirirImagen.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAdquirirImagen.Appearance.Options.UseBackColor = true;
            this.btnAdquirirImagen.Appearance.Options.UseFont = true;
            this.btnAdquirirImagen.Appearance.Options.UseForeColor = true;
            this.btnAdquirirImagen.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAdquirirImagen.Location = new System.Drawing.Point(1134, 404);
            this.btnAdquirirImagen.Name = "btnAdquirirImagen";
            this.btnAdquirirImagen.Size = new System.Drawing.Size(159, 37);
            this.btnAdquirirImagen.TabIndex = 40;
            this.btnAdquirirImagen.Text = "&Adquirir imagen";
            this.btnAdquirirImagen.Click += new System.EventHandler(this.btnAdquirirImagen_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(1134, 343);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(159, 37);
            this.btnCancelar.TabIndex = 41;
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
            this.btnGuardar.Location = new System.Drawing.Point(440, 559);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(182, 37);
            this.btnGuardar.TabIndex = 42;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(29, 8);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(43, 13);
            this.labelControl7.TabIndex = 52;
            this.labelControl7.Text = "MONEDA";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl9.Appearance.Options.UseFont = true;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.Location = new System.Drawing.Point(269, 34);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(5, 18);
            this.labelControl9.TabIndex = 53;
            this.labelControl9.Text = ".";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(29, 34);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(37, 13);
            this.labelControl6.TabIndex = 54;
            this.labelControl6.Text = "MONTO";
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(126, 5);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.cboMoneda.Properties.Appearance.Options.UseForeColor = true;
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdMoneda", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionMoneda", "Descripcion")});
            this.cboMoneda.Properties.NullText = "- Seleccione el tipo de moneda -";
            this.cboMoneda.Properties.ShowFooter = false;
            this.cboMoneda.Properties.ShowHeader = false;
            this.cboMoneda.Size = new System.Drawing.Size(246, 20);
            this.cboMoneda.TabIndex = 55;
            this.cboMoneda.EditValueChanged += new System.EventHandler(this.cboMoneda_EditValueChanged);
            // 
            // txtCentimos
            // 
            this.txtCentimos.EditValue = "00";
            this.txtCentimos.Location = new System.Drawing.Point(277, 31);
            this.txtCentimos.Name = "txtCentimos";
            this.txtCentimos.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtCentimos.Properties.Appearance.Options.UseForeColor = true;
            this.txtCentimos.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCentimos.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCentimos.Size = new System.Drawing.Size(34, 20);
            this.txtCentimos.TabIndex = 57;
            this.txtCentimos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCentimos_KeyPress);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(126, 31);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtMonto.Properties.Appearance.Options.UseForeColor = true;
            this.txtMonto.Size = new System.Drawing.Size(140, 20);
            this.txtMonto.TabIndex = 56;
            this.txtMonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMonto_KeyDown);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // pnlMoneda
            // 
            this.pnlMoneda.Controls.Add(this.cboMoneda);
            this.pnlMoneda.Controls.Add(this.labelControl6);
            this.pnlMoneda.Controls.Add(this.labelControl9);
            this.pnlMoneda.Controls.Add(this.labelControl7);
            this.pnlMoneda.Controls.Add(this.txtMonto);
            this.pnlMoneda.Controls.Add(this.txtCentimos);
            this.pnlMoneda.Location = new System.Drawing.Point(12, 78);
            this.pnlMoneda.Name = "pnlMoneda";
            this.pnlMoneda.Size = new System.Drawing.Size(399, 60);
            this.pnlMoneda.TabIndex = 58;
            this.pnlMoneda.Visible = false;
            // 
            // chkConAutogenerado
            // 
            this.chkConAutogenerado.EditValue = true;
            this.chkConAutogenerado.Location = new System.Drawing.Point(440, 534);
            this.chkConAutogenerado.Name = "chkConAutogenerado";
            this.chkConAutogenerado.Properties.Caption = "Asociar autogerado al documento";
            this.chkConAutogenerado.Size = new System.Drawing.Size(182, 19);
            this.chkConAutogenerado.TabIndex = 59;
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Enabled = false;
            this.pdfViewer1.Location = new System.Drawing.Point(440, 12);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            this.pdfViewer1.ReadOnly = true;
            this.pdfViewer1.Size = new System.Drawing.Size(514, 477);
            this.pdfViewer1.TabIndex = 60;
            this.pdfViewer1.PopupMenuShowing += new DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventHandler(this.pdfViewer1_PopupMenuShowing);
            // 
            // btnPDF
            // 
            this.btnPDF.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPDF.Enabled = false;
            this.btnPDF.Location = new System.Drawing.Point(917, 496);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(37, 23);
            this.btnPDF.TabIndex = 61;
            this.btnPDF.Text = "...";
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // txtRutaArchivoPDF
            // 
            this.txtRutaArchivoPDF.BackColor = System.Drawing.Color.White;
            this.txtRutaArchivoPDF.Enabled = false;
            this.txtRutaArchivoPDF.Location = new System.Drawing.Point(593, 497);
            this.txtRutaArchivoPDF.Name = "txtRutaArchivoPDF";
            this.txtRutaArchivoPDF.ReadOnly = true;
            this.txtRutaArchivoPDF.Size = new System.Drawing.Size(323, 21);
            this.txtRutaArchivoPDF.TabIndex = 62;
            // 
            // lblRutaPDF
            // 
            this.lblRutaPDF.Enabled = false;
            this.lblRutaPDF.Location = new System.Drawing.Point(440, 501);
            this.lblRutaPDF.Name = "lblRutaPDF";
            this.lblRutaPDF.Size = new System.Drawing.Size(147, 13);
            this.lblRutaPDF.TabIndex = 63;
            this.lblRutaPDF.Text = "Requiere adjuntar archivo PDF";
            // 
            // frmRegistroDigitalizacionDocumentos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 606);
            this.Controls.Add(this.lblRutaPDF);
            this.Controls.Add(this.txtRutaArchivoPDF);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.chkConAutogenerado);
            this.Controls.Add(this.pnlMoneda);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnAdquirirImagen);
            this.Controls.Add(this.picDocumento);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmRegistroDigitalizacionDocumentos";
            this.Tag = "Digitalizar-documentos";
            this.Text = "Digitalizar documentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegistroDigitalizacionDocumentos_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegistroDigitalizacionDocumentos_FormClosed);
            this.Load += new System.EventHandler(this.frmRegistroDigitalizacionDocumentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDestino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCentimos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMoneda)).EndInit();
            this.pnlMoneda.ResumeLayout(false);
            this.pnlMoneda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkConAutogenerado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboDestino;
        private DevExpress.XtraEditors.LookUpEdit cboTipoDocumento;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PictureEdit picDocumento;
        private DevExpress.XtraEditors.SimpleButton btnAdquirirImagen;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.TextEdit txtCentimos;
        private DevExpress.XtraEditors.TextEdit txtMonto;
        private DevExpress.XtraEditors.PanelControl pnlMoneda;
        private DevExpress.XtraEditors.CheckEdit chkConAutogenerado;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraEditors.SimpleButton btnPDF;
        private System.Windows.Forms.TextBox txtRutaArchivoPDF;
        private DevExpress.XtraEditors.LabelControl lblRutaPDF;
    }
}