using ExpedicionInternaPC.Properties;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmConfiguracion : frmChild
    {

        #region VARIABLES

        private string sRutaImpresoraEtiquetas = "";
        private int iCantidadPorImprimir = 0;
        private List<Configuracion> indicadores = new List<Configuracion>();
        private List<Configuracion> diasConfirmacionAutomatica = new List<Configuracion>();
        #endregion

        #region METODOS
        //2022
        private void cargarValoresArchivoConfiguracion()
        {
            this.txtRuta.Text = Settings.Default.RutaImpresoraZebra;
        }
        //2022
        private void cargarIndicadores()
        {
            try
            {
                indicadores = Metodos.ListarIndicadores();
                lueIndicadores.Properties.DataSource = indicadores;
                lueIndicadores.Properties.DisplayMember = "Descripcion";
                lueIndicadores.Properties.ValueMember = "ID";
                lueIndicadores.Properties.DropDownRows = indicadores.Count;
                lueIndicadores.EditValue = null;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de indicadores.");
            }
        }
        //2022
        private void cargarDiasConfirmacionAutomatica()
        {
            try
            {
                diasConfirmacionAutomatica = Metodos.ListarDiasConfirmacionAutomatica();
                lueConfirmacion.Properties.DataSource = diasConfirmacionAutomatica;
                lueConfirmacion.Properties.DisplayMember = "Descripcion";
                lueConfirmacion.Properties.ValueMember = "ID";
                lueConfirmacion.Properties.DropDownRows = diasConfirmacionAutomatica.Count;
                lueConfirmacion.EditValue = null;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar los días de confirmación automática.");
            }

        }
        //2022
        private void guardarValorArchivoConfiguracion()
        {
            try
            {
                Settings.Default.RutaImpresoraZebra = txtRuta.Text.Trim();
                Settings.Default.Save();
                Program.mensaje("Se ha guardado la ruta correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cargarValoresArchivoConfiguracion();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar escribir en el archivo de configuración");
            }

        }
        //2022
        private void guardarRuta()
        {
            if (txtRuta.Text.Trim() == String.Empty)
            {
                Program.mensaje("Ingrese la ruta.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            guardarValorArchivoConfiguracion();
        }
        //2022
        private void ModificarIndicador(int iId, int fValor)
        {
            try
            {
                int respuesta = Metodos.ModificarIndicador(iId, fValor);

                if (respuesta == 1)
                {
                    Program.mensaje("Se ha modificado el indicador correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarIndicadores();
                    lueIndicadores.EditValue = iId;
                }
                else
                {
                    Program.mensaje("Ha ocurrido un error, inténtelo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar modificar el valor del indicador.");
            }

        }
        //2022
        private void ModificarDiasConfirmacionAutomatica(int iId, int fValor)
        {
            try
            {
                int respuesta = Metodos.ModificarIndicador(iId, fValor);

                if (respuesta == 1)
                {
                    Program.mensaje("Se ha modificado los días de confirmación correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDiasConfirmacionAutomatica();
                    lueConfirmacion.EditValue = iId;
                }
                else
                {
                    Program.mensaje("Ha ocurrido un error, inténtelo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar modificar el valor del indicador.");
            }

        }

        #endregion

        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            cargarValoresArchivoConfiguracion();
            cargarIndicadores();
            cargarDiasConfirmacionAutomatica();
            txtTiempo.Properties.IsFloatValue = false;
            spinTiempoConfirmacion.Properties.IsFloatValue = false;
        }

        private void lueIndicadores_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTiempo.Text = ((Configuracion)lueIndicadores.GetSelectedDataRow()).fValor.ToString();
            }
            catch (NullReferenceException ex)
            {
            }

        }

        private void btnGuardarIndicador_Click(object sender, EventArgs e)
        {
            int fl = int.Parse(txtTiempo.Text);
            if (fl > 0)
            {
                try
                {
                    ModificarIndicador(((Configuracion)lueIndicadores.GetSelectedDataRow()).ID, fl);
                }
                catch (NullReferenceException ex)
                {
                    Program.mensaje("Elija el indicador", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                Program.mensaje("Ingrese un valor positivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarRuta_Click(object sender, EventArgs e)
        {
            guardarRuta();
        }

        private void lueConfirmacion_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                spinTiempoConfirmacion.Text = ((Configuracion)lueConfirmacion.GetSelectedDataRow()).fValor.ToString();
            }
            catch (NullReferenceException ex)
            {
            }
        }

        private void btnGuardarConfirmacion_Click(object sender, EventArgs e)
        {
            int fl = int.Parse(spinTiempoConfirmacion.Text);
            if (fl > 0)
            {
                try
                {
                    ModificarDiasConfirmacionAutomatica(((Configuracion)lueConfirmacion.GetSelectedDataRow()).ID, fl);
                }
                catch (NullReferenceException ex)
                {
                    Program.mensaje("Elija el destino", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                Program.mensaje("Ingrese un valor positivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
