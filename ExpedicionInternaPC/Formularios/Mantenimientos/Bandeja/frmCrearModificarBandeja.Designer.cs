namespace ExpedicionInternaPC
{
    partial class frmCrearModificarBandeja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCrearModificarBandeja));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cboOficinaArea = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDireccion = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDistrito = new DevExpress.XtraEditors.LookUpEdit();
            this.cboProvincia = new DevExpress.XtraEditors.LookUpEdit();
            this.cboDepartamento = new DevExpress.XtraEditors.LookUpEdit();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.txtBandeja = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOficinaArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDireccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBandeja.Properties)).BeginInit();
            this.SuspendLayout();
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
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.ImageOptions.ImageIndex = 0;
            this.btnCancelar.ImageOptions.ImageList = this.imageCollection1;
            this.btnCancelar.Location = new System.Drawing.Point(52, 310);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(185, 62);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(35, 252);
            this.labelControl14.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(71, 16);
            this.labelControl14.TabIndex = 40;
            this.labelControl14.Text = "Oficina/Area";
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(35, 215);
            this.labelControl13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(52, 16);
            this.labelControl13.TabIndex = 39;
            this.labelControl13.Text = "Dirección";
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(35, 178);
            this.labelControl12.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(40, 16);
            this.labelControl12.TabIndex = 38;
            this.labelControl12.Text = "Distrito";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(35, 142);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(51, 16);
            this.labelControl11.TabIndex = 37;
            this.labelControl11.Text = "Provincia";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(35, 105);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(81, 16);
            this.labelControl10.TabIndex = 36;
            this.labelControl10.Text = "Departamento";
            // 
            // cboOficinaArea
            // 
            this.cboOficinaArea.Location = new System.Drawing.Point(180, 248);
            this.cboOficinaArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboOficinaArea.Name = "cboOficinaArea";
            this.cboOficinaArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboOficinaArea.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Oficina", "OficinaArea")});
            this.cboOficinaArea.Properties.NullText = "-- Seleccionar --";
            this.cboOficinaArea.Properties.ShowFooter = false;
            this.cboOficinaArea.Properties.ShowHeader = false;
            this.cboOficinaArea.Size = new System.Drawing.Size(302, 22);
            this.cboOficinaArea.TabIndex = 5;
            // 
            // cboDireccion
            // 
            this.cboDireccion.Location = new System.Drawing.Point(180, 211);
            this.cboDireccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDireccion.Name = "cboDireccion";
            this.cboDireccion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDireccion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Direccion")});
            this.cboDireccion.Properties.NullText = "-- Seleccionar --";
            this.cboDireccion.Properties.ShowFooter = false;
            this.cboDireccion.Properties.ShowHeader = false;
            this.cboDireccion.Size = new System.Drawing.Size(302, 22);
            this.cboDireccion.TabIndex = 4;
            this.cboDireccion.EditValueChanged += new System.EventHandler(this.cboDireccion_EditValueChanged);
            // 
            // cboDistrito
            // 
            this.cboDistrito.Location = new System.Drawing.Point(180, 174);
            this.cboDistrito.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDistrito.Name = "cboDistrito";
            this.cboDistrito.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDistrito.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Distrito")});
            this.cboDistrito.Properties.NullText = "-- Seleccionar --";
            this.cboDistrito.Properties.ShowFooter = false;
            this.cboDistrito.Properties.ShowHeader = false;
            this.cboDistrito.Size = new System.Drawing.Size(302, 22);
            this.cboDistrito.TabIndex = 3;
            this.cboDistrito.EditValueChanged += new System.EventHandler(this.cboDistrito_EditValueChanged);
            // 
            // cboProvincia
            // 
            this.cboProvincia.Location = new System.Drawing.Point(180, 137);
            this.cboProvincia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboProvincia.Name = "cboProvincia";
            this.cboProvincia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboProvincia.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Provincia")});
            this.cboProvincia.Properties.NullText = "-- Seleccionar --";
            this.cboProvincia.Properties.ShowFooter = false;
            this.cboProvincia.Properties.ShowHeader = false;
            this.cboProvincia.Size = new System.Drawing.Size(302, 22);
            this.cboProvincia.TabIndex = 2;
            this.cboProvincia.EditValueChanged += new System.EventHandler(this.cboProvincia_EditValueChanged);
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.Location = new System.Drawing.Point(180, 101);
            this.cboDepartamento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDepartamento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Departamento")});
            this.cboDepartamento.Properties.NullText = "-- Seleccionar --";
            this.cboDepartamento.Properties.ShowFooter = false;
            this.cboDepartamento.Properties.ShowHeader = false;
            this.cboDepartamento.Size = new System.Drawing.Size(302, 22);
            this.cboDepartamento.TabIndex = 1;
            this.cboDepartamento.EditValueChanged += new System.EventHandler(this.cboDepartamento_EditValueChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.ImageOptions.ImageIndex = 1;
            this.btnGuardar.ImageOptions.ImageList = this.imageCollection1;
            this.btnGuardar.Location = new System.Drawing.Point(264, 310);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(185, 62);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "&Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtBandeja
            // 
            this.txtBandeja.Location = new System.Drawing.Point(180, 48);
            this.txtBandeja.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBandeja.Name = "txtBandeja";
            this.txtBandeja.Size = new System.Drawing.Size(302, 22);
            this.txtBandeja.TabIndex = 0;
            this.txtBandeja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBandeja_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 52);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(51, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Bandeja:";
            // 
            // frmCrearModificarBandeja
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 418);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.labelControl14);
            this.Controls.Add(this.labelControl13);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.cboOficinaArea);
            this.Controls.Add(this.cboDireccion);
            this.Controls.Add(this.cboDistrito);
            this.Controls.Add(this.cboProvincia);
            this.Controls.Add(this.cboDepartamento);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtBandeja);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmCrearModificarBandeja";
            this.Text = "frmCrearModificarBandeja";
            this.Load += new System.EventHandler(this.frmCrearModificarBandeja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboOficinaArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDireccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDistrito.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboProvincia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDepartamento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBandeja.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtBandeja;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LookUpEdit cboOficinaArea;
        private DevExpress.XtraEditors.LookUpEdit cboDireccion;
        private DevExpress.XtraEditors.LookUpEdit cboDistrito;
        private DevExpress.XtraEditors.LookUpEdit cboProvincia;
        private DevExpress.XtraEditors.LookUpEdit cboDepartamento;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}