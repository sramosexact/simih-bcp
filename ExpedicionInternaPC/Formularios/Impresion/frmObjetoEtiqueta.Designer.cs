namespace ExpedicionInternaPC
{
    partial class frmObjetoEtiqueta
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
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.txtAutogenerado = new DevExpress.XtraEditors.TextEdit();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.txt_origen = new DevExpress.XtraEditors.TextEdit();
            this.txt_de = new DevExpress.XtraEditors.TextEdit();
            this.txt_destino = new DevExpress.XtraEditors.TextEdit();
            this.txt_para = new DevExpress.XtraEditors.TextEdit();
            this.bccCodigoBarra = new DevExpress.XtraEditors.BarCodeControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutogenerado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_origen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_de.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_destino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_para.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAutogenerado
            // 
            this.txtAutogenerado.Location = new System.Drawing.Point(120, 68);
            this.txtAutogenerado.Name = "txtAutogenerado";
            this.txtAutogenerado.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.txtAutogenerado.Properties.Appearance.Options.UseFont = true;
            this.txtAutogenerado.Properties.Appearance.Options.UseTextOptions = true;
            this.txtAutogenerado.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtAutogenerado.Properties.ReadOnly = true;
            this.txtAutogenerado.Size = new System.Drawing.Size(210, 30);
            this.txtAutogenerado.TabIndex = 36;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(231, 229);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(211, 22);
            this.btnCancelar.TabIndex = 35;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Location = new System.Drawing.Point(28, 229);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(173, 22);
            this.btnAceptar.TabIndex = 34;
            this.btnAceptar.Text = "&Imprimir Etiqueta";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txt_origen
            // 
            this.txt_origen.Enabled = false;
            this.txt_origen.Location = new System.Drawing.Point(74, 193);
            this.txt_origen.Name = "txt_origen";
            this.txt_origen.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_origen.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_origen.Properties.Appearance.Options.UseFont = true;
            this.txt_origen.Properties.Appearance.Options.UseForeColor = true;
            this.txt_origen.Size = new System.Drawing.Size(368, 20);
            this.txt_origen.TabIndex = 33;
            // 
            // txt_de
            // 
            this.txt_de.Enabled = false;
            this.txt_de.Location = new System.Drawing.Point(74, 167);
            this.txt_de.Name = "txt_de";
            this.txt_de.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_de.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_de.Properties.Appearance.Options.UseFont = true;
            this.txt_de.Properties.Appearance.Options.UseForeColor = true;
            this.txt_de.Size = new System.Drawing.Size(368, 20);
            this.txt_de.TabIndex = 32;
            // 
            // txt_destino
            // 
            this.txt_destino.Enabled = false;
            this.txt_destino.Location = new System.Drawing.Point(74, 141);
            this.txt_destino.Name = "txt_destino";
            this.txt_destino.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_destino.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_destino.Properties.Appearance.Options.UseFont = true;
            this.txt_destino.Properties.Appearance.Options.UseForeColor = true;
            this.txt_destino.Size = new System.Drawing.Size(368, 20);
            this.txt_destino.TabIndex = 31;
            // 
            // txt_para
            // 
            this.txt_para.Enabled = false;
            this.txt_para.Location = new System.Drawing.Point(74, 115);
            this.txt_para.Name = "txt_para";
            this.txt_para.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_para.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.txt_para.Properties.Appearance.Options.UseFont = true;
            this.txt_para.Properties.Appearance.Options.UseForeColor = true;
            this.txt_para.Size = new System.Drawing.Size(368, 20);
            this.txt_para.TabIndex = 30;
            // 
            // bccCodigoBarra
            // 
            this.bccCodigoBarra.BackColor = System.Drawing.Color.White;
            this.bccCodigoBarra.ForeColor = System.Drawing.Color.Black;
            this.bccCodigoBarra.HorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bccCodigoBarra.Location = new System.Drawing.Point(120, 11);
            this.bccCodigoBarra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bccCodigoBarra.Module = 1D;
            this.bccCodigoBarra.Name = "bccCodigoBarra";
            this.bccCodigoBarra.Padding = new System.Windows.Forms.Padding(9, 2, 9, 0);
            this.bccCodigoBarra.Size = new System.Drawing.Size(210, 52);
            this.bccCodigoBarra.Symbology = code128Generator1;
            this.bccCodigoBarra.TabIndex = 29;
            this.bccCodigoBarra.VerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            this.bccCodigoBarra.VerticalTextAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 38;
            this.label1.Text = "Para :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(15, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 39;
            this.label2.Text = "De :";
            // 
            // frmObjetoEtiqueta
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 263);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAutogenerado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txt_origen);
            this.Controls.Add(this.txt_de);
            this.Controls.Add(this.txt_destino);
            this.Controls.Add(this.txt_para);
            this.Controls.Add(this.bccCodigoBarra);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmObjetoEtiqueta";
            this.ShowIcon = false;
            this.Text = "Etiqueta de Autogenerado";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmObjetoEtiqueta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtAutogenerado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_origen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_de.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_destino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_para.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtAutogenerado;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.TextEdit txt_origen;
        private DevExpress.XtraEditors.TextEdit txt_de;
        private DevExpress.XtraEditors.TextEdit txt_destino;
        private DevExpress.XtraEditors.TextEdit txt_para;
        private DevExpress.XtraEditors.BarCodeControl bccCodigoBarra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}