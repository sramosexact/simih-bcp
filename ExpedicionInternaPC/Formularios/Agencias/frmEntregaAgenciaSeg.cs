using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Expedicion
{
    public partial class frmEntregaAgenciaSeg : frmChild
    {
        #region Variables

        #endregion

        #region Metodos

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
                    this.grdListaEntrega.ExportToXls(oSave.FileName);
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = oSave.FileName;
                    process.Start();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        //2022
        private void verDetalle()
        {
            int ie = ((Entrega)grvListaEntrega.GetFocusedRow()).ID;
            List<string> ls = new List<string>();
            try
            {
                ls = Metodos.EntregaDetalle(ie);

                if (ls.Count > 0)
                {
                    String tag = "Entrega " + ie;
                    frmDetalleEntregaSeg frmEp = new frmDetalleEntregaSeg();
                    frmEp.codAgencia = int.Parse(((Entrega)grvListaEntrega.GetFocusedRow()).CodigoAgencia);
                    frmEp.Tag = tag;
                    frmEp.entrega = Metodos.deserializarPrueba<Entrega>(ls[0])[0];
                    frmEp.lEntregaObjeto = Metodos.deserializarPrueba<Objeto>(ls[1]);
                    frmEp.Text = tag;
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
            }
            catch (Exception)
            {
                return;
            }

        }
        //2022
        private void CargarFormulario()
        {
            try
            {
                grdListaEntrega.DataSource = Metodos.ListarEntregaAgenciaSeguimiento();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar listar el seguimiento de las entregas.");
                return;
            }
        }

        #endregion

        // Revisado
        public frmEntregaAgenciaSeg()
        {
            InitializeComponent();
        }

        private void frmEntregaAgenciaSeg_Load(object sender, EventArgs e)
        {
            CargarFormulario();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void grvListaEntrega_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string estado = grvListaEntrega.GetRowCellDisplayText(e.RowHandle, "EstadoDescripcion");
                if (estado == "RUTA")
                {
                    e.Appearance.BackColor = Color.FromArgb(232, 228, 134);
                }
                else if (estado == "TERMINADO")
                {
                    e.Appearance.BackColor = Color.FromArgb(255, 122, 122);
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                grdListaEntrega.DataSource = Metodos.ListarEntregaAgenciaSeguimiento();
            }
            catch (Exception)
            {
                Program.mensajeTokenInvalido();
            }

        }

        private void linkEntrega_Click(object sender, EventArgs e)
        {
            verDetalle();
        }
    }
}
