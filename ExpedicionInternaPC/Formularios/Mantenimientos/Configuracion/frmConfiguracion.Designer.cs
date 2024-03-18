namespace ExpedicionInternaPC
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnGuardarRuta = new DevExpress.XtraEditors.SimpleButton();
            this.txtRuta = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.txtTiempo = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnGuardarIndicador = new DevExpress.XtraEditors.SimpleButton();
            this.lueIndicadores = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.spinTiempoConfirmacion = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnGuardarConfirmacion = new DevExpress.XtraEditors.SimpleButton();
            this.lueConfirmacion = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuta.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiempo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIndicadores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinTiempoConfirmacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueConfirmacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.CancelDev32, "CancelDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "CancelDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.EditDevX32, "EditDevX32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "EditDevX32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "SaveDev32");
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnGuardarRuta);
            this.groupControl1.Controls.Add(this.txtRuta);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(526, 131);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Impresora Zebra";
            // 
            // btnGuardarRuta
            // 
            this.btnGuardarRuta.Location = new System.Drawing.Point(188, 95);
            this.btnGuardarRuta.Name = "btnGuardarRuta";
            this.btnGuardarRuta.Size = new System.Drawing.Size(155, 23);
            this.btnGuardarRuta.TabIndex = 5;
            this.btnGuardarRuta.Text = "Guardar";
            this.btnGuardarRuta.Click += new System.EventHandler(this.btnGuardarRuta_Click);
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(97, 54);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(381, 22);
            this.txtRuta.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(55, 57);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ruta";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.txtTiempo);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.btnGuardarIndicador);
            this.groupControl2.Controls.Add(this.lueIndicadores);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Location = new System.Drawing.Point(13, 160);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(526, 145);
            this.groupControl2.TabIndex = 2;
            this.groupControl2.Text = "Indicadores";
            // 
            // txtTiempo
            // 
            this.txtTiempo.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtTiempo.Location = new System.Drawing.Point(407, 61);
            this.txtTiempo.Name = "txtTiempo";
            this.txtTiempo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTiempo.Size = new System.Drawing.Size(70, 22);
            this.txtTiempo.TabIndex = 8;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(483, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(18, 16);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "hrs";
            // 
            // btnGuardarIndicador
            // 
            this.btnGuardarIndicador.Location = new System.Drawing.Point(187, 108);
            this.btnGuardarIndicador.Name = "btnGuardarIndicador";
            this.btnGuardarIndicador.Size = new System.Drawing.Size(155, 23);
            this.btnGuardarIndicador.TabIndex = 6;
            this.btnGuardarIndicador.Text = "Guardar";
            this.btnGuardarIndicador.Click += new System.EventHandler(this.btnGuardarIndicador_Click);
            // 
            // lueIndicadores
            // 
            this.lueIndicadores.Location = new System.Drawing.Point(96, 58);
            this.lueIndicadores.Name = "lueIndicadores";
            this.lueIndicadores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueIndicadores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Indicador")});
            this.lueIndicadores.Properties.NullText = "Seleccione";
            this.lueIndicadores.Size = new System.Drawing.Size(246, 22);
            this.lueIndicadores.TabIndex = 3;
            this.lueIndicadores.EditValueChanged += new System.EventHandler(this.lueIndicadores_EditValueChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(358, 61);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(43, 16);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Tiempo";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(27, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(53, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Indicador";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.spinTiempoConfirmacion);
            this.groupControl3.Controls.Add(this.labelControl5);
            this.groupControl3.Controls.Add(this.btnGuardarConfirmacion);
            this.groupControl3.Controls.Add(this.lueConfirmacion);
            this.groupControl3.Controls.Add(this.labelControl6);
            this.groupControl3.Controls.Add(this.labelControl7);
            this.groupControl3.Location = new System.Drawing.Point(13, 324);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(526, 146);
            this.groupControl3.TabIndex = 9;
            this.groupControl3.Text = "Confirmación Automática";
            // 
            // spinTiempoConfirmacion
            // 
            this.spinTiempoConfirmacion.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinTiempoConfirmacion.Location = new System.Drawing.Point(407, 61);
            this.spinTiempoConfirmacion.Name = "spinTiempoConfirmacion";
            this.spinTiempoConfirmacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinTiempoConfirmacion.Size = new System.Drawing.Size(70, 22);
            this.spinTiempoConfirmacion.TabIndex = 8;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(483, 64);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(23, 16);
            this.labelControl5.TabIndex = 7;
            this.labelControl5.Text = "días";
            // 
            // btnGuardarConfirmacion
            // 
            this.btnGuardarConfirmacion.Location = new System.Drawing.Point(187, 108);
            this.btnGuardarConfirmacion.Name = "btnGuardarConfirmacion";
            this.btnGuardarConfirmacion.Size = new System.Drawing.Size(155, 23);
            this.btnGuardarConfirmacion.TabIndex = 6;
            this.btnGuardarConfirmacion.Text = "Guardar";
            this.btnGuardarConfirmacion.Click += new System.EventHandler(this.btnGuardarConfirmacion_Click);
            // 
            // lueConfirmacion
            // 
            this.lueConfirmacion.Location = new System.Drawing.Point(96, 58);
            this.lueConfirmacion.Name = "lueConfirmacion";
            this.lueConfirmacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueConfirmacion.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Indicador")});
            this.lueConfirmacion.Properties.NullText = "Seleccione";
            this.lueConfirmacion.Size = new System.Drawing.Size(246, 22);
            this.lueConfirmacion.TabIndex = 3;
            this.lueConfirmacion.EditValueChanged += new System.EventHandler(this.lueConfirmacion_EditValueChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(358, 61);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(43, 16);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Tiempo";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(38, 61);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(42, 16);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Destino";
            // 
            // frmConfiguracion
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 482);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmConfiguracion";
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRuta.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiempo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueIndicadores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            this.groupControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinTiempoConfirmacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueConfirmacion.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnGuardarRuta;
        private DevExpress.XtraEditors.TextEdit txtRuta;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnGuardarIndicador;
        private DevExpress.XtraEditors.LookUpEdit lueIndicadores;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SpinEdit txtTiempo;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.SpinEdit spinTiempoConfirmacion;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnGuardarConfirmacion;
        private DevExpress.XtraEditors.LookUpEdit lueConfirmacion;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}