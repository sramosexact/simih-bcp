using Interna.Entity;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmListaReclamos : frmChild
    {

        #region Propiedades

        List<ListaReclamoView> reclamos = new List<ListaReclamoView>();

        #endregion

        #region Metodos

        public void ListarReclamosPorExpedicion()
        {

            try
            {
                reclamos = Metodos.ListarReclamoPorExpedicion(Program.oUsuario.IdExpedicion);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            reclamos = reclamos.FindAll(x => x.iIdEstadoReclamo == 1 || x.iIdEstadoReclamo == 2 || x.iIdEstadoReclamo == 3);
            grdReclamos.DataSource = reclamos;
            grdReclamos.RefreshDataSource();

        }

        public void cargarReclamoPrimeraRespuestaView(int iIdReclamo)
        {
            frmPrimeraRespuesta frm = new frmPrimeraRespuesta();
            frm.iIdReclamo = iIdReclamo;
            frm.ShowDialog(this.Parent);
            ListarReclamosPorExpedicion();

        }

        public void cargarReclamoSolucionView(int iIdReclamo)
        {
            frmSolucion frm = new frmSolucion();
            frm.iIdReclamo = iIdReclamo;
            frm.ShowDialog(this.Parent);
            ListarReclamosPorExpedicion();
        }

        public void cargarReclamoVerificacionView(int iIdReclamo)
        {
            frmVerficacion frm = new frmVerficacion();
            frm.iIdReclamo = iIdReclamo;
            frm.ShowDialog(this.Parent);
            ListarReclamosPorExpedicion();
        }

        public void cargarReclamoView()
        {

            ListaReclamoView reclamoSeleccionado = (ListaReclamoView)grvReclamos.GetFocusedRow();

            switch (reclamoSeleccionado.iIdEstadoReclamo)
            {
                case 1:
                    cargarReclamoPrimeraRespuestaView(reclamoSeleccionado.iIdReclamo);
                    break;

                case 2:
                    cargarReclamoSolucionView(reclamoSeleccionado.iIdReclamo);
                    break;
                case 3:
                    if (reclamoSeleccionado.iCorreccion == 1)
                    {
                        cargarReclamoSolucionView(reclamoSeleccionado.iIdReclamo);
                    }
                    break;
                case 4:

                    break;
                default:
                    break;
            }
        }

        private void MarcarReclamoPorCorregir()
        {
            ListaReclamoView reclamoSeleccionado = (ListaReclamoView)grvReclamos.GetFocusedRow();
            if (reclamoSeleccionado.sNecesitaCorreccion == "NO" && reclamoSeleccionado.iIdEstadoReclamo == 3)
            {
                if (Program.mensaje("¿Está seguro de que desea marcar el reclamo como por corregir?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    Reclamo reclamo = new Reclamo();
                    reclamo.iIdReclamo = reclamoSeleccionado.iIdReclamo;

                    int respuesta = 0;

                    try
                    {
                        respuesta = Metodos.MarcarReclamoPorCorregir(reclamo);
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }

                    if (respuesta == 1)
                    {
                        Program.mensaje("Se ha marcado el reclamo como por corregir.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ListarReclamosPorExpedicion();
                    }
                    else
                    {
                        Program.mensaje("Ha ocurrido un error. Inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarReclamosPorExpedicion();
                    }
                }
            }
        }



        #endregion

        public frmListaReclamos()
        {
            InitializeComponent();
        }

        private void frmListaReclamos_Load(object sender, EventArgs e)
        {
            ListarReclamosPorExpedicion();
        }

        private void linkCodigoReclamo_Click(object sender, EventArgs e)
        {
            cargarReclamoView();
        }

        private void linkReclamo_Click(object sender, EventArgs e)
        {
            MarcarReclamoPorCorregir();
        }
    }
}
