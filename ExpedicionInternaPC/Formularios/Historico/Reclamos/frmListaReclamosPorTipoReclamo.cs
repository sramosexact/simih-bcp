using Interna.Entity;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC.Formularios.Reclamos
{
    public partial class frmListaReclamosPorTipoReclamo : frmChild
    {

        #region Propiedades

        List<ListaReclamoView> listaReclamos = new List<ListaReclamoView>();

        public byte iIdTipoReclamoUTD { get; set; }
        public byte iIdExpedicion { get; set; }
        public DateTime dFecha { get; set; }
        public int iCantidadFundado { get; set; }

        #endregion

        #region Metodos

        private void ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion()
        {
            Reclamo reclamo = new Reclamo();
            reclamo.iIdTipoReclamoUTD = iIdTipoReclamoUTD;
            reclamo.FechaRegistroJson = dFecha.ToShortDateString();

            try
            {
                listaReclamos = Metodos.ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion(reclamo, iIdExpedicion);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            grdReclamos.DataSource = listaReclamos;
            grdReclamos.RefreshDataSource();
        }

        #endregion

        public frmListaReclamosPorTipoReclamo()
        {
            InitializeComponent();
        }

        private void frmListaReclamosPorTipoReclamo_Load(object sender, EventArgs e)
        {
            ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion();
        }

        private void linkCodigoReclamo_Click(object sender, EventArgs e)
        {
            ListaReclamoView reclamoSeleccionado = (ListaReclamoView)grvReclamos.GetFocusedRow();
            frmVerficacion frm = new frmVerficacion();
            frm.iIdReclamo = reclamoSeleccionado.iIdReclamo;
            frm.iCantidadFundado = iCantidadFundado;
            frm.ShowDialog(this.Parent);
            ListarReclamosSolucionadosPorTipoReclamoUTDYExpedicion();
        }
    }
}
