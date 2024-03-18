using Interna.Entity;
using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmClavSupervisor : frmChild
    {
        #region metodos

        //2022
        private void validar()
        {
            if (validarUsuario(txtClave.Text) == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Program.mensaje("Ingrese correctamente la clave del supervisor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtClave.SelectionStart = 0;
                txtClave.SelectionLength = txtClave.Text.Length;
                txtClave.Focus();
            }
        }
        //2022
        public bool validarUsuario(String Dato)
        {
            bool res = false;
            Usuario oO = new Usuario();
            try
            {
                oO = Metodos.ListarUsuarioDato1(Dato, Program.oUsuario.IdExpedicion)[0];
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return false;
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar validar la clave del supervisor.");
            }

            int x = oO.Preferida;
            if (x == 1) res = true;
            return res;
        }

        #endregion

        // Revisado
        public frmClavSupervisor()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            validar();
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtClave.Text.Length > 0 && e.KeyCode == Keys.Enter)
            {
                validar();
            }
        }

    }
}
