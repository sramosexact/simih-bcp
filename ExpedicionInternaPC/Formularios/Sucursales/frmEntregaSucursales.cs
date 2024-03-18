using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Interna.Core;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Respuesta = System.Windows.Forms.DialogResult;

namespace ExpedicionInternaPC
{
    public partial class frmEntregaSucursales : frmChild
    {
        #region Variables

        const int ASOCIADO = 1;
        const int NOASOCIADO = 0;
        int Validado = 0;
        int iEstado = 0;
        public Entrega oEntrega;
        public List<Palomar> lPalomaresTodos;
        public List<Objeto> lEntregaObjeto = new List<Objeto>();
        public List<Objeto> lValidados = new List<Objeto>();
        public TipoEntrega oTipoEntrega;
        private string CARPETA_DESTINO = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\";

        #endregion

        #region Metodos

        //2022
        public void LlenarResumen()
        {
            int iTotal = lEntregaObjeto.Count;
            int iValidados = lEntregaObjeto.FindAll(x => x.idTipoValidacion == 72).ToList().Count;
            int iNoValidados = iTotal - iValidados;

            lblEntrega.Text = oEntrega.ID.ToString();
            lblTotal.Text = iTotal.ToString();
            lblValidados.Text = iValidados.ToString();
            lblPorValidar.Text = iNoValidados.ToString();
            this.Text = "Entrega Sucursal | Estado : " + oEntrega.EstadoDescripcion.ToUpper();
        }
        //2022
        public void ExportExcel()
        {
            SaveFileDialog oSave = new SaveFileDialog();

            oSave.Filter = "Archivos Excel|*.xls";
            oSave.FilterIndex = 1;
            oSave.RestoreDirectory = true;

            if (oSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    this.grdEntregaObjeto.ExportToXls(oSave.FileName);
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = oSave.FileName;
                    process.Start();
                }
                catch (Exception ex)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar exportar.");
                    ErrorLog oe = new ErrorLog();
                    oe.EscribirLog(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        //2022
        private void CargarFormularioBD()
        {
            List<string> ls = new List<string>();

            try
            {
                ls = Metodos.EntregaDetalle(oEntrega.ID);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los registros.");
                return;
            }

            oEntrega = Metodos.deserializarPrueba<Entrega>(ls[0])[0];
            lEntregaObjeto = Metodos.deserializarPrueba<Objeto>(ls[1]);
            this.grdEntregaObjeto.DataSource = lEntregaObjeto;
            this.grdEntregaObjeto.RefreshDataSource();
            this.grvEntregaObjeto.RefreshData();
            //Se utilizará para validar si existen cambios sin guardar al cerrar el formulario
            lValidados = lEntregaObjeto.FindAll(x => x.idTipoValidacion == 72).ToList();
            LlenarResumen();

            switch (iEstado)
            {

                case (int)EntregaEstado.Grabado: //Creado                    
                    btnGrabar.Text = "Grabar";
                    break;
                default:
                    string estado = oEntrega.EstadoDescripcion;
                    btnGrabar.Enabled = false;
                    btnValidar.Enabled = false;
                    btnRecargar.Enabled = false;
                    btnRetirar.Enabled = false;
                    txtAutogenerado.Enabled = false;

                    break;
            }
            grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }
        //2022
        public void CargarFormularioVista()
        {
            if (oEntrega != null)
            {
                iEstado = oEntrega.Estado;
            }

            this.grdEntregaObjeto.DataSource = lEntregaObjeto;
            this.grdEntregaObjeto.RefreshDataSource();
            this.grvEntregaObjeto.RefreshData();
            //Se utilizará para validar si existen cambios sin guardar al cerrar el formulario
            lValidados = lEntregaObjeto.FindAll(x => x.idTipoValidacion == 72).ToList();
            LlenarResumen();

            switch (iEstado)
            {

                case (int)EntregaEstado.Grabado: //Creado                    
                    btnGrabar.Text = "Grabar";
                    break;
                default:
                    string estado = oEntrega.EstadoDescripcion;
                    btnGrabar.Enabled = false;
                    btnValidar.Enabled = false;
                    btnRecargar.Enabled = false;
                    btnRetirar.Enabled = false;
                    txtAutogenerado.Enabled = false;

                    break;
            }
            grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }
        //2022
        public void validar()
        {
            if (txtAutogenerado.Text.Trim().Length >= 6)
            {
                Objeto o = lEntregaObjeto.Find(x => x.Autogenerado == txtAutogenerado.Text.Trim());
                if (o != null)
                {
                    if (o.idTipoValidacion == 72)
                    {
                        Program.mensaje("El elemento ya se encuentra validado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAutogenerado.Focus();
                        txtAutogenerado.SelectAll();
                    }
                    else
                    {
                        if (o.iIdGeoDestinoAnterior != 0)
                        {
                            Program.mensaje("El destino del elemento ha sido cambiado, retírelo de la entrega e imprima nuevamente su etiqueta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAutogenerado.Focus();
                            txtAutogenerado.SelectAll();
                            return;
                        }
                        else
                        {
                            o.idTipoValidacion = 72;
                            o.fechaValidacion = DateTime.Now;
                            grvEntregaObjeto.RefreshData();
                            grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                            LlenarResumen();
                            txtAutogenerado.Text = "";
                            txtAutogenerado.Focus();
                            txtAutogenerado.SelectAll();
                            Program.ok.PlaySync();
                            Validado += 1;
                            lblCambio.Appearance.BackColor = Color.White;
                            lblCambio.Appearance.BackColor2 = Color.FromArgb(255, 84, 27);
                        }

                    }
                }
                else
                {
                    Objeto objetoAVerificarGeoAnterior = new Objeto();
                    objetoAVerificarGeoAnterior.Autogenerado = txtAutogenerado.Text.Trim();
                    try
                    {
                        objetoAVerificarGeoAnterior = Metodos.ListarGeoAnteriorDeObjeto(objetoAVerificarGeoAnterior);
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar cargar los autogenerados que han cambiado de ubicación destino.");
                        return;
                    }

                    if (objetoAVerificarGeoAnterior != null)
                    {
                        if (objetoAVerificarGeoAnterior.iIdGeoDestinoAnterior != 0)
                        {
                            Program.mensaje("El destino del elemento ha sido cambiado, imprima nuevamente su etiqueta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAutogenerado.Focus();
                            txtAutogenerado.SelectAll();
                            return;
                        }
                    }

                    Program.mensaje("El código ingresado no se encuentra en la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAutogenerado.Focus();
                    txtAutogenerado.SelectAll();
                }
            }
            else
            {
                Program.mensaje("Por favor, ingrese correctamente el código.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAutogenerado.Focus();
                txtAutogenerado.SelectAll();
            }

        }
        //2022
        private void Desvalidar(object sender, EventArgs e)
        {

            if (oEntrega.Estado != 1)
            {
                Program.mensaje(String.Format("No se puede quitar la validación al autogenerado ya que la entrega se encuentra en estado : {0}", oEntrega.EstadoDescripcion), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Activate();
                return;
            }
            Objeto Oo = (Objeto)grvEntregaObjeto.GetFocusedRow();
            if (Oo.idTipoValidacion == 72)
            {
                Objeto oo = lEntregaObjeto.Find(hol => hol.ID == Oo.ID);
                Oo.idTipoValidacion = 0;
                Oo.fechaValidacion = DateTime.Parse("0001-01-01");
                this.grdEntregaObjeto.RefreshDataSource();
                grvEntregaObjeto.RefreshData();
                grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                LlenarResumen();
                Validado += 1;
                lblCambio.Appearance.BackColor = Color.White;
                lblCambio.Appearance.BackColor2 = Color.FromArgb(255, 84, 27);
            }
            else
            {
                Program.mensaje("El elemento seleccionado no está validado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }

        }
        //2022
        private void guardarCambios()
        {
            if (Validado > 0)
            {
                List<ObjetoSucursal> objetosEntregaSucursal = new List<ObjetoSucursal>();

                foreach (Objeto objetoEntrega in lEntregaObjeto)
                {
                    ObjetoSucursal objetoSucursal = new ObjetoSucursal();
                    objetoSucursal.ID = objetoEntrega.ID;
                    objetoSucursal.TipoValidacion = objetoEntrega.idTipoValidacion;
                    objetosEntregaSucursal.Add(objetoSucursal);
                }

                Objeto o = new Objeto();
                string detalle = o.SerializeObjectWindows(objetosEntregaSucursal);

                int res = 0;
                try
                {
                    res = Metodos.ValidarEntregaSucursal(oEntrega.ID, detalle);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar guardar los cambios.");
                    return;
                }

                if (res > 0)
                {
                    CargarFormularioBD();
                    Validado = 0;
                    lblCambio.Appearance.BackColor = Color.White;
                    lblCambio.Appearance.BackColor2 = Color.White;
                    frmListaEntregaSucursal fx = (frmListaEntregaSucursal)Program.SetFormActive<frmListaEntregaSucursal>("Entrega Sucursales", Program.oMain);
                    fx.listarEntregasSucursalActivas();
                    Program.mensaje("La grabación ha sido exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                    this.Close();

                }
                else if (res == -2)
                {
                    Program.mensaje("La Entrega se encuentra actualmente en otro estado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                }
                else if (res == -3)
                {
                    Program.mensaje("La Entrega tiene elementos que han cambiado de destino. Retírelos para que pueda continuar el proceso.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarFormularioBD();
                    Validado = 0;
                    lblCambio.Appearance.BackColor = Color.White;
                    lblCambio.Appearance.BackColor2 = Color.White;
                    this.Activate();
                }
                else
                {
                    Program.mensaje("No se ha podido realizar la acción solicitada.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                }
            }
            else
            {
                Program.mensaje("La grabación ha sido exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }

            txtAutogenerado.Text = "";
            txtAutogenerado.Focus();
            txtAutogenerado.SelectAll();

        }
        //2022
        public void recargarDatos()
        {
            try
            {
                Metodos.RecargarEntregaSucursal(oEntrega.ID);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar recargar los registros de la entrega");
                return;
            }

            List<string> ls = new List<string>();
            List<Objeto> lEntregaRecarga = new List<Objeto>();
            List<Objeto> lNuevoDetalle = new List<Objeto>();

            try
            {
                ls = Metodos.EntregaDetalle(oEntrega.ID);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar recargar los registros de la entrega");
                return;
            }

            if (ls.Count > 0)
            {
                lEntregaRecarga = Metodos.deserializarPrueba<Objeto>(ls[1]);
                lNuevoDetalle = lEntregaRecarga.Where(hol => lEntregaObjeto.Find(x => x.ID == hol.ID) == null).ToList();

                if (lNuevoDetalle.Count > 0)
                {
                    lNuevoDetalle.Select(c => { c.idTipoValidacion = 0; c.fechaValidacion = DateTime.Parse("0001-01-01"); return c; }).ToList();
                    lEntregaObjeto.AddRange(lNuevoDetalle);
                    this.grdEntregaObjeto.DataSource = lEntregaObjeto;
                    this.grdEntregaObjeto.RefreshDataSource();
                    this.grvEntregaObjeto.RefreshData();
                    grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                    LlenarResumen();
                    frmListaEntregaSucursal fx = (frmListaEntregaSucursal)Program.SetFormActive<frmListaEntregaSucursal>("Entrega Sucursales", Program.oMain);
                    fx.listarEntregasSucursalActivas();
                }
                else
                {
                    Program.mensaje("No existen más elementos en CUSTODIA para añadir a la entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                }
            }

            txtAutogenerado.Text = "";
            txtAutogenerado.Focus();
            txtAutogenerado.SelectAll();

        }
        //2022
        public void retirarDatos()
        {
            Objeto o = new Objeto();
            List<Objeto> lSinValidar = new List<Objeto>();
            lSinValidar = lEntregaObjeto.Where(x => x.idTipoValidacion == 0).ToList();

            if (lSinValidar.Count == lEntregaObjeto.Count)
            {
                if (Program.mensaje("No ha validado ningún elemento. Se eliminará la entrega. \n ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == Respuesta.Yes)
                {
                    this.Activate();
                    //Eliminar entrega

                    int resultado = 0;

                    try
                    {
                        resultado = Metodos.EliminarEntregaSucursal(oEntrega.ID);
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar retirar eliminar la entrega.");
                        return;
                    }

                    if (resultado > 0)
                    {
                        Validado = 0;
                        Program.mensaje(string.Format("La Entrega '{0}' ha sido eliminada correctamente.", oEntrega.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = Respuesta.Abort;
                        this.Close();
                        return;
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
                else
                {
                    this.Activate();
                    return;
                }
            }

            if (lSinValidar.Count == 0)
            {
                Program.mensaje("No hay elementos a retirar de la entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }

            if (Program.mensaje(string.Format("Se eliminarán {0} elementos de la entrega. \n ¿Desea continuar?", lSinValidar.Count), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == Respuesta.No)
            {
                this.Activate();
                return;
            }
            this.Activate();
            lEntregaObjeto.RemoveAll(x => x.idTipoValidacion == 0);
            CargarFormularioVista();
            LlenarResumen();
            Validado += 1;
            lblCambio.Appearance.BackColor = Color.White;
            lblCambio.Appearance.BackColor2 = Color.FromArgb(255, 84, 27);

        }
        //2022
        public void limpiarDatos()
        {
            lEntregaObjeto = new List<Objeto>();
            grdEntregaObjeto.DataSource = lEntregaObjeto;
        }
        //2022
        private void verSeguimiento()
        {
            Objeto oO = (Objeto)this.grvEntregaObjeto.GetFocusedRow();
            oO.IdTipoEntrega = 1;
            Metodos.VerTracking(oO);
        }
        //2022
        private void verificaCambios()
        {
            if (Validado > 0)
            {
                if (Program.mensaje(string.Format("No ha grabado los cambios realizados. ¿Desea grabar?", lValidados.Count), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == Respuesta.Yes)
                {
                    this.Activate();
                    guardarCambios();
                }
                this.Activate();
            }
        }
        //2022
        private void validarTexto(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAutogenerado.Text.Trim().Count() > 5)
                {
                    validar();
                }
            }
        }

        #endregion


        public frmEntregaSucursales()
        {
            InitializeComponent();
            txtAutogenerado.Properties.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void frmEntregaSucursales_Load(object sender, EventArgs e)
        {
            Validado = 0;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            validar();
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            validarTexto(e);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            guardarCambios();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            retirarDatos();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            recargarDatos();
        }

        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            verSeguimiento();
        }

        private void frmEntregaSucursales_FormClosed(object sender, FormClosedEventArgs e)
        {
            verificaCambios();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void grvEntregaObjeto_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oCol = null;
                GridColumn oColID = null;

                int tipo = 0;
                int ID = 0;

                try
                {
                    oCol = (GridColumn)View.Columns["idTipoValidacion"];//----------------CAMBIAR
                    oColID = (GridColumn)View.Columns["ID"];
                }
                catch (Exception) { }

                if (oCol != null)
                {
                    try
                    {
                        tipo = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oCol).ToString());
                        ID = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oColID).ToString());
                    }
                    catch (Exception) { }

                    if (oEntrega == null)
                    {
                        return;

                    }

                    if (tipo >= 1)
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.Goldenrod;
                    }
                    else if (tipo == 0)
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.White;
                    }
                }

            }
        }

        private void lnkDesvalidar_Click(object sender, EventArgs e)
        {
            if (iEstado == 1)
            {
                Desvalidar(sender, e);
            }
        }

        private void grvEntregaObjeto_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oColGeoDestinoAnterior = null;
                GridColumn oColAutogenerado = null;

                int id_geo_anterior = 0;

                try
                {
                    oColGeoDestinoAnterior = (GridColumn)View.Columns["iIdGeoDestinoAnterior"];
                    oColAutogenerado = (GridColumn)View.Columns["Autogenerado"];
                }
                catch (Exception) { }

                if (oColGeoDestinoAnterior != null)
                {
                    try
                    {
                        id_geo_anterior = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oColGeoDestinoAnterior).ToString());
                    }
                    catch (Exception) { }


                    if (id_geo_anterior > 0)
                    {
                        if (e.Column.FieldName == "idTipoValidacion")
                        {
                            e.Appearance.BackColor = Color.White;
                            e.Appearance.BackColor2 = Color.LightCoral;
                        }

                    }
                    else if (id_geo_anterior == 0)
                    {
                        if (e.Column.FieldName == "idTipoValidacion")
                        {
                            e.Appearance.BackColor = Color.Transparent;
                            e.Appearance.BackColor2 = Color.Transparent;
                        }
                    }
                }

            }
        }

    }
}

