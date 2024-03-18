using System.Devices;
namespace ExpedicionInternaPC.Formularios.Expedicion
{
    partial class frmListaEntregaAgencias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
         public RemoteDeviceManager _pda;
        /// 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaEntregaAgencias));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tooMenu = new System.Windows.Forms.ToolStrip();
            this.btnCrear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnImportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnIniciar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSelecion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdDatos = new DevExpress.XtraGrid.GridControl();
            this.grvDatos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lnkEntrega = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colColaborador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaCreacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValidados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoValidados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExportado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection3 = new DevExpress.Utils.ImageCollection(this.components);
            this.colImportado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colTerminado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCerrado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtCantidadBultos = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tooMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadBultos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.tooMenu);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(960, 76);
            this.panelControl1.TabIndex = 1;
            // 
            // tooMenu
            // 
            this.tooMenu.AutoSize = false;
            this.tooMenu.BackColor = System.Drawing.Color.Transparent;
            this.tooMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tooMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tooMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tooMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCrear,
            this.toolStripSeparator2,
            this.btnExportar,
            this.btnImportar,
            this.toolStripSeparator1,
            this.btnEliminar,
            this.btnIniciar,
            this.toolStripSeparator8,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.btnSelecion,
            this.toolStripButton2});
            this.tooMenu.Location = new System.Drawing.Point(0, 0);
            this.tooMenu.Name = "tooMenu";
            this.tooMenu.Size = new System.Drawing.Size(960, 76);
            this.tooMenu.TabIndex = 14;
            this.tooMenu.Text = "toolStrip1";
            // 
            // btnCrear
            // 
            this.btnCrear.AutoSize = false;
            this.btnCrear.Image = global::ExpedicionInternaPC.Properties.Resources.cartadd32;
            this.btnCrear.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCrear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(80, 59);
            this.btnCrear.Text = "Nuevo envío";
            this.btnCrear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 76);
            // 
            // btnExportar
            // 
            this.btnExportar.AutoSize = false;
            this.btnExportar.Image = global::ExpedicionInternaPC.Properties.Resources.phoneAndroid32;
            this.btnExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(80, 59);
            this.btnExportar.Text = "Exportar";
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.AutoSize = false;
            this.btnImportar.Image = global::ExpedicionInternaPC.Properties.Resources.ipad32;
            this.btnImportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnImportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(80, 59);
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 76);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.Image = global::ExpedicionInternaPC.Properties.Resources.cancel32;
            this.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(80, 59);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.AutoSize = false;
            this.btnIniciar.Image = global::ExpedicionInternaPC.Properties.Resources.cartgo32;
            this.btnIniciar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIniciar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(80, 59);
            this.btnIniciar.Text = "Iniciar valijas";
            this.btnIniciar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 76);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Image = global::ExpedicionInternaPC.Properties.Resources.applicationformmagnify32;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 59);
            this.toolStripButton1.Text = "Ver Entregas";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 76);
            // 
            // btnSelecion
            // 
            this.btnSelecion.AutoSize = false;
            this.btnSelecion.Image = global::ExpedicionInternaPC.Properties.Resources.todolistchekedall32;
            this.btnSelecion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSelecion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelecion.Name = "btnSelecion";
            this.btnSelecion.Size = new System.Drawing.Size(80, 59);
            this.btnSelecion.Text = "Seleccionar";
            this.btnSelecion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSelecion.Click += new System.EventHandler(this.btnSelecion_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 73);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdDatos);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(984, 455);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdDatos
            // 
            this.grdDatos.Location = new System.Drawing.Point(12, 108);
            this.grdDatos.MainView = this.grvDatos;
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.lnkEntrega,
            this.repositoryItemImageComboBox1,
            this.repositoryItemImageComboBox2,
            this.txtCantidadBultos});
            this.grdDatos.Size = new System.Drawing.Size(960, 335);
            this.grdDatos.TabIndex = 0;
            this.grdDatos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDatos});
            // 
            // grvDatos
            // 
            this.grvDatos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccion,
            this.colEntrega,
            this.colEstado,
            this.colColaborador,
            this.gridColumn2,
            this.gridColumn1,
            this.colFechaCreacion,
            this.colRuta,
            this.colTotal,
            this.colValidados,
            this.colNoValidados,
            this.colExportado,
            this.colImportado,
            this.colTerminado,
            this.colCerrado});
            this.grvDatos.GridControl = this.grdDatos;
            this.grvDatos.Name = "grvDatos";
            this.grvDatos.OptionsView.ShowAutoFilterRow = true;
            this.grvDatos.OptionsView.ShowFooter = true;
            this.grvDatos.OptionsView.ShowGroupPanel = false;
            this.grvDatos.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colColaborador, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colNoValidados, DevExpress.Data.ColumnSortOrder.Descending)});
            this.grvDatos.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvDatos_RowCellStyle);
            this.grvDatos.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvDatos_RowStyle);
            this.grvDatos.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDatos_CellValueChanged);
            this.grvDatos.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvDatos_CellValueChanging);
            // 
            // colSeleccion
            // 
            this.colSeleccion.Caption = "Seleccion";
            this.colSeleccion.FieldName = "SeleccionGrafica";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSeleccion.Visible = true;
            this.colSeleccion.VisibleIndex = 0;
            this.colSeleccion.Width = 31;
            // 
            // colEntrega
            // 
            this.colEntrega.Caption = "Código de Lote";
            this.colEntrega.ColumnEdit = this.lnkEntrega;
            this.colEntrega.FieldName = "iIdEntregaGrupo";
            this.colEntrega.Name = "colEntrega";
            this.colEntrega.OptionsColumn.ReadOnly = true;
            this.colEntrega.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEntrega.Visible = true;
            this.colEntrega.VisibleIndex = 1;
            this.colEntrega.Width = 74;
            // 
            // lnkEntrega
            // 
            this.lnkEntrega.AutoHeight = false;
            this.lnkEntrega.Name = "lnkEntrega";
            this.lnkEntrega.Click += new System.EventHandler(this.lnkEntrega_Click);
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "EstadoDescripcion";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.AllowEdit = false;
            this.colEstado.OptionsColumn.ReadOnly = true;
            this.colEstado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 2;
            this.colEstado.Width = 91;
            // 
            // colColaborador
            // 
            this.colColaborador.Caption = "Asignado a";
            this.colColaborador.FieldName = "Colaborador";
            this.colColaborador.Name = "colColaborador";
            this.colColaborador.OptionsColumn.AllowEdit = false;
            this.colColaborador.OptionsColumn.ReadOnly = true;
            this.colColaborador.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colColaborador.Visible = true;
            this.colColaborador.VisibleIndex = 3;
            this.colColaborador.Width = 93;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Cod. Agencia";
            this.gridColumn2.FieldName = "CodigoAgencia";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Width = 74;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Agencia";
            this.gridColumn1.FieldName = "Agencia";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Width = 110;
            // 
            // colFechaCreacion
            // 
            this.colFechaCreacion.Caption = "Creado el";
            this.colFechaCreacion.DisplayFormat.FormatString = "G";
            this.colFechaCreacion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFechaCreacion.FieldName = "Registro";
            this.colFechaCreacion.Name = "colFechaCreacion";
            this.colFechaCreacion.OptionsColumn.AllowEdit = false;
            this.colFechaCreacion.OptionsColumn.ReadOnly = true;
            this.colFechaCreacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colFechaCreacion.Visible = true;
            this.colFechaCreacion.VisibleIndex = 4;
            this.colFechaCreacion.Width = 69;
            // 
            // colRuta
            // 
            this.colRuta.Caption = "Enviado el";
            this.colRuta.DisplayFormat.FormatString = "G";
            this.colRuta.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colRuta.FieldName = "Inicio";
            this.colRuta.Name = "colRuta";
            this.colRuta.OptionsColumn.AllowEdit = false;
            this.colRuta.OptionsColumn.ReadOnly = true;
            this.colRuta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colRuta.Visible = true;
            this.colRuta.VisibleIndex = 5;
            this.colRuta.Width = 72;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.Caption = "Total";
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 6;
            this.colTotal.Width = 42;
            // 
            // colValidados
            // 
            this.colValidados.AppearanceCell.Options.UseTextOptions = true;
            this.colValidados.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colValidados.Caption = "Validados";
            this.colValidados.FieldName = "idTipoValidacion";
            this.colValidados.Name = "colValidados";
            this.colValidados.OptionsColumn.AllowEdit = false;
            this.colValidados.OptionsColumn.ReadOnly = true;
            this.colValidados.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colValidados.Visible = true;
            this.colValidados.VisibleIndex = 7;
            this.colValidados.Width = 46;
            // 
            // colNoValidados
            // 
            this.colNoValidados.AppearanceCell.Options.UseTextOptions = true;
            this.colNoValidados.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNoValidados.Caption = "No Validados";
            this.colNoValidados.FieldName = "noRecibido";
            this.colNoValidados.Name = "colNoValidados";
            this.colNoValidados.OptionsColumn.AllowEdit = false;
            this.colNoValidados.OptionsColumn.ReadOnly = true;
            this.colNoValidados.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNoValidados.Visible = true;
            this.colNoValidados.VisibleIndex = 8;
            this.colNoValidados.Width = 46;
            // 
            // colExportado
            // 
            this.colExportado.AppearanceCell.Options.UseTextOptions = true;
            this.colExportado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colExportado.Caption = "Exportado";
            this.colExportado.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colExportado.FieldName = "Exportado";
            this.colExportado.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colExportado.Name = "colExportado";
            this.colExportado.OptionsColumn.ReadOnly = true;
            this.colExportado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colExportado.Visible = true;
            this.colExportado.VisibleIndex = 9;
            this.colExportado.Width = 50;
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
            // colImportado
            // 
            this.colImportado.AppearanceCell.Options.UseTextOptions = true;
            this.colImportado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colImportado.Caption = "Importado";
            this.colImportado.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colImportado.FieldName = "Importado";
            this.colImportado.ImageAlignment = System.Drawing.StringAlignment.Center;
            this.colImportado.Name = "colImportado";
            this.colImportado.OptionsColumn.ReadOnly = true;
            this.colImportado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colImportado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Importado", "{0}")});
            this.colImportado.Visible = true;
            this.colImportado.VisibleIndex = 10;
            this.colImportado.Width = 94;
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
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 73, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 278, 0)});
            this.repositoryItemImageComboBox2.LargeImages = this.imageCollection3;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // colTerminado
            // 
            this.colTerminado.Caption = "Terminado el";
            this.colTerminado.DisplayFormat.FormatString = "G";
            this.colTerminado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTerminado.FieldName = "Fin";
            this.colTerminado.Name = "colTerminado";
            this.colTerminado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colCerrado
            // 
            this.colCerrado.Caption = "Cerrado el";
            this.colCerrado.DisplayFormat.FormatString = "G";
            this.colCerrado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCerrado.FieldName = "Cierre";
            this.colCerrado.Name = "colCerrado";
            this.colCerrado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // txtCantidadBultos
            // 
            this.txtCantidadBultos.AutoHeight = false;
            this.txtCantidadBultos.Name = "txtCantidadBultos";
            this.txtCantidadBultos.Click += new System.EventHandler(this.txtCantidadBultos_Click);
            this.txtCantidadBultos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadBultos_KeyPress);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(984, 455);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
            this.layoutControlItem1.AppearanceItemCaption.BackColor2 = System.Drawing.Color.Goldenrod;
            this.layoutControlItem1.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutControlItem1.Control = this.grdDatos;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 80);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(964, 355);
            this.layoutControlItem1.Text = " ";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(3, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.panelControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 80);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(5, 80);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(964, 80);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmListaEntregaAgencias
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 455);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmListaEntregaAgencias";
            this.Tag = "Entrega Agencias";
            this.Text = "Entrega de Agencias";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListaEntregaAgencias_FormClosing);
            this.Load += new System.EventHandler(this.frmListaEntregaAgencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tooMenu.ResumeLayout(false);
            this.tooMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidadBultos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdDatos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDatos;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccion;
        private DevExpress.XtraGrid.Columns.GridColumn colEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colColaborador;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaCreacion;
        private DevExpress.XtraGrid.Columns.GridColumn colRuta;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colValidados;
        private DevExpress.XtraGrid.Columns.GridColumn colNoValidados;
        private DevExpress.XtraGrid.Columns.GridColumn colExportado;
        private DevExpress.XtraGrid.Columns.GridColumn colImportado;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminado;
        private DevExpress.XtraGrid.Columns.GridColumn colCerrado;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit lnkEntrega;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.Utils.ImageCollection imageCollection3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private System.Windows.Forms.ToolStrip tooMenu;
        private System.Windows.Forms.ToolStripButton btnCrear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnImportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.ToolStripButton btnIniciar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnSelecion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit txtCantidadBultos;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
    }
}