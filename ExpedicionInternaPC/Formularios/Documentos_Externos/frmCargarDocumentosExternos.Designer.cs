namespace ExpedicionInternaPC
{
    partial class frmCargarDocumentosExternos
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
            this.cboTipoDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdDocumentosExternos = new DevExpress.XtraGrid.GridControl();
            this.grvDocumentosExternos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPrimero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSegundo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTercero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBuscarArchivo = new DevExpress.XtraEditors.SimpleButton();
            this.btnVistaPrevia = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargarRegistros = new DevExpress.XtraEditors.SimpleButton();
            this.txtArchivoDatos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentosExternos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocumentosExternos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivoDatos.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.Location = new System.Drawing.Point(107, 18);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoDocumento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoDocumentoExterno", "iIdTipoDocumentoExterno", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoDocumentoExterno", "sDescripcionTipoDocumentoExterno")});
            this.cboTipoDocumento.Properties.NullText = "";
            this.cboTipoDocumento.Properties.ShowFooter = false;
            this.cboTipoDocumento.Properties.ShowHeader = false;
            this.cboTipoDocumento.Properties.EditValueChanged += new System.EventHandler(this.cboTipoDocumento_Properties_EditValueChanged);
            this.cboTipoDocumento.Size = new System.Drawing.Size(222, 20);
            this.cboTipoDocumento.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(83, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tipo documento :";
            // 
            // grdDocumentosExternos
            // 
            this.grdDocumentosExternos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDocumentosExternos.Location = new System.Drawing.Point(12, 71);
            this.grdDocumentosExternos.MainView = this.grvDocumentosExternos;
            this.grdDocumentosExternos.Name = "grdDocumentosExternos";
            this.grdDocumentosExternos.Size = new System.Drawing.Size(834, 491);
            this.grdDocumentosExternos.TabIndex = 2;
            this.grdDocumentosExternos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDocumentosExternos});
            // 
            // grvDocumentosExternos
            // 
            this.grvDocumentosExternos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPrimero,
            this.colSegundo,
            this.colTercero,
            this.colEstado});
            this.grvDocumentosExternos.GridControl = this.grdDocumentosExternos;
            this.grvDocumentosExternos.Name = "grvDocumentosExternos";
            this.grvDocumentosExternos.OptionsView.ShowFooter = true;
            this.grvDocumentosExternos.OptionsView.ShowGroupPanel = false;
            // 
            // colPrimero
            // 
            this.colPrimero.Caption = "Identificador destinatario";
            this.colPrimero.FieldName = "sDestinatario";
            this.colPrimero.Name = "colPrimero";
            this.colPrimero.OptionsColumn.ReadOnly = true;
            this.colPrimero.Visible = true;
            this.colPrimero.VisibleIndex = 0;
            // 
            // colSegundo
            // 
            this.colSegundo.Caption = "Nro. documento";
            this.colSegundo.FieldName = "Codigo";
            this.colSegundo.Name = "colSegundo";
            this.colSegundo.OptionsColumn.ReadOnly = true;
            this.colSegundo.Visible = true;
            this.colSegundo.VisibleIndex = 1;
            // 
            // colTercero
            // 
            this.colTercero.Caption = "Destino";
            this.colTercero.FieldName = "Destino";
            this.colTercero.Name = "colTercero";
            this.colTercero.OptionsColumn.ReadOnly = true;
            this.colTercero.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "sDestinatario", "{0}")});
            this.colTercero.Visible = true;
            this.colTercero.VisibleIndex = 2;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 3;
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBuscarArchivo.Location = new System.Drawing.Point(411, 42);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(26, 23);
            this.btnBuscarArchivo.TabIndex = 3;
            this.btnBuscarArchivo.Text = "...";
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // btnVistaPrevia
            // 
            this.btnVistaPrevia.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnVistaPrevia.Location = new System.Drawing.Point(448, 42);
            this.btnVistaPrevia.Name = "btnVistaPrevia";
            this.btnVistaPrevia.Size = new System.Drawing.Size(75, 23);
            this.btnVistaPrevia.TabIndex = 4;
            this.btnVistaPrevia.Text = "Vista previa";
            this.btnVistaPrevia.Click += new System.EventHandler(this.btnVistaPrevia_Click);
            // 
            // btnCargarRegistros
            // 
            this.btnCargarRegistros.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCargarRegistros.Location = new System.Drawing.Point(560, 42);
            this.btnCargarRegistros.Name = "btnCargarRegistros";
            this.btnCargarRegistros.Size = new System.Drawing.Size(90, 23);
            this.btnCargarRegistros.TabIndex = 5;
            this.btnCargarRegistros.Text = "Cargar registros";
            this.btnCargarRegistros.Click += new System.EventHandler(this.btnCargarRegistros_Click);
            // 
            // txtArchivoDatos
            // 
            this.txtArchivoDatos.Location = new System.Drawing.Point(107, 44);
            this.txtArchivoDatos.Name = "txtArchivoDatos";
            this.txtArchivoDatos.Properties.ReadOnly = true;
            this.txtArchivoDatos.Size = new System.Drawing.Size(303, 20);
            this.txtArchivoDatos.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 47);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(88, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Archivo de datos :";
            // 
            // frmCargarDocumentosExternos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 574);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtArchivoDatos);
            this.Controls.Add(this.btnCargarRegistros);
            this.Controls.Add(this.btnVistaPrevia);
            this.Controls.Add(this.btnBuscarArchivo);
            this.Controls.Add(this.grdDocumentosExternos);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboTipoDocumento);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmCargarDocumentosExternos";
            this.Text = "Cargar Documentos Externos";
            this.Load += new System.EventHandler(this.frmCargarDocumentosExternos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentosExternos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocumentosExternos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivoDatos.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboTipoDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdDocumentosExternos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDocumentosExternos;
        private DevExpress.XtraEditors.SimpleButton btnBuscarArchivo;
        private DevExpress.XtraEditors.SimpleButton btnVistaPrevia;
        private DevExpress.XtraEditors.SimpleButton btnCargarRegistros;
        private DevExpress.XtraEditors.TextEdit txtArchivoDatos;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colPrimero;
        private DevExpress.XtraGrid.Columns.GridColumn colSegundo;
        private DevExpress.XtraGrid.Columns.GridColumn colTercero;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
    }
}