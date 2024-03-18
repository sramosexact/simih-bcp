using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Mantenimientos
{
    public partial class frmEditarCamposDinamicos : frmChild
    {
        #region Variables

        private TipoDocumento tipoDocumento;

        private List<CampoDigitalizacion> CampoDigitalizacionList;

        private bool CambiosPendientes = false;

        #endregion

        #region Metodos

        private void CargarControles()
        {
            this.Text = $"{this.tipoDocumento.sDescripcionTipoDocumento} - Mantenimiento de campos";
            lblTipoDocumento.Text = this.tipoDocumento.sDescripcionTipoDocumento;
            chkRequiereDigitalizacion.Checked = this.tipoDocumento.requiereDigitalizacion;
            ListarCamposDocumento();
        }

        private void ListarCamposDocumento()
        {
            CampoDigitalizacionList = Metodos.ListarCamposPorTipoDocumento(tipoDocumento);
            grdCampos.DataSource = CampoDigitalizacionList;
        }

        private void AgregarCampo(string campo, bool opcional)
        {
            if (txtCampo.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese el campo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCampo.Focus();
                return;
            }

            if (CampoDigitalizacionList.Exists(x => x.sDescripcion == campo))
            {
                Program.mensaje("Ya existe el campo ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCampo.Focus();
                txtCampo.SelectAll();
                return;
            }

            CampoDigitalizacion campoDigitalizacion = new CampoDigitalizacion();
            campoDigitalizacion.sDescripcion = campo;
            campoDigitalizacion.iIdentificador = 0;
            campoDigitalizacion.opcional = opcional;
            campoDigitalizacion.iActivo = 1;
            CampoDigitalizacionList.Add(campoDigitalizacion);
            chkOpcional.Checked = false;
            txtCampo.Text = "";
            txtCampo.Focus();
            grdCampos.DataSource = CampoDigitalizacionList;
            grvCampos.RefreshData();
            CambiosPendientes = true;

        }

        private void CambiarEstado()
        {
            CampoDigitalizacion oCampoDigitalizacion = (CampoDigitalizacion)grvCampos.GetFocusedRow();

            if (oCampoDigitalizacion.iIdentificador == 1)
            {
                Program.mensaje("No se puede cambiar el estado al campo identificador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (Program.mensaje($"Desea {(oCampoDigitalizacion.iActivo == 1 ? "desactivar" : "activar")} el campo {oCampoDigitalizacion.sDescripcion}", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CampoDigitalizacionList.Find(x => x.iIdCampoDigitalizacion == oCampoDigitalizacion.iIdCampoDigitalizacion).iActivo = oCampoDigitalizacion.iActivo == 1 ? 0 : 1;
                    grdCampos.Refresh();
                    grvCampos.RefreshData();
                }

                CambiosPendientes = true;
                txtCampo.Focus();
            }
        }

        private void GuardarCambios()
        {

            if (CambiosPendientes == false)
            {
                Program.mensaje("No hay cambios pendientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!CampoDigitalizacionList.Exists(x => (x.iIdentificador == 0 && x.opcional == false && x.iActivo == 1)))
            {
                Program.mensaje("Al menos un campo activo debe ser requerido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TipoDocumento oTipoDocumento = new TipoDocumento();
            oTipoDocumento.iIdTipoDocumento = this.tipoDocumento.iIdTipoDocumento;
            oTipoDocumento.requiereDigitalizacion = chkRequiereDigitalizacion.Checked;

            JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
            string camposJson = jsonSerialiser.Serialize(CampoDigitalizacionList);

            try
            {
                int respuesta = 0;
                respuesta = Metodos.EditarCamposDocumentosEspeciales(oTipoDocumento, camposJson);

                if (respuesta < 1)
                {
                    Program.mensaje("No se puede completar la acción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                }
                else
                {
                    Program.mensaje("Se han guardado los cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CambiosPendientes = false;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }


        }

        #endregion

        public frmEditarCamposDinamicos(TipoDocumento oTipoDocumento)
        {
            this.tipoDocumento = oTipoDocumento;
            InitializeComponent();
        }

        private void frmEditarCamposDinamicos_Load(object sender, EventArgs e)
        {
            CargarControles();
        }

        private void txtCampo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.alfanumericosYGuionesBajo(e);
            Program.mayusculas(e);
        }

        private void chkRequiereDigitalizacion_CheckedChanged(object sender, EventArgs e)
        {
            CambiosPendientes = true;
        }

        private void chkOpcional_CheckedChanged(object sender, EventArgs e)
        {
            CambiosPendientes = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarCampo(txtCampo.Text, chkOpcional.Checked);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            CambiarEstado();
        }

        private void txtCampo_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
