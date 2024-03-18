namespace ExpedicionInternaPC
{
    partial class frmRecepcionAutogeneradoSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecepcionAutogeneradoSucursal));
            this.grdAutogenerados = new DevExpress.XtraGrid.GridControl();
            this.grvAutogenerados = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaRecepcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.txtAutogenerado = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblPendiente = new DevExpress.XtraEditors.LabelControl();
            this.lblCustodia = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblEntrega = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.lblCambio = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdAutogenerados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAutogenerados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutogenerado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAutogenerados
            // 
            this.grdAutogenerados.Location = new System.Drawing.Point(12, 132);
            this.grdAutogenerados.MainView = this.grvAutogenerados;
            this.grdAutogenerados.Name = "grdAutogenerados";
            this.grdAutogenerados.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1,
            this.repositoryItemImageComboBox1,
            this.repositoryItemHyperLinkEdit1});
            this.grdAutogenerados.Size = new System.Drawing.Size(914, 327);
            this.grdAutogenerados.TabIndex = 0;
            this.grdAutogenerados.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAutogenerados});
            // 
            // grvAutogenerados
            // 
            this.grvAutogenerados.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn1,
            this.colTipoDocumento,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.colFechaRecepcion});
            this.grvAutogenerados.GridControl = this.grdAutogenerados;
            this.grvAutogenerados.Name = "grvAutogenerados";
            this.grvAutogenerados.OptionsView.ShowGroupPanel = false;
            this.grvAutogenerados.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvAutogenerados_RowStyle);
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Recibido";
            this.gridColumn7.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn7.FieldName = "IdTipoEstado";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 31;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 4, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 5, 0)});
            this.repositoryItemImageComboBox1.LargeImages = this.imageCollection2;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.InsertImage(global::ExpedicionInternaPC.Properties.Resources.ApplyDev32, "ApplyDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection2.Images.SetKeyName(0, "ApplyDev32");
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Código documento";
            this.gridColumn1.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridColumn1.FieldName = "Autogenerado";
            this.gridColumn1.MinWidth = 120;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 120;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // colTipoDocumento
            // 
            this.colTipoDocumento.Caption = "Tipo documento";
            this.colTipoDocumento.FieldName = "sTipoElemento";
            this.colTipoDocumento.MinWidth = 100;
            this.colTipoDocumento.Name = "colTipoDocumento";
            this.colTipoDocumento.Visible = true;
            this.colTipoDocumento.VisibleIndex = 2;
            this.colTipoDocumento.Width = 120;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Remitente";
            this.gridColumn2.FieldName = "De";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 99;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bandeja Remitente";
            this.gridColumn3.FieldName = "Origen";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 99;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Destino";
            this.gridColumn4.FieldName = "Para";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 99;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Bandeja Destino";
            this.gridColumn5.FieldName = "Destino";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 99;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Estado";
            this.gridColumn6.FieldName = "Estado";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 99;
            // 
            // colFechaRecepcion
            // 
            this.colFechaRecepcion.Caption = "Fecha de Recepción";
            this.colFechaRecepcion.FieldName = "FechaRecepcion";
            this.colFechaRecepcion.Name = "colFechaRecepcion";
            this.colFechaRecepcion.OptionsColumn.AllowEdit = false;
            this.colFechaRecepcion.OptionsColumn.ReadOnly = true;
            this.colFechaRecepcion.Width = 107;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // btnGrabar
            // 
            this.btnGrabar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGrabar.ImageIndex = 6;
            this.btnGrabar.ImageList = this.imageCollection1;
            this.btnGrabar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnGrabar.Location = new System.Drawing.Point(399, 465);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(113, 44);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.accept32, "accept32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "accept32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.radiobuttongroup32, "radiobuttongroup32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "radiobuttongroup32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.saveas32, "saveas32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "saveas32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.tablerefresh32, "tablerefresh32", typeof(global::ExpedicionInternaPC.Properties.Resources), 3);
            this.imageCollection1.Images.SetKeyName(3, "tablerefresh32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.delete32, "delete32", typeof(global::ExpedicionInternaPC.Properties.Resources), 4);
            this.imageCollection1.Images.SetKeyName(4, "delete32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.tableexcel32, "tableexcel32", typeof(global::ExpedicionInternaPC.Properties.Resources), 5);
            this.imageCollection1.Images.SetKeyName(5, "tableexcel32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 6);
            this.imageCollection1.Images.SetKeyName(6, "SaveDev32");
            // 
            // txtAutogenerado
            // 
            this.txtAutogenerado.Location = new System.Drawing.Point(429, 89);
            this.txtAutogenerado.Name = "txtAutogenerado";
            this.txtAutogenerado.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtAutogenerado.Properties.Appearance.Options.UseFont = true;
            this.txtAutogenerado.Properties.MaxLength = 20;
            this.txtAutogenerado.Size = new System.Drawing.Size(239, 26);
            this.txtAutogenerado.TabIndex = 2;
            this.txtAutogenerado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAutogenerado_KeyDown);
            this.txtAutogenerado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutogenerado_KeyPress);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(257, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(166, 19);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Leer código documento";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblPendiente);
            this.panelControl1.Controls.Add(this.lblCustodia);
            this.panelControl1.Controls.Add(this.lblTotal);
            this.panelControl1.Controls.Add(this.lblEntrega);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(914, 66);
            this.panelControl1.TabIndex = 4;
            // 
            // lblPendiente
            // 
            this.lblPendiente.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPendiente.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPendiente.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPendiente.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblPendiente.Location = new System.Drawing.Point(536, 36);
            this.lblPendiente.Name = "lblPendiente";
            this.lblPendiente.Size = new System.Drawing.Size(80, 25);
            this.lblPendiente.TabIndex = 8;
            this.lblPendiente.Text = "11";
            // 
            // lblCustodia
            // 
            this.lblCustodia.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCustodia.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCustodia.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCustodia.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblCustodia.Location = new System.Drawing.Point(450, 36);
            this.lblCustodia.Name = "lblCustodia";
            this.lblCustodia.Size = new System.Drawing.Size(80, 25);
            this.lblCustodia.TabIndex = 7;
            this.lblCustodia.Text = "39";
            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblTotal.Location = new System.Drawing.Point(364, 36);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 25);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "50";
            // 
            // lblEntrega
            // 
            this.lblEntrega.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEntrega.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblEntrega.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEntrega.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblEntrega.Location = new System.Drawing.Point(278, 36);
            this.lblEntrega.Name = "lblEntrega";
            this.lblEntrega.Size = new System.Drawing.Size(80, 25);
            this.lblEntrega.TabIndex = 5;
            this.lblEntrega.Text = "00101";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelControl5.Appearance.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl5.Location = new System.Drawing.Point(536, 11);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 25);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Pendientes";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelControl4.Appearance.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl4.Location = new System.Drawing.Point(450, 11);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 25);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Custodiados";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelControl3.Appearance.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl3.Location = new System.Drawing.Point(364, 11);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 25);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Total";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.labelControl2.Appearance.BackColor2 = System.Drawing.Color.LightSteelBlue;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.labelControl2.Location = new System.Drawing.Point(278, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 25);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Entrega";
            // 
            // btnExportar
            // 
            this.btnExportar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExportar.ImageIndex = 5;
            this.btnExportar.ImageList = this.imageCollection1;
            this.btnExportar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExportar.Location = new System.Drawing.Point(889, 87);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(37, 30);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblCambio
            // 
            this.lblCambio.Appearance.BackColor = System.Drawing.Color.White;
            this.lblCambio.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCambio.Location = new System.Drawing.Point(12, 123);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(750, 5);
            this.lblCambio.TabIndex = 17;
            // 
            // frmRecepcionAutogeneradoSucursal
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 521);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtAutogenerado);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.grdAutogenerados);
            this.Name = "frmRecepcionAutogeneradoSucursal";
            this.Text = "Recepción de Autogenerados de Entrega Sucursal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRecepcionAutogeneradoSucursal_FormClosed);
            this.Load += new System.EventHandler(this.frmRecepcionAutogeneradoSucursal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAutogenerados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAutogenerados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutogenerado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdAutogenerados;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAutogenerados;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.TextEdit txtAutogenerado;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl lblPendiente;
        private DevExpress.XtraEditors.LabelControl lblCustodia;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.LabelControl lblEntrega;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaRecepcion;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraEditors.LabelControl lblCambio;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDocumento;
    }
}