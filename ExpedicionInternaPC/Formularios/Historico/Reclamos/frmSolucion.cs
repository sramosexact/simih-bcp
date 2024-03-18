using Interna.Entity;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ExpedicionInternaPC
{
    public partial class frmSolucion : frmChild
    {
        #region Propiedades
        public int iIdReclamo { get; set; }
        public ListaReclamoView reclamoView { get; set; }
        public List<TipoReclamoUTD> listaTipoReclamoUTD { get; set; }
        public List<TipoResponsable> listaTipoResponsable { get; set; }
        public List<TipoResponsable> listaTipoResponsableAMostrar { get; set; }
        public Reclamo reclamo = new Reclamo();
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
            btnCorregir.Visible = reclamoView.iCorreccion == 1;
            if (reclamoView.iIdTipoReclamoUTD != 0)
            {
                lueTipoReclamoUTD.EditValue = reclamoView.iIdTipoReclamoUTD;
                lueTipoResponsable.EditValue = reclamoView.iIdTipoResponsable;
                memoAccion.Text = reclamoView.sAccionInmediata;
                memoCausa.Text = reclamoView.sCausa;
                memoSolucion.Text = reclamoView.sSolucion;
                txtResponsable.Text = reclamoView.sPersonaResponsable;
                panelControl2.Enabled = false;
                btnPrimeraRespuesta.Visible = false;

            }
        }

        public void ListarTipoReclamoUTD()
        {
            try
            {
                listaTipoReclamoUTD = Metodos.ListarTipoReclamoUTDActivo();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            lueTipoReclamoUTD.Properties.DataSource = listaTipoReclamoUTD;
            lueTipoReclamoUTD.Properties.DisplayMember = "sDescripcionTipoReclamoUTD";
            lueTipoReclamoUTD.Properties.ValueMember = "iIdTipoReclamoUTD";
            lueTipoReclamoUTD.Properties.DropDownRows = listaTipoReclamoUTD.Count;
        }

        public void ListarTipoResponsable()
        {
        }

        public void RegistrarSolucionReclamo()
        {
            reclamo.iIdReclamo = iIdReclamo;
            reclamo.sPersonaResponsable = txtResponsable.Text;
            reclamo.sAccionInmediata = memoAccion.Text;
            reclamo.sCausa = memoCausa.Text;
            reclamo.sSolucion = memoSolucion.Text;
            if (lueTipoReclamoUTD.EditValue == null || memoAccion.Text == "" || memoSolucion.Text == "")
            {
                Program.mensaje("Ingrese los datos que están habilitados para edición", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            reclamo.iIdTipoReclamoUTD = (byte)lueTipoReclamoUTD.EditValue;
            if (tsFundado.IsOn)
            {
                if (lueTipoReclamoUTD.EditValue != null && lueTipoResponsable.EditValue != null &&
                    txtResponsable.Text != "" && memoAccion.Text != "" && memoCausa.Text != "" && memoSolucion.Text != "")
                {
                    reclamo.iIdTipoResponsable = (byte)lueTipoResponsable.EditValue;
                    reclamo.iFundado = 1;
                }
                else
                {
                    Program.mensaje("Ingrese todos los datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            else
            {
                reclamo.iIdTipoReclamoUTD = 0;
                reclamo.iIdTipoResponsable = 0;
                reclamo.iFundado = 0;
            }

            int respuesta = 0;
            try
            {
                respuesta = Metodos.RegistrarSolucion(reclamo);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }


            if (respuesta == 1)
            {
                Program.mensaje("Se ha registrado la solución del reclamo con éxito.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                Program.mensaje("Ha ocurrido un problema, inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void mostrarListaTipoResponsable(bool esFundado)
        {

            if (esFundado)
            {
                listaTipoResponsableAMostrar = listaTipoResponsable.FindAll(x => x.iIdTipoResponsable != 1);
                lueTipoResponsable.Properties.DataSource = listaTipoResponsableAMostrar;
                lueTipoResponsable.Properties.DisplayMember = "sDescripcionTipoResponsable";
                lueTipoResponsable.Properties.ValueMember = "iIdTipoResponsable";
                lueTipoResponsable.Properties.DropDownRows = listaTipoResponsableAMostrar.Count;
                lueTipoResponsable.EditValue = null;
            }
            else
            {
                listaTipoResponsableAMostrar = listaTipoResponsable.FindAll(x => x.iIdTipoResponsable == 1);
                lueTipoResponsable.Properties.DataSource = listaTipoResponsableAMostrar;
                lueTipoResponsable.Properties.DisplayMember = "sDescripcionTipoResponsable";
                lueTipoResponsable.Properties.ValueMember = "iIdTipoResponsable";
                lueTipoResponsable.Properties.DropDownRows = listaTipoResponsableAMostrar.Count;
                lueTipoResponsable.EditValue = (byte)1;
            }
            lueTipoResponsable.Enabled = esFundado;

        }



        #endregion

        public frmSolucion()
        {
            InitializeComponent();
        }



        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmSolucion_Load(object sender, EventArgs e)
        {
            ListarDetalleReclamo();
            ListarTipoReclamoUTD();
            try
            {
                listaTipoResponsable = Metodos.ListarTipoResponsableActivo();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            mostrarListaTipoResponsable(tsFundado.IsOn);

        }

        private void tsFundado_Toggled(object sender, EventArgs e)
        {
            memoCausa.Enabled = tsFundado.IsOn;
            memoCausa.Text = "";
            txtResponsable.Enabled = tsFundado.IsOn;
            txtResponsable.Text = "";
            mostrarListaTipoResponsable(tsFundado.IsOn);
        }

        private void btnPrimeraRespuesta_Click(object sender, EventArgs e)
        {
            RegistrarSolucionReclamo();
        }

        private void memoAccion_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void memoAccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void memoCausa_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtResponsable_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void memoSolucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void btnCorregir_Click(object sender, EventArgs e)
        {
            frmCorreccion frm = new frmCorreccion();
            frm.reclamo.iIdReclamo = iIdReclamo;
            frm.ShowDialog(this.Parent);
        }
    }
}
