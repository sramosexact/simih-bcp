namespace ExpedicionInternaPC
{
    partial class frmAgenciaTurno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgenciaTurno));
            this.grdAgencia = new DevExpress.XtraGrid.GridControl();
            this.grvAgencia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigoAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeleccionar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTurno = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAsociar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdAgenciaTurno = new DevExpress.XtraGrid.GridControl();
            this.grvAgenciaTurno = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CodigoTurno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTurno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNomAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Desvincular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTurno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenciaTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgenciaTurno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAgencia
            // 
            this.grdAgencia.Location = new System.Drawing.Point(12, 91);
            this.grdAgencia.MainView = this.grvAgencia;
            this.grdAgencia.Name = "grdAgencia";
            this.grdAgencia.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdAgencia.Size = new System.Drawing.Size(635, 136);
            this.grdAgencia.TabIndex = 0;
            this.grdAgencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAgencia});
            // 
            // grvAgencia
            // 
            this.grvAgencia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigoAgencia,
            this.colAgencia,
            this.colSeleccionar,
            this.colID});
            this.grvAgencia.GridControl = this.grdAgencia;
            this.grvAgencia.Name = "grvAgencia";
            this.grvAgencia.OptionsView.ShowAutoFilterRow = true;
            this.grvAgencia.OptionsView.ShowGroupPanel = false;
            this.grvAgencia.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvAgencia_CellValueChanging);
            // 
            // colCodigoAgencia
            // 
            this.colCodigoAgencia.Caption = "Código";
            this.colCodigoAgencia.FieldName = "sCodigoAgencia";
            this.colCodigoAgencia.Name = "colCodigoAgencia";
            this.colCodigoAgencia.OptionsColumn.ReadOnly = true;
            this.colCodigoAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodigoAgencia.Visible = true;
            this.colCodigoAgencia.VisibleIndex = 0;
            this.colCodigoAgencia.Width = 137;
            // 
            // colAgencia
            // 
            this.colAgencia.Caption = "Agencia";
            this.colAgencia.FieldName = "sDescripcion";
            this.colAgencia.Name = "colAgencia";
            this.colAgencia.OptionsColumn.ReadOnly = true;
            this.colAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAgencia.Visible = true;
            this.colAgencia.VisibleIndex = 1;
            this.colAgencia.Width = 393;
            // 
            // colSeleccionar
            // 
            this.colSeleccionar.Caption = "Selección";
            this.colSeleccionar.FieldName = "SeleccionGrafica";
            this.colSeleccionar.Name = "colSeleccionar";
            this.colSeleccionar.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colSeleccionar.Visible = true;
            this.colSeleccionar.VisibleIndex = 2;
            this.colSeleccionar.Width = 87;
            // 
            // colID
            // 
            this.colID.Caption = "IdAgencia";
            this.colID.FieldName = "Id";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 17);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Lista de turnos";
            // 
            // cboTurno
            // 
            this.cboTurno.Location = new System.Drawing.Point(12, 36);
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTurno.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTurno", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTurno", "Turno")});
            this.cboTurno.Properties.NullText = "Seleccione un horario";
            this.cboTurno.Properties.ShowFooter = false;
            this.cboTurno.Properties.ShowHeader = false;
            this.cboTurno.Size = new System.Drawing.Size(284, 20);
            this.cboTurno.TabIndex = 2;
            this.cboTurno.EditValueChanged += new System.EventHandler(this.cboTurno_EditValueChanged);
            // 
            // btnAsociar
            // 
            this.btnAsociar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAsociar.ImageOptions.ImageIndex = 0;
            this.btnAsociar.ImageOptions.ImageList = this.imageCollection1;
            this.btnAsociar.Location = new System.Drawing.Point(315, 27);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(104, 37);
            this.btnAsociar.TabIndex = 4;
            this.btnAsociar.Text = "&Asociar";
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.tablerelationship32, "tablerelationship32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "tablerelationship32");
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 72);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Lista de agencias:";
            // 
            // grdAgenciaTurno
            // 
            this.grdAgenciaTurno.Location = new System.Drawing.Point(12, 247);
            this.grdAgenciaTurno.MainView = this.grvAgenciaTurno;
            this.grdAgenciaTurno.Name = "grdAgenciaTurno";
            this.grdAgenciaTurno.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grdAgenciaTurno.Size = new System.Drawing.Size(635, 383);
            this.grdAgenciaTurno.TabIndex = 0;
            this.grdAgenciaTurno.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAgenciaTurno});
            // 
            // grvAgenciaTurno
            // 
            this.grvAgenciaTurno.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.CodigoTurno,
            this.colTurno,
            this.colCodAgencia,
            this.colNomAgencia,
            this.Desvincular});
            this.grvAgenciaTurno.GridControl = this.grdAgenciaTurno;
            this.grvAgenciaTurno.GroupCount = 1;
            this.grvAgenciaTurno.Name = "grvAgenciaTurno";
            this.grvAgenciaTurno.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTurno, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // CodigoTurno
            // 
            this.CodigoTurno.Caption = "Código turno";
            this.CodigoTurno.FieldName = "IdTurno";
            this.CodigoTurno.Name = "CodigoTurno";
            this.CodigoTurno.OptionsColumn.ReadOnly = true;
            this.CodigoTurno.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // colTurno
            // 
            this.colTurno.Caption = "Turno";
            this.colTurno.FieldName = "sTurno";
            this.colTurno.Name = "colTurno";
            this.colTurno.OptionsColumn.ReadOnly = true;
            this.colTurno.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTurno.Visible = true;
            this.colTurno.VisibleIndex = 0;
            this.colTurno.Width = 205;
            // 
            // colCodAgencia
            // 
            this.colCodAgencia.Caption = "Código agencia";
            this.colCodAgencia.FieldName = "sCodigoAgencia";
            this.colCodAgencia.Name = "colCodAgencia";
            this.colCodAgencia.OptionsColumn.ReadOnly = true;
            this.colCodAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodAgencia.Visible = true;
            this.colCodAgencia.VisibleIndex = 0;
            this.colCodAgencia.Width = 117;
            // 
            // colNomAgencia
            // 
            this.colNomAgencia.Caption = "Agencia";
            this.colNomAgencia.FieldName = "sDescripcion";
            this.colNomAgencia.Name = "colNomAgencia";
            this.colNomAgencia.OptionsColumn.ReadOnly = true;
            this.colNomAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNomAgencia.Visible = true;
            this.colNomAgencia.VisibleIndex = 1;
            this.colNomAgencia.Width = 295;
            // 
            // Desvincular
            // 
            this.Desvincular.Caption = "Desvincular";
            this.Desvincular.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.Desvincular.Name = "Desvincular";
            this.Desvincular.OptionsColumn.ReadOnly = true;
            this.Desvincular.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.Desvincular.Visible = true;
            this.Desvincular.VisibleIndex = 2;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Caption = "Desvincular";
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Desvincular";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // frmAgenciaTurno
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 642);
            this.Controls.Add(this.btnAsociar);
            this.Controls.Add(this.cboTurno);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdAgenciaTurno);
            this.Controls.Add(this.grdAgencia);
            this.Name = "frmAgenciaTurno";
            this.Text = "Agencias - Turnos";
            this.Load += new System.EventHandler(this.frmAgenciaTurno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAgencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTurno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenciaTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgenciaTurno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAgencia;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAgencia;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboTurno;
        private DevExpress.XtraEditors.SimpleButton btnAsociar;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grdAgenciaTurno;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAgenciaTurno;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccionar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn CodigoTurno;
        private DevExpress.XtraGrid.Columns.GridColumn colTurno;
        private DevExpress.XtraGrid.Columns.GridColumn colCodAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colNomAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn Desvincular;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}