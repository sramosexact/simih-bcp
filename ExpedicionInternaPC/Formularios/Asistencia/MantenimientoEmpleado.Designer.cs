
namespace ExpedicionInternaPC
{
    partial class MantenimientoEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MantenimientoEmpleado));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtNombres = new DevExpress.XtraEditors.TextEdit();
            this.txtApellidoPaterno = new DevExpress.XtraEditors.TextEdit();
            this.txtApellidoMaterno = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDni = new DevExpress.XtraEditors.TextEdit();
            this.txtHoraIngreso = new DevExpress.XtraEditors.TextEdit();
            this.cboArea = new DevExpress.XtraEditors.LookUpEdit();
            this.cboEstado = new DevExpress.XtraEditors.LookUpEdit();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoPaterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoMaterno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraIngreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(21, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Nombres";
            // 
            // txtNombres
            // 
            this.txtNombres.Location = new System.Drawing.Point(110, 31);
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.Size = new System.Drawing.Size(191, 20);
            this.txtNombres.TabIndex = 1;
            this.txtNombres.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombres_KeyPress);
            // 
            // txtApellidoPaterno
            // 
            this.txtApellidoPaterno.Location = new System.Drawing.Point(110, 57);
            this.txtApellidoPaterno.Name = "txtApellidoPaterno";
            this.txtApellidoPaterno.Size = new System.Drawing.Size(191, 20);
            this.txtApellidoPaterno.TabIndex = 2;
            this.txtApellidoPaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoPaterno_KeyPress);
            // 
            // txtApellidoMaterno
            // 
            this.txtApellidoMaterno.Location = new System.Drawing.Point(110, 83);
            this.txtApellidoMaterno.Name = "txtApellidoMaterno";
            this.txtApellidoMaterno.Size = new System.Drawing.Size(191, 20);
            this.txtApellidoMaterno.TabIndex = 3;
            this.txtApellidoMaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellidoMaterno_KeyPress);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(21, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Apellido paterno";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(21, 86);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Apellido materno";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(110, 109);
            this.txtDni.Name = "txtDni";
            this.txtDni.Properties.MaxLength = 20;
            this.txtDni.Size = new System.Drawing.Size(191, 20);
            this.txtDni.TabIndex = 6;
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // txtHoraIngreso
            // 
            this.txtHoraIngreso.Location = new System.Drawing.Point(110, 135);
            this.txtHoraIngreso.Name = "txtHoraIngreso";
            this.txtHoraIngreso.Properties.Mask.EditMask = "(0?\\d|1\\d|2[0-3])\\:[0-5]\\d";
            this.txtHoraIngreso.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtHoraIngreso.Properties.MaxLength = 5;
            this.txtHoraIngreso.Size = new System.Drawing.Size(76, 20);
            this.txtHoraIngreso.TabIndex = 7;
            // 
            // cboArea
            // 
            this.cboArea.Location = new System.Drawing.Point(110, 161);
            this.cboArea.Name = "cboArea";
            this.cboArea.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboArea.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Area")});
            this.cboArea.Properties.ShowFooter = false;
            this.cboArea.Properties.ShowHeader = false;
            this.cboArea.Size = new System.Drawing.Size(191, 20);
            this.cboArea.TabIndex = 8;
            // 
            // cboEstado
            // 
            this.cboEstado.Location = new System.Drawing.Point(110, 187);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEstado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Estado")});
            this.cboEstado.Properties.ShowFooter = false;
            this.cboEstado.Properties.ShowHeader = false;
            this.cboEstado.Size = new System.Drawing.Size(191, 20);
            this.cboEstado.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(226, 224);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(21, 112);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(18, 13);
            this.labelControl4.TabIndex = 11;
            this.labelControl4.Text = "DNI";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(21, 138);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(76, 13);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Hora de ingreso";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(21, 164);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(23, 13);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Área";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(21, 190);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(33, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Estado";
            // 
            // MantenimientoEmpleado
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 259);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboArea);
            this.Controls.Add(this.txtHoraIngreso);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtApellidoMaterno);
            this.Controls.Add(this.txtApellidoPaterno);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.labelControl1);
            this.Name = "MantenimientoEmpleado";
            this.Text = "Mantenimiento empleado";
            this.Load += new System.EventHandler(this.MantenimientoEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtNombres.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoPaterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtApellidoMaterno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraIngreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtNombres;
        private DevExpress.XtraEditors.TextEdit txtApellidoPaterno;
        private DevExpress.XtraEditors.TextEdit txtApellidoMaterno;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtDni;
        private DevExpress.XtraEditors.TextEdit txtHoraIngreso;
        private DevExpress.XtraEditors.LookUpEdit cboArea;
        private DevExpress.XtraEditors.LookUpEdit cboEstado;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}