using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmAgencia : frmChild
    {
        #region Variables

        private List<Agencia> ListaAgencias;
        private List<Agencia> ListaAgenciaSeleccionada = new List<Agencia>();

        #endregion

        #region Metodos

        private void CargarAgencias()
        {
            try
            {
                ListaAgencias = Metodos.ListarAgencias();
                grdAgencia.DataSource = ListaAgencias;
                ListaAgenciaSeleccionada = new List<Agencia>();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de agencias.");
                return;
            }
        }

        private void NuevaAgencia()
        {
            Agencia oAgencia = null;

            frmCrearModificarAgencia frm = new frmCrearModificarAgencia();
            frm.oAgencia = oAgencia;
            frm.iAccion = 1;
            frm.ShowDialog(this.Parent);
            if (frm.DialogResult == DialogResult.OK)
            {
                CargarAgencias();
            }

        }

        private void EditarAgencia()
        {
            if (ListaAgenciaSeleccionada.Count == 0)
            {
                Program.mensaje("Debe seleccionar una agencia de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Agencia oAgencia = ListaAgenciaSeleccionada[0];

            frmCrearModificarAgencia frm = new frmCrearModificarAgencia();
            frm.oAgencia = oAgencia;
            frm.iAccion = 2;
            frm.ShowDialog(this.Parent);
            if (frm.DialogResult == DialogResult.OK)
            {
                CargarAgencias();
            }
        }

        private void CambiarEstado()
        {
            if (ListaAgenciaSeleccionada.Count == 0)
            {
                Program.mensaje("Debe seleccionar una agencia de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Agencia oAgencia = ListaAgenciaSeleccionada[0];

            string mensaje;

            if (oAgencia.sActivo == "ACTIVO")
            {
                mensaje = $"¿Desea dar de baja a la agencia {oAgencia.sDescripcion.ToUpper()}?";
            }
            else
            {
                mensaje = $"¿Desea activar la agencia {oAgencia.sDescripcion.ToUpper()}?";
            }


            if (Program.mensaje(mensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            int resultado;

            try
            {
                resultado = Metodos.CambiarEstadoAgencia(oAgencia);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cambiar el estado de la agencia.");
                return;
            }

            if (resultado == 1)
            {
                Program.mensaje("Se modificó el estado de la agencia seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaAgenciaSeleccionada.RemoveAt(0);
                CargarAgencias();
            }
            else if (resultado == 2)
            {
                Program.mensaje("Los agencia ha sido eliminada del sistema.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListaAgenciaSeleccionada.RemoveAt(0);
                CargarAgencias();
            }
            else if (resultado == -4)
            {
                Program.mensaje("No se puede cambiar el estado de la agencia a INACTIVO. Existen bandejas activas vinculadas a esta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resultado == -3)
            {
                Program.mensaje("No se puede cambiar el estado de la agencia a INACTIVO. Existen autogenerados creados en esta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resultado == -2)
            {
                Program.mensaje("No se puede cambiar el estado de la agencia a INACTIVO. Existen autogenerados activos dirigidos a esta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Program.mensaje("Error de conexión. Vuelva a intentarlo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


        public frmAgencia()
        {
            InitializeComponent();
        }

        private void frmAgencia_Load(object sender, EventArgs e)
        {
            CargarAgencias();
        }

        private void frmAgencia_Activated(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            if (oM == null) return;
            if (Program.oUsuario.IdTipoAcceso == 43) oM.subMostrarSupervision(true);
            if (Program.oUsuario.IdTipoAcceso == 80) oM.subMostrarJefatura(true);
        }

        private void frmAgencia_Deactivate(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            if (oM == null) return;
            if (Program.oUsuario.IdTipoAcceso == 43) oM.subMostrarSupervision(false);
            if (Program.oUsuario.IdTipoAcceso == 80) oM.subMostrarJefatura(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaAgencia();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            EditarAgencia();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CambiarEstado();
        }

        private void grvAgencia_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            try
            {
                if (grvAgencia.FocusedColumn.FieldName != "SeleccionGrafica") return;

                Agencia oAgenciaSeleccionada = new Agencia();
                oAgenciaSeleccionada = ListaAgencias.Find(x => x.iId == ((Agencia)grvAgencia.GetFocusedRow()).iId);

                if (ListaAgenciaSeleccionada.Count > 0)
                {
                    if (ListaAgenciaSeleccionada[0].iId == oAgenciaSeleccionada.iId)
                    {
                        ListaAgencias.Find(x => x.iId == ((Agencia)grvAgencia.GetFocusedRow()).iId).SeleccionGrafica = false;
                        ListaAgenciaSeleccionada.RemoveAt(0);
                    }
                    else
                    {
                        ListaAgencias.Find(x => x.iId == ListaAgenciaSeleccionada[0].iId).SeleccionGrafica = false;
                        ListaAgencias.Find(x => x.iId == ((Agencia)grvAgencia.GetFocusedRow()).iId).SeleccionGrafica = true;
                        ListaAgenciaSeleccionada.RemoveAt(0);
                        ListaAgenciaSeleccionada.Add(oAgenciaSeleccionada);
                    }
                }
                else
                {
                    ListaAgencias.Find(x => x.iId == ((Agencia)grvAgencia.GetFocusedRow()).iId).SeleccionGrafica = true;
                    ListaAgenciaSeleccionada.Add(oAgenciaSeleccionada);
                }

                grdAgencia.RefreshDataSource();
            }
            catch
            {
                return;
            }
        }

    }
}
