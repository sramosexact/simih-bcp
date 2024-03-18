namespace ExpedicionInternaPC
{
    partial class frmTipoDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoDocumento));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.cboTipoCorrespondencia = new DevExpress.XtraEditors.LookUpEdit();
            this.cboValor = new DevExpress.XtraEditors.LookUpEdit();
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnModificar = new DevExpress.XtraEditors.SimpleButton();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEditarCamposDinamicos = new DevExpress.XtraEditors.SimpleButton();
            this.grdDocumentos = new DevExpress.XtraGrid.GridControl();
            this.grvDocumentos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntregaPersonalizada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdTipoCorrespondencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoCorrespondencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colITipoValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoValor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdModulo = new DevExpress.XtraGrid.GridControl();
            this.grvModulo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccionGrafica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CheckSeleccionGrafica = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkEntregaPersonalizada = new DevExpress.XtraEditors.CheckEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCorrespondencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocumentos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckSeleccionGrafica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntregaPersonalizada.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 38);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Descripción :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 64);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(126, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tipo de Correspondencia :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 90);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(69, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tipo de valor :";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Enabled = false;
            this.txtDescripcion.Location = new System.Drawing.Point(151, 37);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(301, 20);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // cboTipoCorrespondencia
            // 
            this.cboTipoCorrespondencia.Enabled = false;
            this.cboTipoCorrespondencia.Location = new System.Drawing.Point(151, 63);
            this.cboTipoCorrespondencia.Name = "cboTipoCorrespondencia";
            this.cboTipoCorrespondencia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoCorrespondencia.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoCorrespondencia", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoCorrespondencia", "Descripcion")});
            this.cboTipoCorrespondencia.Properties.NullText = "";
            this.cboTipoCorrespondencia.Properties.ShowFooter = false;
            this.cboTipoCorrespondencia.Properties.ShowHeader = false;
            this.cboTipoCorrespondencia.Size = new System.Drawing.Size(301, 20);
            this.cboTipoCorrespondencia.TabIndex = 4;
            // 
            // cboValor
            // 
            this.cboValor.Enabled = false;
            this.cboValor.Location = new System.Drawing.Point(151, 89);
            this.cboValor.Name = "cboValor";
            this.cboValor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboValor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboValor.Properties.NullText = "";
            this.cboValor.Properties.ShowFooter = false;
            this.cboValor.Properties.ShowHeader = false;
            this.cboValor.Size = new System.Drawing.Size(301, 20);
            this.cboValor.TabIndex = 5;
            // 
            // btnNuevo
            // 
            this.btnNuevo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnNuevo.ImageOptions.ImageIndex = 0;
            this.btnNuevo.ImageOptions.ImageList = this.imageCollection1;
            this.btnNuevo.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnNuevo.Location = new System.Drawing.Point(5, 5);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(102, 42);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.AddDev32, "AddDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "AddDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.CancelDev32, "CancelDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "CancelDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.RefreshDev32, "RefreshDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "RefreshDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 3);
            this.imageCollection1.Images.SetKeyName(3, "SaveDev32");
            // 
            // btnModificar
            // 
            this.btnModificar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnModificar.ImageOptions.ImageIndex = 2;
            this.btnModificar.ImageOptions.ImageList = this.imageCollection1;
            this.btnModificar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnModificar.Location = new System.Drawing.Point(113, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 42);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.ImageOptions.ImageIndex = 3;
            this.btnGuardar.ImageOptions.ImageList = this.imageCollection1;
            this.btnGuardar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnGuardar.Location = new System.Drawing.Point(221, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 42);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.Enabled = false;
            this.btnCancelar.ImageOptions.ImageIndex = 1;
            this.btnCancelar.ImageOptions.ImageList = this.imageCollection1;
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelar.Location = new System.Drawing.Point(329, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 42);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnEditarCamposDinamicos);
            this.panelControl1.Controls.Add(this.btnNuevo);
            this.panelControl1.Controls.Add(this.btnCancelar);
            this.panelControl1.Controls.Add(this.btnModificar);
            this.panelControl1.Controls.Add(this.btnGuardar);
            this.panelControl1.Location = new System.Drawing.Point(472, 52);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(648, 53);
            this.panelControl1.TabIndex = 7;
            // 
            // btnEditarCamposDinamicos
            // 
            this.btnEditarCamposDinamicos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnEditarCamposDinamicos.Enabled = false;
            this.btnEditarCamposDinamicos.ImageOptions.ImageIndex = 2;
            this.btnEditarCamposDinamicos.ImageOptions.ImageList = this.imageCollection1;
            this.btnEditarCamposDinamicos.Location = new System.Drawing.Point(465, 8);
            this.btnEditarCamposDinamicos.Name = "btnEditarCamposDinamicos";
            this.btnEditarCamposDinamicos.Size = new System.Drawing.Size(176, 39);
            this.btnEditarCamposDinamicos.TabIndex = 7;
            this.btnEditarCamposDinamicos.Text = "&Editar campos dinámicos";
            this.btnEditarCamposDinamicos.Click += new System.EventHandler(this.btnEditarCamposDinamicos_Click);
            // 
            // grdDocumentos
            // 
            this.grdDocumentos.Location = new System.Drawing.Point(2, 159);
            this.grdDocumentos.MainView = this.grvDocumentos;
            this.grdDocumentos.Name = "grdDocumentos";
            this.grdDocumentos.Size = new System.Drawing.Size(1123, 228);
            this.grdDocumentos.TabIndex = 2;
            this.grdDocumentos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDocumentos});
            // 
            // grvDocumentos
            // 
            this.grvDocumentos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccion,
            this.colIdTipoDocumento,
            this.colTipoDocumento,
            this.colEntregaPersonalizada,
            this.colIdTipoCorrespondencia,
            this.colTipoCorrespondencia,
            this.colITipoValor,
            this.colTipoValor});
            this.grvDocumentos.GridControl = this.grdDocumentos;
            this.grvDocumentos.Name = "grvDocumentos";
            this.grvDocumentos.OptionsView.ShowAutoFilterRow = true;
            this.grvDocumentos.OptionsView.ShowGroupPanel = false;
            this.grvDocumentos.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDocumentos_CellValueChanging);
            // 
            // colSeleccion
            // 
            this.colSeleccion.Caption = "Selección";
            this.colSeleccion.FieldName = "SeleccionGrafica";
            this.colSeleccion.MaxWidth = 60;
            this.colSeleccion.MinWidth = 60;
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSeleccion.Visible = true;
            this.colSeleccion.VisibleIndex = 0;
            this.colSeleccion.Width = 60;
            // 
            // colIdTipoDocumento
            // 
            this.colIdTipoDocumento.Caption = "IdTipoDocumento";
            this.colIdTipoDocumento.FieldName = "iIdTipoDocumento";
            this.colIdTipoDocumento.Name = "colIdTipoDocumento";
            this.colIdTipoDocumento.OptionsColumn.ReadOnly = true;
            this.colIdTipoDocumento.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colTipoDocumento
            // 
            this.colTipoDocumento.Caption = "Tipo de documento";
            this.colTipoDocumento.FieldName = "sDescripcionTipoDocumento";
            this.colTipoDocumento.MinWidth = 200;
            this.colTipoDocumento.Name = "colTipoDocumento";
            this.colTipoDocumento.OptionsColumn.ReadOnly = true;
            this.colTipoDocumento.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTipoDocumento.Visible = true;
            this.colTipoDocumento.VisibleIndex = 1;
            this.colTipoDocumento.Width = 200;
            // 
            // colEntregaPersonalizada
            // 
            this.colEntregaPersonalizada.Caption = "Requiere entrega personalizada";
            this.colEntregaPersonalizada.FieldName = "entregaPersonalizada";
            this.colEntregaPersonalizada.Name = "colEntregaPersonalizada";
            this.colEntregaPersonalizada.OptionsColumn.ReadOnly = true;
            this.colEntregaPersonalizada.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEntregaPersonalizada.Visible = true;
            this.colEntregaPersonalizada.VisibleIndex = 4;
            // 
            // colIdTipoCorrespondencia
            // 
            this.colIdTipoCorrespondencia.Caption = "IdTipoCorrespondencia";
            this.colIdTipoCorrespondencia.FieldName = "iIdTipoCorrespondencia";
            this.colIdTipoCorrespondencia.Name = "colIdTipoCorrespondencia";
            this.colIdTipoCorrespondencia.OptionsColumn.ReadOnly = true;
            this.colIdTipoCorrespondencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colTipoCorrespondencia
            // 
            this.colTipoCorrespondencia.Caption = "Tipo Correspondencia";
            this.colTipoCorrespondencia.FieldName = "sDescripcionTipoCorrespondencia";
            this.colTipoCorrespondencia.MaxWidth = 400;
            this.colTipoCorrespondencia.MinWidth = 300;
            this.colTipoCorrespondencia.Name = "colTipoCorrespondencia";
            this.colTipoCorrespondencia.OptionsColumn.ReadOnly = true;
            this.colTipoCorrespondencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTipoCorrespondencia.Visible = true;
            this.colTipoCorrespondencia.VisibleIndex = 2;
            this.colTipoCorrespondencia.Width = 300;
            // 
            // colITipoValor
            // 
            this.colITipoValor.Caption = "ITipoValor";
            this.colITipoValor.FieldName = "iMoneda";
            this.colITipoValor.Name = "colITipoValor";
            this.colITipoValor.OptionsColumn.ReadOnly = true;
            this.colITipoValor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colTipoValor
            // 
            this.colTipoValor.Caption = "Tipo de valor";
            this.colTipoValor.FieldName = "sDescripcionValor";
            this.colTipoValor.MaxWidth = 300;
            this.colTipoValor.MinWidth = 200;
            this.colTipoValor.Name = "colTipoValor";
            this.colTipoValor.OptionsColumn.ReadOnly = true;
            this.colTipoValor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTipoValor.Visible = true;
            this.colTipoValor.VisibleIndex = 3;
            this.colTipoValor.Width = 200;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdModulo);
            this.layoutControl1.Controls.Add(this.panelControl2);
            this.layoutControl1.Controls.Add(this.grdDocumentos);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1127, 538);
            this.layoutControl1.TabIndex = 9;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdModulo
            // 
            this.grdModulo.Enabled = false;
            this.grdModulo.Location = new System.Drawing.Point(2, 407);
            this.grdModulo.MainView = this.grvModulo;
            this.grdModulo.Name = "grdModulo";
            this.grdModulo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.CheckSeleccionGrafica,
            this.repositoryItemButtonEdit1});
            this.grdModulo.Size = new System.Drawing.Size(1123, 129);
            this.grdModulo.TabIndex = 3;
            this.grdModulo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvModulo});
            // 
            // grvModulo
            // 
            this.grvModulo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccionGrafica,
            this.colId,
            this.colDescripcion});
            this.grvModulo.GridControl = this.grdModulo;
            this.grvModulo.Name = "grvModulo";
            this.grvModulo.OptionsView.ShowGroupPanel = false;
            this.grvModulo.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvModulo_CellValueChanged);
            this.grvModulo.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvModulo_CellValueChanging);
            this.grvModulo.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grvModulo_ValidatingEditor);
            // 
            // colSeleccionGrafica
            // 
            this.colSeleccionGrafica.Caption = "Asociado";
            this.colSeleccionGrafica.ColumnEdit = this.CheckSeleccionGrafica;
            this.colSeleccionGrafica.FieldName = "SeleccionGrafica";
            this.colSeleccionGrafica.MaxWidth = 60;
            this.colSeleccionGrafica.MinWidth = 60;
            this.colSeleccionGrafica.Name = "colSeleccionGrafica";
            this.colSeleccionGrafica.Visible = true;
            this.colSeleccionGrafica.VisibleIndex = 0;
            this.colSeleccionGrafica.Width = 60;
            // 
            // CheckSeleccionGrafica
            // 
            this.CheckSeleccionGrafica.AutoHeight = false;
            this.CheckSeleccionGrafica.Name = "CheckSeleccionGrafica";
            this.CheckSeleccionGrafica.CheckedChanged += new System.EventHandler(this.CheckSeleccionGrafica_CheckedChanged);
            this.CheckSeleccionGrafica.CheckStateChanged += new System.EventHandler(this.CheckSeleccionGrafica_CheckStateChanged);
            this.CheckSeleccionGrafica.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.CheckSeleccionGrafica_EditValueChanging);
            // 
            // colId
            // 
            this.colId.Caption = "ID";
            this.colId.FieldName = "iId";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "sDescripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.chkEntregaPersonalizada);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.cboValor);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.cboTipoCorrespondencia);
            this.panelControl2.Controls.Add(this.txtDescripcion);
            this.panelControl2.Location = new System.Drawing.Point(2, 2);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1123, 153);
            this.panelControl2.TabIndex = 0;
            // 
            // chkEntregaPersonalizada
            // 
            this.chkEntregaPersonalizada.Enabled = false;
            this.chkEntregaPersonalizada.Location = new System.Drawing.Point(151, 115);
            this.chkEntregaPersonalizada.Name = "chkEntregaPersonalizada";
            this.chkEntregaPersonalizada.Properties.Caption = "Requiere entrega personalizada";
            this.chkEntregaPersonalizada.Size = new System.Drawing.Size(182, 19);
            this.chkEntregaPersonalizada.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1127, 538);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdDocumentos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 157);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1127, 232);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.panelControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 157);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(5, 157);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1127, 157);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grdModulo;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 389);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(1127, 149);
            this.layoutControlItem3.Text = "Módulo asociado";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(79, 13);
            // 
            // frmTipoDocumento
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 538);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmTipoDocumento";
            this.Text = "Tipo de documento";
            this.Activated += new System.EventHandler(this.frmTipoDocumento_Activated);
            this.Deactivate += new System.EventHandler(this.frmTipoDocumento_Deactivate);
            this.Load += new System.EventHandler(this.frmTipoDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoCorrespondencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboValor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDocumentos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckSeleccionGrafica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkEntregaPersonalizada.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private DevExpress.XtraEditors.LookUpEdit cboTipoCorrespondencia;
        private DevExpress.XtraEditors.LookUpEdit cboValor;
        private DevExpress.XtraEditors.SimpleButton btnNuevo;
        private DevExpress.XtraEditors.SimpleButton btnModificar;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdDocumentos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDocumentos;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colIdTipoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colIdTipoCorrespondencia;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoCorrespondencia;
        private DevExpress.XtraGrid.Columns.GridColumn colITipoValor;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoValor;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccion;
        private DevExpress.XtraGrid.GridControl grdModulo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvModulo;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionGrafica;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit CheckSeleccionGrafica;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.SimpleButton btnEditarCamposDinamicos;
        private DevExpress.XtraEditors.CheckEdit chkEntregaPersonalizada;
        private DevExpress.XtraGrid.Columns.GridColumn colEntregaPersonalizada;
    }
}