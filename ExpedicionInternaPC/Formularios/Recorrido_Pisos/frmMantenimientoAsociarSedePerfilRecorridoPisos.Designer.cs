
namespace ExpedicionInternaPC
{
    partial class frmMantenimientoAsociarSedePerfilRecorridoPisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoAsociarSedePerfilRecorridoPisos));
            this.grdUsuariosPerfil = new DevExpress.XtraGrid.GridControl();
            this.grvUsuarioPerfil = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdSede = new DevExpress.XtraGrid.GridControl();
            this.grvSede = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.btnAgregarSede = new DevExpress.XtraEditors.SimpleButton();
            this.cboListaSedes = new DevExpress.XtraEditors.LookUpEdit();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuariosPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsuarioPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboListaSedes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdUsuariosPerfil
            // 
            this.grdUsuariosPerfil.Location = new System.Drawing.Point(12, 12);
            this.grdUsuariosPerfil.MainView = this.grvUsuarioPerfil;
            this.grdUsuariosPerfil.Name = "grdUsuariosPerfil";
            this.grdUsuariosPerfil.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grdUsuariosPerfil.Size = new System.Drawing.Size(400, 200);
            this.grdUsuariosPerfil.TabIndex = 0;
            this.grdUsuariosPerfil.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUsuarioPerfil});
            // 
            // grvUsuarioPerfil
            // 
            this.grvUsuarioPerfil.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grvUsuarioPerfil.GridControl = this.grdUsuariosPerfil;
            this.grvUsuarioPerfil.Name = "grvUsuarioPerfil";
            this.grvUsuarioPerfil.OptionsView.ShowAutoFilterRow = true;
            this.grvUsuarioPerfil.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Usuario";
            this.gridColumn1.FieldName = "Usuario";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Perfil";
            this.gridColumn2.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn2.FieldName = "Perfil";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // grdSede
            // 
            this.grdSede.Location = new System.Drawing.Point(12, 245);
            this.grdSede.MainView = this.grvSede;
            this.grdSede.Name = "grdSede";
            this.grdSede.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit2});
            this.grdSede.Size = new System.Drawing.Size(400, 159);
            this.grdSede.TabIndex = 1;
            this.grdSede.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSede});
            // 
            // grvSede
            // 
            this.grvSede.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.grvSede.GridControl = this.grdSede;
            this.grvSede.Name = "grvSede";
            this.grvSede.OptionsView.ShowAutoFilterRow = true;
            this.grvSede.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Sede";
            this.gridColumn3.FieldName = "Nombre";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Seleccionar perfil";
            // 
            // btnAgregarSede
            // 
            this.btnAgregarSede.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarSede.ImageOptions.Image")));
            this.btnAgregarSede.Location = new System.Drawing.Point(203, 216);
            this.btnAgregarSede.Name = "btnAgregarSede";
            this.btnAgregarSede.Size = new System.Drawing.Size(22, 23);
            this.btnAgregarSede.TabIndex = 2;
            this.btnAgregarSede.Click += new System.EventHandler(this.btnAgregarSede_Click);
            // 
            // cboListaSedes
            // 
            this.cboListaSedes.Location = new System.Drawing.Point(12, 218);
            this.cboListaSedes.Name = "cboListaSedes";
            this.cboListaSedes.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboListaSedes.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Sede")});
            this.cboListaSedes.Properties.ShowFooter = false;
            this.cboListaSedes.Properties.ShowHeader = false;
            this.cboListaSedes.Size = new System.Drawing.Size(185, 20);
            this.cboListaSedes.TabIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Acción";
            this.gridColumn4.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.repositoryItemHyperLinkEdit2.NullText = "Eliminar";
            // 
            // frmMantenimientoAsociarSedePerfilRecorridoPisos
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 416);
            this.Controls.Add(this.cboListaSedes);
            this.Controls.Add(this.btnAgregarSede);
            this.Controls.Add(this.grdSede);
            this.Controls.Add(this.grdUsuariosPerfil);
            this.Name = "frmMantenimientoAsociarSedePerfilRecorridoPisos";
            this.Text = "Asociar usuario a perfil y sede";
            this.Load += new System.EventHandler(this.frmMantenimientoAsociarSedePerfilRecorridoPisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdUsuariosPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsuarioPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboListaSedes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdUsuariosPerfil;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUsuarioPerfil;
        private DevExpress.XtraGrid.GridControl grdSede;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSede;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.SimpleButton btnAgregarSede;
        private DevExpress.XtraEditors.LookUpEdit cboListaSedes;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
    }
}