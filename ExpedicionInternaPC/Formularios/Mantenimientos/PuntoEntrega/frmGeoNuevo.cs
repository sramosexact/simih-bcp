using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmAgregarPuntoEntrega : frmChild
    {
        #region Variables

        public Geo oGeo;
        public int opc = 0;
        public int tipoAccion = 0;
        public List<Geo> oListaOficinas;

        #endregion

        #region Metodos

        //2022
        private void Cargar()
        {
            if (tipoAccion == 2)
            {
                //Modificar
                txtOficina.Text = oGeo.Oficina;
                txtArea.Text = oGeo.Descripcion;

                if (oGeo.Agencia != "")
                {
                    txtOficina.Enabled = false;
                    txtArea.Enabled = true;
                    txtArea.Focus();
                }
                else // Sucursal
                {
                    txtOficina.Enabled = true;
                    txtArea.Enabled = true;
                    txtOficina.Focus();
                }

            }
            else
            {
                //Crear
                if (oGeo.Agencia != "") // Agencia
                {
                    txtOficina.Text = oGeo.Oficina;
                    txtOficina.Enabled = false;
                    txtArea.Enabled = true;
                    txtArea.Focus();
                }
                else // Sucursal
                {
                    txtOficina.Enabled = true;
                    txtArea.Enabled = true;
                    txtOficina.Focus();
                }

            }
        }
        //2022
        private void Guardar()
        {

            if (txtOficina.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese una ubicación.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txtOficina.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese un área.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (tipoAccion == 2)
            {
                //Modificar
                Geo oNuevoGeo = new Geo();

                if (oGeo.Agencia == "") // Sucursal                
                    oNuevoGeo.Oficina = txtOficina.Text.Trim().ToUpper();
                else //Agencia
                    oNuevoGeo.Oficina = "";

                oNuevoGeo.Area = txtArea.Text.Trim().ToUpper();
                oNuevoGeo.ID = oGeo.ID;
                oNuevoGeo.IdCalle = oGeo.IdCalle;
                oNuevoGeo.Agencia = oGeo.Agencia;
                oNuevoGeo.IDCliente = Program.oUsuario.IdCliente;

                try
                {
                    this.oListaOficinas = Metodos.ModificarPuntoEntrega(oNuevoGeo);
                    if (this.oListaOficinas == null) return;

                    if (this.oListaOficinas[0].ID > 0)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else if (this.oListaOficinas[0].ID == -2)
                    {
                        Program.mensaje("Ya existe un área con el mismo nombre en la dirección seleccionada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Program.mensaje("Error de red. Intente nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar modificar el punto de entrega.");
                }

            }
            else
            {
                //Crear
                Geo oNuevoGeo = new Geo();

                oNuevoGeo.Oficina = txtOficina.Text.Trim().ToUpper();
                oNuevoGeo.Area = txtArea.Text.Trim().ToUpper();
                oNuevoGeo.ID = oGeo.ID;
                oNuevoGeo.Agencia = oGeo.Agencia;
                oNuevoGeo.IDCliente = Program.oUsuario.IdCliente;

                try
                {
                    this.oListaOficinas = Metodos.CrearPuntoEntrega(oNuevoGeo);
                    if (this.oListaOficinas == null) return;

                    if (this.oListaOficinas[0].ID > 0)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else if (this.oListaOficinas[0].ID == -2)
                    {
                        Program.mensaje("Debe vincular una agencia o una sucursal a la dirección seleccionada antes de agregar puntos de entrega.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (this.oListaOficinas[0].ID == -3)
                    {
                        Program.mensaje("Ya existe un área con el mismo nombre en la dirección seleccionada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Program.mensaje("Error de red. Intente nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar crear el punto de entrega.");
                }
            }
        }

        #endregion

        // Revisado
        public frmAgregarPuntoEntrega()
        {
            InitializeComponent();
        }
        // Revisado
        private void frmAgregarPuntoEntrega_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        // Revisado
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        // Revisado
        private void txtOficina_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }
        // Revisado
        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }
    }
}
