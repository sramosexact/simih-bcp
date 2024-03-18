namespace ExpedicionInternaPC
{
    partial class frmDetalleDocumento
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
            this.picDocumento = new DevExpress.XtraEditors.PictureEdit();
            this.pnlContenedor = new DevExpress.XtraEditors.PanelControl();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.btnAmpliarImagen = new DevExpress.XtraEditors.SimpleButton();
            this.btnSeguimiento = new DevExpress.XtraEditors.SimpleButton();
            this.pdfViewer1 = new DevExpress.XtraPdfViewer.PdfViewer();
            this.btnAsociar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.picDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContenedor)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picDocumento
            // 
            this.picDocumento.Cursor = System.Windows.Forms.Cursors.Default;
            this.picDocumento.Location = new System.Drawing.Point(1244, 15);
            this.picDocumento.Name = "picDocumento";
            this.picDocumento.Properties.Appearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.picDocumento.Properties.Appearance.Options.UseBorderColor = true;
            this.picDocumento.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.picDocumento.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picDocumento.Properties.ZoomAccelerationFactor = 1D;
            this.picDocumento.Size = new System.Drawing.Size(209, 517);
            this.picDocumento.TabIndex = 52;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlContenedor.Appearance.Options.UseBackColor = true;
            this.pnlContenedor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 3);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(405, 561);
            this.pnlContenedor.TabIndex = 53;
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.pnlContenedor);
            this.xtraScrollableControl1.Location = new System.Drawing.Point(12, 12);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(405, 664);
            this.xtraScrollableControl1.TabIndex = 54;
            // 
            // btnAmpliarImagen
            // 
            this.btnAmpliarImagen.Appearance.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAmpliarImagen.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnAmpliarImagen.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAmpliarImagen.Appearance.Options.UseBackColor = true;
            this.btnAmpliarImagen.Appearance.Options.UseFont = true;
            this.btnAmpliarImagen.Appearance.Options.UseForeColor = true;
            this.btnAmpliarImagen.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAmpliarImagen.Location = new System.Drawing.Point(1244, 538);
            this.btnAmpliarImagen.Name = "btnAmpliarImagen";
            this.btnAmpliarImagen.Size = new System.Drawing.Size(159, 37);
            this.btnAmpliarImagen.TabIndex = 57;
            this.btnAmpliarImagen.Text = "Ampliar &imagen";
            this.btnAmpliarImagen.Click += new System.EventHandler(this.btnAmpliarImagen_Click);
            // 
            // btnSeguimiento
            // 
            this.btnSeguimiento.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSeguimiento.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.btnSeguimiento.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSeguimiento.Appearance.Options.UseBackColor = true;
            this.btnSeguimiento.Appearance.Options.UseFont = true;
            this.btnSeguimiento.Appearance.Options.UseForeColor = true;
            this.btnSeguimiento.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSeguimiento.Location = new System.Drawing.Point(1181, 455);
            this.btnSeguimiento.Name = "btnSeguimiento";
            this.btnSeguimiento.Size = new System.Drawing.Size(159, 37);
            this.btnSeguimiento.TabIndex = 58;
            this.btnSeguimiento.Text = "&Ver seguimiento";
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.Location = new System.Drawing.Point(436, 15);
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.NavigationPanePageVisibility = DevExpress.XtraPdfViewer.PdfNavigationPanePageVisibility.None;
            this.pdfViewer1.ReadOnly = true;
            this.pdfViewer1.Size = new System.Drawing.Size(514, 531);
            this.pdfViewer1.TabIndex = 61;
            this.pdfViewer1.PopupMenuShowing += new DevExpress.XtraPdfViewer.PdfPopupMenuShowingEventHandler(this.pdfViewer1_PopupMenuShowing);
            // 
            // btnAsociar
            // 
            this.btnAsociar.Appearance.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAsociar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAsociar.Appearance.Options.UseBackColor = true;
            this.btnAsociar.Appearance.Options.UseForeColor = true;
            this.btnAsociar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAsociar.Location = new System.Drawing.Point(783, 552);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(168, 23);
            this.btnAsociar.TabIndex = 62;
            this.btnAsociar.Text = "Registrar como nuevo ingreso";
            this.btnAsociar.Visible = false;
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
            // 
            // frmDetalleDocumento
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 587);
            this.Controls.Add(this.btnAsociar);
            this.Controls.Add(this.pdfViewer1);
            this.Controls.Add(this.btnSeguimiento);
            this.Controls.Add(this.btnAmpliarImagen);
            this.Controls.Add(this.xtraScrollableControl1);
            this.Controls.Add(this.picDocumento);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmDetalleDocumento";
            this.Text = "6";
            this.Load += new System.EventHandler(this.frmDetalleDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlContenedor)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit picDocumento;
        private DevExpress.XtraEditors.PanelControl pnlContenedor;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.SimpleButton btnAmpliarImagen;
        private DevExpress.XtraEditors.SimpleButton btnSeguimiento;
        private DevExpress.XtraPdfViewer.PdfViewer pdfViewer1;
        private DevExpress.XtraEditors.SimpleButton btnAsociar;
    }
}