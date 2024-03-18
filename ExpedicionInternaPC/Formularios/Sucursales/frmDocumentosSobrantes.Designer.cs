namespace ExpedicionInternaPC.Formularios.Expedicion
{
    partial class frmDocumentosSobrantes
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
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocumentosSobrantes));
            this.grdcImagen = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcRemitente = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcBandejaRemitente = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcDestinatario = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcBandejaDestinatario = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcGrupoOrigen = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcGrupoDestino = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcAutogenerado = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcFechaCreacion = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.btnCustodiar = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grdDato = new DevExpress.XtraGrid.GridControl();
            this.tileView = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.grdcSeleccionGrafica = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancelar = new DevExpress.XtraEditors.SimpleButton();
            this.txtAutogenerado = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdDato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdcImagen
            // 
            this.grdcImagen.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdcImagen.AppearanceCell.Options.UseFont = true;
            this.grdcImagen.Caption = "BarCode";
            this.grdcImagen.FieldName = "Autogenerado";
            this.grdcImagen.Name = "grdcImagen";
            this.grdcImagen.Visible = true;
            this.grdcImagen.VisibleIndex = 8;
            // 
            // grdcRemitente
            // 
            this.grdcRemitente.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdcRemitente.AppearanceCell.Options.UseFont = true;
            this.grdcRemitente.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdcRemitente.AppearanceHeader.ForeColor = System.Drawing.Color.DarkKhaki;
            this.grdcRemitente.AppearanceHeader.Options.UseFont = true;
            this.grdcRemitente.AppearanceHeader.Options.UseForeColor = true;
            this.grdcRemitente.Caption = "De                                 :";
            this.grdcRemitente.FieldName = "De";
            this.grdcRemitente.Name = "grdcRemitente";
            this.grdcRemitente.OptionsColumn.ShowCaption = true;
            this.grdcRemitente.Visible = true;
            this.grdcRemitente.VisibleIndex = 1;
            // 
            // grdcBandejaRemitente
            // 
            this.grdcBandejaRemitente.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdcBandejaRemitente.AppearanceCell.Options.UseFont = true;
            this.grdcBandejaRemitente.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdcBandejaRemitente.AppearanceHeader.ForeColor = System.Drawing.Color.DarkKhaki;
            this.grdcBandejaRemitente.AppearanceHeader.Options.UseFont = true;
            this.grdcBandejaRemitente.AppearanceHeader.Options.UseForeColor = true;
            this.grdcBandejaRemitente.Caption = "Origen                          :";
            this.grdcBandejaRemitente.FieldName = "CasillaDe";
            this.grdcBandejaRemitente.Name = "grdcBandejaRemitente";
            this.grdcBandejaRemitente.OptionsColumn.ShowCaption = true;
            this.grdcBandejaRemitente.Visible = true;
            this.grdcBandejaRemitente.VisibleIndex = 2;
            // 
            // grdcDestinatario
            // 
            this.grdcDestinatario.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdcDestinatario.AppearanceCell.Options.UseFont = true;
            this.grdcDestinatario.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdcDestinatario.AppearanceHeader.ForeColor = System.Drawing.Color.DarkKhaki;
            this.grdcDestinatario.AppearanceHeader.Options.UseFont = true;
            this.grdcDestinatario.AppearanceHeader.Options.UseForeColor = true;
            this.grdcDestinatario.Caption = "Para                               :";
            this.grdcDestinatario.FieldName = "Para";
            this.grdcDestinatario.Name = "grdcDestinatario";
            this.grdcDestinatario.OptionsColumn.ShowCaption = true;
            this.grdcDestinatario.Visible = true;
            this.grdcDestinatario.VisibleIndex = 3;
            // 
            // grdcBandejaDestinatario
            // 
            this.grdcBandejaDestinatario.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdcBandejaDestinatario.AppearanceCell.Options.UseFont = true;
            this.grdcBandejaDestinatario.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdcBandejaDestinatario.AppearanceHeader.ForeColor = System.Drawing.Color.DarkKhaki;
            this.grdcBandejaDestinatario.AppearanceHeader.Options.UseFont = true;
            this.grdcBandejaDestinatario.AppearanceHeader.Options.UseForeColor = true;
            this.grdcBandejaDestinatario.Caption = "Destino                         :";
            this.grdcBandejaDestinatario.FieldName = "CasillaPara";
            this.grdcBandejaDestinatario.Name = "grdcBandejaDestinatario";
            this.grdcBandejaDestinatario.OptionsColumn.ShowCaption = true;
            this.grdcBandejaDestinatario.Visible = true;
            this.grdcBandejaDestinatario.VisibleIndex = 4;
            // 
            // grdcGrupoOrigen
            // 
            this.grdcGrupoOrigen.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            this.grdcGrupoOrigen.AppearanceCell.Options.UseFont = true;
            this.grdcGrupoOrigen.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdcGrupoOrigen.AppearanceHeader.ForeColor = System.Drawing.Color.DarkKhaki;
            this.grdcGrupoOrigen.AppearanceHeader.Options.UseFont = true;
            this.grdcGrupoOrigen.AppearanceHeader.Options.UseForeColor = true;
            this.grdcGrupoOrigen.Caption = "Expedición origen       :";
            this.grdcGrupoOrigen.FieldName = "ExpedicionDe";
            this.grdcGrupoOrigen.Name = "grdcGrupoOrigen";
            this.grdcGrupoOrigen.OptionsColumn.ShowCaption = true;
            this.grdcGrupoOrigen.Visible = true;
            this.grdcGrupoOrigen.VisibleIndex = 5;
            // 
            // grdcGrupoDestino
            // 
            this.grdcGrupoDestino.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            this.grdcGrupoDestino.AppearanceCell.Options.UseFont = true;
            this.grdcGrupoDestino.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdcGrupoDestino.AppearanceHeader.ForeColor = System.Drawing.Color.DarkKhaki;
            this.grdcGrupoDestino.AppearanceHeader.Options.UseFont = true;
            this.grdcGrupoDestino.AppearanceHeader.Options.UseForeColor = true;
            this.grdcGrupoDestino.Caption = "Expedición destino      :";
            this.grdcGrupoDestino.FieldName = "ExpedicionPara";
            this.grdcGrupoDestino.Name = "grdcGrupoDestino";
            this.grdcGrupoDestino.OptionsColumn.ShowCaption = true;
            this.grdcGrupoDestino.Visible = true;
            this.grdcGrupoDestino.VisibleIndex = 6;
            // 
            // grdcAutogenerado
            // 
            this.grdcAutogenerado.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdcAutogenerado.AppearanceHeader.Options.UseFont = true;
            this.grdcAutogenerado.Caption = "Autogenerado";
            this.grdcAutogenerado.FieldName = "Autogenerado";
            this.grdcAutogenerado.Name = "grdcAutogenerado";
            this.grdcAutogenerado.Visible = true;
            this.grdcAutogenerado.VisibleIndex = 0;
            // 
            // grdcFechaCreacion
            // 
            this.grdcFechaCreacion.AppearanceCell.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            this.grdcFechaCreacion.AppearanceCell.Options.UseFont = true;
            this.grdcFechaCreacion.AppearanceHeader.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold);
            this.grdcFechaCreacion.AppearanceHeader.ForeColor = System.Drawing.Color.DarkKhaki;
            this.grdcFechaCreacion.AppearanceHeader.Options.UseFont = true;
            this.grdcFechaCreacion.AppearanceHeader.Options.UseForeColor = true;
            this.grdcFechaCreacion.Caption = "Creado El                      :";
            this.grdcFechaCreacion.DisplayFormat.FormatString = "d";
            this.grdcFechaCreacion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.grdcFechaCreacion.FieldName = "CreadoEl";
            this.grdcFechaCreacion.Name = "grdcFechaCreacion";
            this.grdcFechaCreacion.OptionsColumn.ShowCaption = true;
            this.grdcFechaCreacion.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            this.grdcFechaCreacion.Visible = true;
            this.grdcFechaCreacion.VisibleIndex = 7;
            // 
            // btnCustodiar
            // 
            this.btnCustodiar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCustodiar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.applicationfromstorage32;
            this.btnCustodiar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCustodiar.Location = new System.Drawing.Point(179, 353);
            this.btnCustodiar.Name = "btnCustodiar";
            this.btnCustodiar.Size = new System.Drawing.Size(119, 42);
            this.btnCustodiar.TabIndex = 0;
            this.btnCustodiar.Text = "Custodiar";
            this.btnCustodiar.Click += new System.EventHandler(this.btnCustodiar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Autogenerado";
            // 
            // grdDato
            // 
            this.grdDato.Location = new System.Drawing.Point(9, 54);
            this.grdDato.MainView = this.tileView;
            this.grdDato.Margin = new System.Windows.Forms.Padding(0);
            this.grdDato.Name = "grdDato";
            this.grdDato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdDato.Size = new System.Drawing.Size(619, 278);
            this.grdDato.TabIndex = 3;
            this.grdDato.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileView});
            // 
            // tileView
            // 
            this.tileView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdcAutogenerado,
            this.grdcRemitente,
            this.grdcBandejaRemitente,
            this.grdcDestinatario,
            this.grdcBandejaDestinatario,
            this.grdcGrupoOrigen,
            this.grdcGrupoDestino,
            this.grdcFechaCreacion,
            this.grdcImagen,
            this.grdcSeleccionGrafica});
            this.tileView.ContextButtonOptions.BottomPanelPadding = new System.Windows.Forms.Padding(0);
            this.tileView.ContextButtonOptions.TopPanelPadding = new System.Windows.Forms.Padding(0);
            this.tileView.GridControl = this.grdDato;
            this.tileView.Name = "tileView";
            this.tileView.OptionsFind.AllowFindPanel = false;
            this.tileView.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(12);
            this.tileView.OptionsTiles.ItemSize = new System.Drawing.Size(594, 180);
            this.tileView.OptionsTiles.Padding = new System.Windows.Forms.Padding(0);
            tileViewItemElement1.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Hovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement1.Appearance.Hovered.ForeColor = System.Drawing.Color.Red;
            tileViewItemElement1.Appearance.Hovered.Options.UseFont = true;
            tileViewItemElement1.Appearance.Hovered.Options.UseForeColor = true;
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.Red;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Pressed.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement1.Appearance.Pressed.ForeColor = System.Drawing.Color.Red;
            tileViewItemElement1.Appearance.Pressed.Options.UseFont = true;
            tileViewItemElement1.Appearance.Pressed.Options.UseForeColor = true;
            tileViewItemElement1.Appearance.Selected.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Selected.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement1.Appearance.Selected.ForeColor = System.Drawing.Color.Red;
            tileViewItemElement1.Appearance.Selected.Options.UseFont = true;
            tileViewItemElement1.Appearance.Selected.Options.UseForeColor = true;
            tileViewItemElement1.Column = this.grdcImagen;
            tileViewItemElement1.Text = "grdcImagen";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement1.TextLocation = new System.Drawing.Point(20, 70);
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Column = this.grdcRemitente;
            tileViewItemElement2.Text = "grdcRemitente";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(160, 0);
            tileViewItemElement3.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement3.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement3.Column = this.grdcBandejaRemitente;
            tileViewItemElement3.Text = "grdcBandejaRemitente";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(160, 25);
            tileViewItemElement4.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement4.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement4.Column = this.grdcDestinatario;
            tileViewItemElement4.Text = "grdcDestinatario";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement4.TextLocation = new System.Drawing.Point(160, 80);
            tileViewItemElement5.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement5.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement5.Column = this.grdcBandejaDestinatario;
            tileViewItemElement5.Text = "grdcBandejaDestinatario";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement5.TextLocation = new System.Drawing.Point(160, 105);
            tileViewItemElement6.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement6.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement6.Column = this.grdcGrupoOrigen;
            tileViewItemElement6.Text = "grdcGrupoOrigen";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement6.TextLocation = new System.Drawing.Point(160, 50);
            tileViewItemElement7.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement7.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement7.Column = this.grdcGrupoDestino;
            tileViewItemElement7.Text = "grdcGrupoDestino";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement7.TextLocation = new System.Drawing.Point(160, 130);
            this.tileView.TileTemplate.Add(tileViewItemElement1);
            this.tileView.TileTemplate.Add(tileViewItemElement2);
            this.tileView.TileTemplate.Add(tileViewItemElement3);
            this.tileView.TileTemplate.Add(tileViewItemElement4);
            this.tileView.TileTemplate.Add(tileViewItemElement5);
            this.tileView.TileTemplate.Add(tileViewItemElement6);
            this.tileView.TileTemplate.Add(tileViewItemElement7);
            this.tileView.DoubleClick += new System.EventHandler(this.tileView_DoubleClick);
            // 
            // grdcSeleccionGrafica
            // 
            this.grdcSeleccionGrafica.Caption = "Seleccion";
            this.grdcSeleccionGrafica.FieldName = "SeleccionGrafica";
            this.grdcSeleccionGrafica.Name = "grdcSeleccionGrafica";
            this.grdcSeleccionGrafica.Visible = true;
            this.grdcSeleccionGrafica.VisibleIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(377, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 33);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancelar.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.CancelDev32;
            this.btnCancelar.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(366, 353);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 42);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtAutogenerado
            // 
            this.txtAutogenerado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAutogenerado.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtAutogenerado.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtAutogenerado.Location = new System.Drawing.Point(110, 26);
            this.txtAutogenerado.MaxLength = 20;
            this.txtAutogenerado.Name = "txtAutogenerado";
            this.txtAutogenerado.Size = new System.Drawing.Size(146, 21);
            this.txtAutogenerado.TabIndex = 6;
            this.txtAutogenerado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAutogenerado_KeyDown);
            this.txtAutogenerado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutogenerado_KeyPress);
            // 
            // frmDocumentosSobrantes
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 418);
            this.Controls.Add(this.txtAutogenerado);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.grdDato);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCustodiar);
            this.Name = "frmDocumentosSobrantes";
            this.Text = "Documentos Sobrantes";
            this.Load += new System.EventHandler(this.frmDocumentosSobrantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCustodiar;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grdDato;
        private DevExpress.XtraGrid.Views.Tile.TileView tileView;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcAutogenerado;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcRemitente;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcBandejaRemitente;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcDestinatario;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcBandejaDestinatario;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcGrupoOrigen;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcGrupoDestino;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcFechaCreacion;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcImagen;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcSeleccionGrafica;
        private DevExpress.XtraEditors.SimpleButton btnCancelar;
        private System.Windows.Forms.TextBox txtAutogenerado;
    }
}