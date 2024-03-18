using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmSeleccionarColaborador : frmChild
    {
        #region Variables
        public Usuario oUsuario;
        #endregion

        #region Metodos

        //2022
        private void CargarColaboradores()
        {
            try
            {
                List<Usuario> lUsuario = Metodos.ListarColaboradoresExpedicion();
                cboColaboradores.Properties.DataSource = lUsuario;
                cboColaboradores.Properties.DisplayMember = "Descripcion";
                cboColaboradores.Properties.ValueMember = "ID";
                cboColaboradores.Properties.DropDownRows = lUsuario.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                Cancelar();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de colaboradores.");
                Cancelar();
            }

        }
        //2022
        private void Aceptar()
        {
            if (cboColaboradores.EditValue != null)
            {
                oUsuario = (Usuario)cboColaboradores.GetSelectedDataRow();

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                Program.mensaje("Selecciona un colaborador de la lista.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        //2022
        private void Cancelar()
        {
            oUsuario = null;
            this.DialogResult = DialogResult.Abort;
        }

        #endregion


        public frmSeleccionarColaborador()
        {
            InitializeComponent();
        }

        private void frmSeleccionarColaborador_Load(object sender, EventArgs e)
        {
            oUsuario = null;
            CargarColaboradores();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
    }
}
