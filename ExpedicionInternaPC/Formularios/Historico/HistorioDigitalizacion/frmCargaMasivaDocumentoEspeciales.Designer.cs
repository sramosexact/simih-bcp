namespace ExpedicionInternaPC.Formularios.Mesa_de_Partes
{
    partial class frmCargaMasivaDocumentoEspeciales
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
            this.cboTipoDocumento = new DevExpress.XtraEditors.LookUpEdit();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtRutaArchivo = new DevExpress.XtraEditors.TextEdit();
            this.btnSeleccionarArchivo = new DevExpress.XtraEditors.SimpleButton();
            this.btnCargarDocumentos = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaArchivo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.Location = new System.Drawing.Point(26, 49);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.cboTipoDocumento.Properties.Appearance.Options.UseFont = true;
            this.cboTipoDocumento.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTipoDocumento.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoDocumento", "Nombre1", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoDocumento", "Nombre2")});
            this.cboTipoDocumento.Properties.NullText = "";
            this.cboTipoDocumento.Properties.ShowFooter = false;
            this.cboTipoDocumento.Properties.ShowHeader = false;
            this.cboTipoDocumento.Size = new System.Drawing.Size(346, 22);
            this.cboTipoDocumento.TabIndex = 0;
            this.cboTipoDocumento.EditValueChanged += new System.EventHandler(this.cboTipoDocumento_EditValueChanged);
            // 
            // radioGroup1
            // 
            this.radioGroup1.Location = new System.Drawing.Point(26, 157);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Crear un autogenerado por cada documento"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Crear solo un autogenerado por todos los documentos")});
            this.radioGroup1.Size = new System.Drawing.Size(346, 72);
            this.radioGroup1.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(26, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(110, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tipo de documento";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(26, 92);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(164, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Seleccionar archivo de datos";
            // 
            // txtRutaArchivo
            // 
            this.txtRutaArchivo.Location = new System.Drawing.Point(26, 114);
            this.txtRutaArchivo.Name = "txtRutaArchivo";
            this.txtRutaArchivo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.txtRutaArchivo.Properties.Appearance.Options.UseFont = true;
            this.txtRutaArchivo.Properties.ReadOnly = true;
            this.txtRutaArchivo.Size = new System.Drawing.Size(307, 22);
            this.txtRutaArchivo.TabIndex = 4;
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.btnSeleccionarArchivo.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnSeleccionarArchivo.Appearance.Options.UseBackColor = true;
            this.btnSeleccionarArchivo.Appearance.Options.UseFont = true;
            this.btnSeleccionarArchivo.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(333, 113);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(39, 23);
            this.btnSeleccionarArchivo.TabIndex = 5;
            this.btnSeleccionarArchivo.Text = "...";
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // btnCargarDocumentos
            // 
            this.btnCargarDocumentos.Appearance.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCargarDocumentos.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.btnCargarDocumentos.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCargarDocumentos.Appearance.Options.UseBackColor = true;
            this.btnCargarDocumentos.Appearance.Options.UseFont = true;
            this.btnCargarDocumentos.Appearance.Options.UseForeColor = true;
            this.btnCargarDocumentos.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCargarDocumentos.Location = new System.Drawing.Point(138, 244);
            this.btnCargarDocumentos.Name = "btnCargarDocumentos";
            this.btnCargarDocumentos.Size = new System.Drawing.Size(106, 36);
            this.btnCargarDocumentos.TabIndex = 6;
            this.btnCargarDocumentos.Text = "Cargar archivo";
            this.btnCargarDocumentos.Click += new System.EventHandler(this.btnCargarDocumentos_Click);
            // 
            // frmCargaMasivaDocumentoEspeciales
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 292);
            this.Controls.Add(this.btnCargarDocumentos);
            this.Controls.Add(this.btnSeleccionarArchivo);
            this.Controls.Add(this.txtRutaArchivo);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.cboTipoDocumento);
            this.Name = "frmCargaMasivaDocumentoEspeciales";
            this.Text = "Documentos especiales - Carga de archivo";
            this.Load += new System.EventHandler(this.frmCargaMasivaDocumentoEspeciales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboTipoDocumento.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRutaArchivo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboTipoDocumento;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtRutaArchivo;
        private DevExpress.XtraEditors.SimpleButton btnSeleccionarArchivo;
        private DevExpress.XtraEditors.SimpleButton btnCargarDocumentos;
    }
}