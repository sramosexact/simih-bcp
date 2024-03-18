using System.Drawing;
namespace ExpedicionInternaPC
{
    partial class frmEntregaSucursales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaSucursales));
            this.grdEntregaObjeto = new DevExpress.XtraGrid.GridControl();
            this.grvEntregaObjeto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdTipoValidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection2 = new DevExpress.Utils.ImageCollection(this.components);
            this.colAutogenerado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPara = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOficina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevalidar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lnkDesvalidar = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colFechaValidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdObjeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdBandeja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecepcionadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecepcionadoEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecepcionadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdOficinaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.btnRetirar = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.btnGrabar = new DevExpress.XtraEditors.SimpleButton();
            this.btnRecargar = new DevExpress.XtraEditors.SimpleButton();
            this.btnValidar = new DevExpress.XtraEditors.SimpleButton();
            this.txtAutogenerado = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.lblPorValidar = new DevExpress.XtraEditors.LabelControl();
            this.lblValidados = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblEntrega = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.lblCambio = new DevExpress.XtraEditors.LabelControl();
            this.colGeoDestinoAnterior = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntregaObjeto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntregaObjeto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDesvalidar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutogenerado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdEntregaObjeto
            // 
            this.grdEntregaObjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEntregaObjeto.Location = new System.Drawing.Point(12, 145);
            this.grdEntregaObjeto.MainView = this.grvEntregaObjeto;
            this.grdEntregaObjeto.Name = "grdEntregaObjeto";
            this.grdEntregaObjeto.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2,
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemHyperLinkEdit2,
            this.lnkDesvalidar});
            this.grdEntregaObjeto.Size = new System.Drawing.Size(914, 320);
            this.grdEntregaObjeto.TabIndex = 7;
            this.grdEntregaObjeto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEntregaObjeto});
            // 
            // grvEntregaObjeto
            // 
            this.grvEntregaObjeto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdTipoValidacion,
            this.colAutogenerado,
            this.colTipoDocumento,
            this.colDe,
            this.colOrigen,
            this.colPara,
            this.colDestino,
            this.colOficina,
            this.colDevalidar,
            this.colFechaValidacion,
            this.colIdObjeto,
            this.colIdBandeja,
            this.colRecepcionadoEl,
            this.colRecepcionadoEn,
            this.colRecepcionadoPor,
            this.colResultado,
            this.colObservacion,
            this.colIdOficinaEntrega,
            this.colGeoDestinoAnterior});
            this.grvEntregaObjeto.GridControl = this.grdEntregaObjeto;
            this.grvEntregaObjeto.Name = "grvEntregaObjeto";
            this.grvEntregaObjeto.OptionsView.ShowAutoFilterRow = true;
            this.grvEntregaObjeto.OptionsView.ShowGroupPanel = false;
            this.grvEntregaObjeto.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvEntregaObjeto_RowCellStyle);
            this.grvEntregaObjeto.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvEntregaObjeto_RowStyle);
            // 
            // colIdTipoValidacion
            // 
            this.colIdTipoValidacion.Caption = "Validado";
            this.colIdTipoValidacion.ColumnEdit = this.repositoryItemImageComboBox2;
            this.colIdTipoValidacion.FieldName = "idTipoValidacion";
            this.colIdTipoValidacion.MaxWidth = 30;
            this.colIdTipoValidacion.Name = "colIdTipoValidacion";
            this.colIdTipoValidacion.OptionsColumn.ReadOnly = true;
            this.colIdTipoValidacion.ToolTip = "Validado";
            this.colIdTipoValidacion.Visible = true;
            this.colIdTipoValidacion.VisibleIndex = 0;
            this.colIdTipoValidacion.Width = 30;
            // 
            // repositoryItemImageComboBox2
            // 
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 72, 0)});
            this.repositoryItemImageComboBox2.LargeImages = this.imageCollection2;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            // 
            // imageCollection2
            // 
            this.imageCollection2.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection2.ImageStream")));
            this.imageCollection2.InsertImage(global::ExpedicionInternaPC.Properties.Resources.accept32, "accept32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection2.Images.SetKeyName(0, "accept32");
            this.imageCollection2.InsertImage(global::ExpedicionInternaPC.Properties.Resources.delete32, "delete32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection2.Images.SetKeyName(1, "delete32");
            this.imageCollection2.InsertImage(global::ExpedicionInternaPC.Properties.Resources.add32, "add32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection2.Images.SetKeyName(2, "add32");
            // 
            // colAutogenerado
            // 
            this.colAutogenerado.Caption = "Código documento";
            this.colAutogenerado.ColumnEdit = this.repositoryItemHyperLinkEdit2;
            this.colAutogenerado.FieldName = "Autogenerado";
            this.colAutogenerado.MinWidth = 120;
            this.colAutogenerado.Name = "colAutogenerado";
            this.colAutogenerado.OptionsColumn.ReadOnly = true;
            this.colAutogenerado.Visible = true;
            this.colAutogenerado.VisibleIndex = 1;
            this.colAutogenerado.Width = 127;
            // 
            // repositoryItemHyperLinkEdit2
            // 
            this.repositoryItemHyperLinkEdit2.AutoHeight = false;
            this.repositoryItemHyperLinkEdit2.Name = "repositoryItemHyperLinkEdit2";
            this.repositoryItemHyperLinkEdit2.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit2_Click);
            // 
            // colTipoDocumento
            // 
            this.colTipoDocumento.Caption = "Tipo documento";
            this.colTipoDocumento.FieldName = "sTipoElemento";
            this.colTipoDocumento.MinWidth = 100;
            this.colTipoDocumento.Name = "colTipoDocumento";
            this.colTipoDocumento.OptionsColumn.ReadOnly = true;
            this.colTipoDocumento.Visible = true;
            this.colTipoDocumento.VisibleIndex = 2;
            this.colTipoDocumento.Width = 105;
            // 
            // colDe
            // 
            this.colDe.Caption = "De";
            this.colDe.FieldName = "De";
            this.colDe.Name = "colDe";
            this.colDe.OptionsColumn.ReadOnly = true;
            this.colDe.Visible = true;
            this.colDe.VisibleIndex = 3;
            this.colDe.Width = 115;
            // 
            // colOrigen
            // 
            this.colOrigen.Caption = "Origen";
            this.colOrigen.FieldName = "Origen";
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.OptionsColumn.ReadOnly = true;
            this.colOrigen.Visible = true;
            this.colOrigen.VisibleIndex = 4;
            this.colOrigen.Width = 97;
            // 
            // colPara
            // 
            this.colPara.Caption = "Para";
            this.colPara.FieldName = "Para";
            this.colPara.Name = "colPara";
            this.colPara.OptionsColumn.ReadOnly = true;
            this.colPara.Visible = true;
            this.colPara.VisibleIndex = 5;
            this.colPara.Width = 105;
            // 
            // colDestino
            // 
            this.colDestino.Caption = "Destino";
            this.colDestino.FieldName = "Destino";
            this.colDestino.Name = "colDestino";
            this.colDestino.OptionsColumn.ReadOnly = true;
            this.colDestino.Visible = true;
            this.colDestino.VisibleIndex = 6;
            this.colDestino.Width = 97;
            // 
            // colOficina
            // 
            this.colOficina.Caption = "Oficina";
            this.colOficina.FieldName = "Oficina";
            this.colOficina.Name = "colOficina";
            this.colOficina.OptionsColumn.ReadOnly = true;
            this.colOficina.Visible = true;
            this.colOficina.VisibleIndex = 7;
            this.colOficina.Width = 108;
            // 
            // colDevalidar
            // 
            this.colDevalidar.Caption = "Deshacer validación";
            this.colDevalidar.ColumnEdit = this.lnkDesvalidar;
            this.colDevalidar.Name = "colDevalidar";
            this.colDevalidar.Visible = true;
            this.colDevalidar.VisibleIndex = 8;
            this.colDevalidar.Width = 112;
            // 
            // lnkDesvalidar
            // 
            this.lnkDesvalidar.AutoHeight = false;
            this.lnkDesvalidar.Name = "lnkDesvalidar";
            this.lnkDesvalidar.NullText = "Deshacer validación";
            this.lnkDesvalidar.Click += new System.EventHandler(this.lnkDesvalidar_Click);
            // 
            // colFechaValidacion
            // 
            this.colFechaValidacion.Caption = "Validado el";
            this.colFechaValidacion.FieldName = "fechaValidacion";
            this.colFechaValidacion.Name = "colFechaValidacion";
            // 
            // colIdObjeto
            // 
            this.colIdObjeto.Caption = "Id";
            this.colIdObjeto.FieldName = "ID";
            this.colIdObjeto.Name = "colIdObjeto";
            // 
            // colIdBandeja
            // 
            this.colIdBandeja.Caption = "IdBandeja";
            this.colIdBandeja.FieldName = "IdGeoBandejaFisica";
            this.colIdBandeja.Name = "colIdBandeja";
            // 
            // colRecepcionadoEl
            // 
            this.colRecepcionadoEl.Caption = "Recepcionado el";
            this.colRecepcionadoEl.FieldName = "FechaEntrega";
            this.colRecepcionadoEl.Name = "colRecepcionadoEl";
            // 
            // colRecepcionadoEn
            // 
            this.colRecepcionadoEn.Caption = "Recepcionado en";
            this.colRecepcionadoEn.FieldName = "OficinaEntrega";
            this.colRecepcionadoEn.Name = "colRecepcionadoEn";
            // 
            // colRecepcionadoPor
            // 
            this.colRecepcionadoPor.Caption = "Recepcionado por";
            this.colRecepcionadoPor.FieldName = "EntregaIdentificacion";
            this.colRecepcionadoPor.Name = "colRecepcionadoPor";
            // 
            // colResultado
            // 
            this.colResultado.Caption = "Resultado";
            this.colResultado.FieldName = "TipoResultado";
            this.colResultado.Name = "colResultado";
            // 
            // colObservacion
            // 
            this.colObservacion.Caption = "Observación";
            this.colObservacion.FieldName = "EntregaObservacion";
            this.colObservacion.Name = "colObservacion";
            // 
            // colIdOficinaEntrega
            // 
            this.colIdOficinaEntrega.Caption = "IdOficinaEntrega";
            this.colIdOficinaEntrega.FieldName = "IdOficinaEntrega";
            this.colIdOficinaEntrega.Name = "colIdOficinaEntrega";
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.NullText = "Eliminar";
            this.repositoryItemHyperLinkEdit1.ReadOnly = true;
            // 
            // btnRetirar
            // 
            this.btnRetirar.Appearance.BackColor = System.Drawing.Color.White;
            this.btnRetirar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnRetirar.Appearance.Options.UseBackColor = true;
            this.btnRetirar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRetirar.ImageIndex = 8;
            this.btnRetirar.ImageList = this.imageCollection1;
            this.btnRetirar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRetirar.Location = new System.Drawing.Point(494, 471);
            this.btnRetirar.Name = "btnRetirar";
            this.btnRetirar.Size = new System.Drawing.Size(113, 44);
            this.btnRetirar.TabIndex = 12;
            this.btnRetirar.Text = "Retirar No\r\nValidados";
            this.btnRetirar.Click += new System.EventHandler(this.btnRetirar_Click);
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
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.AddDev32, "AddDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 6);
            this.imageCollection1.Images.SetKeyName(6, "AddDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.RefreshDev32, "RefreshDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 7);
            this.imageCollection1.Images.SetKeyName(7, "RefreshDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.RemoveDev32, "RemoveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 8);
            this.imageCollection1.Images.SetKeyName(8, "RemoveDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.SaveDev32, "SaveDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 9);
            this.imageCollection1.Images.SetKeyName(9, "SaveDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.ApplyDev32, "ApplyDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 10);
            this.imageCollection1.Images.SetKeyName(10, "ApplyDev32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.CancelDev32, "CancelDev32", typeof(global::ExpedicionInternaPC.Properties.Resources), 11);
            this.imageCollection1.Images.SetKeyName(11, "CancelDev32");
            // 
            // btnGrabar
            // 
            this.btnGrabar.Appearance.BackColor = System.Drawing.Color.White;
            this.btnGrabar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnGrabar.Appearance.Options.UseBackColor = true;
            this.btnGrabar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGrabar.ImageIndex = 9;
            this.btnGrabar.ImageList = this.imageCollection1;
            this.btnGrabar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnGrabar.Location = new System.Drawing.Point(301, 471);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(113, 44);
            this.btnGrabar.TabIndex = 11;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnRecargar
            // 
            this.btnRecargar.Appearance.BackColor = System.Drawing.Color.White;
            this.btnRecargar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnRecargar.Appearance.Options.UseBackColor = true;
            this.btnRecargar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRecargar.ImageIndex = 7;
            this.btnRecargar.ImageList = this.imageCollection1;
            this.btnRecargar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnRecargar.Location = new System.Drawing.Point(770, 89);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(113, 44);
            this.btnRecargar.TabIndex = 10;
            this.btnRecargar.Text = "Recargar";
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // btnValidar
            // 
            this.btnValidar.Appearance.BackColor = System.Drawing.Color.White;
            this.btnValidar.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnValidar.Appearance.Options.UseBackColor = true;
            this.btnValidar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnValidar.ImageIndex = 10;
            this.btnValidar.ImageList = this.imageCollection1;
            this.btnValidar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnValidar.Location = new System.Drawing.Point(507, 89);
            this.btnValidar.Name = "btnValidar";
            this.btnValidar.Size = new System.Drawing.Size(113, 44);
            this.btnValidar.TabIndex = 9;
            this.btnValidar.Text = "Validar \rcódigo";
            this.btnValidar.Click += new System.EventHandler(this.btnValidar_Click);
            // 
            // txtAutogenerado
            // 
            this.txtAutogenerado.Location = new System.Drawing.Point(192, 97);
            this.txtAutogenerado.Name = "txtAutogenerado";
            this.txtAutogenerado.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtAutogenerado.Properties.Appearance.Options.UseFont = true;
            this.txtAutogenerado.Properties.MaxLength = 20;
            this.txtAutogenerado.Size = new System.Drawing.Size(309, 26);
            this.txtAutogenerado.TabIndex = 8;
            this.txtAutogenerado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAutogenerado_KeyDown);
            this.txtAutogenerado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutogenerado_KeyPress);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.lblPorValidar);
            this.panelControl2.Controls.Add(this.lblValidados);
            this.panelControl2.Controls.Add(this.lblTotal);
            this.panelControl2.Controls.Add(this.lblEntrega);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(12, 8);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(914, 66);
            this.panelControl2.TabIndex = 13;
            // 
            // lblPorValidar
            // 
            this.lblPorValidar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPorValidar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPorValidar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPorValidar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblPorValidar.Location = new System.Drawing.Point(528, 34);
            this.lblPorValidar.Name = "lblPorValidar";
            this.lblPorValidar.Size = new System.Drawing.Size(80, 25);
            this.lblPorValidar.TabIndex = 8;
            this.lblPorValidar.Text = "0";
            // 
            // lblValidados
            // 
            this.lblValidados.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblValidados.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblValidados.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblValidados.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblValidados.Location = new System.Drawing.Point(442, 34);
            this.lblValidados.Name = "lblValidados";
            this.lblValidados.Size = new System.Drawing.Size(80, 25);
            this.lblValidados.TabIndex = 7;
            this.lblValidados.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblTotal.Location = new System.Drawing.Point(356, 34);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 25);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "0";
            // 
            // lblEntrega
            // 
            this.lblEntrega.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEntrega.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblEntrega.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEntrega.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblEntrega.Location = new System.Drawing.Point(270, 34);
            this.lblEntrega.Name = "lblEntrega";
            this.lblEntrega.Size = new System.Drawing.Size(80, 25);
            this.lblEntrega.TabIndex = 5;
            this.lblEntrega.Text = "0";
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
            this.labelControl5.Location = new System.Drawing.Point(528, 9);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 25);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "Por validar";
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
            this.labelControl4.Location = new System.Drawing.Point(442, 9);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 25);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Validados";
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
            this.labelControl3.Location = new System.Drawing.Point(356, 9);
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
            this.labelControl2.Location = new System.Drawing.Point(270, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 25);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Entrega";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Location = new System.Drawing.Point(12, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(166, 19);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Leer código documento";
            // 
            // btnExportar
            // 
            this.btnExportar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExportar.ImageIndex = 5;
            this.btnExportar.ImageList = this.imageCollection1;
            this.btnExportar.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnExportar.Location = new System.Drawing.Point(889, 95);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(37, 30);
            this.btnExportar.TabIndex = 15;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblCambio
            // 
            this.lblCambio.Appearance.BackColor = System.Drawing.Color.White;
            this.lblCambio.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCambio.Location = new System.Drawing.Point(12, 137);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(732, 5);
            this.lblCambio.TabIndex = 16;
            // 
            // colGeoDestinoAnterior
            // 
            this.colGeoDestinoAnterior.Caption = "DestinoAnterior";
            this.colGeoDestinoAnterior.FieldName = "iIdGeoDestinoAnterior";
            this.colGeoDestinoAnterior.Name = "colGeoDestinoAnterior";
            // 
            // frmEntregaSucursales
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 521);
            this.Controls.Add(this.lblCambio);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.grdEntregaObjeto);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnRetirar);
            this.Controls.Add(this.btnValidar);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.txtAutogenerado);
            this.Name = "frmEntregaSucursales";
            this.Text = "Entrega Sucursal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEntregaSucursales_FormClosed);
            this.Load += new System.EventHandler(this.frmEntregaSucursales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdEntregaObjeto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntregaObjeto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkDesvalidar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAutogenerado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnRetirar;
        private DevExpress.XtraEditors.SimpleButton btnGrabar;
        private DevExpress.XtraEditors.SimpleButton btnRecargar;
        private DevExpress.XtraEditors.SimpleButton btnValidar;
        private DevExpress.XtraEditors.TextEdit txtAutogenerado;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.GridControl grdEntregaObjeto;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEntregaObjeto;
        private DevExpress.XtraGrid.Columns.GridColumn colIdTipoValidacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraGrid.Columns.GridColumn colAutogenerado;
        private DevExpress.XtraGrid.Columns.GridColumn colDe;
        private DevExpress.XtraGrid.Columns.GridColumn colOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn colPara;
        private DevExpress.XtraGrid.Columns.GridColumn colDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colOficina;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaValidacion;
        private DevExpress.XtraGrid.Columns.GridColumn colIdObjeto;
        private DevExpress.XtraGrid.Columns.GridColumn colIdBandeja;
        private DevExpress.XtraGrid.Columns.GridColumn colRecepcionadoEl;
        private DevExpress.XtraGrid.Columns.GridColumn colRecepcionadoEn;
        private DevExpress.XtraGrid.Columns.GridColumn colRecepcionadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colResultado;
        private DevExpress.XtraGrid.Columns.GridColumn colObservacion;
        private DevExpress.XtraGrid.Columns.GridColumn colIdOficinaEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn colDevalidar;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.Utils.ImageCollection imageCollection2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblPorValidar;
        private DevExpress.XtraEditors.LabelControl lblValidados;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.LabelControl lblEntrega;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit2;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit lnkDesvalidar;
        private DevExpress.XtraEditors.LabelControl lblCambio;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colGeoDestinoAnterior;
    }
}