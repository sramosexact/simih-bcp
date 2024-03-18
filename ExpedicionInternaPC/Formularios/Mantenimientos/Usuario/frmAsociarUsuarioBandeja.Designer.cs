namespace ExpedicionInternaPC
{
    partial class frmAsociarUsuarioBandeja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsociarUsuarioBandeja));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.grdBandejasNoVinculadas = new DevExpress.XtraGrid.GridControl();
            this.grvBandejasNoVinculadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUbicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoBandeja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVincular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkVincular = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblUsuario = new DevExpress.XtraEditors.LabelControl();
            this.lblMatricula = new DevExpress.XtraEditors.LabelControl();
            this.grdBandejasVinculadas = new DevExpress.XtraGrid.GridControl();
            this.grvBandejasVinculadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUbicacion2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoBandeja2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesvincular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkDesvincular = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.txtBandeja = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejasNoVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejasNoVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkVincular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejasVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejasVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDesvincular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBandeja.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.linkadd32, "linkadd32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "linkadd32");
            // 
            // grdBandejasNoVinculadas
            // 
            this.grdBandejasNoVinculadas.Location = new System.Drawing.Point(9, 165);
            this.grdBandejasNoVinculadas.MainView = this.grvBandejasNoVinculadas;
            this.grdBandejasNoVinculadas.Name = "grdBandejasNoVinculadas";
            this.grdBandejasNoVinculadas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkVincular});
            this.grdBandejasNoVinculadas.Size = new System.Drawing.Size(577, 227);
            this.grdBandejasNoVinculadas.TabIndex = 1;
            this.grdBandejasNoVinculadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBandejasNoVinculadas});
            // 
            // grvBandejasNoVinculadas
            // 
            this.grvBandejasNoVinculadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsDescripcion,
            this.colUbicacion,
            this.colTipoBandeja,
            this.colVincular});
            this.grvBandejasNoVinculadas.GridControl = this.grdBandejasNoVinculadas;
            this.grvBandejasNoVinculadas.Name = "grvBandejasNoVinculadas";
            this.grvBandejasNoVinculadas.OptionsView.ShowAutoFilterRow = true;
            this.grvBandejasNoVinculadas.OptionsView.ShowFooter = true;
            this.grvBandejasNoVinculadas.OptionsView.ShowGroupPanel = false;
            // 
            // colsDescripcion
            // 
            this.colsDescripcion.Caption = "Nombre";
            this.colsDescripcion.FieldName = "sDescripcion";
            this.colsDescripcion.Name = "colsDescripcion";
            this.colsDescripcion.OptionsColumn.ReadOnly = true;
            this.colsDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colsDescripcion.Visible = true;
            this.colsDescripcion.VisibleIndex = 0;
            this.colsDescripcion.Width = 211;
            // 
            // colUbicacion
            // 
            this.colUbicacion.Caption = "Ubicación";
            this.colUbicacion.FieldName = "Ubicacion";
            this.colUbicacion.Name = "colUbicacion";
            this.colUbicacion.OptionsColumn.ReadOnly = true;
            this.colUbicacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUbicacion.Visible = true;
            this.colUbicacion.VisibleIndex = 1;
            this.colUbicacion.Width = 202;
            // 
            // colTipoBandeja
            // 
            this.colTipoBandeja.Caption = "Tipo de bandeja";
            this.colTipoBandeja.FieldName = "tipoCasilla";
            this.colTipoBandeja.Name = "colTipoBandeja";
            this.colTipoBandeja.Visible = true;
            this.colTipoBandeja.VisibleIndex = 2;
            this.colTipoBandeja.Width = 88;
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
            // grdBandejasVinculadas
            // 
            this.grdBandejasVinculadas.Location = new System.Drawing.Point(9, 418);
            this.grdBandejasVinculadas.MainView = this.grvBandejasVinculadas;
            this.grdBandejasVinculadas.Name = "grdBandejasVinculadas";
            this.grdBandejasVinculadas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkDesvincular});
            this.grdBandejasVinculadas.Size = new System.Drawing.Size(577, 227);
            this.grdBandejasVinculadas.TabIndex = 5;
            this.grdBandejasVinculadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBandejasVinculadas});
            // 
            // grvBandejasVinculadas
            // 
            this.grvBandejasVinculadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombre,
            this.colUbicacion2,
            this.colTipoBandeja2,
            this.colDesvincular});
            this.grvBandejasVinculadas.GridControl = this.grdBandejasVinculadas;
            this.grvBandejasVinculadas.Name = "grvBandejasVinculadas";
            this.grvBandejasVinculadas.OptionsView.ShowAutoFilterRow = true;
            this.grvBandejasVinculadas.OptionsView.ShowFooter = true;
            this.grvBandejasVinculadas.OptionsView.ShowGroupPanel = false;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "sDescripcion";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.ReadOnly = true;
            this.colNombre.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 0;
            this.colNombre.Width = 211;
            // 
            // colUbicacion2
            // 
            this.colUbicacion2.Caption = "Ubicación";
            this.colUbicacion2.FieldName = "Ubicacion";
            this.colUbicacion2.Name = "colUbicacion2";
            this.colUbicacion2.OptionsColumn.ReadOnly = true;
            this.colUbicacion2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colUbicacion2.Visible = true;
            this.colUbicacion2.VisibleIndex = 1;
            this.colUbicacion2.Width = 202;
            // 
            // colTipoBandeja2
            // 
            this.colTipoBandeja2.Caption = "Tipo de Bandeja";
            this.colTipoBandeja2.FieldName = "tipoCasilla";
            this.colTipoBandeja2.Name = "colTipoBandeja2";
            this.colTipoBandeja2.Visible = true;
            this.colTipoBandeja2.VisibleIndex = 2;
            this.colTipoBandeja2.Width = 88;
            // 
            // colDesvincular
            // 
            this.colDesvincular.Caption = "Desvincular";
            this.colDesvincular.ColumnEdit = this.linkDesvincular;
            this.colDesvincular.Name = "colDesvincular";
            this.colDesvincular.Visible = true;
            this.colDesvincular.VisibleIndex = 3;
            this.colDesvincular.Width = 58;
            // 
            // linkDesvincular
            // 
            this.linkDesvincular.AutoHeight = false;
            this.linkDesvincular.Name = "linkDesvincular";
            this.linkDesvincular.NullText = "Desvincular";
            this.linkDesvincular.Click += new System.EventHandler(this.linkDesvincular_Click);
            // 
            // txtBandeja
            // 
            this.txtBandeja.Location = new System.Drawing.Point(72, 126);
            this.txtBandeja.Name = "txtBandeja";
            this.txtBandeja.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBandeja.Properties.Appearance.Options.UseFont = true;
            this.txtBandeja.Size = new System.Drawing.Size(274, 22);
            this.txtBandeja.TabIndex = 6;
            this.txtBandeja.EditValueChanged += new System.EventHandler(this.txtBandeja_EditValueChanged);
            this.txtBandeja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBandeja_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(15, 129);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Bandeja:";
            // 
            // frmAsociarUsuarioBandeja
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 669);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtBandeja);
            this.Controls.Add(this.grdBandejasVinculadas);
            this.Controls.Add(this.lblMatricula);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdBandejasNoVinculadas);
            this.Name = "frmAsociarUsuarioBandeja";
            this.Text = "Vincular bandeja a usuario";
            this.Load += new System.EventHandler(this.frmAsociarUsuarioBandeja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejasNoVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejasNoVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkVincular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejasVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejasVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkDesvincular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBandeja.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdBandejasNoVinculadas;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBandejasNoVinculadas;
        private DevExpress.XtraGrid.Columns.GridColumn colsDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colUbicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colVincular;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblUsuario;
        private DevExpress.XtraEditors.LabelControl lblMatricula;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoBandeja;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkVincular;
        private DevExpress.XtraGrid.GridControl grdBandejasVinculadas;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBandejasVinculadas;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colUbicacion2;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoBandeja2;
        private DevExpress.XtraGrid.Columns.GridColumn colDesvincular;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkDesvincular;
        private DevExpress.XtraEditors.TextEdit txtBandeja;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}