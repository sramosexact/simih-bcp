using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Gestion
{
    public partial class frmCodigoAutogenerado : Form
    {
        public string autogenerado;
        public frmCodigoAutogenerado()
        {
            InitializeComponent();
        }

        private void frmCodigoAutogenerado_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
        }

        private void frmCodigoAutogenerado_Load(object sender, EventArgs e)
        {
            txtAutogenerado.Text = this.autogenerado;
        }
    }
}
