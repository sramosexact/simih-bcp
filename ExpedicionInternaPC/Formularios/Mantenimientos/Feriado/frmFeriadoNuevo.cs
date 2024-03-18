using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Mantenimientos
{
    public partial class frmFeriadoNuevo : frmChild
    {

        #region Propiedades

        List<TipoFeriado> tiposFeriado = new List<TipoFeriado>();

        #endregion

        #region Metodos
        //2022
        public void ListarTiposFeriado()
        {
            try
            {
                tiposFeriado = Metodos.ListarTiposFeriado();

                lueTiposFeriado.Properties.DataSource = tiposFeriado;
                lueTiposFeriado.Properties.DisplayMember = "sDescripcionTipoFeriado";
                lueTiposFeriado.Properties.ValueMember = "iIdTipoFeriado";
                lueTiposFeriado.Properties.DropDownRows = tiposFeriado.Count;
                lueTiposFeriado.EditValue = null;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar listar los tipos de feriado.");
            }
        }
        //2022
        private void IngresarFeriado(DateTime fechaFeriado, byte iIdTipoFeriado, string sDescripcion)
        {
            Feriado feriado = new Feriado(sDescripcion, fechaFeriado, Program.oUsuario.ID, iIdTipoFeriado);

            try
            {
                int respuesta = Metodos.IngresarFeriado(feriado);

                switch (respuesta)
                {
                    case 1:
                        Program.mensaje("Se ha registrado el feriado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        break;
                    case -2:
                        Program.mensaje("El usuario no está autorizado para el registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    case -3:
                        Program.mensaje("La expedición no está autorizada para el registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    default:
                        break;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar ingresar un feriado.");
            }
        }

        #endregion

        public frmFeriadoNuevo()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFeriadoNuevo_Load(object sender, EventArgs e)
        {
            ListarTiposFeriado();

            deFechaFeriado.Properties.MinValue = DateTime.Now.AddDays(1);
            deFechaFeriado.Properties.MaxValue = DateTime.Now.AddYears(5);
            deFechaFeriado.EditValue = DateTime.Now.AddDays(1);
            deFechaFeriado.Properties.Mask.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("es-PE");
            deFechaFeriado.Properties.Mask.UseMaskAsDisplayFormat = true;
        }

        private void lueTiposFeriado_EditValueChanged(object sender, EventArgs e)
        {
            if ((byte)lueTiposFeriado.EditValue == 2)
            {
                deFechaFeriado.Properties.Mask.EditMask = "dd-MMMM";
                deFechaFeriado.Properties.MinValue = new DateTime(2000, 1, 1);
                deFechaFeriado.Properties.MaxValue = new DateTime(2000, 12, 31);
                deFechaFeriado.EditValue = new DateTime(2000, 1, 1);
            }
            else
            {
                deFechaFeriado.Properties.Mask.EditMask = "dd-MM-yyyy";
                deFechaFeriado.Properties.MinValue = DateTime.Now.AddDays(1);
                deFechaFeriado.Properties.MaxValue = DateTime.Now.AddYears(5);
            }

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (deFechaFeriado.EditValue == null || lueTiposFeriado.EditValue == null || meDescripcion.Text == "")
            {
                Program.mensaje("Ingrese los datos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IngresarFeriado(deFechaFeriado.DateTime, (byte)lueTiposFeriado.EditValue, meDescripcion.Text);

        }

        private void meDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }
    }
}
