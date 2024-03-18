namespace ExpedicionInternaPC
{
    partial class frmAgregarPuntoEntrega
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgregarPuntoEntrega));
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.txtArea = new DevExpress.XtraEditors.TextEdit();
            this.txtOficina = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOficina.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAgregar.ImageIndex = 0;
            this.btnAgregar.ImageList = this.imageCollection1;
            this.btnAgregar.Location = new System.Drawing.Point(155, 85);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(145, 38);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.Text = "&Guardar";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "SaveDev32");
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(80, 59);
            this.txtArea.Name = "txtArea";
            this.txtArea.Properties.Mask.EditMask = "[0-9 A-Z\\-]*";
            this.txtArea.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtArea.Size = new System.Drawing.Size(220, 20);
            this.txtArea.TabIndex = 5;
            this.txtArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArea_KeyPress);
            // 
            // txtOficina
            // 
            this.txtOficina.Location = new System.Drawing.Point(80, 33);
            this.txtOficina.Name = "txtOficina";
            this.txtOficina.Properties.Mask.EditMask = "[0-9 A-Z\\-]*";
            this.txtOficina.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtOficina.Size = new System.Drawing.Size(220, 20);
            this.txtOficina.TabIndex = 4;
            this.txtOficina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOficina_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 36);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Ubicación";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(27, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Área:";
            // 
            // frmAgregarPuntoEntrega
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 135);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.txtOficina);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmAgregarPuntoEntrega";
            this.Text = "Editar punto de entrega";
            this.Load += new System.EventHandler(this.frmAgregarPuntoEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOficina.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraEditors.TextEdit txtArea;
        private DevExpress.XtraEditors.TextEdit txtOficina;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}