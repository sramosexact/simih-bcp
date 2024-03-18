namespace ExpedicionInternaPC.Formularios.Expedicion
{
    partial class frmDetalleEntregaSeg
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
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.lblPorValidar = new DevExpress.XtraEditors.LabelControl();
            this.lblValidados = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.lblEntrega = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdEntregaObjeto = new DevExpress.XtraGrid.GridControl();
            this.grvEntregaObjeto = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdTipoValidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutogenerado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkAutogenerado = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colDe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPara = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOficina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaValidacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdObjeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdBandeja = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecepcionadoEl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecepcionadoEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRecepcionadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdOficinaEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTipoElemento = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntregaObjeto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntregaObjeto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkAutogenerado)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.simpleButton1);
            this.panelControl2.Controls.Add(this.btnExportar);
            this.panelControl2.Controls.Add(this.lblPorValidar);
            this.panelControl2.Controls.Add(this.lblValidados);
            this.panelControl2.Controls.Add(this.lblTotal);
            this.panelControl2.Controls.Add(this.lblEntrega);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Location = new System.Drawing.Point(12, 11);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(914, 63);
            this.panelControl2.TabIndex = 23;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::ExpedicionInternaPC.Properties.Resources.arrowrefresh32;
            this.simpleButton1.Location = new System.Drawing.Point(865, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(44, 46);
            this.simpleButton1.TabIndex = 10;
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::ExpedicionInternaPC.Properties.Resources.tableexcel32;
            this.btnExportar.Location = new System.Drawing.Point(815, 8);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(44, 46);
            this.btnExportar.TabIndex = 9;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblPorValidar
            // 
            this.lblPorValidar.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPorValidar.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPorValidar.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPorValidar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblPorValidar.Location = new System.Drawing.Point(534, 31);
            this.lblPorValidar.Name = "lblPorValidar";
            this.lblPorValidar.Size = new System.Drawing.Size(80, 23);
            this.lblPorValidar.TabIndex = 8;
            this.lblPorValidar.Text = "0";
            // 
            // lblValidados
            // 
            this.lblValidados.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblValidados.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblValidados.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblValidados.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblValidados.Location = new System.Drawing.Point(448, 31);
            this.lblValidados.Name = "lblValidados";
            this.lblValidados.Size = new System.Drawing.Size(80, 23);
            this.lblValidados.TabIndex = 7;
            this.lblValidados.Text = "0";
            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotal.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotal.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblTotal.Location = new System.Drawing.Point(362, 31);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 23);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "0";
            // 
            // lblEntrega
            // 
            this.lblEntrega.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEntrega.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblEntrega.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEntrega.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.lblEntrega.Location = new System.Drawing.Point(276, 31);
            this.lblEntrega.Name = "lblEntrega";
            this.lblEntrega.Size = new System.Drawing.Size(80, 23);
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
            this.labelControl5.Location = new System.Drawing.Point(534, 8);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(80, 23);
            this.labelControl5.TabIndex = 4;
            this.labelControl5.Text = "En ruta";
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
            this.labelControl4.Location = new System.Drawing.Point(448, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(80, 23);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Recibidos";
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
            this.labelControl3.Location = new System.Drawing.Point(362, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 23);
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
            this.labelControl2.Location = new System.Drawing.Point(276, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(80, 23);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Entrega";
            // 
            // grdEntregaObjeto
            // 
            this.grdEntregaObjeto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEntregaObjeto.Location = new System.Drawing.Point(12, 90);
            this.grdEntregaObjeto.MainView = this.grvEntregaObjeto;
            this.grdEntregaObjeto.Name = "grdEntregaObjeto";
            this.grdEntregaObjeto.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkAutogenerado});
            this.grdEntregaObjeto.Size = new System.Drawing.Size(914, 295);
            this.grdEntregaObjeto.TabIndex = 24;
            this.grdEntregaObjeto.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvEntregaObjeto});
            // 
            // grvEntregaObjeto
            // 
            this.grvEntregaObjeto.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdTipoValidacion,
            this.colAutogenerado,
            this.gcTipoElemento,
            this.colDe,
            this.colOrigen,
            this.colPara,
            this.colDestino,
            this.colOficina,
            this.colEstado,
            this.colFechaValidacion,
            this.colIdObjeto,
            this.colIdBandeja,
            this.colRecepcionadoEl,
            this.colRecepcionadoEn,
            this.colRecepcionadoPor,
            this.colResultado,
            this.colObservacion,
            this.colIdOficinaEntrega});
            this.grvEntregaObjeto.GridControl = this.grdEntregaObjeto;
            this.grvEntregaObjeto.Name = "grvEntregaObjeto";
            this.grvEntregaObjeto.OptionsView.ShowAutoFilterRow = true;
            this.grvEntregaObjeto.OptionsView.ShowGroupPanel = false;
            // 
            // colIdTipoValidacion
            // 
            this.colIdTipoValidacion.Caption = "Validado";
            this.colIdTipoValidacion.FieldName = "idTipoValidacion";
            this.colIdTipoValidacion.MaxWidth = 30;
            this.colIdTipoValidacion.Name = "colIdTipoValidacion";
            this.colIdTipoValidacion.OptionsColumn.ReadOnly = true;
            this.colIdTipoValidacion.ToolTip = "Validado";
            this.colIdTipoValidacion.Width = 20;
            // 
            // colAutogenerado
            // 
            this.colAutogenerado.Caption = "Código de Documento";
            this.colAutogenerado.ColumnEdit = this.linkAutogenerado;
            this.colAutogenerado.FieldName = "Autogenerado";
            this.colAutogenerado.Name = "colAutogenerado";
            this.colAutogenerado.OptionsColumn.ReadOnly = true;
            this.colAutogenerado.Visible = true;
            this.colAutogenerado.VisibleIndex = 0;
            this.colAutogenerado.Width = 118;
            // 
            // linkAutogenerado
            // 
            this.linkAutogenerado.AutoHeight = false;
            this.linkAutogenerado.Name = "linkAutogenerado";
            this.linkAutogenerado.Click += new System.EventHandler(this.linkAutogenerado_Click);
            // 
            // colDe
            // 
            this.colDe.Caption = "De";
            this.colDe.FieldName = "De";
            this.colDe.Name = "colDe";
            this.colDe.OptionsColumn.ReadOnly = true;
            this.colDe.Visible = true;
            this.colDe.VisibleIndex = 2;
            this.colDe.Width = 106;
            // 
            // colOrigen
            // 
            this.colOrigen.Caption = "Origen";
            this.colOrigen.FieldName = "Origen";
            this.colOrigen.Name = "colOrigen";
            this.colOrigen.OptionsColumn.ReadOnly = true;
            this.colOrigen.Visible = true;
            this.colOrigen.VisibleIndex = 3;
            this.colOrigen.Width = 122;
            // 
            // colPara
            // 
            this.colPara.Caption = "Para";
            this.colPara.FieldName = "Para";
            this.colPara.Name = "colPara";
            this.colPara.OptionsColumn.ReadOnly = true;
            this.colPara.Visible = true;
            this.colPara.VisibleIndex = 4;
            this.colPara.Width = 110;
            // 
            // colDestino
            // 
            this.colDestino.Caption = "Destino";
            this.colDestino.FieldName = "Destino";
            this.colDestino.Name = "colDestino";
            this.colDestino.OptionsColumn.ReadOnly = true;
            this.colDestino.Visible = true;
            this.colDestino.VisibleIndex = 5;
            this.colDestino.Width = 113;
            // 
            // colOficina
            // 
            this.colOficina.Caption = "Oficina";
            this.colOficina.FieldName = "Oficina";
            this.colOficina.Name = "colOficina";
            this.colOficina.OptionsColumn.ReadOnly = true;
            this.colOficina.Visible = true;
            this.colOficina.VisibleIndex = 6;
            this.colOficina.Width = 126;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 7;
            this.colEstado.Width = 93;
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
            // gcTipoElemento
            // 
            this.gcTipoElemento.Caption = "Tipo de Documento";
            this.gcTipoElemento.FieldName = "sTipoElemento";
            this.gcTipoElemento.Name = "gcTipoElemento";
            this.gcTipoElemento.OptionsColumn.ReadOnly = true;
            this.gcTipoElemento.Visible = true;
            this.gcTipoElemento.VisibleIndex = 1;
            this.gcTipoElemento.Width = 108;
            // 
            // frmDetalleEntregaSeg
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 397);
            this.Controls.Add(this.grdEntregaObjeto);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmDetalleEntregaSeg";
            this.ShowIcon = false;
            this.Text = "Detalle de la entrega";
            this.Load += new System.EventHandler(this.frmDetalleEntregaSeg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEntregaObjeto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEntregaObjeto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkAutogenerado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl lblPorValidar;
        private DevExpress.XtraEditors.LabelControl lblValidados;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        private DevExpress.XtraEditors.LabelControl lblEntrega;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grdEntregaObjeto;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEntregaObjeto;
        private DevExpress.XtraGrid.Columns.GridColumn colIdTipoValidacion;
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
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkAutogenerado;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipoElemento;
    }
}