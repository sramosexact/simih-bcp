
namespace ExpedicionInternaPC
{
    partial class frmRegistrarRecorrido
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
            this.cboSede = new DevExpress.XtraEditors.LookUpEdit();
            this.cboHorario = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDni = new DevExpress.XtraEditors.TextEdit();
            this.btnRegistrar = new DevExpress.XtraEditors.SimpleButton();
            this.lblResultado = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboSede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHorario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSede
            // 
            this.cboSede.Location = new System.Drawing.Point(65, 32);
            this.cboSede.Name = "cboSede";
            this.cboSede.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSede.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.cboSede.Properties.NullText = "";
            this.cboSede.Properties.NullValuePrompt = "Sede";
            this.cboSede.Properties.NullValuePromptShowForEmptyValue = true;
            this.cboSede.Properties.ShowFooter = false;
            this.cboSede.Properties.ShowHeader = false;
            this.cboSede.Size = new System.Drawing.Size(339, 20);
            this.cboSede.TabIndex = 1;
            this.cboSede.EditValueChanged += new System.EventHandler(this.cboSede_EditValueChanged);
            // 
            // cboHorario
            // 
            this.cboHorario.Location = new System.Drawing.Point(65, 64);
            this.cboHorario.Name = "cboHorario";
            this.cboHorario.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboHorario.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboHorario.Properties.NullText = "";
            this.cboHorario.Properties.NullValuePrompt = "Horario";
            this.cboHorario.Properties.NullValuePromptShowForEmptyValue = true;
            this.cboHorario.Properties.ShowFooter = false;
            this.cboHorario.Properties.ShowHeader = false;
            this.cboHorario.Size = new System.Drawing.Size(339, 20);
            this.cboHorario.TabIndex = 3;
            // 
            // txtDni
            // 
            this.txtDni.EditValue = "";
            this.txtDni.Location = new System.Drawing.Point(65, 101);
            this.txtDni.Name = "txtDni";
            this.txtDni.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtDni.Properties.Appearance.Options.UseFont = true;
            this.txtDni.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDni.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDni.Size = new System.Drawing.Size(339, 30);
            this.txtDni.TabIndex = 5;
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
            this.btnRegistrar.Location = new System.Drawing.Point(152, 146);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(137, 28);
            this.btnRegistrar.TabIndex = 7;
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
            this.lblResultado.Location = new System.Drawing.Point(28, 191);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(399, 19);
            this.lblResultado.TabIndex = 8;
            this.lblResultado.Text = "Se registró el recorrido para";
            // 
            // frmRegistrarRecorrido
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 252);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtDni);
            this.Controls.Add(this.cboHorario);
            this.Controls.Add(this.cboSede);
            this.Name = "frmRegistrarRecorrido";
            this.Text = "Registrar inicio de recorrido";
            this.Load += new System.EventHandler(this.frmRegistrarRecorrido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHorario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDni.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.LookUpEdit cboSede;
        private DevExpress.XtraEditors.LookUpEdit cboHorario;
        private DevExpress.XtraEditors.TextEdit txtDni;
        private DevExpress.XtraEditors.SimpleButton btnRegistrar;
        private DevExpress.XtraEditors.LabelControl lblResultado;
    }
}