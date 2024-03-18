namespace ExpedicionInternaPC
{
    partial class frmBuscarDocumento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscarDocumento));
            this.txtRemitente = new DevExpress.XtraEditors.TextEdit();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.txtDestinatario = new DevExpress.XtraEditors.TextEdit();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAgregar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtRemitente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestinatario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtRemitente
            // 
            this.txtRemitente.Location = new System.Drawing.Point(112, 17);
            this.txtRemitente.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemitente.Name = "txtRemitente";
            this.txtRemitente.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemitente.Properties.Appearance.Options.UseFont = true;
            this.txtRemitente.Properties.Mask.EditMask = "[A -Z ]+";
            this.txtRemitente.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtRemitente.Size = new System.Drawing.Size(301, 24);
            this.txtRemitente.TabIndex = 18;
            this.txtRemitente.TextChanged += new System.EventHandler(this.txtRemitente_TextChanged);
            this.txtRemitente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textEdit1_KeyDown);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 17;
            this.listBox3.Location = new System.Drawing.Point(111, 88);
            this.listBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(314, 21);
            this.listBox3.TabIndex = 14;
            this.listBox3.Visible = false;
            this.listBox3.Click += new System.EventHandler(this.listBox3_Click);
            this.listBox3.DoubleClick += new System.EventHandler(this.listBox3_DoubleClick);
            this.listBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox3_KeyDown);
            // 
            // txtDestinatario
            // 
            this.txtDestinatario.Location = new System.Drawing.Point(110, 57);
            this.txtDestinatario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDestinatario.Name = "txtDestinatario";
            this.txtDestinatario.Properties.Mask.EditMask = "[A -Z ]+";
            this.txtDestinatario.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtDestinatario.Size = new System.Drawing.Size(301, 22);
            this.txtDestinatario.TabIndex = 15;
            this.txtDestinatario.TextChanged += new System.EventHandler(this.txtBandeja_TextChanged);
            this.txtDestinatario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBandeja_KeyDown);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Location = new System.Drawing.Point(112, 40);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(314, 21);
            this.listBox1.TabIndex = 16;
            this.listBox1.Visible = false;
            this.listBox1.Click += new System.EventHandler(this.listBox1_Click);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAceptar.Enabled = false;
            this.btnAceptar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.add32;
            this.btnAceptar.Location = new System.Drawing.Point(652, 475);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(231, 44);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Agregar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnAgregar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.datatable32;
            this.btnAgregar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAgregar.Location = new System.Drawing.Point(688, 17);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(195, 86);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Buscar Autogenerados";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Enabled = false;
            this.gridControl1.Location = new System.Drawing.Point(14, 120);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.gridControl1.Size = new System.Drawing.Size(880, 346);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdSeleccion,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // grdSeleccion
            // 
            this.grdSeleccion.Caption = "Seleccion";
            this.grdSeleccion.FieldName = "SeleccionGrafica";
            this.grdSeleccion.Name = "grdSeleccion";
            this.grdSeleccion.Visible = true;
            this.grdSeleccion.VisibleIndex = 0;
            this.grdSeleccion.Width = 47;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Autogenerado";
            this.gridColumn1.FieldName = "Autogenerado";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "De";
            this.gridColumn2.FieldName = "CasillaDe";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 176;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Para";
            this.gridColumn5.FieldName = "CasillaPara";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 176;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Creado El";
            this.gridColumn3.DisplayFormat.FormatString = "G";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn3.FieldName = "CreadoEl";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 143;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Impresos";
            this.gridColumn4.FieldName = "Impreso";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 63;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Indicador";
            this.gridColumn6.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn6.FieldName = "indicadorFlag";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 51;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 1, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 2, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 3, 1)});
            this.repositoryItemImageComboBox1.LargeImages = this.imageCollection1;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.flaggreen32, "flaggreen32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "flaggreen32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.flagred32, "flagred32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "flagred32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.flagyellow32, "flagyellow32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "flagyellow32");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Remitente     :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 19;
            this.label2.Text = "Destinatario :";
            // 
            // frmBuscarDocumento
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 528);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRemitente);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.txtDestinatario);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmBuscarDocumento";
            this.Text = "Buscar Documento";
            this.Load += new System.EventHandler(this.frmBuscarDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtRemitente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDestinatario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtRemitente;
        private System.Windows.Forms.ListBox listBox3;
        private DevExpress.XtraEditors.TextEdit txtDestinatario;
        private System.Windows.Forms.ListBox listBox1;
        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.SimpleButton btnAgregar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn grdSeleccion;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.Utils.ImageCollection imageCollection1;

    }

}