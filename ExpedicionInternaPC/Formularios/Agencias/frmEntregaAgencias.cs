using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ExpedicionInternaPC.Formularios.Expedicion;
using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Respuesta = System.Windows.Forms.DialogResult;

namespace ExpedicionInternaPC
{
    public partial class frmEntregaAgencias : frmChild
    {

        #region Variables

        const int MANUAL = 72;
        const int MOVIL = 73;
        int Validado = 0;
        int iEstado = 0;
        public Entrega oEntrega;
        public List<Palomar> lPalomaresTodos;
        public List<Objeto> lEntregaObjeto = new List<Objeto>();
        public TipoEntrega oTipoEntrega;
        private string CARPETA_DESTINO = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
        const int TAM_CODIGO_ELEMENTO = 6;

        #endregion

        #region Metodos

        //2022
        private void ConfigurarValidacionAgencia()
        {
            if (Program.oCliente[0].iUsaPDA == 0)
            {
                lblAutogenerado.Visible = false;
                txtAutogenerado.Visible = false;
                btnValidar.Visible = false;
            }
        }
        //2022
        public void llenarResumen()
        {
            int iTotal = lEntregaObjeto.Count;
            int iValidados = lEntregaObjeto.FindAll(x => x.idTipoValidacion > 0).ToList().Count;
            int iNoValidados = iTotal - iValidados;

            lblEntrega.Text = oEntrega.iIdEntregaGrupo.ToString();
            lblTotal.Text = iTotal.ToString();
            lblValidados.Text = iValidados.ToString();
            lblPorValidar.Text = iNoValidados.ToString();
            this.Text = "Validación de Autogenerados de Entrega Agencia | Estado : " + oEntrega.EstadoDescripcion.ToUpper();
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
                    Program.mensaje(ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }


        }
        //2022
        public void validar()
        {
            if (txtAutogenerado.Text.Trim().Length <= 5)
            {
                Program.mensaje("Por favor, ingrese correctamente el código.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAutogenerado.Focus();
                txtAutogenerado.SelectAll();
                return;
            }

            if (txtAutogenerado.Text != "" && txtAutogenerado.Text.Trim().Length >= 6)
            {
                Objeto o = lEntregaObjeto.Find(x => x.Autogenerado == txtAutogenerado.Text);
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
                        o.idTipoValidacion = 72;
                        o.fechaValidacion = DateTime.Now;
                        grvEntregaObjeto.RefreshData();
                        grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                        llenarResumen();
                        txtAutogenerado.Text = "";
                        txtAutogenerado.Focus();
                        txtAutogenerado.SelectAll();
                        Program.ok.PlaySync();
                        Validado += 1;
                        lblCambio.Appearance.BackColor = Color.White;
                        lblCambio.Appearance.BackColor2 = Color.FromArgb(255, 84, 27);
                    }
                }
                else
                {
                    Objeto objetoAVerificarGeoAnterior = new Objeto();
                    objetoAVerificarGeoAnterior.Autogenerado = txtAutogenerado.Text.Trim();
                    try
                    {
                        objetoAVerificarGeoAnterior = Metodos.ListarGeoAnteriorDeObjeto(objetoAVerificarGeoAnterior);

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
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar obtener verificar la información del destino.");
                        return;
                    }

                }
            }
            else
            {
                Program.mensaje("Por favor, ingrese correctamente el código.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAutogenerado.Focus();
            }

        }
        //2022
        private void Desvalidar(object sender, EventArgs e)
        {
            if (oEntrega.Estado != 1)
            {
                Program.mensaje(String.Format("No se puede desvalidar el autogenerado ya que la entrega se encuentra en estado : {0}", oEntrega.EstadoDescripcion), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                llenarResumen();
                Validado += 1;
                lblCambio.Appearance.BackColor = Color.White;
                lblCambio.Appearance.BackColor2 = Color.FromArgb(255, 84, 27);
            }
            else if (Oo.idTipoValidacion == 73)
            {
                Program.mensaje("No se puede desvalidar un elemento validado mediante PDA.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }
            else if (Oo.idTipoValidacion == 278)
            {
                Program.mensaje("No se puede desvalidar un elemento validado mediante DPM.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }
            else
            {
                Program.mensaje("El elemento seleccionado no está validado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }

        }
        //2022
        private void guardarValidacion()
        {
            if (Validado > 0)
            {
                List<ObjetoAgencia> objetoAgencias = new List<ObjetoAgencia>();

                foreach (Objeto objeto in lEntregaObjeto)
                {
                    objetoAgencias.Add(new ObjetoAgencia(objeto.ID, objeto.idTipoValidacion, objeto.IdEntrega));
                }

                string elementosJson = JsonConvert.SerializeObject(objetoAgencias);

                try
                {
                    int res = Metodos.GrabarCambiosEntregaAgencias(oEntrega.iIdEntregaGrupo, elementosJson);

                    if (res >= 0)
                    {
                        cargarFormulario();
                        Validado = 0;
                        lblCambio.Appearance.BackColor = Color.White;
                        lblCambio.Appearance.BackColor2 = Color.White;
                        frmListaEntregaAgencias fx = (frmListaEntregaAgencias)Program.SetFormActive<frmListaEntregaAgencias>("Entrega Agencias", Program.oMain);
                        fx.listarEntregasAgencia();
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
                        Program.mensaje(string.Format("La entrega tiene elementos que ha cambiado de destino. Retírelos para que pueda continuar con el proceso."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lEntregaObjeto = Metodos.deserializarPrueba<Objeto>(Metodos.EntregaDetalle(oEntrega.ID)[1]);
                        cargarFormulario();
                        this.Activate();
                        return;
                    }
                    else
                    {
                        Program.mensaje("No se ha podido realizar la acción solicitada.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Activate();
                    }
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
            }
            else
            {
                Program.mensaje("La grabación ha sido exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                this.Close();
            }

            txtAutogenerado.Text = "";
            txtAutogenerado.Focus();
            txtAutogenerado.SelectAll();
        }

        //2023
        public void recargarElementosEntrega()
        {
            try
            {
                //int elementosAgregados = Metodos.RecargarEntregaAgencia(oEntrega.iIdEntregaGrupo);
                int elementosAgregados = Metodos.RecargarElementosEntregaAgencia(oEntrega.iIdEntregaGrupo);

                if (elementosAgregados == 0)
                {
                    Program.mensaje("No existen más elementos en CUSTODIA para añadir a la entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                    return;
                }

                List<string> ls = new List<string>();
                ls = Metodos.EntregaAgenciaDetalleGrupo(oEntrega.iIdEntregaGrupo);
                oEntrega = JsonConvert.DeserializeObject<List<Entrega>>(ls[0], new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore })[0];
                lEntregaObjeto = JsonConvert.DeserializeObject<List<Objeto>>(ls[1], new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                frmListaEntregaAgencias fx = (frmListaEntregaAgencias)Program.SetFormActive<frmListaEntregaAgencias>("Entrega Agencias", Program.oMain);
                fx.listarEntregasAgencia();
                cargarFormulario();
                Validado = 0;
                lblCambio.Appearance.BackColor = Color.White;
                lblCambio.Appearance.BackColor2 = Color.White;

            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar recargar los registros.");
                return;
            }
        }

        //2022
        public void recargarDatos()
        {
            try
            {
                Metodos.RecargarEntregaAgencia(oEntrega.iIdEntregaGrupo);
                List<string> ls = new List<string>();
                List<Objeto> lEntregaRecarga = new List<Objeto>();
                List<Objeto> lNuevoDetalle = new List<Objeto>();

                ls = Metodos.EntregaGrupoAgenciaDetalle(oEntrega.iIdEntregaGrupo);

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
                        llenarResumen();
                        frmListaEntregaAgencias fx = (frmListaEntregaAgencias)Program.SetFormActive<frmListaEntregaAgencias>("Entrega Agencias", Program.oMain);
                        fx.listarEntregasAgencia();
                        Objeto o = new Objeto();
                        string detalle = o.SerializeObjectWindows(lEntregaObjeto);
                        int res = Metodos.GuardarCambiosEntregaAgencias(oEntrega.iIdEntregaGrupo, detalle);

                        if (res >= 0)
                        {
                            cargarFormulario();
                            Validado = 0;
                            lblCambio.Appearance.BackColor = Color.White;
                            lblCambio.Appearance.BackColor2 = Color.White;

                        }
                        else if (res == -2)
                        {
                            Program.mensaje("La Entrega se encuentra actualmente en otro estado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Program.mensaje("No existen más elementos en CUSTODIA para añadir a la entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Activate();
                    }

                }

                txtAutogenerado.Text = "";
                txtAutogenerado.Focus();
                txtAutogenerado.SelectAll();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar recargar los registros.");
                return;
            }

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
                    try
                    {
                        int resultado = Metodos.EliminarEntregasAgenciaVacias(oEntrega.iIdEntregaGrupo);
                        frmListaEntregaAgencias frm = (frmListaEntregaAgencias)Program.SetFormActive<frmListaEntregaAgencias>("Entrega Agencias", Program.oMain);
                        frm.listarEntregasAgencia();

                        if (resultado > 0)
                        {
                            Validado = 0;
                            Program.mensaje(string.Format("La Entrega '{0}' ha sido eliminada correctamente.", oEntrega.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            this.DialogResult = Respuesta.Abort;
                            this.Close();
                            return;
                        }
                        else if (resultado == 0)
                        {
                            Program.mensaje("Solo se pueden eliminar Entregas en el estado CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Activate();
                            return;
                        }
                        else
                        {
                            Program.mensaje("No se ha podido realizar la acción. Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Activate();
                            return;
                        }
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar eliminar la entrega.");
                        return;
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

            lEntregaObjeto.RemoveAll(x => x.idTipoValidacion == 0);
            cargarFormulario();
            llenarResumen();
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
                if (Program.mensaje("No ha grabado los cambios realizados. ¿Desea Grabar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == Respuesta.Yes)
                {
                    this.Activate();
                    guardarValidacion();
                }
                this.Activate();
            }
        }
        //2022
        private void validarTexto(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAutogenerado.Text.Replace('_', ' ').Trim().Count() <= 5)
                    return;

                validar();
            }
        }
        //2022
        public void cargarFormulario()
        {
            frmMain frmPadre = this.MdiParent as frmMain;

            if (oEntrega != null)
            {
                iEstado = oEntrega.Estado;
            }

            switch (iEstado)
            {

                case (int)EntregaEstado.Grabado: //Creado

                    btnGrabar.Text = "Grabar";

                    this.grdEntregaObjeto.DataSource = lEntregaObjeto;
                    this.grdEntregaObjeto.RefreshDataSource();
                    this.grvEntregaObjeto.RefreshData();

                    llenarResumen();

                    break;

                default:
                    this.grdEntregaObjeto.DataSource = lEntregaObjeto;
                    this.grdEntregaObjeto.RefreshDataSource();
                    this.grvEntregaObjeto.RefreshData();
                    string estado = oEntrega.EstadoDescripcion;

                    btnGrabar.Enabled = false;
                    btnValidar.Enabled = false;
                    btnRecargar.Enabled = false;
                    btnRetirar.Enabled = false;
                    txtAutogenerado.Enabled = false;

                    llenarResumen();

                    break;
            }
            grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }

        #endregion

        public frmEntregaAgencias()
        {
            InitializeComponent();
            this.txtAutogenerado.Properties.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void frmEntregaAgencias_Load(object sender, EventArgs e)
        {
            ConfigurarValidacionAgencia();
            Validado = 0;
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            validar();
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            recargarElementosEntrega();
            //recargarDatos();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            guardarValidacion();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            retirarDatos();
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            validarTexto(e);
        }

        private void frmEntregaAgencias_FormClosed(object sender, FormClosedEventArgs e)
        {
            verificaCambios();
        }

        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            verSeguimiento();
        }

        private void grvEntregaObjeto_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oCol = null;
                int tipo = 0;

                try
                {
                    oCol = (GridColumn)View.Columns["idTipoValidacion"];
                }
                catch (Exception) { }

                if (oCol != null)
                {
                    try
                    {
                        tipo = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oCol).ToString());
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

        private void repositoryItemHyperLinkEdit3_Click(object sender, EventArgs e)
        {
            if (iEstado == 1)
            {
                Desvalidar(sender, e);
            }
        }

        private void linkAutogenerado_Click(object sender, EventArgs e)
        {
            Objeto oO = (Objeto)grvEntregaObjeto.GetFocusedRow();
            Metodos.VerTracking(oO);
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
