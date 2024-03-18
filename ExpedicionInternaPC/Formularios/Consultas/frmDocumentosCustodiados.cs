using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmDocumentosCustodiados : frmChild
    {
        #region Variables

        public List<Objeto> listaCustodiadosObjeto = new List<Objeto>();
        public List<Objeto> listaPorImprimir = new List<Objeto>();
        int indiceRemitente = -1;
        int indiceDestinatario = -1;

        #endregion 

        #region Metodos

        //2022
        private void EscogerDoubleClick(DevExpress.XtraEditors.TextEdit tex, ListBox listbox)
        {
            try
            {
                if (listbox.DataSource != null)
                {
                    tex.Text = listbox.SelectedValue.ToString();
                    listbox.Visible = false;
                    tex.Focus();
                }
            }
            catch
            {
                Program.mensaje(String.Format("Seleccione correctamente la bandeja"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }
        }
        //2022
        private void Consultar(DevExpress.XtraEditors.TextEdit tex, ListBox listbox, ref int indice)
        {
            if (tex.Text != "")
            {
                Source(listbox, tex);
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
        public void Source(ListBox listbox, DevExpress.XtraEditors.TextEdit txt)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Metodos.rObtenerDescripcion(txt.Text);
                listbox.DataSource = dt;
                listbox.ValueMember = "sDescripcion";
                listbox.DisplayMember = "sDescripcion";
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
        //2022
        private void EscogerBandeja(KeyEventArgs e, ListBox listBox, DevExpress.XtraEditors.TextEdit txt, ref int indice)
        {
            if (e.KeyCode == Keys.Down)
            {
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
                    Consultar();
                }
                try
                {
                    if (listBox.DataSource != null)
                    {
                        txt.Text = listBox.SelectedValue.ToString();
                        txt.Focus();
                        listBox.Visible = false;
                        indice = -1;
                        return;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }
        //2022
        private void CargarComponente()
        {
            lboxRemitente.Location = new Point(txtRemitente.Location.X, txtRemitente.Location.Y + 20);
            lboxRemitente.Size = new Size(txtRemitente.Size.Width, lboxRemitente.Size.Height);
            lboxDestinatario.Location = new Point(txtDestinatario.Location.X, txtDestinatario.Location.Y + 20);
            lboxDestinatario.Size = new Size(txtDestinatario.Size.Width, lboxDestinatario.Size.Height);
        }
        //2022
        private void PintarGrilla()
        {
            try
            {
                if (grvImpresos.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }

                Objeto oO = (Objeto)grvImpresos.GetFocusedRow();

                if (listaPorImprimir.Count == 0)
                {
                    if (oO != null)
                    {
                        oO.SeleccionGrafica = true;
                        listaPorImprimir.Add(oO);
                    }
                    else
                        return;
                }
                else
                {
                    var obj = listaPorImprimir.Find(hol => hol.Autogenerado == oO.Autogenerado);
                    if (obj == null)
                    {
                        oO.SeleccionGrafica = true;
                        listaPorImprimir.Add(oO);
                    }
                    else
                    {
                        oO.SeleccionGrafica = false;
                        listaPorImprimir.Remove(oO);
                    }

                }
            }
            catch (Exception)
            {
            }
        }
        //2022
        private void ImprimirLista()
        {
            if (listaPorImprimir.Count() > 0)
            {
                if (listaPorImprimir.Exists(c => c.sTipoElemento.ToUpper() != "AUTOGENERADO"))
                {
                    Program.mensaje(String.Format("No puede reimprimir documentos externos, solo autogenerados."), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Focus();
                    return;
                }
                frmImpresionControl frmcontrol = new frmImpresionControl();
                frmcontrol.LlenarGrilla(listaPorImprimir);
                if (frmcontrol.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    CargarCustodiados(dtpDesde.Value.Date, dtpHasta.Value.Date);
                    listaPorImprimir.Clear();
                    Program.mensaje(string.Format("Se ha reimpreso correctamente"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                }
                else
                {
                    foreach (Objeto oO in listaPorImprimir)
                    {
                        listaCustodiadosObjeto.Find(hel => hel.Autogenerado == oO.Autogenerado).SeleccionGrafica = false;
                    }
                    listaPorImprimir.Clear();
                    grdImpresos.RefreshDataSource();
                }
            }
            else
            {
                Program.mensaje(String.Format("Seleccione el autogenerado que desea reimprimir."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Focus();
                return;
            }
        }
        //2022
        private void Consultar()
        {
            try
            {
                grdImpresos.DataSource = null;

                if (txtAutogenerado.Text.Trim().ToString() != "" && txtAutogenerado.Text.Count() >= 6)
                {
                    CargarCustodiados(txtAutogenerado.Text, "", "", "", "");
                }
                else if (txtRemitente.Text.Trim() != "" && txtDestinatario.Text.Trim() != "")
                {
                    if (dtpDesde.Value.Date.CompareTo(dtpHasta.Value.Date) <= 0)
                        CargarCustodiados("", txtDestinatario.Text.Trim(), txtRemitente.Text.Trim(), dtpDesde.Value.Date.ToShortDateString().ToString(), dtpHasta.Value.Date.ToShortDateString().ToString());
                    else
                        Program.mensaje(String.Format("Seleccione un rango de fecha válido"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtRemitente.Text != "")
                {
                    if (dtpDesde.Value.Date.CompareTo(dtpHasta.Value.Date) <= 0)
                        CargarCustodiados("", "", txtRemitente.Text.Trim(), dtpDesde.Value.Date.ToShortDateString().ToString(), dtpHasta.Value.Date.ToShortDateString().ToString());
                    else
                        Program.mensaje(String.Format("Seleccione un rango de fecha válido"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtDestinatario.Text != "")
                {
                    if (dtpDesde.Value.Date.CompareTo(dtpHasta.Value.Date) <= 0)
                        CargarCustodiados("", txtDestinatario.Text.Trim(), "", dtpDesde.Value.Date.ToShortDateString().ToString(), dtpHasta.Value.Date.ToShortDateString().ToString());
                    else
                        Program.mensaje(String.Format("Seleccione un rango de fecha válido"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (txtAutogenerado.Text.Trim().Count() < 6 && txtAutogenerado.Text != "")
                {
                    Program.mensaje(String.Format("No se encontraron resultados. Verifique código ingresado"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (dtpDesde.Value.Date.CompareTo(dtpHasta.Value.Date) <= 0)
                        CargarCustodiados("", "", "", dtpDesde.Value.Date.ToShortDateString().ToString(), dtpHasta.Value.Date.ToShortDateString().ToString());
                    else
                        Program.mensaje(String.Format("Seleccione un rango de fecha válido"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                return;
            }
        }
        //2022
        private void CargarCustodiados(DateTime fechaDesde, DateTime fechaHasta)
        {
            Program.ShowPopWaitScreen();
            try
            {
                listaCustodiadosObjeto = Metodos.rObjetoExpedicion_Custodiados1(fechaDesde, fechaHasta, Convert.ToInt32(TipoCustodia.Ver_Custodiados_Pisos_Agencias));
                grdImpresos.DataSource = listaCustodiadosObjeto;
                grdImpresos.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception ex)
            {

            }

            Program.HidePopWaitScreen();
        }
        //2022
        private void CargarCustodiados(string autogenerado, string destinatario, string remitente, string fechaDesde, string fechaHasta)
        {
            try
            {
                listaCustodiadosObjeto = Metodos.rOneObjetoCustodia(autogenerado, destinatario, remitente, fechaDesde, fechaHasta);
                if (!(txtAutogenerado.Text.Trim().Equals("")))
                {
                    if (listaCustodiadosObjeto.Count == 0)
                    {
                        List<Objeto> listaObjetoEstado = Metodos.ValidarEstadoObjeto(txtAutogenerado.Text.Trim());
                        if (listaObjetoEstado.Count != 0)
                        {
                            Objeto obj = listaObjetoEstado[0];
                            if (obj != null)
                            {
                                if (obj.IdTipoEstado == 1)
                                {
                                    Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1}, la expedicion responsable es : {2}.", obj.Autogenerado, obj.Estado.ToLower(), obj.DescripcionExpedicionResponsable), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                else
                                {
                                    if (obj.IdTipoEstado == 2)
                                    {
                                        Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por la expedicion : {2}.", obj.Autogenerado, obj.Estado.ToLower(), obj.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }

                                    else if (obj.IdTipoEstado == 3)
                                    {
                                        Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por la expedicion : {2}.", obj.Autogenerado, obj.Estado.ToLower(), obj.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    else if (obj.IdTipoEstado == 6)
                                    {
                                        Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por la expedicion : {2}.", obj.Autogenerado, obj.Estado.ToLower(), obj.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    else
                                    {
                                        Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por {2} que se encuentra en : {3}.", obj.Autogenerado, obj.Estado.ToLower(), obj.CasillaPara, obj.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }

                        }
                        else
                        {
                            Program.mensaje(string.Format("No se encontraron resultados. Verifique código ingresado"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                else
                {
                    if (listaCustodiadosObjeto.Count == 0)
                    {
                        Program.mensaje(string.Format("No se encontró ningún resultado que coincida con esta búsqueda."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                grdImpresos.DataSource = listaCustodiadosObjeto;
                grdImpresos.RefreshDataSource();
            }
            catch (Exception)
            {

                return;
            }

        }
        //2022
        public override void ExportExcel(String FileName)
        {
            grdImpresos.ExportToXls(FileName);
        }
        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            CargarCustodiados(new DateTime(1999, 1, 1), dtpHasta.Value.Date);
            dtpDesde.Value = listaCustodiadosObjeto.OrderBy(c => c.FechaCustodia).ToList<Objeto>()[0].FechaCustodia;
        }

        #endregion

        public frmDocumentosCustodiados()
        {
            InitializeComponent();
            txtAutogenerado.Properties.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Consultar();
            }
        }

        private void txtRemitente_KeyDown(object sender, KeyEventArgs e)
        {
            EscogerBandeja(e, lboxRemitente, txtRemitente, ref indiceRemitente);
        }

        private void txtDestinatario_KeyDown(object sender, KeyEventArgs e)
        {
            EscogerBandeja(e, lboxDestinatario, txtDestinatario, ref indiceDestinatario);
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void txtRemitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndSpace(e);
        }

        private void txtDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndSpace(e);
        }

        private void txtAutogenerado_TextChanged(object sender, EventArgs e)
        {
            if (txtAutogenerado.Text.Count() > 0)
            {
                txtDestinatario.Enabled = false;
                txtRemitente.Enabled = false;
            }
            else
            {
                txtDestinatario.Enabled = true;
                txtRemitente.Enabled = true;
            }
        }

        private void txtRemitente_TextChanged(object sender, EventArgs e)
        {
            if (txtRemitente.Text.Count() > 0)
            {
                txtAutogenerado.Enabled = false;
            }
            else
            {
                if (txtDestinatario.Text.Count() > 0)
                {
                    txtAutogenerado.Enabled = false;
                }
                else
                {
                    txtAutogenerado.Enabled = true;
                }
            }
            Consultar(txtRemitente, lboxRemitente, ref indiceRemitente);
        }

        private void txtDestinatario_TextChanged(object sender, EventArgs e)
        {
            if (txtDestinatario.Text.Count() > 0)
            {
                txtAutogenerado.Enabled = false;
            }
            else
            {
                if (txtRemitente.Text.Count() > 0)
                {
                    txtAutogenerado.Enabled = false;
                }
                else
                {
                    txtAutogenerado.Enabled = true;
                }
            }
            Consultar(txtDestinatario, lboxDestinatario, ref indiceDestinatario);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void btnImprimirLista_Click(object sender, EventArgs e)
        {
            ImprimirLista();
        }

        private void repositoryItemHyperLinkEdit3_Click(object sender, EventArgs e)
        {
            Objeto oO = (Objeto)grvImpresos.GetFocusedRow();
            oO.IdTipoEntrega = 1;
            Metodos.VerTracking(oO);
        }

        private void frmDocumentosCustodiados_Resize(object sender, EventArgs e)
        {
            CargarComponente();
        }

        private void lboxDestinatario_Click(object sender, EventArgs e)
        {
            indiceDestinatario = lboxDestinatario.SelectedIndex;
            EscogerDoubleClick(txtDestinatario, lboxDestinatario);
        }

        private void lboxRemitente_Click(object sender, EventArgs e)
        {
            indiceRemitente = lboxRemitente.SelectedIndex;
            EscogerDoubleClick(txtRemitente, lboxRemitente);
        }

        private void lboxRemitente_DoubleClick(object sender, EventArgs e)
        {
            //EscogerDoubleClick(txtRemitente, lboxRemitente);
        }

        private void lboxDestinatario_DoubleClick(object sender, EventArgs e)
        {
            //EscogerDoubleClick(txtDestinatario, lboxDestinatario);
        }

        private void lboxRemitente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EscogerBandeja(e, lboxRemitente, txtRemitente, ref indiceRemitente);
                txtRemitente.Focus();
            }
        }

        private void lboxDestinatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EscogerBandeja(e, lboxDestinatario, txtDestinatario, ref indiceDestinatario);
                txtDestinatario.Focus();
            }
        }

        private void frmDocumentosCustodiados_Load(object sender, EventArgs e)
        {
            CargarComponente();
            CargarCustodiados(new DateTime(1999, 1, 1), dtpHasta.Value.Date);
            try
            {
                if (listaCustodiadosObjeto.Count > 0)
                {
                    dtpDesde.Value = listaCustodiadosObjeto.OrderBy(c => c.FechaCustodia).ToList<Objeto>()[0].FechaCustodia;
                }
                else
                {
                    dtpDesde.Value = DateTime.Today;
                }

            }
            catch (Exception ex)
            {

            }



        }

        private void gridView2_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oCol = null;
                int i_geo_anterior = 0;

                try
                {
                    oCol = (GridColumn)View.Columns["iIdGeoDestinoAnterior"];
                }
                catch (Exception) { }

                if (oCol != null)
                {
                    try
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.White;
                        i_geo_anterior = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oCol).ToString());
                        if (i_geo_anterior > 0)
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor2 = Color.IndianRed;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor2 = Color.White;
                        }
                    }
                    catch (Exception) { }
                }
            }
        }

        private void repositoryItemCheckEdit3_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            try
            {
                if ((bool)e.NewValue == true)
                {
                    Objeto objeto = (Objeto)grvImpresos.GetFocusedRow();
                    if (objeto.IdEntrega != 0)
                    {
                        Program.mensaje(String.Format("No puede reimprimir el elemento, está dentro de una entrega"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Focus();
                        e.Cancel = true;
                        return;
                    }
                }
                PintarGrilla();
            }
            catch (Exception)
            {
            }
        }

        private void grvImpresos_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oCol = null;
                int i_geo_anterior = 0;

                try
                {
                    oCol = (GridColumn)View.Columns["iIdGeoDestinoAnterior"];
                }
                catch (Exception) { }

                if (oCol != null)
                {
                    try
                    {
                        if (e.Column.FieldName == "indicadorFlag")
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor2 = Color.White;
                        }
                        i_geo_anterior = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oCol).ToString());

                        if (i_geo_anterior > 0)
                        {
                            if (e.Column.FieldName == "indicadorFlag")
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.BackColor2 = Color.IndianRed;
                            }
                        }
                        else
                        {
                            if (e.Column.FieldName == "indicadorFlag")
                            {
                                e.Appearance.BackColor = Color.White;
                                e.Appearance.BackColor2 = Color.White;
                            }
                        }
                    }
                    catch (Exception) { }
                }
            }
        }


    }
}

