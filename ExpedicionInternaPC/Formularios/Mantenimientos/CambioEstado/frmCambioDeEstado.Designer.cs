namespace ExpedicionInternaPC
{
    partial class frmCambioDeEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCambioDeEstado));
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement9 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement10 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement11 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement12 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement13 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement14 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement15 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement16 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.grdcAutogenerado = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcRemitente = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcBandejaRemitente = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcDestinatario = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcBandejaDestinatario = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcGrupoOrigen = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcGrupoDestino = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcEstado = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.txtAutogenerado = new System.Windows.Forms.TextBox();
            this.btnBuscar = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.grdDato = new DevExpress.XtraGrid.GridControl();
            this.tileView = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.grdcFechaCreacion = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcImagen = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdcSeleccionGrafica = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.btnCambiarEstado = new DevExpress.XtraEditors.SimpleButton();
            this.lblCodigo = new DevExpress.XtraEditors.LabelControl();
            this.lblEstado = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdDato)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdcAutogenerado
            // 
            this.grdcAutogenerado.AppearanceCell.Options.UseTextOptions = true;
            this.grdcAutogenerado.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdcAutogenerado.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdcAutogenerado.AppearanceHeader.Options.UseFont = true;
            this.grdcAutogenerado.Caption = "Autogenerado";
            this.grdcAutogenerado.FieldName = "Autogenerado";
            this.grdcAutogenerado.Name = "grdcAutogenerado";
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
            this.grdcRemitente.VisibleIndex = 0;
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
            this.grdcBandejaRemitente.VisibleIndex = 1;
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
            this.grdcDestinatario.VisibleIndex = 2;
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
            this.grdcBandejaDestinatario.VisibleIndex = 3;
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
            this.grdcGrupoOrigen.VisibleIndex = 4;
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
            this.grdcGrupoDestino.VisibleIndex = 5;
            // 
            // grdcEstado
            // 
            this.grdcEstado.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.grdcEstado.AppearanceHeader.Options.UseFont = true;
            this.grdcEstado.Caption = "Estado:";
            this.grdcEstado.FieldName = "Estado";
            this.grdcEstado.Name = "grdcEstado";
            // 
            // txtAutogenerado
            // 
            this.txtAutogenerado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAutogenerado.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtAutogenerado.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtAutogenerado.Location = new System.Drawing.Point(110, 31);
            this.txtAutogenerado.MaxLength = 30;
            this.txtAutogenerado.Name = "txtAutogenerado";
            this.txtAutogenerado.Size = new System.Drawing.Size(273, 21);
            this.txtAutogenerado.TabIndex = 9;
            this.txtAutogenerado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAutogenerado_KeyDown);
            this.txtAutogenerado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAutogenerado_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnBuscar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.ImageOptions.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(389, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 33);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Código :";
            // 
            // grdDato
            // 
            this.grdDato.Location = new System.Drawing.Point(15, 126);
            this.grdDato.MainView = this.tileView;
            this.grdDato.Margin = new System.Windows.Forms.Padding(0);
            this.grdDato.Name = "grdDato";
            this.grdDato.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdDato.Size = new System.Drawing.Size(482, 255);
            this.grdDato.TabIndex = 11;
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
            this.grdcEstado,
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
            this.tileView.OptionsTiles.ItemSize = new System.Drawing.Size(400, 180);
            this.tileView.OptionsTiles.Padding = new System.Windows.Forms.Padding(0, 0, 0, 60);
            tileViewItemElement9.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement9.Appearance.Hovered.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement9.Appearance.Hovered.ForeColor = System.Drawing.Color.Red;
            tileViewItemElement9.Appearance.Hovered.Options.UseFont = true;
            tileViewItemElement9.Appearance.Hovered.Options.UseForeColor = true;
            tileViewItemElement9.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement9.Appearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement9.Appearance.Normal.ForeColor = System.Drawing.Color.Red;
            tileViewItemElement9.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement9.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement9.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement9.Appearance.Pressed.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement9.Appearance.Pressed.ForeColor = System.Drawing.Color.Red;
            tileViewItemElement9.Appearance.Pressed.Options.UseFont = true;
            tileViewItemElement9.Appearance.Pressed.Options.UseForeColor = true;
            tileViewItemElement9.Appearance.Selected.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement9.Appearance.Selected.FontStyleDelta = System.Drawing.FontStyle.Bold;
            tileViewItemElement9.Appearance.Selected.ForeColor = System.Drawing.Color.Red;
            tileViewItemElement9.Appearance.Selected.Options.UseFont = true;
            tileViewItemElement9.Appearance.Selected.Options.UseForeColor = true;
            tileViewItemElement9.Column = this.grdcAutogenerado;
            tileViewItemElement9.Text = "grdcAutogenerado";
            tileViewItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement9.TextLocation = new System.Drawing.Point(8, 50);
            tileViewItemElement10.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement10.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement10.Column = this.grdcRemitente;
            tileViewItemElement10.Text = "grdcRemitente";
            tileViewItemElement10.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement10.TextLocation = new System.Drawing.Point(10, 0);
            tileViewItemElement11.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement11.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement11.Column = this.grdcBandejaRemitente;
            tileViewItemElement11.Text = "grdcBandejaRemitente";
            tileViewItemElement11.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement11.TextLocation = new System.Drawing.Point(10, 25);
            tileViewItemElement12.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement12.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement12.Column = this.grdcDestinatario;
            tileViewItemElement12.Text = "grdcDestinatario";
            tileViewItemElement12.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement12.TextLocation = new System.Drawing.Point(10, 80);
            tileViewItemElement13.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement13.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement13.Column = this.grdcBandejaDestinatario;
            tileViewItemElement13.Text = "grdcBandejaDestinatario";
            tileViewItemElement13.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement13.TextLocation = new System.Drawing.Point(10, 105);
            tileViewItemElement14.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement14.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement14.Column = this.grdcGrupoOrigen;
            tileViewItemElement14.Text = "grdcGrupoOrigen";
            tileViewItemElement14.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement14.TextLocation = new System.Drawing.Point(10, 50);
            tileViewItemElement15.Appearance.Normal.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            tileViewItemElement15.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement15.Column = this.grdcGrupoDestino;
            tileViewItemElement15.Text = "grdcGrupoDestino";
            tileViewItemElement15.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement15.TextLocation = new System.Drawing.Point(10, 130);
            tileViewItemElement16.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            tileViewItemElement16.Appearance.Normal.ForeColor = System.Drawing.Color.Black;
            tileViewItemElement16.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement16.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement16.Appearance.Normal.Options.UseTextOptions = true;
            tileViewItemElement16.Appearance.Normal.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            tileViewItemElement16.Appearance.Normal.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            tileViewItemElement16.Appearance.Selected.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement16.Appearance.Selected.Options.UseFont = true;
            tileViewItemElement16.Column = this.grdcEstado;
            tileViewItemElement16.Text = "grdcEstado";
            tileViewItemElement16.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement16.TextLocation = new System.Drawing.Point(10, 90);
            this.tileView.TileTemplate.Add(tileViewItemElement9);
            this.tileView.TileTemplate.Add(tileViewItemElement10);
            this.tileView.TileTemplate.Add(tileViewItemElement11);
            this.tileView.TileTemplate.Add(tileViewItemElement12);
            this.tileView.TileTemplate.Add(tileViewItemElement13);
            this.tileView.TileTemplate.Add(tileViewItemElement14);
            this.tileView.TileTemplate.Add(tileViewItemElement15);
            this.tileView.TileTemplate.Add(tileViewItemElement16);
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
            this.grdcFechaCreacion.VisibleIndex = 6;
            // 
            // grdcImagen
            // 
            this.grdcImagen.AppearanceCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdcImagen.AppearanceCell.Options.UseFont = true;
            this.grdcImagen.Caption = "BarCode";
            this.grdcImagen.FieldName = "Autogenerado";
            this.grdcImagen.Name = "grdcImagen";
            this.grdcImagen.Visible = true;
            this.grdcImagen.VisibleIndex = 7;
            // 
            // grdcSeleccionGrafica
            // 
            this.grdcSeleccionGrafica.Caption = "Seleccion";
            this.grdcSeleccionGrafica.FieldName = "SeleccionGrafica";
            this.grdcSeleccionGrafica.Name = "grdcSeleccionGrafica";
            this.grdcSeleccionGrafica.Visible = true;
            this.grdcSeleccionGrafica.VisibleIndex = 8;
            // 
            // btnCambiarEstado
            // 
            this.btnCambiarEstado.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCambiarEstado.ImageOptions.Image = global::ExpedicionInternaPC.Properties.Resources.arrowrefresh32;
            this.btnCambiarEstado.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnCambiarEstado.Location = new System.Drawing.Point(199, 384);
            this.btnCambiarEstado.Name = "btnCambiarEstado";
            this.btnCambiarEstado.Size = new System.Drawing.Size(131, 42);
            this.btnCambiarEstado.TabIndex = 10;
            this.btnCambiarEstado.Text = "Cambiar estado";
            this.btnCambiarEstado.Click += new System.EventHandler(this.btnCambiarEstado_Click);
            // 
            // lblCodigo
            // 
            this.lblCodigo.Appearance.BackColor = System.Drawing.Color.White;
            this.lblCodigo.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigo.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblCodigo.Appearance.Options.UseBackColor = true;
            this.lblCodigo.Appearance.Options.UseFont = true;
            this.lblCodigo.Appearance.Options.UseForeColor = true;
            this.lblCodigo.Appearance.Options.UseTextOptions = true;
            this.lblCodigo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCodigo.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCodigo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCodigo.Location = new System.Drawing.Point(15, 62);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(482, 41);
            this.lblCodigo.TabIndex = 12;
            // 
            // lblEstado
            // 
            this.lblEstado.Appearance.BackColor = System.Drawing.Color.White;
            this.lblEstado.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Appearance.ForeColor = System.Drawing.Color.IndianRed;
            this.lblEstado.Appearance.Options.UseBackColor = true;
            this.lblEstado.Appearance.Options.UseFont = true;
            this.lblEstado.Appearance.Options.UseForeColor = true;
            this.lblEstado.Appearance.Options.UseTextOptions = true;
            this.lblEstado.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblEstado.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblEstado.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEstado.Location = new System.Drawing.Point(15, 97);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(482, 26);
            this.lblEstado.TabIndex = 12;
            // 
            // frmCambioDeEstado
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 435);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.grdDato);
            this.Controls.Add(this.btnCambiarEstado);
            this.Controls.Add(this.txtAutogenerado);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "frmCambioDeEstado";
            this.Text = "Cambio de Estado";
            this.Load += new System.EventHandler(this.frmCambioDeEstado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdDato)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAutogenerado;
        private DevExpress.XtraEditors.SimpleButton btnBuscar;
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
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcSeleccionGrafica;
        private DevExpress.XtraEditors.SimpleButton btnCambiarEstado;
        private DevExpress.XtraGrid.Columns.TileViewColumn grdcEstado;
        private DevExpress.XtraEditors.LabelControl lblCodigo;
        private DevExpress.XtraEditors.LabelControl lblEstado;


    }
}