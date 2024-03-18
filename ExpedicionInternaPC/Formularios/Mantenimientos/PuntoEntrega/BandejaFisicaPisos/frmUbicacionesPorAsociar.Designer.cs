namespace ExpedicionInternaPC.Formularios.Mantenimientos.PuntoEntrega.BandejaFisicaPisos
{
    partial class frmUbicacionesPorAsociar
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
            this.grdUbicacionesAsociadas = new DevExpress.XtraGrid.GridControl();
            this.grvUbicacionesAsociadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkDesasociar = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grdUbicacionesPorAsociar = new DevExpress.XtraGrid.GridControl();
            this.grvUbicacionesPorAsociar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkAsociar = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUbicacionesAsociadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUbicacionesAsociadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDesasociar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUbicacionesPorAsociar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUbicacionesPorAsociar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkAsociar)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUbicacionesAsociadas
            // 
            this.grdUbicacionesAsociadas.Location = new System.Drawing.Point(9, 218);
            this.grdUbicacionesAsociadas.MainView = this.grvUbicacionesAsociadas;
            this.grdUbicacionesAsociadas.Name = "grdUbicacionesAsociadas";
            this.grdUbicacionesAsociadas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkDesasociar});
            this.grdUbicacionesAsociadas.Size = new System.Drawing.Size(613, 221);
            this.grdUbicacionesAsociadas.TabIndex = 0;
            this.grdUbicacionesAsociadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUbicacionesAsociadas});
            // 
            // grvUbicacionesAsociadas
            // 
            this.grvUbicacionesAsociadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.grvUbicacionesAsociadas.GridControl = this.grdUbicacionesAsociadas;
            this.grvUbicacionesAsociadas.Name = "grvUbicacionesAsociadas";
            this.grvUbicacionesAsociadas.OptionsView.ShowAutoFilterRow = true;
            this.grvUbicacionesAsociadas.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Oficina";
            this.gridColumn4.FieldName = "oficina";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            this.gridColumn4.Width = 223;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Área";
            this.gridColumn5.FieldName = "area";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 275;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Quitar asociación";
            this.gridColumn6.ColumnEdit = this.linkDesasociar;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 2;
            this.gridColumn6.Width = 90;
            // 
            // linkDesasociar
            // 
            this.linkDesasociar.AutoHeight = false;
            this.linkDesasociar.Name = "linkDesasociar";
            this.linkDesasociar.NullText = "Quitar asociación";
            this.linkDesasociar.Click += new System.EventHandler(this.linkDesasociar_Click);
            // 
            // grdUbicacionesPorAsociar
            // 
            this.grdUbicacionesPorAsociar.Location = new System.Drawing.Point(9, 12);
            this.grdUbicacionesPorAsociar.MainView = this.grvUbicacionesPorAsociar;
            this.grdUbicacionesPorAsociar.Name = "grdUbicacionesPorAsociar";
            this.grdUbicacionesPorAsociar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkAsociar});
            this.grdUbicacionesPorAsociar.Size = new System.Drawing.Size(613, 200);
            this.grdUbicacionesPorAsociar.TabIndex = 2;
            this.grdUbicacionesPorAsociar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUbicacionesPorAsociar});
            // 
            // grvUbicacionesPorAsociar
            // 
            this.grvUbicacionesPorAsociar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.grvUbicacionesPorAsociar.GridControl = this.grdUbicacionesPorAsociar;
            this.grvUbicacionesPorAsociar.Name = "grvUbicacionesPorAsociar";
            this.grvUbicacionesPorAsociar.OptionsView.ShowAutoFilterRow = true;
            this.grvUbicacionesPorAsociar.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Oficina";
            this.gridColumn1.FieldName = "oficina";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 223;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Área";
            this.gridColumn2.FieldName = "area";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 273;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Asociar";
            this.gridColumn3.ColumnEdit = this.linkAsociar;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 92;
            // 
            // linkAsociar
            // 
            this.linkAsociar.AutoHeight = false;
            this.linkAsociar.Name = "linkAsociar";
            this.linkAsociar.NullText = "Asociar";
            this.linkAsociar.Click += new System.EventHandler(this.linkAsociar_Click);
            // 
            // frmUbicacionesPorAsociar
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 456);
            this.Controls.Add(this.grdUbicacionesPorAsociar);
            this.Controls.Add(this.grdUbicacionesAsociadas);
            this.Name = "frmUbicacionesPorAsociar";
            this.Text = "Ubicaciones por asociar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUbicacionesPorAsociar_FormClosed);
            this.Load += new System.EventHandler(this.frmUbicacionesPorAsociar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUbicacionesAsociadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUbicacionesAsociadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDesasociar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUbicacionesPorAsociar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUbicacionesPorAsociar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkAsociar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdUbicacionesAsociadas;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUbicacionesAsociadas;
        private DevExpress.XtraGrid.GridControl grdUbicacionesPorAsociar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUbicacionesPorAsociar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkAsociar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkDesasociar;
    }
}