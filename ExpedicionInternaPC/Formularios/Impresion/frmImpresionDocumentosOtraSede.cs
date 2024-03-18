using ExpedicionInternaPC.Properties;
using ImpresionZebra;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmDocumentosCustodiadosOtraSede : frmChild
    {
        #region Variables

        public List<Objeto> loResultado = new List<Objeto>();
        public List<Objeto> loSeleccion = new List<Objeto>();
        private int indiceRemitente = -1;
        private int indiceDestinatario = -1;

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
                Program.mensaje(String.Format("Porfavor seleccione correctamente la bandeja"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            DataTable dt;
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
                txt.SelectionStart = txt.Text.Count();
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
                    Buscar();
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
        private void Buscar()
        {
            if (txtAutogenerado.Text.Trim().ToUpper() == String.Empty && txtRemitente.Text.Trim().ToUpper() == String.Empty && txtDestinatario.Text.Trim().ToUpper() == String.Empty)
            {
                Program.mensaje("Ingrese algún valor a buscar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                loResultado = new List<Objeto>();
                grdResultado.DataSource = loResultado;
                return;
            }

            try
            {
                loResultado = Metodos.ObjetoOtraSucursal(txtAutogenerado.Text.Trim().ToUpper(), txtRemitente.Text.Trim().ToUpper(), txtDestinatario.Text.Trim().ToUpper(), Program.oUsuario.IdExpedicion);

                if (txtAutogenerado.Text.Length > 0 && loResultado.Count == 1)
                {
                    if (loResultado[0].IdExpedicionResponsable == Program.oUsuario.IdExpedicion)
                    {
                        Program.mensaje(string.Format("El autogenerado se encuentra en estado '{0}' por expedicion : {1}", loResultado[0].Estado.ToUpper(), loResultado[0].Procedencia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loResultado = new List<Objeto>();
                        grdResultado.DataSource = loResultado;
                        return;
                    }

                    if (loResultado[0].IdTipoEstado != 1)
                    {
                        Program.mensaje(string.Format("El autogenerado se encuentra en estado '{0}' por expedicion : {1}", loResultado[0].Estado.ToUpper(), loResultado[0].Procedencia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loResultado = new List<Objeto>();
                        grdResultado.DataSource = loResultado;
                        return;
                    }
                }
                else if (txtAutogenerado.Text.Length == 0 && loResultado.Count == 0 && (txtRemitente.Text.Length != 0 || txtDestinatario.Text.Length != 0))
                {
                    Program.mensaje(string.Format("No se encontró ningún resultado que coincida con esta búsqueda."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loResultado = new List<Objeto>();
                    grdResultado.DataSource = loResultado;
                    return;

                }
                else
                {
                    if (loResultado.Count == 0)
                    {
                        Program.mensaje("No se encontraron resultados. Por favor verifique el código ingresado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loResultado = new List<Objeto>();
                        grdResultado.DataSource = loResultado;
                        return;
                    }
                }
                grdResultado.DataSource = loResultado;
            }
            catch (InvalidTokenException)
            {

                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar buscar el autogenerado.");
            }


        }
        //2022
        private void SeleccionarRegistro()
        {
            try
            {
                if (grvResultado.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }
                Objeto o = (Objeto)grvResultado.GetFocusedRow();
                if (o != null)
                {
                    if (loSeleccion.Count == 0)
                    {
                        o.SeleccionGrafica = true;
                        loSeleccion.Add(o);
                        grdResultado.Refresh();
                        grvResultado.RefreshData();
                    }
                    else
                    {
                        loResultado.Find(x => x.ID == loSeleccion[0].ID).SeleccionGrafica = false;
                        if (o.ID == loSeleccion[0].ID)
                        {
                            loSeleccion.Clear();
                        }
                        else
                        {
                            loSeleccion.Clear();
                            o.SeleccionGrafica = true;
                            loSeleccion.Add(o);
                        }
                        grdResultado.Refresh();
                        grvResultado.RefreshData();
                    }
                }
            }
            catch
            {
                return;
            }
        }
        //2022
        private void Imprimir()
        {
            if (loResultado == null || loResultado.Count == 0)
            {
                Program.mensaje("Busque el autogenerado que desea imprimir.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Objeto o = loResultado.Find(x => x.SeleccionGrafica == true);

            if (o == null)
            {
                Program.mensaje(String.Format("Seleccione el autogenerado que desea imprimir."), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int res = Metodos.uCustodiaAutogeneradoOtraSucursal(o.ID);
                if (res == 1)
                {
                    ImprimirZebra(o);
                    Program.mensaje(string.Format("El Autogenerado '{0}' ha sido custodiado.", o.Autogenerado), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loSeleccion.Clear();
                    loResultado.ForEach(c => c.SeleccionGrafica = false);
                    txtAutogenerado.ResetText();
                    txtRemitente.ResetText();
                    txtDestinatario.ResetText();
                    loResultado = new List<Objeto>();
                    grdResultado.DataSource = loResultado;
                }
                else if (res == -2)
                {
                    Program.mensaje("No se puede custodiar por este medio. El Autogenerado pertenece a la Expedición actual.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (res == -3)
                {
                    Program.mensaje("No se puede custodiar el elemento. Su Estado es diferente a CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Program.mensaje("No se ha podido completar la acción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar custodiar el autogenerado");
            }

        }
        //2022
        private void VistaPrevia(Objeto oO)
        {
            Objeto ooo = new Objeto();
            ooo.De = oO.CasillaDe.ToUpper();
            ooo.AreaOrigen = oO.AreaOrigen;
            ooo.Origen = oO.Origen.ToUpper();
            ooo.Para = oO.CasillaPara.ToUpper();
            ooo.AreaDestino = oO.AreaDestino;
            ooo.sDestino = oO.sDestino;
            ooo.Autogenerado = oO.Autogenerado.ToUpper();
            ooo.Prefijo = oO.Prefijo.ToUpper();
            frmEtiquetaAutogenedoModelo fea = new frmEtiquetaAutogenedoModelo(ooo);
            fea.Show();
        }
        //2022
        public void ImprimirZebra(Objeto oO)
        {
            try
            {
                EtiquetaCustodia etiqueta = new EtiquetaCustodia();
                etiqueta.De = oO.CasillaDe.ToUpper();
                etiqueta.AreaOrigen = oO.AreaOrigen;
                etiqueta.Origen = oO.Origen.ToUpper();
                etiqueta.Para = oO.CasillaPara.ToUpper();
                etiqueta.AreaDestino = oO.AreaDestino;
                etiqueta.Destino = oO.sDestino;
                etiqueta.Autogenerado = oO.Autogenerado.ToUpper();
                etiqueta.Prefijo = oO.Prefijo.ToUpper();
                //VistaPrevia(oO);
                ZebraZpl zpl = new ZebraZpl() { NOMBRE_IMPRESORA = Settings.Default["RutaImpresoraZebra"].ToString() };
                string s = zpl.etiquetaCustodia(etiqueta.De, etiqueta.AreaOrigen, etiqueta.Origen, etiqueta.Para, etiqueta.AreaDestino, etiqueta.Destino, etiqueta.Autogenerado, etiqueta.Prefijo);
                zpl.imprimirEtiqueta(s);
            }
            catch
            {
                Program.mensaje("Este documento no tiene ninguna referencia.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //2022
        private void PosicionarFront()
        {
            panelControl1.SendToBack();
            grdResultado.SendToBack();
            lboxRemitente.BringToFront();
            lboxDestinatario.BringToFront();
        }

        #endregion


        public frmDocumentosCustodiadosOtraSede()
        {
            InitializeComponent();
            txtAutogenerado.Properties.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void frmDocumentosCustodiadosOtraSede_Load(object sender, EventArgs e)
        {
            PosicionarFront();
        }

        private void txtAutogenerado_TextChanged(object sender, EventArgs e)
        {
            if (txtAutogenerado.Text.Length > 0)
            {
                txtRemitente.ResetText();
                txtDestinatario.ResetText();
                txtRemitente.Enabled = false;
                txtDestinatario.Enabled = false;
            }
            else
            {
                txtRemitente.Enabled = true;
                txtDestinatario.Enabled = true;
            }
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.alfanumericosAndGuiones(e);
            Program.mayusculas(e);
            if (txtAutogenerado.Text.Length >= 6 && e.KeyChar == 13)
            {
                Buscar();
            }
        }

        private void txtRemitente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtDestinatario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void grvResultado_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            SeleccionarRegistro();
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

        private void txtRemitente_KeyDown(object sender, KeyEventArgs e)
        {
            EscogerBandeja(e, lboxRemitente, txtRemitente, ref indiceRemitente);
        }

        private void txtDestinatario_KeyDown(object sender, KeyEventArgs e)
        {
            EscogerBandeja(e, lboxDestinatario, txtDestinatario, ref indiceDestinatario);
        }

        private void lboxRemitente_Click(object sender, EventArgs e)
        {
            indiceRemitente = lboxRemitente.SelectedIndex;
            EscogerDoubleClick(txtRemitente, lboxRemitente);
        }

        private void lboxDestinatario_Click(object sender, EventArgs e)
        {
            indiceDestinatario = lboxDestinatario.SelectedIndex;
            EscogerDoubleClick(txtDestinatario, lboxDestinatario);

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
    }
}
