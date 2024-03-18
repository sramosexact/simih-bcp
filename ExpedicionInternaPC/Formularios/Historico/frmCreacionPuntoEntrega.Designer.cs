namespace ExpedicionInternaPC
{
    partial class frmCreacionPuntoEntrega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreacionPuntoEntrega));
            this.label1 = new System.Windows.Forms.Label();
            this.lupDestino = new DevExpress.XtraEditors.LookUpEdit();
            this.txtCodigoAgencia = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNombreAgencia = new System.Windows.Forms.Label();
            this.txtDescripcion = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.txtArea = new DevExpress.XtraEditors.TextEdit();
            this.btnCrear = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.lblTipo = new System.Windows.Forms.Label();
            this.lupTipo = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lupDestino.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoAgencia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupTipo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Destino            :";
            // 
            // lupDestino
            // 
            this.lupDestino.Location = new System.Drawing.Point(105, 53);
            this.lupDestino.Name = "lupDestino";
            this.lupDestino.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupDestino.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.lupDestino.Properties.NullText = "";
            this.lupDestino.Size = new System.Drawing.Size(190, 20);
            this.lupDestino.TabIndex = 2;
            // 
            // txtCodigoAgencia
            // 
            this.txtCodigoAgencia.Location = new System.Drawing.Point(105, 79);
            this.txtCodigoAgencia.Name = "txtCodigoAgencia";
            this.txtCodigoAgencia.Size = new System.Drawing.Size(190, 20);
            this.txtCodigoAgencia.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Codigo             :";
            // 
            // lblNombreAgencia
            // 
            this.lblNombreAgencia.AutoSize = true;
            this.lblNombreAgencia.Location = new System.Drawing.Point(10, 109);
            this.lblNombreAgencia.Name = "lblNombreAgencia";
            this.lblNombreAgencia.Size = new System.Drawing.Size(88, 13);
            this.lblNombreAgencia.TabIndex = 7;
            this.lblNombreAgencia.Text = "Descripcion      :";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(105, 106);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(190, 20);
            this.txtDescripcion.TabIndex = 6;
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Area                  :";
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(105, 131);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(190, 20);
            this.txtArea.TabIndex = 8;
            this.txtArea.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArea_KeyPress);
            // 
            // btnCrear
            // 
            this.btnCrear.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCrear.ImageIndex = 0;
            this.btnCrear.ImageList = this.imageCollection1;
            this.btnCrear.Location = new System.Drawing.Point(105, 163);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(145, 38);
            this.btnCrear.TabIndex = 12;
            this.btnCrear.Text = "&Crear";
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "SaveDev32");
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(12, 31);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(86, 13);
            this.lblTipo.TabIndex = 1;
            this.lblTipo.Text = "Tipo                  :";
            // 
            // lupTipo
            // 
            this.lupTipo.Location = new System.Drawing.Point(105, 24);
            this.lupTipo.Name = "lupTipo";
            this.lupTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupTipo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Tipo"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default)});
            this.lupTipo.Properties.NullText = "";
            this.lupTipo.Size = new System.Drawing.Size(190, 20);
            this.lupTipo.TabIndex = 0;
            this.lupTipo.EditValueChanged += new System.EventHandler(this.lupTipo_EditValueChanged);
            // 
            // frmCreacionPuntoEntrega
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 213);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.lblNombreAgencia);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigoAgencia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lupDestino);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lupTipo);
            this.Name = "frmCreacionPuntoEntrega";
            this.Text = "Registrar punto de entrega";
            this.Load += new System.EventHandler(this.frmCreacionPuntoEntrega_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lupDestino.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCodigoAgencia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescripcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtArea.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupTipo.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit lupDestino;
        private DevExpress.XtraEditors.TextEdit txtCodigoAgencia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblNombreAgencia;
        private DevExpress.XtraEditors.TextEdit txtDescripcion;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.TextEdit txtArea;
        private DevExpress.XtraEditors.SimpleButton btnCrear;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.Label lblTipo;
        private DevExpress.XtraEditors.LookUpEdit lupTipo;
    }
}