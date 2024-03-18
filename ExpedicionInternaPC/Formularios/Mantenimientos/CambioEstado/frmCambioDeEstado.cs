using ExpedicionInternaPC.Formularios.Expedicion;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmCambioDeEstado : frmChild
    {

        #region Variables
        public Objeto objetoACambiarEstado = new Objeto();
        #endregion 

        #region Métodos
        //2022
        private void manejarEventoBuscar(TextBox txtAutogenerado)
        {
            if (txtAutogenerado.Text.Length >= 6)
            {
                buscar(txtAutogenerado.Text);
            }
            else
            {
                Program.mensaje("Ingrese correctamente el autogenerado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                grdDato.DataSource = null;
                txtAutogenerado.SelectAll();
            }
        }
        //2022
        private void buscar(string autogenerado)
        {
            int respuesta;
            grdDato.DataSource = null;
            objetoACambiarEstado = new Objeto();
            try
            {
                objetoACambiarEstado = Metodos.ListarAutogeneradoCambioEstado(autogenerado, out respuesta);
                List<Objeto> autogenerados = new List<Objeto>();
                autogenerados.Clear();

                lblEstado.Text = "";
                lblCodigo.Text = "";

                switch (respuesta)
                {
                    case 1:

                        autogenerados.Add(objetoACambiarEstado);
                        lblCodigo.Text = string.Format("{0} : {1}", objetoACambiarEstado.TipoDocumento, objetoACambiarEstado.Autogenerado);
                        lblEstado.Text = objetoACambiarEstado.Estado;
                        grdDato.DataSource = autogenerados;
                        this.tileView.TileTemplate.ToList()[0].Text = string.Format("*{0}*", objetoACambiarEstado.Autogenerado);
                        break;
                    case -1:
                        Program.mensaje("No se puede cambiar el estado del autogenerado " + objetoACambiarEstado.Autogenerado
                            + ", se encuentra en estado RECIBIDO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;
                    case -2:
                        Program.mensaje("No se puede cambiar el estado del autogenerado " + objetoACambiarEstado.Autogenerado
                            + ", se encuentra en estado CREADO. La expedición responsable es " + objetoACambiarEstado.DescripcionExpedicionResponsable
                            + ".", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;
                    case -3:
                        Program.mensaje("No se puede cambiar el estado del autogenerado " + objetoACambiarEstado.Autogenerado
                            + ", se encuentra en estado CUSTODIA por " + objetoACambiarEstado.DescripcionExpedicionCustodia + ".", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;
                    case -4:
                        Program.mensaje("No se puede cambiar el estado del autogenerado " + objetoACambiarEstado.Autogenerado
                            + ", aún se encuentra en estado RUTA PISOS por " + objetoACambiarEstado.DescripcionExpedicionCustodia + ".", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;
                    case -5:
                        Program.mensaje("No se puede cambiar el estado del autogenerado " + objetoACambiarEstado.Autogenerado
                           + ", no corresponde a esta UTD.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;
                    case -6:
                        Program.mensaje("No se puede cambiar el estado del autogenerado " + objetoACambiarEstado.Autogenerado
                           + ", se encuentra en estado CONFIRMADO.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;
                    case -7:
                        Program.mensaje("No se puede cambiar el estado del autogenerado " + objetoACambiarEstado.Autogenerado
                           + ", se encuentra en estado RETIRADO.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;
                    case -8:
                        Program.mensaje("Ha ocurrido un error, inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;

                    case 0:
                        Program.mensaje("No se encontraron resultados, verifique el código ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;
                    default:
                        Program.mensaje("Ha ocurrido un error, inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        grdDato.DataSource = null;
                        txtAutogenerado.SelectAll();
                        break;

                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener el resultado.");
            }
        }
        //2022
        public void cambiarEstado(Objeto objetoACambiarEstado)
        {
            if (grdDato.DataSource != null)
            {
                frmNuevoEstado frm = new frmNuevoEstado();
                frm.CargarEstadosValidos(objetoACambiarEstado.IdTipoEstado);
                frm.objetoACambiarEstado = objetoACambiarEstado;
                frm.titulo = "Nuevo estado del autogenerado: " + objetoACambiarEstado.Autogenerado;
                frm.ShowDialog(this);
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    this.Close();
                }
            }
        }



        #endregion

        public frmCambioDeEstado()
        {
            InitializeComponent();
            txtAutogenerado.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void frmCambioDeEstado_Load(object sender, EventArgs e)
        {
            txtAutogenerado.SelectAll();
            grdDato.DataSource = null;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter && txtAutogenerado.Text.Length > 0)
            {
                manejarEventoBuscar(txtAutogenerado);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            manejarEventoBuscar(txtAutogenerado);
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            cambiarEstado(objetoACambiarEstado);
        }
    }
}
