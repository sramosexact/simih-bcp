
namespace ExpedicionInternaPC
{
    partial class frmBandejaPorGeo
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
            this.grdBandejas = new DevExpress.XtraGrid.GridControl();
            this.grvBandejas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblPuntoEntrega = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejas)).BeginInit();
            this.SuspendLayout();
            // 
            // grdBandejas
            // 
            this.grdBandejas.Location = new System.Drawing.Point(12, 61);
            this.grdBandejas.MainView = this.grvBandejas;
            this.grdBandejas.Name = "grdBandejas";
            this.grdBandejas.Size = new System.Drawing.Size(606, 289);
            this.grdBandejas.TabIndex = 0;
            this.grdBandejas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBandejas});
            // 
            // grvBandejas
            // 
            this.grvBandejas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grvBandejas.GridControl = this.grdBandejas;
            this.grvBandejas.Name = "grvBandejas";
            this.grvBandejas.OptionsView.ShowAutoFilterRow = true;
            this.grvBandejas.OptionsView.ShowFooter = true;
            this.grvBandejas.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Bandeja";
            this.gridColumn1.FieldName = "nombre";
            this.gridColumn1.MinWidth = 420;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 427;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tipo";
            this.gridColumn2.FieldName = "tipo";
            this.gridColumn2.MinWidth = 50;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "tipo", "{0}")});
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 161;
            // 
            // lblPuntoEntrega
            // 
            this.lblPuntoEntrega.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblPuntoEntrega.Appearance.Options.UseFont = true;
            this.lblPuntoEntrega.Location = new System.Drawing.Point(12, 29);
            this.lblPuntoEntrega.Name = "lblPuntoEntrega";
            this.lblPuntoEntrega.Size = new System.Drawing.Size(103, 16);
            this.lblPuntoEntrega.TabIndex = 1;
            this.lblPuntoEntrega.Text = "Punto de entrega:";
            // 
            // frmBandejaPorGeo
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 362);
            this.Controls.Add(this.lblPuntoEntrega);
            this.Controls.Add(this.grdBandejas);
            this.Name = "frmBandejaPorGeo";
            this.Text = "Bandejas asociadas";
            this.Load += new System.EventHandler(this.frmBandejaPorGeo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBandejas;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBandejas;
        private DevExpress.XtraEditors.LabelControl lblPuntoEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}