using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmListaBandeja : frmChild
    {

        #region Variables
        private List<Casilla> ListadoBandejas;
        private List<Casilla> ListaBandejasSeleccionadas = new List<Casilla>();
        #endregion

        #region Metodos
        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            ListarBandejas();
        }
        //2022
        private void ListarBandejas()
        {
            try
            {
                ListadoBandejas = Metodos.ListarBandeja();
                grdBandeja.DataSource = ListadoBandejas;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener la lista de bandejas.");
            }

        }
        //2022
        private void NuevaBandejaGenerica()
        {
            frmCrearModificarBandeja frm = new frmCrearModificarBandeja();

            if (frm.ShowDialog(this.Parent) == DialogResult.OK)
            {
                ListarBandejas();
            }

        }
        //2022
        private void ModificarBandeja()
        {
            if (ListaBandejasSeleccionadas.Count == 0)
            {
                Program.mensaje("Debe seleccionar un registro para modificar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmCrearModificarBandeja frm = new frmCrearModificarBandeja();
            Casilla oCasilla = (Casilla)grvBandeja.GetFocusedRow();

            frm.oCasilla = oCasilla;
            if (frm.ShowDialog(this.Parent) == System.Windows.Forms.DialogResult.OK)
            {
                ListaBandejasSeleccionadas = new List<Casilla>();
                ListarBandejas();
            }
        }
        //2022
        private void CambiarEstado()
        {
            if (ListaBandejasSeleccionadas.Count == 0)
            {
                Program.mensaje("Debe seleccionar un registro para modificar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Casilla _casilla = ListaBandejasSeleccionadas[0];

            if (_casilla.IdTipoCasilla != 4)
            {
                Program.mensaje("Sólo puede cambiar de estado a bandejas de tipo GENÉRICA.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string mensaje = "";

            if (_casilla.iActivo == 1)
            {
                mensaje = string.Format("¿Desea dar de baja a la bandeja genérica {0}?", _casilla.sDescripcion.ToUpper());
            }
            else
            {
                mensaje = string.Format("¿Desea activar la bandeja genérica {0}?", _casilla.sDescripcion.ToUpper());
            }

            if (Program.mensaje(mensaje, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            _casilla.iActivo = 1 - _casilla.iActivo;
            try
            {
                int resultado = Metodos.CambiarEstadoBandeja(_casilla);

                if (resultado == 1)
                {
                    Program.mensaje("Se modificó el estado de la bandeja seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListaBandejasSeleccionadas.RemoveAt(0);
                    ListarBandejas();
                }
                else if (resultado == -2)
                {
                    Program.mensaje("No se pudo completar la acción. Bandeja no existe.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado == -1)
                {
                    Program.mensaje("Ha ocurrido un error. No se puede completar la acción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cambiar el estado de la bandeja.");
            }

        }
        //2022
        private void VincularBandejaUsuarios()
        {
            if (ListaBandejasSeleccionadas.Count == 0)
            {
                Program.mensaje("Debe seleccionar una bandeja para vincular usuarios.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ListaBandejasSeleccionadas[0].iActivo == 0)
            {
                Program.mensaje("No puede vincular usuarios a una bandeja inactiva.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmBandejaUsuario frm = new frmBandejaUsuario();
            Casilla oCasilla = (Casilla)grvBandeja.GetFocusedRow();

            frm.oCasilla = oCasilla;
            frm.CargarInformacionBandeja();
            frm.ShowDialog(this.Parent);
            ListaBandejasSeleccionadas.RemoveAt(0);
            ListarBandejas();

        }

        #endregion

        public frmListaBandeja()
        {
            InitializeComponent();
        }

        private void frmListaBandeja_Load(object sender, EventArgs e)
        {
            ListarBandejas();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaBandejaGenerica();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ModificarBandeja();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CambiarEstado();
        }

        private void btnVincular_Click(object sender, EventArgs e)
        {
            VincularBandejaUsuarios();
        }


        private void frmListaBandeja_Activated(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            if (Program.oUsuario.IdTipoAcceso == 43) frmPadre.subMostrarSupervision(true);
            if (Program.oUsuario.IdTipoAcceso == 80) frmPadre.subMostrarJefatura(true);
        }

        private void frmListaBandeja_Deactivate(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            if (Program.oUsuario.IdTipoAcceso == 43) frmPadre.subMostrarSupervision(false);
            if (Program.oUsuario.IdTipoAcceso == 80) frmPadre.subMostrarJefatura(false);
        }

        private void grvBandeja_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (grvBandeja.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;

                }

                Casilla obj = (Casilla)grvBandeja.GetFocusedRow();

                if (obj != null)
                {
                    if (ListaBandejasSeleccionadas.Count == 0)
                    {
                        obj.SeleccionGrafica = true;
                        ListaBandejasSeleccionadas.Add(obj);
                        grdBandeja.Refresh();
                        grvBandeja.RefreshData();

                    }
                    else
                    {
                        ListadoBandejas.Find(hol => hol.ID == ListaBandejasSeleccionadas[0].ID).SeleccionGrafica = false;

                        if (obj.ID == ListaBandejasSeleccionadas[0].ID)
                        {
                            ListaBandejasSeleccionadas.Clear();
                        }
                        else
                        {
                            ListaBandejasSeleccionadas.Clear();
                            obj.SeleccionGrafica = true;
                            ListaBandejasSeleccionadas.Add(obj);
                        }

                        grdBandeja.Refresh();
                        grvBandeja.RefreshData();
                    }

                }
            }
            catch
            {
                return;
            }
        }
    }
}
