
namespace ExpedicionInternaPC
{
    partial class frmIngreso
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
            this.txtDni = new DevExpress.XtraEditors.TextEdit();
            this.btnRegistrar = new DevExpress.XtraEditors.SimpleButton();
            this.lblResultado = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDni
            // 
            this.txtDni.EditValue = "00000000";
            this.txtDni.Location = new System.Drawing.Point(70, 75);
            this.txtDni.Name = "txtDni";
            this.txtDni.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtDni.Properties.Appearance.Options.UseFont = true;
            this.txtDni.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDni.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDni.Size = new System.Drawing.Size(332, 30);
            this.txtDni.TabIndex = 0;
            this.txtDni.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDni_KeyDown);
            this.txtDni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDni_KeyPress);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Appearance.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRegistrar.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnRegistrar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Appearance.Options.UseBackColor = true;
            this.btnRegistrar.Appearance.Options.UseFont = true;
            this.btnRegistrar.Appearance.Options.UseForeColor = true;
            this.btnRegistrar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRegistrar.Location = new System.Drawing.Point(179, 124);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(114, 30);
            this.btnRegistrar.TabIndex = 2;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblResultado.Appearance.Options.UseFont = true;
            this.lblResultado.Appearance.Options.UseTextOptions = true;
            this.lblResultado.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblResultado.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblResultado.Location = new System.Drawing.Point(37, 175);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(399, 19);
            this.lblResultado.TabIndex = 3;
            this.lblResultado.Text = "Se registró la asistencia para";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(80, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(312, 29);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Ingrese su código de registro";
            // 
            // frmIngreso
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 236);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtDni);
            this.Name = "frmIngreso";
            this.Text = "Registrar ingreso";
            this.Load += new System.EventHandler(this.frmIngreso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDni;
        private DevExpress.XtraEditors.SimpleButton btnRegistrar;
        private DevExpress.XtraEditors.LabelControl lblResultado;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}