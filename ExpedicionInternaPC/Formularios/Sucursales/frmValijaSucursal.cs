using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmValijaSucursal : frmChild
    {
        #region Variables

        private List<Entrega> lDestino;
        private List<Entrega> lRuta;

        #endregion

        #region Metodos

        //2022
        public override void ExportExcel(String FileName)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                this.grdTerminado.ExportToXls(FileName);
            }
            else
            {
                this.grdRuta.ExportToXls(FileName);
            }
        }
        //2022
        public override void Actualizar(string CommandName)
        {
            try
            {
                base.Actualizar(CommandName);
                listarEntregasSucursalDestino();
                listarEntregasSucursalesRuta();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de entregas.");
                return;
            }

        }
        //2022
        public void listarEntregasSucursalDestino()
        {
            try
            {
                lDestino = Metodos.ListaEntregaSucursalDestino(Program.oUsuario.IdExpedicion);
                grdTerminado.DataSource = lDestino;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                throw;
            }

        }
        //2022
        private void listarEntregasSucursalesRuta()
        {
            try
            {
                lRuta = Metodos.ListaEntregaSucursalDestinoRuta(Program.oUsuario.IdExpedicion);
                grdRuta.DataSource = lRuta;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                throw;
            }

        }
        //2022
        private void validarTexto(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                validar();
            }
        }
        //2022
        private void validar()
        {
            if (txtCodigo.Text != "" && txtCodigo.Text.Trim().Length > 0)
            {
                Entrega oe = new Entrega();

                try
                {
                    oe = Metodos.RecepcionEntregaSucursal(int.Parse(txtCodigo.Text), Program.oUsuario.IdExpedicion, Program.oUsuario.ID)[0];
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                    return;
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar recepcionar la entrega.");
                    return;
                }

                if (oe.ID == -1)
                {
                    Program.mensaje("No se pudo realizar la acción solicitada. La Entrega se encuentra en estado CREADO.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                }
                else if (oe.ID == -3)
                {
                    Program.mensaje("No se pudo realizar la acción solicitada. La Entrega ya se encuentra en estado TERMINADO.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                }
                else if (oe.ID == -4)
                {
                    Program.mensaje("No se pudo realizar la acción solicitada. La Entrega ya se encuentra en estado CERRADA.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                }
                else if (oe.ID == -5)
                {
                    Program.mensaje("Por favor, ingrese correctamente el código de la entrega.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                }
                else if (oe.ID == 0)
                {
                    Program.mensaje("El código ingresado no esta asociado a ninguna Entrega de tipo Sucursal.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                }
                else
                {
                    if (oe.Estado == 2)
                    {
                        txtCodigo.Text = "";
                        txtCodigo.Focus();
                        if (xtraTabControl1.SelectedTabPageIndex == 1)
                        {
                            try
                            {
                                listarEntregasSucursalesRuta();
                            }
                            catch (Exception)
                            {
                                Program.mensajeError("Ha ocurrido un error al intentar listar las entregas.");
                                return;
                            }
                        }
                        else
                        {
                            xtraTabControl1.SelectedTabPageIndex = 1;
                        }
                        Program.ok.PlaySync();
                    }
                    else if (oe.Estado == 3)
                    {
                        if (xtraTabControl1.SelectedTabPageIndex == 0)
                        {
                            try
                            {
                                listarEntregasSucursalDestino();
                            }
                            catch (Exception)
                            {
                                Program.mensajeError("Ha ocurrido un error al intentar listar las entregas.");
                                return;
                            }
                        }
                        else
                        {
                            xtraTabControl1.SelectedTabPageIndex = 0;
                        }

                        Program.ok.PlaySync();
                        txtCodigo.Text = "";
                    }

                }
            }
        }
        //2022
        private void abrirEntrega(Entrega oe)
        {
            int ie = oe.ID;
            List<string> ls = new List<string>();

            try
            {
                ls = Metodos.EntregaDetalle(ie);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar abrir la entrega.");
                return;
            }

            if (ls.Count > 0)
            {
                String tag = "Entrega " + ie.ToString();
                frmRecepcionAutogeneradoSucursal frmEp = new frmRecepcionAutogeneradoSucursal();
                frmEp.oEntrega = Metodos.deserializarPrueba<Entrega>(ls[0])[0];
                frmEp.lEntregaObjeto = Metodos.deserializarPrueba<Objeto>(ls[1]);
                frmEp.Tag = tag;
                frmEp.Text = tag;
                frmEp.cargarFormulario();
                frmEp.ShowDialog(this.Parent);
            }
            else
            {
                Program.mensaje("Vacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //2022
        private void ObtenerAutogeneradosEntregas()
        {
            List<Objeto> ls = new List<Objeto>();

            try
            {
                ls = Metodos.ListarAutogeneradosEntregasSucursalRecibidas();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener los autogenerados de la entrega.");
                return;
            }

            if (ls != null && ls.Count > 0)
            {
                frmRecepcionarAutogeneradosEntregasSucursales frmEp = new frmRecepcionarAutogeneradosEntregasSucursales();
                frmEp.lEntregaObjeto = ls;
                frmEp.cargarFormulario();
                frmEp.ShowDialog(this.Parent);
            }
            else
            {
                Program.mensaje("No existen autogenerados para recepcionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        #endregion


        public frmValijaSucursal()
        {
            InitializeComponent();
        }

        private void frmValijaSucursal_Load(object sender, EventArgs e)
        {
            try
            {
                listarEntregasSucursalDestino();
                listarEntregasSucursalesRuta();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de entregas.");
                return;
            }
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            validarTexto(e);
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            abrirEntrega((Entrega)grvTerminado.GetFocusedRow());
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                try
                {
                    listarEntregasSucursalesRuta();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de entregas.");
                    return;
                }
            }
            else
            {
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                {
                    try
                    {
                        listarEntregasSucursalDestino();
                    }
                    catch (Exception)
                    {
                        Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de entregas.");
                        return;
                    }

                }
            }

        }

        private void xtraTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnRecepcionar_Click(object sender, EventArgs e)
        {
            ObtenerAutogeneradosEntregas();
        }
    }
}
