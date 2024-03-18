using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmEntregaPisosResultado : frmChild
    {
        #region Variables

        public List<Objeto> lista = null;
        public int contadorEntregados = 0;
        public int contadorNoEntregados = 0;
        public int totalDocumentos = 0;
        public List<Objeto> listaValidadosHands = new List<Objeto>();
        public List<Objeto> listaModificable = null;
        public Entrega oO;

        #endregion

        #region Metodos

        //2022
        public void CargarDetalle()
        {
            try
            {
                lista = Metodos.rObtenerDocumentosPorEntregaJson(oO);
                if (lista != null || lista.Count != 0)
                {
                    listaModificable = lista.Where(hol => hol.IdTipoResultadoPisos == (int)EnumTipoResultadoPisos.INCORRECTO).ToList();
                }
                grdDatos.DataSource = lista;
                contar();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar el detalle de la entrega.");
                return;
            }

        }
        //2022
        private void contar()
        {
            totalDocumentos = lista.Count();
            contadorEntregados = lista.Where(hol => hol.IdTipoResultado == 72 || hol.IdTipoResultado == 73 || hol.IdTipoResultado == 273).ToList().Count();
            contadorNoEntregados = totalDocumentos - contadorEntregados;
            txtEntregados.Text = contadorEntregados.ToString();
            txtEntregadosNo.Text = contadorNoEntregados.ToString();
        }
        //2022
        private void EntregaManual()
        {
            if (txtAutogenerado.Text.Trim() != "")
            {
                Objeto obj = lista.Find(hol => hol.Autogenerado == txtAutogenerado.Text.Trim());
                if (obj != null)
                {
                    if (obj.IdTipoResultado != (int)Proceso.UTILIZAPDA && obj.IdTipoResultado != (int)Proceso.UTILIZADPM && obj.IdTipoResultado != (int)Proceso.UTILIZAMANUAL)
                    {
                        if (obj.iIdGeoDestinoAnterior != 0)
                        {
                            Program.mensaje(string.Format("Ha cambiado el destino del elemento, no se puede entregar manualmente."), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.Activate();
                            txtAutogenerado.Text = "";
                            txtAutogenerado.Focus();
                            txtAutogenerado.SelectAll();
                        }
                        else
                        {
                            obj.IdTipoResultado = (int)Proceso.UTILIZAMANUAL;
                            obj.fechaResultado = DateTime.Now; //Para la vista en grilla                        
                            obj.IdTipoEstado = (int)EstadoObjeto.RECIBIDO;
                            obj.Estado = EstadoObjeto.RECIBIDO.ToString();
                            grdViewDatos.RefreshData();
                            grdViewDatos.Columns["fechaResultado"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                            txtAutogenerado.Text = "";
                            txtAutogenerado.Focus();
                            txtAutogenerado.SelectAll();
                            Program.ok.PlaySync();
                            contar();
                            listaValidadosHands.Add(obj);
                        }

                    }
                    else
                    {
                        Program.mensaje(string.Format("Solo se puede modificar el resultado del elemento {0} mediante la importación de datos.", obj.Autogenerado), MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.Activate();
                        txtAutogenerado.Text = "";
                        txtAutogenerado.Focus();
                        txtAutogenerado.SelectAll();
                        Program.ok.PlaySync();
                    }
                }
                else
                {
                    Program.mensaje("El código ingresado no se encuentra en la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Activate();
                    txtAutogenerado.Focus();
                    txtAutogenerado.SelectAll();
                }
            }
        }
        //2022
        private void CerrarEntrega()
        {
            if (listaValidadosHands.Count > 0)
            {
                Program.mensaje("No ha grabado los cambios. Grabe e intente cerrar la entrega nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }

            List<Objeto> lObjetos = lista.FindAll(hol => hol.IdTipoResultado == (int)Proceso.UTILIZAPDA || hol.IdTipoResultado == (int)Proceso.UTILIZADPM || hol.IdTipoResultado == (int)Proceso.UTILIZAMANUAL).ToList();
            List<Objeto> lObjetosEnRuta = lista.FindAll(hol => hol.IdTipoResultadoPisos == 0).ToList();
            List<Objeto> lObjetosMalEntregados = lista.FindAll(hol => hol.IdTipoResultadoPisos == 2).ToList();

            if (lObjetos.Count > 0)
            {
                if (lObjetosMalEntregados.Count > 0)
                {
                    if (lObjetosEnRuta.Count > 0)
                    {
                        DialogResult respuesta = Program.mensaje(string.Format("Los elementos que no han sido entregados regresarán a Custodia," +
                    " pero la entrega seguirá abierta debido a que hay " + lObjetosMalEntregados.Count.ToString() + " elementos que han sido entregados en el lugar incorrecto. ¿Desea continuar?"),
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        this.Activate();
                        if (respuesta == DialogResult.Yes)
                        {
                            CerrandoEntrega(lObjetosEnRuta.Count);
                        }
                        return;
                    }
                    Program.mensaje(string.Format("Existen " + lObjetosMalEntregados.Count.ToString() + " elementos que han sido entregados en el lugar incorrecto, no se puede cerrar la entrega."),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Activate();
                    return;

                }
                else if (lObjetosEnRuta.Count > 0)
                {
                    DialogResult respuesta = Program.mensaje(string.Format("Los " + lObjetosEnRuta.Count.ToString() + " elementos que no han sido entregados" +
                    " retornarán a estado Custodia. ¿Desea continuar?"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    this.Activate();
                    if (respuesta == DialogResult.Yes)
                    {
                        CerrandoEntrega(lObjetosEnRuta.Count);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        this.Dispose();
                    }
                    return;
                }

                CerrandoEntrega(1);
                this.DialogResult = DialogResult.OK;
                this.Close();
                this.Dispose();
            }
            else
            {
                if (Program.mensaje(string.Format("No ha entregado ningún elemento, se eliminará la entrega y los elementos retornarán a estado CUSTODIA. ¿Desea continuar?"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Activate();
                    int resultado = 0;
                    try
                    {
                        resultado = Metodos.EliminarEntregaPisosResultado(oO.ID, Program.oUsuario.IdExpedicion, Program.oUsuario.ID, Program.oUsuario.idCasilla, Program.oUsuario.idGeoCasilla);
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }


                    if (resultado == 1)
                    {
                        Program.mensaje(string.Format("Se ha eliminado la entrega correctamente."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        refrescarDetalleEntrega();
                        frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);
                        try
                        {
                            frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                        }
                        catch (Exception)
                        {
                            Program.mensajeError("Ha ocurrido un error al intentar actualizar la lista de entregas.");
                        }
                        this.Close();
                        this.Dispose();
                        return;
                    }
                    if (resultado == -1 || resultado == -3)
                    {
                        Program.mensaje(string.Format("Hubo un error en la ejecución. Intente nuevamente"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Activate();
                        return;
                    }
                    if (resultado == -2)
                    {
                        Program.mensaje(string.Format("No se puede eliminar la entrega, existen elementos que han sido entregados."), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Activate();
                        return;
                    }

                }
                this.Activate();
                return;
            }

        }
        //2022
        private void CerrandoEntrega(int cantidad)
        {

            int respuesta;

            try
            {
                respuesta = Metodos.uCerrarEntregaPisos1(oO.ID, Program.oUsuario.IdExpedicion, Program.oUsuario.ID, Program.oUsuario.idCasilla, Program.oUsuario.idGeoCasilla);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cerrar la entrega");
                return;
            }

            if (respuesta == 1)
            {
                Program.mensaje(string.Format("La entrega se ha cerrado correctamente."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                refrescarDetalleEntrega();
                frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);
                try
                {
                    frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar actualizar la lista de entregas.");
                }
                this.Close();
                this.Dispose();
            }
            else if (respuesta == 2)
            {
                Program.mensaje(string.Format("Se han retirado " + cantidad.ToString() + " elementos de la entrega."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                refrescarDetalleEntrega();
                frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);
                try
                {
                    frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar actualizar la lista de entregas.");
                }

                this.Close();
                this.Dispose();
            }
            else if (respuesta == -2)
            {
                Program.mensaje("La entrega se encuentra en diferente estado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
            }
            else if (respuesta == -3)
            {
                Program.mensaje("No puede cerrar la entrega, ya que existe correspondencia que deberia ser regularizada.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();

            }
            else
            {
                Program.mensaje("Hubo un error con la conexion a la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Activate();
            }
        }
        //2022
        private void guardarCambios()
        {
            Objeto O = new Objeto();
            O.ListaXML = O.SerializeObjectWindows(listaValidadosHands);
            int valor = 0;

            try
            {
                valor = Metodos.uGrabarEntregaPisos(O.ListaXML, oO.ID);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar guardar la entrega.");
                return;
            }


            if (valor == -2)
            {
                Program.mensaje("La entrega se encuentra en estado diferente a Terminada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Activate();
                return;
            }
            else if (valor == -1)
            {
                Program.mensaje("Hubo un error en la modificacion en la base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Activate();
                return;
            }
            CargarDetalle();
            listaValidadosHands.Clear();
            frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);
            try
            {
                frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar actualizar la lista de entregas.");
            }

            Program.mensaje("Se grabaron los cambios correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Activate();
        }
        //2022
        private void refrescarDetalleEntrega()
        {
            grdDatos.DataSource = null;
            try
            {
                lista = Metodos.rObtenerDocumentosPorEntregaJson(new Entrega() { ID = oO.ID });
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar el detalle de la entrega.");
                return;
            }

            grdDatos.DataSource = lista;
        }
        //2022
        private void HabilitarEntregaManual()
        {
            if (listaModificable.Count() != 0 || lista.Where(hol => hol.Estado == "RUTA").ToList().Count() != 0)
            {
                frmClavSupervisor frm = new frmClavSupervisor();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    txtAutogenerado.Visible = true;
                    txtAutogenerado.Focus();
                    btnEntrega.Visible = true;
                    lblAutogenerado.Visible = true;
                    btnGuardar.Enabled = true;
                    btnHabilitarEntregaManual.Visible = false;
                }
            }
            else
            {
                Program.mensaje(String.Format("Todos los elementos han sido dejados en el lugar correcto."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }
        }

        #endregion


        public frmEntregaPisosResultado()
        {
            InitializeComponent();
            this.txtAutogenerado.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void grdViewDatos_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;

            if (e.RowHandle >= 0)
            {
                GridColumn oCol = null;
                GridColumn oCol1 = null;
                string tipo = "";
                int ID = 0;

                try
                {
                    oCol = (GridColumn)View.Columns["Estado"];
                    oCol1 = (GridColumn)View.Columns["ID"];
                }
                catch (Exception) { }

                if (oCol != null || oCol1 != null)
                {
                    try
                    {
                        tipo = View.GetRowCellValue(e.RowHandle, oCol).ToString();
                        ID = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oCol1).ToString());
                    }
                    catch (Exception) { }
                }
                if (lista == null)
                {
                    return;

                }
                else
                {
                    if (listaModificable != null || listaModificable.Count != 0)
                    {
                        if (listaModificable.Find(hol => hol.ID == ID) != null)
                        {
                            e.Appearance.BackColor = Color.FromArgb(0xF8, 0x5C, 0x5C);
                            e.Appearance.BackColor2 = Color.FromArgb(0xF8, 0x5C, 0x5C);
                            return;
                        }
                    }
                    if (tipo == "RUTA")
                    {
                        e.Appearance.BackColor = Color.FromArgb(0xE8, 0x87, 0x41);
                        e.Appearance.BackColor2 = Color.FromArgb(0xE8, 0x87, 0x41);
                    }
                    else if (tipo == "RECIBIDO")
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.White;
                    }
                }
            }
        }

        private void btnEntregaManual_Click(object sender, EventArgs e)
        {
            EntregaManual();
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtAutogenerado.Text.Trim().Length >= 6)
            {
                EntregaManual();
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            CerrarEntrega();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (listaValidadosHands.Count() > 0)
            {
                guardarCambios();
            }
            else
            {
                Program.mensaje(string.Format("No existen autogenerados validados manualmente."), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                this.Close();
            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, System.EventArgs e)
        {
            Objeto oO = (Objeto)grdViewDatos.GetFocusedRow();
            oO.IdTipoEntrega = 1;
            Metodos.VerTracking(oO);
        }

        private void btnHabilitarEntregaManual_Click(object sender, EventArgs e)
        {
            HabilitarEntregaManual();
        }

        private void frmEntregaPisosResultado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listaValidadosHands.Count() > 0)
            {
                DialogResult rs = Program.mensaje(string.Format("No ha grabado los cambios realizados. ¿Desea grabar?"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                this.Activate();
                if (rs == DialogResult.Yes)
                {
                    guardarCambios();
                }
            }
        }

        private void frmEntregaPisosResultado_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("Entrega {0}" + "                                      " +
            "                                        " + "Estado : {1}", oO.ID, oO.EstadoDescripcion);
            //Ruta
            if (oO.Estado == 2)
            {
                btnHabilitarEntregaManual.Enabled = false;
                btnFinalizar.Enabled = false;
            }
            btnGuardar.Enabled = false;
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void txtAutogenerado_TextChanged(object sender, EventArgs e)
        {
            if (txtAutogenerado.Text.Count() > 0)
            {
                txtAutogenerado.Text = txtAutogenerado.Text.ToUpper();
                txtAutogenerado.SelectionStart = txtAutogenerado.Text.Count();
            }
        }

    }
}
