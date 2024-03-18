using ExpedicionInternaPC.Formularios.Gestion;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExpedicionInternaPC.Formularios.Mesa_de_Partes
{
    public partial class frmCargaMasivaDocumentoEspeciales : frmChild
    {

        #region Variables

        TipoDocumento oTipoDocumento;
        List<CampoDigitalizacion> LCamposEspeciales;
        List<Casilla> ListaDestino;
        Casilla oCasillaDestino;

        #endregion

        #region Metodos

        private void CargarTipoDocumentoNoRequiereDigitalizacion()
        {
            List<TipoDocumento> TipoDocumentoList = Metodos.ListarTipoDocumentoSinDigitalizar();

            cboTipoDocumento.Properties.DataSource = TipoDocumentoList;

            cboTipoDocumento.Properties.DisplayMember = "sDescripcionTipoDocumento";

            cboTipoDocumento.Properties.ValueMember = "iIdTipoDocumento";

            cboTipoDocumento.Properties.DropDownRows = TipoDocumentoList.Count;
        }

        private void CargarDestino()
        {
            try
            {
                ListaDestino = Metodos.ListarBandejaTipoDocumento();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }


        }

        private void CargarCamposDocumentosEspeciales()
        {
            try
            {
                LCamposEspeciales = Metodos.ListarCamposActivosPorTipoDocumento(oTipoDocumento);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
        }

        private void SeleccionarArchivo()
        {
            if (cboTipoDocumento.EditValue == null)
            {
                Program.mensaje("Debe seleccionar un tipo de documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Seleccionar archivo";
            op.Filter = "Todos los archivos Excel (*.xlsx)|*.xlsx|Todos los archivos Excel 2003 (*.xls)|*.xls";
            op.Multiselect = false;
            op.InitialDirectory = "C:\\";

            if (op.ShowDialog() == DialogResult.OK)
            {
                txtRutaArchivo.Text = op.FileName;

            }
        }

        public void ValidarArchivo()
        {
            bool opc = false;

            if (txtRutaArchivo.Text.Trim().Length == 0)
            {
                Program.mensaje("Debe elegir una archivo para realizar la carga", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //int HojaDeDatos = 1;
            int numeroRegistros = 0;

            try
            {
                Program.ShowPopWaitScreen();

                //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                //app.ScreenUpdating = false;
                //Workbook wb = app.Workbooks.Open(txtRutaArchivo.Text.Trim(), 2, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, false);
                //Worksheet sh = wb.Worksheets.get_Item(HojaDeDatos);
                //Range ec = sh.UsedRange;

                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Open(txtRutaArchivo.Text.Trim());
                Excel._Worksheet sh = wb.Sheets[1];
                Excel.Range ec = sh.UsedRange;

                Documento oDocumento = new Documento();
                List<CampoExterno> CamposDocumentosEspecialesList = new List<CampoExterno>();

                try
                {

                    object[,] wArray = ec.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

                    if (wArray != null)
                    {

                        int col = wArray.GetLength(1);
                        numeroRegistros = wArray.GetLength(0) - 1;

                        if (LCamposEspeciales.Count == col)
                        {
                            for (int row = 2; row < (wArray.GetLength(0) + 1); row++)
                            {
                                int i = 1;
                                foreach (CampoDigitalizacion oCampo in LCamposEspeciales)
                                {
                                    CampoExterno oExterno = new CampoExterno();

                                    oExterno.iIdCampoDigitalizacion = oCampo.iIdCampoDigitalizacion;

                                    if (oCampo.opcional == false && Convert.ToString(wArray[row, i]).Trim().Length == 0)
                                    {
                                        Program.HidePopWaitScreen();
                                        Program.mensaje($"El campo {oCampo.sDescripcion.ToUpper()} es requerido. Complete su valor en la fila {i}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        opc = true;
                                        break;
                                    }

                                    oExterno.sValor = Convert.ToString(wArray[row, i]);

                                    oExterno.iIdDocumento = (row - 1);

                                    CamposDocumentosEspecialesList.Add(oExterno);

                                    if (oCampo.iIdentificador == 1) oDocumento.sCodigoDocumento = oExterno.sValor;


                                    i++;
                                }

                                if (opc)
                                {
                                    break;
                                }

                            }

                            if (!opc)
                            {
                                oDocumento.iIdEmpaque = (int)(oTipoDocumento.iIdTipoCorrespondencia);
                                oDocumento.iIdCasillaDe = Program.oUsuario.idCasilla;
                                oDocumento.iIdCasillaPara = oCasillaDestino.ID;
                                oDocumento.iIdUsuarioCreador = Program.oUsuario.ID;
                                oDocumento.iIdTipoDocumento = (int)(oTipoDocumento.iIdTipoDocumento);
                                oDocumento.sNombreImagen = "";

                                oDocumento.sProcedencia = "";
                                oDocumento.sObservacion = "";
                                oDocumento.Descripcion = oDocumento.SerializeObjectWindows(CamposDocumentosEspecialesList);
                            }
                        }
                        else
                        {
                            Program.HidePopWaitScreen();
                            Program.mensaje($"El archivo no tiene el formato correcto para el tipo de documento seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        Program.HidePopWaitScreen();
                        Program.mensaje($"El archivo no tiene el formato correcto para el tipo de documento seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    Program.HidePopWaitScreen();
                    Program.mensaje($"El archivo no tiene el formato correcto para el tipo de documento seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Program.HidePopWaitScreen();
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad

                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(ec);
                    Marshal.ReleaseComObject(sh);

                    //close and release
                    wb.Close();
                    Marshal.ReleaseComObject(wb);

                    //quit and release
                    app.Quit();
                    Marshal.ReleaseComObject(app);



                    //if (ec != null)
                    //{
                    //    ec = null;
                    //}

                    //if (wb != null)
                    //{
                    //    wb.Close(0);
                    //    //wb.Close(false, txtRutaArchivo.Text.Trim(), Missing.Value);
                    //    wb = null;
                    //}

                    //if (app != null)
                    //{
                    //    //app.DisplayAlerts = true;
                    //    app.Quit();
                    //    app = null;
                    //}

                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                    //Cursor = Cursors.Default;
                }

                if (!opc && CamposDocumentosEspecialesList.Count > 0)
                {

                    int respuesta = 0;
                    bool requiereAutogenerado = (bool)radioGroup1.Properties.Items[radioGroup1.SelectedIndex].Value;
                    string mensaje;

                    try
                    {
                        respuesta = Metodos.RegistrarDocumentosEspecialesMasivo(oDocumento, requiereAutogenerado);

                        Program.HidePopWaitScreen();

                        if (respuesta > 0)
                        {
                            mensaje = Metodos.ObtenerAutogenerado(respuesta);
                            frmCodigoAutogenerado frm = new frmCodigoAutogenerado();
                            frm.autogenerado = mensaje;
                            frm.ShowDialog(this);
                            //Program.mensaje($"Se ha creado el autogenerado {mensaje}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (respuesta == 0)
                        {
                            Program.mensaje($"Se han creado {numeroRegistros} autogenerados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Program.mensaje("Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }

                }
                Program.HidePopWaitScreen();
            }
            catch (Exception)
            {
                Program.HidePopWaitScreen();
            }


        }


        #endregion

        public frmCargaMasivaDocumentoEspeciales()
        {
            InitializeComponent();
        }

        private void frmCargaMasivaDocumentoEspeciales_Load(object sender, EventArgs e)
        {
            radioGroup1.SelectedIndex = 0;

            CargarTipoDocumentoNoRequiereDigitalizacion();

            CargarDestino();
        }

        private void cboTipoDocumento_EditValueChanged(object sender, EventArgs e)
        {
            oTipoDocumento = (TipoDocumento)cboTipoDocumento.GetSelectedDataRow();

            oCasillaDestino = ListaDestino.Find(x => x.TipoDocumentoAsociado == (int)(oTipoDocumento.iIdTipoDocumento));

            CargarCamposDocumentosEspeciales();
        }

        private void btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            SeleccionarArchivo();
        }

        private void btnCargarDocumentos_Click(object sender, EventArgs e)
        {
            ValidarArchivo();
        }
    }
}
