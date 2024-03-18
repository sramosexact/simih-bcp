namespace ExpedicionInternaPC
{
    partial class frmRetirarDocumentosExternos
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
            this.grdPorRetirar = new DevExpress.XtraGrid.GridControl();
            this.grvPorRetirar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colResultado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDataFile = new DevExpress.XtraEditors.TextEdit();
            this.btnSelectFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnLoadFile = new DevExpress.XtraEditors.SimpleButton();
            this.btnRetirar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdPorRetirar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPorRetirar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPorRetirar
            // 
            this.grdPorRetirar.Location = new System.Drawing.Point(12, 87);
            this.grdPorRetirar.MainView = this.grvPorRetirar;
            this.grdPorRetirar.Name = "grdPorRetirar";
            this.grdPorRetirar.Size = new System.Drawing.Size(408, 232);
            this.grdPorRetirar.TabIndex = 5;
            this.grdPorRetirar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvPorRetirar});
            // 
            // grvPorRetirar
            // 
            this.grvPorRetirar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCodigo,
            this.colResultado});
            this.grvPorRetirar.GridControl = this.grdPorRetirar;
            this.grvPorRetirar.Name = "grvPorRetirar";
            this.grvPorRetirar.OptionsView.ShowGroupPanel = false;
            // 
            // colCodigo
            // 
            this.colCodigo.Caption = "Código";
            this.colCodigo.FieldName = "Codigo";
            this.colCodigo.Name = "colCodigo";
            this.colCodigo.OptionsColumn.ReadOnly = true;
            this.colCodigo.Visible = true;
            this.colCodigo.VisibleIndex = 0;
            this.colCodigo.Width = 137;
            // 
            // colResultado
            // 
            this.colResultado.Caption = "Resultado";
            this.colResultado.FieldName = "Destino";
            this.colResultado.Name = "colResultado";
            this.colResultado.OptionsColumn.ReadOnly = true;
            this.colResultado.Visible = true;
            this.colResultado.VisibleIndex = 1;
            this.colResultado.Width = 253;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 54);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(85, 13);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Archivo de datos:";
            // 
            // txtDataFile
            // 
            this.txtDataFile.Location = new System.Drawing.Point(103, 51);
            this.txtDataFile.Name = "txtDataFile";
            this.txtDataFile.Properties.ReadOnly = true;
            this.txtDataFile.Size = new System.Drawing.Size(208, 20);
            this.txtDataFile.TabIndex = 7;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnSelectFile.Location = new System.Drawing.Point(312, 49);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(22, 23);
            this.btnSelectFile.TabIndex = 8;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnLoadFile.Location = new System.Drawing.Point(345, 49);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(75, 23);
            this.btnLoadFile.TabIndex = 9;
            this.btnLoadFile.Text = "Cargar datos";
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnRetirar
            // 
            this.btnRetirar.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRetirar.Location = new System.Drawing.Point(286, 325);
            this.btnRetirar.Name = "btnRetirar";
            this.btnRetirar.Size = new System.Drawing.Size(134, 23);
            this.btnRetirar.TabIndex = 10;
            this.btnRetirar.Text = "Retirar autogenerados";
            this.btnRetirar.Click += new System.EventHandler(this.btnRetirar_Click);
            // 
            // frmRetirarDocumentosExternos
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 361);
            this.Controls.Add(this.btnRetirar);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.txtDataFile);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.grdPorRetirar);
            this.Name = "frmRetirarDocumentosExternos";
            this.Text = "Retirar documentos externos";
            this.Load += new System.EventHandler(this.frmRetirarDocumentosExternos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPorRetirar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvPorRetirar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataFile.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdPorRetirar;
        private DevExpress.XtraGrid.Views.Grid.GridView grvPorRetirar;
        private DevExpress.XtraGrid.Columns.GridColumn colCodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colResultado;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtDataFile;
        private DevExpress.XtraEditors.SimpleButton btnSelectFile;
        private DevExpress.XtraEditors.SimpleButton btnLoadFile;
        private DevExpress.XtraEditors.SimpleButton btnRetirar;
    }
}