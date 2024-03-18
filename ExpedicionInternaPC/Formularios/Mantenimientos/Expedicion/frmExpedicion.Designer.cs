namespace ExpedicionInternaPC
{
    partial class frmExpedicion: frmChild
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedicion));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.grdExpedicion = new DevExpress.XtraGrid.GridControl();
            this.grvExpedicion = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpedicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUbicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBandeja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdGeo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdCalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdDistrito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdProvincia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdDepartamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdTipoExpedicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoExpedicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpedicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExpedicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1230, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 892);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1230, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 892);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1230, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 892);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.grdExpedicion);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1230, 892);
            this.layoutControl1.TabIndex = 5;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.toolStrip1);
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1224, 73);
            this.panelControl1.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnEditar,
            this.btnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1220, 69);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.Image = global::ExpedicionInternaPC.Properties.Resources.buildingadd32;
            this.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(80, 67);
            this.btnNuevo.Text = "&Nuevo";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.AutoSize = false;
            this.btnEditar.Image = global::ExpedicionInternaPC.Properties.Resources.buildingedit32;
            this.btnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(80, 67);
            this.btnEditar.Text = "&Modificar";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.Image = global::ExpedicionInternaPC.Properties.Resources.RefreshDev32;
            this.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 67);
            this.btnEliminar.Text = "&Cambiar estado";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // grdExpedicion
            // 
            this.grdExpedicion.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.grdExpedicion.Location = new System.Drawing.Point(3, 82);
            this.grdExpedicion.MainView = this.grvExpedicion;
            this.grdExpedicion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdExpedicion.MenuManager = this.barManager1;
            this.grdExpedicion.Name = "grdExpedicion";
            this.grdExpedicion.Size = new System.Drawing.Size(1224, 807);
            this.grdExpedicion.TabIndex = 4;
            this.grdExpedicion.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvExpedicion});
            // 
            // grvExpedicion
            // 
            this.grvExpedicion.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colID,
            this.colExpedicion,
            this.colUbicacion,
            this.colBandeja,
            this.colIdGeo,
            this.colIdCalle,
            this.colIdDistrito,
            this.colIdProvincia,
            this.colIdDepartamento,
            this.colIdTipoExpedicion,
            this.colTipoExpedicion,
            this.colGeo,
            this.colActivo});
            this.grvExpedicion.CustomizationFormBounds = new System.Drawing.Rectangle(874, 394, 210, 172);
            this.grvExpedicion.GridControl = this.grdExpedicion;
            this.grvExpedicion.Name = "grvExpedicion";
            this.grvExpedicion.OptionsView.ShowAutoFilterRow = true;
            this.grvExpedicion.OptionsView.ShowGroupPanel = false;
            this.grvExpedicion.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvExpedicion_CellValueChanging);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Seleccionar";
            this.gridColumn1.FieldName = "SeleccionGrafica";
            this.gridColumn1.MaxWidth = 62;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilter = false;
            this.gridColumn1.OptionsFilter.AllowFilterModeChanging = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 56;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colExpedicion
            // 
            this.colExpedicion.Caption = "Expedicion";
            this.colExpedicion.FieldName = "Descripcion";
            this.colExpedicion.MaxWidth = 250;
            this.colExpedicion.MinWidth = 250;
            this.colExpedicion.Name = "colExpedicion";
            this.colExpedicion.OptionsColumn.ReadOnly = true;
            this.colExpedicion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colExpedicion.Visible = true;
            this.colExpedicion.VisibleIndex = 1;
            this.colExpedicion.Width = 250;
            // 
            // colUbicacion
            // 
            this.colUbicacion.Caption = "Ubicación";
            this.colUbicacion.FieldName = "Ubicacion";
            this.colUbicacion.MinWidth = 400;
            this.colUbicacion.Name = "colUbicacion";
            this.colUbicacion.OptionsColumn.ReadOnly = true;
            this.colUbicacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUbicacion.Visible = true;
            this.colUbicacion.VisibleIndex = 2;
            this.colUbicacion.Width = 400;
            // 
            // colBandeja
            // 
            this.colBandeja.Caption = "Bandejas";
            this.colBandeja.FieldName = "iBandejas";
            this.colBandeja.Name = "colBandeja";
            this.colBandeja.OptionsColumn.ReadOnly = true;
            this.colBandeja.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdGeo
            // 
            this.colIdGeo.Caption = "IdGeo";
            this.colIdGeo.FieldName = "IdGeo";
            this.colIdGeo.Name = "colIdGeo";
            this.colIdGeo.OptionsColumn.ReadOnly = true;
            this.colIdGeo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdCalle
            // 
            this.colIdCalle.Caption = "IdCalle";
            this.colIdCalle.FieldName = "idCalle";
            this.colIdCalle.Name = "colIdCalle";
            this.colIdCalle.OptionsColumn.ReadOnly = true;
            this.colIdCalle.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdDistrito
            // 
            this.colIdDistrito.Caption = "IdDistrito";
            this.colIdDistrito.FieldName = "idDistrito";
            this.colIdDistrito.Name = "colIdDistrito";
            this.colIdDistrito.OptionsColumn.ReadOnly = true;
            this.colIdDistrito.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdProvincia
            // 
            this.colIdProvincia.Caption = "IdProvincia";
            this.colIdProvincia.FieldName = "idProvincia";
            this.colIdProvincia.Name = "colIdProvincia";
            this.colIdProvincia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdDepartamento
            // 
            this.colIdDepartamento.Caption = "IdDepartamento";
            this.colIdDepartamento.FieldName = "idDepartamento";
            this.colIdDepartamento.Name = "colIdDepartamento";
            this.colIdDepartamento.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colIdTipoExpedicion
            // 
            this.colIdTipoExpedicion.Caption = "IdTipoExpedicion";
            this.colIdTipoExpedicion.FieldName = "idTipoExpedicion";
            this.colIdTipoExpedicion.Name = "colIdTipoExpedicion";
            this.colIdTipoExpedicion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colTipoExpedicion
            // 
            this.colTipoExpedicion.Caption = "TipoExpedicion";
            this.colTipoExpedicion.FieldName = "TipoExpedicion";
            this.colTipoExpedicion.MaxWidth = 100;
            this.colTipoExpedicion.MinWidth = 100;
            this.colTipoExpedicion.Name = "colTipoExpedicion";
            this.colTipoExpedicion.OptionsColumn.ReadOnly = true;
            this.colTipoExpedicion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTipoExpedicion.Visible = true;
            this.colTipoExpedicion.VisibleIndex = 3;
            this.colTipoExpedicion.Width = 100;
            // 
            // colGeo
            // 
            this.colGeo.Caption = "GeoUbicacion";
            this.colGeo.FieldName = "Geo";
            this.colGeo.Name = "colGeo";
            this.colGeo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colActivo
            // 
            this.colActivo.Caption = "Estado";
            this.colActivo.FieldName = "sActivo";
            this.colActivo.MaxWidth = 100;
            this.colActivo.MinWidth = 100;
            this.colActivo.Name = "colActivo";
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 4;
            this.colActivo.Width = 100;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1230, 892);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdExpedicion;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 79);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1230, 813);
            this.layoutControlItem1.Text = " ";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.panelControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 79);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(5, 79);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1230, 79);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.building32, "building32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "building32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.buildingadd32, "buildingadd32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "buildingadd32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.buildingedit32, "buildingedit32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "buildingedit32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.cancel32, "cancel32", typeof(global::ExpedicionInternaPC.Properties.Resources), 3);
            this.imageCollection1.Images.SetKeyName(3, "cancel32");
            // 
            // frmExpedicion
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 892);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmExpedicion";
            this.Text = "Expedición";
            this.Activated += new System.EventHandler(this.frmExpedicion_Activated);
            this.Deactivate += new System.EventHandler(this.frmExpedicion_Deactivate);
            this.Load += new System.EventHandler(this.frmExpedicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpedicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvExpedicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private DevExpress.XtraGrid.GridControl grdExpedicion;
        private DevExpress.XtraGrid.Views.Grid.GridView grvExpedicion;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colExpedicion;
        private DevExpress.XtraGrid.Columns.GridColumn colUbicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colBandeja;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colIdGeo;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCalle;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDistrito;
        private DevExpress.XtraGrid.Columns.GridColumn colIdProvincia;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDepartamento;
        private DevExpress.XtraGrid.Columns.GridColumn colIdTipoExpedicion;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoExpedicion;
        private DevExpress.XtraGrid.Columns.GridColumn colGeo;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
    }
}