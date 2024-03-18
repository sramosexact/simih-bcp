
namespace ExpedicionInternaPC
{
    partial class frmSeleccionDispositivoMovil
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
            this.btnAndroid = new System.Windows.Forms.Button();
            this.btnWindowsMobile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Seleccione el dispositivo móvil:";
            // 
            // btnAndroid
            // 
            this.btnAndroid.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnAndroid.ForeColor = System.Drawing.Color.White;
            this.btnAndroid.Location = new System.Drawing.Point(168, 65);
            this.btnAndroid.Name = "btnAndroid";
            this.btnAndroid.Size = new System.Drawing.Size(150, 38);
            this.btnAndroid.TabIndex = 4;
            this.btnAndroid.Text = "PDA - Android";
            this.btnAndroid.UseVisualStyleBackColor = false;
            this.btnAndroid.Click += new System.EventHandler(this.btnAndroid_Click);
            // 
            // btnWindowsMobile
            // 
            this.btnWindowsMobile.BackColor = System.Drawing.Color.SteelBlue;
            this.btnWindowsMobile.ForeColor = System.Drawing.Color.White;
            this.btnWindowsMobile.Location = new System.Drawing.Point(12, 65);
            this.btnWindowsMobile.Name = "btnWindowsMobile";
            this.btnWindowsMobile.Size = new System.Drawing.Size(150, 38);
            this.btnWindowsMobile.TabIndex = 3;
            this.btnWindowsMobile.Text = "PDA - Windows Mobile";
            this.btnWindowsMobile.UseVisualStyleBackColor = false;
            this.btnWindowsMobile.Click += new System.EventHandler(this.btnWindowsMobile_Click);
            // 
            // frmSeleccionDispositivoMovil
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 119);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAndroid);
            this.Controls.Add(this.btnWindowsMobile);
            this.Name = "frmSeleccionDispositivoMovil";
            this.Text = "Dispositivos móviles";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAndroid;
        private System.Windows.Forms.Button btnWindowsMobile;
    }
}