using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmBuscarUsuario : frmChild
    {
        #region Propiedades

        public List<Usuario> ListaUsuario = new List<Usuario>();

        public Usuario usuarioReclamo = new Usuario();

        public frmRegistroReclamo frmRegistroReclamo = new frmRegistroReclamo();

        #endregion

        #region Metodos

        public void ListarUsuarios(string sValor, int iIdExpedicion)
        {
            try
            {
                ListaUsuario = Metodos.ListarUsuariosPorNombreOMatricula(sValor, iIdExpedicion);
                grcUsuarios.DataSource = ListaUsuario;
                grcUsuarios.Refresh();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
        }

        #endregion


        public frmBuscarUsuario()
        {
            InitializeComponent();
        }

        public frmBuscarUsuario(frmRegistroReclamo frm)
        {
            frmRegistroReclamo = frm;
            InitializeComponent();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Length > 3)
            {
                ListarUsuarios(txtUsuario.Text.Trim(), Program.oUsuario.IdExpedicion);
            }
        }

        private void linkSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                usuarioReclamo = (Usuario)grvUsuarios.GetFocusedRow();
                frmRegistroReclamo.usuarioReclamo = usuarioReclamo;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (NullReferenceException)
            {

            }
        }
    }
}
