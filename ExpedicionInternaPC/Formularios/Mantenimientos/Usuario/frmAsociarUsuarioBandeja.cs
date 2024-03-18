using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmAsociarUsuarioBandeja : frmChild
    {
        #region Variables
        public Usuario oUsuario;
        List<Casilla> lBandejasAsociadas;
        List<Casilla> lBandejasNoAsociadas;

        #endregion

        #region Metodos

        //2022
        private void CargarEncabezado()
        {
            lblMatricula.Text = "Matrícula: " + oUsuario.sMatricula;
            lblUsuario.Text = "Usuario: " + oUsuario.Descripcion;
        }
        //2022
        private void CargarBandejasNoAsociadas(string sDescripcionCasilla)
        {
            try
            {
                oUsuario.descripcionCasilla = sDescripcionCasilla;
                lBandejasNoAsociadas = Metodos.ListarBandejasNoAsociadasAlUsuario(oUsuario);
                grdBandejasNoVinculadas.DataSource = lBandejasNoAsociadas;
                grdBandejasNoVinculadas.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar las bandejas no asociadas al usuario.");
            }
        }
        //2022
        private void CargarBandejasAsociadas()
        {
            try
            {
                lBandejasAsociadas = Metodos.ListarBandejasAsociadasAlUsuario(oUsuario);
                grdBandejasVinculadas.DataSource = lBandejasAsociadas;
                grdBandejasVinculadas.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar las bandejas asociadas al usuario.");
            }
        }
        //2022
        private void VincularBandeja(Usuario usuario)
        {
            if (Program.mensaje($"Se vinculará la bandeja {usuario.descripcionCasilla}. ¿Desea continuar?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int respuesta = Metodos.VincularUsuarioBandeja(usuario);

                    switch (respuesta)
                    {
                        case 1:
                            Program.mensaje("La bandeja seleccionada ha sido vinculada al usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtBandeja.Text = String.Empty;
                            CargarBandejasAsociadas();
                            frmUsuario frm = (frmUsuario)Program.SetFormActive<frmUsuario>("MantenimientoUsuarios", Program.oMain);
                            frm.SeleccionarUsuario(oUsuario);
                            break;
                        case -2:
                            Program.mensaje("El usuario no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                            break;
                        case -3:
                            Program.mensaje("La bandeja no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtBandeja.Text = String.Empty;
                            break;
                        case -1:
                            Program.mensaje("Ha ocurrido un error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtBandeja.Text = String.Empty;
                            break;
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar vincular la bandeja al usuario.");
                }
            }

        }
        //2022
        private void DesvincularBandeja(Usuario usuario)
        {
            if (Program.mensaje($"Se desvinculará la bandeja {usuario.descripcionCasilla}. ¿Desea continuar?",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int respuesta = Metodos.DesvincularUsuarioBandeja(usuario);

                    switch (respuesta)
                    {
                        case 1:
                            Program.mensaje("La bandeja seleccionada ha sido desvinculada del usuario.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarBandejasAsociadas();
                            frmUsuario frm = (frmUsuario)Program.SetFormActive<frmUsuario>("MantenimientoUsuarios", Program.oMain);
                            frm.SeleccionarUsuario(oUsuario);
                            break;
                        case -2:
                            Program.mensaje("El usuario no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                            break;
                        case -3:
                            Program.mensaje("La bandeja no existe en el sistema.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CargarBandejasAsociadas();
                            break;
                        case -4:
                            Program.mensaje("No existe vínculo con la bandeja.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            CargarBandejasAsociadas();
                            break;
                        case -5:
                            Program.mensaje("No se puede desvincular con su casilla predeterminada.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Program.mensajeError("Ha ocurrido un error al intentar desvincular la bandeja al usuario.");
                }
            }
        }
        #endregion

        public frmAsociarUsuarioBandeja()
        {
            InitializeComponent();
        }

        private void frmAsociarUsuarioBandeja_Load(object sender, EventArgs e)
        {
            CargarEncabezado();
            CargarBandejasAsociadas();
        }

        private void txtBandeja_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtBandeja_EditValueChanged(object sender, EventArgs e)
        {
            if (txtBandeja.Text.Length > 2)
            {
                CargarBandejasNoAsociadas(txtBandeja.Text);
            }
            else
            {
                grdBandejasNoVinculadas.DataSource = null;
                grdBandejasNoVinculadas.RefreshDataSource();
            }
        }

        private void linkVincular_Click(object sender, EventArgs e)
        {
            oUsuario.idCasilla = ((Casilla)grvBandejasNoVinculadas.GetFocusedRow()).ID;
            oUsuario.descripcionCasilla = ((Casilla)grvBandejasNoVinculadas.GetFocusedRow()).sDescripcion;
            VincularBandeja(oUsuario);
        }

        private void linkDesvincular_Click(object sender, EventArgs e)
        {
            oUsuario.idCasilla = ((Casilla)grvBandejasVinculadas.GetFocusedRow()).ID;
            oUsuario.descripcionCasilla = ((Casilla)grvBandejasVinculadas.GetFocusedRow()).sDescripcion;
            oUsuario.IdTipoCasilla = ((Casilla)grvBandejasVinculadas.GetFocusedRow()).IdTipoCasilla;
            if (oUsuario.IdTipoCasilla == (int)EnumTipoCasilla.OPERACION || oUsuario.IdTipoCasilla == (int)EnumTipoCasilla.MESA_DE_PARTES || oUsuario.IdTipoCasilla == (int)EnumTipoCasilla.SUPERVISOR || oUsuario.IdTipoCasilla == (int)EnumTipoCasilla.JEFE)
            {
                Program.mensaje("No se puede desvincular una bandeja de operación.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DesvincularBandeja(oUsuario);
        }
    }
}
