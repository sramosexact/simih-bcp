namespace ExpedicionInternaPC
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.btnEmpezar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.chkRecordar = new DevExpress.XtraEditors.CheckEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.lblTitulo = new DevExpress.XtraEditors.LabelControl();
            this.lblAcceso = new DevExpress.XtraEditors.LabelControl();
            this.cmbAcceso = new DevExpress.XtraEditors.LookUpEdit();
            this.lblUsuario = new DevExpress.XtraEditors.LabelControl();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.lblCliente = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.cmbCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.lblMensaje = new DevExpress.XtraEditors.LabelControl();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.picCargando = new DevExpress.XtraEditors.PictureEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRecordar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAcceso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCargando.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEmpezar
            // 
            this.btnEmpezar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEmpezar.AutoWidthInLayoutControl = true;
            this.btnEmpezar.ImageOptions.ImageIndex = 0;
            this.btnEmpezar.ImageOptions.ImageList = this.imageCollection1;
            this.btnEmpezar.Location = new System.Drawing.Point(505, 212);
            this.btnEmpezar.Name = "btnEmpezar";
            this.btnEmpezar.Size = new System.Drawing.Size(113, 31);
            this.btnEmpezar.TabIndex = 4;
            this.btnEmpezar.Text = "&Iniciar Sesión";
            this.btnEmpezar.Click += new System.EventHandler(this.btnEmpezar_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.paperairplane32, "paperairplane32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "paperairplane32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.microsoft_logo1, "microsoft_logo1", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "microsoft_logo1");
            // 
            // chkRecordar
            // 
            this.chkRecordar.Location = new System.Drawing.Point(776, 215);
            this.chkRecordar.Name = "chkRecordar";
            this.chkRecordar.Properties.Caption = "&Recordarme";
            this.chkRecordar.Size = new System.Drawing.Size(106, 20);
            this.chkRecordar.TabIndex = 18;
            this.chkRecordar.TabStop = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(657, 168);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(238, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(657, 131);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtUsuario.Size = new System.Drawing.Size(238, 20);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.EditValueChanged += new System.EventHandler(this.txtUsuario_EditValueChanged);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Appearance.Options.UseFont = true;
            this.lblTitulo.Location = new System.Drawing.Point(439, 192);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(184, 25);
            this.lblTitulo.TabIndex = 14;
            this.lblTitulo.Text = "Bienvenido al Sistema";
            // 
            // lblAcceso
            // 
            this.lblAcceso.Location = new System.Drawing.Point(577, 99);
            this.lblAcceso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblAcceso.Name = "lblAcceso";
            this.lblAcceso.Size = new System.Drawing.Size(63, 13);
            this.lblAcceso.TabIndex = 22;
            this.lblAcceso.Text = "Modo Acceso";
            // 
            // cmbAcceso
            // 
            this.cmbAcceso.Location = new System.Drawing.Point(657, 95);
            this.cmbAcceso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbAcceso.Name = "cmbAcceso";
            this.cmbAcceso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAcceso.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IdModoAcceso", "IdModoAcceso", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("modoAcceso", "modoAcceso")});
            this.cmbAcceso.Properties.NullText = "";
            this.cmbAcceso.Properties.ShowFooter = false;
            this.cmbAcceso.Properties.ShowHeader = false;
            this.cmbAcceso.Size = new System.Drawing.Size(238, 20);
            this.cmbAcceso.TabIndex = 1;
            this.cmbAcceso.EditValueChanged += new System.EventHandler(this.cmbAcceso_EditValueChanged);
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(577, 136);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(36, 13);
            this.lblUsuario.TabIndex = 24;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(577, 173);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 25;
            this.lblPassword.Text = "Contraseña";
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(577, 62);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(47, 13);
            this.lblCliente.TabIndex = 26;
            this.lblCliente.Text = "ID Cliente";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = global::ExpedicionInternaPC.Properties.Resources.simih_small;
            this.pictureEdit1.Location = new System.Drawing.Point(53, 48);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Properties.ZoomPercent = 150D;
            this.pictureEdit1.Size = new System.Drawing.Size(296, 109);
            this.pictureEdit1.TabIndex = 27;
            // 
            // cmbCliente
            // 
            this.cmbCliente.Location = new System.Drawing.Point(657, 58);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCliente.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "IdCliente", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Cliente", "Cliente")});
            this.cmbCliente.Properties.NullText = "";
            this.cmbCliente.Properties.ShowFooter = false;
            this.cmbCliente.Properties.ShowHeader = false;
            this.cmbCliente.Size = new System.Drawing.Size(238, 20);
            this.cmbCliente.TabIndex = 0;
            this.cmbCliente.EditValueChanged += new System.EventHandler(this.cmbCliente_EditValueChanged);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.btnCancelar.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.Appearance.Options.UseFont = true;
            this.btnCancelar.Appearance.Options.UseTextOptions = true;
            this.btnCancelar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCancelar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnCancelar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.CancelDev32;
            this.btnCancelar.Location = new System.Drawing.Point(355, 13);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(36, 37);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMensaje.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.lblMensaje.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblMensaje.Appearance.Options.UseBorderColor = true;
            this.lblMensaje.Appearance.Options.UseFont = true;
            this.lblMensaje.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMensaje.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.lblMensaje.Location = new System.Drawing.Point(-2, 250);
            this.lblMensaje.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(411, 31);
            this.lblMensaje.TabIndex = 30;
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageSize = new System.Drawing.Size(48, 48);
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.InsertImage(global::ExpedicionInternaPC.Properties.Resources.paperairplane32, "paperairplane32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection2.Images.SetKeyName(0, "paperairplane32");
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButton1.AutoWidthInLayoutControl = true;
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.ImageOptions.ImageIndex = 1;
            this.simpleButton1.ImageOptions.ImageList = this.imageCollection1;
            this.simpleButton1.Location = new System.Drawing.Point(149, 212);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(105, 31);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "&Iniciar sesión";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.simpleButton2.AutoWidthInLayoutControl = true;
            this.simpleButton2.ImageOptions.ImageIndex = 1;
            this.simpleButton2.Location = new System.Drawing.Point(504, 113);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(114, 31);
            this.simpleButton2.TabIndex = 31;
            this.simpleButton2.Text = "&Cerrar sesión Azure";
            this.simpleButton2.Visible = false;
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // picCargando
            // 
            this.picCargando.Cursor = System.Windows.Forms.Cursors.Default;
            this.picCargando.EditValue = global::ExpedicionInternaPC.Properties.Resources.Logo_slogan_isotipo_color;
            this.picCargando.Location = new System.Drawing.Point(-2, 4);
            this.picCargando.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.picCargando.Name = "picCargando";
            this.picCargando.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picCargando.Properties.Appearance.Options.UseBackColor = true;
            this.picCargando.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picCargando.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picCargando.Properties.ZoomPercent = 150D;
            this.picCargando.Size = new System.Drawing.Size(411, 288);
            this.picCargando.TabIndex = 27;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(35, 164);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(338, 25);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Sistema Integral de Mensajería In House";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.ImageHorzOffset = 20;
            this.progressPanel1.Location = new System.Drawing.Point(116, 192);
            this.progressPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(167, 39);
            this.progressPanel1.TabIndex = 32;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // frmLogin
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 281);
            this.ControlBox = false;
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.picCargando);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbCliente);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.cmbAcceso);
            this.Controls.Add(this.lblAcceso);
            this.Controls.Add(this.btnEmpezar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.chkRecordar);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmLogin.IconOptions.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Exact SIM :: Expedicion Interna";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRecordar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAcceso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCargando.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnEmpezar;
        private DevExpress.XtraEditors.CheckEdit chkRecordar;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraEditors.LabelControl lblTitulo;
        private DevExpress.XtraEditors.LabelControl lblAcceso;
        private DevExpress.XtraEditors.LookUpEdit cmbAcceso;
        private DevExpress.XtraEditors.LabelControl lblUsuario;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.LabelControl lblCliente;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LookUpEdit cmbCliente;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl lblMensaje;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.PictureEdit picCargando;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
    }
}