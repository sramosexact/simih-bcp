using Interna.Entity;
using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmBuscarBandejaOrigen : DevExpress.XtraEditors.XtraForm
    {
        #region Variables

        public Casilla oC = new Casilla();

        #endregion

        #region Metodos

        //2022
        public void BuscarBandeja()
        {

            try
            {
                grdBandejaOrigen.DataSource = Metodos.ListarCasillaOrigen(txtBandejaOrigen.Text.Trim());
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar buscar la bandeja.");
            }

        }
        //2022
        public void ElegirBandeja()
        {
            this.oC = (Casilla)grvBandejaOrigen.GetFocusedRow();
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        #endregion


        public frmBuscarBandejaOrigen()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarBandeja();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            ElegirBandeja();
        }

        private void txtBandejaOrigen_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);

        }

        private void txtBandejaOrigen_TextChanged(object sender, EventArgs e)
        {
            if (txtBandejaOrigen.Text.Length > 1)
            {
                BuscarBandeja();
            }
        }
    }
}
