using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public partial class frmDocumentoSeguimiento : frmChild
    {
        #region Variables

        public Documento oDocumento;
        private List<Documento> ListaSeguimiento;
        #endregion

        #region Metodos

        // Revisado
        public void CargarSeguimiento()
        {
            try
            {
                ListaSeguimiento = Metodos.ListarSeguimientoDocumento(oDocumento);
                grdSeguimiento.DataSource = ListaSeguimiento;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }

        }
        #endregion

        // Revisado
        public frmDocumentoSeguimiento()
        {
            InitializeComponent();
        }

        private void frmDocumentoSeguimiento_Load(object sender, EventArgs e)
        {

        }
    }
}
