namespace ExpedicionInternaPC
{
    partial class frmIngresoEstadoReporte
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
            this.luePeriodo = new ExpedicionInternaPC.Formularios.Controles_Comunes.LookUpPeriodo();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCajasServicio = new DevExpress.XtraEditors.SimpleButton();
            this.panelReportes = new System.Windows.Forms.Panel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.luePeriodo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // luePeriodo
            // 
            this.luePeriodo.Location = new System.Drawing.Point(121, 19);
            this.luePeriodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.luePeriodo.Name = "luePeriodo";
            this.luePeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePeriodo.Size = new System.Drawing.Size(144, 20);
            this.luePeriodo.TabIndex = 5;
            this.luePeriodo.EditValueChanged += new System.EventHandler(this.luePeriodo_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(65, 21);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Periodo";
            // 
            // btnCajasServicio
            // 
            this.btnCajasServicio.Appearance.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCajasServicio.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCajasServicio.Appearance.Options.UseBackColor = true;
            this.btnCajasServicio.Appearance.Options.UseForeColor = true;
            this.btnCajasServicio.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCajasServicio.Location = new System.Drawing.Point(165, 63);
            this.btnCajasServicio.Name = "btnCajasServicio";
            this.btnCajasServicio.Size = new System.Drawing.Size(99, 27);
            this.btnCajasServicio.TabIndex = 7;
            this.btnCajasServicio.Text = "Guardar";
            this.btnCajasServicio.Click += new System.EventHandler(this.btnCajasServicio_Click);
            // 
            // panelReportes
            // 
            this.panelReportes.AutoScroll = true;
            this.panelReportes.BackColor = System.Drawing.Color.White;
            this.panelReportes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelReportes.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.panelReportes.Location = new System.Drawing.Point(0, 87);
            this.panelReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportes.Name = "panelReportes";
            this.panelReportes.Size = new System.Drawing.Size(820, 503);
            this.panelReportes.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(23, 68);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Resumen";
            // 
            // frmIngresoEstadoReporte
            // 
            this.Appearance.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Appearance.Options.UseFont = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 590);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelReportes);
            this.Controls.Add(this.btnCajasServicio);
            this.Controls.Add(this.luePeriodo);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmIngresoEstadoReporte";
            this.Text = "Cumplimiento de Reportes";
            this.Load += new System.EventHandler(this.frmIngresoEstadoReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luePeriodo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Formularios.Controles_Comunes.LookUpPeriodo luePeriodo;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCajasServicio;
        private System.Windows.Forms.Panel panelReportes;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}