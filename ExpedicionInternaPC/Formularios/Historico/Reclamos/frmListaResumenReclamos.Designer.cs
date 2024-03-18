namespace ExpedicionInternaPC.Formularios.Reclamos
{
    partial class frmListaResumenReclamos
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
            this.grdTiposReclamo = new DevExpress.XtraGrid.GridControl();
            this.grvTiposReclamo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcIdTipoReclamoUTD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkIdTipoReclamoUTD = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcDescripcionTipoReclamo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkTipoReclamoUTD = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.grcCantidadReclamos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcCantidadFundados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcExpedicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgPeriodos = new DevExpress.XtraEditors.RadioGroup();
            this.dePeriodo = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTiposReclamo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTiposReclamo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkIdTipoReclamoUTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkTipoReclamoUTD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgPeriodos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePeriodo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePeriodo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdTiposReclamo
            // 
            this.grdTiposReclamo.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdTiposReclamo.Location = new System.Drawing.Point(10, 57);
            this.grdTiposReclamo.MainView = this.grvTiposReclamo;
            this.grdTiposReclamo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdTiposReclamo.Name = "grdTiposReclamo";
            this.grdTiposReclamo.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkIdTipoReclamoUTD,
            this.linkTipoReclamoUTD});
            this.grdTiposReclamo.Size = new System.Drawing.Size(910, 247);
            this.grdTiposReclamo.TabIndex = 0;
            this.grdTiposReclamo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTiposReclamo});
            // 
            // grvTiposReclamo
            // 
            this.grvTiposReclamo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grcIdTipoReclamoUTD,
            this.grcDescripcionTipoReclamo,
            this.grcCantidadReclamos,
            this.grcCantidadFundados,
            this.grcExpedicion});
            this.grvTiposReclamo.GridControl = this.grdTiposReclamo;
            this.grvTiposReclamo.Name = "grvTiposReclamo";
            this.grvTiposReclamo.OptionsView.ShowAutoFilterRow = true;
            this.grvTiposReclamo.OptionsView.ShowGroupPanel = false;
            this.grvTiposReclamo.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grvTiposReclamo_RowCellStyle);
            this.grvTiposReclamo.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grvTiposReclamo_RowStyle);
            // 
            // grcIdTipoReclamoUTD
            // 
            this.grcIdTipoReclamoUTD.Caption = "Código Tipo Reclamo";
            this.grcIdTipoReclamoUTD.ColumnEdit = this.linkIdTipoReclamoUTD;
            this.grcIdTipoReclamoUTD.FieldName = "iIdTipoReclamoUTD";
            this.grcIdTipoReclamoUTD.Name = "grcIdTipoReclamoUTD";
            this.grcIdTipoReclamoUTD.OptionsColumn.ReadOnly = true;
            this.grcIdTipoReclamoUTD.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // linkIdTipoReclamoUTD
            // 
            this.linkIdTipoReclamoUTD.AutoHeight = false;
            this.linkIdTipoReclamoUTD.Name = "linkIdTipoReclamoUTD";
            this.linkIdTipoReclamoUTD.Click += new System.EventHandler(this.linkIdTipoReclamoUTD_Click);
            // 
            // grcDescripcionTipoReclamo
            // 
            this.grcDescripcionTipoReclamo.Caption = "Tipo Reclamo";
            this.grcDescripcionTipoReclamo.ColumnEdit = this.linkTipoReclamoUTD;
            this.grcDescripcionTipoReclamo.FieldName = "sDescripcionTipoReclamoUTD";
            this.grcDescripcionTipoReclamo.Name = "grcDescripcionTipoReclamo";
            this.grcDescripcionTipoReclamo.OptionsColumn.ReadOnly = true;
            this.grcDescripcionTipoReclamo.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcDescripcionTipoReclamo.Visible = true;
            this.grcDescripcionTipoReclamo.VisibleIndex = 0;
            // 
            // linkTipoReclamoUTD
            // 
            this.linkTipoReclamoUTD.AutoHeight = false;
            this.linkTipoReclamoUTD.Name = "linkTipoReclamoUTD";
            this.linkTipoReclamoUTD.Click += new System.EventHandler(this.linkTipoReclamoUTD_Click);
            // 
            // grcCantidadReclamos
            // 
            this.grcCantidadReclamos.Caption = "Reclamos";
            this.grcCantidadReclamos.FieldName = "iCantidadReclamos";
            this.grcCantidadReclamos.Name = "grcCantidadReclamos";
            this.grcCantidadReclamos.OptionsColumn.ReadOnly = true;
            this.grcCantidadReclamos.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcCantidadReclamos.Visible = true;
            this.grcCantidadReclamos.VisibleIndex = 2;
            // 
            // grcCantidadFundados
            // 
            this.grcCantidadFundados.Caption = "Fundados";
            this.grcCantidadFundados.FieldName = "iCantidadFundados";
            this.grcCantidadFundados.Name = "grcCantidadFundados";
            this.grcCantidadFundados.OptionsColumn.ReadOnly = true;
            this.grcCantidadFundados.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcCantidadFundados.Visible = true;
            this.grcCantidadFundados.VisibleIndex = 3;
            // 
            // grcExpedicion
            // 
            this.grcExpedicion.Caption = "Expedición";
            this.grcExpedicion.FieldName = "sExpedicion";
            this.grcExpedicion.Name = "grcExpedicion";
            this.grcExpedicion.OptionsColumn.ReadOnly = true;
            this.grcExpedicion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.grcExpedicion.Visible = true;
            this.grcExpedicion.VisibleIndex = 1;
            // 
            // rgPeriodos
            // 
            this.rgPeriodos.Location = new System.Drawing.Point(10, 8);
            this.rgPeriodos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rgPeriodos.Name = "rgPeriodos";
            this.rgPeriodos.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rgPeriodos.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(0)), "Periodo Actual"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Periodo a Evaluar"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(2)), "Históricos")});
            this.rgPeriodos.Size = new System.Drawing.Size(859, 27);
            this.rgPeriodos.TabIndex = 1;
            this.rgPeriodos.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            // 
            // dePeriodo
            // 
            this.dePeriodo.EditValue = null;
            this.dePeriodo.Location = new System.Drawing.Point(709, 13);
            this.dePeriodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dePeriodo.Name = "dePeriodo";
            this.dePeriodo.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True;
            this.dePeriodo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.dePeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePeriodo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dePeriodo.Properties.Mask.EditMask = "y";
            this.dePeriodo.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.dePeriodo.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.dePeriodo.Size = new System.Drawing.Size(193, 22);
            this.dePeriodo.TabIndex = 3;
            this.dePeriodo.EditValueChanged += new System.EventHandler(this.dePeriodo_EditValueChanged);
            // 
            // frmListaResumenReclamos
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 315);
            this.Controls.Add(this.dePeriodo);
            this.Controls.Add(this.rgPeriodos);
            this.Controls.Add(this.grdTiposReclamo);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmListaResumenReclamos";
            this.Text = "Resumen de reclamos atendidos - UTD";
            this.Load += new System.EventHandler(this.frmListaResumenReclamos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTiposReclamo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTiposReclamo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkIdTipoReclamoUTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkTipoReclamoUTD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgPeriodos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePeriodo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dePeriodo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdTiposReclamo;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTiposReclamo;
        private DevExpress.XtraGrid.Columns.GridColumn grcIdTipoReclamoUTD;
        private DevExpress.XtraGrid.Columns.GridColumn grcDescripcionTipoReclamo;
        private DevExpress.XtraGrid.Columns.GridColumn grcCantidadReclamos;
        private DevExpress.XtraGrid.Columns.GridColumn grcCantidadFundados;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkIdTipoReclamoUTD;
        private DevExpress.XtraGrid.Columns.GridColumn grcExpedicion;
        private DevExpress.XtraEditors.RadioGroup rgPeriodos;
        private DevExpress.XtraEditors.DateEdit dePeriodo;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkTipoReclamoUTD;
    }
}