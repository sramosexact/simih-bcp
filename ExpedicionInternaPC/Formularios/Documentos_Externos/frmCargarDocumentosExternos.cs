using Interna.Entity;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmCargarDocumentosExternos : frmChild
    {
        #region Variables

        List<TipoDocumentoExterno> LTipoDocumentoExterno;
        public List<Campo> listaObjetos;
        public List<ObjetoDetalle> listaDatos;
        public Casilla cOrigen;
        public PlantillaGeneral objPlantillaGral;
        public List<DocumentoExternoCarga> ListaDocExternos;
        public List<DocumentoExterno> documentoExternoList;

        private string oledbCnx64 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
        private string oledbCnx32 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
        private string oledbCnx = "";
        #endregion

        #region Metodos

        //2022
        private void ListarDocumentosExternos()
        {
            try
            {
                LTipoDocumentoExterno = Metodos.ListarTipoDocumentoExterno();
                cboTipoDocumento.Properties.DataSource = LTipoDocumentoExterno;
                cboTipoDocumento.Properties.DisplayMember = "sDescripcionTipoDocumentoExterno";
                cboTipoDocumento.Properties.ValueMember = "iIdTipoDocumentoExterno";
                cboTipoDocumento.Properties.DropDownRows = LTipoDocumentoExterno.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de documentos.");
            }

        }
        //2022
        private void BuscarArchivo()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Seleccionar archivo";
            op.Filter = "Todos los archivos Excel (*.xlsx)|*.xlsx|Todos los archivos Excel 2003 (*.xls)|*.xls";
            op.Multiselect = false;
            op.InitialDirectory = "C:\\";

            if (op.ShowDialog() == DialogResult.OK)
            {
                txtArchivoDatos.Text = op.FileName;

            }
        }
        //2022
        private bool existeHojaExcel(string sheetName, string cnx)
        {
            bool existe = false;
            OleDbConnection cn = new OleDbConnection(cnx);
            System.Data.DataTable dt = null;
            try
            {
                cn.Open();
                dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null) return false;

                foreach (DataRow row in dt.Rows)
                {
                    if (row["TABLE_NAME"].ToString().Equals($"{sheetName}$"))
                    {
                        existe = true;
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                existe = false;
            }
            finally
            {

                if (cn != null)
                {
                    cn.Close();
                    cn.Dispose();
                }
                if (dt != null)
                {
                    dt.Dispose();
                }
            }

            return existe;
        }
        //2022
        public void obtenerDatosArchivo()
        {
            if (txtArchivoDatos.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe elegir una archivo para realizar la carga", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileExcel = txtArchivoDatos.Text;
            string stringCnx = string.Format(oledbCnx, fileExcel); //$@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fileExcel};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
            string sheetName = ((TipoDocumentoExterno)cboTipoDocumento.GetSelectedDataRow()).sDescripcionTipoDocumentoExterno;
            string query = $"SELECT * FROM [{sheetName}$]";

            OleDbConnection ConnectToExcel = new OleDbConnection(stringCnx);

            if (!existeHojaExcel(sheetName, stringCnx))
            {
                Program.mensaje("No se encuentra la hoja con el nombre " + ((TipoDocumentoExterno)cboTipoDocumento.GetSelectedDataRow()).sDescripcionTipoDocumentoExterno + ".", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OleDbCommand excelcmd = new OleDbCommand(query, ConnectToExcel);
            OleDbDataAdapter da = new OleDbDataAdapter(excelcmd);
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                da.Fill(dt);
            }
            catch (OleDbException ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar acceder al origen de datos.");

                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar extraer los datos del archivo.");
            }


            ListaDocExternos = new List<DocumentoExternoCarga>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0] == null || dr[2] == null) break;

                DocumentoExternoCarga documento = new DocumentoExternoCarga();

                documento.Destino = dr[0].ToString();
                documento.sDestinatario = dr[1].ToString();
                documento.Codigo = dr[2].ToString();

                ListaDocExternos.Add(documento);

            }

            if (ListaDocExternos.Count == 0)
            {
                MessageBox.Show("No se encontraron datos en las posiciones señaladas de la plantilla elegida.", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grdDocumentosExternos.DataSource = ListaDocExternos;
            grdDocumentosExternos.RefreshDataSource();

        }
        //2022
        public void recorrerDatosArchivo()
        {
            if (txtArchivoDatos.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe elegir una archivo para realizar la carga", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int hojaelegida = 1;

            try
            {
                Program.ShowPopWaitScreen();

                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.ScreenUpdating = false;
                Workbook wb = app.Workbooks.Open(txtArchivoDatos.Text.Trim(), 2, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, false);
                Worksheet sh = wb.Worksheets.get_Item(hojaelegida);

                bool encuentra = false;

                while (!encuentra && wb.Sheets.Count >= hojaelegida)
                {
                    if (((TipoDocumentoExterno)cboTipoDocumento.GetSelectedDataRow()).sDescripcionTipoDocumentoExterno == sh.Name)
                    {
                        encuentra = true;
                        break;
                    }
                    hojaelegida++;
                    if (wb.Sheets.Count >= hojaelegida)
                    {
                        sh = wb.Worksheets.get_Item(hojaelegida);
                    }
                }

                if (!encuentra)
                {
                    Program.mensaje("No se encuentra la hoja con el nombre " + ((TipoDocumentoExterno)cboTipoDocumento.GetSelectedDataRow()).sDescripcionTipoDocumentoExterno + ".", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }



                Range ec = sh.UsedRange;
                object[,] wArray = ec.get_Value(XlRangeValueDataType.xlRangeValueDefault);

                ListaDocExternos = new List<DocumentoExternoCarga>();
                documentoExternoList = new List<DocumentoExterno>();

                try
                {
                    for (int row = 2; row < (wArray.GetLength(0) + 1); row++)
                    {
                        if (Convert.ToString(wArray[row, 1]) == String.Empty)
                        {
                            break;
                        }
                        DocumentoExternoCarga oDocExt = new DocumentoExternoCarga();
                        oDocExt.Destino = Convert.ToString(wArray[row, 1]);
                        long res;
                        try
                        {
                            oDocExt.Codigo = Convert.ToInt64(wArray[row, 3]).ToString();
                        }
                        catch
                        {
                            oDocExt.Codigo = Convert.ToString(wArray[row, 3]);
                        }

                        oDocExt.sDestinatario = Convert.ToString(wArray[row, 2]);

                        ListaDocExternos.Add(oDocExt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                if (ListaDocExternos.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos en las posiciones señaladas de la plantilla elegida.", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                grdDocumentosExternos.DataSource = ListaDocExternos;
                grdDocumentosExternos.RefreshDataSource();

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
            if (cboTipoDocumento.EditValue == null)
            {
                Program.mensaje("Debe seleccionar un tipo de documento externo de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ListaDocExternos == null)
            {
                Program.mensaje("No hay elementos para cargar al sistema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (ListaDocExternos.Count == 0)
            {
                Program.mensaje("No hay elementos para cargar al sistema.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Objeto obj = new Objeto();

            List<DocumentoExterno> ListaDocumentos = JsonConvert.DeserializeObject<List<DocumentoExterno>>(JsonConvert.SerializeObject(ListaDocExternos));
            string jsonDocExt = JsonConvert.SerializeObject(ListaDocumentos);

            try
            {
                Program.ShowPopWaitScreen();
                List<DocumentoExterno> resultado = Metodos.CargarDocumentosExternosLote((byte)cboTipoDocumento.EditValue, jsonDocExt);

                if (resultado.Count == 0)
                {

                    foreach (DocumentoExternoCarga d in ListaDocExternos)
                    {
                        d.estado = "ERROR";
                    }
                    grdDocumentosExternos.DataSource = ListaDocExternos;
                    grdDocumentosExternos.RefreshDataSource();
                    return;
                }

                foreach (DocumentoExternoCarga d in ListaDocExternos)
                {
                    if (resultado.Find(y => y.Codigo == d.Codigo && y.Destino == d.Destino) != null)
                    {
                        d.estado = "REGISTRADO";
                    }
                    else
                    {
                        d.estado = "ERROR";
                    }
                }

                grdDocumentosExternos.DataSource = ListaDocExternos;
                grdDocumentosExternos.RefreshDataSource();

            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los registros.");
            }
            finally
            {
                Program.HidePopWaitScreen();
            }


        }

        #endregion


        public frmCargarDocumentosExternos()
        {
            InitializeComponent();
        }

        private void frmCargarDocumentosExternos_Load(object sender, EventArgs e)
        {
            if (Environment.Is64BitProcess) oledbCnx = oledbCnx64;
            else oledbCnx = oledbCnx32;
            ListarDocumentosExternos();
        }

        private void btnBuscarArchivo_Click(object sender, EventArgs e)
        {
            if (cboTipoDocumento.EditValue == null)
            {
                Program.mensaje("Debe seleccionar un tipo de documento externo de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BuscarArchivo();
        }

        private void btnVistaPrevia_Click(object sender, EventArgs e)
        {
            obtenerDatosArchivo();
        }

        private void btnCargarRegistros_Click(object sender, EventArgs e)
        {
            CargarRegistros();
        }

        private void cboTipoDocumento_Properties_EditValueChanged(object sender, EventArgs e)
        {
            grdDocumentosExternos.DataSource = null;
            grdDocumentosExternos.RefreshDataSource();
            txtArchivoDatos.Text = null;
        }
    }
}
