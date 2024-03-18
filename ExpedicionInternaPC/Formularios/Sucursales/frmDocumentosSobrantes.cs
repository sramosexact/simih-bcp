using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Expedicion
{
    public partial class frmDocumentosSobrantes : frmChild
    {
        #region Variables

        List<Objeto> resultado = null;

        #endregion

        #region Metodos

        //2022
        private void buscaAutogenerado()
        {
            if (txtAutogenerado.Text.Trim().Length >= 6)
            {
                String autogenerado = txtAutogenerado.Text.Trim();
                CargarDatos(autogenerado);
            }
            else
            {
                Program.mensaje("No se encontraron resultados. Verifique código ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutogenerado.SelectionStart = 0;
                txtAutogenerado.SelectionLength = txtAutogenerado.Text.Length;
                txtAutogenerado.Focus();
                return;
            }
        }
        //2022
        private void CargarDatos(string autogenerado)
        {
            LimpiarDatos();
            try
            {
                resultado = Metodos.rObtenerSobrantes(autogenerado);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener los datos del autogenerado.");
                return;
            }

            if (resultado != null)
            {
                if (resultado.Count > 0)
                {
                    grdDato.DataSource = resultado;
                    this.tileView.TileTemplate.ToList()[0].Text = "*" + resultado[0].Autogenerado + "*";
                }
                else
                {
                    EvaluarEstado(autogenerado);
                }
            }
            else
            {
                EvaluarEstado(autogenerado);
            }
        }
        //2022
        private void LimpiarDatos()
        {
            grdDato.DataSource = null;
        }
        //2022
        private void EvaluarEstado(String autogenerado)
        {
            List<Objeto> listaObjetoEstado = new List<Objeto>();

            try
            {
                listaObjetoEstado = Metodos.ValidarEstadoSobrante(autogenerado);
                if (listaObjetoEstado == null)
                {
                    Program.mensaje(string.Format("No se encontraron resultados. Verifique código ingresado"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAutogenerado.SelectionStart = 0;
                    txtAutogenerado.SelectionLength = txtAutogenerado.Text.Length;
                    txtAutogenerado.Focus();
                    return;
                }
                if (listaObjetoEstado.Count == 0)
                {
                    Program.mensaje(string.Format("No se encontraron resultados. Verifique código ingresado"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAutogenerado.SelectionStart = 0;
                    txtAutogenerado.SelectionLength = txtAutogenerado.Text.Length;
                    txtAutogenerado.Focus();
                    return;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar evaluar el estado del autogenerado.");
                return;
            }


            Objeto obj = listaObjetoEstado[0];
            if (obj != null)
            {
                if (obj.IdTipoEstado == 1)
                {
                    Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1}, la expedicion responsable es : {2}.", obj.Autogenerado, obj.Estado.ToLower(), obj.DescripcionExpedicionResponsable), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAutogenerado.SelectionStart = 0;
                    txtAutogenerado.SelectionLength = txtAutogenerado.Text.Length;
                    txtAutogenerado.Focus();
                    return;
                }
                else
                {
                    if (obj.IdTipoEstado == 2)
                    {
                        Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por la expedicion : {2}.", obj.Autogenerado, obj.Estado.ToLower(), obj.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAutogenerado.SelectionStart = 0;
                        txtAutogenerado.SelectionLength = txtAutogenerado.Text.Length;
                        txtAutogenerado.Focus();
                        return;
                    }

                    else if (obj.IdTipoEstado == 3)
                    {
                        Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por la expedicion : {2}.", obj.Autogenerado, obj.Estado.ToLower(), obj.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAutogenerado.SelectionStart = 0;
                        txtAutogenerado.SelectionLength = txtAutogenerado.Text.Length;
                        txtAutogenerado.Focus();
                        return;
                    }
                    else
                    {
                        Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por {2} que se encuentra en : {3}.", obj.Autogenerado, obj.Estado.ToLower(), obj.CasillaPara, obj.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAutogenerado.SelectionStart = 0;
                        txtAutogenerado.SelectionLength = txtAutogenerado.Text.Length;
                        txtAutogenerado.Focus();
                        return;
                    }
                }
            }


        }
        //2022
        private void custodiarCorrespondencia()
        {
            Objeto oO = resultado[0];
            int salida = 0;

            try
            {
                salida = Metodos.uRegularizarObjetoSobrante(oO);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar custodiar el autogenerado.");
                return;
            }

            if (salida == 1)
            {
                Program.mensaje("El autogenerado " + oO.Autogenerado + " ha sido Custodiado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
                txtAutogenerado.Text = "";
            }
            else if (salida == -2)
            {
                Program.mensaje("El autogenerado " + oO.Autogenerado + " ha sido Custodiado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarDatos();
                txtAutogenerado.Text = "";
            }
            else if (salida == -3)
            {
                Program.mensaje("No se ha podido realizar la custodia del elemento, verifique su estado actual.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarDatos();
                txtAutogenerado.Text = "";
            }
            else
            {
                Program.mensaje("No se ha podido realizar el cambio de esta correspondencia, porfavor verifique su conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LimpiarDatos();
                txtAutogenerado.Text = "";
            }
        }

        #endregion


        public frmDocumentosSobrantes()
        {
            InitializeComponent();
            txtAutogenerado.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscaAutogenerado();
        }

        private void btnCustodiar_Click(object sender, EventArgs e)
        {
            if (resultado != null && resultado.Count > 0)
            {
                custodiarCorrespondencia();
            }
        }

        private void tileView_DoubleClick(object sender, EventArgs e)
        {
            Objeto oO = (Objeto)tileView.GetFocusedRow();
            oO.IdTipoEntrega = 1;
            Metodos.VerTracking(oO);
        }

        private void frmDocumentosSobrantes_Load(object sender, EventArgs e)
        {
            txtAutogenerado.Select();
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                buscaAutogenerado();
            }
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
