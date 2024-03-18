namespace ExpedicionInternaPC
{
    partial class frmListaReclamos
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.grdReclamos = new DevExpress.XtraGrid.GridControl();
            this.grvReclamos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdCodigoReclamo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkCodigoReclamo = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcFechaRegistro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcUsuarioCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcTipoReclamoUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcDocReferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcFechaAtencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcFechaSolucion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcFechaVerificacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcEstadoReclamo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCorreccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkReclamo = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReclamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReclamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkCodigoReclamo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkReclamo)).BeginInit();
            this.SuspendLayout();
            // 
            // grdReclamos
            // 
            this.grdReclamos.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gridLevelNode1.RelationName = "Level1";
            this.grdReclamos.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grdReclamos.Location = new System.Drawing.Point(14, 17);
            this.grdReclamos.MainView = this.grvReclamos;
            this.grdReclamos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdReclamos.Name = "grdReclamos";
            this.grdReclamos.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkCodigoReclamo,
            this.linkReclamo});
            this.grdReclamos.Size = new System.Drawing.Size(1316, 788);
            this.grdReclamos.TabIndex = 0;
            this.grdReclamos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvReclamos});
            // 
            // grvReclamos
            // 
            this.grvReclamos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grdCodigoReclamo,
            this.grcFechaRegistro,
            this.grcUsuarioCliente,
            this.grcArea,
            this.grcTipoReclamoUsuario,
            this.grcDocReferencia,
            this.grcFechaAtencion,
            this.grcFechaSolucion,
            this.grcCorreccion,
            this.grcFechaVerificacion,
            this.grcEstadoReclamo});
            this.grvReclamos.GridControl = this.grdReclamos;
            this.grvReclamos.Name = "grvReclamos";
            this.grvReclamos.OptionsView.ShowAutoFilterRow = true;
            this.grvReclamos.OptionsView.ShowGroupPanel = false;
            // 
            // grdCodigoReclamo
            // 
            this.grdCodigoReclamo.Caption = "Código Reclamo";
            this.grdCodigoReclamo.ColumnEdit = this.linkCodigoReclamo;
            this.grdCodigoReclamo.FieldName = "iIdReclamo";
            this.grdCodigoReclamo.Name = "grdCodigoReclamo";
            this.grdCodigoReclamo.OptionsColumn.ReadOnly = true;
            this.grdCodigoReclamo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grdCodigoReclamo.Visible = true;
            this.grdCodigoReclamo.VisibleIndex = 0;
            this.grdCodigoReclamo.Width = 88;
            // 
            // linkCodigoReclamo
            // 
            this.linkCodigoReclamo.AutoHeight = false;
            this.linkCodigoReclamo.Name = "linkCodigoReclamo";
            this.linkCodigoReclamo.Click += new System.EventHandler(this.linkCodigoReclamo_Click);
            // 
            // grcFechaRegistro
            // 
            this.grcFechaRegistro.Caption = "Fecha Reclamo";
            this.grcFechaRegistro.FieldName = "dFechaRegistro";
            this.grcFechaRegistro.Name = "grcFechaRegistro";
            this.grcFechaRegistro.OptionsColumn.ReadOnly = true;
            this.grcFechaRegistro.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcFechaRegistro.Visible = true;
            this.grcFechaRegistro.VisibleIndex = 1;
            this.grcFechaRegistro.Width = 97;
            // 
            // grcUsuarioCliente
            // 
            this.grcUsuarioCliente.Caption = "Usuario";
            this.grcUsuarioCliente.FieldName = "sUsuarioCliente";
            this.grcUsuarioCliente.Name = "grcUsuarioCliente";
            this.grcUsuarioCliente.OptionsColumn.ReadOnly = true;
            this.grcUsuarioCliente.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcUsuarioCliente.Visible = true;
            this.grcUsuarioCliente.VisibleIndex = 2;
            this.grcUsuarioCliente.Width = 140;
            // 
            // grcArea
            // 
            this.grcArea.Caption = "Área";
            this.grcArea.FieldName = "sArea";
            this.grcArea.Name = "grcArea";
            this.grcArea.OptionsColumn.ReadOnly = true;
            this.grcArea.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcArea.Visible = true;
            this.grcArea.VisibleIndex = 3;
            this.grcArea.Width = 147;
            // 
            // grcTipoReclamoUsuario
            // 
            this.grcTipoReclamoUsuario.Caption = "Tipo Reclamo Cliente";
            this.grcTipoReclamoUsuario.FieldName = "sTipoReclamoUsuario";
            this.grcTipoReclamoUsuario.Name = "grcTipoReclamoUsuario";
            this.grcTipoReclamoUsuario.OptionsColumn.ReadOnly = true;
            this.grcTipoReclamoUsuario.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcTipoReclamoUsuario.Visible = true;
            this.grcTipoReclamoUsuario.VisibleIndex = 4;
            this.grcTipoReclamoUsuario.Width = 132;
            // 
            // grcDocReferencia
            // 
            this.grcDocReferencia.Caption = "Documento de Referencia";
            this.grcDocReferencia.FieldName = "sDocReferencia";
            this.grcDocReferencia.Name = "grcDocReferencia";
            this.grcDocReferencia.OptionsColumn.ReadOnly = true;
            this.grcDocReferencia.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcDocReferencia.Visible = true;
            this.grcDocReferencia.VisibleIndex = 5;
            this.grcDocReferencia.Width = 131;
            // 
            // grcFechaAtencion
            // 
            this.grcFechaAtencion.Caption = "Fecha 1ra Respuesta";
            this.grcFechaAtencion.FieldName = "dFechaAtencion";
            this.grcFechaAtencion.Name = "grcFechaAtencion";
            this.grcFechaAtencion.OptionsColumn.ReadOnly = true;
            this.grcFechaAtencion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcFechaAtencion.Visible = true;
            this.grcFechaAtencion.VisibleIndex = 6;
            this.grcFechaAtencion.Width = 110;
            // 
            // grcFechaSolucion
            // 
            this.grcFechaSolucion.Caption = "Fecha Solución";
            this.grcFechaSolucion.FieldName = "dFechaSolucion";
            this.grcFechaSolucion.Name = "grcFechaSolucion";
            this.grcFechaSolucion.OptionsColumn.ReadOnly = true;
            this.grcFechaSolucion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcFechaSolucion.Visible = true;
            this.grcFechaSolucion.VisibleIndex = 7;
            this.grcFechaSolucion.Width = 85;
            // 
            // grcFechaVerificacion
            // 
            this.grcFechaVerificacion.Caption = "Fecha Verificación";
            this.grcFechaVerificacion.FieldName = "dFechaVerificacion";
            this.grcFechaVerificacion.Name = "grcFechaVerificacion";
            this.grcFechaVerificacion.OptionsColumn.ReadOnly = true;
            this.grcFechaVerificacion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcFechaVerificacion.Visible = true;
            this.grcFechaVerificacion.VisibleIndex = 9;
            this.grcFechaVerificacion.Width = 96;
            // 
            // grcEstadoReclamo
            // 
            this.grcEstadoReclamo.Caption = "Estado";
            this.grcEstadoReclamo.FieldName = "sEstadoReclamo";
            this.grcEstadoReclamo.Name = "grcEstadoReclamo";
            this.grcEstadoReclamo.OptionsColumn.ReadOnly = true;
            this.grcEstadoReclamo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcEstadoReclamo.Visible = true;
            this.grcEstadoReclamo.VisibleIndex = 10;
            this.grcEstadoReclamo.Width = 84;
            // 
            // grcCorreccion
            // 
            this.grcCorreccion.Caption = "Corrección";
            this.grcCorreccion.ColumnEdit = this.linkReclamo;
            this.grcCorreccion.FieldName = "sNecesitaCorreccion";
            this.grcCorreccion.Name = "grcCorreccion";
            this.grcCorreccion.Visible = true;
            this.grcCorreccion.VisibleIndex = 8;
            // 
            // linkReclamo
            // 
            this.linkReclamo.AutoHeight = false;
            this.linkReclamo.Name = "linkReclamo";
            this.linkReclamo.Click += new System.EventHandler(this.linkReclamo_Click);
            // 
            // frmListaReclamos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 822);
            this.Controls.Add(this.grdReclamos);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListaReclamos";
            this.Text = "Lista de Reclamos";
            this.Load += new System.EventHandler(this.frmListaReclamos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdReclamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvReclamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkCodigoReclamo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkReclamo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdReclamos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvReclamos;
        private DevExpress.XtraGrid.Columns.GridColumn grdCodigoReclamo;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkCodigoReclamo;
        private DevExpress.XtraGrid.Columns.GridColumn grcFechaRegistro;
        private DevExpress.XtraGrid.Columns.GridColumn grcUsuarioCliente;
        private DevExpress.XtraGrid.Columns.GridColumn grcArea;
        private DevExpress.XtraGrid.Columns.GridColumn grcTipoReclamoUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn grcDocReferencia;
        private DevExpress.XtraGrid.Columns.GridColumn grcFechaAtencion;
        private DevExpress.XtraGrid.Columns.GridColumn grcFechaSolucion;
        private DevExpress.XtraGrid.Columns.GridColumn grcFechaVerificacion;
        private DevExpress.XtraGrid.Columns.GridColumn grcEstadoReclamo;
        private DevExpress.XtraGrid.Columns.GridColumn grcCorreccion;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkReclamo;
    }
}