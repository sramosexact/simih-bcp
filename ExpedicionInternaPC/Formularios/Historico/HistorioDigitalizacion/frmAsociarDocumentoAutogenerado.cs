using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmAsociarDocumentoAutogenerado : frmChild
    {

        #region Variales

        public List<Tipo> ListaTipoDocumento;
        public List<Casilla> ListaDestino;

        public int iDestino = 0;
        public int iTipoDocumento = 0;
        #endregion

        #region Metodos
        // Revisado
        public void CargarDestino()
        {
            cboDestino.Properties.DataSource = ListaDestino;
            cboDestino.Properties.ValueMember = "ID";
            cboDestino.Properties.DisplayMember = "sDescripcion";
            cboDestino.Properties.DropDownRows = ListaDestino.Count;
            cboDestino.EditValue = null;
        }
        // Revisado
        public void CargarTipoDocumento()
        {
            cboTipoDocumento.Properties.DataSource = ListaTipoDocumento;
            cboTipoDocumento.Properties.ValueMember = "ID";
            cboTipoDocumento.Properties.DisplayMember = "Descripcion";
            cboTipoDocumento.Properties.DropDownRows = ListaTipoDocumento.Count;
            cboTipoDocumento.EditValue = null;
        }
        // Revisado
        private void AsociarAutogenerado()
        {
            if (cboDestino.EditValue != null || cboTipoDocumento.EditValue != null)
            {
                if (cboDestino.EditValue != null)
                {
                    iDestino = (int)cboDestino.EditValue;
                }
                if (cboTipoDocumento.EditValue != null)
                {
                    iTipoDocumento = (int)cboTipoDocumento.EditValue;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                Program.mensaje("Debe como filtro el tipo de documento para crear el Autogenerado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        #endregion

        // Revisado
        public frmAsociarDocumentoAutogenerado()
        {
            InitializeComponent();
        }
        // Revisado
        private void frmAsociarDocumentoAutogenerado_Load(object sender, EventArgs e)
        {
            CargarDestino();
            CargarTipoDocumento();
        }
        // Revisado
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            AsociarAutogenerado();
        }
        // Revisado
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
