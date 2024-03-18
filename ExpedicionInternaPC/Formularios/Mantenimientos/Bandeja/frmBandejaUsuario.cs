using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace ExpedicionInternaPC
{
    public partial class frmBandejaUsuario : frmChild
    {
        #region Variables

        public Casilla oCasilla;
        private List<Usuario> ListaVinculados;
        private List<Usuario> ListaNOVinculados;

        #endregion

        #region Metodos

        //2022
        public void CargarInformacionBandeja()
        {
            lblBandeja.Text = oCasilla.sDescripcion;
            lblUbicacion.Text = string.Format("Ubicación : {0}", oCasilla.Ubicacion);
            lblTipo.Text = string.Format("Tipo : {0} |  Estado : {1}", oCasilla.tipoCasilla, oCasilla.sActivo);
        }
        //2022
        private void CargarAsociados()
        {
            try
            {
                Usuario oUsuario = new Usuario();
                oUsuario.idCasilla = oCasilla.ID;
                ListaVinculados = Metodos.ListarUsuarioBandejaAsociado(oUsuario);
                grdVinculados.DataSource = ListaVinculados;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar listar los usuarios asociados a la bandeja.");
            }

        }
        //2022
        private void BuscarUsuarioNoVinculado(string Descripcion)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.idCasilla = oCasilla.ID;
            oUsuario.Descripcion = Descripcion;

            try
            {
                ListaNOVinculados = Metodos.ListarUsuarioBandejaNoAsociado(oUsuario);
                grdNoVinculados.DataSource = ListaNOVinculados;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los usuarios no asociados a la bandeja.");
            }
        }
        //2022
        private void VincularUsuario()
        {
            Usuario oUsuario = new Usuario();
            oUsuario = (Usuario)grvNoVinculados.GetFocusedRow();
            oUsuario.idCasilla = oCasilla.ID;

            //if (oUsuario.IdTipoAcceso != (int)EnumTipoUsuario.USUARIO)
            //{
            //    Program.mensaje("Solo se pueden vincular los registros de tipo Usuario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            try
            {
                int resultado = Metodos.VincularUsuarioBandeja(oUsuario);

                if (resultado == 1)
                {
                    Usuario ou = new Usuario();
                    ou.CopyToMe(oUsuario);
                    ou.Estado = null;
                    Program.mensaje("El usuario seleccionado ha sido vinculado a la bandeja.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListaNOVinculados = new List<Usuario>();
                    ListaVinculados.Add(ou);
                    grdNoVinculados.DataSource = ListaNOVinculados;
                    grdVinculados.RefreshDataSource();
                    txtUsuario.Text = "";
                    txtUsuario.Focus();
                }
                else if (resultado == -2)
                {
                    Program.mensaje("El usuario seleccionado no se puede vincularse a la bandeja.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (resultado == -3)
                {
                    Program.mensaje("La bandeja no está activa o no existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (resultado == -1)
                {
                    Program.mensaje("Ha ocurrido un error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar vincular el usuario a la bandeja.");
            }
        }
        //2022
        private void DesvincularUsuario()
        {
            Usuario oUsuario = new Usuario();
            oUsuario = (Usuario)grvVinculados.GetFocusedRow();
            oUsuario.idCasilla = oCasilla.ID;

            try
            {
                int resultado = Metodos.DesvincularUsuarioBandeja(oUsuario);

                if (resultado == 1)
                {
                    Program.mensaje("El usuario seleccionado ha sido desvinculado de la bandeja.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ListaVinculados.Remove(oUsuario);
                    grdVinculados.DataSource = ListaVinculados;
                    grdVinculados.RefreshDataSource();

                    if (ListaVinculados.Count == 0)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
                else if (resultado == -2)
                {
                    Program.mensaje("El usuario seleccionado no se puede vincularse a la bandeja.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (resultado == -3)
                {
                    Program.mensaje("La bandeja no existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (resultado == -4)
                {
                    Program.mensaje("No existe la relación entre la bandeja y el usuario seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (resultado == -5)
                {
                    Program.mensaje("No se puede desvincular al propietario de la bandeja.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else if (resultado == -1)
                {
                    Program.mensaje("Ha ocurrido un error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar desvincular el usuario de la bandeja.");
            }


        }

        #endregion

        public frmBandejaUsuario()
        {
            InitializeComponent();
        }

        private void frmBandejaUsuario_Load(object sender, EventArgs e)
        {
            CargarAsociados();
            this.Activate();
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Trim().Length > 2)
            {
                BuscarUsuarioNoVinculado(txtUsuario.Text.Trim());
            }
            else
            {
                ListaNOVinculados = new List<Usuario>();
                grdNoVinculados.DataSource = new List<Usuario>();
            }

        }

        private void lnkVincular_Click(object sender, EventArgs e)
        {
            VincularUsuario();
        }

        private void lnkDesvincular_Click(object sender, EventArgs e)
        {
            DesvincularUsuario();
        }

    }
}
