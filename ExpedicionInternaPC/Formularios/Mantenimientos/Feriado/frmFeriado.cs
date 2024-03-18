using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC.Formularios.Mantenimientos
{
    public partial class frmFeriado : frmChild
    {
        #region Propiedades
        List<Feriado> feriadosEventuales = new List<Feriado>();
        List<Feriado> feriadosPermanentes = new List<Feriado>();
        #endregion

        #region Metodos
        //2022
        public void ListarFeriados()
        {
            try
            {
                List<Feriado> feriados = Metodos.ListarFeriados();
                if (feriados == null) return;
                feriadosEventuales = feriados.FindAll(x => x.iIdTipoFeriado == 1);
                feriadosPermanentes = feriados.FindAll(x => x.iIdTipoFeriado == 2);
                gcFeriadosEventuales.DataSource = feriadosEventuales;
                gcFeriadosEventuales.RefreshDataSource();
                grdFeriadosPermanentes.DataSource = feriadosPermanentes;
                grdFeriadosPermanentes.RefreshDataSource();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de feriados registrados.");
            }
        }
        //2022
        public void EliminarFeriado(int iIdFeriado, byte iIdTipoFeriado)
        {
            if (iIdTipoFeriado == 2 && Program.oUsuario.IdTipoAcceso != 80)
            {
                Program.mensaje("No puedes eliminar un feriado con Región Nacional", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Program.mensaje("Se va a eliminar el feriado. ¿Desea continuar?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                return;
            }

            try
            {
                int respuesta = Metodos.EliminarFeriado(new Feriado(iIdFeriado));
                switch (respuesta)
                {
                    case 1:
                        Program.mensaje("Se ha eliminado el feriado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListarFeriados();
                        break;
                    case -2:
                        Program.mensaje("No existe el feriado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;
                    case -3:
                        Program.mensaje("No se puede eliminar el feriado, ya pasó la fecha", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        break;
                    default:
                        Program.mensaje("Ha ocurrido un error. Inténtelo nuevamente más tarde.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar eliminar el feriado seleccionado.");
            }
        }

        #endregion

        public frmFeriado()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmFeriadoNuevo frm = new frmFeriadoNuevo();
            frm.ShowDialog(this);
            ListarFeriados();
        }

        private void frmFeriado_Load(object sender, EventArgs e)
        {
            ListarFeriados();
        }

        private void imgEliminarFeriadoEventual_Click(object sender, EventArgs e)
        {

        }

        private void imgEliminarFeriadoPermanente_Click(object sender, EventArgs e)
        {

        }

        private void linkEliminarFeriadoEventual_Click(object sender, EventArgs e)
        {

        }

        private void linkEliminarFeriadoPermanente_Click(object sender, EventArgs e)
        {
            Feriado feriadoSeleccionado = (Feriado)grvFeriadosPermanentes.GetFocusedRow();

            EliminarFeriado(feriadoSeleccionado.iIdFeriado, feriadoSeleccionado.iIdTipoFeriado);
        }

        private void hlEliminarFeriadoEventual_Click(object sender, EventArgs e)
        {
            Feriado feriadoSeleccionado = (Feriado)gvFeriadosEventuales.GetFocusedRow();

            EliminarFeriado(feriadoSeleccionado.iIdFeriado, feriadoSeleccionado.iIdTipoFeriado);
        }
    }
}
