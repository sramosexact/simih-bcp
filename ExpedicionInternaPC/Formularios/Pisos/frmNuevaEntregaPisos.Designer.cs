namespace ExpedicionInternaPC
{
    partial class frmNuevaEntregaPisos
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lupOperativo = new DevExpress.XtraEditors.LookUpEdit();
            this.lupGrupoPalomar = new DevExpress.XtraEditors.LookUpEdit();
            this.btnCrear = new DevExpress.XtraEditors.SimpleButton();
            this.btnIntroducirTodos = new DevExpress.XtraEditors.SimpleButton();
            this.btnExtraerTodos = new DevExpress.XtraEditors.SimpleButton();
            this.grdPalomaresEscogidos = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdPalomares = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOperativo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupGrupoPalomar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalomaresEscogidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalomares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.Name = "gridView1";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Grupo Palomar :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Operativo :";
            // 
            // lupOperativo
            // 
            this.lupOperativo.Location = new System.Drawing.Point(113, 12);
            this.lupOperativo.Name = "lupOperativo";
            this.lupOperativo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupOperativo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Nombre1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Nombre2")});
            this.lupOperativo.Properties.NullText = "Seleccione Operativo";
            this.lupOperativo.Properties.ShowFooter = false;
            this.lupOperativo.Properties.ShowHeader = false;
            this.lupOperativo.Size = new System.Drawing.Size(278, 20);
            this.lupOperativo.TabIndex = 11;
            this.lupOperativo.EditValueChanged += new System.EventHandler(this.lupOperativo_EditValueChanged);
            // 
            // lupGrupoPalomar
            // 
            this.lupGrupoPalomar.Location = new System.Drawing.Point(113, 38);
            this.lupGrupoPalomar.Name = "lupGrupoPalomar";
            this.lupGrupoPalomar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupGrupoPalomar.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IdGrupo", "Nombre3", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Grupo", "Nombre4")});
            this.lupGrupoPalomar.Properties.NullText = "Seleccione Grupo Palomar";
            this.lupGrupoPalomar.Properties.ShowFooter = false;
            this.lupGrupoPalomar.Properties.ShowHeader = false;
            this.lupGrupoPalomar.Size = new System.Drawing.Size(278, 20);
            this.lupGrupoPalomar.TabIndex = 10;
            this.lupGrupoPalomar.EditValueChanged += new System.EventHandler(this.lupGrupoPalomar_EditValueChanged);
            // 
            // btnCrear
            // 
            this.btnCrear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCrear.Image = global::ExpedicionInternaPC.Properties.Resources.layersmap32;
            this.btnCrear.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnCrear.Location = new System.Drawing.Point(170, 291);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(158, 71);
            this.btnCrear.TabIndex = 15;
            this.btnCrear.Text = "Crear Entrega Pisos";
            this.btnCrear.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIntroducirTodos
            // 
            this.btnIntroducirTodos.Location = new System.Drawing.Point(233, 127);
            this.btnIntroducirTodos.Name = "btnIntroducirTodos";
            this.btnIntroducirTodos.Size = new System.Drawing.Size(36, 22);
            this.btnIntroducirTodos.TabIndex = 19;
            this.btnIntroducirTodos.Text = ">>";
            this.btnIntroducirTodos.Click += new System.EventHandler(this.btnIntroducirTodos_Click);
            // 
            // btnExtraerTodos
            // 
            this.btnExtraerTodos.Location = new System.Drawing.Point(233, 164);
            this.btnExtraerTodos.Name = "btnExtraerTodos";
            this.btnExtraerTodos.Size = new System.Drawing.Size(36, 22);
            this.btnExtraerTodos.TabIndex = 19;
            this.btnExtraerTodos.Text = "<<";
            this.btnExtraerTodos.Click += new System.EventHandler(this.btnExtraerTodos_Click);
            // 
            // grdPalomaresEscogidos
            // 
            this.grdPalomaresEscogidos.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdPalomaresEscogidos.Location = new System.Drawing.Point(289, 78);
            this.grdPalomaresEscogidos.MainView = this.gridView2;
            this.grdPalomaresEscogidos.Name = "grdPalomaresEscogidos";
            this.grdPalomaresEscogidos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grdPalomaresEscogidos.Size = new System.Drawing.Size(205, 196);
            this.grdPalomaresEscogidos.TabIndex = 20;
            this.grdPalomaresEscogidos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView2.GridControl = this.grdPalomaresEscogidos;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView2.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView2_RowStyle);
            this.gridView2.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView2_CellValueChanging);
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Sel.";
            this.gridColumn8.FieldName = "SeleccionGrafica";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Width = 25;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.Caption = "PalomarEscogido";
            this.gridColumn6.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn6.FieldName = "Descripcion";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 162;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemHyperLinkEdit1.Appearance.Options.UseFont = true;
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.LinkColor = System.Drawing.Color.Black;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "eliminar";
            this.repositoryItemHyperLinkEdit1.DoubleClick += new System.EventHandler(this.eliminarPalomarEscogido);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "eliminar";
            this.gridColumn9.Name = "gridColumn9";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Base";
            this.gridColumn10.FieldName = "Base";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // grdPalomares
            // 
            this.grdPalomares.Location = new System.Drawing.Point(15, 78);
            this.grdPalomares.MainView = this.gridView3;
            this.grdPalomares.Name = "grdPalomares";
            this.grdPalomares.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit2});
            this.grdPalomares.Size = new System.Drawing.Size(205, 196);
            this.grdPalomares.TabIndex = 21;
            this.grdPalomares.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1});
            this.gridView3.GridControl = this.grdPalomares;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView3.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            this.gridView3.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView3_CellValueChanging);
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.Caption = "Sel.";
            this.gridColumn7.FieldName = "SeleccionGrafica";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Width = 25;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.Caption = "Palomares";
            this.gridColumn1.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.gridColumn1.FieldName = "Descripcion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 162;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.Appearance.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repositoryItemHyperLinkEdit2.Appearance.Options.UseFont = true;
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.repositoryItemHyperLinkEdit2.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.repositoryItemHyperLinkEdit2.LinkColor = System.Drawing.Color.Black;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.repositoryItemHyperLinkEdit2.DoubleClick += new System.EventHandler(this.DoubleClickEscogePalomar);
            // 
            // frmNuevaEntregaPisos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 371);
            this.Controls.Add(this.grdPalomares);
            this.Controls.Add(this.grdPalomaresEscogidos);
            this.Controls.Add(this.btnExtraerTodos);
            this.Controls.Add(this.btnIntroducirTodos);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lupOperativo);
            this.Controls.Add(this.lupGrupoPalomar);
            this.Name = "frmNuevaEntregaPisos";
            this.Text = "Crear Entrega Pisos";
            this.Load += new System.EventHandler(this.frmNuevaEntregaPisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupOperativo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupGrupoPalomar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalomaresEscogidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPalomares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lupOperativo;
        private DevExpress.XtraEditors.LookUpEdit lupGrupoPalomar;
        private DevExpress.XtraEditors.SimpleButton btnCrear;
        private DevExpress.XtraEditors.SimpleButton btnIntroducirTodos;
        private DevExpress.XtraEditors.SimpleButton btnExtraerTodos;
        private DevExpress.XtraGrid.GridControl grdPalomaresEscogidos;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.GridControl grdPalomares;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;

    }
}