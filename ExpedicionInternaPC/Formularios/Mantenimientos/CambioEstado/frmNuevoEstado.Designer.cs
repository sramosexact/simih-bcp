namespace ExpedicionInternaPC.Formularios.Expedicion
{
    partial class frmNuevoEstado
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
            this.lueMotivoCambioEstado = new DevExpress.XtraEditors.LookUpEdit();
            this.lblMotivo = new DevExpress.XtraEditors.LabelControl();
            this.lueEstado = new DevExpress.XtraEditors.LookUpEdit();
            this.btnCambiarEstado = new DevExpress.XtraEditors.SimpleButton();
            this.mObservacion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.lueMotivoCambioEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mObservacion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lueMotivoCambioEstado
            // 
            this.lueMotivoCambioEstado.Location = new System.Drawing.Point(133, 56);
            this.lueMotivoCambioEstado.Name = "lueMotivoCambioEstado";
            this.lueMotivoCambioEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueMotivoCambioEstado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcion", "Motivo Cambio Estado"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdMotivoCambioEstado", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lueMotivoCambioEstado.Properties.NullText = "Elija el motivo";
            this.lueMotivoCambioEstado.Properties.ShowFooter = false;
            this.lueMotivoCambioEstado.Properties.ShowHeader = false;
            this.lueMotivoCambioEstado.Size = new System.Drawing.Size(217, 20);
            this.lueMotivoCambioEstado.TabIndex = 7;
            this.lueMotivoCambioEstado.Visible = false;
            // 
            // lblMotivo
            // 
            this.lblMotivo.Appearance.BackColor = System.Drawing.Color.White;
            this.lblMotivo.Appearance.Options.UseBackColor = true;
            this.lblMotivo.Location = new System.Drawing.Point(55, 58);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(69, 13);
            this.lblMotivo.TabIndex = 6;
            this.lblMotivo.Text = "Elija el motivo:";
            this.lblMotivo.Visible = false;
            // 
            // lueEstado
            // 
            this.lueEstado.Location = new System.Drawing.Point(133, 28);
            this.lueEstado.Name = "lueEstado";
            this.lueEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueEstado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("estado", "Estado"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("IdEstado", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lueEstado.Properties.NullText = "Elija el nuevo estado";
            this.lueEstado.Properties.ShowFooter = false;
            this.lueEstado.Properties.ShowHeader = false;
            this.lueEstado.Size = new System.Drawing.Size(217, 20);
            this.lueEstado.TabIndex = 5;
            this.lueEstado.EditValueChanged += new System.EventHandler(this.lueEstado_EditValueChanged);
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.arrowrefresh32;
            this.btnCambiarEstado.Location = new System.Drawing.Point(133, 201);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(138, 47);
            this.btnCambiarEstado.TabIndex = 4;
            this.btnCambiarEstado.Text = "Cambiar estado";
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // mObservacion
            // 
            this.mObservacion.Location = new System.Drawing.Point(133, 84);
            this.mObservacion.Name = "mObservacion";
            this.mObservacion.Size = new System.Drawing.Size(217, 96);
            this.mObservacion.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(63, 85);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Observación:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Location = new System.Drawing.Point(24, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Elija el nuevo estado:";
            // 
            // frmNuevoEstado
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 258);
            this.Controls.Add(this.lueMotivoCambioEstado);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lueEstado);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.mObservacion);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "frmNuevoEstado";
            this.Text = "Nuevo estado";
            this.Load += new System.EventHandler(this.frmNuevoEstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lueMotivoCambioEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mObservacion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.MemoEdit mObservacion;
        private DevExpress.XtraEditors.SimpleButton btnCambiarEstado;
        private DevExpress.XtraEditors.LookUpEdit lueEstado;
        private DevExpress.XtraEditors.LookUpEdit lueMotivoCambioEstado;
        private DevExpress.XtraEditors.LabelControl lblMotivo;
    }
}