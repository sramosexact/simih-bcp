namespace ExpedicionInternaPC.Formularios.Mantenimientos
{
    partial class frmEditarCamposDinamicos
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
            this.chkRequiereDigitalizacion = new DevExpress.XtraEditors.CheckEdit();
            this.txtCampo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkOpcional = new DevExpress.XtraEditors.CheckEdit();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.grdCampos = new DevExpress.XtraGrid.GridControl();
            this.grvCampos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCampo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdentificador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOpcional = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.lblTipoDocumento = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequiereDigitalizacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCampo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpcional.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCampos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCampos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkRequiereDigitalizacion
            // 
            this.chkRequiereDigitalizacion.Location = new System.Drawing.Point(12, 63);
            this.chkRequiereDigitalizacion.Name = "chkRequiereDigitalizacion";
            this.chkRequiereDigitalizacion.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.chkRequiereDigitalizacion.Properties.Appearance.Options.UseFont = true;
            this.chkRequiereDigitalizacion.Properties.Caption = "Requiere digitalización";
            this.chkRequiereDigitalizacion.Size = new System.Drawing.Size(220, 23);
            this.chkRequiereDigitalizacion.TabIndex = 0;
            this.chkRequiereDigitalizacion.CheckedChanged += new System.EventHandler(this.chkRequiereDigitalizacion_CheckedChanged);
            // 
            // txtCampo
            // 
            this.txtCampo.Location = new System.Drawing.Point(67, 101);
            this.txtCampo.Name = "txtCampo";
            this.txtCampo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtCampo.Properties.Appearance.Options.UseFont = true;
            this.txtCampo.Size = new System.Drawing.Size(184, 22);
            this.txtCampo.TabIndex = 2;
            this.txtCampo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCampo_KeyDown);
            this.txtCampo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCampo_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 104);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Campo";
            // 
            // chkOpcional
            // 
            this.chkOpcional.Location = new System.Drawing.Point(270, 102);
            this.chkOpcional.Name = "chkOpcional";
            this.chkOpcional.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.chkOpcional.Properties.Appearance.Options.UseFont = true;
            this.chkOpcional.Properties.Caption = "Opcional";
            this.chkOpcional.Size = new System.Drawing.Size(75, 20);
            this.chkOpcional.TabIndex = 4;
            this.chkOpcional.CheckedChanged += new System.EventHandler(this.chkOpcional_CheckedChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAgregar.Location = new System.Drawing.Point(361, 98);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(90, 29);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // grdCampos
            // 
            this.grdCampos.Location = new System.Drawing.Point(12, 150);
            this.grdCampos.MainView = this.grvCampos;
            this.grdCampos.Name = "grdCampos";
            this.grdCampos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grdCampos.Size = new System.Drawing.Size(518, 291);
            this.grdCampos.TabIndex = 6;
            this.grdCampos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvCampos});
            // 
            // grvCampos
            // 
            this.grvCampos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCampo,
            this.colIdentificador,
            this.colOpcional,
            this.colEstado});
            this.grvCampos.GridControl = this.grdCampos;
            this.grvCampos.Name = "grvCampos";
            this.grvCampos.OptionsView.ShowGroupPanel = false;
            // 
            // colCampo
            // 
            this.colCampo.Caption = "Campo";
            this.colCampo.FieldName = "sDescripcion";
            this.colCampo.Name = "colCampo";
            this.colCampo.OptionsColumn.AllowEdit = false;
            this.colCampo.OptionsColumn.ReadOnly = true;
            this.colCampo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colCampo.Visible = true;
            this.colCampo.VisibleIndex = 0;
            // 
            // colIdentificador
            // 
            this.colIdentificador.Caption = "Identificador";
            this.colIdentificador.FieldName = "sIdentificador";
            this.colIdentificador.Name = "colIdentificador";
            this.colIdentificador.OptionsColumn.AllowEdit = false;
            this.colIdentificador.OptionsColumn.ReadOnly = true;
            this.colIdentificador.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colIdentificador.Visible = true;
            this.colIdentificador.VisibleIndex = 1;
            // 
            // colOpcional
            // 
            this.colOpcional.Caption = "Opcional";
            this.colOpcional.FieldName = "sOpcional";
            this.colOpcional.Name = "colOpcional";
            this.colOpcional.OptionsColumn.AllowEdit = false;
            this.colOpcional.OptionsColumn.ReadOnly = true;
            this.colOpcional.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colOpcional.Visible = true;
            this.colOpcional.VisibleIndex = 2;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.colEstado.FieldName = "sActivo";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.ReadOnly = true;
            this.colEstado.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 3;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(194, 447);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(151, 36);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTipoDocumento
            // 
            this.lblTipoDocumento.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.lblTipoDocumento.Appearance.Options.UseFont = true;
            this.lblTipoDocumento.Appearance.Options.UseTextOptions = true;
            this.lblTipoDocumento.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTipoDocumento.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTipoDocumento.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTipoDocumento.Location = new System.Drawing.Point(-1, 21);
            this.lblTipoDocumento.Name = "lblTipoDocumento";
            this.lblTipoDocumento.Size = new System.Drawing.Size(544, 25);
            this.lblTipoDocumento.TabIndex = 8;
            this.lblTipoDocumento.Text = "CARTAS GOED DFDFDFD FDS";
            // 
            // frmEditarCamposDinamicos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 488);
            this.Controls.Add(this.lblTipoDocumento);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.grdCampos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.chkOpcional);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtCampo);
            this.Controls.Add(this.chkRequiereDigitalizacion);
            this.Name = "frmEditarCamposDinamicos";
            this.Text = "Mantenimiento de campos";
            this.Load += new System.EventHandler(this.frmEditarCamposDinamicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkRequiereDigitalizacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCampo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOpcional.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCampos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvCampos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkRequiereDigitalizacion;
        private DevExpress.XtraEditors.TextEdit txtCampo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkOpcional;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraGrid.GridControl grdCampos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvCampos;
        private DevExpress.XtraGrid.Columns.GridColumn colCampo;
        private DevExpress.XtraGrid.Columns.GridColumn colIdentificador;
        private DevExpress.XtraGrid.Columns.GridColumn colOpcional;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.LabelControl lblTipoDocumento;
    }
}