namespace ExpedicionInternaPC
{
    partial class frmNuevaEntregaSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNuevaEntregaSucursal));
            this.cboSucursales = new DevExpress.XtraEditors.LookUpEdit();
            this.cboColaboradores = new DevExpress.XtraEditors.LookUpEdit();
            this.btnAccion = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboSucursales.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboColaboradores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSucursales
            // 
            this.cboSucursales.Location = new System.Drawing.Point(97, 34);
            this.cboSucursales.Name = "cboSucursales";
            this.cboSucursales.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboSucursales.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.cboSucursales.Properties.NullText = "";
            this.cboSucursales.Properties.ShowFooter = false;
            this.cboSucursales.Properties.ShowHeader = false;
            this.cboSucursales.Size = new System.Drawing.Size(254, 20);
            this.cboSucursales.TabIndex = 4;
            // 
            // cboColaboradores
            // 
            this.cboColaboradores.Location = new System.Drawing.Point(97, 76);
            this.cboColaboradores.Name = "cboColaboradores";
            this.cboColaboradores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboColaboradores.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Codigo")});
            this.cboColaboradores.Properties.NullText = "";
            this.cboColaboradores.Properties.ShowFooter = false;
            this.cboColaboradores.Properties.ShowHeader = false;
            this.cboColaboradores.Size = new System.Drawing.Size(254, 20);
            this.cboColaboradores.TabIndex = 5;
            // 
            // btnAccion
            // 
            this.btnAccion.Appearance.BackColor = System.Drawing.Color.White;
            this.btnAccion.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnAccion.Appearance.Options.UseBackColor = true;
            this.btnAccion.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAccion.ImageIndex = 3;
            this.btnAccion.ImageList = this.imageCollection1;
            this.btnAccion.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAccion.Location = new System.Drawing.Point(66, 122);
            this.btnAccion.Name = "btnAccion";
            this.btnAccion.Size = new System.Drawing.Size(113, 44);
            this.btnAccion.TabIndex = 6;
            this.btnAccion.Text = "Crear";
            this.btnAccion.Click += new System.EventHandler(this.btnAccion_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.cancel32, "cancel32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "cancel32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.saveas32, "saveas32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "saveas32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.CancelDev32, "CancelDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "CancelDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 3);
            this.imageCollection1.Images.SetKeyName(3, "SaveDev32");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Appearance.BackColor = System.Drawing.Color.White;
            this.btnCancelar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnCancelar.Appearance.Options.UseBackColor = true;
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.ImageIndex = 2;
            this.btnCancelar.ImageList = this.imageCollection1;
            this.btnCancelar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCancelar.Location = new System.Drawing.Point(200, 122);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 44);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Sucursal";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 79);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Operativo";
            // 
            // frmNuevaEntregaSucursal
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 187);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cboSucursales);
            this.Controls.Add(this.cboColaboradores);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAccion);
            this.Name = "frmNuevaEntregaSucursal";
            this.Text = "frmNuevaEntregaSucursal";
            this.Load += new System.EventHandler(this.frmNuevaEntregaSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboSucursales.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboColaboradores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LookUpEdit cboSucursales;
        private DevExpress.XtraEditors.LookUpEdit cboColaboradores;
        private DevExpress.XtraEditors.SimpleButton btnAccion;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}