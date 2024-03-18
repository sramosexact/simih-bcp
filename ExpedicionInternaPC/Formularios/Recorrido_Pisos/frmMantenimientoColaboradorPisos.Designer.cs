
namespace ExpedicionInternaPC
{
    partial class frmMantenimientoColaboradorPisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoColaboradorPisos));
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.cboSede = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDni = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtApellidoMaterno = new DevExpress.XtraEditors.TextEdit();
            this.txtApellidoPaterno = new DevExpress.XtraEditors.TextEdit();
            this.txtNombres = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboEstado = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cboSede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoMaterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoPaterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(28, 154);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(33, 13);
            this.labelControl7.TabIndex = 29;
            this.labelControl7.Text = "Estado";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(28, 128);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(24, 13);
            this.labelControl6.TabIndex = 28;
            this.labelControl6.Text = "Sede";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(28, 102);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(18, 13);
            this.labelControl4.TabIndex = 26;
            this.labelControl4.Text = "DNI";
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(233, 177);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 25;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboSede
            // 
            this.cboSede.Location = new System.Drawing.Point(117, 125);
            this.cboSede.Name = "cboSede";
            this.cboSede.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSede.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Area")});
            this.cboSede.Properties.ShowFooter = false;
            this.cboSede.Properties.ShowHeader = false;
            this.cboSede.Size = new System.Drawing.Size(191, 20);
            this.cboSede.TabIndex = 23;
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(117, 99);
            this.txtDni.Name = "txtDni";
            this.txtDni.Properties.MaxLength = 20;
            this.txtDni.Size = new System.Drawing.Size(191, 20);
            this.txtDni.TabIndex = 21;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(28, 76);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 13);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = "Apellido materno";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(28, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 13);
            this.labelControl2.TabIndex = 19;
            this.labelControl2.Text = "Apellido paterno";
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.Location = new System.Drawing.Point(117, 73);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(191, 20);
            this.txtApellidoMaterno.TabIndex = 18;
            this.txtApellidoMaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoMaterno_KeyPress);
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.Location = new System.Drawing.Point(117, 47);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(191, 20);
            this.txtApellidoPaterno.TabIndex = 17;
            this.txtApellidoPaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoPaterno_KeyPress);
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(117, 21);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(191, 20);
            this.txtNombres.TabIndex = 16;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(28, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 15;
            this.labelControl1.Text = "Nombres";
            // 
            // cboEstado
            // 
            this.cboEstado.Location = new System.Drawing.Point(117, 151);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEstado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Estado")});
            this.cboEstado.Properties.ShowFooter = false;
            this.cboEstado.Properties.ShowHeader = false;
            this.cboEstado.Size = new System.Drawing.Size(191, 20);
            this.cboEstado.TabIndex = 24;
            // 
            // frmMantenimientoColaboradorPisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 216);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboSede);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtApellidoMaterno);
            this.Controls.Add(this.txtApellidoPaterno);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmMantenimientoColaboradorPisos";
            this.Text = "Mantenimiento colaborador pisos";
            this.Load += new System.EventHandler(this.frmMantenimientoColaboradorPisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoMaterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoPaterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.LookUpEdit cboSede;
        private DevExpress.XtraEditors.TextEdit txtDni;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtApellidoMaterno;
        private DevExpress.XtraEditors.TextEdit txtApellidoPaterno;
        private DevExpress.XtraEditors.TextEdit txtNombres;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cboEstado;
    }
}