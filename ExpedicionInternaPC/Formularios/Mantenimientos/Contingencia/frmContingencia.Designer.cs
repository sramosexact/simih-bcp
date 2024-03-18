namespace ExpedicionInternaPC
{
    partial class frmContingencia
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtArchivoDatos = new DevExpress.XtraEditors.TextEdit();
            this.btnCargarRegistros = new DevExpress.XtraEditors.SimpleButton();
            this.btnVistaPrevia = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscarArchivo = new DevExpress.XtraEditors.SimpleButton();
            this.grdDocumentosContingencia = new DevExpress.XtraGrid.GridControl();
            this.grvDocumentosContingencia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrimero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSegundo = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivoDatos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentosContingencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocumentosContingencia)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 25);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 13);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Archivo de datos :";
            // 
            // txtArchivoDatos
            // 
            this.txtArchivoDatos.Location = new System.Drawing.Point(109, 22);
            this.txtArchivoDatos.Name = "txtArchivoDatos";
            this.txtArchivoDatos.Properties.ReadOnly = true;
            this.txtArchivoDatos.Size = new System.Drawing.Size(173, 20);
            this.txtArchivoDatos.TabIndex = 12;
            // 
            // btnCargarRegistros
            // 
            this.btnCargarRegistros.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCargarRegistros.Location = new System.Drawing.Point(396, 20);
            this.btnCargarRegistros.Name = "btnCargarRegistros";
            this.btnCargarRegistros.Size = new System.Drawing.Size(90, 23);
            this.btnCargarRegistros.TabIndex = 11;
            this.btnCargarRegistros.Text = "Cargar registros";
            this.btnCargarRegistros.Click += new System.EventHandler(this.btnCargarRegistros_Click);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnVistaPrevia.Location = new System.Drawing.Point(315, 20);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(75, 23);
            this.btnVistaPrevia.TabIndex = 10;
            this.btnVistaPrevia.Text = "Vista previa";
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBuscarArchivo.Location = new System.Drawing.Point(283, 20);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarArchivo.TabIndex = 9;
            this.btnBuscarArchivo.Text = "...";
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // grdDocumentosContingencia
            // 
            this.grdDocumentosContingencia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDocumentosContingencia.Location = new System.Drawing.Point(13, 60);
            this.grdDocumentosContingencia.MainView = this.grvDocumentosContingencia;
            this.grdDocumentosContingencia.Name = "grdDocumentosContingencia";
            this.grdDocumentosContingencia.Size = new System.Drawing.Size(469, 339);
            this.grdDocumentosContingencia.TabIndex = 8;
            this.grdDocumentosContingencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDocumentosContingencia});
            // 
            // grvDocumentosContingencia
            // 
            this.grvDocumentosContingencia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrimero,
            this.colSegundo});
            this.grvDocumentosContingencia.GridControl = this.grdDocumentosContingencia;
            this.grvDocumentosContingencia.Name = "grvDocumentosContingencia";
            this.grvDocumentosContingencia.OptionsView.ShowFooter = true;
            this.grvDocumentosContingencia.OptionsView.ShowGroupPanel = false;
            // 
            // colPrimero
            // 
            this.colPrimero.Caption = "Código de Documento";
            this.colPrimero.FieldName = "Autogenerado";
            this.colPrimero.Name = "colPrimero";
            this.colPrimero.OptionsColumn.ReadOnly = true;
            this.colPrimero.Visible = true;
            this.colPrimero.VisibleIndex = 0;
            this.colPrimero.Width = 361;
            // 
            // colSegundo
            // 
            this.colSegundo.Caption = "Impreso";
            this.colSegundo.FieldName = "Impreso";
            this.colSegundo.Name = "colSegundo";
            this.colSegundo.OptionsColumn.ReadOnly = true;
            this.colSegundo.Visible = true;
            this.colSegundo.VisibleIndex = 1;
            this.colSegundo.Width = 95;
            // 
            // frmContingencia
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 411);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtArchivoDatos);
            this.Controls.Add(this.btnCargarRegistros);
            this.Controls.Add(this.btnVistaPrevia);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.grdDocumentosContingencia);
            this.Name = "frmContingencia";
            this.Text = "Carga de Archivo de Contingencia";
            this.Load += new System.EventHandler(this.frmContingencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivoDatos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentosContingencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocumentosContingencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtArchivoDatos;
        private DevExpress.XtraEditors.SimpleButton btnCargarRegistros;
        private DevExpress.XtraEditors.SimpleButton btnVistaPrevia;
        private DevExpress.XtraEditors.SimpleButton btnBuscarArchivo;
        private DevExpress.XtraGrid.GridControl grdDocumentosContingencia;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDocumentosContingencia;
        private DevExpress.XtraGrid.Columns.GridColumn colPrimero;
        private DevExpress.XtraGrid.Columns.GridColumn colSegundo;
    }
}