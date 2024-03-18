namespace ExpedicionInternaPC
{
    partial class frmListaBandeja
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
            this.grdBandeja = new DevExpress.XtraGrid.GridControl();
            this.grvBandeja = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdGeo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoCasilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlias = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUbicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVinculados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdTipoCasilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnModificar = new System.Windows.Forms.ToolStripButton();
            this.btnCambiarEstado = new System.Windows.Forms.ToolStripButton();
            this.btnVincular = new System.Windows.Forms.ToolStripButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandeja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandeja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBandeja
            // 
            this.grdBandeja.Location = new System.Drawing.Point(12, 99);
            this.grdBandeja.MainView = this.grvBandeja;
            this.grdBandeja.Name = "grdBandeja";
            this.grdBandeja.Size = new System.Drawing.Size(971, 580);
            this.grdBandeja.TabIndex = 0;
            this.grdBandeja.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBandeja});
            // 
            // grvBandeja
            // 
            this.grvBandeja.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSeleccion,
            this.colID,
            this.colIdGeo,
            this.colDescripcion,
            this.colTipoCasilla,
            this.colAlias,
            this.colUbicacion,
            this.colVinculados,
            this.colIdTipoCasilla,
            this.colEstado});
            this.grvBandeja.GridControl = this.grdBandeja;
            this.grvBandeja.Name = "grvBandeja";
            this.grvBandeja.OptionsView.ShowAutoFilterRow = true;
            this.grvBandeja.OptionsView.ShowFooter = true;
            this.grvBandeja.OptionsView.ShowGroupPanel = false;
            this.grvBandeja.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvBandeja_CellValueChanging);
            // 
            // colSeleccion
            // 
            this.colSeleccion.Caption = "Selección";
            this.colSeleccion.FieldName = "SeleccionGrafica";
            this.colSeleccion.MaxWidth = 60;
            this.colSeleccion.MinWidth = 60;
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.Visible = true;
            this.colSeleccion.VisibleIndex = 0;
            this.colSeleccion.Width = 60;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
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
            this.colDescripcion.VisibleIndex = 1;
            this.colDescripcion.Width = 268;
            // 
            // colTipoCasilla
            // 
            this.colTipoCasilla.Caption = "Tipo bandeja";
            this.colTipoCasilla.FieldName = "tipoCasilla";
            this.colTipoCasilla.MaxWidth = 200;
            this.colTipoCasilla.MinWidth = 200;
            this.colTipoCasilla.Name = "colTipoCasilla";
            this.colTipoCasilla.Visible = true;
            this.colTipoCasilla.VisibleIndex = 2;
            this.colTipoCasilla.Width = 200;
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
            this.colUbicacion.Visible = true;
            this.colUbicacion.VisibleIndex = 3;
            this.colUbicacion.Width = 206;
            // 
            // colVinculados
            // 
            this.colVinculados.Caption = "Usuarios vinculados";
            this.colVinculados.FieldName = "STotal";
            this.colVinculados.MaxWidth = 200;
            this.colVinculados.MinWidth = 200;
            this.colVinculados.Name = "colVinculados";
            this.colVinculados.OptionsColumn.ReadOnly = true;
            this.colVinculados.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colVinculados.Visible = true;
            this.colVinculados.VisibleIndex = 4;
            this.colVinculados.Width = 200;
            // 
            // colIdTipoCasilla
            // 
            this.colIdTipoCasilla.Caption = "IdTipoCasilla";
            this.colIdTipoCasilla.FieldName = "IdTipoCasilla";
            this.colIdTipoCasilla.MaxWidth = 60;
            this.colIdTipoCasilla.MinWidth = 60;
            this.colIdTipoCasilla.Name = "colIdTipoCasilla";
            this.colIdTipoCasilla.Width = 60;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "sActivo";
            this.colEstado.MaxWidth = 200;
            this.colEstado.MinWidth = 200;
            this.colEstado.Name = "colEstado";
            this.colEstado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "sActivo", "{0}")});
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 5;
            this.colEstado.Width = 200;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.grdBandeja);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(995, 691);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.toolStrip1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(971, 83);
            this.panelControl1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnModificar,
            this.btnCambiarEstado,
            this.btnVincular});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(967, 79);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.AutoSize = false;
            this.btnNuevo.Image = global::ExpedicionInternaPC.Properties.Resources.pageadd32;
            this.btnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(70, 76);
            this.btnNuevo.Text = "&Nueva";
            this.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.AutoSize = false;
            this.btnModificar.Image = global::ExpedicionInternaPC.Properties.Resources.pageedit32;
            this.btnModificar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(70, 76);
            this.btnModificar.Text = "&Modificar";
            this.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.AutoSize = false;
            this.btnCambiarEstado.Image = global::ExpedicionInternaPC.Properties.Resources.RefreshDev32;
            this.btnCambiarEstado.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCambiarEstado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(90, 76);
            this.btnCambiarEstado.Text = "&Cambiar Estado";
            this.btnCambiarEstado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.AutoSize = false;
            this.btnVincular.Image = global::ExpedicionInternaPC.Properties.Resources.groupadd32;
            this.btnVincular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnVincular.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(70, 76);
            this.btnVincular.Text = "&Vincular";
            this.btnVincular.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
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
            this.layoutControlGroup1.Size = new System.Drawing.Size(995, 691);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(0, 87);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(5, 87);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(975, 87);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.grdBandeja;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 87);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(975, 584);
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // frmListaBandeja
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 691);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "frmListaBandeja";
            this.Text = "Bandejas";
            this.Activated += new System.EventHandler(this.frmListaBandeja_Activated);
            this.Deactivate += new System.EventHandler(this.frmListaBandeja_Deactivate);
            this.Load += new System.EventHandler(this.frmListaBandeja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBandeja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandeja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBandeja;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBandeja;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnModificar;
        private System.Windows.Forms.ToolStripButton btnCambiarEstado;
        private System.Windows.Forms.ToolStripButton btnVincular;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colIdGeo;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colAlias;
        private DevExpress.XtraGrid.Columns.GridColumn colVinculados;
        private DevExpress.XtraGrid.Columns.GridColumn colUbicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoCasilla;
        private DevExpress.XtraGrid.Columns.GridColumn colIdTipoCasilla;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccion;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
    }
}