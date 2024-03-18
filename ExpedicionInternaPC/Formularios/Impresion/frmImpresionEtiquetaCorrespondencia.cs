using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using ExpedicionInternaPC.Properties;
using ImpresionZebra;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace ExpedicionInternaPC
{
    public partial class frmImpresionEtiquetaCorrespondencia : frmChild
    {

        #region variable

        int contadorAgregados = -1;
        private const int iBandeja = 0;
        List<Objeto> listaMasdeUnaImpresion = new List<Objeto>();
        private DataTable listaCustodiados = new DataTable();
        private List<Objeto> listaCustodiadosObjeto = new List<Objeto>();
        private List<Objeto> listaPorImprimir = new List<Objeto>();
        private List<Objeto> listaCreadoObjetos = new List<Objeto>();

        #endregion

        #region metodos

        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            try
            {
                CargarCorrespondenciaCreado();
            }
            catch (InvalidTokenException)
            {

                throw;
            }

        }
        //2022
        private void Agregar()
        {
            String autogenerado = txtAutogenerado.Text.Trim();

            if (autogenerado.Length == 0)
            {
                Program.mensaje("Ingrese el código del elemento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAutogenerado.SelectAll();
                this.Focus();
                return;
            }

            if (autogenerado.Length < 6)
            {
                Program.mensaje(string.Format("No se encontraron resultados. Verifique código ingresado."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutogenerado.Text = "";
                txtAutogenerado.Focus();
            }

            Objeto obj = listaPorImprimir.Find(hol => hol.Autogenerado == autogenerado);

            if (obj != null)
            {
                Program.mensaje("Se encuentra Seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Focus();
                return;
            }


            obj = listaCreadoObjetos.Find(hol => hol.Autogenerado == autogenerado);

            if (obj == null)
            {
                /*Busca autogenerado en la Base de Datos*/
                try
                {
                    List<Objeto> lObjE = Metodos.ValidarEstadoObjeto(txtAutogenerado.Text.Trim());

                    if (lObjE.Count == 0)
                    {
                        Program.mensaje(string.Format("No se encontraron resultados. Verifique código ingresado."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAutogenerado.SelectAll();
                        this.Focus();
                        txtAutogenerado.Focus();
                        return;
                    }

                    Objeto ObjE = lObjE[0];

                    if (ObjE != null)
                    {
                        if (ObjE.IdTipoEstado == (int)EstadoObjeto.CREADO)
                        {
                            /*Verifico si es de mi expedicion responsable*/
                            if (ObjE.IdExpedicionResponsable == Program.oUsuario.IdExpedicion)
                            {

                                listaCreadoObjetos.Add(ObjE);
                                Agregar();
                                this.Focus();
                                return;
                            }
                            else
                            {
                                Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1}, la expedicion responsable es : {2}.", ObjE.Autogenerado, ObjE.Estado.ToUpper(), ObjE.DescripcionExpedicionResponsable), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtAutogenerado.SelectAll();
                                this.Focus();
                                return;
                            }
                        }
                        else if (ObjE.IdTipoEstado == (int)EstadoObjeto.CUSTODIA)
                        {
                            Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por la expedicion : {2}.", ObjE.Autogenerado, ObjE.Estado.ToUpper(), ObjE.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAutogenerado.SelectAll();
                            this.Focus();
                            txtAutogenerado.Focus();
                            return;
                        }

                        else if (ObjE.IdTipoEstado == (int)EstadoObjeto.RUTA)
                        {
                            Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por la expedicion : {2}.", ObjE.Autogenerado, ObjE.Estado.ToUpper(), ObjE.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAutogenerado.SelectAll();
                            this.Focus();
                            txtAutogenerado.Focus();
                            return;
                        }
                        else if (ObjE.IdTipoEstado == (int)EstadoObjeto.RETIRADO)
                        {
                            Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por la expedicion : {2}.", ObjE.Autogenerado, ObjE.Estado.ToUpper(), ObjE.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAutogenerado.SelectAll();
                            this.Focus();
                            txtAutogenerado.Focus();
                            return;
                        }
                        /*Objeto estado = "recibido,confirmado"*/
                        else
                        {
                            Program.mensaje(String.Format("El autogenerado : {0} se encuentra en estado {1} por {2} que se encuentra en : {3}.", ObjE.Autogenerado, ObjE.Estado.ToUpper(), ObjE.CasillaPara, ObjE.DescripcionExpedicionCustodia), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAutogenerado.SelectAll();
                            this.Focus();
                            txtAutogenerado.Focus();
                            return;
                        }
                    }

                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception ex)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar validar el autogenerado.");
                    return;
                }
            }

            frmObjetoEtiqueta ofrm = new frmObjetoEtiqueta() { obj = obj };
            ofrm.ShowDialog(Program.oMain);
            if (ofrm.DialogResult == DialogResult.No)
            {
                txtAutogenerado.Select();
                txtAutogenerado.Focus();
                return;
            }
            obj.SeleccionGrafica = true;
            listaPorImprimir.Add(obj);
            imprimirListas();
            grdPorImprimir.RefreshDataSource();
            txtAutogenerado.Text = "";
            txtAutogenerado.Focus();


        }
        //2022
        private void ValidarAutogeneradoKeyDown(KeyEventArgs e)
        {
            if (txtAutogenerado.Text.Trim().Length > 0 && txtAutogenerado.Text.Trim().Length < 6 && e.KeyData == Keys.Enter)
            {
                Program.mensaje("No se encontraron resultados. Verifique código ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Focus();
                txtAutogenerado.SelectAll();
                txtAutogenerado.Focus();
                return;
            }
            if (txtAutogenerado.Text.Trim().Length <= 20 && e.KeyData == Keys.Enter)
            {
                Agregar();
            }
        }
        //2022
        private void imprimirListas()
        {

            if (listaPorImprimir.Count() > 0)
            {
                Objeto O = new Objeto();
                O.ListaXML = O.SerializeObjectWindows(listaPorImprimir);
                Objeto ORES = new Objeto();
                try
                {
                    ORES = Metodos.uObjetoImpresoXML1(O.ListaXML);
                    String xml = ORES.ListaXML;

                    XmlDocument docx = new XmlDocument();
                    docx.LoadXml(xml);
                    XmlNodeList Personas = docx.GetElementsByTagName("ARRAYOFOBJETO");
                    XmlNodeList lista = ((System.Xml.XmlElement)Personas[0]).GetElementsByTagName("t");
                    foreach (System.Xml.XmlElement nodo in lista)
                    {
                        XmlNodeList ID = nodo.GetElementsByTagName("ID");
                        XmlNodeList sysncOk = nodo.GetElementsByTagName("LOTE");
                        XmlNodeList iImpreso = nodo.GetElementsByTagName("IMPRESO");
                        XmlNodeList sEstado = nodo.GetElementsByTagName("ESTADO");
                        /* sysncOk = 0 >> CORRECTO ; sysncOk = 1 >> SEPARAR ; */
                        int iid = Convert.ToInt32(ID[0].InnerText);
                        Objeto oOO = new Objeto();
                        oOO = listaPorImprimir.Find(p => p.ID == iid);
                        if (Convert.ToInt32(sysncOk[0].InnerText) == 1)
                        {
                            oOO.Estado = Convert.ToString(sEstado[0].InnerText);
                            oOO.Impreso = Convert.ToInt32(iImpreso[0].InnerText);
                            listaMasdeUnaImpresion.Add(oOO);
                            listaPorImprimir.Remove(oOO);

                        }
                        else
                        {
                            ZebraZpl zpl = new ZebraZpl();
                            imprimirZebra(oOO);
                            listaPorImprimir.Remove(oOO);
                        }
                    }
                    try
                    {
                        CargarCorrespondenciaCreado();
                    }
                    catch (InvalidTokenException)
                    {

                        throw;
                    }


                    if (listaMasdeUnaImpresion.Count > 0)
                    {
                        frmImpresionControl frmcontrol = new frmImpresionControl();
                        frmcontrol.LlenarGrilla(listaMasdeUnaImpresion);
                        frmcontrol.ShowDialog();

                    }

                    listaMasdeUnaImpresion.Clear();
                    contadorAgregados = 0;
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception e)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar imprimir.");
                }

            }
            else
            {
                Program.mensaje("Por favor seleccione por lo menos un autogenerado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }

        }
        //2022
        private void VistaPrevia(Objeto oO)
        {
            frmEtiquetaAutogenedoModelo fea = new frmEtiquetaAutogenedoModelo(oO);
            fea.Show();
        }
        //2022
        public void imprimirZebra(Objeto oO)
        {
            try
            {
                EtiquetaCustodia etiqueta = new EtiquetaCustodia();

                etiqueta.De = oO.De.ToUpper();
                etiqueta.AreaOrigen = oO.AreaOrigen;
                etiqueta.Origen = oO.Origen.ToUpper();
                etiqueta.Para = oO.Para.ToUpper();
                etiqueta.AreaDestino = oO.AreaDestino;
                etiqueta.Destino = oO.sDestino;
                etiqueta.Autogenerado = oO.Autogenerado.ToUpper();
                etiqueta.Prefijo = oO.Prefijo.ToUpper();
                //VistaPrevia(oO);
                ZebraZpl zpl = new ZebraZpl() { NOMBRE_IMPRESORA = Settings.Default["RutaImpresoraZebra"].ToString() };
                string s = zpl.etiquetaCustodia(etiqueta.De, etiqueta.AreaOrigen, etiqueta.Origen, etiqueta.Para, etiqueta.AreaDestino, etiqueta.Destino, etiqueta.Autogenerado, etiqueta.Prefijo);
                zpl.imprimirEtiqueta(s);

            }
            catch
            {
                Program.mensaje("Este documento no tiene ninguna referencia.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //2022
        public void CargarCorrespondenciaCreado()
        {
            Program.ShowPopWaitScreen();
            try
            {
                listaCreadoObjetos = Metodos.CorrespondenciaPorCustodiarJSON3(Program.oUsuario.IdExpedicion);
                gridCheckOut.DataSource = listaCreadoObjetos;
                grdPorImprimir.DataSource = listaPorImprimir;
                gridCheckOut.Refresh();
                grdPorImprimir.Refresh();
                gridView1.RefreshData();
                gridView3.RefreshData();
                Program.HidePopWaitScreen();
            }
            catch (InvalidTokenException)
            {
                Program.HidePopWaitScreen();
                Program.mensaje("El token no es válido. Inicie sesión nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar listar los registros");
            }

        }
        //2022
        public override void ExportExcel(String FileName)
        {
            gridCheckOut.ExportToXls(FileName);
        }

        #endregion


        public frmImpresionEtiquetaCorrespondencia()
        {
            InitializeComponent();
            txtAutogenerado.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void frmImpresionEtiquetaCorrespondencia_Load(object sender, EventArgs e)
        {
            CargarCorrespondenciaCreado();
            cboForma.SelectedIndex = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Agregar();
            }
            catch
            {
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                frmBuscarDocumento frmBDU = new frmBuscarDocumento(listaCreadoObjetos, grdPorImprimir, gridView1, gridView3, listaPorImprimir);
                frmBDU.ShowDialog();
                if (listaPorImprimir.Count() >= 3)//tengo que modificar aqui para que coja en bloque
                {
                    imprimirListas();
                }
            }
            catch
            {
            }
        }

        private void btnImprimirLista_Click(object sender, EventArgs e)
        {
            imprimirListas();
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            ValidarAutogeneradoKeyDown(e);
        }

        private void cboForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboForma.SelectedIndex == 0)
            {
                this.layoutControlItem11.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
                this.layoutControlItem11.AppearanceItemCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(68)))), ((int)(((byte)(0)))));
                layoutControlItem11.Text = "Manual";
                layoutControlItem11.Image = global::ExpedicionInternaPC.Properties.Resources.scriptedit32;
                btnAgregar.Enabled = true;
                btnAgregar.Visible = true;
                txtAutogenerado.Visible = true;
                txtAutogenerado.Enabled = true;
                lblAutogenerado.Enabled = true;
                lblAutogenerado.Visible = true;
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
            else
            {

                layoutControlItem11.Text = "Seleccion";
                layoutControlItem11.Image = global::ExpedicionInternaPC.Properties.Resources.investmentmenuquality32;
                this.layoutControlItem11.AppearanceItemCaption.BackColor = System.Drawing.Color.White;
                this.layoutControlItem11.AppearanceItemCaption.BackColor2 = System.Drawing.Color.Goldenrod;
                lblAutogenerado.Enabled = true;
                lblAutogenerado.Visible = false;
                btnAgregar.Enabled = false;
                btnAgregar.Visible = false;
                txtAutogenerado.Enabled = false;
                txtAutogenerado.Visible = false;
                layoutControlItem1.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutControlItem2.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void gridView3_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gridView3.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;

                }

                Objeto obj = (Objeto)gridView3.GetFocusedRow();

                Objeto resul = listaPorImprimir.Find(hol => hol.Autogenerado == obj.Autogenerado);

                if (listaPorImprimir.Count >= 0)
                {
                    if (resul != null)
                    {
                        obj.SeleccionGrafica = false;
                        listaPorImprimir.Remove(obj);
                        grdPorImprimir.RefreshDataSource();
                        contadorAgregados--;

                    }
                    else
                    {
                        if (obj.Impreso > 0)
                        {
                            contadorAgregados++;
                            obj.SeleccionGrafica = true;
                            listaPorImprimir.Add(obj);
                            grdPorImprimir.RefreshDataSource();
                        }
                        else
                        {
                            contadorAgregados++;
                            obj.SeleccionGrafica = true;
                            listaPorImprimir.Add(obj);
                            grdPorImprimir.RefreshDataSource();
                        }

                    }

                }
            }
            catch
            {
                return;
            }
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            Objeto oO = (Objeto)gridView3.GetFocusedRow();
            oO.IdTipoEntrega = 1;
            Metodos.VerTracking(oO);
        }

        private void repositoryItemHyperLinkEdit2_Click(object sender, EventArgs e)
        {
            Objeto oO = (Objeto)gridView1.GetFocusedRow();
            oO.IdTipoEntrega = 1;
            Metodos.VerTracking(oO);
        }

        private void gridView3_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oCol = null;
                Boolean tipo = false;
                try
                {
                    oCol = (GridColumn)View.Columns["SeleccionGrafica"];
                }
                catch (Exception)
                {
                    Program.mensajeError("Escoge una fila");
                }

                if (oCol != null)
                {
                    try
                    {
                        tipo = Convert.ToBoolean(View.GetRowCellValue(e.RowHandle, oCol));
                    }
                    catch (Exception)
                    {

                    }
                }

                if (tipo == true)
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.BackColor2 = Color.Goldenrod;
                }
                else if (tipo == false)
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.BackColor2 = Color.White;
                }
            }


        }

        private void gridView2_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (gridView1.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }
                Objeto oO = (Objeto)gridView1.GetFocusedRow();
                if (listaPorImprimir.Count >= 0)
                {
                    if (listaPorImprimir.Count == 0)
                    {
                        if (oO != null)
                        {
                            oO.SeleccionGrafica = true;
                            listaPorImprimir.Add(oO);
                        }
                        else
                            return;
                    }
                    else
                    {
                        var obj = listaPorImprimir.Find(hol => hol.Autogenerado == oO.Autogenerado);
                        if (listaPorImprimir[0].Estado == "CUSTODIA")
                        {

                            if (obj == null)
                            {
                                oO.SeleccionGrafica = true;
                                listaPorImprimir.Add(oO);
                            }
                            else
                                listaPorImprimir.Remove(oO);
                        }
                        else
                        {

                            if (obj == null)
                            {
                                listaPorImprimir.ForEach(x => ((Objeto)listaCreadoObjetos.Find(hol => hol.Autogenerado == x.Autogenerado)).SeleccionGrafica = false);
                                listaPorImprimir.Clear();
                                oO.SeleccionGrafica = true;
                                listaPorImprimir.Add(oO);
                                gridView1.RefreshData();
                                gridCheckOut.RefreshDataSource();
                            }
                            Program.mensaje("Si seleccionas autogenerados de diferentes estado se deseleccionaran los autogenerados anteriores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Focus();
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void repositoryItemHyperLinkEdit3_Click(object sender, EventArgs e)
        {

        }

        private void frmImpresionEtiquetaCorrespondencia_Activated(object sender, EventArgs e)
        {

        }

        private void frmImpresionEtiquetaCorrespondencia_Deactivate(object sender, EventArgs e)
        {

        }
    }
}