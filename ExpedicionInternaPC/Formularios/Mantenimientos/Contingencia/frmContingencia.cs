using Interna.Entity;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmContingencia : frmChild
    {
        #region Variables 

        private List<Objeto> ListaObjetoContingencia;

        #endregion

        #region Metodos
        //2022
        private void BuscarArchivo()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Seleccionar archivo";
            op.Filter = "Todos los archivos Excel 2003 (*.xls)|*.xls|Todos los archivos Excel (*.xlsx)|*.xlsx";
            op.Multiselect = false;
            op.InitialDirectory = "C:\\";

            if (op.ShowDialog() == DialogResult.OK)
            {
                txtArchivoDatos.Text = op.FileName;

            }
        }
        //2022
        public void recorrerDatosArchivo()
        {
            if (txtArchivoDatos.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe elegir una archivo para realizar la carga", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int hojaelegida = 0;

            try
            {
                Program.ShowPopWaitScreen();

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.ScreenUpdating = false;
                Workbook wb = app.Workbooks.Open(txtArchivoDatos.Text.Trim(), 2, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, false);
                Worksheet sh = wb.Worksheets.get_Item(hojaelegida + 1);
                Range ec = sh.UsedRange;
                object[,] wArray = ec.get_Value(Type.Missing);

                ListaObjetoContingencia = new List<Objeto>();

                try
                {
                    for (int row = 2; row < (wArray.GetLength(0) + 1); row++)
                    {
                        Objeto oObjeto = new Objeto();
                        oObjeto.Autogenerado = Convert.ToString(wArray[row, 1]).ToUpper();
                        oObjeto.Impreso = int.Parse(Convert.ToString(wArray[row, 2]));
                        ListaObjetoContingencia.Add(oObjeto);
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    if (ec != null)
                    {
                        ec = null;
                    }

                    if (wb != null)
                    {
                        wb.Close(false, txtArchivoDatos.Text.Trim(), Missing.Value);
                        wb = null;
                    }

                    if (app != null)
                    {
                        app.DisplayAlerts = true;
                        app.Quit();
                        app = null;
                    }

                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    Cursor = Cursors.Default;
                }

                //Comprobar si ListaDocExternos tiene elementos que mostrar
                if (ListaObjetoContingencia.Count > 0)
                {
                    try
                    {
                        grdDocumentosContingencia.DataSource = ListaObjetoContingencia;
                        grdDocumentosContingencia.RefreshDataSource();
                    }
                    catch { }
                    finally
                    {
                        Cursor = Cursors.Default;
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron datos en las posiciones señaladas de la plantilla elegida.", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
            finally
            {
                Program.HidePopWaitScreen();
            }

        }
        //2022
        private void CargarRegistros()
        {
            if (ListaObjetoContingencia == null)
            {
                Program.mensaje("No hay elementos para cargar al sistema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (ListaObjetoContingencia.Count == 0)
                {
                    Program.mensaje("No hay elementos para cargar al sistema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Objeto oObjetoContingencia = new Objeto();
            oObjetoContingencia.IdUsuario = Program.oUsuario.ID;
            oObjetoContingencia.IdExpedicionCustodia = Program.oUsuario.IdExpedicion;
            oObjetoContingencia.Detalle = oObjetoContingencia.SerializeObjectWindows(ListaObjetoContingencia);
            try
            {
                List<Objeto> resultado = Metodos.RecibirObjetosMasivoContingencia(oObjetoContingencia);
                if (resultado == null)
                {
                    Program.mensaje("Ha ocurrido un error con la conexion. Intente nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (resultado[0].Autogenerado == "0")
                {
                    Program.mensaje("Los documentos se cargaron de forma correcta.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListaObjetoContingencia = new List<Objeto>();
                    grdDocumentosContingencia.DataSource = ListaObjetoContingencia;
                }
                else if (resultado[0].Autogenerado == "-1")
                {
                    Program.mensaje("Ha ocurrido un error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado[0].Autogenerado == "-2")
                {
                    Program.mensaje("Existen autogenerados que están dentro de varias entregas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado[0].Autogenerado == "-3")
                {
                    Program.mensaje("El usuario no cuenta con una casilla predeterminada.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado[0].Autogenerado == "-4")
                {
                    Program.mensaje("Los autogenerados del archivo no están registrados en el sistema o ya se encuentran en estado 'RECIBIDO'.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los registros masivos.");
            }

        }

        #endregion
        public frmContingencia()
        {
            InitializeComponent(); //  @OBJETOS, @IDUSUARIO, @IDEXPEDICION   PC_CONTINGENCIA_U_RECIBIR_DOCUMENTOS_MASIVO
        }

        private void frmContingencia_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            BuscarArchivo();
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            recorrerDatosArchivo();
        }

        private void btnCargarRegistros_Click(object sender, EventArgs e)
        {
            CargarRegistros();
        }

    }
}
