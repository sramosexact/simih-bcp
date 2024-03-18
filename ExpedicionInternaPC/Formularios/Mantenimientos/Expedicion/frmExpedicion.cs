using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmExpedicion : frmChild
    {

        #region Variables
        List<Expedicion> ListaExpediciones = new List<Expedicion>();
        private List<Expedicion> ListaExpedicionesSeleccionada = new List<Expedicion>();
        #endregion


        #region Metodos
        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            ListarExpedicion();
        }
        //2022
        public override void ExportExcel(string FileName)
        {
            grvExpedicion.ExportToXlsx(FileName);
        }
        //2022
        private void ListarExpedicion()
        {
            try
            {
                ListaExpediciones = Metodos.ListarExpedicionesListaJson();
                grdExpedicion.DataSource = ListaExpediciones;
                ListaExpedicionesSeleccionada = new List<Expedicion>();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener la lista de Expediciones.");
            }

        }
        //2022
        private void NuevaExpedicion()
        {
            frmExpedicionNuevo fx = new frmExpedicionNuevo();
            fx.ShowDialog(this.Parent);
            DialogResult resultado = fx.DialogResult;
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                ListarExpedicion();
            }
        }
        //2022
        private void ModificarExpedicion()
        {
            if (ListaExpedicionesSeleccionada.Count == 0)
            {
                Program.mensaje("Debe seleccionar una expedición de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Expedicion oExpedicion = ListaExpedicionesSeleccionada[0];
            frmExpedicionNuevo fx = new frmExpedicionNuevo();
            fx.oExpedicion = oExpedicion;
            fx.ShowDialog(this.Parent);
            DialogResult resultado = fx.DialogResult;
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                ListarExpedicion();

            }
        }
        //2022
        private void EliminarExpedicion(Expedicion oExpedicion)
        {

            if (Program.mensaje(string.Format("¿Desea dar de baja a la expedición {0}?", oExpedicion.Descripcion), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int resultado = Metodos.EliminarExpedicion(oExpedicion);

                    if (resultado == 1)
                    {
                        Program.mensaje(string.Format("Se eliminó la expedición {0} correctamente.", oExpedicion.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarExpedicion();
                    }
                    else if (resultado == 2)
                    {
                        Program.mensaje(string.Format("Se ha desactivado la expedición {0} correctamente.", oExpedicion.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarExpedicion();
                    }
                    else if (resultado == -1)
                    {
                        Program.mensaje(string.Format("La expedición {0} no existe en el sistema.", oExpedicion.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultado == -2)
                    {
                        Program.mensaje("Existen documentos por recibir para la expedición. No se puede dar de baja.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultado == -3)
                    {
                        Program.mensaje("Existen bandejas asociadas a la expedición. No se puede dar de baja.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultado == -4)
                    {
                        Program.mensaje("Existen elementos custodiados en la expedición. No se puede dar de baja.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (resultado == 0)
                    {
                        Program.mensaje("Ha ocurrido un error. Vuelva a intentarlo más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Program.mensaje("Error de red. Vuelva a intentarlo más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar eliminar una expedición.");
                }
            }

        }
        //2022
        private void ActivarExpedicion(Expedicion oExpedicion)
        {
            if (Program.mensaje(string.Format("¿Desea activar la expedición {0}?", oExpedicion.Descripcion), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    int respuesta = Metodos.ActivarExpedicion(oExpedicion);
                    switch (respuesta)
                    {
                        case 1:
                            Program.mensaje(string.Format("Se ha activado la expedición {0} correctamente. ", oExpedicion.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ListarExpedicion();
                            break;
                        case -1:
                            Program.mensaje(string.Format("La expedición {0} no existe en el sistema.", oExpedicion.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        case -2:
                            Program.mensaje(string.Format("Ha ocurrido un error. Vuelva a intentarlo más tarde."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            Program.mensaje(string.Format("Error de red. Vuelva a intentarlo más tarde."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar activar una expedición.");
                }

            }
        }
        //2022
        private void cambiarEstadoExpedicion()
        {
            if (ListaExpedicionesSeleccionada.Count == 0)
            {
                Program.mensaje("Debe seleccionar una expedición de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Expedicion oExpedicion = ListaExpedicionesSeleccionada[0];
            if (oExpedicion.iActivo == 1)
            {
                EliminarExpedicion(oExpedicion);
            }
            else
            {
                ActivarExpedicion(oExpedicion);
            }
        }

        #endregion

        public frmExpedicion()
        {
            InitializeComponent();
        }

        private void frmExpedicion_Load(object sender, EventArgs e)
        {
            ListarExpedicion();
        }

        private void frmExpedicion_Activated(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            if (oM == null) return;
            oM.subMostrarJefatura(true);
        }

        private void frmExpedicion_Deactivate(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            if (oM == null) return;
            oM.subMostrarJefatura(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevaExpedicion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ModificarExpedicion();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            cambiarEstadoExpedicion();
        }

        private void grvExpedicion_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Expedicion oExpedicionSeleccionada = new Expedicion();
            try
            {
                oExpedicionSeleccionada = ListaExpediciones.Find(x => x.ID == ((Expedicion)grvExpedicion.GetFocusedRow()).ID);
            }
            catch (Exception)
            {
                return;
            }

            if (ListaExpedicionesSeleccionada.Count > 0)
            {
                if (ListaExpedicionesSeleccionada[0].ID == oExpedicionSeleccionada.ID)
                {
                    ListaExpediciones.Find(x => x.ID == ((Expedicion)grvExpedicion.GetFocusedRow()).ID).SeleccionGrafica = false;
                    ListaExpedicionesSeleccionada.RemoveAt(0);
                }
                else
                {
                    ListaExpediciones.Find(x => x.ID == ListaExpedicionesSeleccionada[0].ID).SeleccionGrafica = false;
                    ListaExpediciones.Find(x => x.ID == ((Expedicion)grvExpedicion.GetFocusedRow()).ID).SeleccionGrafica = true;
                    ListaExpedicionesSeleccionada.RemoveAt(0);
                    ListaExpedicionesSeleccionada.Add(oExpedicionSeleccionada);
                }
            }
            else
            {
                ListaExpediciones.Find(x => x.ID == ((Expedicion)grvExpedicion.GetFocusedRow()).ID).SeleccionGrafica = true;
                ListaExpedicionesSeleccionada.Add(oExpedicionSeleccionada);
            }

            grdExpedicion.RefreshDataSource();
        }


    }
}
