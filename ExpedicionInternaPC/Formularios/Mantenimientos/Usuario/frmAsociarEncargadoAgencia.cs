using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmAsociarEncargadoAgencia : frmChild
    {
        #region Variables
        public Usuario oUsuario;
        List<Agencia> lAgenciasAsociadas;
        List<Agencia> lAgenciasNoAsociadas;
        #endregion

        #region Metodos

        //2022
        private void CargarEncabezado()
        {
            lblMatricula.Text = "Matrícula: " + oUsuario.sMatricula;
            lblUsuario.Text = "Usuario: " + oUsuario.Descripcion;
        }
        //2022
        private void CargarAgenciasNoAsociadas()
        {
            string agencia = txtAgencia.Text.Trim();
            try
            {
                lAgenciasNoAsociadas = Metodos.ListarAgenciasNoVinculadasAlUsuario(oUsuario, agencia);
                grdAgenciasNoVinculadas.DataSource = lAgenciasNoAsociadas;
                grdAgenciasNoVinculadas.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar listar las agencias no vinculadas al usuario.");
            }
        }
        //2022
        private void CargarAgenciasAsociadas()
        {
            try
            {
                lAgenciasAsociadas = Metodos.ListarAgenciasVinculadasAlUsuario(oUsuario);
                grdAgenciasVinculadas.DataSource = lAgenciasAsociadas;
                grdAgenciasVinculadas.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar listar las agencias vinculadas al usuario.");
            }

        }
        //2022
        private void VincularEncargadoAgencia(Agencia agencia, Usuario usuario)
        {
            if (Program.mensaje($"Se vinculará la agencia {agencia.sDescripcion}. ¿Desea continuar?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EncargadoAgencia encargadoAgencia = new EncargadoAgencia();
                encargadoAgencia.iIdAgencia = agencia.iId;
                encargadoAgencia.iIdUsuario = usuario.ID;
                try
                {
                    int respuesta = Metodos.VincularEncargadoAgencia(encargadoAgencia);

                    switch (respuesta)
                    {
                        case 1:
                            Program.mensaje("La bandeja seleccionada ha sido vinculada al usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtAgencia.Text = String.Empty;
                            CargarAgenciasAsociadas();
                            frmUsuario frm = (frmUsuario)Program.SetFormActive<frmUsuario>("MantenimientoUsuarios", Program.oMain);
                            frm.SeleccionarUsuario(oUsuario);
                            break;
                        case -2:
                            Program.mensaje("El usuario no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                            break;
                        case -3:
                            Program.mensaje("La agencia no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtAgencia.Text = String.Empty;
                            break;
                        case -4:
                            Program.mensaje("El usuario no es de agencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtAgencia.Text = String.Empty;
                            break;
                        case -1:
                            Program.mensaje("Ha ocurrido un error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtAgencia.Text = String.Empty;
                            break;
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar vincular al usuario a la agencia.");
                }
            }
        }
        //2022
        private void DesvincularEncargadoAgencia(Agencia agencia)
        {

            if (Program.mensaje($"Se desvinculará la agencia {agencia.sDescripcion}. ¿Desea continuar?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EncargadoAgencia encargadoAgencia = new EncargadoAgencia();
                encargadoAgencia.iIdEncargadoAgencia = agencia.iIdEncargadoAgencia;
                try
                {
                    int respuesta = Metodos.DesvincularEncargadoAgencia(encargadoAgencia);

                    switch (respuesta)
                    {
                        case 1:
                            Program.mensaje("La agencia seleccionada ha sido desvinculada del usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarAgenciasAsociadas();
                            frmUsuario frm = (frmUsuario)Program.SetFormActive<frmUsuario>("MantenimientoUsuarios", Program.oMain);
                            //frm.CargarGrillas();
                            frm.SeleccionarUsuario(oUsuario);
                            break;
                        case -2:
                            Program.mensaje("El usuario no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                            break;
                        case -3:
                            Program.mensaje("La agencia no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CargarAgenciasAsociadas();
                            break;
                        case -4:
                            Program.mensaje("El usuario no es de agencia.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CargarAgenciasAsociadas();
                            break;
                        case -1:
                            Program.mensaje("Ha ocurrido un error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar desvincular al usuario a la agencia.");
                }
            }
        }
        #endregion

        public frmAsociarEncargadoAgencia()
        {
            InitializeComponent();
        }

        private void frmAsociarUsuarioBandeja_Load(object sender, EventArgs e)
        {
            CargarEncabezado();
            CargarAgenciasAsociadas();
        }

        private void txtBandeja_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtBandeja_EditValueChanged(object sender, EventArgs e)
        {
            if (txtAgencia.Text.Length > 2)
            {
                CargarAgenciasNoAsociadas();
            }
            else
            {
                grdAgenciasNoVinculadas.DataSource = null;
                grdAgenciasNoVinculadas.RefreshDataSource();
            }
        }

        private void linkVincular_Click(object sender, EventArgs e)
        {
            Agencia agencia = ((Agencia)grvAgenciasNoVinculadas.GetFocusedRow());
            VincularEncargadoAgencia(agencia, oUsuario);
        }

        private void linkDesvincular_Click_1(object sender, EventArgs e)
        {
            Agencia agencia = ((Agencia)grvAgenciasVinculadas.GetFocusedRow());
            DesvincularEncargadoAgencia(agencia);
        }
    }
}
