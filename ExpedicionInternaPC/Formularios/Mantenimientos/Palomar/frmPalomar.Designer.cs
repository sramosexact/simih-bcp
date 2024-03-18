namespace ExpedicionInternaPC
{
    partial class frmPalomar
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPalomar));
            this.bsGeoBusca = new System.Windows.Forms.BindingSource(this.components);
            this.backstageViewButtonItem1 = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.backstageViewTabItem1 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.spcPalomar = new DevExpress.XtraEditors.SplitContainerControl();
            this.panIzquierda = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.trePalomar = new DevExpress.XtraTreeList.TreeList();
            this.colDescripcion2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colID2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIdTipoPalomar2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colExpedicion = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTipoDestino = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colIdPadre = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.bsPalomar = new System.Windows.Forms.BindingSource(this.components);
            this.tolDefault = new DevExpress.Utils.ToolTipController(this.components);
            this.lcgPalomar = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lciPalomar = new DevExpress.XtraLayout.LayoutControlItem();
            this.panDerecha = new DevExpress.XtraEditors.PanelControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.griGeo = new DevExpress.XtraGrid.GridControl();
            this.bsGeoGrilla = new System.Windows.Forms.BindingSource(this.components);
            this.gvwGeo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIDOfi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lookGeoPorAsignar = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOficina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPais = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdPais = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdDepartamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProvincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdProvincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDistrito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdDistrito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdCalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdOficina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeleccionGrafica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEliminar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lnkEliminar = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colLevel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdCboGeoPorAsignar = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lcgDerecha = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPalomar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdPalomar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.bsOperario = new System.Windows.Forms.BindingSource(this.components);
            this.popMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnGrupoNuevo = new DevExpress.XtraBars.BarSubItem();
            this.btnNuevoGrupoPisos = new DevExpress.XtraBars.BarButtonItem();
            this.btnNuevoGrupoAgenciasLima = new DevExpress.XtraBars.BarButtonItem();
            this.btnNuevoGrupoAgenciasProvincia = new DevExpress.XtraBars.BarButtonItem();
            this.btnNuevoGrupoSucursales = new DevExpress.XtraBars.BarButtonItem();
            this.btnNuevoPalomar = new DevExpress.XtraBars.BarButtonItem();
            this.btnRenombrar = new DevExpress.XtraBars.BarButtonItem();
            this.btnMover = new DevExpress.XtraBars.BarButtonItem();
            this.btnEliminar = new DevExpress.XtraBars.BarButtonItem();
            this.btnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.bsGeoBusca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcPalomar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcPalomar.Panel1)).BeginInit();
            this.spcPalomar.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcPalomar.Panel2)).BeginInit();
            this.spcPalomar.Panel2.SuspendLayout();
            this.spcPalomar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panIzquierda)).BeginInit();
            this.panIzquierda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trePalomar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPalomar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPalomar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPalomar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDerecha)).BeginInit();
            this.panDerecha.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.griGeo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGeoGrilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwGeo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGeoPorAsignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCboGeoPorAsignar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDerecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // bsGeoBusca
            // 
            this.bsGeoBusca.DataSource = typeof(Interna.Entity.Geo);
            // 
            // backstageViewButtonItem1
            // 
            this.backstageViewButtonItem1.Caption = "backstageViewButtonItem1";
            this.backstageViewButtonItem1.Name = "backstageViewButtonItem1";
            // 
            // backstageViewTabItem1
            // 
            this.backstageViewTabItem1.Caption = "backstageViewTabItem1";
            this.backstageViewTabItem1.Name = "backstageViewTabItem1";
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // spcPalomar
            // 
            this.spcPalomar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcPalomar.Location = new System.Drawing.Point(0, 41);
            this.spcPalomar.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.spcPalomar.Name = "spcPalomar";
            // 
            // spcPalomar.Panel1
            // 
            this.spcPalomar.Panel1.Controls.Add(this.panIzquierda);
            this.spcPalomar.Panel1.Text = "Panel1";
            // 
            // spcPalomar.Panel2
            // 
            this.spcPalomar.Panel2.Controls.Add(this.panDerecha);
            this.spcPalomar.Panel2.Text = "Panel2";
            this.spcPalomar.Size = new System.Drawing.Size(1174, 364);
            this.spcPalomar.SplitterPosition = 378;
            this.spcPalomar.TabIndex = 0;
            this.spcPalomar.Text = "splitContainerControl1";
            // 
            // panIzquierda
            // 
            this.panIzquierda.Controls.Add(this.layoutControl1);
            this.panIzquierda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panIzquierda.Location = new System.Drawing.Point(0, 0);
            this.panIzquierda.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panIzquierda.Name = "panIzquierda";
            this.panIzquierda.Size = new System.Drawing.Size(378, 364);
            this.panIzquierda.TabIndex = 0;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.trePalomar);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 2);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.lcgPalomar;
            this.layoutControl1.Size = new System.Drawing.Size(374, 360);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // trePalomar
            // 
            this.trePalomar.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.trePalomar.Appearance.Empty.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.Empty.Options.UseFont = true;
            this.trePalomar.Appearance.EvenRow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.EvenRow.Options.UseFont = true;
            this.trePalomar.Appearance.FilterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.FilterPanel.Options.UseFont = true;
            this.trePalomar.Appearance.FixedLine.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.FixedLine.Options.UseFont = true;
            this.trePalomar.Appearance.FocusedCell.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.FocusedCell.Options.UseFont = true;
            this.trePalomar.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.trePalomar.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.trePalomar.Appearance.FocusedRow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.FocusedRow.Options.UseBackColor = true;
            this.trePalomar.Appearance.FocusedRow.Options.UseFont = true;
            this.trePalomar.Appearance.FooterPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.FooterPanel.Options.UseFont = true;
            this.trePalomar.Appearance.GroupButton.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.GroupButton.Options.UseFont = true;
            this.trePalomar.Appearance.GroupFooter.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.GroupFooter.Options.UseFont = true;
            this.trePalomar.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.HeaderPanel.Options.UseFont = true;
            this.trePalomar.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.HideSelectionRow.Options.UseFont = true;
            this.trePalomar.Appearance.HorzLine.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.HorzLine.Options.UseFont = true;
            this.trePalomar.Appearance.OddRow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.OddRow.Options.UseFont = true;
            this.trePalomar.Appearance.Preview.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.Preview.Options.UseFont = true;
            this.trePalomar.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.Row.Options.UseFont = true;
            this.trePalomar.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.trePalomar.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.trePalomar.Appearance.SelectedRow.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.SelectedRow.Options.UseBackColor = true;
            this.trePalomar.Appearance.SelectedRow.Options.UseFont = true;
            this.trePalomar.Appearance.TreeLine.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.TreeLine.Options.UseFont = true;
            this.trePalomar.Appearance.VertLine.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trePalomar.Appearance.VertLine.Options.UseFont = true;
            this.trePalomar.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescripcion2,
            this.colID2,
            this.colIdTipoPalomar2,
            this.colExpedicion,
            this.colTipoDestino,
            this.colIdPadre});
            this.trePalomar.ColumnsImageList = this.imageCollection1;
            this.trePalomar.DataSource = this.bsPalomar;
            this.trePalomar.ImageIndexFieldName = "IdTipoPalomar";
            this.trePalomar.Location = new System.Drawing.Point(2, 2);
            this.trePalomar.Margin = new System.Windows.Forms.Padding(0);
            this.trePalomar.Name = "trePalomar";
            this.trePalomar.OptionsBehavior.Editable = false;
            this.trePalomar.OptionsBehavior.EditorShowMode = DevExpress.XtraTreeList.TreeListEditorShowMode.MouseDownFocused;
            this.trePalomar.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Advanced;
            this.trePalomar.OptionsLayout.AddNewColumns = false;
            this.trePalomar.OptionsLayout.StoreAppearance = true;
            this.trePalomar.OptionsMenu.ShowExpandCollapseItems = false;
            this.trePalomar.OptionsSelection.UseIndicatorForSelection = true;
            this.trePalomar.OptionsView.ShowSummaryFooter = true;
            this.trePalomar.ParentFieldName = "IdPadre";
            this.trePalomar.SelectImageList = this.imageCollection1;
            this.trePalomar.Size = new System.Drawing.Size(370, 356);
            this.trePalomar.StateImageList = this.imageCollection1;
            this.trePalomar.TabIndex = 4;
            this.trePalomar.ToolTipController = this.tolDefault;
            this.trePalomar.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trePalomar_FocusedNodeChanged);
            this.trePalomar.ShownEditor += new System.EventHandler(this.trePalomar_ShownEditor);
            this.trePalomar.HiddenEditor += new System.EventHandler(this.trePalomar_HiddenEditor);
            this.trePalomar.CellValueChanged += new DevExpress.XtraTreeList.CellValueChangedEventHandler(this.trePalomar_CellValueChanged);
            this.trePalomar.DragDrop += new System.Windows.Forms.DragEventHandler(this.trePalomar_DragDrop);
            this.trePalomar.DragOver += new System.Windows.Forms.DragEventHandler(this.trePalomar_DragOver);
            this.trePalomar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trePalomar_MouseClick);
            this.trePalomar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trePalomar_MouseDown);
            // 
            // colDescripcion2
            // 
            this.colDescripcion2.Caption = "Descripcion";
            this.colDescripcion2.FieldName = "Descripcion";
            this.colDescripcion2.ImageOptions.ImageIndex = 4;
            this.colDescripcion2.MinWidth = 85;
            this.colDescripcion2.Name = "colDescripcion2";
            this.colDescripcion2.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.colDescripcion2.SummaryFooter = DevExpress.XtraTreeList.SummaryItemType.Count;
            this.colDescripcion2.Visible = true;
            this.colDescripcion2.VisibleIndex = 0;
            this.colDescripcion2.Width = 142;
            // 
            // colID2
            // 
            this.colID2.Caption = "ID";
            this.colID2.FieldName = "ID";
            this.colID2.Name = "colID2";
            this.colID2.OptionsColumn.AllowEdit = false;
            this.colID2.OptionsColumn.ReadOnly = true;
            this.colID2.OptionsColumn.ShowInCustomizationForm = false;
            this.colID2.RowFooterSummary = DevExpress.XtraTreeList.SummaryItemType.Count;
            // 
            // colIdTipoPalomar2
            // 
            this.colIdTipoPalomar2.Caption = "treeListColumn1";
            this.colIdTipoPalomar2.FieldName = "IdTipoPalomar";
            this.colIdTipoPalomar2.Name = "colIdTipoPalomar2";
            this.colIdTipoPalomar2.OptionsColumn.AllowEdit = false;
            this.colIdTipoPalomar2.OptionsColumn.ReadOnly = true;
            this.colIdTipoPalomar2.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colExpedicion
            // 
            this.colExpedicion.Caption = "IdExpedicion";
            this.colExpedicion.FieldName = "IdExpedicion";
            this.colExpedicion.Name = "colExpedicion";
            this.colExpedicion.OptionsColumn.AllowEdit = false;
            this.colExpedicion.OptionsColumn.ReadOnly = true;
            this.colExpedicion.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // colTipoDestino
            // 
            this.colTipoDestino.Caption = "Tipo Destino";
            this.colTipoDestino.FieldName = "sTipoDestino";
            this.colTipoDestino.Name = "colTipoDestino";
            this.colTipoDestino.Visible = true;
            this.colTipoDestino.VisibleIndex = 1;
            // 
            // colIdPadre
            // 
            this.colIdPadre.Caption = "IdPadre";
            this.colIdPadre.FieldName = "IdPadre";
            this.colIdPadre.Name = "colIdPadre";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.atsign32, "atsign32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "atsign32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.building32, "building32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "building32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.boxclosed32, "boxclosed32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "boxclosed32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.boxopen32, "boxopen32", typeof(global::ExpedicionInternaPC.Properties.Resources), 3);
            this.imageCollection1.Images.SetKeyName(3, "boxopen32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.pageedit32, "pageedit32", typeof(global::ExpedicionInternaPC.Properties.Resources), 4);
            this.imageCollection1.Images.SetKeyName(4, "pageedit32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.asteriskorange32, "asteriskorange32", typeof(global::ExpedicionInternaPC.Properties.Resources), 5);
            this.imageCollection1.Images.SetKeyName(5, "asteriskorange32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.group32, "group32", typeof(global::ExpedicionInternaPC.Properties.Resources), 6);
            this.imageCollection1.Images.SetKeyName(6, "group32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.printer32, "printer32", typeof(global::ExpedicionInternaPC.Properties.Resources), 7);
            this.imageCollection1.Images.SetKeyName(7, "printer32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.aolmessenger32, "aolmessenger32", typeof(global::ExpedicionInternaPC.Properties.Resources), 8);
            this.imageCollection1.Images.SetKeyName(8, "aolmessenger32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.luggage32, "luggage32", typeof(global::ExpedicionInternaPC.Properties.Resources), 9);
            this.imageCollection1.Images.SetKeyName(9, "luggage32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.travel32, "travel32", typeof(global::ExpedicionInternaPC.Properties.Resources), 10);
            this.imageCollection1.Images.SetKeyName(10, "travel32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.inboxdownload32, "inboxdownload32", typeof(global::ExpedicionInternaPC.Properties.Resources), 11);
            this.imageCollection1.Images.SetKeyName(11, "inboxdownload32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.inboxupload32, "inboxupload32", typeof(global::ExpedicionInternaPC.Properties.Resources), 12);
            this.imageCollection1.Images.SetKeyName(12, "inboxupload32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.tablereplace32, "tablereplace32", typeof(global::ExpedicionInternaPC.Properties.Resources), 13);
            this.imageCollection1.Images.SetKeyName(13, "tablereplace32");
            // 
            // bsPalomar
            // 
            this.bsPalomar.DataSource = typeof(Interna.Entity.Palomar);
            // 
            // lcgPalomar
            // 
            this.lcgPalomar.CustomizationFormText = "lcgPalomar";
            this.lcgPalomar.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgPalomar.GroupBordersVisible = false;
            this.lcgPalomar.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lciPalomar});
            this.lcgPalomar.Name = "lcgPalomar";
            this.lcgPalomar.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgPalomar.Size = new System.Drawing.Size(374, 360);
            this.lcgPalomar.TextVisible = false;
            // 
            // lciPalomar
            // 
            this.lciPalomar.Control = this.trePalomar;
            this.lciPalomar.CustomizationFormText = "lciPalomar";
            this.lciPalomar.Location = new System.Drawing.Point(0, 0);
            this.lciPalomar.Name = "lciPalomar";
            this.lciPalomar.Size = new System.Drawing.Size(374, 360);
            this.lciPalomar.TextSize = new System.Drawing.Size(0, 0);
            this.lciPalomar.TextVisible = false;
            // 
            // panDerecha
            // 
            this.panDerecha.Controls.Add(this.layoutControl2);
            this.panDerecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDerecha.Location = new System.Drawing.Point(0, 0);
            this.panDerecha.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.panDerecha.Name = "panDerecha";
            this.panDerecha.Size = new System.Drawing.Size(786, 364);
            this.panDerecha.TabIndex = 0;
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.griGeo);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 2);
            this.layoutControl2.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(811, 277, 250, 350);
            this.layoutControl2.Root = this.lcgDerecha;
            this.layoutControl2.Size = new System.Drawing.Size(782, 360);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // griGeo
            // 
            this.griGeo.DataSource = this.bsGeoGrilla;
            this.griGeo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.griGeo.Location = new System.Drawing.Point(2, 2);
            this.griGeo.MainView = this.gvwGeo;
            this.griGeo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.griGeo.Name = "griGeo";
            this.griGeo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.grdCboGeoPorAsignar,
            this.lnkEliminar,
            this.lookGeoPorAsignar});
            this.griGeo.Size = new System.Drawing.Size(778, 356);
            this.griGeo.TabIndex = 5;
            this.griGeo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwGeo});
            // 
            // bsGeoGrilla
            // 
            this.bsGeoGrilla.DataSource = typeof(Interna.Entity.Geo);
            // 
            // gvwGeo
            // 
            this.gvwGeo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gvwGeo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gvwGeo.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.gvwGeo.Appearance.TopNewRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gvwGeo.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gvwGeo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colIDOfi,
            this.colOficina,
            this.colCalle,
            this.colDescripcion,
            this.colPais,
            this.colIdPais,
            this.colDepartamento,
            this.colIdDepartamento,
            this.colProvincia,
            this.colIdProvincia,
            this.colDistrito,
            this.colIdDistrito,
            this.colIdCalle,
            this.colIdOficina,
            this.colSeleccionGrafica,
            this.colEliminar,
            this.colLevel});
            this.gvwGeo.GridControl = this.griGeo;
            this.gvwGeo.Name = "gvwGeo";
            this.gvwGeo.NewItemRowText = "Nuevo";
            this.gvwGeo.OptionsView.ShowAutoFilterRow = true;
            this.gvwGeo.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowOnlyInEditor;
            this.gvwGeo.OptionsView.ShowFooter = true;
            this.gvwGeo.OptionsView.ShowGroupPanel = false;
            this.gvwGeo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwGeo_FocusedRowChanged);
            // 
            // colID
            // 
            this.colID.AppearanceCell.Options.UseTextOptions = true;
            this.colID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.MaxWidth = 50;
            this.colID.MinWidth = 50;
            this.colID.Name = "colID";
            this.colID.OptionsColumn.AllowEdit = false;
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 50;
            // 
            // colIDOfi
            // 
            this.colIDOfi.Caption = "Oficina";
            this.colIDOfi.ColumnEdit = this.lookGeoPorAsignar;
            this.colIDOfi.FieldName = "IdOficina";
            this.colIDOfi.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colIDOfi.Name = "colIDOfi";
            this.colIDOfi.OptionsColumn.ShowInCustomizationForm = false;
            this.colIDOfi.OptionsColumn.ShowInExpressionEditor = false;
            this.colIDOfi.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIDOfi.Visible = true;
            this.colIDOfi.VisibleIndex = 1;
            this.colIDOfi.Width = 100;
            // 
            // lookGeoPorAsignar
            // 
            this.lookGeoPorAsignar.AutoHeight = false;
            this.lookGeoPorAsignar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookGeoPorAsignar.DisplayMember = "Oficina";
            this.lookGeoPorAsignar.Name = "lookGeoPorAsignar";
            this.lookGeoPorAsignar.NullText = "Elija un punto de entrega";
            this.lookGeoPorAsignar.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            this.lookGeoPorAsignar.PopupFormMinSize = new System.Drawing.Size(650, 0);
            this.lookGeoPorAsignar.PopupView = this.gridView2;
            this.lookGeoPorAsignar.ShowFooter = false;
            this.lookGeoPorAsignar.ValueMember = "IdOficina";
            this.lookGeoPorAsignar.ViewType = DevExpress.XtraEditors.Repository.GridLookUpViewType.GridView;
            this.lookGeoPorAsignar.EditValueChanged += new System.EventHandler(this.repositoryItemGridLookUpEdit1_EditValueChanged);
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn6});
            this.gridView2.DetailHeight = 700;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Oficina";
            this.gridColumn2.FieldName = "Oficina";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Area";
            this.gridColumn3.FieldName = "Area";
            this.gridColumn3.MinWidth = 30;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 200;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Calle";
            this.gridColumn4.FieldName = "Calle";
            this.gridColumn4.MinWidth = 60;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Distrito";
            this.gridColumn5.FieldName = "Distrito";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 100;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IdPalomar";
            this.gridColumn7.FieldName = "IdPalomar";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Palomar";
            this.gridColumn6.FieldName = "Palomar";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 150;
            // 
            // colOficina
            // 
            this.colOficina.Caption = "Area";
            this.colOficina.FieldName = "Area";
            this.colOficina.Name = "colOficina";
            this.colOficina.OptionsColumn.AllowEdit = false;
            this.colOficina.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colOficina.Visible = true;
            this.colOficina.VisibleIndex = 2;
            this.colOficina.Width = 100;
            // 
            // colCalle
            // 
            this.colCalle.Caption = "Calle";
            this.colCalle.FieldName = "Calle";
            this.colCalle.Name = "colCalle";
            this.colCalle.OptionsColumn.AllowEdit = false;
            this.colCalle.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCalle.Visible = true;
            this.colCalle.VisibleIndex = 3;
            this.colCalle.Width = 100;
            // 
            // colDescripcion
            // 
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.AllowEdit = false;
            this.colDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colPais
            // 
            this.colPais.FieldName = "Pais";
            this.colPais.Name = "colPais";
            this.colPais.OptionsColumn.AllowEdit = false;
            this.colPais.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdPais
            // 
            this.colIdPais.FieldName = "IdPais";
            this.colIdPais.Name = "colIdPais";
            this.colIdPais.OptionsColumn.AllowEdit = false;
            this.colIdPais.OptionsColumn.ShowInCustomizationForm = false;
            this.colIdPais.OptionsColumn.ShowInExpressionEditor = false;
            this.colIdPais.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colDepartamento
            // 
            this.colDepartamento.FieldName = "Departamento";
            this.colDepartamento.Name = "colDepartamento";
            this.colDepartamento.OptionsColumn.AllowEdit = false;
            this.colDepartamento.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdDepartamento
            // 
            this.colIdDepartamento.FieldName = "IdDepartamento";
            this.colIdDepartamento.Name = "colIdDepartamento";
            this.colIdDepartamento.OptionsColumn.AllowEdit = false;
            this.colIdDepartamento.OptionsColumn.ShowInCustomizationForm = false;
            this.colIdDepartamento.OptionsColumn.ShowInExpressionEditor = false;
            this.colIdDepartamento.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colProvincia
            // 
            this.colProvincia.FieldName = "Provincia";
            this.colProvincia.Name = "colProvincia";
            this.colProvincia.OptionsColumn.AllowEdit = false;
            this.colProvincia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdProvincia
            // 
            this.colIdProvincia.FieldName = "IdProvincia";
            this.colIdProvincia.Name = "colIdProvincia";
            this.colIdProvincia.OptionsColumn.AllowEdit = false;
            this.colIdProvincia.OptionsColumn.ShowInCustomizationForm = false;
            this.colIdProvincia.OptionsColumn.ShowInExpressionEditor = false;
            this.colIdProvincia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colDistrito
            // 
            this.colDistrito.Caption = "Distrito";
            this.colDistrito.FieldName = "Distrito";
            this.colDistrito.Name = "colDistrito";
            this.colDistrito.OptionsColumn.AllowEdit = false;
            this.colDistrito.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colDistrito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Distrito", "{0}")});
            this.colDistrito.Visible = true;
            this.colDistrito.VisibleIndex = 4;
            this.colDistrito.Width = 100;
            // 
            // colIdDistrito
            // 
            this.colIdDistrito.FieldName = "IdDistrito";
            this.colIdDistrito.Name = "colIdDistrito";
            this.colIdDistrito.OptionsColumn.AllowEdit = false;
            this.colIdDistrito.OptionsColumn.ShowInCustomizationForm = false;
            this.colIdDistrito.OptionsColumn.ShowInExpressionEditor = false;
            this.colIdDistrito.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdCalle
            // 
            this.colIdCalle.FieldName = "IdCalle";
            this.colIdCalle.Name = "colIdCalle";
            this.colIdCalle.OptionsColumn.AllowEdit = false;
            this.colIdCalle.OptionsColumn.ShowInCustomizationForm = false;
            this.colIdCalle.OptionsColumn.ShowInExpressionEditor = false;
            this.colIdCalle.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdOficina
            // 
            this.colIdOficina.FieldName = "IdOficina";
            this.colIdOficina.Name = "colIdOficina";
            this.colIdOficina.OptionsColumn.AllowEdit = false;
            this.colIdOficina.OptionsColumn.ShowInCustomizationForm = false;
            this.colIdOficina.OptionsColumn.ShowInExpressionEditor = false;
            this.colIdOficina.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colSeleccionGrafica
            // 
            this.colSeleccionGrafica.FieldName = "SeleccionGrafica";
            this.colSeleccionGrafica.Name = "colSeleccionGrafica";
            this.colSeleccionGrafica.OptionsColumn.AllowEdit = false;
            this.colSeleccionGrafica.OptionsColumn.ShowInCustomizationForm = false;
            this.colSeleccionGrafica.OptionsColumn.ShowInExpressionEditor = false;
            this.colSeleccionGrafica.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colEliminar
            // 
            this.colEliminar.AppearanceCell.Options.UseTextOptions = true;
            this.colEliminar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colEliminar.ColumnEdit = this.lnkEliminar;
            this.colEliminar.MaxWidth = 50;
            this.colEliminar.MinWidth = 50;
            this.colEliminar.Name = "colEliminar";
            this.colEliminar.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEliminar.Visible = true;
            this.colEliminar.VisibleIndex = 5;
            this.colEliminar.Width = 50;
            // 
            // lnkEliminar
            // 
            this.lnkEliminar.AutoHeight = false;
            this.lnkEliminar.Caption = "Desvincular";
            this.lnkEliminar.Name = "lnkEliminar";
            this.lnkEliminar.NullText = "Desvincular";
            this.lnkEliminar.Click += new System.EventHandler(this.lnkEliminar_Click);
            // 
            // colLevel
            // 
            this.colLevel.Caption = "Level (ID Sistema)";
            this.colLevel.FieldName = "Level";
            this.colLevel.Name = "colLevel";
            this.colLevel.OptionsColumn.AllowEdit = false;
            this.colLevel.OptionsColumn.ReadOnly = true;
            this.colLevel.OptionsColumn.ShowCaption = false;
            this.colLevel.OptionsColumn.ShowInCustomizationForm = false;
            this.colLevel.OptionsColumn.ShowInExpressionEditor = false;
            // 
            // grdCboGeoPorAsignar
            // 
            this.grdCboGeoPorAsignar.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdCboGeoPorAsignar.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Oficina", "Oficina"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Area", "Area", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Calle", "Calle", 60, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Distrito", "Distrito"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("idPalomar", "idPalomar", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Palomar", "Palomar")});
            this.grdCboGeoPorAsignar.DisplayMember = "Oficina";
            this.grdCboGeoPorAsignar.DropDownRows = 15;
            this.grdCboGeoPorAsignar.Name = "grdCboGeoPorAsignar";
            this.grdCboGeoPorAsignar.NullText = "Elija un Punto de Entrega";
            this.grdCboGeoPorAsignar.PopupFormMinSize = new System.Drawing.Size(650, 0);
            this.grdCboGeoPorAsignar.ShowFooter = false;
            this.grdCboGeoPorAsignar.ValueMember = "IdOficina";
            // 
            // lcgDerecha
            // 
            this.lcgDerecha.CustomizationFormText = "lcgDerecha";
            this.lcgDerecha.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.lcgDerecha.GroupBordersVisible = false;
            this.lcgDerecha.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.lcgDerecha.Name = "lcgDerecha";
            this.lcgDerecha.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.lcgDerecha.Size = new System.Drawing.Size(782, 360);
            this.lcgDerecha.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.griGeo;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(782, 360);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // colPalomar
            // 
            this.colPalomar.Name = "colPalomar";
            // 
            // colIdPalomar
            // 
            this.colIdPalomar.Name = "colIdPalomar";
            // 
            // bsOperario
            // 
            this.bsOperario.DataSource = typeof(Interna.Entity.Operario);
            // 
            // popMenu
            // 
            this.popMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnGrupoNuevo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNuevoPalomar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnRenombrar, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMover),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEliminar, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnImprimir)});
            this.popMenu.Manager = this.barManager;
            this.popMenu.Name = "popMenu";
            // 
            // btnGrupoNuevo
            // 
            this.btnGrupoNuevo.Caption = "Nuevo Grupo";
            this.btnGrupoNuevo.Id = 11;
            this.btnGrupoNuevo.ImageOptions.ImageIndex = 2;
            this.btnGrupoNuevo.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNuevoGrupoPisos),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNuevoGrupoAgenciasLima),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNuevoGrupoAgenciasProvincia),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNuevoGrupoSucursales)});
            this.btnGrupoNuevo.Name = "btnGrupoNuevo";
            // 
            // btnNuevoGrupoPisos
            // 
            this.btnNuevoGrupoPisos.Caption = "Pisos";
            this.btnNuevoGrupoPisos.Id = 0;
            this.btnNuevoGrupoPisos.ImageOptions.ImageIndex = 8;
            this.btnNuevoGrupoPisos.Name = "btnNuevoGrupoPisos";
            this.btnNuevoGrupoPisos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNuevoGrupoPisos_ItemClick);
            // 
            // btnNuevoGrupoAgenciasLima
            // 
            this.btnNuevoGrupoAgenciasLima.Caption = "Agencias Lima";
            this.btnNuevoGrupoAgenciasLima.Id = 8;
            this.btnNuevoGrupoAgenciasLima.ImageOptions.ImageIndex = 10;
            this.btnNuevoGrupoAgenciasLima.Name = "btnNuevoGrupoAgenciasLima";
            this.btnNuevoGrupoAgenciasLima.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNuevoGrupoAgencias_ItemClick);
            // 
            // btnNuevoGrupoAgenciasProvincia
            // 
            this.btnNuevoGrupoAgenciasProvincia.Caption = "Agencias Provincia";
            this.btnNuevoGrupoAgenciasProvincia.Id = 12;
            this.btnNuevoGrupoAgenciasProvincia.ImageOptions.ImageIndex = 10;
            this.btnNuevoGrupoAgenciasProvincia.Name = "btnNuevoGrupoAgenciasProvincia";
            this.btnNuevoGrupoAgenciasProvincia.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNuevoGrupoAgenciasProvincia_ItemClick);
            // 
            // btnNuevoGrupoSucursales
            // 
            this.btnNuevoGrupoSucursales.Caption = "Sucursales";
            this.btnNuevoGrupoSucursales.Id = 9;
            this.btnNuevoGrupoSucursales.ImageOptions.ImageIndex = 9;
            this.btnNuevoGrupoSucursales.Name = "btnNuevoGrupoSucursales";
            this.btnNuevoGrupoSucursales.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNuevoGrupoSucursales_ItemClick);
            // 
            // btnNuevoPalomar
            // 
            this.btnNuevoPalomar.Caption = "Nuevo &Palomar";
            this.btnNuevoPalomar.Id = 1;
            this.btnNuevoPalomar.ImageOptions.ImageIndex = 3;
            this.btnNuevoPalomar.Name = "btnNuevoPalomar";
            this.btnNuevoPalomar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNuevoPalomar_ItemClick);
            // 
            // btnRenombrar
            // 
            this.btnRenombrar.Caption = "&Renombrar";
            this.btnRenombrar.Id = 2;
            this.btnRenombrar.ImageOptions.ImageIndex = 5;
            this.btnRenombrar.Name = "btnRenombrar";
            this.btnRenombrar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRenombrar_ItemClick);
            // 
            // btnMover
            // 
            this.btnMover.Caption = "Seleccionar";
            this.btnMover.Id = 13;
            this.btnMover.ImageOptions.ImageIndex = 4;
            this.btnMover.Name = "btnMover";
            this.btnMover.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMover_ItemClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Caption = "&Eliminar";
            this.btnEliminar.Id = 3;
            this.btnEliminar.ImageOptions.ImageIndex = 6;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEliminar_ItemClick);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Caption = "Imprimir";
            this.btnImprimir.Id = 7;
            this.btnImprimir.ImageOptions.ImageIndex = 7;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImprimir_ItemClick);
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imageCollection1;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNuevoGrupoPisos,
            this.btnNuevoPalomar,
            this.btnRenombrar,
            this.btnEliminar,
            this.btnImprimir,
            this.btnNuevoGrupoAgenciasLima,
            this.btnNuevoGrupoSucursales,
            this.barButtonItem3,
            this.btnGrupoNuevo,
            this.btnNuevoGrupoAgenciasProvincia,
            this.btnMover});
            this.barManager.MainMenu = this.bar2;
            this.barManager.MaxItemId = 14;
            this.barManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Herramientas";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.Text = "Herramientas";
            this.bar1.Visible = false;
            // 
            // bar2
            // 
            this.bar2.BarName = "Menú principal";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menú principal";
            this.bar2.Visible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "Barra de estado";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Barra de estado";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.barDockControlTop.Size = new System.Drawing.Size(1174, 41);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 405);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.barDockControlBottom.Size = new System.Drawing.Size(1174, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 41);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 364);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1174, 41);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 364);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Nuevo Grupo";
            this.barButtonItem3.Id = 10;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 267);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(545, 57);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmPalomar
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(1174, 425);
            this.Controls.Add(this.spcPalomar);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmPalomar";
            this.Tag = "Palomar";
            this.Text = "Palomares";
            this.Activated += new System.EventHandler(this.frmPalomar_Activated);
            this.Deactivate += new System.EventHandler(this.frmPalomar_Deactivate);
            this.Load += new System.EventHandler(this.frmPalomar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsGeoBusca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spcPalomar.Panel1)).EndInit();
            this.spcPalomar.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPalomar.Panel2)).EndInit();
            this.spcPalomar.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcPalomar)).EndInit();
            this.spcPalomar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panIzquierda)).EndInit();
            this.panIzquierda.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trePalomar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPalomar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPalomar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lciPalomar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panDerecha)).EndInit();
            this.panDerecha.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.griGeo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsGeoGrilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwGeo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookGeoPorAsignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCboGeoPorAsignar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lcgDerecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsOperario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem backstageViewButtonItem1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem1;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraEditors.SplitContainerControl spcPalomar;
        private DevExpress.XtraEditors.PanelControl panIzquierda;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup lcgPalomar;
        private DevExpress.XtraEditors.PanelControl panDerecha;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraGrid.GridControl griGeo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwGeo;
        private DevExpress.XtraLayout.LayoutControlGroup lcgDerecha;
        private DevExpress.Utils.ToolTipController tolDefault;
        private System.Windows.Forms.BindingSource bsOperario;
        private System.Windows.Forms.BindingSource bsGeoGrilla;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colIDOfi;
        private DevExpress.XtraGrid.Columns.GridColumn colPais;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPais;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartamento;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDepartamento;
        private DevExpress.XtraGrid.Columns.GridColumn colProvincia;
        private DevExpress.XtraGrid.Columns.GridColumn colIdProvincia;
        private DevExpress.XtraGrid.Columns.GridColumn colDistrito;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDistrito;
        private DevExpress.XtraGrid.Columns.GridColumn colCalle;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCalle;
        private DevExpress.XtraGrid.Columns.GridColumn colOficina;
        private DevExpress.XtraGrid.Columns.GridColumn colIdOficina;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionGrafica;
        private System.Windows.Forms.BindingSource bsGeoBusca;
        private DevExpress.XtraTreeList.TreeList trePalomar;
        private DevExpress.XtraLayout.LayoutControlItem lciPalomar;
        private System.Windows.Forms.BindingSource bsPalomar;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescripcion2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIdTipoPalomar2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colExpedicion;
        
        //private DevExpress.Utils.ToolTipController tolDefault;
        //private System.Windows.Forms.ImageList img32x32;
        private DevExpress.XtraBars.PopupMenu popMenu;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnNuevoGrupoPisos;
        private DevExpress.XtraBars.BarButtonItem btnNuevoPalomar;
        private DevExpress.XtraBars.BarButtonItem btnRenombrar;
        private DevExpress.XtraBars.BarButtonItem btnEliminar;
        //private DevExpress.XtraTreeList.Columns.TreeListColumn colExpedicion;
        //private DevExpress.XtraBars.BarDockControl barDockControlTop;
        //private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        //private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        //private DevExpress.XtraBars.BarDockControl barDockControlRight;
        //private DevExpress.XtraBars.BarManager barManager;
        //private DevExpress.XtraBars.PopupMenu popMenu;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        //private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit rslGeoPorOficina;
        //private DevExpress.XtraLayout.LayoutControl layoutControl2;
        //private DevExpress.XtraGrid.GridControl griGeo;
        //private DevExpress.XtraGrid.Views.Grid.GridView gvwGeo;
        //private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit grdCboGeoPorAsignar;
        //private DevExpress.XtraLayout.LayoutControlGroup lcgDerecha;
        //private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPalomar;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPalomar;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colEliminar;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit lnkEliminar;
        private DevExpress.XtraBars.BarButtonItem btnImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn colLevel;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarSubItem btnGrupoNuevo;
        private DevExpress.XtraBars.BarButtonItem btnNuevoGrupoAgenciasLima;
        private DevExpress.XtraBars.BarButtonItem btnNuevoGrupoSucursales;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTipoDestino;
        private DevExpress.XtraBars.BarButtonItem btnNuevoGrupoAgenciasProvincia;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colIdPadre;
        private DevExpress.XtraBars.BarButtonItem btnMover;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit lookGeoPorAsignar;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        //private DevExpress.XtraGrid.Columns.GridColumn colDistrito;
        //private DevExpress.XtraGrid.Columns.GridColumn colCalle;

    }
}
