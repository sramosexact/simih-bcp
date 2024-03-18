namespace ExpedicionInternaPC
{
    partial class frmBandejaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBandejaUsuario));
            this.lblBandeja = new DevExpress.XtraEditors.LabelControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.grdNoVinculados = new DevExpress.XtraGrid.GridControl();
            this.grvNoVinculados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdUsuarioNoVinculado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatriculaNoVinculado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuarioNoVinculadoDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVincular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lnkVincular = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grdVinculados = new DevExpress.XtraGrid.GridControl();
            this.grvVinculados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdVinculado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMatricula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesvincular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lnkDesvincular = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblUbicacion = new DevExpress.XtraEditors.LabelControl();
            this.lblTipo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoVinculados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNoVinculados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkVincular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVinculados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVinculados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDesvincular)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBandeja
            // 
            this.lblBandeja.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.lblBandeja.Appearance.BackColor2 = System.Drawing.Color.SlateGray;
            this.lblBandeja.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblBandeja.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblBandeja.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBandeja.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBandeja.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBandeja.Location = new System.Drawing.Point(12, 17);
            this.lblBandeja.Name = "lblBandeja";
            this.lblBandeja.Size = new System.Drawing.Size(565, 35);
            this.lblBandeja.TabIndex = 1;
            this.lblBandeja.Text = "Bandeja : {0}";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.linkadd32, "linkadd32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "linkadd32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.linkdelete32, "linkdelete32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "linkdelete32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.cancel32, "cancel32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "cancel32");
            // 
            // grdNoVinculados
            // 
            this.grdNoVinculados.Location = new System.Drawing.Point(9, 160);
            this.grdNoVinculados.MainView = this.grvNoVinculados;
            this.grdNoVinculados.Name = "grdNoVinculados";
            this.grdNoVinculados.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lnkVincular});
            this.grdNoVinculados.Size = new System.Drawing.Size(577, 233);
            this.grdNoVinculados.TabIndex = 2;
            this.grdNoVinculados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvNoVinculados});
            // 
            // grvNoVinculados
            // 
            this.grvNoVinculados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdUsuarioNoVinculado,
            this.colMatriculaNoVinculado,
            this.colUsuarioNoVinculadoDescripcion,
            this.colVincular});
            this.grvNoVinculados.GridControl = this.grdNoVinculados;
            this.grvNoVinculados.Name = "grvNoVinculados";
            this.grvNoVinculados.OptionsView.ShowGroupPanel = false;
            // 
            // colIdUsuarioNoVinculado
            // 
            this.colIdUsuarioNoVinculado.Caption = "Id";
            this.colIdUsuarioNoVinculado.FieldName = "ID";
            this.colIdUsuarioNoVinculado.Name = "colIdUsuarioNoVinculado";
            this.colIdUsuarioNoVinculado.OptionsColumn.ReadOnly = true;
            // 
            // colMatriculaNoVinculado
            // 
            this.colMatriculaNoVinculado.Caption = "Matricula";
            this.colMatriculaNoVinculado.FieldName = "sMatricula";
            this.colMatriculaNoVinculado.MaxWidth = 150;
            this.colMatriculaNoVinculado.MinWidth = 150;
            this.colMatriculaNoVinculado.Name = "colMatriculaNoVinculado";
            this.colMatriculaNoVinculado.OptionsColumn.ReadOnly = true;
            this.colMatriculaNoVinculado.Visible = true;
            this.colMatriculaNoVinculado.VisibleIndex = 0;
            this.colMatriculaNoVinculado.Width = 150;
            // 
            // colUsuarioNoVinculadoDescripcion
            // 
            this.colUsuarioNoVinculadoDescripcion.Caption = "Usuario";
            this.colUsuarioNoVinculadoDescripcion.FieldName = "Descripcion";
            this.colUsuarioNoVinculadoDescripcion.Name = "colUsuarioNoVinculadoDescripcion";
            this.colUsuarioNoVinculadoDescripcion.OptionsColumn.ReadOnly = true;
            this.colUsuarioNoVinculadoDescripcion.Visible = true;
            this.colUsuarioNoVinculadoDescripcion.VisibleIndex = 1;
            // 
            // colVincular
            // 
            this.colVincular.Caption = "Vincular";
            this.colVincular.ColumnEdit = this.lnkVincular;
            this.colVincular.FieldName = "Estado";
            this.colVincular.MaxWidth = 60;
            this.colVincular.MinWidth = 60;
            this.colVincular.Name = "colVincular";
            this.colVincular.OptionsColumn.ReadOnly = true;
            this.colVincular.Visible = true;
            this.colVincular.VisibleIndex = 2;
            this.colVincular.Width = 60;
            // 
            // lnkVincular
            // 
            this.lnkVincular.AutoHeight = false;
            this.lnkVincular.Name = "lnkVincular";
            this.lnkVincular.NullText = "Vincular";
            this.lnkVincular.Click += new System.EventHandler(this.lnkVincular_Click);
            // 
            // grdVinculados
            // 
            this.grdVinculados.Location = new System.Drawing.Point(9, 399);
            this.grdVinculados.MainView = this.grvVinculados;
            this.grdVinculados.Name = "grdVinculados";
            this.grdVinculados.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.lnkDesvincular});
            this.grdVinculados.Size = new System.Drawing.Size(577, 267);
            this.grdVinculados.TabIndex = 3;
            this.grdVinculados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVinculados});
            // 
            // grvVinculados
            // 
            this.grvVinculados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdVinculado,
            this.colMatricula,
            this.colUsuario,
            this.colDesvincular});
            this.grvVinculados.GridControl = this.grdVinculados;
            this.grvVinculados.Name = "grvVinculados";
            this.grvVinculados.OptionsView.ShowGroupPanel = false;
            // 
            // colIdVinculado
            // 
            this.colIdVinculado.Caption = "ID";
            this.colIdVinculado.FieldName = "ID";
            this.colIdVinculado.Name = "colIdVinculado";
            this.colIdVinculado.OptionsColumn.ReadOnly = true;
            // 
            // colMatricula
            // 
            this.colMatricula.Caption = "Matricula";
            this.colMatricula.FieldName = "sMatricula";
            this.colMatricula.MaxWidth = 150;
            this.colMatricula.MinWidth = 150;
            this.colMatricula.Name = "colMatricula";
            this.colMatricula.OptionsColumn.ReadOnly = true;
            this.colMatricula.Visible = true;
            this.colMatricula.VisibleIndex = 0;
            this.colMatricula.Width = 150;
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.FieldName = "Descripcion";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.OptionsColumn.ReadOnly = true;
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 1;
            // 
            // colDesvincular
            // 
            this.colDesvincular.Caption = "Desvincular";
            this.colDesvincular.ColumnEdit = this.lnkDesvincular;
            this.colDesvincular.FieldName = "Estado";
            this.colDesvincular.MaxWidth = 60;
            this.colDesvincular.MinWidth = 60;
            this.colDesvincular.Name = "colDesvincular";
            this.colDesvincular.OptionsColumn.ReadOnly = true;
            this.colDesvincular.Visible = true;
            this.colDesvincular.VisibleIndex = 2;
            this.colDesvincular.Width = 60;
            // 
            // lnkDesvincular
            // 
            this.lnkDesvincular.AutoHeight = false;
            this.lnkDesvincular.Name = "lnkDesvincular";
            this.lnkDesvincular.NullText = "Desvincular";
            this.lnkDesvincular.Click += new System.EventHandler(this.lnkDesvincular_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(78, 132);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtUsuario.Size = new System.Drawing.Size(326, 22);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(10, 135);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 16);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Usuario :";
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.lblUbicacion.Appearance.BackColor2 = System.Drawing.Color.SlateGray;
            this.lblUbicacion.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblUbicacion.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblUbicacion.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblUbicacion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUbicacion.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblUbicacion.Location = new System.Drawing.Point(12, 58);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(565, 29);
            this.lblUbicacion.TabIndex = 1;
            this.lblUbicacion.Text = "Ubicación : {0}";
            // 
            // lblTipo
            // 
            this.lblTipo.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.lblTipo.Appearance.BackColor2 = System.Drawing.Color.SlateGray;
            this.lblTipo.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblTipo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTipo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTipo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTipo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblTipo.Location = new System.Drawing.Point(12, 93);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(565, 29);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo : {0} | Estado : {1}";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.labelControl3.Appearance.BackColor2 = System.Drawing.Color.SlateGray;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl3.Location = new System.Drawing.Point(9, 12);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(577, 115);
            this.labelControl3.TabIndex = 1;
            // 
            // frmBandejaUsuario
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 669);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.grdVinculados);
            this.Controls.Add(this.grdNoVinculados);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.lblBandeja);
            this.Controls.Add(this.labelControl3);
            this.Name = "frmBandejaUsuario";
            this.Text = "Vincular/desvincular usuarios";
            this.Load += new System.EventHandler(this.frmBandejaUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNoVinculados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvNoVinculados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkVincular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVinculados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVinculados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDesvincular)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblBandeja;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.GridControl grdNoVinculados;
        private DevExpress.XtraGrid.Views.Grid.GridView grvNoVinculados;
        private DevExpress.XtraGrid.GridControl grdVinculados;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVinculados;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colMatriculaNoVinculado;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuarioNoVinculadoDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colVincular;
        private DevExpress.XtraGrid.Columns.GridColumn colIdUsuarioNoVinculado;
        private DevExpress.XtraGrid.Columns.GridColumn colIdVinculado;
        private DevExpress.XtraGrid.Columns.GridColumn colMatricula;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colDesvincular;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit lnkVincular;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit lnkDesvincular;
        private DevExpress.XtraEditors.LabelControl lblUbicacion;
        private DevExpress.XtraEditors.LabelControl lblTipo;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}