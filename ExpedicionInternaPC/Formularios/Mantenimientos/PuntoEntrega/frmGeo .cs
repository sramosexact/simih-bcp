using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using ExpedicionInternaPC.Properties;
using ImpresionZebra;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmGeo : frmChild
    {
        #region Variables
        private List<Geo> oLista = null;
        private Geo oGeoSeleccionado;
        private Boolean opc = false;
        private Boolean seleccionado = false;
        private TreeListNode oNodex;
        private Boolean SeleccionClicDerecho = false;
        private bool autoajuste = bool.Parse(Settings.Default["autoajuste"].ToString());
        #endregion

        #region Metodos

        //2022
        public override void Actualizar(string CommandName)
        {
            seleccionado = true;
            CargarRegistros();
            seleccionado = false;
        }
        //2022
        private void CargarRegistros()
        {
            CargarGeoPanelIzquierdo();
            if (oLista == null || oLista.Count == 0) return;
            if (opc == false)
            {
                treGeo.FocusedNode = treGeo.Nodes[0].Nodes[0].Nodes[0].Nodes[0];
                treGeo.FocusedNode.Selected = true;
            }
            opc = true;
            oGeoSeleccionado = GeoActual();
            UbicarGeo(oGeoSeleccionado.ID);
            CargarPuntosEntrega();
        }
        //2022
        private void CargarGeoPanelIzquierdo()
        {
            try
            {
                oLista = Metodos.ListarUbicacionesJson(Program.oUsuario.IdCliente);
                treGeo.DataSource = oLista;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de direcciones del panel izquierdo.");
            }

        }
        //2022
        public void CargarPuntosEntrega()
        {
            try
            {
                Program.ShowPopWaitScreen();
                List<Geo> oG = null;
                oGeoSeleccionado = GeoActual();
                oGeoSeleccionado.IDCliente = Program.oUsuario.IdCliente;
                grdOficinas.DataSource = null;
                oG = Metodos.ListarPuntosEntrega(oGeoSeleccionado);

                if (oG != null)
                {
                    grdOficinas.DataSource = oG;
                    grpPuntoEntrega.Text = "Puntos de Entrega para la Zona : " + oGeoSeleccionado.Descripcion;
                }
                grdOficinas.Refresh();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los puntos de entrega.");
            }
            finally
            {
                Program.HidePopWaitScreen();
            }
        }
        //2022
        private Geo GeoActual()
        {
            Geo oGeo = new Geo();
            try
            {
                oGeo.ID = int.Parse(oNodex.GetValue("ID").ToString());
                oGeo.Descripcion = oNodex.GetValue("Descripcion").ToString();
                oGeo.Distrito = oNodex.GetValue("Descripcion").ToString();
                oGeo.IDPadre = int.Parse(oNodex.GetValue("IDPadre").ToString());
                oGeo.Alias = oNodex.GetValue("Alias").ToString();
                oGeo.Level = oNodex.Level;
            }
            catch (Exception)
            {

            }
            return oGeo;
        }
        //2022
        private void UbicarGeo(int IdGeo)
        {
            oNodex = treGeo.FindNodeByKeyID(IdGeo);
            oNodex.Visible = true;
            oNodex.Expanded = true;
            oNodex.Selected = true;
        }
        //2022
        public override void ExportExcel(String FileName)
        {
            grvOficinas.ExportToXls(FileName);
        }
        //2022
        public void Imprimir()
        {
            try
            {
                if (this.grdOficinas.DefaultView.RowCount > 0)
                {
                    if (Program.mensaje(string.Format("Va a imprimir {0} etiquetas. ¿Desea continuar?", grdOficinas.DefaultView.RowCount), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        List<string> Oficinas = new List<string>();
                        for (int i = 0; i <= grdOficinas.DefaultView.DataRowCount - 1; i++)
                        {
                            string codigo = grvOficinas.GetRowCellValue(i, "ID").ToString().PadLeft(6, '0');
                            string oficina = grvOficinas.GetRowCellValue(i, "Oficina").ToString().ToUpper();
                            string area = grvOficinas.GetRowCellValue(i, "Descripcion").ToString().ToUpper();
                            ZebraZpl zpl = new ZebraZpl();
                            zpl.NOMBRE_IMPRESORA = Settings.Default["RutaImpresoraZebra"].ToString();
                            string s = zpl.etiquetaPuntoEntrega(codigo, oficina, area, autoajuste);
                            if (!(Oficinas.Contains(area)))
                            {
                                Oficinas.Add(oficina);
                                zpl.imprimirEtiqueta(s);
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        //2022
        private void AgregarPuntoEntrega()
        {
            List<Geo> ListaPuntoEntrega = (List<Geo>)grdOficinas.DataSource;
            if (ListaPuntoEntrega == null)
            {
                Program.mensaje("No puede crear puntos de entrega. Primero debe vincular una sucursal o agencia a la dirección seleccionada.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ListaPuntoEntrega.Count > 0)
            {
                Geo oGeo = new Geo();
                oGeo.IDCliente = Program.oUsuario.IdCliente;
                oGeo.ID = int.Parse(treGeo.Selection[0].GetValue("ID").ToString());
                oGeo.CodigoAgencia = treGeo.Selection[0].GetValue("CodigoAgencia").ToString();
                oGeo.Agencia = treGeo.Selection[0].GetValue("Agencia").ToString();
                oGeo.Expedicion = treGeo.Selection[0].GetValue("Expedicion").ToString();
                oGeo.IdTipoDestino = int.Parse(treGeo.Selection[0].GetValue("IdTipoDestino").ToString());
                oGeo.Alias3 = treGeo.Selection[0].GetValue("Alias3").ToString();
                oGeo.Area = "";
                oGeo.Oficina = oGeo.Agencia;

                frmAgregarPuntoEntrega frmCr = new frmAgregarPuntoEntrega();
                frmCr.Text = "Crear punto de entrega.";
                frmCr.oGeo = oGeo;
                frmCr.tipoAccion = 1;

                frmCr.ShowDialog();
                if (frmCr.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    treGeo.Selection[0].SetValue("CodigoAgencia", frmCr.oListaOficinas[0].CodigoAgencia);
                    treGeo.Selection[0].SetValue("Agencia", frmCr.oListaOficinas[0].Agencia);
                    treGeo.Selection[0].SetValue("Expedicion", frmCr.oListaOficinas[0].Expedicion);
                    treGeo.Selection[0].SetValue("IdTipoDestino", frmCr.oListaOficinas[0].IdTipoDestino);
                    treGeo.Selection[0].SetValue("Alias3", frmCr.oListaOficinas[0].Alias3);
                    grdOficinas.DataSource = frmCr.oListaOficinas;
                    grvOficinas.SelectRow(frmCr.oListaOficinas.Count - 1);
                    grdOficinas.Focus();
                }
            }
            else
            {
                Program.mensaje("No puede crear puntos de entrega. Primero debe vincular una sucursal o agencia a la dirección seleccionada.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void crearDepartamento(Geo GeoPais)
        {
            int intIdPadre = GeoPais.ID;
            Geo oGeoCrear = new Geo();
            oGeoCrear.IDCliente = Program.oUsuario.IdCliente;
            oGeoCrear.Distrito = string.Empty;
            oGeoCrear.ID = intIdPadre;
            crearGeo(oGeoCrear);
        }
        //2022
        public void editarCelda()
        {
            treGeo.OptionsBehavior.Editable = true;
            treGeo.ShowEditor();
        }
        //2022
        public void eliminarGeo(Geo geo)
        {
            if (Program.mensaje("Se eliminará el registro seleccionado. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            try
            {
                int respuesta = Metodos.EliminarPuntoEntrega(geo.ID);
                switch (respuesta)
                {
                    case 1:
                        Program.mensaje("Se ha eliminado el registro con éxito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRegistros();
                        break;
                    case -1:
                    case -3:
                        Program.mensaje("Ha ocurrido un problema, inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    case -2:
                        switch (geo.Level)
                        {
                            case 1:
                                Program.mensaje(string.Format("Existen provincias asociadas al departamsento {0}, no se puede eliminar.", geo.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            case 2:
                                Program.mensaje(string.Format("Existen distritos asociados a la provincia {0}, no se puede eliminar.", geo.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            case 3:
                                Program.mensaje(string.Format("Existen calles asociadas al distrito {0}, no se puede eliminar.", geo.Descripcion), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                        }
                        break;
                    case -4:
                        Program.mensaje("No existe el registro en la base de datos.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CargarRegistros();
                        break;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar eliminar el punto de entrega.");
            }

        }
        //2022
        public bool mostrarEliminarGeo(Geo geo)
        {
            if (oLista.Exists(x => x.IDPadre == geo.ID))
            {
                return false;
            }
            return true;
        }
        //2022
        public void crearGeo(Geo oGeoCrear)
        {
            try
            {
                int ID1 = Metodos.CrearGeo(oGeoCrear);
                if (ID1 > 0)
                {
                    CargarGeoPanelIzquierdo();
                    UbicarGeo(ID1);
                    treGeo.OptionsBehavior.Editable = true;
                    treGeo.ShowEditor();
                    return;
                }
                if (ID1 == -1)
                {
                    Program.mensaje("No existe el registro en el sistema. Recargue la pantalla", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ID1 == -2)
                {
                    Program.mensaje("No se puede crear el registro debido a que no ha nombrado correctamente el registro base.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    Program.mensaje("Ha ocurrido un error en la creación. Intentelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar crear el punto de entrega.");
            }


        }

        #endregion

        public frmGeo()
        {
            InitializeComponent();
        }

        private void frmGeo_Load(object sender, EventArgs e)
        {

        }

        private void frmGeo_Activated(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            if (Program.oUsuario.IdTipoAcceso == 43) frmPadre.subMostrarSupervision(true);
            if (Program.oUsuario.IdTipoAcceso == 80) frmPadre.subMostrarJefatura(true);
            CargarRegistros();
            seleccionado = false;
        }

        private void frmGeo_Deactivate(object sender, EventArgs e)
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            seleccionado = true;
            if (Program.oUsuario.IdTipoAcceso == 43) frmPadre.subMostrarSupervision(false);
            if (Program.oUsuario.IdTipoAcceso == 80) frmPadre.subMostrarJefatura(false);
        }

        private void treGeo_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
            opc = false;
            oGeoSeleccionado = GeoActual();

            if (oGeoSeleccionado.Descripcion.Length > 0)
            {
                try
                {
                    if (e.Node.Level == 4)
                    {
                        Metodos.ActualizarGeo(oGeoSeleccionado);
                    }
                    if (e.Node.Level == 3)
                    {
                        Metodos.ActualizarGeo(oGeoSeleccionado);
                    }
                    if (e.Node.Level == 2)
                    {
                        Metodos.ActualizarGeo(oGeoSeleccionado);
                    }
                    if (e.Node.Level == 1)
                    {
                        Metodos.ActualizarGeo(oGeoSeleccionado);
                    }

                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar actualizar el punto de entrega.");
                }

            }
            int iId = oGeoSeleccionado.ID;
            CargarGeoPanelIzquierdo();
            UbicarGeo(iId);
            CargarPuntosEntrega();
            treGeo.OptionsBehavior.Editable = false;
            opc = true;
        }

        private void treGeo_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (seleccionado == false)
            {
                oNodex = e.Node;
                if (oNodex.Level == 4)
                {
                    btn_agregar.Enabled = true;
                    grvOficinas.Columns.ColumnByName("grdColEditar").Visible = true;
                    grvOficinas.Columns.ColumnByName("grdColEliminar").Visible = true;
                    grvOficinas.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                }
                else
                {
                    btn_agregar.Enabled = false;
                    grvOficinas.Columns.ColumnByName("grdColEditar").Visible = false;
                    grvOficinas.Columns.ColumnByName("grdColEliminar").Visible = false;
                    grvOficinas.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                }

                if (opc == true)
                {
                    CargarPuntosEntrega();
                }
            }
            treGeo.OptionsBehavior.Editable = false;
        }

        private void treGeo_HiddenEditor(object sender, EventArgs e)
        {
            TreeList tlist = sender as TreeList;
            tlist.FocusedNode.StateImageIndex = -1;
        }

        private void treGeo_MouseClick(object sender, MouseEventArgs e)
        {
            if (SeleccionClicDerecho == false)
                return;

            if (e.Button == MouseButtons.Right)
            {
                oGeoSeleccionado = GeoActual();
                barbtnNuevoDistrito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtnEditarDistrito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barBtnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barBtnEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barBtnEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barBtnImprimir.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtnNuevaProvincia.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtnEditarProvincia.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtnNuevoDepa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtnEditarDepa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtnEliminarDepa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtnEliminarProvincia.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtnEliminarDistrito.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                switch (oGeoSeleccionado.Level)
                {
                    // pais
                    case 0:
                        barbtnNuevoDepa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    // dpto
                    case 1:
                        barbtnNuevaProvincia.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barbtnEditarDepa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barbtnEliminarDepa.Visibility = mostrarEliminarGeo(oGeoSeleccionado) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                        break;
                    // prov
                    case 2:
                        barbtnNuevoDistrito.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barbtnEditarProvincia.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barbtnEliminarProvincia.Visibility = mostrarEliminarGeo(oGeoSeleccionado) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                        break;
                    // dist
                    case 3:
                        barbtnEditarDistrito.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barBtnNuevo.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barbtnEliminarDistrito.Visibility = mostrarEliminarGeo(oGeoSeleccionado) ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                        break;
                    // calle
                    case 4:
                        barBtnEditar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        barBtnEliminar.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                        break;
                    default:
                        break;
                }
                ppmCalles.ShowPopup(Control.MousePosition);
            }
        }

        private void treGeo_ShownEditor(object sender, EventArgs e)
        {
            TreeList tlist = sender as TreeList;
            tlist.FocusedNode.StateImageIndex = 5;
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            AgregarPuntoEntrega();
        }

        private void lnkEditar_Click(object sender, EventArgs e)
        {
            Geo objGeo = new Geo();
            objGeo = (Geo)grvOficinas.GetFocusedRow();

            if (objGeo == null) return;

            objGeo.IDCliente = Program.oUsuario.IdCliente;

            frmAgregarPuntoEntrega frmPE = new frmAgregarPuntoEntrega();
            frmPE.tipoAccion = 2;
            frmPE.Text = "Modificar punto de entrega.";
            frmPE.oGeo = objGeo;

            frmPE.ShowDialog(this.Parent);
            if (frmPE.DialogResult == DialogResult.OK)
            {
                grdOficinas.DataSource = frmPE.oListaOficinas;
                grvOficinas.SelectRow(frmPE.oListaOficinas.Count - 1);
                grdOficinas.Focus();
            }
        }

        private void lnkEliminar_Click(object sender, EventArgs e)
        {
            if (grvOficinas.GetFocusedRow() == null) return;

            Geo oGeo = (Geo)grvOficinas.GetFocusedRow();
            oGeo.IDCliente = Program.oUsuario.IdCliente;

            if (oGeo.CantidadBandeja > 0)
            {
                Program.mensaje(string.Format("Existen {0} bandejas asociadas", oGeo.CantidadBandeja), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int[] rHandle = grvOficinas.GetSelectedRows();

            DialogResult oR = Program.mensaje("Se eliminará el punto de entrega, desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oR == DialogResult.No) return;

            try
            {
                int intEliminar = Metodos.EliminarOficinas(oGeo);

                if (intEliminar > 0)
                {
                    try
                    {
                        grvOficinas.DeleteSelectedRows();
                        grvOficinas.SelectRow(rHandle[0] - 1);
                    }
                    catch (Exception) { }
                    if (grvOficinas.RowCount == 1)
                    {
                        treGeo.Selection[0].SetValue("CodigoAgencia", "");
                        treGeo.Selection[0].SetValue("Agencia", "");
                        treGeo.Selection[0].SetValue("Expedicion", "");
                        treGeo.Selection[0].SetValue("IdTipoDestino", 0);
                        treGeo.Selection[0].SetValue("Alias3", "");
                    }
                    grvOficinas.Focus();
                    return;
                }
                else if (intEliminar == -2)
                {
                    Program.mensaje("No se puede eliminar. Existe correspondencia asociada a este punto de entrega.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grdOficinas.Focus();
                    return;
                }
                else if (intEliminar == -3)
                {
                    Program.mensaje("No se puede eliminar. Existen bandejas asociadas a este punto de entrega.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grdOficinas.Focus();
                    return;
                }
                else if (intEliminar == -4)
                {
                    Program.mensaje("No se puede eliminar. Este punto de entrega está asociado a una expedición.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grdOficinas.Focus();
                    return;
                }
                else if (intEliminar == -5)
                {
                    Program.mensaje("No se puede eliminar el último punto de entrega de una dirección.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    grdOficinas.Focus();
                    return;
                }
                else
                {
                    Program.mensaje("Error de red. Intente realizar la acción nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdOficinas.Focus();
                    return;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar eliminar el punto de entrega.");
            }


        }

        private void lnkCantidadBandeja_Click(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)grvOficinas.GetFocusedRow();
            if (oGeo == null) return;

            frmBandejaPorGeo fx = new frmBandejaPorGeo(oGeo);
            fx.Show();

        }

        private void barbtnNuevoDistrito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //NUEVO DISTRITO
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level != 2) return;
            int intIdPadre = oGeoSeleccionado.ID;
            Geo oGeoCrear = new Geo();
            oGeoCrear.IDCliente = Program.oUsuario.IdCliente;
            oGeoCrear.Distrito = string.Empty;
            oGeoCrear.ID = intIdPadre;
            crearGeo(oGeoCrear);
        }

        private void barbtnEditarDistrito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Editar distrito
            Geo oGeo = GeoActual();
            treGeo.OptionsBehavior.Editable = true;
            treGeo.ShowEditor();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //NUEVA PROVINCIA
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level != 1) return;
            int intIdPadre = oGeoSeleccionado.ID;

            Geo oGeoCrear = new Geo();
            oGeoCrear.IDCliente = Program.oUsuario.IdCliente;
            oGeoCrear.Distrito = string.Empty;
            oGeoCrear.ID = intIdPadre;
            crearGeo(oGeoCrear);
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Editar provincia
            Geo oGeo = GeoActual();
            treGeo.OptionsBehavior.Editable = true;
            treGeo.ShowEditor();
        }

        private void barBtnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //NUEVA CALLE
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level < 3) return;
            int intIdPadre = oGeoSeleccionado.Alias == "CALL" ? oGeoSeleccionado.IDPadre : oGeoSeleccionado.ID;

            Geo oGeoCrear = new Geo();
            oGeoCrear.IDCliente = Program.oUsuario.IdCliente;
            oGeoCrear.Calle = string.Empty;
            oGeoCrear.ID = intIdPadre;
            crearGeo(oGeoCrear);
        }

        private void barBtnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Editar calle            
            oGeoSeleccionado = GeoActual();
            treGeo.OptionsBehavior.Editable = true;
            treGeo.ShowEditor();
        }

        private void barBtnEliminar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level < 4) return;
            oGeoSeleccionado.IDCliente = Program.oUsuario.IdCliente;
            try
            {
                int intEliminar = Metodos.EliminarCalles(oGeoSeleccionado);
                switch (intEliminar)
                {
                    case -1: Program.mensaje("No se pudo eliminar la calle porque tiene oficinas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); break;
                    default: CargarGeoPanelIzquierdo(); break;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar eliminar el punto de entrega.");
            }
        }

        private void barBtnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void treGeo_MouseDown(object sender, MouseEventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right && (hitInfo.HitInfoType == HitInfoType.Cell || hitInfo.HitInfoType == HitInfoType.SelectImage || hitInfo.HitInfoType == HitInfoType.StateImage || hitInfo.HitInfoType == HitInfoType.RowIndent))
            {
                SeleccionClicDerecho = true;
                hitInfo.Node.Selected = !hitInfo.Node.Selected;
            }
            else
            {
                SeleccionClicDerecho = false;
            }
        }

        private void barbtnNuevoDepa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //NUEVO DEPARTAMENTO
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level != 0) return;
            crearDepartamento(oGeoSeleccionado);
        }

        private void barbtnEditarDepa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level != 1) return;
            editarCelda();
        }

        private void treGeo_SelectionChanged(object sender, EventArgs e)
        {
            treGeo.OptionsBehavior.Editable = false;
        }

        private void barbtnEliminarDepa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level != 1) return;
            eliminarGeo(oGeoSeleccionado);
        }

        private void barbtnEliminarProvincia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level != 2) return;
            eliminarGeo(oGeoSeleccionado);
        }

        private void barbtnEliminarDistrito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            oGeoSeleccionado = GeoActual();
            if (oGeoSeleccionado.Level != 3) return;
            eliminarGeo(oGeoSeleccionado);
        }

        private void btnAdministrarBuzones_Click(object sender, EventArgs e)
        {

        }
    }
}