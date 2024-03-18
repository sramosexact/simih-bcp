namespace ExpedicionInternaPC
{
    partial class frmRegistroReclamo
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lueTipoReclamoUsuario = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDocumentoReferencia = new System.Windows.Forms.Label();
            this.txtDocumentoReferencia = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.btnBuscarUsuario = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dtFechaAtencion = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtFechaReclamo = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoReclamoUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentoReferencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Usuario :";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(192, 21);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Properties.Appearance.Options.UseFont = true;
            this.txtUsuario.Properties.Mask.EditMask = "[A -Z ]+";
            this.txtUsuario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtUsuario.Properties.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(225, 20);
            this.txtUsuario.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Tipo de Reclamo Usuario :";
            // 
            // lueTipoReclamoUsuario
            // 
            this.lueTipoReclamoUsuario.Location = new System.Drawing.Point(192, 118);
            this.lueTipoReclamoUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lueTipoReclamoUsuario.Name = "lueTipoReclamoUsuario";
            this.lueTipoReclamoUsuario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipoReclamoUsuario.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoReclamoUsuario", "iIdTipoReclamoUsuario", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoReclamoUsuario", "sDescripcionTipoReclamoUsuario")});
            this.lueTipoReclamoUsuario.Properties.NullText = "Seleccione";
            this.lueTipoReclamoUsuario.Properties.ShowFooter = false;
            this.lueTipoReclamoUsuario.Properties.ShowHeader = false;
            this.lueTipoReclamoUsuario.Size = new System.Drawing.Size(258, 20);
            this.lueTipoReclamoUsuario.TabIndex = 24;
            this.lueTipoReclamoUsuario.EditValueChanged += new System.EventHandler(this.lueTipoReclamoUsuario_EditValueChanged);
            // 
            // lblDocumentoReferencia
            // 
            this.lblDocumentoReferencia.AutoSize = true;
            this.lblDocumentoReferencia.Location = new System.Drawing.Point(40, 154);
            this.lblDocumentoReferencia.Name = "lblDocumentoReferencia";
            this.lblDocumentoReferencia.Size = new System.Drawing.Size(143, 13);
            this.lblDocumentoReferencia.TabIndex = 25;
            this.lblDocumentoReferencia.Text = "Documento de referencia :";
            // 
            // txtDocumentoReferencia
            // 
            this.txtDocumentoReferencia.Location = new System.Drawing.Point(191, 152);
            this.txtDocumentoReferencia.Name = "txtDocumentoReferencia";
            this.txtDocumentoReferencia.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentoReferencia.Properties.Appearance.Options.UseFont = true;
            this.txtDocumentoReferencia.Properties.Mask.EditMask = "[A -Z ]+";
            this.txtDocumentoReferencia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDocumentoReferencia.Size = new System.Drawing.Size(259, 20);
            this.txtDocumentoReferencia.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Detalle Reclamo :";
            // 
            // memoEdit1
            // 
            this.memoEdit1.EditValue = "";
            this.memoEdit1.Location = new System.Drawing.Point(192, 196);
            this.memoEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(258, 126);
            this.memoEdit1.TabIndex = 28;
            // 
            // btnBuscarUsuario
            // 
            this.btnBuscarUsuario.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.btnBuscarUsuario.Appearance.Options.UseForeColor = true;
            this.btnBuscarUsuario.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBuscarUsuario.Location = new System.Drawing.Point(423, 21);
            this.btnBuscarUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarUsuario.Name = "btnBuscarUsuario";
            this.btnBuscarUsuario.Size = new System.Drawing.Size(27, 17);
            this.btnBuscarUsuario.TabIndex = 29;
            this.btnBuscarUsuario.Text = "...";
            this.btnBuscarUsuario.Click += new System.EventHandler(this.btnBuscarUsuario_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.cancel32;
            this.simpleButton2.Location = new System.Drawing.Point(249, 339);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(91, 32);
            this.simpleButton2.TabIndex = 31;
            this.simpleButton2.Text = "Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.ApplyDev32;
            this.simpleButton1.Location = new System.Drawing.Point(135, 339);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(91, 32);
            this.simpleButton1.TabIndex = 30;
            this.simpleButton1.Text = "Registrar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dtFechaAtencion
            // 
            this.dtFechaAtencion.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaAtencion.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtFechaAtencion.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaAtencion.Location = new System.Drawing.Point(192, 52);
            this.dtFechaAtencion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFechaAtencion.MaxDate = new System.DateTime(2018, 6, 5, 0, 0, 0, 0);
            this.dtFechaAtencion.Name = "dtFechaAtencion";
            this.dtFechaAtencion.Size = new System.Drawing.Size(259, 21);
            this.dtFechaAtencion.TabIndex = 32;
            this.dtFechaAtencion.Value = new System.DateTime(2018, 6, 5, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "Fecha de Atención :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Fecha de Ingreso de Reclamo:";
            // 
            // dtFechaReclamo
            // 
            this.dtFechaReclamo.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaReclamo.CustomFormat = "dd/MM/yyyy hh:mm:ss tt";
            this.dtFechaReclamo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFechaReclamo.Location = new System.Drawing.Point(192, 78);
            this.dtFechaReclamo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtFechaReclamo.MaxDate = new System.DateTime(2018, 6, 5, 0, 0, 0, 0);
            this.dtFechaReclamo.Name = "dtFechaReclamo";
            this.dtFechaReclamo.Size = new System.Drawing.Size(259, 21);
            this.dtFechaReclamo.TabIndex = 35;
            this.dtFechaReclamo.Value = new System.DateTime(2018, 6, 5, 0, 0, 0, 0);
            // 
            // frmRegistroReclamo
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 393);
            this.Controls.Add(this.dtFechaReclamo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtFechaAtencion);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnBuscarUsuario);
            this.Controls.Add(this.memoEdit1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDocumentoReferencia);
            this.Controls.Add(this.lblDocumentoReferencia);
            this.Controls.Add(this.lueTipoReclamoUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuario);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmRegistroReclamo";
            this.Text = "Registro Reclamo";
            this.Load += new System.EventHandler(this.frmRegistroReclamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoReclamoUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentoReferencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit lueTipoReclamoUsuario;
        private System.Windows.Forms.Label lblDocumentoReferencia;
        private DevExpress.XtraEditors.TextEdit txtDocumentoReferencia;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton btnBuscarUsuario;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DateTimePicker dtFechaAtencion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtFechaReclamo;
    }
}