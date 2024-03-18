using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Mantenimientos.PuntoEntrega.BandejaFisicaPisos
{
    public partial class frmNuevaBandejaFisica : frmChild
    {
        #region "Variables"

        private int idExpedicion;

        #endregion

        #region "Metodos"

        private void guardarBandejaFisica(string nombreBandejaFisica)
        {
            if (!validarNombre(nombreBandejaFisica))
            {
                Program.mensaje("Debe ingresar un nombre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                Program.ShowPopWaitScreen();
                int resultado = Metodos.CrearBandejaFisica(nombreBandejaFisica, idExpedicion);
                Program.HidePopWaitScreen();

                if (resultado > 0)
                {
                    Program.mensaje("Bandeja registrada correctamente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.OK;
                }
                else if (resultado == -1)
                {
                    Program.mensaje("La expedición seleccionada no existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (resultado == -2)
                {
                    Program.mensaje("El nombre ingresado ya se encuentra registrado para la expedición seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Program.mensaje("Ha ocurrido un error al intentar realizar la acción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Program.HidePopWaitScreen();
                Program.mensaje("Ha ocurrido un error al intentar realizar la acción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool validarNombre(string nombre)
        {
            return nombre.Trim().Length > 0;
        }

        #endregion

        public frmNuevaBandejaFisica(int idExpedicion)
        {
            this.idExpedicion = idExpedicion;
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarBandejaFisica(txtBandejaFisica.Text.Trim().ToUpper());
        }
    }
}
