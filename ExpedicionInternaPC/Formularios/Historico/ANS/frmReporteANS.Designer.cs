namespace ExpedicionInternaPC
{
    partial class frmReporteANS
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.luePeriodo = new ExpedicionInternaPC.Formularios.Controles_Comunes.LookUpPeriodo();
            this.gcResumen = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIndicador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUnidadMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcPeligro = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcMeta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcValorObtenido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUltimoPeriodo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gcEfectividad = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcIndicador2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcAntepenultimoPeriodo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcUltimoPeriodo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.gcGestionOportuna = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcProcesadosMesaPartes = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnExportar = new DevExpress.XtraEditors.SimpleButton();
            this.gcReportesDeServicios = new DevExpress.XtraGrid.GridControl();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.luePeriodo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcResumen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEfectividad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGestionOportuna)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProcesadosMesaPartes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReportesDeServicios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(46, 23);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Periodo";
            // 
            // luePeriodo
            // 
            this.luePeriodo.Location = new System.Drawing.Point(102, 21);
            this.luePeriodo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.luePeriodo.Name = "luePeriodo";
            this.luePeriodo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luePeriodo.Size = new System.Drawing.Size(144, 20);
            this.luePeriodo.TabIndex = 1;
            this.luePeriodo.EditValueChanged += new System.EventHandler(this.luePeriodo_EditValueChanged);
            // 
            // gcResumen
            // 
            this.gcResumen.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcResumen.Location = new System.Drawing.Point(10, 104);
            this.gcResumen.MainView = this.gridView1;
            this.gcResumen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcResumen.Name = "gcResumen";
            this.gcResumen.Size = new System.Drawing.Size(800, 175);
            this.gcResumen.TabIndex = 2;
            this.gcResumen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIndicador,
            this.gcUnidadMedida,
            this.gcPeligro,
            this.gcMeta,
            this.gcValorObtenido,
            this.gcUltimoPeriodo});
            this.gridView1.GridControl = this.gcResumen;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcIndicador
            // 
            this.gcIndicador.Caption = "Indicador";
            this.gcIndicador.FieldName = "sDescripcion";
            this.gcIndicador.Name = "gcIndicador";
            this.gcIndicador.OptionsColumn.AllowEdit = false;
            this.gcIndicador.OptionsColumn.ReadOnly = true;
            this.gcIndicador.Visible = true;
            this.gcIndicador.VisibleIndex = 0;
            this.gcIndicador.Width = 270;
            // 
            // gcUnidadMedida
            // 
            this.gcUnidadMedida.Caption = "Unidad de Medida";
            this.gcUnidadMedida.FieldName = "sUnidadMedida";
            this.gcUnidadMedida.Name = "gcUnidadMedida";
            this.gcUnidadMedida.OptionsColumn.AllowEdit = false;
            this.gcUnidadMedida.OptionsColumn.ReadOnly = true;
            this.gcUnidadMedida.Visible = true;
            this.gcUnidadMedida.VisibleIndex = 1;
            this.gcUnidadMedida.Width = 131;
            // 
            // gcPeligro
            // 
            this.gcPeligro.Caption = "Peligro";
            this.gcPeligro.FieldName = "sPeligro";
            this.gcPeligro.Name = "gcPeligro";
            this.gcPeligro.OptionsColumn.AllowEdit = false;
            this.gcPeligro.OptionsColumn.ReadOnly = true;
            this.gcPeligro.Visible = true;
            this.gcPeligro.VisibleIndex = 2;
            this.gcPeligro.Width = 126;
            // 
            // gcMeta
            // 
            this.gcMeta.Caption = "Meta";
            this.gcMeta.FieldName = "sMeta";
            this.gcMeta.Name = "gcMeta";
            this.gcMeta.OptionsColumn.AllowEdit = false;
            this.gcMeta.OptionsColumn.ReadOnly = true;
            this.gcMeta.Visible = true;
            this.gcMeta.VisibleIndex = 3;
            this.gcMeta.Width = 126;
            // 
            // gcValorObtenido
            // 
            this.gcValorObtenido.Caption = "Valor Obtenido";
            this.gcValorObtenido.FieldName = "sUltimoPeriodo";
            this.gcValorObtenido.Name = "gcValorObtenido";
            this.gcValorObtenido.OptionsColumn.AllowEdit = false;
            this.gcValorObtenido.OptionsColumn.ReadOnly = true;
            this.gcValorObtenido.Visible = true;
            this.gcValorObtenido.VisibleIndex = 4;
            this.gcValorObtenido.Width = 126;
            // 
            // gcUltimoPeriodo
            // 
            this.gcUltimoPeriodo.Caption = "Ultimo Periodo";
            this.gcUltimoPeriodo.FieldName = "sPenultimoPeriodo";
            this.gcUltimoPeriodo.Name = "gcUltimoPeriodo";
            this.gcUltimoPeriodo.OptionsColumn.AllowEdit = false;
            this.gcUltimoPeriodo.OptionsColumn.ReadOnly = true;
            this.gcUltimoPeriodo.Visible = true;
            this.gcUltimoPeriodo.VisibleIndex = 5;
            this.gcUltimoPeriodo.Width = 134;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(10, 70);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 17);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Resumen";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(10, 294);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(267, 17);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Efectividad de Entrega de Documentos";
            // 
            // gcEfectividad
            // 
            this.gcEfectividad.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            gridLevelNode1.RelationName = "Level1";
            this.gcEfectividad.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gcEfectividad.Location = new System.Drawing.Point(10, 313);
            this.gcEfectividad.MainView = this.gridView2;
            this.gcEfectividad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcEfectividad.Name = "gcEfectividad";
            this.gcEfectividad.Size = new System.Drawing.Size(800, 184);
            this.gcEfectividad.TabIndex = 4;
            this.gcEfectividad.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcIndicador2,
            this.gcAntepenultimoPeriodo2,
            this.gridColumn2,
            this.gcUltimoPeriodo2});
            this.gridView2.GridControl = this.gcEfectividad;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gcIndicador2
            // 
            this.gcIndicador2.Caption = "Indicador";
            this.gcIndicador2.FieldName = "sDescripcion";
            this.gcIndicador2.Name = "gcIndicador2";
            this.gcIndicador2.OptionsColumn.AllowEdit = false;
            this.gcIndicador2.OptionsColumn.ReadOnly = true;
            this.gcIndicador2.Visible = true;
            this.gcIndicador2.VisibleIndex = 0;
            // 
            // gcAntepenultimoPeriodo2
            // 
            this.gcAntepenultimoPeriodo2.Caption = "Antepenúltimo Periodo";
            this.gcAntepenultimoPeriodo2.FieldName = "sAntepenultimoPeriodo";
            this.gcAntepenultimoPeriodo2.Name = "gcAntepenultimoPeriodo2";
            this.gcAntepenultimoPeriodo2.OptionsColumn.AllowEdit = false;
            this.gcAntepenultimoPeriodo2.OptionsColumn.ReadOnly = true;
            this.gcAntepenultimoPeriodo2.Visible = true;
            this.gcAntepenultimoPeriodo2.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Penúltimo Periodo";
            this.gridColumn2.FieldName = "sPenultimoPeriodo";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gcUltimoPeriodo2
            // 
            this.gcUltimoPeriodo2.Caption = "Último Periodo";
            this.gcUltimoPeriodo2.FieldName = "sUltimoPeriodo";
            this.gcUltimoPeriodo2.Name = "gcUltimoPeriodo2";
            this.gcUltimoPeriodo2.OptionsColumn.AllowEdit = false;
            this.gcUltimoPeriodo2.OptionsColumn.ReadOnly = true;
            this.gcUltimoPeriodo2.Visible = true;
            this.gcUltimoPeriodo2.VisibleIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(10, 517);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(328, 17);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Gestión oportuna en la Entrega de Documentos";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(10, 736);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(306, 17);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Documentos Procesados por Mesa de Partes";
            // 
            // gcGestionOportuna
            // 
            this.gcGestionOportuna.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcGestionOportuna.Location = new System.Drawing.Point(10, 536);
            this.gcGestionOportuna.MainView = this.gridView3;
            this.gcGestionOportuna.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcGestionOportuna.Name = "gcGestionOportuna";
            this.gcGestionOportuna.Size = new System.Drawing.Size(800, 184);
            this.gcGestionOportuna.TabIndex = 10;
            this.gcGestionOportuna.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView3.GridControl = this.gcGestionOportuna;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Indicador";
            this.gridColumn3.FieldName = "sDescripcion";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Antepenúltimo Periodo";
            this.gridColumn4.FieldName = "sAntepenultimoPeriodo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Penúltimo Periodo";
            this.gridColumn5.FieldName = "sPenultimoPeriodo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 2;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Último Periodo";
            this.gridColumn6.FieldName = "sUltimoPeriodo";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 3;
            // 
            // gcProcesadosMesaPartes
            // 
            this.gcProcesadosMesaPartes.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcProcesadosMesaPartes.Location = new System.Drawing.Point(10, 755);
            this.gcProcesadosMesaPartes.MainView = this.gridView4;
            this.gcProcesadosMesaPartes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcProcesadosMesaPartes.Name = "gcProcesadosMesaPartes";
            this.gcProcesadosMesaPartes.Size = new System.Drawing.Size(800, 184);
            this.gcProcesadosMesaPartes.TabIndex = 11;
            this.gcProcesadosMesaPartes.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
            this.gridView4.GridControl = this.gcProcesadosMesaPartes;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Indicador";
            this.gridColumn7.FieldName = "sDescripcion";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Antepenúltimo Periodo";
            this.gridColumn8.FieldName = "sAntepenultimoPeriodo";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 1;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Penúltimo Periodo";
            this.gridColumn9.FieldName = "sPenultimoPeriodo";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 2;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Último Periodo";
            this.gridColumn10.FieldName = "sUltimoPeriodo";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 3;
            // 
            // btnExportar
            // 
            this.btnExportar.Appearance.BackColor = System.Drawing.Color.CadetBlue;
            this.btnExportar.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Appearance.Options.UseBackColor = true;
            this.btnExportar.Appearance.Options.UseForeColor = true;
            this.btnExportar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnExportar.Location = new System.Drawing.Point(698, 24);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(112, 35);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Text = "Exportar a Excel";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // gcReportesDeServicios
            // 
            this.gcReportesDeServicios.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcReportesDeServicios.Location = new System.Drawing.Point(10, 976);
            this.gcReportesDeServicios.MainView = this.gridView5;
            this.gcReportesDeServicios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcReportesDeServicios.Name = "gcReportesDeServicios";
            this.gcReportesDeServicios.Size = new System.Drawing.Size(800, 184);
            this.gcReportesDeServicios.TabIndex = 14;
            this.gcReportesDeServicios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView5});
            // 
            // gridView5
            // 
            this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView5.GridControl = this.gcReportesDeServicios;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Indicador";
            this.gridColumn1.FieldName = "sDescripcion";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Antepenúltimo Periodo";
            this.gridColumn11.FieldName = "sAntepenultimoPeriodo";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Penúltimo Periodo";
            this.gridColumn12.FieldName = "sPenultimoPeriodo";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Último Periodo";
            this.gridColumn13.FieldName = "sUltimoPeriodo";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 3;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Location = new System.Drawing.Point(10, 957);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(148, 17);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Reportes de Servicios";
            // 
            // frmReporteANS
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(841, 511);
            this.Controls.Add(this.gcReportesDeServicios);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.gcProcesadosMesaPartes);
            this.Controls.Add(this.gcGestionOportuna);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.gcEfectividad);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.gcResumen);
            this.Controls.Add(this.luePeriodo);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmReporteANS";
            this.Text = "Reporte ANS";
            this.Load += new System.EventHandler(this.frmReporteANS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luePeriodo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcResumen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcEfectividad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcGestionOportuna)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcProcesadosMesaPartes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcReportesDeServicios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Formularios.Controles_Comunes.LookUpPeriodo luePeriodo;
        private DevExpress.XtraGrid.GridControl gcResumen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.GridControl gcEfectividad;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndicador;
        private DevExpress.XtraGrid.Columns.GridColumn gcUnidadMedida;
        private DevExpress.XtraGrid.Columns.GridColumn gcPeligro;
        private DevExpress.XtraGrid.Columns.GridColumn gcMeta;
        private DevExpress.XtraGrid.Columns.GridColumn gcValorObtenido;
        private DevExpress.XtraGrid.Columns.GridColumn gcUltimoPeriodo;
        private DevExpress.XtraGrid.Columns.GridColumn gcIndicador2;
        private DevExpress.XtraGrid.Columns.GridColumn gcAntepenultimoPeriodo2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gcUltimoPeriodo2;
        private DevExpress.XtraGrid.GridControl gcGestionOportuna;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.GridControl gcProcesadosMesaPartes;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.SimpleButton btnExportar;
        private DevExpress.XtraGrid.GridControl gcReportesDeServicios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}