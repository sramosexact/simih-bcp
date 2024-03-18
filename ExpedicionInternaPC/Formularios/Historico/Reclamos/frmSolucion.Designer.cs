namespace ExpedicionInternaPC
{
    partial class frmSolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolucion));
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrimeraRespuesta = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.memoSolucion = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lueTipoResponsable = new DevExpress.XtraEditors.LookUpEdit();
            this.memoCausa = new DevExpress.XtraEditors.MemoEdit();
            this.memoAccion = new DevExpress.XtraEditors.MemoEdit();
            this.txtResponsable = new DevExpress.XtraEditors.TextEdit();
            this.tsFundado = new DevExpress.XtraEditors.ToggleSwitch();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lueTipoReclamoUTD = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.lblFecha = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.lblUsuario = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.lblDocReferencia = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblArea = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lblTipo = new DevExpress.XtraEditors.LabelControl();
            this.lblDetalle = new DevExpress.XtraEditors.LabelControl();
            this.btnCorregir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoSolucion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoResponsable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoCausa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAccion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponsable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsFundado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoReclamoUTD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.ApplyDev32, "ApplyDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "ApplyDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.accept32, "accept32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "accept32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.cancel32, "cancel32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "cancel32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.CancelDev32, "CancelDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 3);
            this.imageCollection1.Images.SetKeyName(3, "CancelDev32");
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.ImageOptions.ImageIndex = 2;
            this.btnCancelar.ImageOptions.ImageList = this.imageCollection1;
            this.btnCancelar.Location = new System.Drawing.Point(411, 436);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 33);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnPrimeraRespuesta
            // 
            this.btnPrimeraRespuesta.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnPrimeraRespuesta.ImageOptions.ImageIndex = 1;
            this.btnPrimeraRespuesta.ImageOptions.ImageList = this.imageCollection1;
            this.btnPrimeraRespuesta.Location = new System.Drawing.Point(194, 436);
            this.btnPrimeraRespuesta.Name = "btnPrimeraRespuesta";
            this.btnPrimeraRespuesta.Size = new System.Drawing.Size(127, 33);
            this.btnPrimeraRespuesta.TabIndex = 16;
            this.btnPrimeraRespuesta.Text = "Registrar Solución";
            this.btnPrimeraRespuesta.Click += new System.EventHandler(this.btnPrimeraRespuesta_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.panelControl2.Controls.Add(this.memoSolucion);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.lueTipoResponsable);
            this.panelControl2.Controls.Add(this.memoCausa);
            this.panelControl2.Controls.Add(this.memoAccion);
            this.panelControl2.Controls.Add(this.txtResponsable);
            this.panelControl2.Controls.Add(this.tsFundado);
            this.panelControl2.Controls.Add(this.labelControl14);
            this.panelControl2.Controls.Add(this.labelControl13);
            this.panelControl2.Controls.Add(this.labelControl12);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.lueTipoReclamoUTD);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Location = new System.Drawing.Point(361, 6);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(349, 416);
            this.panelControl2.TabIndex = 14;
            // 
            // memoSolucion
            // 
            this.memoSolucion.Location = new System.Drawing.Point(11, 292);
            this.memoSolucion.Name = "memoSolucion";
            this.memoSolucion.Size = new System.Drawing.Size(329, 62);
            this.memoSolucion.TabIndex = 34;
            this.memoSolucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.memoSolucion_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl4.Location = new System.Drawing.Point(11, 270);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(71, 28);
            this.labelControl4.TabIndex = 33;
            this.labelControl4.Text = "Solución:";
            // 
            // lueTipoResponsable
            // 
            this.lueTipoResponsable.Location = new System.Drawing.Point(135, 368);
            this.lueTipoResponsable.Name = "lueTipoResponsable";
            this.lueTipoResponsable.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipoResponsable.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoResponsable", "iIdTipoResponsable", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoResponsable", "sDescripcionTipoResponsable")});
            this.lueTipoResponsable.Properties.NullText = "";
            this.lueTipoResponsable.Properties.ShowFooter = false;
            this.lueTipoResponsable.Properties.ShowHeader = false;
            this.lueTipoResponsable.Size = new System.Drawing.Size(208, 20);
            this.lueTipoResponsable.TabIndex = 32;
            // 
            // memoCausa
            // 
            this.memoCausa.Location = new System.Drawing.Point(11, 193);
            this.memoCausa.Name = "memoCausa";
            this.memoCausa.Size = new System.Drawing.Size(329, 62);
            this.memoCausa.TabIndex = 30;
            this.memoCausa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.memoCausa_KeyPress);
            // 
            // memoAccion
            // 
            this.memoAccion.Location = new System.Drawing.Point(11, 100);
            this.memoAccion.Name = "memoAccion";
            this.memoAccion.Size = new System.Drawing.Size(329, 59);
            this.memoAccion.TabIndex = 29;
            this.memoAccion.EditValueChanged += new System.EventHandler(this.memoAccion_EditValueChanged);
            this.memoAccion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.memoAccion_KeyPress);
            // 
            // txtResponsable
            // 
            this.txtResponsable.Location = new System.Drawing.Point(106, 395);
            this.txtResponsable.Name = "txtResponsable";
            this.txtResponsable.Size = new System.Drawing.Size(237, 20);
            this.txtResponsable.TabIndex = 28;
            this.txtResponsable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResponsable_KeyPress);
            // 
            // tsFundado
            // 
            this.tsFundado.EditValue = true;
            this.tsFundado.Location = new System.Drawing.Point(133, 17);
            this.tsFundado.Name = "tsFundado";
            this.tsFundado.Properties.OffText = "No";
            this.tsFundado.Properties.OnText = "Sí";
            this.tsFundado.Size = new System.Drawing.Size(87, 24);
            this.tsFundado.TabIndex = 27;
            this.tsFundado.Toggled += new System.EventHandler(this.tsFundado_Toggled);
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl14.Location = new System.Drawing.Point(11, 388);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(123, 28);
            this.labelControl14.TabIndex = 26;
            this.labelControl14.Text = "Responsable:";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl13.Appearance.Options.UseFont = true;
            this.labelControl13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl13.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl13.Location = new System.Drawing.Point(11, 361);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(123, 28);
            this.labelControl13.TabIndex = 24;
            this.labelControl13.Text = "Tipo Responsable:";
            // 
            // labelControl12
            // 
            this.labelControl12.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl12.Appearance.Options.UseFont = true;
            this.labelControl12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl12.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl12.Location = new System.Drawing.Point(11, 168);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(71, 28);
            this.labelControl12.TabIndex = 22;
            this.labelControl12.Text = "Causa:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl3.Location = new System.Drawing.Point(12, 77);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 28);
            this.labelControl3.TabIndex = 20;
            this.labelControl3.Text = " Acción:";
            // 
            // lueTipoReclamoUTD
            // 
            this.lueTipoReclamoUTD.Location = new System.Drawing.Point(136, 52);
            this.lueTipoReclamoUTD.Name = "lueTipoReclamoUTD";
            this.lueTipoReclamoUTD.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueTipoReclamoUTD.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("iIdTipoReclamoUTD", "iIdTipoReclamoUTD", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sDescripcionTipoReclamoUTD", "sDescripcionTipoReclamoUTD")});
            this.lueTipoReclamoUTD.Properties.NullText = "";
            this.lueTipoReclamoUTD.Properties.ShowFooter = false;
            this.lueTipoReclamoUTD.Properties.ShowHeader = false;
            this.lueTipoReclamoUTD.Size = new System.Drawing.Size(208, 20);
            this.lueTipoReclamoUTD.TabIndex = 18;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl2.Location = new System.Drawing.Point(12, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(123, 28);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Tipo Reclamo UTD :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(71, 28);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Fundado :";
            this.labelControl1.Click += new System.EventHandler(this.labelControl1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl11);
            this.panelControl1.Controls.Add(this.lblFecha);
            this.panelControl1.Controls.Add(this.labelControl10);
            this.panelControl1.Controls.Add(this.lblUsuario);
            this.panelControl1.Controls.Add(this.labelControl8);
            this.panelControl1.Controls.Add(this.lblDocReferencia);
            this.panelControl1.Controls.Add(this.labelControl7);
            this.panelControl1.Controls.Add(this.lblArea);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.lblTipo);
            this.panelControl1.Controls.Add(this.lblDetalle);
            this.panelControl1.Location = new System.Drawing.Point(3, 6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(352, 416);
            this.panelControl1.TabIndex = 13;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl5.Location = new System.Drawing.Point(15, 19);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(71, 28);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Fecha :";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl11.Location = new System.Drawing.Point(15, 284);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(71, 28);
            this.labelControl11.TabIndex = 1;
            this.labelControl11.Text = "Detalle :";
            // 
            // lblFecha
            // 
            this.lblFecha.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblFecha.Appearance.Options.UseFont = true;
            this.lblFecha.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFecha.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblFecha.Location = new System.Drawing.Point(92, 19);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 28);
            this.lblFecha.TabIndex = 12;
            this.lblFecha.Text = "16/03/2017";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl10.Location = new System.Drawing.Point(8, 194);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(71, 28);
            this.labelControl10.TabIndex = 2;
            this.labelControl10.Text = "Tipo :";
            // 
            // lblUsuario
            // 
            this.lblUsuario.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblUsuario.Appearance.Options.UseFont = true;
            this.lblUsuario.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUsuario.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblUsuario.Location = new System.Drawing.Point(92, 77);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(240, 28);
            this.lblUsuario.TabIndex = 11;
            this.lblUsuario.Text = "OCTAVIO FANASTO OCROSPOMA";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl8.Location = new System.Drawing.Point(8, 141);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(71, 28);
            this.labelControl8.TabIndex = 3;
            this.labelControl8.Text = "Área :";
            // 
            // lblDocReferencia
            // 
            this.lblDocReferencia.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDocReferencia.Appearance.Options.UseFont = true;
            this.lblDocReferencia.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDocReferencia.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblDocReferencia.Location = new System.Drawing.Point(165, 242);
            this.lblDocReferencia.Name = "lblDocReferencia";
            this.lblDocReferencia.Size = new System.Drawing.Size(167, 28);
            this.lblDocReferencia.TabIndex = 10;
            this.lblDocReferencia.Text = "MIRAFLORES";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl7.Location = new System.Drawing.Point(15, 242);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(144, 28);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Documento Referencia :";
            // 
            // lblArea
            // 
            this.lblArea.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblArea.Appearance.Options.UseFont = true;
            this.lblArea.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblArea.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblArea.Location = new System.Drawing.Point(92, 141);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(240, 28);
            this.lblArea.TabIndex = 9;
            this.lblArea.Text = "BANCA EMPRESAS";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.labelControl6.Location = new System.Drawing.Point(8, 77);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(71, 28);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "Usuario :";
            // 
            // lblTipo
            // 
            this.lblTipo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTipo.Appearance.Options.UseFont = true;
            this.lblTipo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTipo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblTipo.Location = new System.Drawing.Point(92, 194);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(240, 28);
            this.lblTipo.TabIndex = 8;
            this.lblTipo.Text = "DOCUMENTO";
            // 
            // lblDetalle
            // 
            this.lblDetalle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDetalle.Appearance.Options.UseFont = true;
            this.lblDetalle.Appearance.Options.UseTextOptions = true;
            this.lblDetalle.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblDetalle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDetalle.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblDetalle.Location = new System.Drawing.Point(15, 318);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.lblDetalle.Size = new System.Drawing.Size(317, 73);
            this.lblDetalle.TabIndex = 7;
            this.lblDetalle.Text = "El autogenerado ABC001 no se encuentra en mi bandeja de entrada...";
            // 
            // btnCorregir
            // 
            this.btnCorregir.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCorregir.ImageOptions.ImageList = this.imageCollection1;
            this.btnCorregir.Location = new System.Drawing.Point(585, 436);
            this.btnCorregir.Name = "btnCorregir";
            this.btnCorregir.Size = new System.Drawing.Size(83, 33);
            this.btnCorregir.TabIndex = 17;
            this.btnCorregir.Text = "Corregir";
            this.btnCorregir.Click += new System.EventHandler(this.btnCorregir_Click);
            // 
            // frmSolucion
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 478);
            this.Controls.Add(this.btnCorregir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnPrimeraRespuesta);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "frmSolucion";
            this.Text = "Gestión de Reclamo";
            this.Load += new System.EventHandler(this.frmSolucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoSolucion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoResponsable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoCausa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAccion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResponsable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsFundado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueTipoReclamoUTD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblDetalle;
        private DevExpress.XtraEditors.LabelControl lblTipo;
        private DevExpress.XtraEditors.LabelControl lblArea;
        private DevExpress.XtraEditors.LabelControl lblDocReferencia;
        private DevExpress.XtraEditors.LabelControl lblUsuario;
        private DevExpress.XtraEditors.LabelControl lblFecha;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lueTipoReclamoUTD;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private DevExpress.XtraEditors.SimpleButton btnPrimeraRespuesta;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.MemoEdit memoCausa;
        private DevExpress.XtraEditors.MemoEdit memoAccion;
        private DevExpress.XtraEditors.TextEdit txtResponsable;
        private DevExpress.XtraEditors.ToggleSwitch tsFundado;
        private DevExpress.XtraEditors.LookUpEdit lueTipoResponsable;
        private DevExpress.XtraEditors.MemoEdit memoSolucion;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnCorregir;
    }
}