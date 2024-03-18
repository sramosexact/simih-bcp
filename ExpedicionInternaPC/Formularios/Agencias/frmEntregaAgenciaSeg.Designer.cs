namespace ExpedicionInternaPC.Formularios.Expedicion
{
    partial class frmEntregaAgenciaSeg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaAgenciaSeg));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnActualizar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnExportarExcel = new DevExpress.XtraEditors.SimpleButton();
            this.grdListaEntrega = new DevExpress.XtraGrid.GridControl();
            this.grvListaEntrega = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkEntrega = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEnviadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTerminadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCerradoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendientes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustodia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecibido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConfirmado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCantidadBultos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListaEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkEntrega)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnActualizar);
            this.layoutControl1.Controls.Add(this.btnExportarExcel);
            this.layoutControl1.Controls.Add(this.grdListaEntrega);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(662, 398, 250, 348);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1145, 644);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnActualizar.ImageOptions.ImageIndex = 1;
            this.btnActualizar.ImageOptions.ImageList = this.imageCollection1;
            this.btnActualizar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftTop;
            this.btnActualizar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnActualizar.Location = new System.Drawing.Point(1056, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(77, 22);
            this.btnActualizar.StyleController = this.layoutControl1;
            this.btnActualizar.TabIndex = 6;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.fileextensionxls32, "fileextensionxls32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "fileextensionxls32");
            this.imageCollection1.Images.SetKeyName(1, "arrowrefresh32.png");
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.ImageOptions.ImageIndex = 0;
            this.btnExportarExcel.ImageOptions.ImageList = this.imageCollection1;
            this.btnExportarExcel.Location = new System.Drawing.Point(980, 12);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(72, 22);
            this.btnExportarExcel.StyleController = this.layoutControl1;
            this.btnExportarExcel.TabIndex = 5;
            this.btnExportarExcel.Text = "Exportar";
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // grdListaEntrega
            // 
            this.grdListaEntrega.Location = new System.Drawing.Point(12, 38);
            this.grdListaEntrega.MainView = this.grvListaEntrega;
            this.grdListaEntrega.Name = "grdListaEntrega";
            this.grdListaEntrega.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkEntrega});
            this.grdListaEntrega.Size = new System.Drawing.Size(1121, 594);
            this.grdListaEntrega.TabIndex = 4;
            this.grdListaEntrega.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvListaEntrega});
            // 
            // grvListaEntrega
            // 
            this.grvListaEntrega.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEntrega,
            this.colEstado,
            this.colCreadoPor,
            this.colCodAgencia,
            this.colAgencia,
            this.colCreadoEl,
            this.colEnviadoEl,
            this.colTerminadoEl,
            this.colCerradoEl,
            this.colTotal,
            this.colPendientes,
            this.colCustodia,
            this.colRuta,
            this.colRecibido,
            this.colConfirmado,
            this.colCantidadBultos});
            this.grvListaEntrega.GridControl = this.grdListaEntrega;
            this.grvListaEntrega.Name = "grvListaEntrega";
            this.grvListaEntrega.OptionsView.ShowAutoFilterRow = true;
            this.grvListaEntrega.OptionsView.ShowGroupPanel = false;
            this.grvListaEntrega.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvListaEntrega_RowStyle);
            // 
            // colEntrega
            // 
            this.colEntrega.Caption = "Código de entrega";
            this.colEntrega.ColumnEdit = this.linkEntrega;
            this.colEntrega.FieldName = "ID";
            this.colEntrega.MaxWidth = 80;
            this.colEntrega.MinWidth = 80;
            this.colEntrega.Name = "colEntrega";
            this.colEntrega.OptionsColumn.ReadOnly = true;
            this.colEntrega.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEntrega.Visible = true;
            this.colEntrega.VisibleIndex = 0;
            this.colEntrega.Width = 80;
            // 
            // linkEntrega
            // 
            this.linkEntrega.AutoHeight = false;
            this.linkEntrega.Name = "linkEntrega";
            this.linkEntrega.Click += new System.EventHandler(this.linkEntrega_Click);
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "EstadoDescripcion";
            this.colEstado.MaxWidth = 120;
            this.colEstado.MinWidth = 120;
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.ReadOnly = true;
            this.colEstado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 1;
            this.colEstado.Width = 120;
            // 
            // colCreadoPor
            // 
            this.colCreadoPor.Caption = "Creado por";
            this.colCreadoPor.FieldName = "Usuario";
            this.colCreadoPor.MaxWidth = 160;
            this.colCreadoPor.MinWidth = 160;
            this.colCreadoPor.Name = "colCreadoPor";
            this.colCreadoPor.OptionsColumn.ReadOnly = true;
            this.colCreadoPor.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCreadoPor.Visible = true;
            this.colCreadoPor.VisibleIndex = 2;
            this.colCreadoPor.Width = 160;
            // 
            // colCodAgencia
            // 
            this.colCodAgencia.Caption = "Cod.Agencia";
            this.colCodAgencia.FieldName = "CodigoAgencia";
            this.colCodAgencia.MaxWidth = 100;
            this.colCodAgencia.MinWidth = 100;
            this.colCodAgencia.Name = "colCodAgencia";
            this.colCodAgencia.OptionsColumn.ReadOnly = true;
            this.colCodAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodAgencia.Visible = true;
            this.colCodAgencia.VisibleIndex = 3;
            this.colCodAgencia.Width = 100;
            // 
            // colAgencia
            // 
            this.colAgencia.Caption = "Agencia";
            this.colAgencia.FieldName = "Agencia";
            this.colAgencia.MaxWidth = 230;
            this.colAgencia.MinWidth = 230;
            this.colAgencia.Name = "colAgencia";
            this.colAgencia.OptionsColumn.ReadOnly = true;
            this.colAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAgencia.Visible = true;
            this.colAgencia.VisibleIndex = 4;
            this.colAgencia.Width = 230;
            // 
            // colCreadoEl
            // 
            this.colCreadoEl.Caption = "Creado el";
            this.colCreadoEl.FieldName = "Registro";
            this.colCreadoEl.MaxWidth = 110;
            this.colCreadoEl.MinWidth = 110;
            this.colCreadoEl.Name = "colCreadoEl";
            this.colCreadoEl.OptionsColumn.ReadOnly = true;
            this.colCreadoEl.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCreadoEl.Width = 110;
            // 
            // colEnviadoEl
            // 
            this.colEnviadoEl.Caption = "Enviado el";
            this.colEnviadoEl.FieldName = "Inicio";
            this.colEnviadoEl.MaxWidth = 110;
            this.colEnviadoEl.MinWidth = 110;
            this.colEnviadoEl.Name = "colEnviadoEl";
            this.colEnviadoEl.OptionsColumn.ReadOnly = true;
            this.colEnviadoEl.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEnviadoEl.Visible = true;
            this.colEnviadoEl.VisibleIndex = 5;
            this.colEnviadoEl.Width = 110;
            // 
            // colTerminadoEl
            // 
            this.colTerminadoEl.Caption = "Terminado el";
            this.colTerminadoEl.FieldName = "Fin";
            this.colTerminadoEl.MaxWidth = 110;
            this.colTerminadoEl.MinWidth = 110;
            this.colTerminadoEl.Name = "colTerminadoEl";
            this.colTerminadoEl.OptionsColumn.ReadOnly = true;
            this.colTerminadoEl.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTerminadoEl.Visible = true;
            this.colTerminadoEl.VisibleIndex = 6;
            this.colTerminadoEl.Width = 110;
            // 
            // colCerradoEl
            // 
            this.colCerradoEl.Caption = "Cerrado el";
            this.colCerradoEl.FieldName = "Cierre";
            this.colCerradoEl.MaxWidth = 110;
            this.colCerradoEl.MinWidth = 110;
            this.colCerradoEl.Name = "colCerradoEl";
            this.colCerradoEl.OptionsColumn.ReadOnly = true;
            this.colCerradoEl.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCerradoEl.Width = 110;
            // 
            // colTotal
            // 
            this.colTotal.AppearanceCell.Options.UseTextOptions = true;
            this.colTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.AppearanceHeader.Options.UseTextOptions = true;
            this.colTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTotal.Caption = "Total";
            this.colTotal.FieldName = "Total";
            this.colTotal.MaxWidth = 70;
            this.colTotal.MinWidth = 70;
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 7;
            this.colTotal.Width = 70;
            // 
            // colPendientes
            // 
            this.colPendientes.Caption = "Pendientes";
            this.colPendientes.FieldName = "Pendientes";
            this.colPendientes.Name = "colPendientes";
            this.colPendientes.Visible = true;
            this.colPendientes.VisibleIndex = 8;
            this.colPendientes.Width = 123;
            // 
            // colCustodia
            // 
            this.colCustodia.Caption = "Custodia";
            this.colCustodia.MaxWidth = 70;
            this.colCustodia.MinWidth = 70;
            this.colCustodia.Name = "colCustodia";
            this.colCustodia.OptionsColumn.ReadOnly = true;
            this.colCustodia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCustodia.Width = 70;
            // 
            // colRuta
            // 
            this.colRuta.Caption = "Ruta";
            this.colRuta.MaxWidth = 70;
            this.colRuta.MinWidth = 70;
            this.colRuta.Name = "colRuta";
            this.colRuta.OptionsColumn.ReadOnly = true;
            this.colRuta.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colRuta.Width = 70;
            // 
            // colRecibido
            // 
            this.colRecibido.Caption = "Recibidos";
            this.colRecibido.MaxWidth = 70;
            this.colRecibido.MinWidth = 70;
            this.colRecibido.Name = "colRecibido";
            this.colRecibido.OptionsColumn.ReadOnly = true;
            this.colRecibido.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colRecibido.Width = 70;
            // 
            // colConfirmado
            // 
            this.colConfirmado.Caption = "Confirmados";
            this.colConfirmado.MaxWidth = 70;
            this.colConfirmado.MinWidth = 70;
            this.colConfirmado.Name = "colConfirmado";
            this.colConfirmado.OptionsColumn.ReadOnly = true;
            this.colConfirmado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colConfirmado.Width = 70;
            // 
            // colCantidadBultos
            // 
            this.colCantidadBultos.AppearanceCell.Options.UseTextOptions = true;
            this.colCantidadBultos.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantidadBultos.AppearanceHeader.Options.UseTextOptions = true;
            this.colCantidadBultos.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCantidadBultos.Caption = "Bultos";
            this.colCantidadBultos.FieldName = "iCantidadBultos";
            this.colCantidadBultos.MaxWidth = 70;
            this.colCantidadBultos.MinWidth = 70;
            this.colCantidadBultos.Name = "colCantidadBultos";
            this.colCantidadBultos.OptionsColumn.ReadOnly = true;
            this.colCantidadBultos.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCantidadBultos.Visible = true;
            this.colCantidadBultos.VisibleIndex = 9;
            this.colCantidadBultos.Width = 70;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1145, 644);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.grdListaEntrega;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1125, 598);
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnExportarExcel;
            this.layoutControlItem2.Location = new System.Drawing.Point(968, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(76, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(968, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnActualizar;
            this.layoutControlItem3.Location = new System.Drawing.Point(1044, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(81, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmEntregaAgenciaSeg
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 644);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmEntregaAgenciaSeg";
            this.Text = "Seguimiento de Entregas de Agencia";
            this.Load += new System.EventHandler(this.frmEntregaAgenciaSeg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdListaEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvListaEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkEntrega)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl grdListaEntrega;
        private DevExpress.XtraGrid.Views.Grid.GridView grvListaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colCodAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colCreadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colEnviadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colTerminadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colCerradoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colCustodia;
        private DevExpress.XtraGrid.Columns.GridColumn colRuta;
        private DevExpress.XtraGrid.Columns.GridColumn colRecibido;
        private DevExpress.XtraGrid.Columns.GridColumn colConfirmado;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.SimpleButton btnExportarExcel;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colPendientes;
        private DevExpress.XtraEditors.SimpleButton btnActualizar;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colCantidadBultos;
    }
}