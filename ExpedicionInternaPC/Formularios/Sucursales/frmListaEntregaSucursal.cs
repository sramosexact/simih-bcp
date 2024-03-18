using ExpedicionInternaPC.Properties;
using ImpresionZebra;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmListaEntregaSucursal : frmChild
    {
        #region Variables

        List<Entrega> loEntrega;
        List<Entrega> lEntregaSeleccionadas = new List<Entrega>();

        #endregion

        #region Metodos

        //2022
        public override void ExportExcel(String FileName)
        {
            this.grdDatos.ExportToXls(FileName);
        }
        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            listarEntregasSucursalActivas();
            lEntregaSeleccionadas.Clear();
        }
        //2022
        private void nuevaEntregaSucursal()
        {
            frmNuevaEntregaSucursal fx = new frmNuevaEntregaSucursal();
            fx.iEstado = EntregaEstado.Nuevo;
            fx.Text = ".:: Nueva Entrega de Sucursal";
            if (fx.ShowDialog(this.Parent) == System.Windows.Forms.DialogResult.Yes)
            {
                listarEntregasSucursalActivas();
                lEntregaSeleccionadas.Clear();
            }
        }
        //2022
        private void editarEntregaSucursal()
        {
            if (lEntregaSeleccionadas.Count == 1)
            {
                Entrega oe = lEntregaSeleccionadas[0];

                if (oe.Estado != 1)
                {
                    Program.mensaje(string.Format("No se puede modificar la Entrega '{0}', se encuentra en estado: '{1}'.", oe.ID, oe.EstadoDescripcion), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                    return;
                }

                frmNuevaEntregaSucursal fx = new frmNuevaEntregaSucursal();
                if (oe.Estado == 1) fx.iEstado = EntregaEstado.Grabado;
                fx.oEntrega = oe;
                fx.Text = string.Format(".:: Modificar Entrega de Sucursal N° {0}", oe.ID);
                if (fx.ShowDialog(this.Parent) == System.Windows.Forms.DialogResult.Yes)
                {
                    listarEntregasSucursalActivas();
                    lEntregaSeleccionadas.Clear();
                }
            }
            else
            {
                Program.mensaje("No ha seleccionado ninguna entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }
        }
        //2022
        private void iniciarEntregaSucursal()
        {
            if (lEntregaSeleccionadas.Count == 1)
            {
                Entrega oe = lEntregaSeleccionadas[0];

                if (oe.Estado == 2)
                {
                    Program.mensaje(string.Format("No se puede iniciar la entrega, se encuentra en estado RUTA", oe.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                    return;
                }
                if (oe.Estado == 3)
                {
                    Program.mensaje(string.Format("No se puede iniciar la entrega, se encuentra en estado TERMINADO", oe.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                    return;
                }

                if (oe.idTipoValidacion == 0)
                {
                    Program.mensaje(string.Format("No puede iniciar la entrega, debido a que no tiene ningún elemento validado.", oe.ID), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Activate();
                    return;
                }


                if (Program.mensaje("Ya no podrá modificar la Entrega. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Activate();
                    List<string> ls = new List<string>();
                    List<Objeto> lEntregaObjeto = new List<Objeto>();

                    try
                    {
                        ls = Metodos.EntregaDetalle(oe.ID);
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar procesar la entrega seleccionada.");
                        return;
                    }

                    if (ls.Count > 0)
                    {
                        lEntregaObjeto = Metodos.deserializarPrueba<Objeto>(ls[1]);
                        List<Objeto> loIniciar = new List<Objeto>();
                        loIniciar = lEntregaObjeto.Where(x => x.idTipoValidacion == 0).ToList();

                        if (loIniciar.Count == lEntregaObjeto.Count)
                        {
                            Program.mensaje(string.Format("No se puede iniciar la entrega '{0}', debe existir como mínimo un elemento validado.", oe.ID), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.Activate();
                            listarEntregasSucursalActivas();
                            lEntregaSeleccionadas.Clear();
                            return;
                        }

                        if (loIniciar.Count > 0)
                        {
                            if (Program.mensaje(string.Format("Existe(n) {0} elemento(s) sin validar. Estos serán retirados de la Entrega. \n  ¿Desea continuar? ", loIniciar.Count), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                            {
                                this.Activate();
                                return;
                            }
                            this.Activate();
                        }
                        inicia(oe);

                    }
                }
                this.Activate();
            }
            else
            {
                Program.mensaje("No ha seleccionado ninguna entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }

        }
        //2022
        private void inicia(Entrega oe)
        {
            int resultado;

            try
            {
                resultado = Metodos.IniciarEntregaSucursal(oe.ID, Program.oUsuario.IdExpedicion, Program.oUsuario.ID, Program.oUsuario.idCasilla);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar iniciar la entrega seleccionada.");
                return;
            }

            if (resultado > 0)
            {
                listarEntregasSucursalActivas();
                imprimirEtiquetaValija();
                lEntregaSeleccionadas.Clear();
                Program.mensaje(string.Format("La entrega '{0}' ha sido iniciada correctamente. Se ha impreso la etiqueta.", oe.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }
            else if (resultado == -1)
            {
                Program.mensaje("Error, no se pudo completar la acción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Activate();
            }
            else if (resultado == -2)
            {
                listarEntregasSucursalActivas();
                lEntregaSeleccionadas.Clear();
                Program.mensaje("Solo se puede Iniciar una Entrega en estado CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
            }
            else if (resultado == -4)
            {
                listarEntregasSucursalActivas();
                lEntregaSeleccionadas.Clear();
                Program.mensaje("No se realizó ningún cambio.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }
        }
        //2022
        private void eliminarEntregaSucursal()
        {
            if (lEntregaSeleccionadas.Count == 0)
            {
                Program.mensaje("No ha seleccionado ninguna entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }

            if (lEntregaSeleccionadas.Count == 1)
            {
                if (lEntregaSeleccionadas[0].Estado == 1)
                {
                    if (Program.mensaje(string.Format("Se eliminará la Entrega '{0}'. ¿Desea continuar?", lEntregaSeleccionadas[0].ID), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.Activate();
                        int resultado = 0;

                        try
                        {
                            resultado = Metodos.EliminarEntregaSucursal(lEntregaSeleccionadas[0].ID);
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }
                        catch (Exception)
                        {
                            Program.mensajeError("Ha ocurrido un error al intentar eliminar la entrega seleccionada.");
                            return;
                        }


                        if (resultado > 0)
                        {
                            listarEntregasSucursalActivas();
                            Program.mensaje(string.Format("La Entrega '{0}' ha sido eliminada correctamente.", lEntregaSeleccionadas[0].ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            lEntregaSeleccionadas.Clear();
                        }
                        else if (resultado == 0)
                        {
                            Program.mensaje("Solo se pueden eliminar Entregas en el estado CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Activate();
                        }
                        else
                        {
                            Program.mensaje("No se ha podido realizar la acción. Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Activate();
                        }
                    }
                    this.Activate();
                }
                else
                {
                    Program.mensaje(string.Format("No se puede eliminar la Entrega '{0}', se encuentra en estado '{1}'.", lEntregaSeleccionadas[0].ID, lEntregaSeleccionadas[0].EstadoDescripcion), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                }

            }
            else
            {
                Program.mensaje("No ha seleccionado ninguna entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }

        }
        //2022
        public void listarEntregasSucursalActivas()
        {
            Entrega oEntrega = new Entrega() { IdExpedicionOrigen = Program.oUsuario.IdExpedicion };

            try
            {
                loEntrega = Metodos.ListarEntregasSucursalesActivas(oEntrega);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar listar las entregas activas.");
            }

            grdDatos.DataSource = loEntrega;

            grvSucursal.BeginDataUpdate();
            try
            {
                grvSucursal.ClearSorting();
                grvSucursal.Columns["EstadoDescripcion"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                grvSucursal.Columns["Registro"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                grvSucursal.Columns["Inicio"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;

            }
            finally
            {
                grvSucursal.EndDataUpdate();
            }

        }
        //2022
        private void verDetalle()
        {
            int ie = ((Entrega)grvSucursal.GetFocusedRow()).ID;
            List<string> ls = new List<string>();

            try
            {
                ls = Metodos.EntregaDetalle(ie);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener el detalle de la entrega seleccionada.");
                return;
            }

            if (ls.Count > 0)
            {
                String tag = "Entrega " + ie.ToString();

                frmEntregaSucursales frmEp = new frmEntregaSucursales();
                frmEp.oEntrega = Metodos.deserializarPrueba<Entrega>(ls[0])[0];

                frmEp.lEntregaObjeto = Metodos.deserializarPrueba<Objeto>(ls[1]);
                frmEp.Tag = tag;
                frmEp.Text = tag;
                frmEp.oTipoEntrega = TipoEntrega.ENVIO_SUCURSALES;
                frmEp.CargarFormularioVista();
                if (frmEp.ShowDialog(this.Parent) == System.Windows.Forms.DialogResult.Abort)
                {
                    listarEntregasSucursalActivas();
                }
                lEntregaSeleccionadas.Clear();

            }

        }
        //2022
        private void imprimirEtiquetaValija()
        {
            if (lEntregaSeleccionadas.Count > 0)
            {
                Entrega oe = lEntregaSeleccionadas[0];

                ZebraZpl zpl = new ZebraZpl();
                zpl.NOMBRE_IMPRESORA = Settings.Default["RutaImpresoraZebra"].ToString();
                string s = zpl.etiquetaEntregaSucursal(oe.ID.ToString("000000"), oe.ExpedicionDestino);

                zpl.imprimirEtiqueta(s);

                Program.mensaje("Se ha impreso la etiqueta de la Entrega seleccionada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }
            else
            {
                //Program.mensaje("No ha seleccionado ninguna Entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.Activate();
            }
        }

        #endregion


        public frmListaEntregaSucursal()
        {
            InitializeComponent();
        }

        private void frmListaEntregaSucursal_Load(object sender, EventArgs e)
        {
            listarEntregasSucursalActivas();
            lEntregaSeleccionadas.Clear();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            nuevaEntregaSucursal();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            editarEntregaSucursal();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminarEntregaSucursal();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            iniciarEntregaSucursal();
            this.Activate();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            verDetalle();
        }

        private void frmListaEntregaSucursal_Activated(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            if (oM == null) return;
        }

        private void frmListaEntregaSucursal_Deactivate(object sender, EventArgs e)
        {
            frmMain oM = (frmMain)this.MdiParent;
            if (oM == null) return;
        }

        private void grvSucursal_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (grvSucursal.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }

                Entrega obj = (Entrega)grvSucursal.GetFocusedRow();

                if (obj != null)
                {
                    if (lEntregaSeleccionadas.Count == 0)
                    {
                        obj.SeleccionGrafica = true;
                        lEntregaSeleccionadas.Add(obj);
                        grdDatos.Refresh();
                        grvSucursal.RefreshData();

                    }
                    else
                    {
                        loEntrega.Find(hol => hol.ID == lEntregaSeleccionadas[0].ID).SeleccionGrafica = false;

                        if (obj.ID == lEntregaSeleccionadas[0].ID)
                        {
                            lEntregaSeleccionadas.Clear();
                        }
                        else
                        {
                            lEntregaSeleccionadas.Clear();
                            obj.SeleccionGrafica = true;
                            lEntregaSeleccionadas.Add(obj);
                        }

                        grdDatos.Refresh();
                        grvSucursal.RefreshData();
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
