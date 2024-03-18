using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public partial class frmBandejaPorGeo : frmChild
    {
        private Geo puntoEntrega;

        public frmBandejaPorGeo(Geo puntoEntrega)
        {
            this.puntoEntrega = puntoEntrega;
            InitializeComponent();
        }

        private void cargarBandejas()
        {
            lblPuntoEntrega.Text = $"Punto de entrega: {puntoEntrega.Oficina} | {puntoEntrega.Descripcion}";
            try
            {
                List<Bandeja> bandejaList = Metodos.ListarBandejasPorGeo(this.puntoEntrega.ID);
                grdBandejas.DataSource = bandejaList;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener las bandejas.");
                return;
            }

        }

        private void frmBandejaPorGeo_Load(object sender, EventArgs e)
        {
            cargarBandejas();
        }
    }
}
