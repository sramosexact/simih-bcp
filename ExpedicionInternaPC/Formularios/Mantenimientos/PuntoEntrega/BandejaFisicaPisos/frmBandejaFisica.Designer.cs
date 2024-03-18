namespace ExpedicionInternaPC.Formularios
{
    partial class frmBandejaFisica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBandejaFisica));
            this.grdBandejasFisicas = new DevExpress.XtraGrid.GridControl();
            this.grvBandejasFisicas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkAsociarUbicaciones = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cboExpedicion = new DevExpress.XtraEditors.LookUpEdit();
            this.btnImprimir = new DevExpress.XtraEditors.SimpleButton();
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.grdUbicaciones = new DevExpress.XtraGrid.GridControl();
            this.grvUbicaciones = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejasFisicas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejasFisicas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkAsociarUbicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboExpedicion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUbicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUbicaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBandejasFisicas
            // 
            this.grdBandejasFisicas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBandejasFisicas.Location = new System.Drawing.Point(5, 55);
            this.grdBandejasFisicas.MainView = this.grvBandejasFisicas;
            this.grdBandejasFisicas.Name = "grdBandejasFisicas";
            this.grdBandejasFisicas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkAsociarUbicaciones});
            this.grdBandejasFisicas.Size = new System.Drawing.Size(352, 308);
            this.grdBandejasFisicas.TabIndex = 0;
            this.grdBandejasFisicas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBandejasFisicas});
            // 
            // grvBandejasFisicas
            // 
            this.grvBandejasFisicas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn6});
            this.grvBandejasFisicas.GridControl = this.grdBandejasFisicas;
            this.grvBandejasFisicas.Name = "grvBandejasFisicas";
            this.grvBandejasFisicas.OptionsView.ShowAutoFilterRow = true;
            this.grvBandejasFisicas.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBandejasFisicas.OptionsView.ShowGroupPanel = false;
            this.grvBandejasFisicas.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvBuzones_SelectionChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código";
            this.gridColumn1.FieldName = "idBandejaFisica";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Bandeja física";
            this.gridColumn5.FieldName = "nombre";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 176;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Editar ubicaciones";
            this.gridColumn6.ColumnEdit = this.linkAsociarUbicaciones;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 102;
            // 
            // linkAsociarUbicaciones
            // 
            this.linkAsociarUbicaciones.AutoHeight = false;
            this.linkAsociarUbicaciones.Caption = "Editar ubicaciones";
            this.linkAsociarUbicaciones.Name = "linkAsociarUbicaciones";
            this.linkAsociarUbicaciones.NullText = "Editar ubicaciones";
            this.linkAsociarUbicaciones.NullValuePrompt = "Editar ubicaciones";
            this.linkAsociarUbicaciones.Click += new System.EventHandler(this.linkAsociarUbicaciones_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.cboExpedicion);
            this.groupControl1.Location = new System.Drawing.Point(12, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(776, 54);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Seleccione Expedición";
            // 
            // cboExpedicion
            // 
            this.cboExpedicion.Location = new System.Drawing.Point(11, 26);
            this.cboExpedicion.Name = "cboExpedicion";
            this.cboExpedicion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboExpedicion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboExpedicion.Properties.ShowFooter = false;
            this.cboExpedicion.Properties.ShowHeader = false;
            this.cboExpedicion.Size = new System.Drawing.Size(297, 20);
            this.cboExpedicion.TabIndex = 0;
            this.cboExpedicion.EditValueChanged += new System.EventHandler(this.cboExpedicion_EditValueChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.ImageOptions.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(264, 26);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(93, 23);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.ImageOptions.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(5, 26);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(129, 23);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "Nuevo bandeja física";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grdUbicaciones
            // 
            this.grdUbicaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUbicaciones.Location = new System.Drawing.Point(5, 26);
            this.grdUbicaciones.MainView = this.grvUbicaciones;
            this.grdUbicaciones.Name = "grdUbicaciones";
            this.grdUbicaciones.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grdUbicaciones.Size = new System.Drawing.Size(398, 337);
            this.grdUbicaciones.TabIndex = 3;
            this.grdUbicaciones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUbicaciones});
            // 
            // grvUbicaciones
            // 
            this.grvUbicaciones.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3});
            this.grvUbicaciones.GridControl = this.grdUbicaciones;
            this.grvUbicaciones.Name = "grvUbicaciones";
            this.grvUbicaciones.OptionsView.ShowAutoFilterRow = true;
            this.grvUbicaciones.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Oficina";
            this.gridColumn2.FieldName = "oficina";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 197;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Área";
            this.gridColumn3.FieldName = "area";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 178;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Caption = "Quitar ubicaciones";
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Quitar asociación";
            this.repositoryItemHyperLinkEdit1.NullValuePrompt = "Quitar ubicaciones";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl2.Controls.Add(this.btnNuevo);
            this.groupControl2.Controls.Add(this.btnImprimir);
            this.groupControl2.Controls.Add(this.grdBandejasFisicas);
            this.groupControl2.Location = new System.Drawing.Point(12, 70);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(362, 368);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.Text = "Lista de bandejas físicas";
            // 
            // groupControl3
            // 
            this.groupControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl3.Controls.Add(this.grdUbicaciones);
            this.groupControl3.Location = new System.Drawing.Point(380, 70);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(408, 368);
            this.groupControl3.TabIndex = 5;
            this.groupControl3.Text = "Puntos de entrega asociados";
            // 
            // frmBandejaFisica
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmBandejaFisica";
            this.Tag = "Bandeja fisica";
            this.Text = "Administrar bandejas físicas";
            this.Load += new System.EventHandler(this.frmBuzon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejasFisicas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejasFisicas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkAsociarUbicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboExpedicion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUbicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUbicaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBandejasFisicas;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBandejasFisicas;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnNuevo;
        private DevExpress.XtraGrid.GridControl grdUbicaciones;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUbicaciones;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SimpleButton btnImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkAsociarUbicaciones;
        private DevExpress.XtraEditors.LookUpEdit cboExpedicion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}