using DevExpress.XtraTab;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmCrearTurno : Form
    {
        #region Variables
        List<Agencia> listaAgencia = new List<Agencia>();
        List<Agencia> listaAgenciaBase = new List<Agencia>();
        List<Agencia> listaAgenciaSeleccionados = new List<Agencia>();
        #endregion

        #region Constructor

        public frmCrearTurno()
        {
            InitializeComponent();
        }

        #endregion

        #region Eventos

        private void frmCrearTurno_Load(object sender, EventArgs e)
        {
            CargarAgencias();
            CargarTurnos();
        }

        private void CargarTurnos()
        {
            try
            {
                List<Turno> listarTurno = Metodos.ListarTurnos();
                lueTurno.Properties.DataSource = listarTurno;
                lueTurno.Properties.DisplayMember = "sDescripcion";
                lueTurno.Properties.ValueMember = "iId";
                lueTurno.Properties.ShowFooter = false;
                lueTurno.Properties.ShowHeader = false;
                lueTurno.Properties.DropDownRows = listarTurno.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de turnos.");
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            registrarTurno();
        }

        #endregion

        #region Metodos

        private void registrarTurno()
        {
            if (String.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                Program.mensaje(String.Format("Por favor ingrese una descripción del turno."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Turno turn = new Turno();
            turn.sDescripcionTurno = txtDescripcion.Text;
            turn.listaAgencias = turn.SerializeObjectWindows(turn.AgenciasAsociadas);
            try
            {
                Turno res = Metodos.CrearTurno(turn);
                if (res.iIdTurno != -1)
                {
                    Program.mensaje(String.Format("Sé registró correctamente el turno Nro : {0}", turn.iIdTurno), MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    Program.mensaje(String.Format("Hay conflictos en la base de datos, por favor comuniquese con él administrador del sistema"), MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                Resetear();
                CargarAgencias();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar crear el turno.");
            }

        }

        private void DoubleClickAgregarAgencia(object sender, EventArgs e)
        {
            Agencia oO = (Agencia)gridView3.GetFocusedRow();
            Agencia obj = (Agencia)listaAgenciaSeleccionados.Find(hol => hol.iId == oO.iId);
            if (obj == null)
            {
                if (listaAgenciaBase.Find(hol => hol.iId == oO.iId) != null)
                {
                    oO.Base = 1;
                }
                listaAgenciaSeleccionados.Add(oO);
                listaAgencia.Find(hol => hol.iId == oO.iId).SeleccionGrafica = true;
                actualizarGrillas();
            }
            else
            {
                Program.mensaje(string.Format("El palomar ya se encuentra seleccionado"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void DoubleClickQuitarAgenciaEscogida(object sender, EventArgs e)
        {
            Agencia oO = (Agencia)gridView2.GetFocusedRow();
            Agencia obj = (Agencia)listaAgencia.Find(hol => hol.iId == oO.iId);

            if (obj != null)
            {
                obj.SeleccionGrafica = false;
                listaAgenciaSeleccionados.Remove(oO);
            }
            else
            {
                listaAgenciaSeleccionados.Remove(oO);
            }
            actualizarGrillas();
        }

        private void CargarAgencias()
        {
            try
            {
                listaAgencia = Metodos.ObtenerListadoAgencia();
                grdAgencia.DataSource = listaAgencia;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de agencias.");
            }

        }

        private void obtenerAgenciasAsociados()
        {
            try
            {
                listaAgenciaSeleccionados = Metodos.ListarAgenciasPorTurno(new Turno() { iIdTurno = (Int16)lueTurno.EditValue });
                listaAgenciaSeleccionados.ForEach(hol => listaAgenciaBase.Add(hol));
                grdAgenciaEscogidas.DataSource = listaAgenciaSeleccionados;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }

        }

        private void obtenerAgenciasAsociadosActualizar()
        {
            try
            {
                listaAgenciaSeleccionados = Metodos.ListarAgenciasPorTurno(new Turno() { iIdTurno = (Int16)lueTurno.EditValue });
                listaAgenciaSeleccionados.ForEach(hol => listaAgenciaBase.Add(hol));
                grdAgenciaEscogidaActua.DataSource = listaAgenciaSeleccionados;
            }
            catch (InvalidTokenException)
            {

                Program.mensajeTokenInvalido();
            }

        }
        //2022
        private void Resetear()
        {
            txtDescripcion.Text = String.Empty;
            lueTurno.Properties.DataSource = false;
            grdAgencia.DataSource = null;
            grdAgenciaActua.DataSource = null;
            grdAgenciaEscogidaActua.DataSource = null;
            grdAgenciaEscogidas.DataSource = null;
            listaAgencia.Clear();
            if (listaAgenciaBase != null) listaAgenciaBase.Clear();
            if (listaAgenciaSeleccionados != null) listaAgenciaSeleccionados.Clear();
        }
        //2022
        private void actualizarGrillas()
        {
            grdAgencia.DataSource = null;
            grdAgenciaEscogidas.DataSource = null;
            grdAgenciaEscogidas.DataSource = listaAgenciaSeleccionados;
            grdAgencia.DataSource = listaAgencia.Where(hol => hol.SeleccionGrafica == false).ToList();
        }

        #endregion

        private void btnIntroducirTodos_Click(object sender, EventArgs e)
        {
            listaAgencia.Where(hol => hol.SeleccionGrafica == false).ToList().ForEach(h =>
            {
                if (listaAgenciaBase.Find(hol => hol.iId == h.iId) != null)
                {
                    h.Base = 1;
                }
                listaAgenciaSeleccionados.Add(h);
            });
            listaAgencia.ForEach(hol => hol.SeleccionGrafica = true);
            actualizarGrillas();
        }

        private void btnExtraerTodos_Click(object sender, EventArgs e)
        {
            listaAgenciaSeleccionados.ForEach(hol =>
            {
                Agencia pa = listaAgencia.Find(h => h.iId == hol.iId);
                if (pa != null)
                {
                    pa.SeleccionGrafica = false;
                }
            });
            listaAgenciaSeleccionados.Clear();
            actualizarGrillas();
        }

        private void lueTurno_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {

        }

        private void xtraTabConfiguracionTurno_SelectedPageChanging(object sender, DevExpress.XtraTab.TabPageChangingEventArgs e)
        {


        }

        private void xtraTabConfiguracionTurno_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            XtraTabPage obj = xtraTabConfiguracionTurno.SelectedTabPage;
            Resetear();
            if (obj.Text == "Registrar")
            {
                CargarAgencias();
            }
            /*Actualizar*/
            else
            {
                CargarTurnos();
            }
        }

        private void lueTurno_EditValueChanged(object sender, EventArgs e)
        {
            obtenerAgenciasAsociadosActualizar();
        }




    }
}
