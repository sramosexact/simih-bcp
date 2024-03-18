using System.Collections.Generic;
using System.Data;
namespace ExpedicionInternaPC
{
    partial class frmEntregaPisosResultado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntregaPisosResultado));
            this.btnGuardar = new DevExpress.XtraEditors.SimpleButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblAutogenerado = new System.Windows.Forms.ToolStripLabel();
            this.txtAutogenerado = new System.Windows.Forms.ToolStripTextBox();
            this.btnEntrega = new System.Windows.Forms.ToolStripButton();
            this.lblEntregadosPDA = new System.Windows.Forms.ToolStripLabel();
            this.txtEntregados = new System.Windows.Forms.ToolStripLabel();
            this.lblEntregadosManual = new System.Windows.Forms.ToolStripLabel();
            this.txtEntregadosNo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnHabilitarEntregaManual = new System.Windows.Forms.ToolStripButton();
            this.btnFinalizar = new DevExpress.XtraEditors.SimpleButton();
            this.grdDatos = new DevExpress.XtraGrid.GridControl();
            this.grdViewDatos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridAutogenerado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.gcTipoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridRemitente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDestinatario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridObservacionEntrega = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridValorPDA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnGuardar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.saveas32;
            this.btnGuardar.Location = new System.Drawing.Point(289, 381);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(151, 38);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblAutogenerado,
            this.txtAutogenerado,
            this.btnEntrega,
            this.lblEntregadosPDA,
            this.txtEntregados,
            this.lblEntregadosManual,
            this.txtEntregadosNo,
            this.toolStripSeparator1,
            this.btnHabilitarEntregaManual});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1120, 54);
            this.toolStrip1.TabIndex = 14;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblAutogenerado
            // 
            this.lblAutogenerado.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblAutogenerado.Image = ((System.Drawing.Image)(resources.GetObject("lblAutogenerado.Image")));
            this.lblAutogenerado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lblAutogenerado.Name = "lblAutogenerado";
            this.lblAutogenerado.Size = new System.Drawing.Size(89, 51);
            this.lblAutogenerado.Text = "Autogenerado :";
            this.lblAutogenerado.Visible = false;
            // 
            // txtAutogenerado
            // 
            this.txtAutogenerado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutogenerado.MaxLength = 20;
            this.txtAutogenerado.Name = "txtAutogenerado";
            this.txtAutogenerado.Size = new System.Drawing.Size(100, 54);
            this.txtAutogenerado.Visible = false;
            this.txtAutogenerado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAutogenerado_KeyDown);
            this.txtAutogenerado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutogenerado_KeyPress);
            this.txtAutogenerado.TextChanged += new System.EventHandler(this.txtAutogenerado_TextChanged);
            // 
            // btnEntrega
            // 
            this.btnEntrega.Image = global::ExpedicionInternaPC.Properties.Resources.inboxdocumenttext32;
            this.btnEntrega.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEntrega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEntrega.Name = "btnEntrega";
            this.btnEntrega.Size = new System.Drawing.Size(126, 51);
            this.btnEntrega.Text = "Entrega Manual";
            this.btnEntrega.Visible = false;
            this.btnEntrega.Click += new System.EventHandler(this.btnEntregaManual_Click);
            // 
            // lblEntregadosPDA
            // 
            this.lblEntregadosPDA.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntregadosPDA.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEntregadosPDA.Name = "lblEntregadosPDA";
            this.lblEntregadosPDA.Size = new System.Drawing.Size(90, 51);
            this.lblEntregadosPDA.Text = "Entregados:";
            // 
            // txtEntregados
            // 
            this.txtEntregados.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntregados.ForeColor = System.Drawing.Color.Red;
            this.txtEntregados.Name = "txtEntregados";
            this.txtEntregados.Size = new System.Drawing.Size(15, 51);
            this.txtEntregados.Text = "0";
            // 
            // lblEntregadosManual
            // 
            this.lblEntregadosManual.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntregadosManual.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEntregadosManual.Name = "lblEntregadosManual";
            this.lblEntregadosManual.Size = new System.Drawing.Size(119, 51);
            this.lblEntregadosManual.Text = "No Entregados :";
            // 
            // txtEntregadosNo
            // 
            this.txtEntregadosNo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.txtEntregadosNo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntregadosNo.ForeColor = System.Drawing.Color.Red;
            this.txtEntregadosNo.Image = ((System.Drawing.Image)(resources.GetObject("txtEntregadosNo.Image")));
            this.txtEntregadosNo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.txtEntregadosNo.Name = "txtEntregadosNo";
            this.txtEntregadosNo.Size = new System.Drawing.Size(15, 51);
            this.txtEntregadosNo.Text = "0";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // btnHabilitarEntregaManual
            // 
            this.btnHabilitarEntregaManual.Image = global::ExpedicionInternaPC.Properties.Resources.safe32;
            this.btnHabilitarEntregaManual.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnHabilitarEntregaManual.ImageTransparentColor = System.Drawing.Color.White;
            this.btnHabilitarEntregaManual.Name = "btnHabilitarEntregaManual";
            this.btnHabilitarEntregaManual.Size = new System.Drawing.Size(151, 51);
            this.btnHabilitarEntregaManual.Text = "Habilitar Ent.Manual";
            this.btnHabilitarEntregaManual.Click += new System.EventHandler(this.btnHabilitarEntregaManual_Click);
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnFinalizar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.drawer32;
            this.btnFinalizar.Location = new System.Drawing.Point(688, 381);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(158, 38);
            this.btnFinalizar.TabIndex = 12;
            this.btnFinalizar.Text = "Cerrar Entrega";
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // grdDatos
            // 
            this.grdDatos.Location = new System.Drawing.Point(2, 59);
            this.grdDatos.MainView = this.grdViewDatos;
            this.grdDatos.Name = "grdDatos";
            this.grdDatos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1,
            this.repositoryItemImageComboBox1});
            this.grdDatos.Size = new System.Drawing.Size(1120, 316);
            this.grdDatos.TabIndex = 11;
            this.grdDatos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewDatos});
            // 
            // grdViewDatos
            // 
            this.grdViewDatos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridAutogenerado,
            this.gcTipoDocumento,
            this.gridRemitente,
            this.gridOrigen,
            this.gridDestinatario,
            this.gridDestino,
            this.colTipoDestino,
            this.gridColumn3,
            this.gridObservacionEntrega,
            this.gridValorPDA,
            this.gridColumn1,
            this.gridColumn2,
            this.gridEstado,
            this.gridColumn4});
            this.grdViewDatos.GridControl = this.grdDatos;
            this.grdViewDatos.Name = "grdViewDatos";
            this.grdViewDatos.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grdViewDatos.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grdViewDatos.OptionsView.ShowGroupPanel = false;
            this.grdViewDatos.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdViewDatos_RowStyle);
            // 
            // gridAutogenerado
            // 
            this.gridAutogenerado.Caption = "Código de Documento";
            this.gridAutogenerado.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.gridAutogenerado.FieldName = "Autogenerado";
            this.gridAutogenerado.Name = "gridAutogenerado";
            this.gridAutogenerado.Visible = true;
            this.gridAutogenerado.VisibleIndex = 0;
            this.gridAutogenerado.Width = 146;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            this.repositoryItemHyperLinkEdit1.SingleClick = true;
            this.repositoryItemHyperLinkEdit1.Click += new System.EventHandler(this.repositoryItemHyperLinkEdit1_Click);
            // 
            // gcTipoDocumento
            // 
            this.gcTipoDocumento.Caption = "Tipo de Documento";
            this.gcTipoDocumento.FieldName = "sTipoElemento";
            this.gcTipoDocumento.Name = "gcTipoDocumento";
            this.gcTipoDocumento.OptionsColumn.ReadOnly = true;
            this.gcTipoDocumento.Visible = true;
            this.gcTipoDocumento.VisibleIndex = 1;
            this.gcTipoDocumento.Width = 132;
            // 
            // gridRemitente
            // 
            this.gridRemitente.Caption = "Remitente";
            this.gridRemitente.FieldName = "De";
            this.gridRemitente.Name = "gridRemitente";
            this.gridRemitente.OptionsColumn.AllowEdit = false;
            this.gridRemitente.OptionsColumn.ReadOnly = true;
            this.gridRemitente.Width = 128;
            // 
            // gridOrigen
            // 
            this.gridOrigen.Caption = "Origen";
            this.gridOrigen.FieldName = "Origen";
            this.gridOrigen.Name = "gridOrigen";
            this.gridOrigen.OptionsColumn.AllowEdit = false;
            this.gridOrigen.OptionsColumn.ReadOnly = true;
            this.gridOrigen.Width = 184;
            // 
            // gridDestinatario
            // 
            this.gridDestinatario.Caption = "Destinatario";
            this.gridDestinatario.FieldName = "Para";
            this.gridDestinatario.Name = "gridDestinatario";
            this.gridDestinatario.OptionsColumn.AllowEdit = false;
            this.gridDestinatario.OptionsColumn.ReadOnly = true;
            this.gridDestinatario.Visible = true;
            this.gridDestinatario.VisibleIndex = 2;
            this.gridDestinatario.Width = 136;
            // 
            // gridDestino
            // 
            this.gridDestino.Caption = "Destino";
            this.gridDestino.FieldName = "Destino";
            this.gridDestino.Name = "gridDestino";
            this.gridDestino.OptionsColumn.AllowEdit = false;
            this.gridDestino.OptionsColumn.ReadOnly = true;
            this.gridDestino.Visible = true;
            this.gridDestino.VisibleIndex = 3;
            this.gridDestino.Width = 117;
            // 
            // colTipoDestino
            // 
            this.colTipoDestino.Caption = "Tipo destino";
            this.colTipoDestino.FieldName = "sTipoDestinoEntregaPisos";
            this.colTipoDestino.Name = "colTipoDestino";
            this.colTipoDestino.Visible = true;
            this.colTipoDestino.VisibleIndex = 4;
            this.colTipoDestino.Width = 79;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Dejado en ";
            this.gridColumn3.FieldName = "OficinaEntrega";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 87;
            // 
            // gridObservacionEntrega
            // 
            this.gridObservacionEntrega.Caption = "Observación entrega";
            this.gridObservacionEntrega.FieldName = "ObservacionEntrega";
            this.gridObservacionEntrega.Name = "gridObservacionEntrega";
            this.gridObservacionEntrega.OptionsColumn.ReadOnly = true;
            this.gridObservacionEntrega.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridObservacionEntrega.Visible = true;
            this.gridObservacionEntrega.VisibleIndex = 6;
            this.gridObservacionEntrega.Width = 112;
            // 
            // gridValorPDA
            // 
            this.gridValorPDA.Caption = "Valor PDA";
            this.gridValorPDA.FieldName = "EntregaIdentificacion";
            this.gridValorPDA.Name = "gridValorPDA";
            this.gridValorPDA.OptionsColumn.ReadOnly = true;
            this.gridValorPDA.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.gridValorPDA.Visible = true;
            this.gridValorPDA.VisibleIndex = 7;
            this.gridValorPDA.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Tipo Resultado";
            this.gridColumn1.ColumnEdit = this.repositoryItemImageComboBox1;
            this.gridColumn1.FieldName = "IdTipoResultado";
            this.gridColumn1.ImageOptions.Alignment = System.Drawing.StringAlignment.Center;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 8;
            this.gridColumn1.Width = 61;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 72, 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 73, 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", 278, 0)});
            this.repositoryItemImageComboBox1.LargeImages = this.imageCollection1;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            this.repositoryItemImageComboBox1.ReadOnly = true;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.blackberry32, "blackberry32", typeof(global::ExpedicionInternaPC.Properties.Resources), 0);
            this.imageCollection1.Images.SetKeyName(0, "blackberry32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.EditDevX32, "EditDevX32", typeof(global::ExpedicionInternaPC.Properties.Resources), 1);
            this.imageCollection1.Images.SetKeyName(1, "EditDevX32");
            this.imageCollection1.InsertImage(global::ExpedicionInternaPC.Properties.Resources.blackberrywhite32, "blackberrywhite32", typeof(global::ExpedicionInternaPC.Properties.Resources), 2);
            this.imageCollection1.Images.SetKeyName(2, "blackberrywhite32");
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha Resultado";
            this.gridColumn2.DisplayFormat.FormatString = "G";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn2.FieldName = "fechaResultado";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 9;
            this.gridColumn2.Width = 83;
            // 
            // gridEstado
            // 
            this.gridEstado.Caption = "Estado";
            this.gridEstado.FieldName = "Estado";
            this.gridEstado.Name = "gridEstado";
            this.gridEstado.OptionsColumn.AllowEdit = false;
            this.gridEstado.OptionsColumn.ReadOnly = true;
            this.gridEstado.SortMode = DevExpress.XtraGrid.ColumnSortMode.DisplayText;
            this.gridEstado.Visible = true;
            this.gridEstado.VisibleIndex = 10;
            this.gridEstado.Width = 49;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "ID";
            this.gridColumn4.FieldName = "ID";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            // 
            // frmEntregaPisosResultado
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 427);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnFinalizar);
            this.Controls.Add(this.grdDatos);
            this.Name = "frmEntregaPisosResultado";
            this.Text = "Entrega Pisos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEntregaPisosResultado_FormClosing);
            this.Load += new System.EventHandler(this.frmEntregaPisosResultado_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnGuardar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel lblAutogenerado;
        private System.Windows.Forms.ToolStripTextBox txtAutogenerado;
        private System.Windows.Forms.ToolStripButton btnEntrega;
        private System.Windows.Forms.ToolStripLabel lblEntregadosPDA;
        private System.Windows.Forms.ToolStripLabel txtEntregados;
        private System.Windows.Forms.ToolStripLabel lblEntregadosManual;
        private System.Windows.Forms.ToolStripLabel txtEntregadosNo;
        private DevExpress.XtraEditors.SimpleButton btnFinalizar;
        private DevExpress.XtraGrid.GridControl grdDatos;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewDatos;
        private DevExpress.XtraGrid.Columns.GridColumn gridAutogenerado;
        private DevExpress.XtraGrid.Columns.GridColumn gridRemitente;
        private DevExpress.XtraGrid.Columns.GridColumn gridOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn gridDestinatario;
        private DevExpress.XtraGrid.Columns.GridColumn gridDestino;
        private DevExpress.XtraGrid.Columns.GridColumn gridEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnHabilitarEntregaManual;
        private DevExpress.XtraGrid.Columns.GridColumn gcTipoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDestino;
        private DevExpress.XtraGrid.Columns.GridColumn gridObservacionEntrega;
        private DevExpress.XtraGrid.Columns.GridColumn gridValorPDA;
    }
}