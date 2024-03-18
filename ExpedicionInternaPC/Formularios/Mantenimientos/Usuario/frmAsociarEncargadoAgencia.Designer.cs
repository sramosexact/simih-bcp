namespace ExpedicionInternaPC
{
    partial class frmAsociarEncargadoAgencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsociarEncargadoAgencia));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.grdAgenciasNoVinculadas = new DevExpress.XtraGrid.GridControl();
            this.grvAgenciasNoVinculadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigoAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDireccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVincular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkVincular = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblUsuario = new DevExpress.XtraEditors.LabelControl();
            this.lblMatricula = new DevExpress.XtraEditors.LabelControl();
            this.txtAgencia = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdAgenciasVinculadas = new DevExpress.XtraGrid.GridControl();
            this.grvAgenciasVinculadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigoAgenciaVinculada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAgenciaVinculada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDireccionVinculada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesVincularVinculada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkDesvincular = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenciasNoVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgenciasNoVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkVincular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenciasVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgenciasVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDesvincular)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.linkadd32, "linkadd32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "linkadd32");
            // 
            // grdAgenciasNoVinculadas
            // 
            this.grdAgenciasNoVinculadas.Location = new System.Drawing.Point(9, 165);
            this.grdAgenciasNoVinculadas.MainView = this.grvAgenciasNoVinculadas;
            this.grdAgenciasNoVinculadas.Name = "grdAgenciasNoVinculadas";
            this.grdAgenciasNoVinculadas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkVincular});
            this.grdAgenciasNoVinculadas.Size = new System.Drawing.Size(577, 227);
            this.grdAgenciasNoVinculadas.TabIndex = 1;
            this.grdAgenciasNoVinculadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAgenciasNoVinculadas});
            // 
            // grvAgenciasNoVinculadas
            // 
            this.grvAgenciasNoVinculadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigoAgencia,
            this.colAgencia,
            this.colDireccion,
            this.colVincular});
            this.grvAgenciasNoVinculadas.GridControl = this.grdAgenciasNoVinculadas;
            this.grvAgenciasNoVinculadas.Name = "grvAgenciasNoVinculadas";
            this.grvAgenciasNoVinculadas.OptionsView.ShowAutoFilterRow = true;
            this.grvAgenciasNoVinculadas.OptionsView.ShowFooter = true;
            this.grvAgenciasNoVinculadas.OptionsView.ShowGroupPanel = false;
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
            this.colCodigoAgencia.Width = 211;
            // 
            // colAgencia
            // 
            this.colAgencia.Caption = "Nombre";
            this.colAgencia.FieldName = "sDescripcion";
            this.colAgencia.Name = "colAgencia";
            this.colAgencia.OptionsColumn.ReadOnly = true;
            this.colAgencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAgencia.Visible = true;
            this.colAgencia.VisibleIndex = 1;
            this.colAgencia.Width = 202;
            // 
            // colDireccion
            // 
            this.colDireccion.Caption = "Dirección";
            this.colDireccion.FieldName = "sDireccion";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.Visible = true;
            this.colDireccion.VisibleIndex = 2;
            this.colDireccion.Width = 88;
            // 
            // colVincular
            // 
            this.colVincular.Caption = "Vincular";
            this.colVincular.ColumnEdit = this.linkVincular;
            this.colVincular.Name = "colVincular";
            this.colVincular.Visible = true;
            this.colVincular.VisibleIndex = 3;
            this.colVincular.Width = 58;
            // 
            // linkVincular
            // 
            this.linkVincular.AutoHeight = false;
            this.linkVincular.Name = "linkVincular";
            this.linkVincular.NullText = "Vincular";
            this.linkVincular.Click += new System.EventHandler(this.linkVincular_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.Location = new System.Drawing.Point(9, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(577, 86);
            this.labelControl1.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.lblUsuario.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Appearance.Options.UseBackColor = true;
            this.lblUsuario.Appearance.Options.UseFont = true;
            this.lblUsuario.Appearance.Options.UseForeColor = true;
            this.lblUsuario.Appearance.Options.UseTextOptions = true;
            this.lblUsuario.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblUsuario.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUsuario.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblUsuario.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lblUsuario.Location = new System.Drawing.Point(15, 26);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(565, 35);
            this.lblUsuario.TabIndex = 3;
            // 
            // lblMatricula
            // 
            this.lblMatricula.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.lblMatricula.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatricula.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMatricula.Appearance.Options.UseBackColor = true;
            this.lblMatricula.Appearance.Options.UseFont = true;
            this.lblMatricula.Appearance.Options.UseForeColor = true;
            this.lblMatricula.Appearance.Options.UseTextOptions = true;
            this.lblMatricula.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMatricula.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMatricula.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblMatricula.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lblMatricula.Location = new System.Drawing.Point(15, 69);
            this.lblMatricula.Name = "lblMatricula";
            this.lblMatricula.Size = new System.Drawing.Size(565, 29);
            this.lblMatricula.TabIndex = 4;
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(72, 126);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAgencia.Properties.Appearance.Options.UseFont = true;
            this.txtAgencia.Size = new System.Drawing.Size(274, 22);
            this.txtAgencia.TabIndex = 6;
            this.txtAgencia.EditValueChanged += new System.EventHandler(this.txtBandeja_EditValueChanged);
            this.txtAgencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBandeja_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(15, 129);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 16);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Agencia:";
            // 
            // grdAgenciasVinculadas
            // 
            this.grdAgenciasVinculadas.Location = new System.Drawing.Point(9, 418);
            this.grdAgenciasVinculadas.MainView = this.grvAgenciasVinculadas;
            this.grdAgenciasVinculadas.Name = "grdAgenciasVinculadas";
            this.grdAgenciasVinculadas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkDesvincular});
            this.grdAgenciasVinculadas.Size = new System.Drawing.Size(577, 227);
            this.grdAgenciasVinculadas.TabIndex = 8;
            this.grdAgenciasVinculadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAgenciasVinculadas});
            // 
            // grvAgenciasVinculadas
            // 
            this.grvAgenciasVinculadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigoAgenciaVinculada,
            this.colAgenciaVinculada,
            this.colDireccionVinculada,
            this.colDesVincularVinculada});
            this.grvAgenciasVinculadas.GridControl = this.grdAgenciasVinculadas;
            this.grvAgenciasVinculadas.Name = "grvAgenciasVinculadas";
            this.grvAgenciasVinculadas.OptionsView.ShowAutoFilterRow = true;
            this.grvAgenciasVinculadas.OptionsView.ShowFooter = true;
            this.grvAgenciasVinculadas.OptionsView.ShowGroupPanel = false;
            // 
            // colCodigoAgenciaVinculada
            // 
            this.colCodigoAgenciaVinculada.Caption = "Código";
            this.colCodigoAgenciaVinculada.FieldName = "sCodigoAgencia";
            this.colCodigoAgenciaVinculada.Name = "colCodigoAgenciaVinculada";
            this.colCodigoAgenciaVinculada.OptionsColumn.ReadOnly = true;
            this.colCodigoAgenciaVinculada.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCodigoAgenciaVinculada.Visible = true;
            this.colCodigoAgenciaVinculada.VisibleIndex = 0;
            this.colCodigoAgenciaVinculada.Width = 211;
            // 
            // colAgenciaVinculada
            // 
            this.colAgenciaVinculada.Caption = "Nombre";
            this.colAgenciaVinculada.FieldName = "sDescripcion";
            this.colAgenciaVinculada.Name = "colAgenciaVinculada";
            this.colAgenciaVinculada.OptionsColumn.ReadOnly = true;
            this.colAgenciaVinculada.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colAgenciaVinculada.Visible = true;
            this.colAgenciaVinculada.VisibleIndex = 1;
            this.colAgenciaVinculada.Width = 202;
            // 
            // colDireccionVinculada
            // 
            this.colDireccionVinculada.Caption = "Dirección";
            this.colDireccionVinculada.FieldName = "sDireccion";
            this.colDireccionVinculada.Name = "colDireccionVinculada";
            this.colDireccionVinculada.Visible = true;
            this.colDireccionVinculada.VisibleIndex = 2;
            this.colDireccionVinculada.Width = 88;
            // 
            // colDesVincularVinculada
            // 
            this.colDesVincularVinculada.Caption = "Desvincular";
            this.colDesVincularVinculada.ColumnEdit = this.linkDesvincular;
            this.colDesVincularVinculada.Name = "colDesVincularVinculada";
            this.colDesVincularVinculada.Visible = true;
            this.colDesVincularVinculada.VisibleIndex = 3;
            this.colDesVincularVinculada.Width = 58;
            // 
            // linkDesvincular
            // 
            this.linkDesvincular.AutoHeight = false;
            this.linkDesvincular.Name = "linkDesvincular";
            this.linkDesvincular.NullText = "Desvincular";
            this.linkDesvincular.Click += new System.EventHandler(this.linkDesvincular_Click_1);
            // 
            // frmAsociarEncargadoAgencia
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 669);
            this.Controls.Add(this.grdAgenciasVinculadas);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdAgenciasNoVinculadas);
            this.Name = "frmAsociarEncargadoAgencia";
            this.Text = "Asociar Encargado Agencia";
            this.Load += new System.EventHandler(this.frmAsociarUsuarioBandeja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenciasNoVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgenciasNoVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkVincular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgenciasVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgenciasVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDesvincular)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAgenciasNoVinculadas;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAgenciasNoVinculadas;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn colVincular;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblUsuario;
        private DevExpress.XtraEditors.LabelControl lblMatricula;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccion;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkVincular;
        private DevExpress.XtraEditors.TextEdit txtAgencia;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grdAgenciasVinculadas;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAgenciasVinculadas;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoAgenciaVinculada;
        private DevExpress.XtraGrid.Columns.GridColumn colAgenciaVinculada;
        private DevExpress.XtraGrid.Columns.GridColumn colDireccionVinculada;
        private DevExpress.XtraGrid.Columns.GridColumn colDesVincularVinculada;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkDesvincular;
    }
}