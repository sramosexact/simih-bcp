namespace ExpedicionInternaPC
{
    partial class frmBuscarUsuario
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtUsuario = new DevExpress.XtraEditors.TextEdit();
            this.grcUsuarios = new DevExpress.XtraGrid.GridControl();
            this.grvUsuarios = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcMatricula = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcExpedicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSeleccionar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.linkSeleccionar = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsuarios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkSeleccionar)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 24);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(136, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ingrese valor de búsqueda :";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(178, 22);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(234, 20);
            this.txtUsuario.TabIndex = 1;
            this.txtUsuario.TextChanged += new System.EventHandler(this.txtUsuario_TextChanged);
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // grcUsuarios
            // 
            this.grcUsuarios.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcUsuarios.Location = new System.Drawing.Point(10, 53);
            this.grcUsuarios.MainView = this.grvUsuarios;
            this.grcUsuarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grcUsuarios.Name = "grcUsuarios";
            this.grcUsuarios.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.linkSeleccionar});
            this.grcUsuarios.Size = new System.Drawing.Size(614, 164);
            this.grcUsuarios.TabIndex = 2;
            this.grcUsuarios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUsuarios});
            // 
            // grvUsuarios
            // 
            this.grvUsuarios.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcMatricula,
            this.gcNombre,
            this.gcArea,
            this.gcExpedicion,
            this.gcSeleccionar});
            this.grvUsuarios.GridControl = this.grcUsuarios;
            this.grvUsuarios.Name = "grvUsuarios";
            this.grvUsuarios.OptionsView.ShowGroupPanel = false;
            // 
            // gcMatricula
            // 
            this.gcMatricula.Caption = "Matrícula";
            this.gcMatricula.FieldName = "sMatricula";
            this.gcMatricula.Name = "gcMatricula";
            this.gcMatricula.OptionsColumn.ReadOnly = true;
            this.gcMatricula.Visible = true;
            this.gcMatricula.VisibleIndex = 0;
            this.gcMatricula.Width = 98;
            // 
            // gcNombre
            // 
            this.gcNombre.Caption = "Nombre";
            this.gcNombre.FieldName = "Descripcion";
            this.gcNombre.Name = "gcNombre";
            this.gcNombre.OptionsColumn.ReadOnly = true;
            this.gcNombre.Visible = true;
            this.gcNombre.VisibleIndex = 1;
            this.gcNombre.Width = 210;
            // 
            // gcArea
            // 
            this.gcArea.Caption = "Área";
            this.gcArea.FieldName = "area";
            this.gcArea.Name = "gcArea";
            this.gcArea.OptionsColumn.ReadOnly = true;
            this.gcArea.Visible = true;
            this.gcArea.VisibleIndex = 2;
            this.gcArea.Width = 100;
            // 
            // gcExpedicion
            // 
            this.gcExpedicion.Caption = "Expedición";
            this.gcExpedicion.FieldName = "Expedicion";
            this.gcExpedicion.Name = "gcExpedicion";
            this.gcExpedicion.OptionsColumn.ReadOnly = true;
            this.gcExpedicion.Visible = true;
            this.gcExpedicion.VisibleIndex = 3;
            this.gcExpedicion.Width = 149;
            // 
            // gcSeleccionar
            // 
            this.gcSeleccionar.Caption = "Seleccionar";
            this.gcSeleccionar.ColumnEdit = this.linkSeleccionar;
            this.gcSeleccionar.Name = "gcSeleccionar";
            this.gcSeleccionar.OptionsColumn.ReadOnly = true;
            this.gcSeleccionar.Visible = true;
            this.gcSeleccionar.VisibleIndex = 4;
            // 
            // linkSeleccionar
            // 
            this.linkSeleccionar.AutoHeight = false;
            this.linkSeleccionar.Name = "linkSeleccionar";
            this.linkSeleccionar.NullText = "Seleccionar";
            this.linkSeleccionar.Click += new System.EventHandler(this.linkSeleccionar_Click);
            // 
            // frmBuscarUsuario
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 233);
            this.Controls.Add(this.grcUsuarios);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "frmBuscarUsuario";
            this.Text = "Buscar Usuario";
            ((System.ComponentModel.ISupportInitialize)(this.txtUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUsuarios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linkSeleccionar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtUsuario;
        private DevExpress.XtraGrid.GridControl grcUsuarios;
        private DevExpress.XtraGrid.Views.Grid.GridView grvUsuarios;
        private DevExpress.XtraGrid.Columns.GridColumn gcMatricula;
        private DevExpress.XtraGrid.Columns.GridColumn gcNombre;
        private DevExpress.XtraGrid.Columns.GridColumn gcArea;
        private DevExpress.XtraGrid.Columns.GridColumn gcExpedicion;
        private DevExpress.XtraGrid.Columns.GridColumn gcSeleccionar;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit linkSeleccionar;
    }
}