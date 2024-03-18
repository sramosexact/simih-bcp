using Interna.Entity.Estructuras;
using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmPrimeraRespuesta : frmChild
    {
        #region Propiedades

        public int iIdReclamo { get; set; }
        public ListaReclamoView reclamoView { get; set; }

        #endregion

        #region Metodos

        public void CargarDetalleReclamo()
        {
            try
            {
                reclamoView = Metodos.ListarDetalleReclamo(iIdReclamo);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            lblFecha.Text = reclamoView.dFechaRegistro.ToShortDateString();
            lblUsuario.Text = reclamoView.sUsuarioCliente;
            lblArea.Text = reclamoView.sArea;
            lblDetalle.Text = reclamoView.sDetalle;
            lblTipo.Text = reclamoView.sTipoReclamoUsuario;
            lblDocReferencia.Text = reclamoView.sDocReferencia;
        }

        public void RegistrarPrimeraRespuesta()
        {

            int respuesta = 0;

            try
            {
                respuesta = Metodos.RegistrarPrimeraRespuesta(iIdReclamo, Program.oUsuario.ID);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }


            if (respuesta == 1)
            {
                Program.mensaje("Se ha registrado la primera respuesta correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                Program.mensaje("Ha ocurrido un error, inténtelo nuevamente más tarde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarDetalleReclamo();
            }
        }

        private void Cancelar()
        {
            this.Close();
        }

        #endregion


        public frmPrimeraRespuesta()
        {
            InitializeComponent();
        }

        private void btnPrimeraRespuesta_Click(object sender, EventArgs e)
        {
            RegistrarPrimeraRespuesta();
        }

        private void frmPrimeraRespuesta_Load(object sender, EventArgs e)
        {
            CargarDetalleReclamo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
    }
}
