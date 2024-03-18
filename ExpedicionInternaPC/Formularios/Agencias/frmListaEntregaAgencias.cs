using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevicesMobile;
using ExpedicionInternaPC.Formularios.Agencias;
using Interna.Entity;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;



namespace ExpedicionInternaPC.Formularios.Expedicion
{
    public partial class frmListaEntregaAgencias : frmChild
    {

        #region Variables
        //public IList<WindowsPortableDevice> devicess;
        //public ThreadStart th;
        //public Thread thr;
        //public bool encuentraLibreriaMobil;

        //StandardWindowsPortableDeviceService _Movil;

        private List<Entrega> loEntrega;
        public Usuario oUsuario;

        static string strRutaOrigen = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
        static string strRutaDestino = "\\Flash File Store\\";
        static string strRutaDestinoAndroid = "/storage/emulated/0/xml_exact/";
        static string strFileOficinas = "SSED_VPO_DET.TXT";
        static string strFileOficinasResult = "SSED_VPO_DETALLE.TXT";

        #endregion

        #region Metodos

        //2022
        public override void Actualizar(string CommandName)
        {
            base.Actualizar(CommandName);
            listarEntregasAgencia();
        }
        //2022
        public override void ExportExcel(String FileName)
        {
            grdDatos.ExportToXlsx(FileName);
        }
        //2022
        public void listarEntregasAgencia()
        {
            try
            {
                loEntrega = Metodos.ListarEntregaGrupoAgencia(Program.oUsuario.IdExpedicion);
                grdDatos.DataSource = loEntrega;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de entregas.");
                return;
            }

        }
        //2022
        private void nuevaEntregaAgencia()
        {
            frmNuevaEntregaAgencias fx = new frmNuevaEntregaAgencias();
            fx.iEstado = EntregaEstado.Nuevo;
            fx.Text = ".:: Nueva Entrega de Agencias";
            fx.lEntregasYaCreadas = this.loEntrega;
            if (fx.ShowDialog(this.Parent) == System.Windows.Forms.DialogResult.Yes)
            {
                listarEntregasAgencia();
            }
        }
        //2022
        private void verDetalle()
        {
            int ie = ((Entrega)grvDatos.GetFocusedRow()).iIdEntregaGrupo;
            List<string> ls = new List<string>();
            try
            {
                ls = Metodos.EntregaGrupoAgenciaDetalle(ie);

                if (ls.Count > 0)
                {
                    String tag = $"Entrega {ie}";

                    frmEntregaAgencias frmEp = new frmEntregaAgencias();
                    frmEp.oEntrega = Metodos.deserializarPrueba<Entrega>(ls[0])[0];

                    frmEp.lEntregaObjeto = Metodos.deserializarPrueba<Objeto>(ls[1]);
                    frmEp.Tag = tag;
                    frmEp.Text = $"Lote {ie}";
                    frmEp.oTipoEntrega = TipoEntrega.ENVIO_AGENCIAS;
                    frmEp.cargarFormulario();
                    frmEp.ShowDialog(this.Parent);
                }
                else
                {
                    Program.mensaje("Vacio", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Program.mensajeError("Ha ocurrido un error al intentar obtener información del lote.");
                return;
            }

        }
        //2022
        private void iniciarEntregaAgencia()
        {

            List<Entrega> lEntregaSeleccionadas = new List<Entrega>();
            lEntregaSeleccionadas = loEntrega.FindAll(x => x.SeleccionGrafica == true).ToList();

            if (lEntregaSeleccionadas.Count > 0)
            {
                List<Entrega> lEntregasValidadas = new List<Entrega>();
                List<Entrega> lEntregasSinValidar = new List<Entrega>();
                lEntregasValidadas = lEntregaSeleccionadas.FindAll(x => x.idTipoValidacion > 0).ToList();
                lEntregasSinValidar = lEntregaSeleccionadas.FindAll(x => x.noRecibido > 0).ToList();


                if (lEntregasSinValidar.Count == lEntregaSeleccionadas.Count)
                {
                    if (lEntregaSeleccionadas.Count > 1) Program.mensaje("Se canceló la acción. Existen elementos sin validar en todas los lotes seleccionados.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else Program.mensaje("Se canceló la acción. Existen elementos sin validar en el lote seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    this.Activate();
                    return;
                }


                if (lEntregasSinValidar.Count > 0)
                {
                    if (Program.mensaje(string.Format("Ha seleccionado {0} lote. \nSin embargo, no se iniciarán {1} lotes," +
                    " debido a que no tienen todos sus elementos validados. ¿Desea continuar?", lEntregaSeleccionadas.Count, lEntregasSinValidar.Count), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        this.Activate();
                        return;
                    }


                    this.Activate();
                }
                else
                {

                    if (Program.mensaje(string.Format("Se iniciarán {0} lotes. ¿Desea continuar?", lEntregaSeleccionadas.Count), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        this.Activate();
                        return;
                    }
                    this.Activate();
                }

                Entrega ee = new Entrega();
                try
                {

                    int resultado = Metodos.IniciarLoteAgenciasGrupo(ee.SerializeObjectWindows(lEntregasValidadas));

                    if (resultado > 0)
                    {
                        listarEntregasAgencia();
                        Program.mensaje("Operación realizada de forma satisfactoria.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Activate();
                    }
                    else
                    {
                        Program.mensaje("No se ha podido realizar la acción. Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Activate();
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception ex)
                {
                    Program.mensajeError($"Ha ocurrido un error al intentar iniciar los lotes: {ex.Message}");
                }

            }
            else
            {
                Program.mensaje("No ha seleccionado ninguna entrega", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }



        }
        //2022
        private void eliminarEntrega()
        {

            List<Entrega> lEntregaSeleccionadas = new List<Entrega>();
            lEntregaSeleccionadas = loEntrega.FindAll(x => x.SeleccionGrafica == true).ToList();

            if (lEntregaSeleccionadas.Count > 0)
            {

                if (Program.mensaje(string.Format("Eliminará {0} lote(s) de entrega(s). ¿Desea continuar?", lEntregaSeleccionadas.Count), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Activate();
                    // Modificar 
                    Entrega ee = new Entrega();
                    try
                    {
                        int resultado = Metodos.EliminarEntregaAgencia(ee.SerializeObjectWindows(lEntregaSeleccionadas));

                        if (resultado > 0)
                        {
                            listarEntregasAgencia();
                            Program.mensaje(string.Format("Se ha(n) eliminado correctamente {0} entrega(s).", resultado), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Activate();
                            if (btnSelecion.Text == "Desmarcar")
                            {
                                btnSelecion.Text = "Seleccionar";
                                this.btnSelecion.Image = global::ExpedicionInternaPC.Properties.Resources.todolistchekedall32;
                            }
                        }
                        else if (resultado == 0)
                        {
                            Program.mensaje("No se pudo realizar la acción. Solo debe seleccionar entregas en estado CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Activate();
                        }
                        else
                        {
                            Program.mensaje("No se ha podido realizar la acción. Intente nuevamente", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        Program.mensajeError("Ha ocurrido un error al intentar eliminar la entrega");
                        return;
                    }

                }
                this.Activate();
            }
            else
            {
                Program.mensaje("No ha seleccionado ninguna entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }

        }
        //2022
        private void ExportarPDA(Proceso TipoDispositivo)
        {
            Boolean boolCopy = false;
            string resultadoAndroid = string.Empty;

            Entrega oEntrega = new Entrega();
            List<Objeto> ListaAutogeneradosPDA = new List<Objeto>();

            frmSeleccionarColaborador frm = new frmSeleccionarColaborador();

            frm.ShowDialog(this);
            oUsuario = frm.oUsuario;
            if (frm.DialogResult != DialogResult.OK)
            {
                return;
            }

            List<Entrega> lEntregaUsuario = loEntrega.FindAll(x => x.IdColaborador == oUsuario.ID).ToList();

            if (lEntregaUsuario.Count == 0)
            {
                Program.mensaje("El colaborador seleccionado no está asociado a ninguna entrega de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                return;
            }

            try
            {
                ListaAutogeneradosPDA = Metodos.ListarObjetosPDA(oEntrega.SerializeObjectWindows(lEntregaUsuario));
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar los datos para exportar.");
                return;
            }

            if (loEntrega.Count == 0)
            {
                Program.mensaje("No hay entregas en la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                return;
            }
            if (ListaAutogeneradosPDA.Count == 0)
            {
                Program.mensaje("Todos los documentos se encuentran validados por Móvil o PDA.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                return;
            }

            try
            {
                RetirarObjetosConGeoCambiado(ListaAutogeneradosPDA, true);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar retirar los registros con destino cambiado.");
                return;
            }


            List<int> lEntregasExportadas = new List<int>();
            StreamWriter SWFileOficinas = new StreamWriter(strRutaOrigen + strFileOficinas);
            foreach (Objeto objObjeto in ListaAutogeneradosPDA)
            {
                string strNroLote = objObjeto.IdEntrega.ToString();                     // "EOP-SIS-000" + iRow;    // Lote
                string strIdObjet = objObjeto.Autogenerado;                             // "001G20" + iRow;         // Autogenerado
                string strEmpleId = objObjeto.IdCasillaDe.ToString();                   // Empleado codigo.
                string strEmpleNom = objObjeto.CasillaDe;                               // Empleado Nombre.
                string strEntFcha = string.Empty;                                       // fecha entrega
                string strEntHora = string.Empty;                                       // hora de entrega
                string strAgencia = objObjeto.IdPalomarPara.ToString().PadLeft(6, '0'); // Codigo de Agencia
                string strAgeNombre = objObjeto.Palomar;                                // Nombre de Agencia.
                string strAgeInput = string.Empty;                                      // Agencia.
                string strTipoDoc = objObjeto.sTipoElemento;                            // Autogenerado - Tipo de documento.
                string strObserva = string.Empty;                                       // Observaciones
                SWFileOficinas.WriteLine(string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}", strNroLote, strIdObjet, strEmpleId, strEmpleNom, strEntFcha, strEntHora, strAgencia, strAgeNombre, strAgeInput, strTipoDoc, strObserva));
                int entregaYaExistente = 0;
                entregaYaExistente = lEntregasExportadas.Find(x => x == objObjeto.IdEntrega);
                if (entregaYaExistente == 0)
                {
                    lEntregasExportadas.Add(objObjeto.IdEntrega);
                    try
                    {
                        Metodos.ExportarImportarMovilModo(objObjeto.IdEntrega, 1, (int)Proceso.UTILIZAPDA);
                    }
                    catch (Exception) { }

                    loEntrega.ForEach(x =>
                    {
                        if (x.ID == objObjeto.IdEntrega)
                        {
                            x.Exportado = 73;
                        }
                    });
                }
            }

            SWFileOficinas.Close();

            if (TipoDispositivo == Proceso.UTILIZAPDA)
            {
                Rapi objPda = new Rapi();
                try
                {
                    boolCopy = objPda.copyFileToPDA(strRutaOrigen + strFileOficinas, strRutaDestino + strFileOficinas);
                    if (boolCopy)
                    {
                        Program.mensaje("Archivo copiado al PDA.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();

                    }
                    else
                    {
                        Program.mensaje($@"Error copiando al PDA.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {
                    Program.mensaje("Error copiando al PDA.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }
            else
            {
                Rapi_Android.Rapi_Android adb = new Rapi_Android.Rapi_Android();
                try
                {
                    bool respuesta = adb.copyFileToPDA(strRutaOrigen + strFileOficinas, strRutaDestinoAndroid + strFileOficinas, "", "C:\\platform-tools\\platform-tools\\", ref resultadoAndroid);
                    if (respuesta)
                    {
                        Program.mensaje("Archivo copiado al dispositivo de manera correcta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                    }
                    else
                    {
                        Program.mensaje($@"Error copiando al dispositivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Program.mensaje($"Error copiando al dispositivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                }
            }

        }
        //2022
        private void RetirarObjetosConGeoCambiado(List<Objeto> ListaAutogeneradosPDA, bool Exportacion)
        {
            List<Objeto> lObjetosConGeoCambiado = new List<Objeto>();
            Objeto objeto = new Objeto();
            try
            {
                lObjetosConGeoCambiado = Metodos.ListarObjetosGeoCambiadoDeAgencia(objeto.SerializeObjectWindows(ListaAutogeneradosPDA));

                if (lObjetosConGeoCambiado == null)
                {
                    Program.mensaje("Ha ocurrido un error en la conexión. Contáctese con su administrador de red", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Activate();
                    return;
                }

                if (lObjetosConGeoCambiado.Count == 0)
                {
                    return;
                }

                if (lObjetosConGeoCambiado[0].ID == -1)
                {
                    Program.mensaje("Ha ocurrido un error. Inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Activate();
                    return;
                }

                if (lObjetosConGeoCambiado[0].ID != 0)
                {

                    //var query = (from p in lObjetosConGeoCambiado
                    //             join pts in ListaAutogeneradosPDA on p.Autogenerado equals pts.Autogenerado
                    //             select p).Distinct().ToList();

                    frmElementosDeGeoCambiado frm2 = new frmElementosDeGeoCambiado();
                    frm2.lObjetosConGeoCambiado = lObjetosConGeoCambiado;
                    frm2.Exportacion = Exportacion;
                    frm2.ShowDialog(Parent);
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
        private void ImportarPDA(Proceso TipoDispositivo)
        {
            int resultado = 0;
            string resultadoAndroid = string.Empty;

            Entrega oEntrega = new Entrega();
            List<Objeto> ListaAutogeneradosPDA = new List<Objeto>();



            if (TipoDispositivo == Proceso.UTILIZAPDA)
            {
                Rapi objPda = new Rapi();

                try
                {
                    bool resPda = objPda.copyFileToDesktop(strRutaOrigen + strFileOficinasResult, strRutaDestino + strFileOficinasResult);

                    if (resPda)
                    {
                        Program.mensaje("Archivo importado de manera correcta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                    }
                    else
                    {
                        Program.mensaje($"Error al importar desde el PDA.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Program.mensaje($"Error al importar desde el PDA.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                    return;
                }

            }
            else
            {
                Rapi_Android.Rapi_Android adb = new Rapi_Android.Rapi_Android();

                try
                {
                    bool respuesta = adb.copyFileToDesktop(strRutaOrigen + strFileOficinasResult, strRutaDestinoAndroid + strFileOficinasResult, "", ref resultadoAndroid);

                    if (respuesta)
                    {
                        Program.mensaje("Archivo importado de manera correcta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                    }
                    else
                    {
                        Program.mensaje($"Error al importar desde el dispositivo.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Program.mensaje("Error al importar desde el dispositivo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Focus();
                    return;
                }

            }

            using (StreamReader SRFile = new StreamReader(strRutaOrigen + strFileOficinasResult))
            {
                string strLine = string.Empty;
                while ((strLine = SRFile.ReadLine()) != null)
                {
                    string[] strFields = strLine.Split('|');
                    string strNroLote = strFields[0];                        // "EOP-SIS-000" + iRow;    // Lote
                    string strIdObjet = strFields[1];                        // "001G20" + iRow;         // Autogenerado
                    string strEmpleId = strFields[2];                        // Empleado codigo.
                    string strEmpleNom = strFields[3];                       // Empleado Nombre.
                    string strEntFecha = strFields[4];                        // fecha entrega ---->>fechaValidacion encasillado
                    string strEntHora = strFields[5];                        // hora de entrega ---->>horaValidacion encasillado
                    string strAgencia = strFields[6];                        // Codigo de Agencia
                    string strAgeNombre = strFields[7];                      // Nombre de Agencia.
                    string strAgeInput = strFields[8];                       // Agencia.
                    string strTipoDoc = strFields[9];                        // Autogenerado - Tipo de documento.
                    string strObserva = strFields[10];                       // Observaciones                   
                    string strFechaHora = string.Format("{0}/{1}/{2} {3}:{4}:{5}", strEntFecha.Substring(0, 4), strEntFecha.Substring(4, 2), strEntFecha.Substring(6, 2), strEntHora.Substring(0, 2), strEntHora.Substring(2, 2), strEntHora.Substring(4, 2));


                    Objeto oResultadoPDA = new Objeto();

                    oResultadoPDA.Autogenerado = strIdObjet;
                    oResultadoPDA.IdEntrega = int.Parse(strNroLote);
                    oResultadoPDA.EntregaIdentificacion = strAgeInput;
                    oResultadoPDA.EntregaObservacion = strObserva;
                    if (TipoDispositivo == Proceso.UTILIZAPDA)
                    {
                        oResultadoPDA.seleccion = "PDA";
                        oResultadoPDA.idTipoValidacion = (int)Proceso.UTILIZAPDA;
                    }
                    else
                    {
                        oResultadoPDA.seleccion = "DPM";
                        oResultadoPDA.idTipoValidacion = (int)Proceso.UTILIZADPM;
                    }


                    if (strFechaHora == "") oResultadoPDA.fechaValidacion = DateTime.Now;
                    else oResultadoPDA.fechaValidacion = Convert.ToDateTime(strFechaHora);

                    ListaAutogeneradosPDA.Add(oResultadoPDA);
                }
            }

            if (ListaAutogeneradosPDA.Count == 0)
            {
                Program.mensaje("No se ha encontrado registros para importar.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Activate();
                return;
            }


            try
            {
                RetirarObjetosConGeoCambiado(ListaAutogeneradosPDA, true);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar retirar los registros con destino cambiado.");
                return;
            }

            try
            {
                resultado = Metodos.ImportarObjetosValidadosPDA(ListaAutogeneradosPDA);

                if (resultado > 0)
                {
                    Program.mensaje("Validación importada satisfactoriamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                }
                else if (resultado == 0)
                {
                    Program.mensaje("No se realizó ningún cambio. Todos los registros importados ya se encuentran validados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Activate();
                }
                else if (resultado == -2)
                {
                    Program.mensaje("No se realizó ningún cambio.Todas las entregas tienen su estado diferente a Creado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                }
                else if (resultado == -1)
                {
                    Program.mensaje("Ha ocurrido un error, revise su conexión a la red.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Activate();
                }

                this.listarEntregasAgencia();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar importar los registros validados.");
                return;
            }

        }
        //2022
        public int TransferBlueToothFile(bool subida)
        {
            return -1;
            //InTheHand.Windows.Forms
            //BluetoothDevicePicker b = new BluetoothDevicePicker();

            //var device = await b.PickSingleDeviceAsync();

            //SelectBluetoothDeviceDialog dialog = new SelectBluetoothDeviceDialog();
            //dialog.ShowAuthenticated = true;
            //dialog.ShowRemembered = true;
            //dialog.ShowUnknown = true;
            //if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            // Create client object
            BluetoothClient cli = new BluetoothClient();

            // Connect to the given device in FileTranfer mode

            BluetoothEndPoint bluetoothEndPoint = null;
            //var bluetoothService = BluetoothService.SerialPort;
            //var guidService = new Guid(dialog.SelectedDevice.InstalledServices[0].ToString());
            var guidService = BluetoothService.ObexFileTransfer; //0x1106

            //try
            //{
            //    bluetoothEndPoint = new BluetoothEndPoint(dialog.SelectedDevice.DeviceAddress, guidService);
            //    cli.Connect(bluetoothEndPoint);
            //    // Create a remote session and navigate to the bluetooth directory

            //    ObexClientSession sess = new ObexClientSession(cli.GetStream(), UInt16.MaxValue);

            //    sess.Connect(ObexConstant.Target.FolderBrowsing);
            //    // Navigate to the file location on the remote device
            //    sess.SetPath("xml_exact");

            //    // Create a filestream and write the content of the file into it, then filename is returned

            //    if (!subida)
            //    {
            //        FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\agenciaExp.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //        sess.GetTo(fs, "agenciaExp.txt", null);
            //    }
            //    else
            //    {
            //        FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\agencia.txt", FileMode.OpenOrCreate, FileAccess.Read);
            //        try
            //        {
            //            sess.Delete("agencia.txt");
            //        }
            //        catch (Exception)
            //        { }

            //        sess.PutFrom(fs, "agencia.txt", null);
            //    }

            //    return 1;

            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.Message);
            //    return -1;
            //}
            //}
            //else
            //{
            //    return -1;
            //}


        }
        //2022
        public void Importar()
        {
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

            Proceso procesoDispositivo;

            if (tipoDispositivoMovil == TipoDispositivoMovil.MOVIL_PDA)
            {
                procesoDispositivo = Proceso.UTILIZAPDA;
            }
            else
            {
                procesoDispositivo = Proceso.UTILIZADPM;
            }

            ImportarPDA(procesoDispositivo);

        }
        //2022
        private void Exportar()
        {
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

            Proceso procesoDispositivo;

            if (tipoDispositivoMovil == TipoDispositivoMovil.MOVIL_PDA)
            {
                procesoDispositivo = Proceso.UTILIZAPDA;
            }
            else
            {
                procesoDispositivo = Proceso.UTILIZADPM;
            }

            ExportarPDA(procesoDispositivo);


            grvDatos.RefreshData();
        }
        //2022
        private void Seleccionar()
        {

            if (loEntrega.Count == 0)
            {
                return;
            }

            grvDatos.LayoutChanged();

            if (btnSelecion.Text == "Seleccionar")
            {
                btnSelecion.Text = "Desmarcar";
                this.btnSelecion.Image = global::ExpedicionInternaPC.Properties.Resources.todolistcheked132;

                loEntrega.ForEach(x => x.SeleccionGrafica = true);

            }
            else
            {
                btnSelecion.Text = "Seleccionar";
                this.btnSelecion.Image = global::ExpedicionInternaPC.Properties.Resources.todolistchekedall32;
                loEntrega.ForEach(x => x.SeleccionGrafica = false);
            }

            grdDatos.RefreshDataSource();
            grvDatos.RefreshData();
        }

        #endregion


        public frmListaEntregaAgencias()
        {
            InitializeComponent();
        }

        private void frmListaEntregaAgencias_Load(object sender, EventArgs e)
        {
            listarEntregasAgencia();

        }

        private void lnkEntrega_Click(object sender, EventArgs e)
        {
            verDetalle();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            this.nuevaEntregaAgencia();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            this.Importar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.eliminarEntrega();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            this.iniciarEntregaAgencia();
        }

        private void grvDatos_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (grvDatos.FocusedColumn.FieldName != "SeleccionGrafica")
                {
                    return;
                }

                Entrega obj = (Entrega)grvDatos.GetFocusedRow();

                if (obj != null)
                {

                    Entrega oe = loEntrega.Find(x => x.iIdEntregaGrupo == obj.iIdEntregaGrupo);


                    if (oe != null)
                    {
                        if (oe.SeleccionGrafica == true)
                        {
                            oe.SeleccionGrafica = false;
                        }
                        else
                        {
                            obj.SeleccionGrafica = true;
                        }
                    }

                    grdDatos.Refresh();
                    grvDatos.RefreshData();

                }
            }
            catch
            {
                return;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmEntregaAgenciaSeg fx = new frmEntregaAgenciaSeg();
            fx.ShowDialog(this);
        }

        private void btnSelecion_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void frmListaEntregaAgencias_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void grvDatos_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oColNoRecibido = null;
                int NoRecibido = 0;

                try
                {
                    oColNoRecibido = (GridColumn)View.Columns["noRecibido"];
                }
                catch (Exception) { }

                if (oColNoRecibido != null)
                {
                    try
                    {
                        string valor = View.GetRowCellValue(e.RowHandle, oColNoRecibido).ToString();
                        NoRecibido = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oColNoRecibido).ToString());
                    }
                    catch (Exception) { }
                }

                if (NoRecibido > 0)
                {
                    if (e.Column.FieldName == "noRecibido")
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.LightCoral;
                    }

                }
                else
                {
                    if (e.Column.FieldName == "noRecibido")
                    {
                        e.Appearance.BackColor = Color.White;
                        e.Appearance.BackColor2 = Color.White;
                    }

                }

            }
        }

        private void grvDatos_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oColNoRecibido = null;
                int NoRecibido = 0;

                try
                {
                    oColNoRecibido = (GridColumn)View.Columns["noRecibido"];
                }
                catch (Exception) { }

                if (oColNoRecibido != null)
                {
                    try
                    {
                        NoRecibido = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oColNoRecibido).ToString());
                    }
                    catch (Exception) { }
                }

                if (NoRecibido > 0)
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.BackColor2 = Color.LightCoral;
                }
                else
                {
                    e.Appearance.BackColor = Color.White;
                    e.Appearance.BackColor2 = Color.White;
                }
            }
        }

        private void grvDatos_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //GridView View = sender as GridView;
            //if (e.RowHandle >= 0)
            //{
            //    GridColumn CantidadBultos = null;
            //    try
            //    {
            //        CantidadBultos = (GridColumn)View.Columns["iCantidadBultos"];
            //    }
            //    catch { }

            //    if (CantidadBultos != null)
            //    {
            //        Entrega oEntrega = new Entrega();
            //        oEntrega = (Entrega)grvDatos.GetFocusedRow();

            //        try
            //        {
            //            int resultado = Metodos.ModificarCantidadBultos(oEntrega);
            //        }
            //        catch (InvalidTokenException)
            //        {
            //            Program.mensajeTokenInvalido();
            //        }


            //    }
            //}

        }

        private void txtCantidadBultos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

        private void txtCantidadBultos_Click(object sender, EventArgs e)
        {
            ((DevExpress.XtraEditors.TextEdit)sender).SelectAll();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TransferBlueToothFile(true);
        }
    }
}

