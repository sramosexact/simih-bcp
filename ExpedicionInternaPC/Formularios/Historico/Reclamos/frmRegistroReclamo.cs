using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmRegistroReclamo : frmChild
    {

        #region Propiedades

        public Usuario usuarioReclamo = new Usuario();
        public List<TipoReclamoUsuario> ListaTipoReclamoUsuario = new List<TipoReclamoUsuario>();

        #endregion

        #region Metodos

        public void ListarTiposReclamoUsuario()
        {
            try
            {
                ListaTipoReclamoUsuario = Metodos.ListarTipoReclamoUsuario();
                lueTipoReclamoUsuario.Properties.DataSource = ListaTipoReclamoUsuario;
                lueTipoReclamoUsuario.Properties.DisplayMember = "sDescripcionTipoReclamoUsuario";
                lueTipoReclamoUsuario.Properties.ValueMember = "iIdTipoReclamoUsuario";
                lueTipoReclamoUsuario.Properties.DropDownRows = ListaTipoReclamoUsuario.Count;
                lueTipoReclamoUsuario.EditValue = (byte)1;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
        }

        public void RegistrarReclamoDesdeUTD(int iIdUsuario, int iIdUsuarioAtencion, byte iIdTipoReclamoUsuario, string sDocReferencia, string sDetalle, DateTime dFechaAtencion, DateTime dFechaRegistro)
        {
            try
            {
                int respuesta = Metodos.RegistrarReclamoDesdeUTD(iIdUsuario, iIdUsuarioAtencion, iIdTipoReclamoUsuario, sDocReferencia, sDetalle, dFechaAtencion, dFechaRegistro);

                if (respuesta == 1)
                {
                    Program.mensaje("Se ha registrado correctamente el reclamo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    Program.mensaje("Ha ocurrido un error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();

            }
        }

        #endregion


        public frmRegistroReclamo()
        {
            InitializeComponent();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            frmBuscarUsuario frm = new frmBuscarUsuario(this);
            frm.ShowDialog(this);
            if (frm.DialogResult == DialogResult.OK)
            {
                txtUsuario.Text = usuarioReclamo.Descripcion;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lueTipoReclamoUsuario_EditValueChanged(object sender, EventArgs e)
        {
            lblDocumentoReferencia.Visible = Convert.ToInt32(lueTipoReclamoUsuario.EditValue) == 1;
            txtDocumentoReferencia.Visible = Convert.ToInt32(lueTipoReclamoUsuario.EditValue) == 1;
        }

        private void frmRegistroReclamo_Load(object sender, EventArgs e)
        {
            ListarTiposReclamoUsuario();
            dtFechaAtencion.MaxDate = DateTime.Now;
            dtFechaReclamo.MaxDate = DateTime.Now;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == String.Empty)
            {
                Program.mensaje("Ingrese el usuario que hace el reclamo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToByte(lueTipoReclamoUsuario.EditValue) == (byte)1 && txtDocumentoReferencia.Text == String.Empty)
            {
                Program.mensaje("Ingrese el documento de referencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (memoEdit1.Text == String.Empty)
            {
                Program.mensaje("Ingrese el detalle del reclamo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RegistrarReclamoDesdeUTD(usuarioReclamo.ID, Program.oUsuario.ID, Convert.ToByte(lueTipoReclamoUsuario.EditValue), txtDocumentoReferencia.Text, memoEdit1.Text, dtFechaAtencion.Value, dtFechaReclamo.Value);
        }
    }
}
