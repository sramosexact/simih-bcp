using ExpedicionInternaPC.Enumeracion;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmNuevaEntregaSucursal : frmChild
    {
        #region Variables

        public EntregaEstado iEstado;
        public Entrega oEntrega;

        #endregion

        #region Metodos
        //2022
        private void listarSucursales()
        {

            List<Palomar> lPalomares = new List<Palomar>();
            try
            {
                lPalomares = Metodos.ListaPalomarExpedicionJSON(Program.oUsuario.IdExpedicion, (int)TipoPalomarDestino.SUCURSALES);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de sucursales.");
                return;
            }

            if (lPalomares == null) { return; }
            if (lPalomares.Count == 0) { return; }

            List<Palomar> lPalomar = lPalomares.FindAll(x => x.IdTipoPalomar == 3).ToList();
            cboSucursales.Properties.DataSource = lPalomar;
            cboSucursales.Properties.ValueMember = "ID";
            cboSucursales.Properties.DisplayMember = "Descripcion";
            cboSucursales.EditValue = null;
            cboSucursales.Properties.DropDownRows = lPalomar.Count;
        }
        //2022
        private void listarColaboradores()
        {
            List<Operario> lColaboradores = new List<Operario>();

            try
            {
                lColaboradores = Metodos.listaOperarioJSON(Program.oUsuario.IdExpedicion);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de colaboradores.");
                return;
            }

            cboColaboradores.Properties.DataSource = lColaboradores;
            cboColaboradores.Properties.ValueMember = "ID";
            cboColaboradores.Properties.DisplayMember = "Descripcion";
            cboColaboradores.EditValue = null;
            cboColaboradores.Properties.DropDownRows = lColaboradores.Count;
        }
        //2022
        private void cargarEntregaSucursal()
        {
            List<Entrega> oe = new List<Entrega>();

            try
            {
                oe = Metodos.EntregaID(oEntrega.ID);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar las entregas.");
                return;
            }

            if (oe != null)
            {
                if (oe.Count > 0)
                {
                    cboColaboradores.EditValue = oe[0].IdUsuarioCreador;
                    cboSucursales.EditValue = oe[0].iDestino;
                }
            }
        }
        //2022
        private void cargarFormulario()
        {
            listarSucursales();
            listarColaboradores();
            if (iEstado == EntregaEstado.Nuevo)
            {
                cboSucursales.Enabled = true;
                cboColaboradores.Enabled = true;
            }
            else if (iEstado == EntregaEstado.Grabado)
            {
                cboSucursales.Enabled = false;
                cboColaboradores.Enabled = true;
                cargarEntregaSucursal();
                btnAccion.Text = "Guardar";
            }
            else
            {
                cboSucursales.Enabled = false;
                cboColaboradores.Enabled = false;
                cargarEntregaSucursal();
                btnAccion.Enabled = false;
                btnCancelar.Enabled = false;
            }
        }
        //2022
        private void crearEntregaSucursal()
        {
            if (cboSucursales.EditValue == null)
            {
                Program.mensaje("Por favor, seleccione Sucursal.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboSucursales.Focus();
                return;
            }

            if (cboColaboradores.EditValue == null)
            {
                Program.mensaje("Por favor, seleccione Operativo.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboColaboradores.Focus();
                return;
            }

            Operario ou = (Operario)cboColaboradores.GetSelectedDataRow();
            Palomar op = (Palomar)cboSucursales.GetSelectedDataRow();
            Expedicion oex = new Expedicion();
            oex.ID = Program.oUsuario.IdExpedicion;

            int resultado = 0;

            try
            {
                resultado = Metodos.CrearEntregaSucursal(oex, op, ou);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar crear la entrega.");
                return;
            }

            if (resultado > 0)
            {
                DialogResult = DialogResult.Yes;
                Program.mensaje(string.Format("La Entrega '{0}' ha sido creada correctamente ", resultado), MessageBoxButtons.OK, MessageBoxIcon.Information);
                Activate();
                Close();
            }
            else
            {
                Program.mensaje("No tiene elementos en Custodia para la Sucursal elegida.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Activate();
            }
        }
        //2022
        private void actualizarEntregaSucursal()
        {
            Operario ou = (Operario)cboColaboradores.GetSelectedDataRow();

            int resultado = 0;

            try
            {
                resultado = Metodos.ActualizarEntregaSucursal(oEntrega.ID, ou.ID);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar actualizar la entrega.");
                return;
            }

            if (resultado > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                Program.mensaje(string.Format("La Entrega '{0}' ha sido modificada correctamente.", resultado), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
                this.Close();
            }
            else
            {
                Program.mensaje("No se pudo guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Activate();
            }
        }

        #endregion

        public frmNuevaEntregaSucursal()
        {
            InitializeComponent();
        }

        private void frmNuevaEntregaSucursal_Load(object sender, EventArgs e)
        {
            cargarFormulario();
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            if (iEstado == EntregaEstado.Nuevo)
            {
                crearEntregaSucursal();
            }
            else
            {
                actualizarEntregaSucursal();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
