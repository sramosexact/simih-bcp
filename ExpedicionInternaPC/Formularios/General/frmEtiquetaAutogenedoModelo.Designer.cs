
namespace ExpedicionInternaPC
{
    partial class frmEtiquetaAutogenedoModelo
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.lblPara = new System.Windows.Forms.Label();
            this.lblAreaDestino = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblAreaOrigen = new System.Windows.Forms.Label();
            this.lblAutogeneradoCB = new System.Windows.Forms.Label();
            this.lblAutogenerado = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Para:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "De:";
            // 
            // lblDestino
            // 
            this.lblDestino.Location = new System.Drawing.Point(87, 117);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(349, 23);
            this.lblDestino.TabIndex = 1;
            this.lblDestino.Text = "label3";
            // 
            // lblPara
            // 
            this.lblPara.Location = new System.Drawing.Point(87, 140);
            this.lblPara.Name = "lblPara";
            this.lblPara.Size = new System.Drawing.Size(349, 23);
            this.lblPara.TabIndex = 1;
            this.lblPara.Text = "label3";
            // 
            // lblAreaDestino
            // 
            this.lblAreaDestino.Location = new System.Drawing.Point(87, 163);
            this.lblAreaDestino.Name = "lblAreaDestino";
            this.lblAreaDestino.Size = new System.Drawing.Size(349, 23);
            this.lblAreaDestino.TabIndex = 1;
            this.lblAreaDestino.Text = "label3";
            // 
            // lblDe
            // 
            this.lblDe.Location = new System.Drawing.Point(87, 202);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(349, 23);
            this.lblDe.TabIndex = 1;
            this.lblDe.Text = "label3";
            // 
            // lblAreaOrigen
            // 
            this.lblAreaOrigen.Location = new System.Drawing.Point(87, 225);
            this.lblAreaOrigen.Name = "lblAreaOrigen";
            this.lblAreaOrigen.Size = new System.Drawing.Size(349, 23);
            this.lblAreaOrigen.TabIndex = 1;
            this.lblAreaOrigen.Text = "label3";
            // 
            // lblAutogeneradoCB
            // 
            this.lblAutogeneradoCB.Font = new System.Drawing.Font("Código de Barras 3/9", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutogeneradoCB.Location = new System.Drawing.Point(57, 9);
            this.lblAutogeneradoCB.Name = "lblAutogeneradoCB";
            this.lblAutogeneradoCB.Size = new System.Drawing.Size(365, 61);
            this.lblAutogeneradoCB.TabIndex = 1;
            this.lblAutogeneradoCB.Text = "label3";
            this.lblAutogeneradoCB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAutogenerado
            // 
            this.lblAutogenerado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutogenerado.Location = new System.Drawing.Point(60, 74);
            this.lblAutogenerado.Name = "lblAutogenerado";
            this.lblAutogenerado.Size = new System.Drawing.Size(349, 23);
            this.lblAutogenerado.TabIndex = 1;
            this.lblAutogenerado.Text = "label3";
            this.lblAutogenerado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEtiquetaAutogenedoModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 285);
            this.Controls.Add(this.lblAreaOrigen);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.lblAreaDestino);
            this.Controls.Add(this.lblPara);
            this.Controls.Add(this.lblAutogenerado);
            this.Controls.Add(this.lblAutogeneradoCB);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEtiquetaAutogenedoModelo";
            this.Text = "frmEtiquetaAutogenedoModelo";
            this.Load += new System.EventHandler(this.frmEtiquetaAutogenedoModelo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.Label lblPara;
        private System.Windows.Forms.Label lblAreaDestino;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblAreaOrigen;
        private System.Windows.Forms.Label lblAutogeneradoCB;
        private System.Windows.Forms.Label lblAutogenerado;
    }
}