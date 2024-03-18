using Interna.Core;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Expedicion
{
    public partial class frmDetalleEntregaSeg : frmChild
    {

        #region variables 

        public List<Objeto> lEntregaObjeto = new List<Objeto>();
        public Entrega entrega = new Entrega();
        public int codAgencia = 0;

        #endregion

        #region metodos 

        //2022
        public void llenarResumen()
        {
            int iTotal = lEntregaObjeto.Count;
            int iRecibidos = lEntregaObjeto.FindAll(x => x.IdTipoEstado == 4).ToList().Count;
            int iEnRuta = iTotal - iRecibidos;

            lblEntrega.Text = entrega.ID.ToString();
            lblTotal.Text = iTotal.ToString();
            lblValidados.Text = iRecibidos.ToString();
            lblPorValidar.Text = iEnRuta.ToString();
            this.Text = "Detalle de la Entrega: Agencia " + this.codAgencia.ToString() + " | Estado : " + entrega.EstadoDescripcion.ToUpper();
        }
        //2022
        public void refrescarDetalle()
        {
            List<string> ls = new List<string>();
            try
            {
                ls = Metodos.EntregaDetalle(entrega.ID);
                if (ls.Count > 0)
                {
                    entrega = Metodos.deserializarPrueba<Entrega>(ls[0])[0];
                    lEntregaObjeto = Metodos.deserializarPrueba<Objeto>(ls[1]);
                    cargarTabla();
                    llenarResumen();
                }
                else
                {
                    Program.mensaje("La entrega se encuentra vacía o no existe.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar el detalle de la entrega.");
            }
        }
        //2022
        public void cargarTabla()
        {
            this.grdEntregaObjeto.DataSource = lEntregaObjeto;
            this.grdEntregaObjeto.RefreshDataSource();
            this.grvEntregaObjeto.RefreshData();
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
                    Program.mensajeError("Ha ocurrido un error al intentar exportar los registros.");
                    ErrorLog oe = new ErrorLog();
                    oe.EscribirLog("Inicializando...");
                    oe.EscribirLog("Registro de errores iniciado.");
                    oe.EscribirLog(ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        //2022
        private void verSeguimiento()
        {
            Objeto oO = (Objeto)this.grvEntregaObjeto.GetFocusedRow();
            oO.IdTipoEntrega = 1;
            try
            {
                Metodos.VerTracking(oO);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener el seguimiento.");
                return;
            }

        }
        #endregion


        public frmDetalleEntregaSeg()
        {
            InitializeComponent();
        }

        private void frmDetalleEntregaSeg_Load(object sender, EventArgs e)
        {
            cargarTabla();
            llenarResumen();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            refrescarDetalle();
        }

        private void linkAutogenerado_Click(object sender, EventArgs e)
        {
            verSeguimiento();
        }

    }
}
