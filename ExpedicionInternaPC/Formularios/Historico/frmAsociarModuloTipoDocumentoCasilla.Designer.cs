namespace ExpedicionInternaPC.Formularios.Mantenimientos
{
    partial class frmAsociarModuloTipoDocumentoCasilla
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
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtBandeja = new DevExpress.XtraEditors.TextEdit();
            this.lblModulo = new DevExpress.XtraEditors.LabelControl();
            this.lblTipoDocumento = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.colVincular = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBandejasNoVinculadas = new DevExpress.XtraGrid.GridControl();
            this.grvBandejasNoVinculadas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colsDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUbicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoBandeja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkVincular = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBandeja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejasNoVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejasNoVinculadas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkVincular)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(58, 125);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Bandeja:";
            // 
            // txtBandeja
            // 
            this.txtBandeja.Location = new System.Drawing.Point(115, 122);
            this.txtBandeja.Name = "txtBandeja";
            this.txtBandeja.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBandeja.Properties.Appearance.Options.UseFont = true;
            this.txtBandeja.Size = new System.Drawing.Size(274, 22);
            this.txtBandeja.TabIndex = 8;
            this.txtBandeja.EditValueChanged += new System.EventHandler(this.txtBandeja_EditValueChanged);
            this.txtBandeja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBandeja_KeyPress);
            // 
            // lblModulo
            // 
            this.lblModulo.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.lblModulo.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModulo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblModulo.Appearance.Options.UseBackColor = true;
            this.lblModulo.Appearance.Options.UseFont = true;
            this.lblModulo.Appearance.Options.UseForeColor = true;
            this.lblModulo.Appearance.Options.UseTextOptions = true;
            this.lblModulo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblModulo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblModulo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblModulo.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lblModulo.Location = new System.Drawing.Point(18, 60);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(565, 29);
            this.lblModulo.TabIndex = 12;
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.lblTipoDocumento.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoDocumento.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTipoDocumento.Appearance.Options.UseBackColor = true;
            this.lblTipoDocumento.Appearance.Options.UseFont = true;
            this.lblTipoDocumento.Appearance.Options.UseForeColor = true;
            this.lblTipoDocumento.Appearance.Options.UseTextOptions = true;
            this.lblTipoDocumento.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTipoDocumento.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTipoDocumento.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblTipoDocumento.LineLocation = DevExpress.XtraEditors.LineLocation.Center;
            this.lblTipoDocumento.Location = new System.Drawing.Point(18, 17);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(565, 35);
            this.lblTipoDocumento.TabIndex = 11;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.SlateGray;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(577, 86);
            this.labelControl1.TabIndex = 10;
            // 
            // colVincular
            // 
            this.colVincular.Caption = "Vincular";
            this.colVincular.Name = "colVincular";
            this.colVincular.Width = 58;
            // 
            // grdBandejasNoVinculadas
            // 
            this.grdBandejasNoVinculadas.Location = new System.Drawing.Point(12, 152);
            this.grdBandejasNoVinculadas.MainView = this.grvBandejasNoVinculadas;
            this.grdBandejasNoVinculadas.Name = "grdBandejasNoVinculadas";
            this.grdBandejasNoVinculadas.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkVincular});
            this.grdBandejasNoVinculadas.Size = new System.Drawing.Size(577, 227);
            this.grdBandejasNoVinculadas.TabIndex = 13;
            this.grdBandejasNoVinculadas.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBandejasNoVinculadas});
            // 
            // grvBandejasNoVinculadas
            // 
            this.grvBandejasNoVinculadas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colsDescripcion,
            this.colUbicacion,
            this.colTipoBandeja,
            this.gridColumn1});
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
            this.colTipoBandeja.Caption = "Tipo de Bandeja";
            this.colTipoBandeja.FieldName = "tipoCasilla";
            this.colTipoBandeja.Name = "colTipoBandeja";
            this.colTipoBandeja.Visible = true;
            this.colTipoBandeja.VisibleIndex = 2;
            this.colTipoBandeja.Width = 88;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Vincular";
            this.gridColumn1.ColumnEdit = this.linkVincular;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 58;
            // 
            // linkVincular
            // 
            this.linkVincular.AutoHeight = false;
            this.linkVincular.Name = "linkVincular";
            this.linkVincular.NullText = "Vincular";
            this.linkVincular.Click += new System.EventHandler(this.linkVincular_Click);
            // 
            // frmAsociarModuloTipoDocumentoCasilla
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 391);
            this.Controls.Add(this.grdBandejasNoVinculadas);
            this.Controls.Add(this.lblModulo);
            this.Controls.Add(this.lblTipoDocumento);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtBandeja);
            this.Name = "frmAsociarModuloTipoDocumentoCasilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Asociar bandeja a tipo de documento";
            this.Load += new System.EventHandler(this.frmAsociarModuloTipoDocumentoCasilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtBandeja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBandejasNoVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBandejasNoVinculadas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkVincular)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtBandeja;
        private DevExpress.XtraEditors.LabelControl lblModulo;
        private DevExpress.XtraEditors.LabelControl lblTipoDocumento;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colVincular;
        private DevExpress.XtraGrid.GridControl grdBandejasNoVinculadas;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBandejasNoVinculadas;
        private DevExpress.XtraGrid.Columns.GridColumn colsDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colUbicacion;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoBandeja;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkVincular;
    }
}