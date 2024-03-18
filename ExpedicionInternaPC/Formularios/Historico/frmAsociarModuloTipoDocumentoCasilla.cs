using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Mantenimientos
{
    public partial class frmAsociarModuloTipoDocumentoCasilla : frmChild
    {
        #region Propiedades
        List<Casilla> lCasillas = new List<Casilla>();
        public TipoDocumento oTipoDocumento;
        #endregion

        #region Metodos

        #region Manejo De Eventos

        private void manejarEventoTxtBandeja_EditValueChanged()
        {
            if (txtBandeja.Text.Trim().Length >= 3)
            {
                Casilla oCasilla = new Casilla
                {
                    sDescripcion = txtBandeja.Text.Trim()
                };
                cargarBandejasPorAsociarAlTipoDocumento(oCasilla);
            }
        }

        private void manejarEventoLinkVincular_Click()
        {
            if (Program.mensaje("La Bandeja se asociará al TipoDocumento para el módulo de digitalización. ¿Desea continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Casilla oCasilla = (Casilla)grvBandejasNoVinculadas.GetFocusedRow();
                AsociarModulo(oCasilla);
            }
        }
        #endregion

        private void CargarEncabezado()
        {
            lblModulo.Text = "Módulo: Digitalización ";
            lblTipoDocumento.Text = "TipoDocumento: " + oTipoDocumento.sDescripcionTipoDocumento;
        }

        private void cargarBandejasPorAsociarAlTipoDocumento(Casilla oCasilla)
        {
            try
            {
                lCasillas = Metodos.ListarCasillasPorAsociarAlTipoDocumento(oCasilla);
                grdBandejasNoVinculadas.DataSource = lCasillas;
                grdBandejasNoVinculadas.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }

        }

        private void AsociarModulo(Casilla oCasilla)
        {
            frmAsociarCampoTipoDocumentoDigitalizacion frm = new frmAsociarCampoTipoDocumentoDigitalizacion
            {
                oCasilla = oCasilla,
                oTipoDocumento = oTipoDocumento
            };

            frm.ShowDialog(this.Parent);
            if (frm.DialogResult == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }




        #endregion



        public frmAsociarModuloTipoDocumentoCasilla()
        {
            InitializeComponent();
        }

        #region Eventos

        private void txtBandeja_EditValueChanged(object sender, EventArgs e)
        {
            manejarEventoTxtBandeja_EditValueChanged();
        }

        private void linkVincular_Click(object sender, EventArgs e)
        {
            manejarEventoLinkVincular_Click();
        }

        private void txtBandeja_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void frmAsociarModuloTipoDocumentoCasilla_Load(object sender, EventArgs e)
        {
            CargarEncabezado();
        }

        #endregion
    }
}
