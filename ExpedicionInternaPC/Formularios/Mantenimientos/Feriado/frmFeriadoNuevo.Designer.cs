namespace ExpedicionInternaPC.Formularios.Mantenimientos
{
    partial class frmFeriadoNuevo
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.deFechaFeriado = new DevExpress.XtraEditors.DateEdit();
            this.meDescripcion = new DevExpress.XtraEditors.MemoEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lueTiposFeriado = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFeriado.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFeriado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTiposFeriado.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(49, 65);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(33, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Fecha:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 88);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Descripción:";
            // 
            // deFechaFeriado
            // 
            this.deFechaFeriado.EditValue = null;
            this.deFechaFeriado.Location = new System.Drawing.Point(87, 63);
            this.deFechaFeriado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deFechaFeriado.Name = "deFechaFeriado";
            this.deFechaFeriado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaFeriado.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFechaFeriado.Size = new System.Drawing.Size(177, 20);
            this.deFechaFeriado.TabIndex = 1;
            // 
            // meDescripcion
            // 
            this.meDescripcion.Location = new System.Drawing.Point(87, 87);
            this.meDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.meDescripcion.Name = "meDescripcion";
            this.meDescripcion.Size = new System.Drawing.Size(177, 83);
            this.meDescripcion.TabIndex = 2;
            this.meDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.meDescripcion_KeyPress);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton1.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.accept32;
            this.simpleButton1.Location = new System.Drawing.Point(32, 193);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(92, 31);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Ingresar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.simpleButton2.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.cancel32;
            this.simpleButton2.Location = new System.Drawing.Point(165, 193);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(92, 31);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 41);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(63, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Tipo Feriado:";
            // 
            // lueTiposFeriado
            // 
            this.lueTiposFeriado.Location = new System.Drawing.Point(87, 39);
            this.lueTiposFeriado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lueTiposFeriado.Name = "lueTiposFeriado";
            this.lueTiposFeriado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTiposFeriado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoFeriado", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoFeriado", "Tipo Feriado")});
            this.lueTiposFeriado.Properties.NullText = "Escoja el tipo de feriado";
            this.lueTiposFeriado.Size = new System.Drawing.Size(177, 20);
            this.lueTiposFeriado.TabIndex = 0;
            this.lueTiposFeriado.EditValueChanged += new System.EventHandler(this.lueTiposFeriado_EditValueChanged);
            // 
            // frmFeriadoNuevo
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 248);
            this.Controls.Add(this.lueTiposFeriado);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.meDescripcion);
            this.Controls.Add(this.deFechaFeriado);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmFeriadoNuevo";
            this.Text = "Nuevo feriado";
            this.Load += new System.EventHandler(this.frmFeriadoNuevo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFeriado.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFechaFeriado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.meDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTiposFeriado.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit deFechaFeriado;
        private DevExpress.XtraEditors.MemoEdit meDescripcion;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lueTiposFeriado;
    }
}