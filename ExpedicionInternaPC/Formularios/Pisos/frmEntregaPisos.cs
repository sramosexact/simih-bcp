using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Interna.Core;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace ExpedicionInternaPC
{
    public partial class frmEntregaPisos : frmChild
    {
        #region variables

        public Entrega oEntrega;
        public List<Objeto> lEntregaObjeto = new List<Objeto>();
        public List<Objeto> lEntregaObjetoNoModificable = new List<Objeto>();
        public int totalValidados = 0;
        public int variableModificada = 0;
        private string CARPETA_DESTINO = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\";

        #endregion

        #region Metodos
        //2022
        public override void ExportExcel(String FileName)
        {
            grdEntregaObjeto.ExportToXls(FileName);
        }
        //2022
        public void cargarFormulario()
        {
            this.Text = $"Código de Entrega: {oEntrega.ID.ToString()}";
            try
            {
                lEntregaObjeto = Metodos.rObtenerDocumentosPorEntregaJson(oEntrega);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }


            lEntregaObjetoNoModificable = lEntregaObjeto.ToList<Objeto>();
            grdEntregaObjeto.DataSource = lEntregaObjeto;
            contar();
            grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            if (oEntrega.Exportado != 0)
            {
                btnRecargar.Enabled = false;
                btnRetirar.Enabled = false;
                txtAutogenerado.Enabled = false;
                btnValidar.Enabled = false;
                btnGrabar.Enabled = false;
            }
        }
        //2022
        public void validar()
        {
            if (txtAutogenerado.Text != "" && txtAutogenerado.Text.Trim().Length >= 6)
            {
                Objeto o = lEntregaObjeto.Find(x => x.Autogenerado == txtAutogenerado.Text.Trim());
                if (o != null)
                {
                    if (o.idTipoValidacion != 72)
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
                            contar();
                            txtAutogenerado.Text = "";
                            txtAutogenerado.Focus();
                            txtAutogenerado.SelectAll();
                            Program.ok.PlaySync();
                            variableModificada = 1;
                        }

                    }
                    else
                    {
                        Program.mensaje("El elemento ya se encuentra validado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAutogenerado.Focus();
                        txtAutogenerado.SelectAll();
                        return;
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
                        Program.mensajeError("Ha ocurrido un error al intentar validar el autogenerado");
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
                    Program.mensaje("El código ingresado no se encuentra en la lista.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAutogenerado.Focus();
                    txtAutogenerado.SelectAll();
                }
            }
            else
                Program.mensaje("Por favor ingrese correctamente el código.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txtAutogenerado.Focus();
            txtAutogenerado.SelectAll();
        }
        //2022
        public void contar()
        {
            List<Objeto> loValidados = lEntregaObjeto.Where(x => x.idTipoValidacion == 72).ToList();
            txtTotalDocumentos.Text = lEntregaObjeto.Count.ToString();
            txtPorValidar.Text = (lEntregaObjeto.Count - loValidados.Count).ToString();
            txtValidados.Text = loValidados.Count.ToString();
        }
        //2022
        private void eliminarEntrega()
        {
            int valor;

            try
            {
                valor = Metodos.rEliminarEntregaPisos(oEntrega.ID);
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

            if (valor != -1)
            {
                Program.mensaje(string.Format("La entrega se ha eliminado correctamente."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                this.Close();
            }
        }
        //2022
        private void refrescar()
        {
            if (oEntrega != null)
            {
                List<Objeto> listaPorRefrescar = new List<Objeto>();
                try
                {
                    listaPorRefrescar = Metodos.rElementosPorRefrescar(oEntrega.ID);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar recargar los elemenetos de la entrega.");
                    return;
                }

                if (listaPorRefrescar == null)
                    return;
                if (listaPorRefrescar.Count != 0)
                {
                    if (listaPorRefrescar.Count != lEntregaObjeto.Count)
                    {
                        listaPorRefrescar.ForEach(hol =>
                        {
                            if (lEntregaObjeto.Find(l => l.ID == hol.ID) == null)
                            {
                                lEntregaObjeto.Add(hol);
                            }
                        });
                        grdEntregaObjeto.DataSource = null;
                        grdEntregaObjeto.DataSource = lEntregaObjeto;
                        contar();
                        variableModificada = 1;

                        List<ObjetoPisoValidacion> listaObjetoPisoValidacion = new List<ObjetoPisoValidacion>();

                        foreach (Objeto objeto in lEntregaObjeto)
                        {
                            ObjetoPisoValidacion objetoPiso = new ObjetoPisoValidacion();
                            objetoPiso.ID = objeto.ID;
                            objetoPiso.IdTipoValidacion = objeto.idTipoValidacion;
                            objetoPiso.FechaValidacion = objeto.fechaValidacion;
                            objetoPiso.IdTipoResultado = objeto.IdTipoResultado;
                            objetoPiso.FechaRecepcion = objeto.FechaRecepcion;
                            objetoPiso.IdGeoBandejaFisica = objeto.IdGeoBandejaFisica;
                            listaObjetoPisoValidacion.Add(objetoPiso);
                        }


                        Objeto oo = new Objeto();
                        oo.ListaXML = oo.SerializeObjectWindows(listaObjetoPisoValidacion);

                        int resp = 0;

                        try
                        {
                            resp = Metodos.uGrabarCambioObjetoEntregaPisos(oo.ListaXML, oEntrega.ID, 0);
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }
                        catch (Exception)
                        {
                            Program.mensajeError("Ha ocurrido un error al intentar guardar los cambios en la entrega.");
                            return;
                        }

                        if (resp != -1)
                        {
                            /*actualiza formulario que invoco este formulario*/
                            frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);
                            frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            try
                            {
                                cargarFormulario();
                            }
                            catch (InvalidTokenException)
                            {
                                Program.mensajeTokenInvalido();
                            }
                            catch (Exception)
                            {
                                Program.mensajeError("Ha ocurrido un error al intentar cargar el formulario");
                                return;
                            }

                            variableModificada = 0;
                            return;
                        }
                        else
                        {
                            Program.mensaje(string.Format("La entrega se encuentra en diferente estado."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            return;
                        }
                    }
                    else
                    {
                        Program.mensaje(string.Format("No existen más elementos en CUSTODIA para añadir a la entrega."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Activate();
                    }
                }
            }
        }
        //2022
        private void grabar()
        {
            if (variableModificada != 0)
            {
                List<ObjetoPisoValidacion> listaObjetoPisoValidacion = new List<ObjetoPisoValidacion>();

                foreach (Objeto objeto in lEntregaObjeto)
                {
                    ObjetoPisoValidacion objetoPiso = new ObjetoPisoValidacion();
                    objetoPiso.ID = objeto.ID;
                    objetoPiso.IdTipoValidacion = objeto.idTipoValidacion;
                    objetoPiso.FechaValidacion = objeto.fechaValidacion;
                    objetoPiso.IdTipoResultado = objeto.IdTipoResultado;
                    objetoPiso.FechaRecepcion = objeto.FechaRecepcion;
                    objetoPiso.IdGeoBandejaFisica = objeto.IdGeoBandejaFisica;
                    listaObjetoPisoValidacion.Add(objetoPiso);
                }

                Objeto oo = new Objeto();
                oo.ListaXML = oo.SerializeObjectWindows(listaObjetoPisoValidacion);
                int resp = 0;

                try
                {
                    resp = Metodos.uGrabarCambioObjetoEntregaPisos(oo.ListaXML, oEntrega.ID, 0);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar grabar los cambios en la entrega.");
                    return;
                }

                if (resp == 1)
                {
                    /*actualiza formulario que invoco este formulario*/
                    frmEntregaPisosPrin frm = (frmEntregaPisosPrin)Program.SetFormActive<frmEntregaPisosPrin>("Entrega Pisos", Program.oMain);

                    frm.CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                    this.Activate();
                    Program.mensaje(string.Format("La grabación ha sido exitosa."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                    try
                    {
                        cargarFormulario();
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar cargar el formulario");
                        return;
                    }
                    variableModificada = 0;
                    this.Close();
                }
                else if (resp == -3)
                {
                    Program.mensaje(string.Format("La entrega tiene elementos que ha cambiado de destino. Retírelos para que pueda continuar con el proceso."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    try
                    {
                        cargarFormulario();
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar cargar el formulario");
                        return;
                    }
                    this.Activate();
                    return;
                }
                else
                {
                    Program.mensaje(string.Format("La entrega se encuentra en diferente estado."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                    return;
                }
            }
            else
            {
                Program.mensaje(string.Format("La grabación ha sido exitosa."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                this.Close();
            }
        }
        //2022
        private int totalDocumentos()
        {
            return Int32.Parse(txtTotalDocumentos.Text);
        }
        //2022
        private int totalPorValidar()
        {
            return Int32.Parse(txtPorValidar.Text);
        }
        //2022
        private int totaldeValidados()
        {
            return Int32.Parse(txtValidados.Text);
        }
        //2022
        public void retirar()
        {
            if (totalDocumentos() != totalPorValidar())
            {
                if (totalPorValidar() == 0)
                {
                    Program.mensaje(string.Format("No hay elementos a retirar de la entrega."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                    return;
                }
                DialogResult resp = Program.mensaje(String.Format("Se eliminarán {0} elementos de la entrega. ¿Desea continuar?", (totalDocumentos() - totaldeValidados())), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                this.Activate();
                if (resp == DialogResult.Yes)
                {
                    lEntregaObjeto.RemoveAll(hol => hol.idTipoValidacion != 72);
                    grdEntregaObjeto.DataSource = null;
                    grdEntregaObjeto.DataSource = lEntregaObjeto;
                    contar();
                    variableModificada = 1;
                }
            }
            else
            {
                DialogResult res = Program.mensaje(String.Format("No ha validado ningún elemento. Se eliminará la entrega. \n¿Desea continuar?"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                this.Activate();
                if (res == DialogResult.Yes)
                {
                    eliminarEntrega();
                }
            }
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
                    Program.mensajeError("Ha ocurrido un error al intentar exportar los datos");
                    this.Activate();
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
        private void DesvalidarValidados(object sender, EventArgs e)
        {
            if (oEntrega.Exportado == 0)
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

                    Oo.idTipoValidacion = 0;
                    Oo.fechaValidacion = DateTime.Parse("1900-01-01 00:00:00.000");
                    grvEntregaObjeto.RefreshData();
                    grvEntregaObjeto.Columns["fechaValidacion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                    contar();
                    txtAutogenerado.Text = "";
                    txtAutogenerado.Focus();
                    txtAutogenerado.SelectAll();
                    Program.ok.PlaySync();
                    variableModificada = 1;
                }
                else
                {
                    Program.mensaje(String.Format("El elemento seleccionado no está validado."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Activate();
                    return;
                }
            }
        }

        #endregion


        public frmEntregaPisos()
        {
            InitializeComponent();
            this.txtAutogenerado.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void frmEntregaPisos_Load(object sender, EventArgs e)
        {
            try
            {
                cargarFormulario();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar el formulario");
                return;
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            validar();
        }

        private void grvEntregaObjeto_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oCol = null;
                GridColumn oCol2 = null;
                int tipo = 0;
                int tipoResultado = 0;

                try
                {
                    oCol = (GridColumn)View.Columns["idTipoValidacion"];
                    oCol2 = (GridColumn)View.Columns["IdTipoEstado"];
                }
                catch (Exception) { }

                if (oCol != null)
                {
                    try
                    {
                        tipo = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oCol).ToString());
                    }
                    catch (Exception) { }
                }

                if (oCol2 != null)
                {
                    try
                    {
                        tipoResultado = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oCol2).ToString());
                    }
                    catch (Exception) { }
                }
                if (oEntrega == null)
                {
                    return;

                }
                if (oEntrega.Estado > 1)
                {
                    if (tipoResultado > 3)
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.Goldenrod;
                    }
                    else if (tipoResultado == 2)
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.LightBlue;
                    }
                    else if (tipoResultado == 0)
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.White;
                    }
                }
                else if (oEntrega.Estado <= 1)
                {
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

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtAutogenerado.Text.Trim().Length >= 6 && e.KeyCode == Keys.Enter)
            {
                validar();
            }
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            refrescar();
        }

        private void btnGrabar_Click_1(object sender, EventArgs e)
        {
            grabar();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            retirar();
        }

        private void txtAutogenerado_TextChanged(object sender, EventArgs e)
        {
            if (txtAutogenerado.Text.Count() > 0)
            {
                txtAutogenerado.Text = txtAutogenerado.Text.ToUpper();
                txtAutogenerado.SelectionStart = txtAutogenerado.Text.Count();
            }
        }

        private void frmEntregaPisos_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmEntregaPisos_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*Si son diferentes en cantidad entonces se hizo un retirar o refrescar*/
            if (lEntregaObjeto.Count() != lEntregaObjetoNoModificable.Count)
            {
                DialogResult rs = Program.mensaje(string.Format("No ha grabado los cambios realizados. ¿Desea Grabar?"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                this.Activate();
                if (rs == DialogResult.Yes)
                {
                    grabar();
                }
                else
                {
                    return;
                }

            }
            else if (variableModificada == 1)
            {
                DialogResult rs = Program.mensaje(string.Format("No ha grabado los cambios realizados. ¿Desea Grabar?"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                this.Activate();
                if (rs == DialogResult.Yes)
                {
                    grabar();
                }
                else
                {
                    return;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void linkAutogenerado_Click(object sender, EventArgs e)
        {
            Objeto oO = (Objeto)grvEntregaObjeto.GetFocusedRow();
            oO.IdTipoEntrega = 1;
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
