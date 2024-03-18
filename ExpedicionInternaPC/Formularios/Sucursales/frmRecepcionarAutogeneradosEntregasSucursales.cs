using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Respuesta = System.Windows.Forms.DialogResult;

namespace ExpedicionInternaPC
{
    public partial class frmRecepcionarAutogeneradosEntregasSucursales : frmChild
    {
        #region Variables

        int iEstado = 0;
        public List<Objeto> lEntregaObjeto = new List<Objeto>();
        int iCustodia = 0;

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
                    this.grdAutogenerados.ExportToXls(oSave.FileName);
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    process.StartInfo.FileName = oSave.FileName;
                    process.Start();
                }
                catch (Exception ex)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar exportar los datos.");
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        //2022
        public void llenarResumen()
        {
            int iTotal = lEntregaObjeto.Count;
            int iCustodiados = lEntregaObjeto.FindAll(x => x.IdTipoEstado == 4 || x.IdTipoEstado == 2 || x.IdTipoEstado == 5).ToList().Count;
            int iPendientes = iTotal - iCustodiados;
            lblTotal.Text = iTotal.ToString();
            lblCustodia.Text = iCustodiados.ToString();
            lblPendiente.Text = iPendientes.ToString();

        }
        //2022
        public void cargarFormulario()
        {
            frmMain frmPadre = this.MdiParent as frmMain;
            this.grdAutogenerados.DataSource = lEntregaObjeto;
            this.grdAutogenerados.RefreshDataSource();
            this.grvAutogenerados.RefreshData();
            grvAutogenerados.Columns["FechaRecepcion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            txtAutogenerado.Enabled = true;
            btnGrabar.Enabled = true;
            llenarResumen();
            grvAutogenerados.Columns["FechaRecepcion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            txtAutogenerado.Focus();
        }
        //2022
        private void validarTexto(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtAutogenerado.Text.Trim().Length > 5)
                {
                    custodiar();
                }
            }
        }
        //2022
        private void custodiar()
        {
            if (txtAutogenerado.Text.Trim().Length >= 6)
            {
                Objeto oo = lEntregaObjeto.Find(x => x.Autogenerado == txtAutogenerado.Text.Trim().ToUpper());
                if (oo != null)
                {
                    if (oo.Estado != "RUTA")
                    {
                        Program.mensaje("El elemento ya se encuentra validado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtAutogenerado.Focus();
                        txtAutogenerado.SelectAll();
                        return;
                    }
                    oo.IdTipoEstado = 2;
                    oo.Estado = "CUSTODIA";
                    oo.FechaRecepcion = DateTime.UtcNow;
                    grdAutogenerados.RefreshDataSource();
                    grvAutogenerados.RefreshData();
                    grvAutogenerados.Columns["FechaRecepcion"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;

                    llenarResumen();
                    txtAutogenerado.ResetText();
                    txtAutogenerado.Focus();
                    iCustodia += 1;
                    lblCambio.Appearance.BackColor = Color.White;
                    lblCambio.Appearance.BackColor2 = Color.FromArgb(255, 84, 27);
                }
                else
                {
                    Program.mensaje("El código ingresado no se encuentra en la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtAutogenerado.Focus();
                    txtAutogenerado.SelectAll();
                }

            }
            else
            {
                Program.mensaje("Por favor, ingrese correctamente el código.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAutogenerado.Focus();
                txtAutogenerado.SelectAll();
            }
        }
        //2022
        private void grabarCustodia()
        {
            if (iCustodia == 0)
            {
                Program.mensaje("La grabación ha sido exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAutogenerado.Focus();
                txtAutogenerado.SelectAll();
                frmValijaSucursal fx = (frmValijaSucursal)Program.SetFormActive<frmValijaSucursal>("Administrar Valija de Sucursal", Program.oMain);
                fx.listarEntregasSucursalDestino();
                this.Close();
                return;
            }
            List<Objeto> lo = lEntregaObjeto.FindAll(x => x.IdTipoEstado == 2).ToList();
            if (lo != null)
            {
                if (lo.Count > 0)
                {

                    List<ObjetoSucursalCustodiaMasivo> listaOjetoSucursalCustodiaMasivo = new List<ObjetoSucursalCustodiaMasivo>();

                    foreach (Objeto objeto in lo)
                    {
                        ObjetoSucursalCustodiaMasivo objetoSucursalCustodiaMasivo = new ObjetoSucursalCustodiaMasivo();
                        objetoSucursalCustodiaMasivo.ID = objeto.ID;
                        objetoSucursalCustodiaMasivo.fechaResultado = objeto.fechaResultado;
                        objetoSucursalCustodiaMasivo.IdEntrega = objeto.IdEntrega;
                        listaOjetoSucursalCustodiaMasivo.Add(objetoSucursalCustodiaMasivo);
                    }

                    Objeto o = new Objeto();
                    o.Detalle = o.SerializeObjectWindows(listaOjetoSucursalCustodiaMasivo);
                    int resultado = 0;

                    try
                    {
                        resultado = Metodos.CustodiarAutogeneradosEntregasSucursal(Program.oUsuario.ID, o.Detalle);
                    }
                    catch (InvalidTokenException)
                    {
                        Program.mensajeTokenInvalido();
                        return;
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar custodiar los elementos de la entrega.");
                        return;
                    }

                    if (resultado == 1)
                    {
                        frmValijaSucursal fx = (frmValijaSucursal)Program.SetFormActive<frmValijaSucursal>("Administrar Valija de Sucursal", Program.oMain);
                        fx.listarEntregasSucursalDestino();
                        iCustodia = 0;
                        lblCambio.Appearance.BackColor = Color.White;
                        lblCambio.Appearance.BackColor2 = Color.White;
                        Program.mensaje("La grabación ha sido exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAutogenerado.Focus();
                        txtAutogenerado.SelectAll();
                        this.Close();
                    }
                    else
                    {
                        Program.mensaje("No se pudo guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtAutogenerado.Focus();
                        txtAutogenerado.SelectAll();
                    }

                }
            }
        }
        //2022
        private void verificaCambios()
        {
            if (iCustodia > 0)
            {
                if (Program.mensaje("No ha grabado los cambios realizados. ¿Desea grabar?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == Respuesta.Yes)
                {
                    grabarCustodia();
                }
            }
        }
        //2022
        private void verSeguimiento()
        {
            Objeto oO = (Objeto)this.grvAutogenerados.GetFocusedRow();
            //oO.IdTipoEntrega = 1;

            if (oO != null)
            {
                frmTracking oT = new frmTracking(oO.ID);
                oT.oObjeto = oO;
                oT.Show(this.Parent);
            }
        }

        #endregion

        public frmRecepcionarAutogeneradosEntregasSucursales()
        {
            InitializeComponent();
            txtAutogenerado.Properties.MaxLength = Program.LONGITUD_CODIGO;
        }

        private void frmRecepcionarAutogeneradosEntregasSucursales_Load(object sender, EventArgs e)
        {
            iCustodia = 0;
            txtAutogenerado.Focus();
        }

        private void txtAutogenerado_KeyDown(object sender, KeyEventArgs e)
        {
            validarTexto(e);
        }

        private void txtAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
            Program.alfanumericosAndGuiones(e);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            grabarCustodia();
        }

        private void frmRecepcionarAutogeneradosEntregasSucursales_FormClosed(object sender, FormClosedEventArgs e)
        {
            verificaCambios();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            verSeguimiento();
        }

        private void grvAutogenerados_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                GridColumn oCol = null;
                int tipo = 0;

                try
                {
                    oCol = (GridColumn)View.Columns["IdTipoEstado"];
                }
                catch (Exception) { }

                if (oCol != null)
                {
                    try
                    {
                        tipo = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, oCol).ToString());
                    }
                    catch (Exception) { }

                    if (lEntregaObjeto == null)
                    {
                        return;

                    }

                    if (lEntregaObjeto.Count == 0)
                    {
                        return;
                    }

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
    }
}
