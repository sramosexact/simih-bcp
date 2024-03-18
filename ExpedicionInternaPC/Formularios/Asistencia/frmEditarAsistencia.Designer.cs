
namespace ExpedicionInternaPC
{
    partial class frmEditarAsistencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditarAsistencia));
            this.txtColaborador = new DevExpress.XtraEditors.TextEdit();
            this.cboFechaIngreso = new DevExpress.XtraEditors.DateEdit();
            this.txtHoraIngreso = new DevExpress.XtraEditors.TextEdit();
            this.cboFechaSalida = new DevExpress.XtraEditors.DateEdit();
            this.txtHoraSalida = new DevExpress.XtraEditors.TextEdit();
            this.cboUbicacion = new DevExpress.XtraEditors.LookUpEdit();
            this.cboEstado = new DevExpress.XtraEditors.LookUpEdit();
            this.txtObservacion = new DevExpress.XtraEditors.TextEdit();
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtColaborador.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaIngreso.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaIngreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraIngreso.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaSalida.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaSalida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraSalida.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUbicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtColaborador
            // 
            this.txtColaborador.Location = new System.Drawing.Point(87, 28);
            this.txtColaborador.Name = "txtColaborador";
            this.txtColaborador.Size = new System.Drawing.Size(193, 20);
            this.txtColaborador.TabIndex = 0;
            // 
            // cboFechaIngreso
            // 
            this.cboFechaIngreso.EditValue = null;
            this.cboFechaIngreso.Location = new System.Drawing.Point(87, 54);
            this.cboFechaIngreso.Name = "cboFechaIngreso";
            this.cboFechaIngreso.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFechaIngreso.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFechaIngreso.Size = new System.Drawing.Size(193, 20);
            this.cboFechaIngreso.TabIndex = 1;
            // 
            // txtHoraIngreso
            // 
            this.txtHoraIngreso.Location = new System.Drawing.Point(87, 80);
            this.txtHoraIngreso.Name = "txtHoraIngreso";
            this.txtHoraIngreso.Size = new System.Drawing.Size(193, 20);
            this.txtHoraIngreso.TabIndex = 2;
            // 
            // cboFechaSalida
            // 
            this.cboFechaSalida.EditValue = null;
            this.cboFechaSalida.Location = new System.Drawing.Point(87, 106);
            this.cboFechaSalida.Name = "cboFechaSalida";
            this.cboFechaSalida.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFechaSalida.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboFechaSalida.Size = new System.Drawing.Size(193, 20);
            this.cboFechaSalida.TabIndex = 3;
            // 
            // txtHoraSalida
            // 
            this.txtHoraSalida.Location = new System.Drawing.Point(87, 132);
            this.txtHoraSalida.Name = "txtHoraSalida";
            this.txtHoraSalida.Size = new System.Drawing.Size(193, 20);
            this.txtHoraSalida.TabIndex = 4;
            // 
            // cboUbicacion
            // 
            this.cboUbicacion.Location = new System.Drawing.Point(87, 158);
            this.cboUbicacion.Name = "cboUbicacion";
            this.cboUbicacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboUbicacion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.cboUbicacion.Properties.ShowFooter = false;
            this.cboUbicacion.Properties.ShowHeader = false;
            this.cboUbicacion.Size = new System.Drawing.Size(193, 20);
            this.cboUbicacion.TabIndex = 5;
            // 
            // cboEstado
            // 
            this.cboEstado.Location = new System.Drawing.Point(87, 184);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboEstado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboEstado.Properties.ShowFooter = false;
            this.cboEstado.Properties.ShowHeader = false;
            this.cboEstado.Size = new System.Drawing.Size(193, 20);
            this.cboEstado.TabIndex = 6;
            // 
            // txtObservacion
            // 
            this.txtObservacion.Location = new System.Drawing.Point(87, 210);
            this.txtObservacion.Name = "txtObservacion";
            this.txtObservacion.Properties.MaxLength = 250;
            this.txtObservacion.Size = new System.Drawing.Size(193, 20);
            this.txtObservacion.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.ImageOptions.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(205, 249);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Colaborador";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(67, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Fecha ingreso";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 83);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(61, 13);
            this.labelControl3.TabIndex = 11;
            this.labelControl3.Text = "Hora ingreso";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 109);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(59, 13);
            this.labelControl4.TabIndex = 12;
            this.labelControl4.Text = "Fecha salida";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 135);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 13);
            this.labelControl5.TabIndex = 13;
            this.labelControl5.Text = "Hora salida";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 161);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(45, 13);
            this.labelControl6.TabIndex = 14;
            this.labelControl6.Text = "Ubicación";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(13, 187);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(33, 13);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "Estado";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(13, 213);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(60, 13);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "Observación";
            // 
            // frmEditarAsistencia
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 289);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtObservacion);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboUbicacion);
            this.Controls.Add(this.txtHoraSalida);
            this.Controls.Add(this.cboFechaSalida);
            this.Controls.Add(this.txtHoraIngreso);
            this.Controls.Add(this.cboFechaIngreso);
            this.Controls.Add(this.txtColaborador);
            this.Name = "frmEditarAsistencia";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmEditarAsistencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtColaborador.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaIngreso.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaIngreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraIngreso.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaSalida.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboFechaSalida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoraSalida.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboUbicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtObservacion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtColaborador;
        private DevExpress.XtraEditors.DateEdit cboFechaIngreso;
        private DevExpress.XtraEditors.TextEdit txtHoraIngreso;
        private DevExpress.XtraEditors.DateEdit cboFechaSalida;
        private DevExpress.XtraEditors.TextEdit txtHoraSalida;
        private DevExpress.XtraEditors.LookUpEdit cboUbicacion;
        private DevExpress.XtraEditors.LookUpEdit cboEstado;
        private DevExpress.XtraEditors.TextEdit txtObservacion;
        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
    }
}