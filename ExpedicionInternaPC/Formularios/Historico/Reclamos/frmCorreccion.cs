using Interna.Entity;
using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmCorreccion : frmChild
    {

        #region Propiedades

        public Reclamo reclamo = new Reclamo();

        #endregion

        #region Metodos

        public void GuardarCorreccion()
        {
            if (memoEdit1.Text == "")
            {
                Program.mensaje("Ingrese la solución corregida.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            reclamo.sCorreccion = memoEdit1.Text;

            int respuesta = 0;

            try
            {
                respuesta = Metodos.GuardarCorreccion(reclamo);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }

            if (respuesta == 1)
            {
                Program.mensaje("Se ha registrado la corrección de la solución correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                Program.mensaje("Ha ocurrido un error. Inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion



        public frmCorreccion()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCorreccion();
        }

        private void frmCorreccion_Load(object sender, EventArgs e)
        {
            this.Text = "Corregir la solución del reclamo: " + reclamo.iIdReclamo.ToString();
        }
    }
}
