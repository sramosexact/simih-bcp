namespace ExpedicionInternaPC.Formularios.Agencias
{
    partial class frmElementosDeGeoCambiado
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
            this.btnAceptar = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.grdObjetos = new DevExpress.XtraGrid.GridControl();
            this.grvObjetos = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dgcCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgcCodigoAgenciaAnterior = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgcAgenciaAnterior = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgcGeoDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dgcExpedicionPara = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblIndicaciones = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grdObjetos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvObjetos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(277, 331);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(83, 27);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(338, 23);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Elementos con el destino cambiado";
            // 
            // grdObjetos
            // 
            this.grdObjetos.Location = new System.Drawing.Point(12, 38);
            this.grdObjetos.MainView = this.grvObjetos;
            this.grdObjetos.Name = "grdObjetos";
            this.grdObjetos.Size = new System.Drawing.Size(615, 224);
            this.grdObjetos.TabIndex = 3;
            this.grdObjetos.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvObjetos});
            // 
            // grvObjetos
            // 
            this.grvObjetos.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.dgcCodigo,
            this.dgcCodigoAgenciaAnterior,
            this.dgcAgenciaAnterior,
            this.dgcGeoDestino,
            this.dgcExpedicionPara});
            this.grvObjetos.DetailHeight = 323;
            this.grvObjetos.GridControl = this.grdObjetos;
            this.grvObjetos.Name = "grvObjetos";
            // 
            // dgcCodigo
            // 
            this.dgcCodigo.Caption = "Autogenerado";
            this.dgcCodigo.FieldName = "Autogenerado";
            this.dgcCodigo.Name = "dgcCodigo";
            this.dgcCodigo.Visible = true;
            this.dgcCodigo.VisibleIndex = 0;
            // 
            // dgcCodigoAgenciaAnterior
            // 
            this.dgcCodigoAgenciaAnterior.Caption = "Código Agencia Anterior";
            this.dgcCodigoAgenciaAnterior.FieldName = "sCodigoAgenciaDestino";
            this.dgcCodigoAgenciaAnterior.Name = "dgcCodigoAgenciaAnterior";
            this.dgcCodigoAgenciaAnterior.Visible = true;
            this.dgcCodigoAgenciaAnterior.VisibleIndex = 1;
            // 
            // dgcAgenciaAnterior
            // 
            this.dgcAgenciaAnterior.Caption = "Agencia Anterior";
            this.dgcAgenciaAnterior.FieldName = "sAgenciaDestino";
            this.dgcAgenciaAnterior.Name = "dgcAgenciaAnterior";
            this.dgcAgenciaAnterior.Visible = true;
            this.dgcAgenciaAnterior.VisibleIndex = 2;
            // 
            // dgcGeoDestino
            // 
            this.dgcGeoDestino.Caption = "Nuevo Destino";
            this.dgcGeoDestino.FieldName = "sGeoDestino";
            this.dgcGeoDestino.Name = "dgcGeoDestino";
            this.dgcGeoDestino.Visible = true;
            this.dgcGeoDestino.VisibleIndex = 3;
            // 
            // dgcExpedicionPara
            // 
            this.dgcExpedicionPara.Caption = "Expedicion Destino";
            this.dgcExpedicionPara.FieldName = "ExpedicionPara";
            this.dgcExpedicionPara.Name = "dgcExpedicionPara";
            this.dgcExpedicionPara.Visible = true;
            this.dgcExpedicionPara.VisibleIndex = 4;
            // 
            // lblIndicaciones
            // 
            this.lblIndicaciones.Location = new System.Drawing.Point(12, 279);
            this.lblIndicaciones.Name = "lblIndicaciones";
            this.lblIndicaciones.Size = new System.Drawing.Size(63, 13);
            this.lblIndicaciones.TabIndex = 4;
            this.lblIndicaciones.Text = "labelControl2";
            // 
            // frmElementosDeGeoCambiado
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 369);
            this.Controls.Add(this.lblIndicaciones);
            this.Controls.Add(this.grdObjetos);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnAceptar);
            this.Name = "frmElementosDeGeoCambiado";
            this.Text = "Destino cambiado para los elementos";
            this.Load += new System.EventHandler(this.frmElementosDeGeoCambiado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdObjetos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvObjetos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnAceptar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl grdObjetos;
        private DevExpress.XtraGrid.Views.Grid.GridView grvObjetos;
        private DevExpress.XtraEditors.LabelControl lblIndicaciones;
        private DevExpress.XtraGrid.Columns.GridColumn dgcCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn dgcCodigoAgenciaAnterior;
        private DevExpress.XtraGrid.Columns.GridColumn dgcAgenciaAnterior;
        private DevExpress.XtraGrid.Columns.GridColumn dgcGeoDestino;
        private DevExpress.XtraGrid.Columns.GridColumn dgcExpedicionPara;
    }
}