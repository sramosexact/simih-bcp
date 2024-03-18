namespace ExpedicionInternaPC
{
    partial class frmExpedicionNuevo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpedicionNuevo));
            this.cboTipoExpedicion = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.cboProvincia = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDistrito = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDireccion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.Direccion = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtExpedicion = new DevExpress.XtraEditors.TextEdit();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtOficina = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.txtPrefijo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoExpedicion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpedicion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOficina.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrefijo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoExpedicion
            // 
            this.cboTipoExpedicion.Location = new System.Drawing.Point(122, 225);
            this.cboTipoExpedicion.Name = "cboTipoExpedicion";
            this.cboTipoExpedicion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoExpedicion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoExpedicion", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoExpedicion", "Descripcion")});
            this.cboTipoExpedicion.Properties.NullText = "Seleccione";
            this.cboTipoExpedicion.Properties.ShowFooter = false;
            this.cboTipoExpedicion.Properties.ShowHeader = false;
            this.cboTipoExpedicion.Size = new System.Drawing.Size(310, 20);
            this.cboTipoExpedicion.TabIndex = 8;
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Location = new System.Drawing.Point(122, 95);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartamento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Departamento")});
            this.cboDepartamento.Properties.NullText = "Seleccione";
            this.cboDepartamento.Properties.ShowFooter = false;
            this.cboDepartamento.Properties.ShowHeader = false;
            this.cboDepartamento.Size = new System.Drawing.Size(310, 20);
            this.cboDepartamento.TabIndex = 3;
            this.cboDepartamento.EditValueChanged += new System.EventHandler(this.cboDepartamento_EditValueChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.Location = new System.Drawing.Point(122, 121);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProvincia.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Provincia")});
            this.cboProvincia.Properties.NullText = "Seleccione";
            this.cboProvincia.Properties.ShowFooter = false;
            this.cboProvincia.Properties.ShowHeader = false;
            this.cboProvincia.Size = new System.Drawing.Size(310, 20);
            this.cboProvincia.TabIndex = 4;
            this.cboProvincia.EditValueChanged += new System.EventHandler(this.cboProvincia_EditValueChanged);
            // 
            // cboDistrito
            // 
            this.cboDistrito.Location = new System.Drawing.Point(122, 147);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDistrito.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Distrito")});
            this.cboDistrito.Properties.NullText = "Seleccione";
            this.cboDistrito.Properties.ShowFooter = false;
            this.cboDistrito.Properties.ShowHeader = false;
            this.cboDistrito.Size = new System.Drawing.Size(310, 20);
            this.cboDistrito.TabIndex = 5;
            this.cboDistrito.EditValueChanged += new System.EventHandler(this.cboDistrito_EditValueChanged);
            // 
            // cboDireccion
            // 
            this.cboDireccion.Location = new System.Drawing.Point(122, 173);
            this.cboDireccion.Name = "cboDireccion";
            this.cboDireccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDireccion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Direccion")});
            this.cboDireccion.Properties.NullText = "Seleccione";
            this.cboDireccion.Properties.ShowFooter = false;
            this.cboDireccion.Properties.ShowHeader = false;
            this.cboDireccion.Size = new System.Drawing.Size(310, 20);
            this.cboDireccion.TabIndex = 6;
            this.cboDireccion.EditValueChanged += new System.EventHandler(this.cboDireccion_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(34, 98);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(69, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Departamento";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(34, 124);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Provincia";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 154);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(34, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Distrito";
            // 
            // Direccion
            // 
            this.Direccion.Location = new System.Drawing.Point(34, 176);
            this.Direccion.Name = "Direccion";
            this.Direccion.Size = new System.Drawing.Size(43, 13);
            this.Direccion.TabIndex = 8;
            this.Direccion.Text = "Dirección";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(34, 48);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(51, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Expedición";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(34, 228);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(20, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Tipo";
            // 
            // txtExpedicion
            // 
            this.txtExpedicion.Location = new System.Drawing.Point(122, 45);
            this.txtExpedicion.Name = "txtExpedicion";
            this.txtExpedicion.Size = new System.Drawing.Size(310, 20);
            this.txtExpedicion.TabIndex = 1;
            this.txtExpedicion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExpedicion_KeyPress);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.SaveDev32;
            this.btnGuardar.ImageOptions.ImageIndex = 0;
            this.btnGuardar.ImageOptions.ImageList = this.imageCollection1;
            this.btnGuardar.Location = new System.Drawing.Point(252, 267);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(132, 50);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(34, 202);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 13);
            this.labelControl4.TabIndex = 14;
            this.labelControl4.Text = "Ubicación";
            // 
            // txtOficina
            // 
            this.txtOficina.Location = new System.Drawing.Point(122, 199);
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Size = new System.Drawing.Size(310, 20);
            this.txtOficina.TabIndex = 7;
            this.txtOficina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOficina_KeyPress);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.CancelDev32;
            this.btnCancelar.ImageOptions.ImageIndex = 1;
            this.btnCancelar.ImageOptions.ImageList = this.imageCollection1;
            this.btnCancelar.Location = new System.Drawing.Point(95, 267);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(132, 50);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPrefijo
            // 
            this.txtPrefijo.Location = new System.Drawing.Point(122, 69);
            this.txtPrefijo.Name = "txtPrefijo";
            this.txtPrefijo.Properties.MaxLength = 3;
            this.txtPrefijo.Size = new System.Drawing.Size(77, 20);
            this.txtPrefijo.TabIndex = 2;
            this.txtPrefijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textEdit1_KeyPress);
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(34, 72);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(31, 13);
            this.labelControl7.TabIndex = 19;
            this.labelControl7.Text = "Prefijo";
            // 
            // frmExpedicionNuevo
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 337);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.txtPrefijo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtOficina);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtExpedicion);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.Direccion);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cboTipoExpedicion);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboDireccion);
            this.Controls.Add(this.cboDistrito);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.cboDepartamento);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "frmExpedicionNuevo";
            this.Text = "Expedición";
            this.Load += new System.EventHandler(this.frmExpedicionNuevo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoExpedicion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpedicion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOficina.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrefijo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboTipoExpedicion;
        private DevExpress.XtraEditors.LookUpEdit cboDepartamento;
        private DevExpress.XtraEditors.LookUpEdit cboProvincia;
        private DevExpress.XtraEditors.LookUpEdit cboDistrito;
        private DevExpress.XtraEditors.LookUpEdit cboDireccion;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl Direccion;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtExpedicion;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.TextEdit txtOficina;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.TextEdit txtPrefijo;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}