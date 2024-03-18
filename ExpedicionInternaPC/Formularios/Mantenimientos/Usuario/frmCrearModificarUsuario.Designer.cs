namespace ExpedicionInternaPC
{
    partial class frmCrearModificarUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearModificarUsuario));
            this.txtNombre = new DevExpress.XtraEditors.TextEdit();
            this.txtMatricula = new DevExpress.XtraEditors.TextEdit();
            this.txtCodigoUsuario = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.cboTipoUsuario = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTipoAutenticacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBandejaPredeterminada = new DevExpress.XtraEditors.LabelControl();
            this.cboExpedicion = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.cboProvincia = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDistrito = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.cboBandeja = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDominio = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDni = new DevExpress.XtraEditors.TextEdit();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.glookOficinaArea = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.glookDireccion = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.cboProveedor = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatricula.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoAutenticacion.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboExpedicion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBandeja.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDominio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glookOficinaArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.glookDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProveedor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(156, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Properties.MaxLength = 200;
            this.txtNombre.Size = new System.Drawing.Size(259, 20);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(156, 56);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Properties.MaxLength = 20;
            this.txtMatricula.Size = new System.Drawing.Size(259, 20);
            this.txtMatricula.TabIndex = 1;
            this.txtMatricula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMatricula_KeyPress);
            // 
            // txtCodigoUsuario
            // 
            this.txtCodigoUsuario.Location = new System.Drawing.Point(156, 134);
            this.txtCodigoUsuario.Name = "txtCodigoUsuario";
            this.txtCodigoUsuario.Properties.MaxLength = 100;
            this.txtCodigoUsuario.Size = new System.Drawing.Size(259, 20);
            this.txtCodigoUsuario.TabIndex = 4;
            this.txtCodigoUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoUsuario_KeyPress);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(156, 186);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(259, 20);
            this.txtPassword.TabIndex = 6;
            // 
            // cboTipoUsuario
            // 
            this.cboTipoUsuario.Location = new System.Drawing.Point(156, 280);
            this.cboTipoUsuario.Name = "cboTipoUsuario";
            this.cboTipoUsuario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoUsuario.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoUsuario", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoUsuario", "Descripcion")});
            this.cboTipoUsuario.Properties.NullText = "-- Seleccionar --";
            this.cboTipoUsuario.Properties.ShowFooter = false;
            this.cboTipoUsuario.Properties.ShowHeader = false;
            this.cboTipoUsuario.Size = new System.Drawing.Size(259, 20);
            this.cboTipoUsuario.TabIndex = 7;
            this.cboTipoUsuario.EditValueChanged += new System.EventHandler(this.cboTipoUsuario_EditValueChanged);
            // 
            // cboTipoAutenticacion
            // 
            this.cboTipoAutenticacion.Location = new System.Drawing.Point(156, 160);
            this.cboTipoAutenticacion.Name = "cboTipoAutenticacion";
            this.cboTipoAutenticacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoAutenticacion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IdModoAcceso", "IdModoAcceso", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("modoAcceso", "ModoAcceso")});
            this.cboTipoAutenticacion.Properties.NullText = "-- Seleccionar --";
            this.cboTipoAutenticacion.Properties.ShowFooter = false;
            this.cboTipoAutenticacion.Properties.ShowHeader = false;
            this.cboTipoAutenticacion.Size = new System.Drawing.Size(259, 20);
            this.cboTipoAutenticacion.TabIndex = 5;
            this.cboTipoAutenticacion.EditValueChanged += new System.EventHandler(this.cboTipoAutenticacion_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Nombre";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(32, 59);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "Matrícula";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(32, 283);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(73, 13);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Tipo de usuario";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(32, 137);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(86, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Código de usuario";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(32, 163);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(102, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Tipo de autenticación";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(32, 189);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(46, 13);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBandejaPredeterminada);
            this.groupBox1.Location = new System.Drawing.Point(32, 219);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 55);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bandeja predeterminada";
            // 
            // lblBandejaPredeterminada
            // 
            this.lblBandejaPredeterminada.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lblBandejaPredeterminada.Appearance.Options.UseFont = true;
            this.lblBandejaPredeterminada.Appearance.Options.UseTextOptions = true;
            this.lblBandejaPredeterminada.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBandejaPredeterminada.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBandejaPredeterminada.Location = new System.Drawing.Point(6, 23);
            this.lblBandejaPredeterminada.Name = "lblBandejaPredeterminada";
            this.lblBandejaPredeterminada.Size = new System.Drawing.Size(371, 19);
            this.lblBandejaPredeterminada.TabIndex = 15;
            // 
            // cboExpedicion
            // 
            this.cboExpedicion.Enabled = false;
            this.cboExpedicion.Location = new System.Drawing.Point(156, 334);
            this.cboExpedicion.Name = "cboExpedicion";
            this.cboExpedicion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboExpedicion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboExpedicion.Properties.NullText = "-- Seleccionar --";
            this.cboExpedicion.Properties.ShowFooter = false;
            this.cboExpedicion.Properties.ShowHeader = false;
            this.cboExpedicion.Size = new System.Drawing.Size(259, 20);
            this.cboExpedicion.TabIndex = 9;
            this.cboExpedicion.EditValueChanged += new System.EventHandler(this.cboExpedicion_EditValueChanged);
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Enabled = false;
            this.cboDepartamento.Location = new System.Drawing.Point(156, 395);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartamento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Departamento")});
            this.cboDepartamento.Properties.NullText = "-- Seleccionar --";
            this.cboDepartamento.Properties.ShowFooter = false;
            this.cboDepartamento.Properties.ShowHeader = false;
            this.cboDepartamento.Size = new System.Drawing.Size(259, 20);
            this.cboDepartamento.TabIndex = 11;
            this.cboDepartamento.EditValueChanged += new System.EventHandler(this.cboDepartamento_EditValueChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.Enabled = false;
            this.cboProvincia.Location = new System.Drawing.Point(156, 421);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProvincia.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Provincia")});
            this.cboProvincia.Properties.NullText = "-- Seleccionar --";
            this.cboProvincia.Properties.ShowFooter = false;
            this.cboProvincia.Properties.ShowHeader = false;
            this.cboProvincia.Size = new System.Drawing.Size(259, 20);
            this.cboProvincia.TabIndex = 12;
            this.cboProvincia.EditValueChanged += new System.EventHandler(this.cboProvincia_EditValueChanged);
            // 
            // cboDistrito
            // 
            this.cboDistrito.Enabled = false;
            this.cboDistrito.Location = new System.Drawing.Point(156, 447);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDistrito.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Distrito")});
            this.cboDistrito.Properties.NullText = "-- Seleccionar --";
            this.cboDistrito.Properties.ShowFooter = false;
            this.cboDistrito.Properties.ShowHeader = false;
            this.cboDistrito.Size = new System.Drawing.Size(259, 20);
            this.cboDistrito.TabIndex = 13;
            this.cboDistrito.EditValueChanged += new System.EventHandler(this.cboDistrito_EditValueChanged);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(32, 337);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(51, 13);
            this.labelControl9.TabIndex = 25;
            this.labelControl9.Text = "Expedición";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(32, 398);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(69, 13);
            this.labelControl10.TabIndex = 26;
            this.labelControl10.Text = "Departamento";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(32, 424);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(43, 13);
            this.labelControl11.TabIndex = 27;
            this.labelControl11.Text = "Provincia";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(32, 450);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(34, 13);
            this.labelControl12.TabIndex = 28;
            this.labelControl12.Text = "Distrito";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(32, 476);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(43, 13);
            this.labelControl13.TabIndex = 29;
            this.labelControl13.Text = "Dirección";
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(32, 502);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(60, 13);
            this.labelControl14.TabIndex = 30;
            this.labelControl14.Text = "Oficina/Area";
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.ImageList = this.imageCollection1;
            this.btnCancelar.Location = new System.Drawing.Point(235, 541);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(159, 44);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.CancelDev32, "CancelDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "CancelDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "SaveDev32");
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.ImageOptions.ImageIndex = 1;
            this.btnGuardar.ImageOptions.ImageList = this.imageCollection1;
            this.btnGuardar.Location = new System.Drawing.Point(53, 541);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(159, 44);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboBandeja
            // 
            this.cboBandeja.Enabled = false;
            this.cboBandeja.Location = new System.Drawing.Point(156, 360);
            this.cboBandeja.Name = "cboBandeja";
            this.cboBandeja.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboBandeja.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboBandeja.Properties.NullText = "-- Seleccionar --";
            this.cboBandeja.Properties.ShowFooter = false;
            this.cboBandeja.Properties.ShowHeader = false;
            this.cboBandeja.Size = new System.Drawing.Size(259, 20);
            this.cboBandeja.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(32, 363);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 25;
            this.labelControl2.Text = "Bandeja:";
            // 
            // txtDominio
            // 
            this.txtDominio.EditValue = "BCP";
            this.txtDominio.Enabled = false;
            this.txtDominio.Location = new System.Drawing.Point(156, 108);
            this.txtDominio.Name = "txtDominio";
            this.txtDominio.Properties.MaxLength = 50;
            this.txtDominio.Size = new System.Drawing.Size(259, 20);
            this.txtDominio.TabIndex = 3;
            this.txtDominio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDominio_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(32, 111);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(37, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Dominio";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(156, 82);
            this.txtDni.Name = "txtDni";
            this.txtDni.Properties.MaxLength = 20;
            this.txtDni.Size = new System.Drawing.Size(259, 20);
            this.txtDni.TabIndex = 2;
            // 
            // labelControl15
            // 
            this.labelControl15.Location = new System.Drawing.Point(32, 85);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(18, 13);
            this.labelControl15.TabIndex = 32;
            this.labelControl15.Text = "DNI";
            // 
            // glookOficinaArea
            // 
            this.glookOficinaArea.Enabled = false;
            this.glookOficinaArea.Location = new System.Drawing.Point(156, 499);
            this.glookOficinaArea.Name = "glookOficinaArea";
            this.glookOficinaArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glookOficinaArea.Properties.NullText = "-- Seleccionar --";
            this.glookOficinaArea.Properties.PopupView = this.gridLookUpEdit1View;
            this.glookOficinaArea.Size = new System.Drawing.Size(259, 20);
            this.glookOficinaArea.TabIndex = 15;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Codigo";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.MaxWidth = 75;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 50;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "OficinaArea";
            this.gridColumn2.FieldName = "Oficina";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // glookDireccion
            // 
            this.glookDireccion.Enabled = false;
            this.glookDireccion.Location = new System.Drawing.Point(156, 473);
            this.glookDireccion.Name = "glookDireccion";
            this.glookDireccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.glookDireccion.Properties.NullText = "-- Seleccionar --";
            this.glookDireccion.Properties.PopupView = this.gridView1;
            this.glookDireccion.Size = new System.Drawing.Size(259, 20);
            this.glookDireccion.TabIndex = 14;
            this.glookDireccion.EditValueChanged += new System.EventHandler(this.glookDireccion_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ID";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Direccion";
            this.gridColumn4.FieldName = "Descripcion";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // labelControl16
            // 
            this.labelControl16.Location = new System.Drawing.Point(33, 314);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(50, 13);
            this.labelControl16.TabIndex = 33;
            this.labelControl16.Text = "Proveedor";
            // 
            // cboProveedor
            // 
            this.cboProveedor.Location = new System.Drawing.Point(156, 311);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProveedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboProveedor.Properties.NullText = "-- Seleccionar --";
            this.cboProveedor.Properties.ShowFooter = false;
            this.cboProveedor.Properties.ShowHeader = false;
            this.cboProveedor.Size = new System.Drawing.Size(259, 20);
            this.cboProveedor.TabIndex = 8;
            // 
            // frmCrearModificarUsuario
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 597);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.labelControl16);
            this.Controls.Add(this.glookDireccion);
            this.Controls.Add(this.glookOficinaArea);
            this.Controls.Add(this.labelControl15);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.txtDominio);
            this.Controls.Add(this.cboBandeja);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.cboDistrito);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.cboDepartamento);
            this.Controls.Add(this.cboExpedicion);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboTipoAutenticacion);
            this.Controls.Add(this.cboTipoUsuario);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtCodigoUsuario);
            this.Controls.Add(this.txtMatricula);
            this.Controls.Add(this.txtNombre);
            this.Name = "frmCrearModificarUsuario";
            this.Text = "frmCrearModificarUsuario";
            this.Load += new System.EventHandler(this.frmCrearModificarUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatricula.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoAutenticacion.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cboExpedicion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboBandeja.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDominio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glookOficinaArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.glookDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProveedor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtNombre;
        private DevExpress.XtraEditors.TextEdit txtMatricula;
        private DevExpress.XtraEditors.TextEdit txtCodigoUsuario;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LookUpEdit cboTipoUsuario;
        private DevExpress.XtraEditors.LookUpEdit cboTipoAutenticacion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl lblBandejaPredeterminada;
        private DevExpress.XtraEditors.LookUpEdit cboExpedicion;
        private DevExpress.XtraEditors.LookUpEdit cboDepartamento;
        private DevExpress.XtraEditors.LookUpEdit cboProvincia;
        private DevExpress.XtraEditors.LookUpEdit cboDistrito;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.LookUpEdit cboBandeja;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDominio;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDni;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.GridLookUpEdit glookOficinaArea;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.GridLookUpEdit glookDireccion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LookUpEdit cboProveedor;
    }
}