namespace ExpedicionInternaPC
{
    partial class frmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.grdAgencia = new DevExpress.XtraGrid.GridControl();
            this.grvAgencia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUbicacionAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdUsuarioResponsable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBandeja = new DevExpress.XtraGrid.GridControl();
            this.grvBandeja = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdGeo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUbicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdUsuario = new DevExpress.XtraGrid.GridControl();
            this.grvUsuario = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatricula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDNI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResponsableAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navUsuario = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnNuevoUsuario = new DevExpress.XtraNavBar.NavBarItem();
            this.btnModificarUsuario = new DevExpress.XtraNavBar.NavBarItem();
            this.btnEliminarUsuario = new DevExpress.XtraNavBar.NavBarItem();
            this.navBandeja = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnVincularBandeja = new DevExpress.XtraNavBar.NavBarItem();
            this.navAgencia = new DevExpress.XtraNavBar.NavBarGroup();
            this.btnVincularFac = new DevExpress.XtraNavBar.NavBarItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnCargarUsuarios = new DevExpress.XtraEditors.SimpleButton();
            this.btnBuscarArchivo = new DevExpress.XtraEditors.SimpleButton();
            this.txtArchivoDatos = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandeja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandeja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivoDatos.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.grdAgencia);
            this.layoutControl1.Controls.Add(this.grdBandeja);
            this.layoutControl1.Controls.Add(this.grdUsuario);
            this.layoutControl1.Controls.Add(this.navBarControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(937, 462);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtArchivoDatos);
            this.panelControl1.Controls.Add(this.btnBuscarArchivo);
            this.panelControl1.Controls.Add(this.btnCargarUsuarios);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.txtUsuario);
            this.panelControl1.Location = new System.Drawing.Point(197, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(738, 37);
            this.panelControl1.TabIndex = 4;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(237, 10);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(61, 23);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(51, 12);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(184, 20);
            this.txtUsuario.TabIndex = 9;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // grdAgencia
            // 
            this.grdAgencia.Location = new System.Drawing.Point(594, 317);
            this.grdAgencia.MainView = this.grvAgencia;
            this.grdAgencia.Name = "grdAgencia";
            this.grdAgencia.Size = new System.Drawing.Size(341, 143);
            this.grdAgencia.TabIndex = 3;
            this.grdAgencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAgencia});
            // 
            // grvAgencia
            // 
            this.grvAgencia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdAgencia,
            this.colCodigoAgencia,
            this.colAgencia,
            this.colUbicacionAgencia,
            this.colIdUsuarioResponsable});
            this.grvAgencia.GridControl = this.grdAgencia;
            this.grvAgencia.Name = "grvAgencia";
            this.grvAgencia.OptionsView.ShowFooter = true;
            this.grvAgencia.OptionsView.ShowGroupPanel = false;
            // 
            // colIdAgencia
            // 
            this.colIdAgencia.Caption = "ID";
            this.colIdAgencia.FieldName = "ID";
            this.colIdAgencia.Name = "colIdAgencia";
            this.colIdAgencia.OptionsColumn.ReadOnly = true;
            this.colIdAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colCodigoAgencia
            // 
            this.colCodigoAgencia.Caption = "Codigo";
            this.colCodigoAgencia.FieldName = "sCodigoAgencia";
            this.colCodigoAgencia.Name = "colCodigoAgencia";
            this.colCodigoAgencia.OptionsColumn.ReadOnly = true;
            this.colCodigoAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodigoAgencia.Visible = true;
            this.colCodigoAgencia.VisibleIndex = 0;
            this.colCodigoAgencia.Width = 62;
            // 
            // colAgencia
            // 
            this.colAgencia.Caption = "Agencia";
            this.colAgencia.FieldName = "sDescripcion";
            this.colAgencia.Name = "colAgencia";
            this.colAgencia.OptionsColumn.ReadOnly = true;
            this.colAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAgencia.Visible = true;
            this.colAgencia.VisibleIndex = 1;
            this.colAgencia.Width = 82;
            // 
            // colUbicacionAgencia
            // 
            this.colUbicacionAgencia.Caption = "Ubicación";
            this.colUbicacionAgencia.FieldName = "sDireccion";
            this.colUbicacionAgencia.Name = "colUbicacionAgencia";
            this.colUbicacionAgencia.OptionsColumn.ReadOnly = true;
            this.colUbicacionAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUbicacionAgencia.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Descripcion", "{0}")});
            this.colUbicacionAgencia.Visible = true;
            this.colUbicacionAgencia.VisibleIndex = 2;
            this.colUbicacionAgencia.Width = 179;
            // 
            // colIdUsuarioResponsable
            // 
            this.colIdUsuarioResponsable.Caption = "IdUsuarioResponsable";
            this.colIdUsuarioResponsable.FieldName = "IDCliente";
            this.colIdUsuarioResponsable.Name = "colIdUsuarioResponsable";
            this.colIdUsuarioResponsable.OptionsColumn.ReadOnly = true;
            this.colIdUsuarioResponsable.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // grdBandeja
            // 
            this.grdBandeja.Location = new System.Drawing.Point(197, 317);
            this.grdBandeja.MainView = this.grvBandeja;
            this.grdBandeja.Name = "grdBandeja";
            this.grdBandeja.Size = new System.Drawing.Size(393, 143);
            this.grdBandeja.TabIndex = 2;
            this.grdBandeja.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBandeja});
            // 
            // grvBandeja
            // 
            this.grvBandeja.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colIdGeo,
            this.colDescripcion,
            this.colAlias,
            this.colUbicacion,
            this.colIdUsuario});
            this.grvBandeja.GridControl = this.grdBandeja;
            this.grvBandeja.Name = "grvBandeja";
            this.grvBandeja.OptionsView.ShowFooter = true;
            this.grvBandeja.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdGeo
            // 
            this.colIdGeo.Caption = "IdGeo";
            this.colIdGeo.FieldName = "IdGeo";
            this.colIdGeo.Name = "colIdGeo";
            this.colIdGeo.OptionsColumn.ReadOnly = true;
            this.colIdGeo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Bandeja";
            this.colDescripcion.FieldName = "sDescripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 0;
            this.colDescripcion.Width = 265;
            // 
            // colAlias
            // 
            this.colAlias.Caption = "Alias";
            this.colAlias.FieldName = "Alias";
            this.colAlias.Name = "colAlias";
            this.colAlias.OptionsColumn.ReadOnly = true;
            this.colAlias.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAlias.Width = 188;
            // 
            // colUbicacion
            // 
            this.colUbicacion.Caption = "Ubicación";
            this.colUbicacion.FieldName = "Ubicacion";
            this.colUbicacion.Name = "colUbicacion";
            this.colUbicacion.OptionsColumn.ReadOnly = true;
            this.colUbicacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUbicacion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Ubicacion", "{0}")});
            this.colUbicacion.Visible = true;
            this.colUbicacion.VisibleIndex = 1;
            this.colUbicacion.Width = 558;
            // 
            // colIdUsuario
            // 
            this.colIdUsuario.Caption = "IdUsuario";
            this.colIdUsuario.FieldName = "IdUsuario";
            this.colIdUsuario.Name = "colIdUsuario";
            // 
            // grdUsuario
            // 
            this.grdUsuario.Location = new System.Drawing.Point(197, 59);
            this.grdUsuario.MainView = this.grvUsuario;
            this.grdUsuario.Name = "grdUsuario";
            this.grdUsuario.Size = new System.Drawing.Size(738, 238);
            this.grdUsuario.TabIndex = 0;
            this.grdUsuario.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUsuario});
            // 
            // grvUsuario
            // 
            this.grvUsuario.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colUsuario,
            this.colTipoUsuario,
            this.colCodigoUsuario,
            this.colMatricula,
            this.colDNI,
            this.colResponsableAgencia,
            this.colEstado});
            this.grvUsuario.GridControl = this.grdUsuario;
            this.grvUsuario.Name = "grvUsuario";
            this.grvUsuario.OptionsView.ShowAutoFilterRow = true;
            this.grvUsuario.OptionsView.ShowFooter = true;
            this.grvUsuario.OptionsView.ShowGroupPanel = false;
            this.grvUsuario.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grvUsuario_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.FieldName = "Descripcion";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.OptionsColumn.ReadOnly = true;
            this.colUsuario.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 0;
            this.colUsuario.Width = 183;
            // 
            // colTipoUsuario
            // 
            this.colTipoUsuario.Caption = "Tipo Usuario";
            this.colTipoUsuario.FieldName = "Tipo";
            this.colTipoUsuario.Name = "colTipoUsuario";
            this.colTipoUsuario.OptionsColumn.ReadOnly = true;
            this.colTipoUsuario.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTipoUsuario.Visible = true;
            this.colTipoUsuario.VisibleIndex = 1;
            this.colTipoUsuario.Width = 77;
            // 
            // colCodigoUsuario
            // 
            this.colCodigoUsuario.Caption = "Código de usuario";
            this.colCodigoUsuario.FieldName = "Codigo";
            this.colCodigoUsuario.MinWidth = 60;
            this.colCodigoUsuario.Name = "colCodigoUsuario";
            this.colCodigoUsuario.OptionsColumn.ReadOnly = true;
            this.colCodigoUsuario.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodigoUsuario.Visible = true;
            this.colCodigoUsuario.VisibleIndex = 2;
            this.colCodigoUsuario.Width = 108;
            // 
            // colMatricula
            // 
            this.colMatricula.Caption = "Matricula";
            this.colMatricula.FieldName = "sMatricula";
            this.colMatricula.Name = "colMatricula";
            this.colMatricula.Visible = true;
            this.colMatricula.VisibleIndex = 3;
            this.colMatricula.Width = 92;
            // 
            // colDNI
            // 
            this.colDNI.Caption = "DNI";
            this.colDNI.FieldName = "sDni";
            this.colDNI.Name = "colDNI";
            this.colDNI.Visible = true;
            this.colDNI.VisibleIndex = 4;
            this.colDNI.Width = 100;
            // 
            // colResponsableAgencia
            // 
            this.colResponsableAgencia.Caption = "Responsable de agencia";
            this.colResponsableAgencia.FieldName = "esFAc";
            this.colResponsableAgencia.Name = "colResponsableAgencia";
            this.colResponsableAgencia.OptionsColumn.ReadOnly = true;
            this.colResponsableAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colResponsableAgencia.Visible = true;
            this.colResponsableAgencia.VisibleIndex = 5;
            this.colResponsableAgencia.Width = 20;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "sActivo";
            this.colEstado.MaxWidth = 80;
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.ReadOnly = true;
            this.colEstado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEstado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "sActivo", "{0}")});
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 6;
            this.colEstado.Width = 20;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navUsuario;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navUsuario,
            this.navBandeja,
            this.navAgencia});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.btnNuevoUsuario,
            this.btnModificarUsuario,
            this.btnEliminarUsuario,
            this.btnVincularBandeja,
            this.btnVincularFac});
            this.navBarControl1.Location = new System.Drawing.Point(2, 2);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 191;
            this.navBarControl1.Size = new System.Drawing.Size(191, 458);
            this.navBarControl1.SmallImages = this.imageCollection1;
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navUsuario
            // 
            this.navUsuario.Caption = "Usuario";
            this.navUsuario.Expanded = true;
            this.navUsuario.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnNuevoUsuario),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnModificarUsuario),
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnEliminarUsuario)});
            this.navUsuario.Name = "navUsuario";
            this.navUsuario.SmallImageIndex = 4;
            // 
            // btnNuevoUsuario
            // 
            this.btnNuevoUsuario.Caption = "Nuevo usuario";
            this.btnNuevoUsuario.Name = "btnNuevoUsuario";
            this.btnNuevoUsuario.SmallImageIndex = 4;
            this.btnNuevoUsuario.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnNuevoUsuario_LinkClicked);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Caption = "Modificar usuario";
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.SmallImageIndex = 6;
            this.btnModificarUsuario.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnModificarUsuario_LinkClicked);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Appearance.Image = global::ExpedicionInternaPC.Properties.Resources.arrowrefresh32;
            this.btnEliminarUsuario.Appearance.Options.UseImage = true;
            this.btnEliminarUsuario.Caption = "Cambiar estado";
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.SmallImage = global::ExpedicionInternaPC.Properties.Resources.RefreshDev32;
            this.btnEliminarUsuario.SmallImageIndex = 5;
            this.btnEliminarUsuario.SmallImageSize = new System.Drawing.Size(35, 30);
            this.btnEliminarUsuario.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnEliminarUsuario_LinkClicked);
            // 
            // navBandeja
            // 
            this.navBandeja.Caption = "Bandeja";
            this.navBandeja.Expanded = true;
            this.navBandeja.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnVincularBandeja)});
            this.navBandeja.Name = "navBandeja";
            this.navBandeja.SmallImageIndex = 10;
            // 
            // btnVincularBandeja
            // 
            this.btnVincularBandeja.Caption = "Vincular bandejas";
            this.btnVincularBandeja.Name = "btnVincularBandeja";
            this.btnVincularBandeja.SmallImageIndex = 2;
            this.btnVincularBandeja.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnVincularBandeja_LinkClicked);
            // 
            // navAgencia
            // 
            this.navAgencia.Caption = "Responsable de agencia";
            this.navAgencia.Expanded = true;
            this.navAgencia.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.btnVincularFac)});
            this.navAgencia.Name = "navAgencia";
            this.navAgencia.SmallImageIndex = 12;
            // 
            // btnVincularFac
            // 
            this.btnVincularFac.Caption = "Vincular agencias";
            this.btnVincularFac.Name = "btnVincularFac";
            this.btnVincularFac.SmallImageIndex = 13;
            this.btnVincularFac.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.btnVincularFac_LinkClicked);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.groupadd32, "groupadd32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "groupadd32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.groupdelete32, "groupdelete32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "groupdelete32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.link32, "link32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "link32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.linkbreak32, "linkbreak32", typeof(global::ExpedicionInternaPC.Properties.Resources), 3);
            this.imageCollection1.Images.SetKeyName(3, "linkbreak32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.useradd32, "useradd32", typeof(global::ExpedicionInternaPC.Properties.Resources), 4);
            this.imageCollection1.Images.SetKeyName(4, "useradd32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.userdelete32, "userdelete32", typeof(global::ExpedicionInternaPC.Properties.Resources), 5);
            this.imageCollection1.Images.SetKeyName(5, "userdelete32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.useredit32, "useredit32", typeof(global::ExpedicionInternaPC.Properties.Resources), 6);
            this.imageCollection1.Images.SetKeyName(6, "useredit32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.vcardadd32, "vcardadd32", typeof(global::ExpedicionInternaPC.Properties.Resources), 7);
            this.imageCollection1.Images.SetKeyName(7, "vcardadd32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.vcarddelete32, "vcarddelete32", typeof(global::ExpedicionInternaPC.Properties.Resources), 8);
            this.imageCollection1.Images.SetKeyName(8, "vcarddelete32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.vcardedit32, "vcardedit32", typeof(global::ExpedicionInternaPC.Properties.Resources), 9);
            this.imageCollection1.Images.SetKeyName(9, "vcardedit32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.ContactDev32, "ContactDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 10);
            this.imageCollection1.Images.SetKeyName(10, "ContactDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.emailtofriend32, "emailtofriend32", typeof(global::ExpedicionInternaPC.Properties.Resources), 11);
            this.imageCollection1.Images.SetKeyName(11, "emailtofriend32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.sitemapcolor32, "sitemapcolor32", typeof(global::ExpedicionInternaPC.Properties.Resources), 12);
            this.imageCollection1.Images.SetKeyName(12, "sitemapcolor32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.tagblueadd32, "tagblueadd32", typeof(global::ExpedicionInternaPC.Properties.Resources), 13);
            this.imageCollection1.Images.SetKeyName(13, "tagblueadd32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.tagbluedelete32, "tagbluedelete32", typeof(global::ExpedicionInternaPC.Properties.Resources), 14);
            this.imageCollection1.Images.SetKeyName(14, "tagbluedelete32");
            this.imageCollection1.InsertGalleryImage("findcustomers_32x32.png", "images/find/findcustomers_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/find/findcustomers_32x32.png"), 15);
            this.imageCollection1.Images.SetKeyName(15, "findcustomers_32x32.png");
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(937, 462);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.navBarControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(195, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(195, 14);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(195, 462);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.layoutControlItem2.AppearanceItemCaption.BackColor2 = System.Drawing.Color.SteelBlue;
            this.layoutControlItem2.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem2.Control = this.grdUsuario;
            this.layoutControlItem2.Location = new System.Drawing.Point(195, 41);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(742, 258);
            this.layoutControlItem2.Text = "Lista de usuarios";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(96, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.layoutControlItem3.AppearanceItemCaption.BackColor2 = System.Drawing.Color.SteelBlue;
            this.layoutControlItem3.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem3.Control = this.grdBandeja;
            this.layoutControlItem3.Location = new System.Drawing.Point(195, 299);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(397, 163);
            this.layoutControlItem3.Text = "Lista de bandejas";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(96, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.layoutControlItem4.AppearanceItemCaption.BackColor2 = System.Drawing.Color.SteelBlue;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem4.Control = this.grdAgencia;
            this.layoutControlItem4.Location = new System.Drawing.Point(592, 299);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(345, 163);
            this.layoutControlItem4.Text = "Agencias vinculadas";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(96, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.panelControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(195, 0);
            this.layoutControlItem5.MaxSize = new System.Drawing.Size(0, 41);
            this.layoutControlItem5.MinSize = new System.Drawing.Size(5, 41);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(742, 41);
            this.layoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // btnCargarUsuarios
            // 
            this.btnCargarUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCargarUsuarios.Location = new System.Drawing.Point(648, 9);
            this.btnCargarUsuarios.Name = "btnCargarUsuarios";
            this.btnCargarUsuarios.Size = new System.Drawing.Size(85, 23);
            this.btnCargarUsuarios.TabIndex = 12;
            this.btnCargarUsuarios.Text = "Cargar usuarios";
            this.btnCargarUsuarios.Click += new System.EventHandler(this.btnCargarUsuarios_Click);
            // 
            // btnBuscarArchivo
            // 
            this.btnBuscarArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarArchivo.Location = new System.Drawing.Point(611, 9);
            this.btnBuscarArchivo.Name = "btnBuscarArchivo";
            this.btnBuscarArchivo.Size = new System.Drawing.Size(31, 23);
            this.btnBuscarArchivo.TabIndex = 13;
            this.btnBuscarArchivo.Text = "...";
            this.btnBuscarArchivo.Click += new System.EventHandler(this.btnBuscarArchivo_Click);
            // 
            // txtArchivoDatos
            // 
            this.txtArchivoDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchivoDatos.Location = new System.Drawing.Point(469, 11);
            this.txtArchivoDatos.Name = "txtArchivoDatos";
            this.txtArchivoDatos.Properties.ReadOnly = true;
            this.txtArchivoDatos.Size = new System.Drawing.Size(141, 20);
            this.txtArchivoDatos.TabIndex = 14;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(378, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Base de usuarios:";
            // 
            // frmUsuario
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 462);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmUsuario";
            this.Text = "Usuario";
            this.Activated += new System.EventHandler(this.frmUsuarioBandeja_Activated);
            this.Deactivate += new System.EventHandler(this.frmUsuarioBandeja_Deactivate);
            this.Load += new System.EventHandler(this.frmUsuarioBandeja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandeja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandeja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArchivoDatos.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navUsuario;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl grdUsuario;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoUsuario;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl grdAgencia;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAgencia;
        private DevExpress.XtraGrid.GridControl grdBandeja;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBandeja;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colIdGeo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colAlias;
        private DevExpress.XtraGrid.Columns.GridColumn colUbicacion;
        private DevExpress.XtraNavBar.NavBarItem btnNuevoUsuario;
        private DevExpress.XtraNavBar.NavBarItem btnModificarUsuario;
        private DevExpress.XtraNavBar.NavBarItem btnEliminarUsuario;
        private DevExpress.XtraNavBar.NavBarGroup navBandeja;
        private DevExpress.XtraNavBar.NavBarItem btnVincularBandeja;
        private DevExpress.XtraNavBar.NavBarGroup navAgencia;
        private DevExpress.XtraNavBar.NavBarItem btnVincularFac;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraGrid.Columns.GridColumn colResponsableAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colIdUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colIdAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colUbicacionAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colIdUsuarioResponsable;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colMatricula;
        private DevExpress.XtraGrid.Columns.GridColumn colDNI;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtArchivoDatos;
        private DevExpress.XtraEditors.SimpleButton btnBuscarArchivo;
        private DevExpress.XtraEditors.SimpleButton btnCargarUsuarios;
    }
}