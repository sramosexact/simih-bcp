using System.Devices;
namespace ExpedicionInternaPC
{
    partial class frmEntregaPisosPrin
    {
        public RemoteDeviceManager weada;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaPisosPrin));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDatos = new DevExpress.XtraGrid.GridControl();
            this.grvPisos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.grvSucursales = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvAgencias = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grvPisos2 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCrearEntrega = new System.Windows.Forms.ToolStripButton();
            this.btnModificarEntrega = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnIniciarEntrega = new System.Windows.Forms.ToolStripButton();
            this.btnTerminarEntrega = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnImportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminarEntrega = new System.Windows.Forms.ToolStripButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPisos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSucursales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgencias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPisos2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDatos);
            this.layoutControl1.Controls.Add(this.toolStrip1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(349, 215, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1017, 460);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDatos
            // 
            this.grdDatos.Location = new System.Drawing.Point(12, 81);
            this.grdDatos.MainView = this.grvPisos;
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2,
            this.repositoryItemHyperLinkEdit3,
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2});
            this.grdDatos.Size = new System.Drawing.Size(993, 367);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPisos,
            this.grvSucursales,
            this.grvAgencias,
            this.grvPisos2});
            // 
            // grvPisos
            // 
            this.grvPisos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn14,
            this.gridColumn6,
            this.gridColumn12,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn13,
            this.gridColumn5,
            this.gridColumn15,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.colCreadoPor});
            this.grvPisos.GridControl = this.grdDatos;
            this.grvPisos.Name = "grvPisos";
            this.grvPisos.OptionsView.ShowAutoFilterRow = true;
            this.grvPisos.OptionsView.ShowFooter = true;
            this.grvPisos.OptionsView.ShowGroupPanel = false;
            this.grvPisos.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvPisos_CellValueChanging);
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Seleccionar";
            this.gridColumn11.FieldName = "SeleccionGrafica";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 32;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código de entrega";
            this.gridColumn1.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 46;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.verObjetosEntrega);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Estado";
            this.gridColumn2.FieldName = "EstadoDescripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 56;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "iEstado";
            this.gridColumn14.FieldName = "Estado";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Asignado a";
            this.gridColumn6.FieldName = "Colaborador";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            this.gridColumn6.Width = 119;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "Creado el";
            this.gridColumn12.DisplayFormat.FormatString = "G";
            this.gridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn12.FieldName = "Registro";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 4;
            this.gridColumn12.Width = 91;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Iniciado el";
            this.gridColumn3.DisplayFormat.FormatString = "G";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "Inicio";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 92;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Terminado el";
            this.gridColumn4.DisplayFormat.FormatString = "G";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn4.FieldName = "Fin";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 83;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "Cerrado el";
            this.gridColumn13.FieldName = "Cierre";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Width = 76;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Total de Documentos";
            this.gridColumn5.FieldName = "Total";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 73;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn15.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn15.Caption = "Validados";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn15.FieldName = "idTipoValidacion";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 8;
            this.gridColumn15.Width = 61;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Entregados";
            this.gridColumn7.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.gridColumn7.FieldName = "Recibido";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 9;
            this.gridColumn7.Width = 60;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Por Entregar";
            this.gridColumn8.ColumnEdit = this.repositoryItemHyperLinkEdit3;
            this.gridColumn8.FieldName = "noRecibido";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 10;
            this.gridColumn8.Width = 62;
            // 
            // repositoryItemHyperLinkEdit3
            // 
            this.repositoryItemHyperLinkEdit3.Appearance.Options.UseTextOptions = true;
            this.repositoryItemHyperLinkEdit3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemHyperLinkEdit3.AutoHeight = false;
            this.repositoryItemHyperLinkEdit3.Name = "repositoryItemHyperLinkEdit3";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn9.Caption = "Exportado";
            this.gridColumn9.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn9.FieldName = "Exportado";
            this.gridColumn9.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 11;
            this.gridColumn9.Width = 38;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.Appearance.Options.UseTextOptions = true;
            this.repositoryItemImageComboBox1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 278, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 73, 1)});
            this.repositoryItemImageComboBox1.LargeImages = this.imageCollection3;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // imageCollection3
            // 
            this.imageCollection3.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection3.ImageStream")));
            this.imageCollection3.InsertImage(global::ExpedicionInternaPC.Properties.Resources.android32, "android32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection3.Images.SetKeyName(0, "android32");
            this.imageCollection3.InsertImage(global::ExpedicionInternaPC.Properties.Resources.blackberrywhite32, "blackberrywhite32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection3.Images.SetKeyName(1, "blackberrywhite32");
            this.imageCollection3.InsertImage(global::ExpedicionInternaPC.Properties.Resources.blackberry32, "blackberry32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection3.Images.SetKeyName(2, "blackberry32");
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn10.Caption = "Importado";
            this.gridColumn10.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn10.FieldName = "Importado";
            this.gridColumn10.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Importado", "{0}")});
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 12;
            this.gridColumn10.Width = 62;
            // 
            // colCreadoPor
            // 
            this.colCreadoPor.Caption = "Creado por";
            this.colCreadoPor.FieldName = "UsuarioDescripcion";
            this.colCreadoPor.Name = "colCreadoPor";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ValueChecked = false;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.Appearance.Options.UseTextOptions = true;
            this.repositoryItemImageComboBox2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 1)});
            this.repositoryItemImageComboBox2.LargeImages = this.imageCollection3;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // grvSucursales
            // 
            this.grvSucursales.GridControl = this.grdDatos;
            this.grvSucursales.Name = "grvSucursales";
            // 
            // grvAgencias
            // 
            this.grvAgencias.GridControl = this.grdDatos;
            this.grvAgencias.Name = "grvAgencias";
            // 
            // grvPisos2
            // 
            this.grvPisos2.FocusedCardTopFieldIndex = 0;
            this.grvPisos2.GridControl = this.grdDatos;
            this.grvPisos2.Name = "grvPisos2";
            this.grvPisos2.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCrearEntrega,
            this.btnModificarEntrega,
            this.toolStripSeparator2,
            this.btnIniciarEntrega,
            this.btnTerminarEntrega,
            this.toolStripSeparator1,
            this.btnExportar,
            this.btnImportar,
            this.toolStripSeparator3,
            this.btnEliminarEntrega});
            this.toolStrip1.Location = new System.Drawing.Point(12, 12);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(993, 55);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCrearEntrega
            // 
            this.btnCrearEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnCrearEntrega.Image")));
            this.btnCrearEntrega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCrearEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrearEntrega.Margin = new System.Windows.Forms.Padding(0);
            this.btnCrearEntrega.Name = "btnCrearEntrega";
            this.btnCrearEntrega.Padding = new System.Windows.Forms.Padding(15);
            this.btnCrearEntrega.Size = new System.Drawing.Size(69, 55);
            this.btnCrearEntrega.Text = "&Crear";
            this.btnCrearEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCrearEntrega.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnModificarEntrega
            // 
            this.btnModificarEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarEntrega.Image")));
            this.btnModificarEntrega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnModificarEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificarEntrega.Name = "btnModificarEntrega";
            this.btnModificarEntrega.Padding = new System.Windows.Forms.Padding(15);
            this.btnModificarEntrega.Size = new System.Drawing.Size(92, 52);
            this.btnModificarEntrega.Text = "&Modificar";
            this.btnModificarEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificarEntrega.Click += new System.EventHandler(this.ModificarEntrega);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnIniciarEntrega
            // 
            this.btnIniciarEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnIniciarEntrega.Image")));
            this.btnIniciarEntrega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIniciarEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIniciarEntrega.Name = "btnIniciarEntrega";
            this.btnIniciarEntrega.Padding = new System.Windows.Forms.Padding(15);
            this.btnIniciarEntrega.Size = new System.Drawing.Size(73, 52);
            this.btnIniciarEntrega.Text = "&Iniciar";
            this.btnIniciarEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIniciarEntrega.Click += new System.EventHandler(this.btnIniciarEntrega_Click);
            // 
            // btnTerminarEntrega
            // 
            this.btnTerminarEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnTerminarEntrega.Image")));
            this.btnTerminarEntrega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTerminarEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTerminarEntrega.Name = "btnTerminarEntrega";
            this.btnTerminarEntrega.Padding = new System.Windows.Forms.Padding(15);
            this.btnTerminarEntrega.Size = new System.Drawing.Size(87, 52);
            this.btnTerminarEntrega.Text = "&Terminar";
            this.btnTerminarEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTerminarEntrega.Click += new System.EventHandler(this.btnTerminarEntrega_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(55, 52);
            this.btnExportar.Text = "&Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(57, 52);
            this.btnImportar.Text = "&Importar";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnEliminarEntrega
            // 
            this.btnEliminarEntrega.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarEntrega.Image")));
            this.btnEliminarEntrega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminarEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarEntrega.Name = "btnEliminarEntrega";
            this.btnEliminarEntrega.Size = new System.Drawing.Size(54, 52);
            this.btnEliminarEntrega.Text = "&Eliminar";
            this.btnEliminarEntrega.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminarEntrega.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1017, 460);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.toolStrip1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(997, 59);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdDatos;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 69);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(997, 371);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 59);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(997, 10);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmEntregaPisosPrin
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 460);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmEntregaPisosPrin";
            this.Text = "Entrega Pisos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntregaPisosPrin_FormClosing);
            this.Load += new System.EventHandler(this.frmEntregaPisosPrin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPisos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSucursales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgencias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPisos2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.ToolStripButton btnCrearEntrega;
        private System.Windows.Forms.ToolStripButton btnModificarEntrega;
        private System.Windows.Forms.ToolStripButton btnIniciarEntrega;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnTerminarEntrega;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.ToolStripButton btnImportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnEliminarEntrega;
        private DevExpress.XtraGrid.GridControl grdDatos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPisos;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSucursales;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAgencias;
        private DevExpress.XtraGrid.Views.Card.CardView grvPisos2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.Utils.ImageCollection imageCollection3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
    }
}