using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Mantenimientos
{
    public partial class frmAsociarCampoTipoDocumentoDigitalizacion : frmChild
    {
        #region Propiedades 
        public TipoDocumento oTipoDocumento;
        private List<CampoDigitalizacion> camposDigitalizacion = new List<CampoDigitalizacion>();
        public Casilla oCasilla;
        #endregion

        #region Metodos

        //Revisado
        private void CargarEncabezado()
        {
            lblModulo.Text = "Módulo: Digitalización ";
            lblTipoDocumento.Text = "TipoDocumento: " + oTipoDocumento.sDescripcionTipoDocumento;
        }

        private void posicionarControl()
        {
            if (ceIdentificador.Visible == true)
            {
                ceIdentificador.Location = new Point(309, 173);
                chkOpcional.Location = new Point(411, 173);
            }
            else
            {
                chkOpcional.Location = new Point(309, 173);
            }
        }

        //Revisado
        private void AgregarCampo(string campo, bool identificador, bool opcional)
        {
            if (camposDigitalizacion.Exists(x => x.sDescripcion == campo))
            {
                Program.mensaje("Ya existe el campo ingresado.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CampoDigitalizacion campoDigitalizacion = new CampoDigitalizacion();
            campoDigitalizacion.sDescripcion = campo;
            campoDigitalizacion.iIdentificador = identificador ? 1 : 0;
            campoDigitalizacion.opcional = opcional;
            camposDigitalizacion.Add(campoDigitalizacion);
            ceIdentificador.Visible = !identificador && ceIdentificador.Visible;
            RefrescarGrillaCampos();
            ceIdentificador.EditValue = false;
            chkOpcional.Checked = false;
            txtCampo.Text = "";

            posicionarControl();
            txtCampo.Focus();
        }

        //Revisado
        private void EliminarCampo(CampoDigitalizacion campoDigitalizacion)
        {
            if (Program.mensaje("Está seguro de eliminar el campo " + campoDigitalizacion.sDescripcion, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                camposDigitalizacion.Remove(campoDigitalizacion);
                ceIdentificador.Visible = campoDigitalizacion.iIdentificador == 1;
                chkOpcional.Checked = false;
                RefrescarGrillaCampos();
                posicionarControl();
            }
        }

        //Revisado
        private void RefrescarGrillaCampos()
        {
            grcCampos.DataSource = camposDigitalizacion;
            grcCampos.RefreshDataSource();
        }

        //Revisado
        private void CrearAsociacion()
        {
            if (camposDigitalizacion.Count < 2)
            {
                Program.mensaje("Debe ingresar al menos 2 campos al documento de digitalización.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!camposDigitalizacion.Exists(x => x.iIdentificador == 1))
            {
                Program.mensaje("Algún campo debe ser identificador.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!camposDigitalizacion.Exists(x => (x.iIdentificador == 0 && x.opcional == false)))
            {
                Program.mensaje("Algún campo debe ser requerido.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            ModuloCreacion oModulo = new ModuloCreacion();
            oModulo.iId = (int)EnumModuloCreacion.DIGITALIZACION;

            JavaScriptSerializer jsonSerialiser = new JavaScriptSerializer();
            string camposJson = jsonSerialiser.Serialize(camposDigitalizacion);
            try
            {
                oTipoDocumento.requiereDigitalizacion = chkRequiereDigitalizacion.Checked;
                int respuesta = 0;
                respuesta = Metodos.AsociarModulo(oModulo, oTipoDocumento, oCasilla, camposJson);

                if (respuesta < 1)
                {
                    Program.mensaje("No se puede completar la acción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Program.mensaje("Se ha asociado la Bandeja al TipoDocumento correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }


            this.Close();
        }





        #endregion

        //Revisado
        public frmAsociarCampoTipoDocumentoDigitalizacion()
        {
            InitializeComponent();
        }
        //Revisado
        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            CampoDigitalizacion campoDigitalizacion = (CampoDigitalizacion)grvCampos.GetFocusedRow();
            EliminarCampo(campoDigitalizacion);
        }
        //Revisado
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCampo.Text != "")
            {
                AgregarCampo(txtCampo.Text, (bool)ceIdentificador.EditValue, chkOpcional.Checked);
            }
        }
        //Revisado
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CrearAsociacion();
        }
        //Revisado
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //Revisado
        private void frmAsociarCampoTipoDocumentoDigitalizacion_Load(object sender, EventArgs e)
        {
            CargarEncabezado();
        }
        //Revisado
        private void txtCampo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.alfanumericosYGuionesBajo(e);
            Program.mayusculas(e);
        }

        private void chkRequiereDigitalizacion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ceIdentifiador_CheckedChanged(object sender, EventArgs e)
        {
            if (ceIdentificador.Checked == true)
            {
                chkOpcional.Checked = false;
                chkOpcional.Enabled = false;
            }
            else
            {
                chkOpcional.Checked = false;
                chkOpcional.Enabled = true;
            }
        }

        private void chkOpcional_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
