namespace ExpedicionInternaPC
{
    partial class frmBuscarBandejaOrigen
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
            this.lcgPrincipal = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtBandejaOrigen = new DevExpress.XtraEditors.TextEdit();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.grdBandejaOrigen = new DevExpress.XtraGrid.GridControl();
            this.grvBandejaOrigen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdCasilla = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAREA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldistrito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.pnlPrincipal = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).BeginInit();
            this.lcgPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBandejaOrigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejaOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejaOrigen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // lcgPrincipal
            // 
            this.lcgPrincipal.Controls.Add(this.panelControl1);
            this.lcgPrincipal.Controls.Add(this.grdBandejaOrigen);
            this.lcgPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lcgPrincipal.Location = new System.Drawing.Point(0, 0);
            this.lcgPrincipal.Name = "lcgPrincipal";
            this.lcgPrincipal.Root = this.layoutControlGroup1;
            this.lcgPrincipal.Size = new System.Drawing.Size(709, 400);
            this.lcgPrincipal.TabIndex = 0;
            this.lcgPrincipal.Text = "layoutControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txtBandejaOrigen);
            this.panelControl1.Controls.Add(this.btnBuscar);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(544, 49);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 19);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Bandeja";
            // 
            // txtBandejaOrigen
            // 
            this.txtBandejaOrigen.Location = new System.Drawing.Point(88, 13);
            this.txtBandejaOrigen.Name = "txtBandejaOrigen";
            this.txtBandejaOrigen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtBandejaOrigen.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtBandejaOrigen.Properties.Appearance.Options.UseFont = true;
            this.txtBandejaOrigen.Properties.Appearance.Options.UseForeColor = true;
            this.txtBandejaOrigen.Size = new System.Drawing.Size(356, 22);
            this.txtBandejaOrigen.TabIndex = 4;
            this.txtBandejaOrigen.TextChanged += new System.EventHandler(this.txtBandejaOrigen_TextChanged);
            this.txtBandejaOrigen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBandejaOrigen_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnBuscar.Appearance.Options.UseFont = true;
            this.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBuscar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.FindDev32;
            this.btnBuscar.Location = new System.Drawing.Point(450, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(91, 32);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // grdBandejaOrigen
            // 
            this.grdBandejaOrigen.Location = new System.Drawing.Point(12, 65);
            this.grdBandejaOrigen.MainView = this.grvBandejaOrigen;
            this.grdBandejaOrigen.Name = "grdBandejaOrigen";
            this.grdBandejaOrigen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grdBandejaOrigen.Size = new System.Drawing.Size(685, 323);
            this.grdBandejaOrigen.TabIndex = 2;
            this.grdBandejaOrigen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBandejaOrigen});
            // 
            // grvBandejaOrigen
            // 
            this.grvBandejaOrigen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDescripcion,
            this.colID,
            this.colIdCasilla,
            this.colAREA,
            this.coldistrito});
            this.grvBandejaOrigen.GridControl = this.grdBandejaOrigen;
            this.grvBandejaOrigen.Name = "grvBandejaOrigen";
            this.grvBandejaOrigen.OptionsView.ShowFooter = true;
            this.grvBandejaOrigen.OptionsView.ShowGroupPanel = false;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Bandeja";
            this.colDescripcion.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 0;
            this.colDescripcion.Width = 214;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colIdCasilla
            // 
            this.colIdCasilla.FieldName = "IdCasilla";
            this.colIdCasilla.Name = "colIdCasilla";
            // 
            // colAREA
            // 
            this.colAREA.Caption = "Área";
            this.colAREA.FieldName = "AREA";
            this.colAREA.Name = "colAREA";
            this.colAREA.OptionsColumn.AllowEdit = false;
            this.colAREA.Visible = true;
            this.colAREA.VisibleIndex = 1;
            this.colAREA.Width = 214;
            // 
            // coldistrito
            // 
            this.coldistrito.Caption = "Distrito";
            this.coldistrito.FieldName = "Descripcion2";
            this.coldistrito.Name = "coldistrito";
            this.coldistrito.OptionsColumn.AllowEdit = false;
            this.coldistrito.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Descripcion2", "{0}")});
            this.coldistrito.Visible = true;
            this.coldistrito.VisibleIndex = 2;
            this.coldistrito.Width = 232;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(709, 400);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.grdBandejaOrigen;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 53);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(689, 327);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.panelControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(548, 53);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(548, 53);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(689, 53);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(709, 400);
            this.pnlPrincipal.TabIndex = 1;
            // 
            // frmBuscarBandejaOrigen
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 400);
            this.Controls.Add(this.lcgPrincipal);
            this.Controls.Add(this.pnlPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBuscarBandejaOrigen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar Bandeja";
            ((System.ComponentModel.ISupportInitialize)(this.lcgPrincipal)).EndInit();
            this.lcgPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBandejaOrigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejaOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejaOrigen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl lcgPrincipal;
        private DevExpress.XtraGrid.GridControl grdBandejaOrigen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBandejaOrigen;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraEditors.TextEdit txtBandejaOrigen;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.PanelControl pnlPrincipal;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colIdCasilla;
        private DevExpress.XtraGrid.Columns.GridColumn colAREA;
        private DevExpress.XtraGrid.Columns.GridColumn coldistrito;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}