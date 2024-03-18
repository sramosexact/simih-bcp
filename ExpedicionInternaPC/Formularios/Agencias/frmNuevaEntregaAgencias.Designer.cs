namespace ExpedicionInternaPC.Formularios.Expedicion
{
    partial class frmNuevaEntregaAgencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaEntregaAgencias));
            this.btnCrear = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.cboTurno = new DevExpress.XtraEditors.LookUpEdit();
            this.txtAgencia = new DevExpress.XtraEditors.TextEdit();
            this.lblTurno = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.grdAgencia = new DevExpress.XtraGrid.GridControl();
            this.grvAgencia = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.griCodigoAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.griAgencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.cboColaborador = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboPalomar = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTurno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboColaborador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPalomar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCrear.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnCrear.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCrear.Appearance.Options.UseBackColor = true;
            this.btnCrear.Appearance.Options.UseFont = true;
            this.btnCrear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCrear.ImageOptions.ImageIndex = 3;
            this.btnCrear.ImageOptions.ImageList = this.imageCollection1;
            this.btnCrear.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCrear.Location = new System.Drawing.Point(86, 514);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(120, 44);
            this.btnCrear.TabIndex = 8;
            this.btnCrear.Text = "&Crear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.cancel32, "cancel32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "cancel32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.saveas32, "saveas32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "saveas32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.CancelDev32, "CancelDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "CancelDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 3);
            this.imageCollection1.Images.SetKeyName(3, "SaveDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.AddDev32, "AddDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 4);
            this.imageCollection1.Images.SetKeyName(4, "AddDev32");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.ImageOptions.ImageIndex = 2;
            this.btnCancelar.ImageOptions.ImageList = this.imageCollection1;
            this.btnCancelar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelar.Location = new System.Drawing.Point(272, 514);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 44);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cboTurno
            // 
            this.cboTurno.Location = new System.Drawing.Point(153, 73);
            this.cboTurno.Name = "cboTurno";
            this.cboTurno.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboTurno.Properties.Appearance.Options.UseFont = true;
            this.cboTurno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTurno.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTurno", "Turno"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTurno", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.cboTurno.Properties.NullText = "-- Elija un turno --";
            this.cboTurno.Properties.ShowFooter = false;
            this.cboTurno.Properties.ShowHeader = false;
            this.cboTurno.Size = new System.Drawing.Size(289, 22);
            this.cboTurno.TabIndex = 10;
            this.cboTurno.EditValueChanged += new System.EventHandler(this.cboTurno_EditValueChanged);
            // 
            // txtAgencia
            // 
            this.txtAgencia.Location = new System.Drawing.Point(151, 109);
            this.txtAgencia.Name = "txtAgencia";
            this.txtAgencia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtAgencia.Properties.Appearance.Options.UseFont = true;
            this.txtAgencia.Properties.MaxLength = 10;
            this.txtAgencia.Size = new System.Drawing.Size(165, 22);
            this.txtAgencia.TabIndex = 11;
            this.txtAgencia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAgencia_KeyDown);
            this.txtAgencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAgencia_KeyPress);
            // 
            // lblTurno
            // 
            this.lblTurno.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTurno.Appearance.Options.UseFont = true;
            this.lblTurno.Location = new System.Drawing.Point(33, 76);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(34, 16);
            this.lblTurno.TabIndex = 13;
            this.lblTurno.Text = "Turno";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(33, 112);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(95, 16);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Agregar Agencia";
            // 
            // grdAgencia
            // 
            this.grdAgencia.Location = new System.Drawing.Point(12, 150);
            this.grdAgencia.MainView = this.grvAgencia;
            this.grdAgencia.Name = "grdAgencia";
            this.grdAgencia.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.grdAgencia.Size = new System.Drawing.Size(452, 342);
            this.grdAgencia.TabIndex = 15;
            this.grdAgencia.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAgencia});
            // 
            // grvAgencia
            // 
            this.grvAgencia.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.griCodigoAgencia,
            this.griAgencia,
            this.gridColumn3});
            this.grvAgencia.GridControl = this.grdAgencia;
            this.grvAgencia.Name = "grvAgencia";
            this.grvAgencia.OptionsView.ShowAutoFilterRow = true;
            this.grvAgencia.OptionsView.ShowGroupPanel = false;
            // 
            // griCodigoAgencia
            // 
            this.griCodigoAgencia.Caption = "Código Agencia";
            this.griCodigoAgencia.FieldName = "sCodigoAgencia";
            this.griCodigoAgencia.Name = "griCodigoAgencia";
            this.griCodigoAgencia.OptionsColumn.ReadOnly = true;
            this.griCodigoAgencia.Visible = true;
            this.griCodigoAgencia.VisibleIndex = 0;
            this.griCodigoAgencia.Width = 108;
            // 
            // griAgencia
            // 
            this.griAgencia.Caption = "Agencia";
            this.griAgencia.FieldName = "sDescripcion";
            this.griAgencia.Name = "griAgencia";
            this.griAgencia.OptionsColumn.ReadOnly = true;
            this.griAgencia.Visible = true;
            this.griAgencia.VisibleIndex = 1;
            this.griAgencia.Width = 238;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Quitar";
            this.gridColumn3.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 88;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Caption = "Quitar";
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Quitar";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Appearance.BackColor = System.Drawing.Color.White;
            this.btnAgregar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnAgregar.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAgregar.Appearance.Options.UseBackColor = true;
            this.btnAgregar.Appearance.Options.UseFont = true;
            this.btnAgregar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAgregar.ImageOptions.ImageIndex = 4;
            this.btnAgregar.ImageOptions.ImageList = this.imageCollection1;
            this.btnAgregar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAgregar.Location = new System.Drawing.Point(322, 104);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 28);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // cboColaborador
            // 
            this.cboColaborador.Location = new System.Drawing.Point(153, 17);
            this.cboColaborador.Name = "cboColaborador";
            this.cboColaborador.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboColaborador.Properties.Appearance.Options.UseFont = true;
            this.cboColaborador.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboColaborador.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboColaborador.Properties.NullText = "-- Elija un colaborador --";
            this.cboColaborador.Properties.ShowFooter = false;
            this.cboColaborador.Properties.ShowHeader = false;
            this.cboColaborador.Size = new System.Drawing.Size(289, 22);
            this.cboColaborador.TabIndex = 16;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(33, 20);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 16);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Colaborador";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(33, 48);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(85, 16);
            this.labelControl2.TabIndex = 13;
            this.labelControl2.Text = "Grupo palomar";
            // 
            // cboPalomar
            // 
            this.cboPalomar.Location = new System.Drawing.Point(153, 45);
            this.cboPalomar.Name = "cboPalomar";
            this.cboPalomar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPalomar.Properties.Appearance.Options.UseFont = true;
            this.cboPalomar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPalomar.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboPalomar.Properties.NullText = "-- Elija un grupo palomar --";
            this.cboPalomar.Properties.ShowFooter = false;
            this.cboPalomar.Properties.ShowHeader = false;
            this.cboPalomar.Size = new System.Drawing.Size(289, 22);
            this.cboPalomar.TabIndex = 16;
            this.cboPalomar.EditValueChanged += new System.EventHandler(this.cboPalomar_EditValueChanged);
            // 
            // frmNuevaEntregaAgencias
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 565);
            this.Controls.Add(this.cboPalomar);
            this.Controls.Add(this.cboColaborador);
            this.Controls.Add(this.grdAgencia);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.txtAgencia);
            this.Controls.Add(this.cboTurno);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCrear);
            this.Name = "frmNuevaEntregaAgencias";
            this.Text = "Nuevo envío";
            this.Load += new System.EventHandler(this.frmNuevaEntregaAgencias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTurno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAgencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAgencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboColaborador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPalomar.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCrear;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.LookUpEdit cboTurno;
        private DevExpress.XtraEditors.TextEdit txtAgencia;
        private DevExpress.XtraEditors.LabelControl lblTurno;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.GridControl grdAgencia;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn griCodigoAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn griAgencia;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.LookUpEdit cboColaborador;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cboPalomar;
    }
}