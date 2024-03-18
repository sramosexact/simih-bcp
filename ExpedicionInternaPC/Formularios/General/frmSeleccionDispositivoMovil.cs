using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC

{
    public partial class frmSeleccionDispositivoMovil : frmChild
    {
        public frmSeleccionDispositivoMovil()
        {
            InitializeComponent();
        }

        private void btnWindowsMobile_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAndroid_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
