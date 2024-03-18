namespace ExpedicionInternaPC
{
    partial class frmNuevaCasilla
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.grdCalle = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbDistrito = new System.Windows.Forms.ComboBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.cmbUbicacion = new DevExpress.XtraEditors.GridLookUpEdit();
            this.cmbUbicacionGrid = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmbGrdColArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cmbGrdColDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtAlias = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtCasilla = new DevExpress.XtraEditors.TextEdit();
            this.c = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.geoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCalle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUbicacion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUbicacionGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCasilla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.geoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.grdCalle);
            this.layoutControl1.Controls.Add(this.cmbDistrito);
            this.layoutControl1.Controls.Add(this.cmbProvincia);
            this.layoutControl1.Controls.Add(this.cmbDepartamento);
            this.layoutControl1.Controls.Add(this.cmbUbicacion);
            this.layoutControl1.Controls.Add(this.txtAlias);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.txtCasilla);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(546, 70, 250, 350);
            this.layoutControl1.Root = this.c;
            this.layoutControl1.Size = new System.Drawing.Size(493, 223);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // grdCalle
            // 
            this.grdCalle.Location = new System.Drawing.Point(128, 135);
            this.grdCalle.Name = "grdCalle";
            this.grdCalle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.grdCalle.Properties.View = this.gridLookUpEdit1View;
            this.grdCalle.Size = new System.Drawing.Size(353, 20);
            this.grdCalle.StyleController = this.layoutControl1;
            this.grdCalle.TabIndex = 12;
            this.grdCalle.EditValueChanged += new System.EventHandler(this.grdCalle_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 118;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Calle";
            this.gridColumn2.FieldName = "Descripcion";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 1062;
            // 
            // cmbDistrito
            // 
            this.cmbDistrito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDistrito.FormattingEnabled = true;
            this.cmbDistrito.Location = new System.Drawing.Point(128, 110);
            this.cmbDistrito.Name = "cmbDistrito";
            this.cmbDistrito.Size = new System.Drawing.Size(353, 21);
            this.cmbDistrito.TabIndex = 11;
            this.cmbDistrito.SelectedIndexChanged += new System.EventHandler(this.cmbDistrito_SelectedIndexChanged);
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(128, 85);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(353, 21);
            this.cmbProvincia.TabIndex = 10;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(128, 60);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(353, 21);
            this.cmbDepartamento.TabIndex = 9;
            this.cmbDepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbDepartamento_SelectedIndexChanged);
            // 
            // cmbUbicacion
            // 
            this.cmbUbicacion.EditValue = "";
            this.cmbUbicacion.Location = new System.Drawing.Point(128, 159);
            this.cmbUbicacion.Name = "cmbUbicacion";
            this.cmbUbicacion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbUbicacion.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.cmbUbicacion.Properties.View = this.cmbUbicacionGrid;
            this.cmbUbicacion.Size = new System.Drawing.Size(353, 20);
            this.cmbUbicacion.StyleController = this.layoutControl1;
            this.cmbUbicacion.TabIndex = 8;
            // 
            // cmbUbicacionGrid
            // 
            this.cmbUbicacionGrid.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.cmbGrdColArea,
            this.cmbGrdColDescripcion});
            this.cmbUbicacionGrid.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cmbUbicacionGrid.Name = "cmbUbicacionGrid";
            this.cmbUbicacionGrid.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cmbUbicacionGrid.OptionsView.ShowAutoFilterRow = true;
            this.cmbUbicacionGrid.OptionsView.ShowGroupPanel = false;
            // 
            // cmbGrdColArea
            // 
            this.cmbGrdColArea.Caption = "ID";
            this.cmbGrdColArea.FieldName = "ID";
            this.cmbGrdColArea.Name = "cmbGrdColArea";
            this.cmbGrdColArea.OptionsColumn.ReadOnly = true;
            this.cmbGrdColArea.Visible = true;
            this.cmbGrdColArea.VisibleIndex = 0;
            this.cmbGrdColArea.Width = 114;
            // 
            // cmbGrdColDescripcion
            // 
            this.cmbGrdColDescripcion.Caption = "Descripcion";
            this.cmbGrdColDescripcion.FieldName = "Descripcion";
            this.cmbGrdColDescripcion.Name = "cmbGrdColDescripcion";
            this.cmbGrdColDescripcion.OptionsColumn.ReadOnly = true;
            this.cmbGrdColDescripcion.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.cmbGrdColDescripcion.Visible = true;
            this.cmbGrdColDescripcion.VisibleIndex = 1;
            this.cmbGrdColDescripcion.Width = 1066;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(128, 36);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAlias.Size = new System.Drawing.Size(353, 20);
            this.txtAlias.StyleController = this.layoutControl1;
            this.txtAlias.TabIndex = 7;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(12, 183);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(469, 22);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Asignar Bandeja";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtCasilla
            // 
            this.txtCasilla.Location = new System.Drawing.Point(128, 12);
            this.txtCasilla.Name = "txtCasilla";
            this.txtCasilla.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCasilla.Size = new System.Drawing.Size(353, 20);
            this.txtCasilla.StyleController = this.layoutControl1;
            this.txtCasilla.TabIndex = 4;
            // 
            // c
            // 
            this.c.CustomizationFormText = "layoutControlGroup1";
            this.c.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.c.GroupBordersVisible = false;
            this.c.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem2,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem5,
            this.layoutControlItem8});
            this.c.Location = new System.Drawing.Point(0, 0);
            this.c.Name = "c";
            this.c.Size = new System.Drawing.Size(493, 223);
            this.c.Text = "c";
            this.c.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtCasilla;
            this.layoutControlItem1.CustomizationFormText = "Casilla";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(473, 24);
            this.layoutControlItem1.Text = "Nombre Bandeja";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.simpleButton1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 171);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(473, 32);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtAlias;
            this.layoutControlItem4.CustomizationFormText = "Alias";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(473, 24);
            this.layoutControlItem4.Text = "Alias (segundo nombre)";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.cmbDepartamento;
            this.layoutControlItem2.CustomizationFormText = "Departamento";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(473, 25);
            this.layoutControlItem2.Text = "Departamento";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.cmbProvincia;
            this.layoutControlItem6.CustomizationFormText = "Provincia";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 73);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(473, 25);
            this.layoutControlItem6.Text = "Provincia";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.cmbDistrito;
            this.layoutControlItem7.CustomizationFormText = "Distrito";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 98);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(473, 25);
            this.layoutControlItem7.Text = "Distrito";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.cmbUbicacion;
            this.layoutControlItem5.CustomizationFormText = "Punto de Entrega";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 147);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(473, 24);
            this.layoutControlItem5.Text = "Oficina";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(113, 13);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.grdCalle;
            this.layoutControlItem8.CustomizationFormText = "Calle";
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 123);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(473, 24);
            this.layoutControlItem8.Text = "Calle";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(113, 13);
            // 
            // geoBindingSource
            // 
            this.geoBindingSource.DataSource = typeof(Interna.Entity.Geo);
            // 
            // frmNuevaCasilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 223);
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNuevaCasilla";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Bandeja";
            this.Load += new System.EventHandler(this.NuevaCasilla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCalle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUbicacion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbUbicacionGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAlias.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCasilla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.geoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit txtCasilla;
        private DevExpress.XtraLayout.LayoutControlGroup c;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.TextEdit txtAlias;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.GridLookUpEdit cmbUbicacion;
        private DevExpress.XtraGrid.Views.Grid.GridView cmbUbicacionGrid;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraGrid.Columns.GridColumn cmbGrdColDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn cmbGrdColArea;
        private DevExpress.XtraEditors.GridLookUpEdit grdCalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.ComboBox cmbDistrito;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private System.Windows.Forms.BindingSource geoBindingSource;
    }
}