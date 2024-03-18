namespace ExpedicionInternaPC
{
    partial class frmNuevaMesaParte
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaMesaParte));
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.txt_Monto = new DevExpress.XtraEditors.SpinEdit();
            this.bsObjeto2 = new System.Windows.Forms.BindingSource(this.components);
            this.txt_Procedencia = new DevExpress.XtraEditors.TextEdit();
            this.casillaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btn_Buscar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDetalle = new DevExpress.XtraGrid.GridControl();
            this.grvDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProcedencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMoneda = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbMoneda = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.colCantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEliminar2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imgEliminar = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbTipoDocumento = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.f = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.bsObjeto = new System.Windows.Forms.BindingSource(this.components);
            this.cboTipoEmpaque = new DevExpress.XtraEditors.LookUpEdit();
            this.tipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cboBandejaOrigen = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblMonto = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboPara = new DevExpress.XtraEditors.LookUpEdit();
            this.cbTipoDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.cboMoneda = new DevExpress.XtraEditors.LookUpEdit();
            this.btn_Grabar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancelar = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_Resultado = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Observacion = new DevExpress.XtraEditors.TextEdit();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Monto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjeto2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Procedencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casillaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoneda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDocumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.f)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjeto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoEmpaque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBandejaOrigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Observacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAgregar.Appearance.Options.UseFont = true;
            this.btnAgregar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAgregar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.AddDev32;
            this.btnAgregar.Location = new System.Drawing.Point(182, 225);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(118, 42);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txt_Monto
            // 
            this.txt_Monto.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_Monto.Location = new System.Drawing.Point(382, 141);
            this.txt_Monto.Name = "txt_Monto";
            this.txt_Monto.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_Monto.Properties.Appearance.Options.UseFont = true;
            this.txt_Monto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txt_Monto.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txt_Monto.Properties.IsFloatValue = false;
            this.txt_Monto.Properties.Mask.EditMask = "N00";
            this.txt_Monto.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txt_Monto.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_Monto.Size = new System.Drawing.Size(105, 22);
            this.txt_Monto.TabIndex = 5;
            // 
            // bsObjeto2
            // 
            ////////////this.bsObjeto2.DataSource = typeof(ExpedicionInternaPC.ServiceObjetoWS.Objeto);
            // 
            // txt_Procedencia
            // 
            this.txt_Procedencia.Location = new System.Drawing.Point(182, 169);
            this.txt_Procedencia.Name = "txt_Procedencia";
            this.txt_Procedencia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_Procedencia.Properties.Appearance.Options.UseFont = true;
            this.txt_Procedencia.Properties.Mask.EditMask = "\\p{Lu}+.+";
            this.txt_Procedencia.Size = new System.Drawing.Size(305, 22);
            this.txt_Procedencia.TabIndex = 6;
            this.txt_Procedencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Procedencia_KeyPress);
            // 
            // casillaBindingSource
            // 
            ////////////this.casillaBindingSource.DataSource = typeof(ExpedicionInternaPC.ServiceCasillaWS.Casilla);
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btn_Buscar.Appearance.Options.UseFont = true;
            this.btn_Buscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_Buscar.Location = new System.Drawing.Point(452, 55);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(35, 20);
            this.btn_Buscar.TabIndex = 1;
            this.btn_Buscar.Text = "...";
            this.btn_Buscar.Click += new System.EventHandler(this.btn_Buscar_Click);
            // 
            // grdDetalle
            // 
            this.grdDetalle.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdDetalle.Location = new System.Drawing.Point(3, 272);
            this.grdDetalle.MainView = this.grvDetalle;
            this.grdDetalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdDetalle.Name = "grdDetalle";
            this.grdDetalle.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cmbTipoDocumento,
            this.cmbMoneda,
            this.imgEliminar,
            this.f});
            this.grdDetalle.Size = new System.Drawing.Size(509, 227);
            this.grdDetalle.TabIndex = 8;
            this.grdDetalle.TabStop = false;
            this.grdDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetalle});
            // 
            // grvDetalle
            // 
            this.grvDetalle.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colTipoDocumento,
            this.colProcedencia,
            this.colMoneda,
            this.colCantidad,
            this.colEliminar2,
            this.colObservacion});
            this.grvDetalle.GridControl = this.grdDetalle;
            this.grvDetalle.Name = "grvDetalle";
            this.grvDetalle.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            this.grvDetalle.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.grvDetalle.OptionsCustomization.AllowColumnMoving = false;
            this.grvDetalle.OptionsCustomization.AllowFilter = false;
            this.grvDetalle.OptionsDetail.EnableMasterViewMode = false;
            this.grvDetalle.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.grvDetalle.OptionsView.EnableAppearanceEvenRow = true;
            this.grvDetalle.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.grvDetalle.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDetalle.OptionsView.ShowFooter = true;
            this.grvDetalle.OptionsView.ShowGroupPanel = false;
            this.grvDetalle.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.OptionsColumn.ShowInCustomizationForm = false;
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colID.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // colTipoDocumento
            // 
            this.colTipoDocumento.Caption = "Tipo Documento";
            this.colTipoDocumento.FieldName = "TipoDocumento";
            this.colTipoDocumento.MaxWidth = 600;
            this.colTipoDocumento.MinWidth = 120;
            this.colTipoDocumento.Name = "colTipoDocumento";
            this.colTipoDocumento.OptionsColumn.ReadOnly = true;
            this.colTipoDocumento.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTipoDocumento.Visible = true;
            this.colTipoDocumento.VisibleIndex = 0;
            this.colTipoDocumento.Width = 125;
            // 
            // colProcedencia
            // 
            this.colProcedencia.Caption = "Procedencia";
            this.colProcedencia.FieldName = "Descripcion";
            this.colProcedencia.MaxWidth = 600;
            this.colProcedencia.MinWidth = 100;
            this.colProcedencia.Name = "colProcedencia";
            this.colProcedencia.OptionsColumn.ReadOnly = true;
            this.colProcedencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colProcedencia.Visible = true;
            this.colProcedencia.VisibleIndex = 1;
            this.colProcedencia.Width = 101;
            // 
            // colMoneda
            // 
            this.colMoneda.Caption = "Moneda";
            this.colMoneda.ColumnEdit = this.cmbMoneda;
            this.colMoneda.FieldName = "MonedaS";
            this.colMoneda.MaxWidth = 60;
            this.colMoneda.MinWidth = 50;
            this.colMoneda.Name = "colMoneda";
            this.colMoneda.OptionsColumn.ReadOnly = true;
            this.colMoneda.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMoneda.Visible = true;
            this.colMoneda.VisibleIndex = 3;
            this.colMoneda.Width = 57;
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.AutoHeight = false;
            this.cmbMoneda.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbMoneda.Items.AddRange(new object[] {
            "NINGUNO",
            "SOLES",
            "DOLARES",
            "EUROS"});
            this.cmbMoneda.Name = "cmbMoneda";
            // 
            // colCantidad
            // 
            this.colCantidad.Caption = "Cantidad";
            this.colCantidad.FieldName = "cantidadBd";
            this.colCantidad.MaxWidth = 60;
            this.colCantidad.MinWidth = 50;
            this.colCantidad.Name = "colCantidad";
            this.colCantidad.OptionsColumn.ReadOnly = true;
            this.colCantidad.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCantidad.Visible = true;
            this.colCantidad.VisibleIndex = 4;
            this.colCantidad.Width = 60;
            // 
            // colEliminar2
            // 
            this.colEliminar2.Caption = "Eliminar";
            this.colEliminar2.ColumnEdit = this.imgEliminar;
            this.colEliminar2.MaxWidth = 60;
            this.colEliminar2.MinWidth = 50;
            this.colEliminar2.Name = "colEliminar2";
            this.colEliminar2.OptionsColumn.AllowMove = false;
            this.colEliminar2.OptionsColumn.AllowShowHide = false;
            this.colEliminar2.OptionsColumn.AllowSize = false;
            this.colEliminar2.OptionsColumn.ReadOnly = true;
            this.colEliminar2.OptionsColumn.ShowInCustomizationForm = false;
            this.colEliminar2.OptionsColumn.ShowInExpressionEditor = false;
            this.colEliminar2.OptionsColumn.TabStop = false;
            this.colEliminar2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "TipoDocumento", "")});
            this.colEliminar2.Visible = true;
            this.colEliminar2.VisibleIndex = 5;
            this.colEliminar2.Width = 60;
            // 
            // imgEliminar
            // 
            this.imgEliminar.AutoHeight = false;
            editorButtonImageOptions2.Image = global::ExpedicionInternaPC.Properties.Resources.delete32;
            this.imgEliminar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions2, DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, null)});
            this.imgEliminar.Images = this.imageCollection1;
            this.imgEliminar.Name = "imgEliminar";
            this.imgEliminar.PopupSizeable = false;
            this.imgEliminar.ReadOnly = true;
            this.imgEliminar.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.imgEliminar.ShowMenu = false;
            this.imgEliminar.ShowPopupShadow = false;
            this.imgEliminar.Click += new System.EventHandler(this.imgeliminar_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.delete32, "delete32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "delete32");
            // 
            // colObservacion
            // 
            this.colObservacion.Caption = "Observación";
            this.colObservacion.FieldName = "Observacion";
            this.colObservacion.Name = "colObservacion";
            this.colObservacion.OptionsColumn.AllowMove = false;
            this.colObservacion.OptionsColumn.AllowShowHide = false;
            this.colObservacion.OptionsColumn.AllowSize = false;
            this.colObservacion.OptionsColumn.ReadOnly = true;
            this.colObservacion.OptionsColumn.ShowInCustomizationForm = false;
            this.colObservacion.OptionsColumn.ShowInExpressionEditor = false;
            this.colObservacion.OptionsColumn.TabStop = false;
            this.colObservacion.Visible = true;
            this.colObservacion.VisibleIndex = 2;
            this.colObservacion.Width = 88;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.AutoHeight = false;
            this.cmbTipoDocumento.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            // 
            // f
            // 
            this.f.AutoHeight = false;
            this.f.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.f.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.f.Name = "f";
            this.f.ShowFooter = false;
            this.f.ShowHeader = false;
            // 
            // bsObjeto
            // 
            this.bsObjeto.DataSource = typeof(Interna.Entity.Objeto);
            // 
            // cboTipoEmpaque
            // 
            this.cboTipoEmpaque.EnterMoveNextControl = true;
            this.cboTipoEmpaque.Location = new System.Drawing.Point(182, 83);
            this.cboTipoEmpaque.Name = "cboTipoEmpaque";
            this.cboTipoEmpaque.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboTipoEmpaque.Properties.Appearance.Options.UseFont = true;
            this.cboTipoEmpaque.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoEmpaque.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoCorrespondencia", "iId", 5, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoCorrespondencia", "sDescripcion", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.cboTipoEmpaque.Properties.DataSource = this.tipoBindingSource;
            this.cboTipoEmpaque.Properties.DisplayMember = "Descripcion";
            this.cboTipoEmpaque.Properties.NullText = "Seleccione tipo de empaque";
            this.cboTipoEmpaque.Properties.ShowFooter = false;
            this.cboTipoEmpaque.Properties.ShowHeader = false;
            this.cboTipoEmpaque.Properties.ValueMember = "ID";
            this.cboTipoEmpaque.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboTipoEmpaque.Size = new System.Drawing.Size(305, 22);
            this.cboTipoEmpaque.TabIndex = 2;
            this.cboTipoEmpaque.EditValueChanged += new System.EventHandler(this.cboTipoEmpaque_EditValueChanged);
            // 
            // tipoBindingSource
            // 
            ////////////////this.tipoBindingSource.DataSource = typeof(ExpedicionInternaPC.ServiceObjetoWS.Tipo);
            // 
            // cboBandejaOrigen
            // 
            this.cboBandejaOrigen.Location = new System.Drawing.Point(182, 27);
            this.cboBandejaOrigen.Name = "cboBandejaOrigen";
            this.cboBandejaOrigen.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.cboBandejaOrigen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboBandejaOrigen.Properties.Appearance.Options.UseFont = true;
            this.cboBandejaOrigen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBandejaOrigen.Properties.ReadOnly = true;
            this.cboBandejaOrigen.Properties.View = this.searchLookUpEdit2View;
            this.cboBandejaOrigen.Size = new System.Drawing.Size(305, 22);
            this.cboBandejaOrigen.TabIndex = 2;
            // 
            // searchLookUpEdit2View
            // 
            this.searchLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.searchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit2View.Name = "searchLookUpEdit2View";
            this.searchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Bandeja";
            this.gridColumn1.FieldName = "Descripcion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Distrito";
            this.gridColumn2.FieldName = "distrito";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(32, 172);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 16);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Procedencia:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(32, 144);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 16);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Moneda:";
            // 
            // lblMonto
            // 
            this.lblMonto.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblMonto.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblMonto.Appearance.Options.UseFont = true;
            this.lblMonto.Appearance.Options.UseForeColor = true;
            this.lblMonto.Location = new System.Drawing.Point(319, 144);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(50, 16);
            this.lblMonto.TabIndex = 12;
            this.lblMonto.Text = "Cantidad";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(32, 114);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(115, 16);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Tipo de documento:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(32, 30);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(20, 16);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "De:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(32, 57);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(31, 16);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "Para:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(32, 86);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(105, 16);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "Tipo de empaque:";
            // 
            // cboPara
            // 
            this.cboPara.Location = new System.Drawing.Point(182, 55);
            this.cboPara.Name = "cboPara";
            this.cboPara.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.False;
            this.cboPara.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPara.Properties.Appearance.Options.UseFont = true;
            this.cboPara.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPara.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Nombre5")});
            this.cboPara.Properties.NullText = "Seleccione destinatario";
            this.cboPara.Properties.ReadOnly = true;
            this.cboPara.Properties.ShowFooter = false;
            this.cboPara.Properties.ShowHeader = false;
            this.cboPara.Size = new System.Drawing.Size(264, 22);
            this.cboPara.TabIndex = 0;
            // 
            // cbTipoDocumento
            // 
            this.cbTipoDocumento.EnterMoveNextControl = true;
            this.cbTipoDocumento.Location = new System.Drawing.Point(182, 111);
            this.cbTipoDocumento.Name = "cbTipoDocumento";
            this.cbTipoDocumento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cbTipoDocumento.Properties.Appearance.Options.UseFont = true;
            this.cbTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTipoDocumento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoDocumento", "sDescripcion"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoDocumento", "iId", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iMoneda", "iMoneda", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cbTipoDocumento.Properties.NullText = "Seleccione tipo de documento";
            this.cbTipoDocumento.Properties.ShowFooter = false;
            this.cbTipoDocumento.Properties.ShowHeader = false;
            this.cbTipoDocumento.Size = new System.Drawing.Size(305, 22);
            this.cbTipoDocumento.TabIndex = 3;
            this.cbTipoDocumento.EditValueChanged += new System.EventHandler(this.cbTipoDocumento_EditValueChanged_1);
            // 
            // cboMoneda
            // 
            this.cboMoneda.Location = new System.Drawing.Point(182, 141);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboMoneda.Properties.Appearance.Options.UseFont = true;
            this.cboMoneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMoneda.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdMoneda", "iIdMoneda", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionMoneda", "sDescripcionMoneda")});
            this.cboMoneda.Properties.NullText = "";
            this.cboMoneda.Properties.ShowFooter = false;
            this.cboMoneda.Properties.ShowHeader = false;
            this.cboMoneda.Size = new System.Drawing.Size(118, 22);
            this.cboMoneda.TabIndex = 4;
            this.cboMoneda.EditValueChanged += new System.EventHandler(this.cboMoneda_EditValueChanged);
            // 
            // btn_Grabar
            // 
            this.btn_Grabar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_Grabar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.SaveDev32;
            this.btn_Grabar.Location = new System.Drawing.Point(127, 504);
            this.btn_Grabar.Name = "btn_Grabar";
            this.btn_Grabar.Size = new System.Drawing.Size(118, 42);
            this.btn_Grabar.TabIndex = 9;
            this.btn_Grabar.Text = "&Grabar";
            this.btn_Grabar.Click += new System.EventHandler(this.btn_Grabar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btn_Cancelar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.CancelDev32;
            this.btn_Cancelar.Location = new System.Drawing.Point(3, 504);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(118, 42);
            this.btn_Cancelar.TabIndex = 10;
            this.btn_Cancelar.Text = "&Cancelar";
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbl_Resultado
            // 
            this.lbl_Resultado.Appearance.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.lbl_Resultado.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbl_Resultado.Appearance.Options.UseFont = true;
            this.lbl_Resultado.Appearance.Options.UseForeColor = true;
            this.lbl_Resultado.Location = new System.Drawing.Point(260, 518);
            this.lbl_Resultado.Name = "lbl_Resultado";
            this.lbl_Resultado.Size = new System.Drawing.Size(60, 13);
            this.lbl_Resultado.TabIndex = 24;
            this.lbl_Resultado.Text = "En espera...";
            this.lbl_Resultado.Visible = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(32, 200);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 16);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Observación:";
            // 
            // txt_Observacion
            // 
            this.txt_Observacion.Location = new System.Drawing.Point(182, 197);
            this.txt_Observacion.Name = "txt_Observacion";
            this.txt_Observacion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Observacion.Properties.Appearance.Options.UseFont = true;
            this.txt_Observacion.Size = new System.Drawing.Size(305, 22);
            this.txt_Observacion.TabIndex = 7;
            this.txt_Observacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Observacion_KeyPress);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // frmNuevaMesaParte
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 559);
            this.Controls.Add(this.txt_Observacion);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lbl_Resultado);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Grabar);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.cbTipoDocumento);
            this.Controls.Add(this.cboPara);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.btn_Buscar);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboTipoEmpaque);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.cboBandejaOrigen);
            this.Controls.Add(this.txt_Monto);
            this.Controls.Add(this.grdDetalle);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txt_Procedencia);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "frmNuevaMesaParte";
            this.Tag = "MesaParte";
            this.Text = "Mesa de Partes | Nueva Correspondencia";
            this.Load += new System.EventHandler(this.frmNuevaMesaParte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Monto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjeto2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Procedencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casillaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMoneda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTipoDocumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.f)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsObjeto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoEmpaque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBandejaOrigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit2View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMoneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Observacion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SearchLookUpEdit cboBandejaOrigen;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit2View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.LookUpEdit cboTipoEmpaque;
        private System.Windows.Forms.BindingSource tipoBindingSource;
        private DevExpress.XtraGrid.GridControl grdDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetalle;
        private System.Windows.Forms.BindingSource bsObjeto;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidad;
        private DevExpress.XtraGrid.Columns.GridColumn colProcedencia;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbTipoDocumento;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cmbMoneda;
        private DevExpress.XtraGrid.Columns.GridColumn colEliminar2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit imgEliminar;
        private DevExpress.XtraEditors.SimpleButton btn_Buscar;
        private System.Windows.Forms.BindingSource casillaBindingSource;
        private DevExpress.XtraEditors.TextEdit txt_Procedencia;
        private DevExpress.XtraEditors.SpinEdit txt_Monto;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private System.Windows.Forms.BindingSource bsObjeto2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblMonto;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit cboPara;
        private DevExpress.XtraEditors.LookUpEdit cbTipoDocumento;
        private DevExpress.XtraEditors.LookUpEdit cboMoneda;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit f;
        private DevExpress.XtraEditors.SimpleButton btn_Grabar;
        private DevExpress.XtraEditors.SimpleButton btn_Cancelar;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.LabelControl lbl_Resultado;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_Observacion;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}