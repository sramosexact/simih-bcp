using Interna.Entity;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmVerficacion : frmChild
    {

        #region Propiedades
        public int iIdReclamo { get; set; }
        public ListaReclamoView reclamoView { get; set; }
        public List<EstadoVerificacion> ListaEstadoVerificacion;
        public List<EstadoVerificacion> ListaEstadoVerificacionDisponibles;
        public List<TipoReclamoJefe> ListaTipoReclamoJefe;
        public int iCantidadFundado { get; set; }
        #endregion

        #region Metodos

        public void ListarDetalleReclamo()
        {
            try
            {
                reclamoView = Metodos.ListarDetalleReclamo(iIdReclamo);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            lblFecha.Text = reclamoView.dFechaRegistro.ToShortDateString();
            lblUsuario.Text = reclamoView.sUsuarioCliente;
            lblArea.Text = reclamoView.sArea;
            lblDetalle.Text = reclamoView.sDetalle;
            lblTipo.Text = reclamoView.sTipoReclamoUsuario;
            lblDocReferencia.Text = reclamoView.sDocReferencia;
            lblFundado.Text = reclamoView.sFundado;
            lblTipoReclamoUtd.Text = reclamoView.sTipoReclamoUTD;
            lblAccion.Text = reclamoView.sAccionInmediata;
            lblCausa.Text = reclamoView.sCausa;
            lblTipoResponsable.Text = reclamoView.sTipoResponsable;
            lblResponsable.Text = reclamoView.sPersonaResponsable;
            lblSolucion.Text = reclamoView.sSolucion;
            cboEmiteAC.Enabled = reclamoView.iIdEstadoVerificacion != 3;
            rtcCalificacion.EditValue = reclamoView.iCalificacion;
            cboObservado.EditValue = reclamoView.iObservado == 1;
            txtObservacion.Enabled = reclamoView.iObservado == 1;
            txtObservacion.Text = reclamoView.sObservacion;
            cboEmiteAC.EditValue = reclamoView.iIdEstadoVerificacion;
            lueTipoReclamoJefe.EditValue = reclamoView.iIdTipoReclamoJefe;
            if (reclamoView.iIdTipoReclamoJefe == 0)
            {
                lueTipoReclamoJefe.EditValue = null;
            }


            if (reclamoView.iCorreccion == 1 && reclamoView.sCorreccion == "")
            {
                panelControl3.Enabled = false;
            }
        }

        public void cargarEstadoVerificacion()
        {
            try
            {
                ListaEstadoVerificacion = Metodos.ListarEstadoVerificacion();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }


            if (iCantidadFundado >= 3)
            {
                ListaEstadoVerificacion.Remove(ListaEstadoVerificacion.Find(x => x.iIdEstadoVerificacion == 2));
            }


            cboEmiteAC.Properties.DataSource = ListaEstadoVerificacion;
            cboEmiteAC.Properties.DisplayMember = "sDescripcionEstadoVerificacion";
            cboEmiteAC.Properties.ValueMember = "iIdEstadoVerificacion";
            cboEmiteAC.Properties.DropDownRows = ListaEstadoVerificacion.Count;
        }

        public void ListarTiposReclamoJefe()
        {
            try
            {
                ListaTipoReclamoJefe = Metodos.ListarTiposReclamoJefe();
                lueTipoReclamoJefe.Properties.DataSource = ListaTipoReclamoJefe;
                lueTipoReclamoJefe.Properties.DisplayMember = "sDescripcion";
                lueTipoReclamoJefe.Properties.ValueMember = "iIdTipoReclamoJefe";
                lueTipoReclamoJefe.Properties.DropDownRows = ListaTipoReclamoJefe.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }
        }

        public void guardarVerificacion()
        {
            Reclamo oReclamo = new Reclamo();
            oReclamo.iIdReclamo = iIdReclamo;
            oReclamo.iCalificacion = Convert.ToByte(rtcCalificacion.EditValue);
            oReclamo.iObservado = Convert.ToByte(cboObservado.EditValue);
            oReclamo.sObservacion = txtObservacion.Text.Trim().ToUpper();
            oReclamo.iIdEstadoVerificacion = Convert.ToByte(cboEmiteAC.EditValue);
            oReclamo.iIdTipoReclamoJefe = Convert.ToByte(lueTipoReclamoJefe.EditValue);

            int respuesta = 0;

            try
            {
                respuesta = Metodos.RegistrarVerificacion(oReclamo);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            if (respuesta == 1)
            {
                Program.mensaje("Se ha registrado la verificación del reclamo correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.Close();
                return;
            }
            Program.mensaje("Ha ocurrido un problema, inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void manejarEventoGuardarVerificacion()
        {
            if (Convert.ToInt32(cboEmiteAC.EditValue) == 1)
            {
                Program.mensaje("Seleccione si emite AC.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(rtcCalificacion.EditValue) == 0)
            {
                Program.mensaje("Califique la gestión del reclamo.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lueTipoReclamoJefe.EditValue == null || Convert.ToInt32(lueTipoReclamoJefe.EditValue) == 0)
            {
                Program.mensaje("Ingrese el tipo de reclamo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            guardarVerificacion();
        }


        #endregion

        public frmVerficacion()
        {
            InitializeComponent();
        }

        private void cboObservado_Toggled(object sender, EventArgs e)
        {
            if (Convert.ToByte(cboObservado.EditValue) == 1)
            {
                txtObservacion.Enabled = true;

            }
            else
            {
                txtObservacion.Enabled = false;
            }
            txtObservacion.Text = "";
        }

        private void cboEmiteAC_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            manejarEventoGuardarVerificacion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtcCalificacion_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void frmVerficacion_Load(object sender, EventArgs e)
        {
            cargarEstadoVerificacion();
            ListarDetalleReclamo();
            ListarTiposReclamoJefe();
        }

        private void txtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void labelControl16_Click(object sender, EventArgs e)
        {

        }

        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
