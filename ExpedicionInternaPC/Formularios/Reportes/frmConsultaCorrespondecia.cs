using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmConsultaCorrespondecia : frmChild
    {
        #region variables
        int indiceRemitente = 0;
        int indiceDestinatario = 0;
        #endregion

        #region metodos

        //2022
        public void source(ListBox listbox, DevExpress.XtraEditors.TextEdit txt)
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
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los datos.");
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
        private void buscar()
        {
            grdObjetos.DataSource = null;
            if (txtAutogenerado.Text.Trim() != "")
            {
                if (txtAutogenerado.Text.Trim().Count() > 5)
                {
                    List<Objeto> listaObjeto = BuscarAutogenerado(txtAutogenerado.Text.Trim());

                    if (listaObjeto.Count() > 0)
                    {
                        grdObjetos.DataSource = listaObjeto;
                    }
                    else
                    {
                        Program.mensaje(String.Format("No se encontraron resultados. Verifique el código ingresado."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Program.mensaje(String.Format("No se encontraron resultados. Verifique el código ingresado."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            else
            {
                /*Se busca por la fecha de creación y el de , para*/
                if (txtDe.Text.Trim() != "" || txtPara.Text.Trim() != "")
                {
                    List<Objeto> listaObjeto = BuscarAutogeneradoSegundaOpcion(txtDe.Text.Trim(), txtPara.Text.Trim(), dteDesde.DateTime, dteHasta.DateTime);
                    if (listaObjeto.Count > 0)
                    {
                        grdObjetos.DataSource = listaObjeto;
                    }
                    else
                    {
                        Program.mensaje("No se encontró ningún resultado que coincida con esta búsqueda.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                /*Se busca por las fechas*/
                else
                {
                    if (((DateTime)dteDesde.EditValue).Date.CompareTo(((DateTime)dteHasta.EditValue).Date) <= 0)
                    {
                        List<Objeto> listaObjeto = BuscarAutogeneradoSegundaOpcion(txtDe.Text.Trim(), txtPara.Text.Trim(), dteDesde.DateTime, dteHasta.DateTime);
                        if (listaObjeto.Count > 0)
                        {
                            grdObjetos.DataSource = listaObjeto;
                        }
                        else
                        {
                            Program.mensaje("No se encontró ningún resultado que coincida con esta búsqueda.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        Program.mensaje(String.Format("Seleccione un rango de fecha válido"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        //2022
        public override void ExportExcel(String FileName)
        {
            grdObjetos.ExportToXls(FileName);
        }
        //2022
        private List<Objeto> BuscarAutogenerado(String autogenerado)
        {
            List<Objeto> lObjeto = new List<Objeto>();
            try
            {
                lObjeto = Metodos.rConsultaAutogeneradoReporte(autogenerado);
            }
            catch (InvalidTokenException)
            {
                lObjeto = null;
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener resultados.");
            }

            return lObjeto;
        }
        //2022
        private List<Objeto> BuscarAutogeneradoSegundaOpcion(String de, String para, DateTime desde, DateTime hasta)
        {
            List<Objeto> lObjeto = new List<Objeto>();
            try
            {
                lObjeto = Metodos.rConsultaAutogeneradoReporteSegunda(de, para, desde, hasta);
            }
            catch (InvalidTokenException)
            {
                lObjeto = null;
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener resultados.");
            }
            return lObjeto;
        }
        //2022
        private void AbrirTracking(object sender, EventArgs e)
        {
            Objeto oo = (Objeto)grvObjetos.GetFocusedRow();
            Metodos.VerTracking(oo);
        }
        //2022
        private void escogerDoubleClick(DevExpress.XtraEditors.TextEdit tex, ListBox listbox)
        {
            try
            {
                tex.Text = listbox.SelectedValue.ToString();
                listbox.Visible = false;
                tex.Focus();
            }
            catch
            {
                Program.mensaje(String.Format("Por favor seleccione correctamente la bandeja"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        //2022
        private void escogerBandeja(KeyEventArgs e, ListBox listBox, DevExpress.XtraEditors.TextEdit txt, ref int indice)
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
                    buscar();
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
        private void CargarFechas()
        {
            dteDesde.EditValue = DateTime.Now;
            dteHasta.EditValue = DateTime.Now;
        }
        //2022
        private void CargarComponente()
        {
            lboxRemitente.Location = new Point(txtDe.Location.X, txtDe.Location.Y + 20);
            lboxRemitente.Size = new Size(txtDe.Size.Width + 50, lboxRemitente.Size.Height);
            lboxDestinatario.Location = new Point(txtPara.Location.X, txtPara.Location.Y + 20);
            lboxDestinatario.Size = new Size(txtPara.Size.Width + 50, lboxDestinatario.Size.Height);
        }

        #endregion


        public frmConsultaCorrespondecia()
        {
            InitializeComponent();
            txtAutogenerado.Properties.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void lboxRemitente_Click(object sender, EventArgs e)
        {
            indiceRemitente = lboxRemitente.SelectedIndex;
            escogerDoubleClick(txtDe, lboxRemitente);
        }

        private void lboxRemitente_DoubleClick(object sender, EventArgs e)
        {
            escogerDoubleClick(txtDe, lboxRemitente);
        }

        private void lboxRemitente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escogerBandeja(e, lboxRemitente, txtDe, ref indiceRemitente);
                txtDe.Focus();
            }
        }

        private void lboxDestinatario_Click(object sender, EventArgs e)
        {
            indiceDestinatario = lboxDestinatario.SelectedIndex;
            escogerDoubleClick(txtPara, lboxDestinatario);
        }

        private void lboxDestinatario_DoubleClick(object sender, EventArgs e)
        {
            escogerDoubleClick(txtPara, lboxDestinatario);
        }

        private void lboxDestinatario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                escogerBandeja(e, lboxDestinatario, txtPara, ref indiceDestinatario);
                txtPara.Focus();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void txtDe_KeyDown(object sender, KeyEventArgs e)
        {
            escogerBandeja(e, lboxRemitente, txtDe, ref indiceRemitente);
        }

        private void txtDe_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndSpace(e);
        }

        private void txtPara_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndSpace(e);
        }

        private void txtPara_KeyDown(object sender, KeyEventArgs e)
        {
            escogerBandeja(e, lboxDestinatario, txtPara, ref indiceDestinatario);
        }

        private void frmConsultaCorrespondecia_Load(object sender, EventArgs e)
        {
            CargarComponente();
            CargarFechas();
        }

        private void txtDe_TextChanged(object sender, EventArgs e)
        {
            if (txtDe.Text.Count() > 0)
            {
                txtAutogenerado.Enabled = false;
            }
            else
            {
                if (txtPara.Text.Count() > 0)
                {
                    txtAutogenerado.Enabled = false;
                }
                else
                {
                    txtAutogenerado.Enabled = true;
                }
            }
            consultar(txtDe, lboxRemitente, ref indiceRemitente);
        }

        private void txtPara_TextChanged(object sender, EventArgs e)
        {
            if (txtPara.Text.Count() > 0)
            {
                txtAutogenerado.Enabled = false;
            }
            else
            {
                if (txtDe.Text.Count() > 0)
                {
                    txtAutogenerado.Enabled = false;
                }
                else
                {
                    txtAutogenerado.Enabled = true;
                }
            }
            consultar(txtPara, lboxDestinatario, ref indiceDestinatario);
        }

        private void frmConsultaCorrespondecia_Resize(object sender, EventArgs e)
        {
            CargarComponente();
        }

        private void txtAutogenerado_TextChanged(object sender, EventArgs e)
        {
            if (txtAutogenerado.Text.Trim() != "")
            {
                txtPara.Enabled = false;
                txtDe.Enabled = false;
                dteDesde.Enabled = false;
                dteHasta.Enabled = false;
            }
            else
            {
                txtPara.Enabled = true;
                txtDe.Enabled = true;
                dteDesde.Enabled = true;
                dteHasta.Enabled = true;
            }
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void frmConsultaCorrespondecia_Activated(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            oM.subMostrarConsultas(true);
        }

        private void frmConsultaCorrespondecia_Deactivate(object sender, EventArgs e)
        {

        }

    }
}
