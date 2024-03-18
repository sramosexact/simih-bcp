using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Expedicion
{
    public partial class frmNuevoEstado : frmChild
    {
        #region Variables
        public Objeto objetoACambiarEstado { get; set; }
        List<Estado> estadosValidos = new List<Estado>();
        public string titulo { get; set; }
        List<MotivoCambioEstado> motivosCambioEstado = new List<MotivoCambioEstado>();
        #endregion

        #region Métodos
        //2022
        public void CargarEstadosValidos(int idTipoEstado)
        {
            try
            {
                estadosValidos = Metodos.cargarEstadosValidos(idTipoEstado);
                lueEstado.Properties.DataSource = estadosValidos;
                lueEstado.Properties.DisplayMember = "estado";
                lueEstado.Properties.ValueMember = "IdEstado";
                lueEstado.Properties.DropDownRows = estadosValidos.Count;
                lueEstado.EditValue = null;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los estados válidos.");
            }

        }
        //2022
        public void ManejarEventoCambiarEstado()
        {

            if (lueEstado.EditValue == null)
            {
                Program.mensaje("Elija el nuevo estado del elemento.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (lueMotivoCambioEstado.EditValue == null && lueMotivoCambioEstado.Visible)
            {
                Program.mensaje("Elija el nuevo estado del elemento.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            Estado estado = (Estado)lueEstado.GetSelectedDataRow();


            if (mObservacion.Text.Trim().Length == 0 && estado.IdEstado != 6)
            {
                Program.mensaje("Debe ingresar alguna observación.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (Program.mensaje("Se cambiará el estado del elemento. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                CambiarEstado();
            }
        }
        //2022
        public void CambiarEstado()
        {
            byte iIdMotivoCambioEstado = lueMotivoCambioEstado.EditValue == null ? (byte)0 : Convert.ToByte(lueMotivoCambioEstado.EditValue);

            try
            {
                int respuesta = Metodos.cambiarEstadoAutogenerado(objetoACambiarEstado.ID, objetoACambiarEstado.IdTipoEstado,
                    Convert.ToInt32(lueEstado.EditValue), mObservacion.Text.Trim(), iIdMotivoCambioEstado);
                switch (respuesta)
                {
                    case 1:
                        Program.mensaje("El cambio de estado se realizó con éxito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case -1:
                        Program.mensaje("Ha surgido un problema. Inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        break;
                    case -2:
                        Program.mensaje("No existe el elemento. Verifique el código ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        break;
                    case -3:
                        Program.mensaje("El estado no concuerda con el de la base datos.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        break;
                    case -4:
                        Program.mensaje("El nuevo estado elegido no está permitido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        break;
                    case -5:
                        Program.mensaje("No está permitido cambiar el estado del elemento.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cambiar el estado del autogenerado.");
            }
        }
        //2022
        public void MostrarLueMotivo(int iIdTipoEstado)
        {

            lblMotivo.Visible = true;
            lueMotivoCambioEstado.Visible = true;
            labelControl2.Visible = false;
            mObservacion.Visible = false;
            try
            {
                motivosCambioEstado = Metodos.ListarMotivoCambioEstadoPorTipoEstado(iIdTipoEstado);
                lueMotivoCambioEstado.Properties.DataSource = motivosCambioEstado;
                lueMotivoCambioEstado.Properties.DisplayMember = "sDescripcion";
                lueMotivoCambioEstado.Properties.ValueMember = "iIdMotivoCambioEstado";
                lueMotivoCambioEstado.Properties.DropDownRows = motivosCambioEstado.Count;
                lueMotivoCambioEstado.EditValue = null;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar listar los motivos de cambio de estado del autogenerado.");
            }

        }

        #endregion

        #region Eventos 

        public frmNuevoEstado()
        {
            InitializeComponent();
        }

        private void frmNuevoEstado_Load(object sender, EventArgs e)
        {
            this.Text = this.titulo;
            labelControl2.Visible = false;
            mObservacion.Visible = false;
        }

        #endregion

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            ManejarEventoCambiarEstado();
        }

        private void lueEstado_EditValueChanged(object sender, EventArgs e)
        {
            Estado estado = (Estado)lueEstado.GetSelectedDataRow();
            if (estado.IdEstado == 6)
            {
                MostrarLueMotivo(estado.IdEstado);
            }
            else
            {
                lblMotivo.Visible = false;
                lueMotivoCambioEstado.Visible = false;
                labelControl2.Visible = true;
                mObservacion.Visible = true;
            }
        }
    }
}
