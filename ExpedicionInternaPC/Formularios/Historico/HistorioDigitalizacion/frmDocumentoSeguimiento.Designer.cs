namespace ExpedicionInternaPC
{
    partial class frmDocumentoSeguimiento
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
            this.grdSeguimiento = new DevExpress.XtraGrid.GridControl();
            this.grvSeguimiento = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCodigoDocumento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdSeguimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSeguimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSeguimiento
            // 
            this.grdSeguimiento.Location = new System.Drawing.Point(12, 12);
            this.grdSeguimiento.MainView = this.grvSeguimiento;
            this.grdSeguimiento.Name = "grdSeguimiento";
            this.grdSeguimiento.Size = new System.Drawing.Size(687, 289);
            this.grdSeguimiento.TabIndex = 0;
            this.grdSeguimiento.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSeguimiento});
            // 
            // grvSeguimiento
            // 
            this.grvSeguimiento.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdDocumento,
            this.colCodigoDocumento,
            this.colEstado,
            this.colDescripcion,
            this.colUsuario,
            this.colFecha});
            this.grvSeguimiento.GridControl = this.grdSeguimiento;
            this.grvSeguimiento.Name = "grvSeguimiento";
            this.grvSeguimiento.OptionsView.ShowGroupPanel = false;
            // 
            // colIdDocumento
            // 
            this.colIdDocumento.Caption = "IdDocumento";
            this.colIdDocumento.FieldName = "iIdDocumento";
            this.colIdDocumento.Name = "colIdDocumento";
            this.colIdDocumento.OptionsColumn.ReadOnly = true;
            // 
            // colCodigoDocumento
            // 
            this.colCodigoDocumento.Caption = "Codigo documento";
            this.colCodigoDocumento.FieldName = "sCodigoDocumento";
            this.colCodigoDocumento.Name = "colCodigoDocumento";
            this.colCodigoDocumento.OptionsColumn.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.FieldName = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.ReadOnly = true;
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripcion";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.OptionsColumn.ReadOnly = true;
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.FieldName = "Usuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.OptionsColumn.ReadOnly = true;
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 2;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "FechaRegistro";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 3;
            // 
            // frmDocumentoSeguimiento
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 316);
            this.Controls.Add(this.grdSeguimiento);
            this.Name = "frmDocumentoSeguimiento";
            this.Text = "frmDocumentoSeguimiento";
            this.Load += new System.EventHandler(this.frmDocumentoSeguimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSeguimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSeguimiento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSeguimiento;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSeguimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colIdDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigoDocumento;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
    }
}