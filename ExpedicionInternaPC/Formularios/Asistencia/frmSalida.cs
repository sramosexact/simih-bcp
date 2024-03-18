using Interna.Entity;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmSalida : frmChild
    {
        public frmSalida()
        {
            InitializeComponent();
        }

        private void frmSalida_Load(object sender, EventArgs e)
        {
            txtDni.Text = "";
            lblResultado.Text = "";
        }

        private void txtDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
            {
                return;
            }

            if (!DniEsValido())
            {
                SeleccionarTexto();
                MensajeDNIInvalido();
                lblResultado.Visible = true;
                return;
            }

            RegistrarSalida();
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!DniEsValido())
            {
                SeleccionarTexto();
                MensajeDNIInvalido();
                lblResultado.Visible = true;
                return;
            }

            RegistrarSalida();
        }

        #region Metodos
        private bool DniEsValido()
        {
            if (txtDni.Text.Trim().Length < 8) return false;
            return true;
        }
        private void SeleccionarTexto()
        {
            this.Focus();
            txtDni.Focus();
            txtDni.SelectAll();
        }
        private void MensajeDNIInvalido()
        {
            lblResultado.Text = "El código debe tener 8 caracteres.";
            lblResultado.ForeColor = Color.Red;
        }
        private void MensajeResultado(string mensaje, Color color)
        {
            lblResultado.Text = mensaje;
            lblResultado.ForeColor = color;
        }
        private void RegistrarSalida()
        {
            try
            {
                Registro registro = Metodos.RegistrarSalida(txtDni.Text);
                if (registro.Resultado == 1) MensajeResultado(registro.Mensaje, Color.Green);
                else MensajeResultado(registro.Mensaje, Color.Red);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception ex)
            {
                Program.mensajeError("Ha ocurrido un error al intentar registrar la asistencia.");
            }
            lblResultado.Visible = true;
        }


        #endregion


    }
}
