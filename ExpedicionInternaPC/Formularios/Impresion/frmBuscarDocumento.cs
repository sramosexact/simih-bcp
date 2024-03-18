using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmBuscarDocumento : frmChild
    {
        #region Variales
        List<Objeto> data;
        List<Objeto> lobj;
        GridView gridView;
        GridView gridView3;
        GridControl grdcontrol;
        List<Objeto> lPorImprimir;
        List<Objeto> lObjeto = new List<Objeto>();
        private int indiceRemitente = -1;
        private int indiceDestinatario = -1;
        #endregion

        #region Metodos

        //2022
        private void AgregarAutogenerados()
        {
            if (txtDestinatario.Text.Trim() == "" && txtRemitente.Text.Trim() == "")
            {
                Program.mensaje("Ingrese el remitente y/o destinatario", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            if (txtDestinatario.Text.Trim() != "" || txtRemitente.Text.Trim() != "" || (txtDestinatario.Text.Trim() == "" && txtRemitente.Text.Trim() != "") || (txtDestinatario.Text.Trim() != "" && txtRemitente.Text.Trim() == ""))
            {
                if (txtRemitente.Text.Trim().Equals(txtDestinatario.Text.Trim()))
                {
                    gridControl1.DataSource = null;
                    gridControl1.Enabled = false;
                    btnAceptar.Enabled = false;
                    Program.mensaje("Las bandejas escogidas no deben ser las mismas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                try
                {
                    data = Metodos.rObtenerCreados(txtRemitente.Text, txtDestinatario.Text);
                    if (data.Count != 0)
                    {
                        btnAceptar.Enabled = true;
                        gridControl1.DataSource = data;
                        gridControl1.Enabled = true;

                    }
                    else
                    {
                        gridControl1.DataSource = null;
                        gridControl1.Enabled = false;
                        btnAceptar.Enabled = false;
                        Program.mensaje("No se encontró ningún resultado que coincida con esta búsqueda.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar buscar el autogenerado.");
                    return;
                }

            }
            else
            {
                Program.mensaje("No se encontró ningún resultado que coincida con esta búsqueda.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //2022
        private void consultar(DevExpress.XtraEditors.TextEdit tex, ListBox listbox, ref int indice)
        {

            if (tex.Text != "")
            {
                source(listbox, tex);
                if (listbox.Items.Count > 0)
                {
                    if (tex.Text.Trim() == listbox.Items[0].ToString())
                    {
                        listbox.Visible = false;
                        return;
                    }
                    listbox.Visible = true;
                }
                if (listbox.Items.Count == 0)
                {
                    listbox.Visible = false;

                }

            }
            else
                listbox.Visible = false;

            indice = -1;
        }
        //2022
        public void source(ListBox listbox, DevExpress.XtraEditors.TextEdit txt)
        {
            DataTable dt = new DataTable();
            try
            {

                listbox.Items.Clear();
                foreach (DataRow row in dt.Rows)
                {
                    listbox.Items.Add(Convert.ToString(row[1]));
                }
                listbox.Size = new System.Drawing.Size(261, (dt.Rows.Count + 1) * 12);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                return;
            }

        }


        #endregion

        public frmBuscarDocumento(List<Objeto> lobj, GridControl grdcontrol, GridView gridView, GridView gridView3, List<Objeto> lPorImprimir)
        {
            this.grdcontrol = grdcontrol;
            this.lobj = lobj;
            this.gridView = gridView;
            this.lPorImprimir = lPorImprimir;
            this.gridView3 = gridView3;
            InitializeComponent();
        }

        private void txtBandeja_TextChanged(object sender, EventArgs e)
        {
            consultar(txtDestinatario, listBox3, ref indiceDestinatario);
        }

        private void txtBandeja_KeyDown(object sender, KeyEventArgs e)
        {
            escogerBandeja(e, listBox3, txtDestinatario, ref indiceDestinatario);
        }

        private void listBox3_Click(object sender, EventArgs e)
        {
            indiceDestinatario = listBox3.SelectedIndex;
        }

        private void escogerBandeja(KeyEventArgs e, ListBox listBox, DevExpress.XtraEditors.TextEdit txt, ref int indice)
        {

            if (e.KeyCode == Keys.Down)
            {
                //listBox3.Focus();
                if (indice < listBox.Items.Count - 1 && indice > -2)
                {

                    indice = indice + 1;
                    listBox.SelectedIndex = indice;


                }
                else
                    return;
            }
            if (e.KeyCode == Keys.Up)
            {
                txt.SelectionStart = txt.Text.Length + 1;
                if (indice < listBox.Items.Count && indice > 0)
                {
                    indice--;
                    listBox.SelectedIndex = indice;

                }
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (listBox.Visible == false)
                {
                    AgregarAutogenerados();
                }
                try
                {
                    if (indice != -1)
                    {
                        txt.Text = listBox.Items[indice].ToString();
                        txt.Focus();
                        listBox.Visible = false;
                        indice = -1;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void listBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escogerBandeja(e, listBox3, txtDestinatario, ref indiceDestinatario);
                txtDestinatario.Focus();
            }
        }

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            escogerDoubleClick(txtDestinatario, listBox3);
        }

        private void escogerDoubleClick(DevExpress.XtraEditors.TextEdit tex, ListBox listbox)
        {
            try
            {
                tex.Text = listbox.Items[listbox.SelectedIndex].ToString();
                tex.Focus();
            }
            catch
            {
                Program.mensaje(String.Format("Porfavor seleccione correctamente la bandeja"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarAutogenerados();
        }

        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }
                Objeto obj = (Objeto)gridView1.GetFocusedRow();
                if (lObjeto.Count == 0)
                {
                    obj.SeleccionGrafica = true;
                    lObjeto.Add(obj);
                    gridView1.RefreshData();
                    gridControl1.RefreshDataSource();
                }
                else
                {
                    Objeto result = lObjeto.Find(hol => hol.Autogenerado == obj.Autogenerado);
                    if (result == null)
                    {
                        data.Find(hol => hol.Autogenerado == lObjeto[0].Autogenerado).SeleccionGrafica = false;
                        obj.SeleccionGrafica = true;
                        lObjeto[0] = obj;
                        gridView1.RefreshData();
                        gridControl1.RefreshDataSource();
                    }
                    else
                    {
                        obj.SeleccionGrafica = false;
                        lObjeto.Remove(obj);
                    }

                }
            }
            catch (Exception)
            {
                Program.mensaje("Solo debe seleccionar un elemento.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Objeto resultado = lobj.Find(hol => hol.Autogenerado == lObjeto[0].Autogenerado);
                if (resultado != null)
                {

                    resultado.SeleccionGrafica = true;
                    if (lPorImprimir.Find(hol => hol.Autogenerado == lObjeto[0].Autogenerado) == null)
                    {
                        lPorImprimir.Add(resultado);
                    }
                    else
                    {
                        Program.mensaje("El elemento ya se encuentra seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    grdcontrol.RefreshDataSource();
                    gridView.RefreshData();
                    gridView3.RefreshData();
                    gridView.Columns["SeleccionGrafica"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    Program.mensaje("Se seleccionó correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    this.Dispose();
                }
                else
                {
                    if (lPorImprimir.Find(hol => hol.Autogenerado == lObjeto[0].Autogenerado) == null)
                    {
                        lPorImprimir.Add(lObjeto[0]);

                    }
                    else
                    {
                        Program.mensaje("El elemento ya se encuentra seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    Program.mensaje("Se seleccionó correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lObjeto[0].SeleccionGrafica = true;
                    lobj.Add(lObjeto[0]);
                    grdcontrol.RefreshDataSource();
                    gridView.RefreshData();
                    gridView.Columns["SeleccionGrafica"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    this.Close();
                    this.Dispose();
                }
            }
            catch
            {
                Program.mensaje("Elija el elemento a agregar.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escogerBandeja(e, listBox1, txtRemitente, ref indiceRemitente);
                txtDestinatario.Focus();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            escogerDoubleClick(txtRemitente, listBox1);
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            indiceRemitente = listBox1.SelectedIndex;
        }

        private void textEdit1_KeyDown(object sender, KeyEventArgs e)
        {
            escogerBandeja(e, listBox1, txtRemitente, ref indiceRemitente);

        }

        private void txtRemitente_TextChanged(object sender, EventArgs e)
        {
            consultar(txtRemitente, listBox1, ref indiceRemitente);
        }

        private void frmBuscarDocumento_Load(object sender, EventArgs e)
        {
            listBox1.BringToFront();
            listBox3.BringToFront();
        }

    }
}
