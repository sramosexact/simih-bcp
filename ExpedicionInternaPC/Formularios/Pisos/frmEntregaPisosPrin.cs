using DevExpress.XtraGrid.Views.Grid;
using DevicesMobile;
using Interna.Entity;
//using WindowsPortableDevicesLib;
//using WindowsPortableDevicesLib.Domain;
//using InTheHand.Windows.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmEntregaPisosPrin : frmChild
    {

        #region Variables

        List<Entrega> lEntregas = new List<Entrega>();
        List<Entrega> lEntregaSeleccionadas = new List<Entrega>();
        static string strRutaOrigen = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
        static string strRutaDestino = "\\Flash File Store\\";
        static string strRutaDestinoAndroid = "/storage/emulated/0/xml_exact/";
        static string strFilePisos = "SSED_EOP_DET.TXT";
        static string strFilePisosResult = "SSED_EOP_DETALLE.TXT";

        #endregion

        #region ARCHIVO-TXT
        private List<ObjetoPiso> LeerArchivoTexto(Proceso TipoDispositivo, Entrega entregaSeleccionada)
        {
            List<ObjetoPiso> resultadoEntregaPisoList = new List<ObjetoPiso>();

            try
            {
                using (StreamReader SRFile = new StreamReader(strRutaOrigen + strFilePisosResult))
                {
                    string strLine = string.Empty;

                    while ((strLine = SRFile.ReadLine()) != null)
                    {
                        string[] strCampos = strLine.Split('|');
                        string strNroLote = strCampos[0];
                        string strAutogenerado = strCampos[1];
                        string strDniColaborador = strCampos[2];
                        string strTipoDocumento = strCampos[3];
                        string strFechaEntrega = strCampos[4];
                        string strHoraEntrega = strCampos[5];
                        string strUsuarioDestino = strCampos[6];
                        string strCodigoEntregadoEn = strCampos[7];
                        string strObservacionEntrega = strCampos[8];
                        string strFechaHora = string.Format("{0} {1}:{2}:{3}", strFechaEntrega, strHoraEntrega.Substring(0, 2), strHoraEntrega.Substring(2, 2), strHoraEntrega.Substring(4, 2));

                        if (strNroLote == entregaSeleccionada.ID.ToString())
                        {
                            var resultadoPiso = resultadoEntregaPisoList.Find(correspondencia => (correspondencia.Autogenerado == strAutogenerado.Trim()));

                            if (resultadoPiso == null)
                            {
                                ObjetoPiso correspondenciaPiso = new ObjetoPiso();
                                correspondenciaPiso.Autogenerado = strAutogenerado;
                                correspondenciaPiso.EntregaFecha = strFechaEntrega;
                                correspondenciaPiso.EntregaHora = strHoraEntrega;
                                correspondenciaPiso.EntregaIdentificacion = strCodigoEntregadoEn;
                                correspondenciaPiso.EntregaObservacion = strObservacionEntrega;
                                correspondenciaPiso.EntregaFecha = strFechaHora;
                                if (TipoDispositivo == Proceso.UTILIZAPDA)
                                {
                                    correspondenciaPiso.seleccion = "PDA";
                                    correspondenciaPiso.IdTipoResultado = (int)Proceso.UTILIZAPDA;
                                }
                                else
                                {
                                    correspondenciaPiso.seleccion = "DPM";
                                    correspondenciaPiso.IdTipoResultado = (int)Proceso.UTILIZADPM;
                                }

                                resultadoEntregaPisoList.Add(correspondenciaPiso);
                            }
                        }
                    }
                    if (resultadoEntregaPisoList.Count > 0)
                    {
                        return resultadoEntregaPisoList;
                    }
                    else
                    {
                        return null;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //2022
        private void LeerArchivoPisosTxt(Proceso TipoDispositivo, Entrega entregaSeleccionada)
        {
            if (entregaSeleccionada == null) return;
            if (entregaSeleccionada.ID == 0) return;

            List<Objeto> correspondenciaEntregaDB = null;
            List<ObjetoPiso> correspondenciaResultadoFinal = new List<ObjetoPiso>();
            List<ObjetoPiso> correspondenciaResultado;

            Entrega entrega = lEntregas.Find(hol => hol.ID == entregaSeleccionada.ID);

            if (entrega == null)
            {
                Program.mensaje(String.Format("La entrega seleccionada no se encuetra en la lista de entregas. Recargue la lista de entregas."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }
            if (entrega.Estado == 2)
            {
                Program.mensaje(String.Format("No se puede importar la entrega, se encuentra en estado {0}", "Ruta"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }
            else if (entrega.Estado == 1)
            {
                Program.mensaje(String.Format("No se puede importar la entrega, se encuentra en estado {0}", "Creado"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }

            if (entrega.Exportado <= 0)
            {
                Program.mensaje(String.Format("No se puede importar la entrega, no ha sido exportada."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }

            try
            {
                correspondenciaResultado = LeerArchivoTexto(TipoDispositivo, entregaSeleccionada);
                if (correspondenciaResultado == null)
                {
                    Program.mensaje(String.Format("La entrega que exportó del PDA no es la misma que la entrega seleccionada."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                    return;
                }

                correspondenciaEntregaDB = Metodos.rObtenerDocumentosPorEntregaJson(new Entrega() { ID = entregaSeleccionada.ID });
                if (correspondenciaEntregaDB == null || correspondenciaEntregaDB.Count == 0)
                {
                    Program.mensaje(String.Format("La entrega que deseas importar no se encuentra disponible."), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                    return;
                }

                foreach (ObjetoPiso correspondencia in correspondenciaResultado)
                {
                    Objeto correspondenciaEncontrada = correspondenciaEntregaDB.Find(hol => (hol.Autogenerado == correspondencia.Autogenerado.Trim()));
                    if (correspondenciaEncontrada != null) correspondenciaResultadoFinal.Add(correspondencia);
                }

                if (correspondenciaResultadoFinal.Count == 0)
                {
                    Program.mensaje("No se puede importar la entrega ya que no ha entregado ningún documento.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Focus();
                    return;
                }

                entregaSeleccionada.Importado = Metodos.ExportarImportarMovilModo(entregaSeleccionada.ID, 2, (int)Proceso.UTILIZAPDA);

                if (entregaSeleccionada.Importado == (int)Proceso.UTILIZAPDA)
                {
                    Objeto oOxml = new Objeto();
                    oOxml.IdEntrega = entregaSeleccionada.ID;
                    oOxml.Detalle = JsonConvert.SerializeObject(correspondenciaResultadoFinal);  // oOxml.SerializeObjectWindows(lstObjetoResultado);
                    int resultado = Metodos.ImportarResultadoPisosPDA(oOxml);
                    MessageBox.Show(resultado.ToString());
                }

                frmEntregaPisosResultado frm = new frmEntregaPisosResultado();
                frm.oO = entregaSeleccionada;
                frm.CargarDetalle();
                if (frm.ShowDialog(this.Parent) == DialogResult.OK)
                {
                    CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                    lEntregaSeleccionadas.Clear();
                }

            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        //2022
        private bool GenerarArchivoPisosTxt(List<Objeto> listaDetalle)
        {

            if (listaDetalle == null) return false;
            if (listaDetalle.Count == 0) return false;

            try
            {
                StreamWriter SWFilePisos = new StreamWriter(strRutaOrigen + strFilePisos);
                foreach (Objeto objObjeto in listaDetalle)
                {
                    string strNroLote = objObjeto.IdEntrega.ToString();                     // "EOP-SIS-000" + iRow;    // Lote
                    string strIdObjet = objObjeto.Autogenerado;                        // "001G20" + iRow;         // Autogenerado
                    string strDniOper = objObjeto.IdUsuario.ToString();                 // "10328139";              // DNI del operativo
                    string strTipoDoc = objObjeto.sTipoElemento;                            // "OTRO";                  // Tipo de documento
                    string strEntFcha = string.Empty;                                       // fecha entrega
                    string strEntHora = string.Empty;                                       // hora de entrega
                    string strUsuario = objObjeto.IdOficinaEntrega.ToString();          //  <----- por verificar // objObjeto.PuntoEntrega //objObjeto.IdCasillaPara.ToString();                 // "000025";                // usuario destino
                    string strDniRecb = string.Empty;                                       // DNI del que recibe o matricula del que recibe o el codigo de bandeja
                    string strObserva = string.Empty;                                       // Observaciones
                    SWFilePisos.WriteLine(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", strNroLote, strIdObjet, strDniOper, strTipoDoc, strEntFcha, strEntHora, strUsuario, strDniRecb, strObserva));
                }
                SWFilePisos.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region ANDROID
        //2022
        public void ExportarAndroid()
        {
            string resultadoAndroid = string.Empty;
            bool estaGenerado = false;

            if (lEntregaSeleccionadas.Count == 0)
            {
                Program.mensaje("No ha seleccionado ninguna entrega.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }

            Entrega oEntrega = lEntregaSeleccionadas[0];

            if (oEntrega.Estado != 1)
            {
                Program.mensaje("Solo se pueden exportar entregas en estado CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }

            try
            {
                if (oEntrega.Total == oEntrega.idTipoValidacion)
                {
                    DialogResult resp;
                    if (oEntrega.Exportado == (int)Proceso.UTILIZAPDA || oEntrega.Exportado == (int)Proceso.UTILIZADPM)
                    {
                        resp = Program.mensaje($"La entrega ya ha sido exportada. ¿Desea exportar nuevamente?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        this.Focus();
                    }
                    else
                    {
                        resp = Program.mensaje($"Ya no podrá modificar la entrega. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        this.Focus();
                    }

                    if (resp != DialogResult.Yes) return;


                    oEntrega.Exportado = Metodos.ExportarImportarMovilModo(oEntrega.ID, 1, (int)Proceso.UTILIZADPM);

                    if (oEntrega.Exportado == (int)Proceso.UTILIZADPM)
                    {
                        List<Objeto> listaDetalle = new List<Objeto>();
                        listaDetalle = Metodos.rObtenerDocumentosPorEntregaJson(oEntrega);
                        estaGenerado = GenerarArchivoPisosTxt(listaDetalle);

                        if (estaGenerado)
                        {
                            Rapi_Android.Rapi_Android adb = new Rapi_Android.Rapi_Android();

                            if (adb.copyFileToPDA(strRutaOrigen + strFilePisos, strRutaDestinoAndroid + strFilePisos, "", "C:\\platform-tools\\platform-tools\\", ref resultadoAndroid))
                            {
                                Program.mensaje("Archivo copiado al dispositivo de manera correcta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Focus();
                            }
                            else
                            {
                                Program.mensaje($@"Ha ocurrido un eror al intentar exportar el archivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        Entrega e = lEntregas.Find(hol => hol.ID == oEntrega.ID);
                        e.SeleccionGrafica = false;
                        grdDatos.DataSource = null;
                        grdDatos.DataSource = lEntregas;
                        lEntregaSeleccionadas.Clear();
                    }

                }
                else
                {
                    DialogResult res;
                    if (oEntrega.idTipoValidacion == 0)
                    {
                        res = Program.mensaje($"No puede exportar la entrega debido a que no tiene ningún elemento validado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                        return;
                    }

                    res = Program.mensaje($"Existen {(oEntrega.Total - oEntrega.idTipoValidacion)} elementos no validados, se retirarán de la entrega. ¿Desea continuar?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    this.Focus();
                    if (res == DialogResult.OK)
                    {
                        int resultado = RetirarNoValidadosDespuesDeExportar();
                        /*Entrega se quedara sin  ningun elemento*/
                        if (resultado == -1 || resultado == -3 || resultado == -2)
                        {
                            return;
                        }
                        RefrescarUnaEntrega(oEntrega);
                        if (lEntregaSeleccionadas.Count > 0)
                        {
                            int id = lEntregaSeleccionadas[0].ID;
                            Entrega Oo = lEntregas.Find(hol => hol.ID == id);
                            Oo.SeleccionGrafica = false;
                            grdDatos.DataSource = null;
                            grdDatos.DataSource = lEntregas;
                            lEntregaSeleccionadas.Clear();
                            lEntregaSeleccionadas.Add(lEntregas.Find(hol => hol.ID == id));
                            lEntregas.Find(hol => hol.ID == id).SeleccionGrafica = true;
                            grvPisos.RefreshData();
                            grdDatos.RefreshDataSource();
                        }
                        ExportarAndroid();
                    }
                    else
                    {
                        lEntregas.Find(hol => hol.ID == oEntrega.ID).SeleccionGrafica = false;
                        grdDatos.DataSource = null;
                        grdDatos.DataSource = lEntregas;
                        lEntregaSeleccionadas.Clear();
                        return;
                    }
                }
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        //2022
        public void ImportarAndroid()
        {
            string resultado = string.Empty;

            try
            {
                Entrega entregaSeleccionada = null;
                entregaSeleccionada = lEntregaSeleccionadas[0];
                Rapi_Android.Rapi_Android adb = new Rapi_Android.Rapi_Android();
                bool respuesta = adb.copyFileToDesktop(strRutaOrigen + strFilePisosResult, strRutaDestinoAndroid + strFilePisosResult, "", ref resultado);
                if (respuesta) LeerArchivoPisosTxt(Proceso.UTILIZADPM, entregaSeleccionada);
                else MessageBox.Show("No se pudo descargar el archivo !! :( ->" + resultado);
            }
            catch (FormatException)
            {
                Program.mensaje(String.Format("El archivo a importar está en un formato incorrecto, intente nuevamente."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Focus();
                return;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                this.Focus();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar importar el archivo.");
                this.Focus();
                return;
            }
        }

        #endregion


        #region WINDOWS-MOBILE
        //2022
        private void ExportarPDA()
        {
            bool estaGenerado = false;

            if (lEntregaSeleccionadas.Count == 0)
            {
                Program.mensaje("No ha seleccionado ninguna entrega.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }

            Entrega oEntrega = lEntregaSeleccionadas[0];

            if (oEntrega.Estado != 1)
            {
                Program.mensaje("Solo puede exportar entregas en estado CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }

            try
            {


                if (oEntrega.Total == oEntrega.idTipoValidacion)
                {
                    DialogResult resp;
                    if (oEntrega.Exportado == (int)Proceso.UTILIZAPDA || oEntrega.Exportado == (int)Proceso.UTILIZADPM)
                    {
                        resp = Program.mensaje($"La entrega ya ha sido exportada. ¿Desea exportar nuevamente?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        this.Focus();
                    }
                    else
                    {
                        resp = Program.mensaje($"Ya no podrá modificar la entrega. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        this.Focus();
                    }

                    if (resp != DialogResult.Yes) return;


                    oEntrega.Exportado = Metodos.ExportarImportarMovilModo(oEntrega.ID, 1, (int)Proceso.UTILIZAPDA);
                    if (oEntrega.Exportado == (int)Proceso.UTILIZAPDA)
                    {
                        List<Objeto> listaDetalle = new List<Objeto>();
                        listaDetalle = Metodos.rObtenerDocumentosPorEntregaJson(oEntrega);
                        estaGenerado = GenerarArchivoPisosTxt(listaDetalle);

                        if (estaGenerado)
                        {
                            Rapi objPda = new Rapi();


                            if (objPda.copyFileToPDA(strRutaOrigen + strFilePisos, strRutaDestino + strFilePisos))
                            {
                                Program.mensaje("Archivo copiado al PDA.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Focus();
                            }
                            else
                            {
                                Program.mensaje($@"Ha ocurrido un error al intentar exportar el archivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                        Entrega e = lEntregas.Find(hol => hol.ID == oEntrega.ID);
                        e.SeleccionGrafica = false;
                        grdDatos.DataSource = null;
                        grdDatos.DataSource = lEntregas;
                        lEntregaSeleccionadas.Clear();
                    }


                }
                else
                {
                    DialogResult res;
                    if (oEntrega.idTipoValidacion == 0)
                    {
                        res = Program.mensaje($"No puede exportar la entrega debido a que no tiene ningún elemento validado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                        return;
                    }

                    res = Program.mensaje($"Existen {(oEntrega.Total - oEntrega.idTipoValidacion)} elementos no validados, se retirarán de la entrega. ¿Desea continuar?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    this.Focus();
                    if (res == DialogResult.OK)
                    {
                        int resultado = RetirarNoValidadosDespuesDeExportar();
                        /*Entrega se quedara sin  ningun elemento*/
                        if (resultado == -1 || resultado == -3 || resultado == -2)
                        {
                            return;
                        }
                        RefrescarUnaEntrega(oEntrega);
                        if (lEntregaSeleccionadas.Count > 0)
                        {
                            int id = lEntregaSeleccionadas[0].ID;
                            Entrega Oo = lEntregas.Find(hol => hol.ID == id);
                            Oo.SeleccionGrafica = false;
                            grdDatos.DataSource = null;
                            grdDatos.DataSource = lEntregas;
                            lEntregaSeleccionadas.Clear();
                            lEntregaSeleccionadas.Add(lEntregas.Find(hol => hol.ID == id));
                            lEntregas.Find(hol => hol.ID == id).SeleccionGrafica = true;
                            grvPisos.RefreshData();
                            grdDatos.RefreshDataSource();
                        }
                        ExportarPDA();

                    }
                    else
                    {
                        lEntregas.Find(hol => hol.ID == oEntrega.ID).SeleccionGrafica = false;
                        grdDatos.DataSource = null;
                        grdDatos.DataSource = lEntregas;
                        lEntregaSeleccionadas.Clear();
                        return;
                    }
                }

            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }




        }
        //2022
        private void ImportarPDA()
        {
            try
            {
                Entrega entregaSeleccionada = null;
                entregaSeleccionada = lEntregaSeleccionadas[0];
                Rapi objPda = new Rapi();
                objPda.copyFileToDesktop(strRutaOrigen + strFilePisosResult, strRutaDestino + strFilePisosResult);
                LeerArchivoPisosTxt(Proceso.UTILIZAPDA, entregaSeleccionada);

            }
            catch (FormatException)
            {
                Program.mensaje(String.Format("El archivo a importar está en un formato incorrecto, intente nuevamente."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Focus();
                return;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                this.Focus();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar importar el archivo.");
                this.Focus();
                return;
            }
        }

        #endregion

        #region Metodos

        //2022
        public void CargarRecorridoDePisos(TipoEntrega iTipoEntrega, int iModo)
        {
            Entrega ed = new Entrega();
            Program.ShowPopWaitScreen();
            try
            {
                lEntregas = Metodos.EntregaLista(Program.oUsuario.IdExpedicion, (int)iTipoEntrega, iModo);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

            grdDatos.DataSource = lEntregas;

            GridView gridView = grdDatos.FocusedView as GridView;
            gridView.BeginSort();
            try
            {
                gridView.ClearSorting();
                gridView.Columns["Estado"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                gridView.Columns["Registro"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

            }
            finally
            {
                gridView.EndSort();
                gridView.RefreshData();
            }
            Program.HidePopWaitScreen();

        }
        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            try
            {
                CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                lEntregaSeleccionadas.Clear();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar actualizar la lista de entregas.");
            }
        }
        //2022
        public override void ExportExcel(String FileName)
        {
            grdDatos.ExportToXls(FileName);
        }
        //2022
        private void verObjetosEntrega(object sender, EventArgs e)
        {
            try
            {
                Entrega oO = (Entrega)grvPisos.GetFocusedRow();
                if (oO.Estado == 1)
                {
                    frmEntregaPisos frm = new frmEntregaPisos();
                    frm.oEntrega = oO;
                    if (frm.ShowDialog(this.Parent) == DialogResult.OK)
                    {
                        CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                        lEntregaSeleccionadas.Clear();
                    }
                }
                else
                {
                    frmEntregaPisosResultado frm = new frmEntregaPisosResultado();
                    frm.oO = oO;
                    frm.CargarDetalle();
                    if (frm.ShowDialog(this.Parent) == DialogResult.OK)
                    {
                        CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                        lEntregaSeleccionadas.Clear();
                    }
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar realizar la acción");
            }
        }
        //2022
        private void RefrescarUnaEntrega(Entrega oO)
        {
            int index = lEntregas.IndexOf(oO);
            try
            {
                lEntregas[index] = Metodos.rRefrescar(1, Convert.ToInt32(TipoEntrega.RECORRIDO_PISOS), oO);
                grdDatos.Refresh();
                grdDatos.RefreshDataSource();
                grvPisos.RefreshData();
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }


        }
        //2022
        private void eliminarEntrega()
        {
            if (lEntregaSeleccionadas.Count == 1)
            {
                if (lEntregaSeleccionadas[0].Estado == 1)
                {
                    DialogResult mensaje = Program.mensaje("Se eliminará la entrega. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    this.Focus();
                    if (mensaje == DialogResult.Yes)
                    {
                        int valor = 0;

                        try
                        {
                            valor = Metodos.rEliminarEntregaPisos(lEntregaSeleccionadas[0].ID);
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
                            Program.mensaje(string.Format("La entrega {0} ha sido eliminada correctamente", lEntregaSeleccionadas[0].ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Focus();
                            try
                            {
                                CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                                lEntregaSeleccionadas.Clear();
                            }
                            catch (InvalidTokenException)
                            {
                                Program.mensajeTokenInvalido();
                                return;
                            }
                            catch (Exception)
                            {
                                Program.mensajeError("Ha ocurrido un error al intentar actualizar la lista de entregas.");
                                return;
                            }


                        }

                    }
                }
                else
                {
                    Program.mensaje(string.Format("La entrega {0} no se puede eliminar porque se encuentra en estado : {1}", lEntregaSeleccionadas[0].ID, lEntregaSeleccionadas[0].EstadoDescripcion), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
        }
        //2022
        private void ModificarEntrega(object sender, EventArgs e)
        {

            if (lEntregaSeleccionadas.Count > 0)
            {
                Entrega oE = lEntregaSeleccionadas[0];
                if (oE.Estado == 1 && oE.Exportado == 0)
                {
                    frmNuevaEntregaPisos frm = new frmNuevaEntregaPisos(Convert.ToInt32(TipoEntregaForm.Modificacion));
                    frm.En = oE;
                    frm.Text = "Modificar Entrega " + oE.ID;
                    if (frm.ShowDialog(this.Parent) == DialogResult.OK)
                    {
                        try
                        {
                            CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            lEntregaSeleccionadas.Clear();
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }
                        catch (Exception)
                        {
                            Program.mensajeError("Ha ocurrido un error al intentar actualizar las lista de entregas.");
                            return;
                        }
                    }
                }
                else if (oE.Estado != 1)
                {
                    Program.mensaje(string.Format("No se puede modificar la entrega ya que se encuentra en estado : {0}.", oE.EstadoDescripcion), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
                else if (oE.Exportado != 0)
                {
                    Program.mensaje("No se puede modificar la entrega Exportada.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            else
            {
                Program.mensaje(string.Format("No ha seleccionado ninguna entrega."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Focus();
            }

        }
        //2022
        private void Exportar()
        {
            if (lEntregaSeleccionadas.Count == 0)
            {
                Program.mensaje("No ha seleccionado ninguna entrega.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }

            Entrega oEntrega = lEntregaSeleccionadas[0];
            if (oEntrega.Estado != 1)
            {
                Program.mensaje($"No puede exportar la entrega, se encuentra en estado : {oEntrega.EstadoDescripcion}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }


            TipoDispositivoMovil tipoDispositivoMovil = Program.obtenerTipoDispositivoMovilConfigurado();

            if (tipoDispositivoMovil == TipoDispositivoMovil.NO_CONFIGURADO)
            {
                Program.mensaje("La opción no se encuentra habilitada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (tipoDispositivoMovil == TipoDispositivoMovil.TODOS)
            {
                tipoDispositivoMovil = Program.seleccionarTipoDispositivoMovil();

                if (tipoDispositivoMovil == TipoDispositivoMovil.TODOS)
                {
                    return;
                }
            }

            try
            {
                if (tipoDispositivoMovil == TipoDispositivoMovil.MOVIL_PDA)
                {
                    ExportarPDA();
                }
                if (tipoDispositivoMovil == TipoDispositivoMovil.MOVIL_ANDROID)
                {
                    ExportarAndroid();
                }

            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar exportar la entrega.");
            }
        }
        //2022
        private int RetirarNoValidados()
        {
            try
            {
                int valor = Metodos.rEliminarObjetoEntregaPisos(lEntregaSeleccionadas[0].ID);
                if (valor != -2 && valor != -1)
                {
                    Program.mensaje("Se retiraron los autogenerados correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                    return valor;
                }
                else if (valor == -1)
                {
                    Program.mensaje("No se puede completar la acción. Para exportar la entrega debe existir al menos un elemento validado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.Focus(); return valor;
                }
                else
                {
                    Program.mensaje(String.Format("No se puede iniciar la entrega porque se encuentra en estado : {0}", lEntregaSeleccionadas[0].EstadoDescripcion), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                    return valor;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return -4;//<<-------------Revisar valor
            }
            catch
            {
                return -3;
            }
        }
        //2022
        private int RetirarNoValidadosDespuesDeExportar()
        {
            try
            {
                int valor = Metodos.rEliminarObjetoEntregaPisos(lEntregaSeleccionadas[0].ID);
                return valor;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return -4; //<<---------------Revisar valor
            }
            catch
            {
                return -3;
            }
        }
        //2022
        public void Importar()
        {
            if (lEntregaSeleccionadas.Count == 0)
            {
                Program.mensaje("No ha seleccionado ninguna entrega.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Focus();
                return;
            }
            if (lEntregaSeleccionadas.Count > 0)
            {
                Entrega entregaSeleccionada;
                entregaSeleccionada = lEntregaSeleccionadas[0];
                if (entregaSeleccionada.Estado == 2)
                {
                    Program.mensaje(String.Format("No se puede importar la entrega, se encuentra en estado {0}", "Ruta"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                    return;
                }
                if (entregaSeleccionada.Estado == 1)
                {
                    Program.mensaje(String.Format("No se puede importar la entrega, se encuentra en estado {0}", "Creado"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                    return;
                }
                if (entregaSeleccionada.Exportado == 0)
                {
                    Program.mensaje(String.Format("No se puede importar la entrega {0}, no ha sido exportada.", entregaSeleccionada.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                    return;
                }
            }

            TipoDispositivoMovil tipoDispositivoMovil = Program.obtenerTipoDispositivoMovilConfigurado();

            if (tipoDispositivoMovil == TipoDispositivoMovil.NO_CONFIGURADO)
            {
                Program.mensaje("La opción no se encuentra habilitada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (tipoDispositivoMovil == TipoDispositivoMovil.TODOS)
            {
                tipoDispositivoMovil = Program.seleccionarTipoDispositivoMovil();

                if (tipoDispositivoMovil == TipoDispositivoMovil.TODOS)
                {
                    return;
                }
            }

            if (tipoDispositivoMovil == TipoDispositivoMovil.MOVIL_PDA)
            {
                ImportarPDA();
            }
            if (tipoDispositivoMovil == TipoDispositivoMovil.MOVIL_ANDROID)
            {
                ImportarAndroid();
            }


        }
        //2022
        private void TerminarEntrega()
        {
            if (lEntregaSeleccionadas[0].Importado == 0)
            {
                int resultado;

                try
                {
                    resultado = Metodos.uEntregaPisosTerminar(lEntregaSeleccionadas[0].ID, Program.oUsuario.IdExpedicion, Program.oUsuario.ID);


                    if (resultado == 1)
                    {
                        Program.mensaje(string.Format("La operación ha finalizado correctamente.", lEntregaSeleccionadas[0].ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                        CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                        lEntregaSeleccionadas.Clear();
                    }
                    else
                    {
                        Program.mensaje("Ocurrio un problema en terminar la entrega. Quizas la entrega se encuentre en un estado diferente a Ruta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Focus();
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar terminar la entrega");
                    return;
                }
            }

        }

        #endregion


        public frmEntregaPisosPrin()
        {
            InitializeComponent();
        }

        private void frmEntregaPisosPrin_Load(object sender, EventArgs e)
        {
            try
            {
                CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                lEntregaSeleccionadas.Clear();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de entregas.");
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmNuevaEntregaPisos frm = new frmNuevaEntregaPisos(Convert.ToInt32(TipoEntregaForm.Creacion));
            try
            {
                frm.ShowDialog(this.Parent);
            }
            catch
            {
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (lEntregaSeleccionadas.Count > 0)
            {
                eliminarEntrega();
            }
            else
            {
                Program.mensaje("No ha seleccionado ninguna entrega", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Focus();
            }
        }

        private void grvPisos_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (grvPisos.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }

                Entrega obj = (Entrega)grvPisos.GetFocusedRow();

                if (obj != null)
                {

                    if (lEntregaSeleccionadas.Count == 0)
                    {
                        obj.SeleccionGrafica = true;
                        lEntregaSeleccionadas.Add(obj);
                        grdDatos.Refresh();
                        grvPisos.RefreshData();
                    }
                    else
                    {
                        lEntregas.Find(hol => hol.ID == lEntregaSeleccionadas[0].ID).SeleccionGrafica = false;
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
                        grvPisos.RefreshData();
                    }
                }
            }
            catch
            {
                return;
            }
        }
        //2022
        private void btnIniciarEntrega_Click(object sender, EventArgs e)
        {
            if (lEntregaSeleccionadas.Count > 0)
            {
                Entrega en = lEntregaSeleccionadas[0];

                if (en.Estado == 2)
                {
                    Program.mensaje(string.Format("No se puede iniciar la entrega, se encuentra en estado RUTA", en.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                    return;
                }
                if (en.Estado == 3)
                {
                    Program.mensaje(string.Format("No se puede iniciar la entrega, se encuentra en estado TERMINADO", en.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                    return;
                }

                if (en.Exportado == (int)Proceso.UTILIZAPDA || en.Exportado == (int)Proceso.UTILIZADPM || en.Exportado == 1)
                {
                    if ((en.Total - en.idTipoValidacion) != 0)
                    {
                        DialogResult resp = Program.mensaje(string.Format("No puede iniciar la entrega debido a que no tiene ningún elemento validado"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        this.Focus();
                        if (resp == DialogResult.Yes)
                        {
                            RetirarNoValidados();
                        }
                        else
                        {
                            return;
                        }
                    }

                    int resultado;

                    try
                    {
                        resultado = Metodos.uEntregaPisosIniciar(en.ID, Program.oUsuario.ID, Program.oUsuario.IdExpedicion, Program.oUsuario.idCasilla);
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

                    try
                    {
                        if (resultado != -2)
                        {
                            CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            lEntregaSeleccionadas.Clear();
                            Program.mensaje(string.Format("La entrega {0} se ha iniciado correctamente.", en.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Focus();
                        }
                        else
                        {

                            CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            lEntregaSeleccionadas.Clear();


                        }
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar actualizar la lista de entregas.");
                        return;
                    }
                }
                else
                {
                    DialogResult resp = Program.mensaje(string.Format("La entrega no ha sido exportada. Una vez que inicie la entrega cambiará a estado RUTA y no podrá exportarla. ¿Desea continuar?", en.ID), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    this.Focus();
                    if (resp == DialogResult.Yes)
                    {
                        if (en.idTipoValidacion == 0)
                        {
                            Program.mensaje(string.Format("No puede iniciar la entrega debido a que no tiene ningún elemento validado.", en.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Focus();
                            return;
                        }

                        if ((en.Total - en.idTipoValidacion) != 0)
                        {
                            DialogResult resp1 = Program.mensaje(string.Format("Existen {0} elementos no validados, se retirarán de la entrega. ¿Desea continuar?", (en.Total - en.idTipoValidacion)), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            this.Focus();
                            if (resp1 == DialogResult.Yes)
                            {
                                RetirarNoValidados();
                            }
                            else
                            {
                                return;
                            }
                        }

                        int resultado = 0;
                        try
                        {
                            resultado = Metodos.uEntregaPisosIniciar(en.ID, Program.oUsuario.ID, Program.oUsuario.IdExpedicion, Program.oUsuario.idCasilla);
                            if (resultado != -2)
                            {
                                Program.mensaje(string.Format("La entrega {0} se ha iniciado correctamente.", en.ID), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Focus();
                            }
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }
                        catch (Exception)
                        {
                            Program.mensajeError("Ha ocurrido un error al intentar iniciar la entrega.");
                            return;
                        }

                        try
                        {
                            CargarRecorridoDePisos(TipoEntrega.RECORRIDO_PISOS, 1);
                            lEntregaSeleccionadas.Clear();
                        }
                        catch (InvalidTokenException)
                        {
                            Program.mensajeTokenInvalido();
                            return;
                        }
                        catch (Exception)
                        {
                            Program.mensajeError("Ha ocurrido un error al intentar actualizar la lista de entregas.");
                            return;
                        }
                    }
                }
            }
            else
            {
                Program.mensaje("No ha seleccionado ninguna entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Focus();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            Importar();
        }

        private void btnTerminarEntrega_Click(object sender, EventArgs e)
        {
            if (lEntregaSeleccionadas.Count > 0)
            {
                if (lEntregaSeleccionadas[0].Exportado != 0 && lEntregaSeleccionadas[0].Estado == 2)
                {
                    TerminarEntrega();
                }
                else if (lEntregaSeleccionadas[0].Exportado == 0 && lEntregaSeleccionadas[0].Estado == 2)
                {

                    TerminarEntrega();
                }
                else if (lEntregaSeleccionadas[0].Estado == 1)
                {
                    Program.mensaje("No se puede terminar la entrega, se encuentra en estado CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                }
                else
                {
                    Program.mensaje("No se puede terminar la entrega, se encuentra en estado TERMINADO.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Focus();
                }
            }
            else
            {
                Program.mensaje("No ha seleccionado ninguna entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Focus();
            }
        }

        private void frmEntregaPisosPrin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }



    }
}
