
namespace ExpedicionInternaPC
{
    partial class frmMantenimientoColaboradorRecorridoPisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoColaboradorRecorridoPisos));
            this.btnNuevo = new DevExpress.XtraEditors.SimpleButton();
            this.grdColaboradores = new DevExpress.XtraGrid.GridControl();
            this.grvColaboradores = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.HyperLinkModificar = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdColaboradores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvColaboradores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HyperLinkModificar)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnNuevo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevo.ImageOptions.Image")));
            this.btnNuevo.Location = new System.Drawing.Point(12, 16);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grdColaboradores
            // 
            this.grdColaboradores.Location = new System.Drawing.Point(12, 45);
            this.grdColaboradores.MainView = this.grvColaboradores;
            this.grdColaboradores.Name = "grdColaboradores";
            this.grdColaboradores.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.HyperLinkModificar});
            this.grdColaboradores.Size = new System.Drawing.Size(662, 301);
            this.grdColaboradores.TabIndex = 2;
            this.grdColaboradores.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvColaboradores});
            // 
            // grvColaboradores
            // 
            this.grvColaboradores.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.grvColaboradores.GridControl = this.grdColaboradores;
            this.grvColaboradores.Name = "grvColaboradores";
            this.grvColaboradores.OptionsView.ShowAutoFilterRow = true;
            this.grvColaboradores.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvColaboradores.OptionsView.ShowFooter = true;
            this.grvColaboradores.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nombres";
            this.gridColumn1.FieldName = "Nombres";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Apellido paterno";
            this.gridColumn2.FieldName = "ApellidoPaterno";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Apellido materno";
            this.gridColumn3.FieldName = "ApellidoMaterno";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "DNI";
            this.gridColumn4.FieldName = "Dni";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Sede";
            this.gridColumn6.FieldName = "Sede";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Estado";
            this.gridColumn7.FieldName = "Estado";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Modificar";
            this.gridColumn8.ColumnEdit = this.HyperLinkModificar;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 6;
            // 
            // HyperLinkModificar
            // 
            this.HyperLinkModificar.AutoHeight = false;
            this.HyperLinkModificar.Caption = "Modificar";
            this.HyperLinkModificar.Name = "HyperLinkModificar";
            this.HyperLinkModificar.NullText = "Modificar";
            this.HyperLinkModificar.Click += new System.EventHandler(this.HyperLinkModificar_Click);
            // 
            // frmMantenimientoColaboradorRecorridoPisos
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 363);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.grdColaboradores);
            this.Name = "frmMantenimientoColaboradorRecorridoPisos";
            this.Text = "Mantenimiento de colaboradores recorrido";
            this.Load += new System.EventHandler(this.frmMantenimientoColaboradorRecorridoPisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdColaboradores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvColaboradores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HyperLinkModificar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnNuevo;
        private DevExpress.XtraGrid.GridControl grdColaboradores;
        private DevExpress.XtraGrid.Views.Grid.GridView grvColaboradores;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit HyperLinkModificar;
    }
}