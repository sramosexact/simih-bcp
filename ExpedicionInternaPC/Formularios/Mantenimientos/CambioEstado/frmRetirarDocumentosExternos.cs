using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace ExpedicionInternaPC
{
    public partial class frmRetirarDocumentosExternos : frmChild
    {
        private string oledbCnx64 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
        private string oledbCnx32 = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'";
        private string oledbCnx = "";

        private List<DocumentoExterno> DocumentosExternosPorRetirar = new List<DocumentoExterno>();

        private void SelectedFile()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Seleccionar archivo";
            op.Filter = "Todos los archivos Excel (*.xlsx)|*.xlsx|Todos los archivos Excel 2003 (*.xls)|*.xls";
            op.Multiselect = false;
            op.InitialDirectory = "C:\\";

            if (op.ShowDialog() == DialogResult.OK)
            {
                txtDataFile.Text = op.FileName;

            }
        }

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

        private void LoadFile()
        {
            if (txtDataFile.Text.Trim().Length == 0)
            {
                MessageBox.Show("Debe elegir una archivo para realizar la carga", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string fileExcel = txtDataFile.Text;
            string stringCnx = string.Format(oledbCnx, fileExcel); //$@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fileExcel};Extended Properties='Excel 12.0;HDR=YES;IMEX=1;'";
            string sheetName = "DOCUMENTOS";
            string query = $"SELECT * FROM [{sheetName}$]";

            OleDbConnection ConnectToExcel = new OleDbConnection(stringCnx);

            if (!existeHojaExcel(sheetName, stringCnx))
            {
                Program.mensaje("No se encuentra la hoja con el nombre 'POR RETIRAR'.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


            DocumentosExternosPorRetirar = new List<DocumentoExterno>();

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0] == null) break;

                DocumentoExterno documentoExternoPorRetirar = new DocumentoExterno();

                documentoExternoPorRetirar.Codigo = dr[0].ToString();
                documentoExternoPorRetirar.Destino = "";


                DocumentosExternosPorRetirar.Add(documentoExternoPorRetirar);

            }

            if (DocumentosExternosPorRetirar.Count == 0)
            {
                MessageBox.Show("No se encontraron datos en las posiciones señaladas de la plantilla elegida.", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            grdPorRetirar.DataSource = DocumentosExternosPorRetirar;
            grdPorRetirar.RefreshDataSource();
        }

        private void RetirarDocumentos()
        {
            Objeto obj = new Objeto();


            string jsonDocExt = JsonConvert.SerializeObject(DocumentosExternosPorRetirar);

            try
            {
                Program.ShowPopWaitScreen();
                List<DocumentoExterno> resultado = Metodos.RetirarListaDocumentosExternos(jsonDocExt);

                if (resultado.Count == 0)
                {

                    foreach (DocumentoExterno d in DocumentosExternosPorRetirar)
                    {
                        d.Destino = "ERROR";
                    }
                    grdPorRetirar.DataSource = DocumentosExternosPorRetirar;
                    grdPorRetirar.RefreshDataSource();
                    return;
                }

                foreach (DocumentoExterno d in DocumentosExternosPorRetirar)
                {
                    if (resultado.Find(y => y.Codigo == d.Codigo) != null)
                    {
                        d.Destino = "RETIRADO";
                    }
                    else
                    {
                        d.Destino = "ERROR";
                    }
                }

                grdPorRetirar.DataSource = DocumentosExternosPorRetirar;
                grdPorRetirar.RefreshDataSource();
                Program.HidePopWaitScreen();

            }
            catch (InvalidTokenException)
            {
                Program.HidePopWaitScreen();
                Program.mensajeTokenInvalido();
            }
            catch (Exception ex)
            {
                Program.HidePopWaitScreen();
                Program.mensajeError("Ha ocurrido un error al intentar retirar los documentos externos.");
            }
            finally
            {
                Program.HidePopWaitScreen();
            }

        }

        public frmRetirarDocumentosExternos()
        {
            InitializeComponent();
        }

        private void frmRetirarDocumentosExternos_Load(object sender, EventArgs e)
        {
            if (Environment.Is64BitProcess) oledbCnx = oledbCnx64;
            else oledbCnx = oledbCnx32;
        }


        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SelectedFile();
        }


        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            RetirarDocumentos();
        }


    }
}
