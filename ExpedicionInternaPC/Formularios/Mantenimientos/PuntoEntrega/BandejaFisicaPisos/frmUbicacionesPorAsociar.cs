using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Mantenimientos.PuntoEntrega.BandejaFisicaPisos
{
    public partial class frmUbicacionesPorAsociar : frmChild
    {
        #region "Variables"

        int idBandejaFisica;
        private List<Ubicacion> ubicacionesNoAsociadas;
        private List<Ubicacion> ubicacionesAsociadas;

        #endregion

        #region "Metodos"

        private void cargarUbicaciones()
        {
            grdUbicacionesAsociadas.DataSource = null;
            grdUbicacionesPorAsociar.DataSource = null;
            grdUbicacionesAsociadas.DataSource = ubicacionesAsociadas;
            grdUbicacionesPorAsociar.DataSource = ubicacionesNoAsociadas;
        }

        private bool asociarUbicacion(Ubicacion ubicacionPorAsociar)
        {
            int resultado = Metodos.AsociarUbicacionABandejaFisica(ubicacionPorAsociar.idUbicacion, idBandejaFisica);

            if (resultado == 1)
            {
                ubicacionesNoAsociadas.Remove(ubicacionPorAsociar);
                ubicacionesAsociadas.Add(ubicacionPorAsociar);
                return true;
            }
            return false;

        }

        private bool quitarAsociacionUbicacion(Ubicacion ubicacionAsociada)
        {
            int resultado = Metodos.DesasociarUbicacionDeBandejaFisica(ubicacionAsociada.idUbicacion, idBandejaFisica);

            if (resultado == 1)
            {
                ubicacionesAsociadas.Remove(ubicacionAsociada);
                ubicacionesNoAsociadas.Add(ubicacionAsociada);
                return true;
            }
            return false;
        }

        #endregion

        public frmUbicacionesPorAsociar(BandejaFisica bandejaFisica, List<Ubicacion> ubicacionesNoAsociadas, List<Ubicacion> ubicacionesAsociadas)
        {
            idBandejaFisica = bandejaFisica.idBandejaFisica;
            this.ubicacionesNoAsociadas = ubicacionesNoAsociadas;
            this.ubicacionesAsociadas = ubicacionesAsociadas;
            InitializeComponent();
        }

        private void frmUbicacionesPorAsociar_Load(object sender, EventArgs e)
        {
            cargarUbicaciones();
        }

        private void linkAsociar_Click(object sender, EventArgs e)
        {
            Ubicacion ubicacionPorAsociar = (Ubicacion)grvUbicacionesPorAsociar.GetFocusedRow();
            if (asociarUbicacion(ubicacionPorAsociar)) cargarUbicaciones();
        }

        private void linkDesasociar_Click(object sender, EventArgs e)
        {
            Ubicacion ubicacionPorDesasociar = (Ubicacion)grvUbicacionesAsociadas.GetFocusedRow();
            if (quitarAsociacionUbicacion(ubicacionPorDesasociar)) cargarUbicaciones();
        }

        private void frmUbicacionesPorAsociar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
