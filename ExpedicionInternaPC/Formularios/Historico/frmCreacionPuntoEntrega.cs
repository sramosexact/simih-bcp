using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmCreacionPuntoEntrega : frmChild
    {

        #region Variables

        public Geo oGeo { set; get; }
        public int tipoAccion { set; get; }
        public int opc = 0;
        public List<Geo> oListaOficinas { set; get; }

        #endregion

        #region Constructor

        public frmCreacionPuntoEntrega()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos

        private void ChangeLupTipo()
        {

            int valor = (int)lupTipo.EditValue;
            /*Sucursal*/
            if (valor == 1)
            {
                txtArea.Enabled = true;
                txtDescripcion.Enabled = true;
                lupDestino.Enabled = false;
                txtCodigoAgencia.Enabled = false;
                lupDestino.ItemIndex = -1;
            }
            //Agencia
            else
            {
                lupDestino.Enabled = true;
                txtArea.Enabled = true;
                txtDescripcion.Enabled = true;
                txtCodigoAgencia.Enabled = true;
            }
        }

        private void TipoFormulario()
        {
            if (tipoAccion == 1)
            {
                txtDescripcion.Text = "";
                txtArea.Text = "";
                btnCrear.Text = "Agregar";

                if (oGeo.Expedicion != "")
                {
                    lupTipo.EditValue = 1;
                    lupTipo.Enabled = false;
                    lupDestino.ItemIndex = -1;
                    lupDestino.Enabled = false;
                    txtCodigoAgencia.Enabled = false;
                }
                else if (oGeo.Agencia != "")
                {
                    lupTipo.EditValue = 2;
                    lupDestino.EditValue = oGeo.IdTipoDestino;
                    txtCodigoAgencia.Text = oGeo.CodigoAgencia;
                    txtDescripcion.Text = oGeo.Agencia;
                    lupTipo.Enabled = false;
                    lupDestino.Enabled = false;
                    txtCodigoAgencia.Enabled = false;
                    txtDescripcion.Enabled = false;

                }
                else if (oGeo.Alias3 == "0")
                {
                    lupTipo.EditValue = 1;
                    lupTipo.Enabled = false;
                    lupDestino.ItemIndex = -1;
                    lupDestino.Enabled = false;
                    txtCodigoAgencia.Enabled = false;
                }


            }
            else if (tipoAccion == 2)
            {
                btnCrear.Text = "Actualizar";
                txtDescripcion.Text = this.oGeo.Oficina.Trim().ToUpper();
                txtArea.Text = this.oGeo.Area.Trim().ToUpper();
            }
        }

        private void CrearPuntoEntrega()
        {
            if (txtDescripcion.Text.Trim().Length == 0 || txtArea.Text.Trim().Length == 0)
            {
                MessageBox.Show("Por favor, debe de completar los campos Oficina y Area", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return;
            }

            this.oGeo.Oficina = txtDescripcion.Text.Trim().ToUpper();
            this.oGeo.Area = txtArea.Text.Trim().ToUpper();
            this.oGeo.IdExpedicion = Program.oUsuario.IdExpedicion;
            this.oGeo.IdTipoDestino = lupDestino.EditValue == null ? 0 : (int)lupDestino.EditValue;
            this.oGeo.CodigoAgencia = ((int)lupTipo.EditValue) == 1 ? "" : txtCodigoAgencia.Text;
            this.oGeo.Agencia = ((int)lupTipo.EditValue) == 1 ? "" : txtDescripcion.Text;

            this.DialogResult = System.Windows.Forms.DialogResult.No;
            if (tipoAccion == 1)
            {
                try
                {
                    this.oListaOficinas = Metodos.CrearPuntoEntrega(this.oGeo);
                    if (this.oListaOficinas == null) return;
                    Resultado(this.oListaOficinas);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }

            }
            else if (tipoAccion == 2)
            {
                try
                {
                    this.oListaOficinas = Metodos.ActualizarOficinas(this.oGeo);
                    if (this.oListaOficinas == null) return;
                    Resultado(this.oListaOficinas);
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
            }

            this.Close();
        }


        private void Resultado(List<Geo> resultado)
        {
            if (resultado != null)
            {
                if (resultado[0].ID == -5)
                    Program.mensaje(String.Format("Ya existe una agencia registrada en la direccion seleccionada."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (resultado[0].ID == -4)
                    Program.mensaje(String.Format("El nombre de la agencia ya existe."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (resultado[0].ID == -3)
                    Program.mensaje(String.Format("El código de la agencia ya existe."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (resultado[0].ID == -2)
                    Program.mensaje(String.Format("El nombre del área ya existe."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (resultado[0].ID == -6)
                    Program.mensaje(String.Format("Primero debe asociar una Expedición para poder seguir agregando puntos de entrega en la dirección seleccionada."), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if (resultado[0].ID == -7)
                    Program.mensaje(String.Format("No se puede crear puntos de entrega en la dirección seleccionada. La dirección seleccionada está vinculada a una Expedición de tipo Agencias."), MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultado[0].ID > 0)
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void CargarTipo()
        {
            List<Geo> lGeoTipo = new List<Geo>();
            lGeoTipo.Add(new Geo() { ID = 1, Descripcion = "Sucursal" });
            lGeoTipo.Add(new Geo() { ID = 2, Descripcion = "Agencia" });
            lupTipo.Properties.DataSource = lGeoTipo;
            lupTipo.Properties.ValueMember = "ID";
            lupTipo.Properties.DisplayMember = "Descripcion";
            lupTipo.Properties.NullText = "Seleccione";
            lupTipo.Properties.ShowHeader = false;
            lupTipo.Properties.ShowFooter = false;
            lupTipo.Properties.DropDownRows = 2;
        }

        private void CargarDestino()
        {
            List<Geo> lGeoTipo = new List<Geo>();
            lGeoTipo.Add(new Geo() { ID = (int)Enumeracion.TipoPalomarDestino.AGENCIAS_LIMA, Descripcion = "Agencia Lima" });
            lGeoTipo.Add(new Geo() { ID = (int)Enumeracion.TipoPalomarDestino.AGENCIAS_PROVINCIA, Descripcion = "Agencia Provincia" });
            lupDestino.Properties.DataSource = lGeoTipo;
            lupDestino.Properties.ValueMember = "ID";
            lupDestino.Properties.DisplayMember = "Descripcion";
            lupDestino.Properties.NullText = "Seleccione";
            lupDestino.Properties.ShowHeader = false;
            lupDestino.Properties.ShowFooter = false;
            lupDestino.Properties.DropDownRows = 2;
        }

        private void Inhabilitar()
        {
            lupDestino.ItemIndex = -1;
            lupTipo.ItemIndex = -1;
            lupDestino.Enabled = false;
            txtCodigoAgencia.Enabled = false;
            txtDescripcion.Enabled = false;
            txtArea.Enabled = false;
            txtDescripcion.Focus();
        }

        #endregion


        #region eventos

        private void frmCreacionPuntoEntrega_Load(object sender, EventArgs e)
        {
            CargarTipo();
            CargarDestino();
            Inhabilitar();
            TipoFormulario();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            CrearPuntoEntrega();
        }

        private void lupTipo_EditValueChanged(object sender, EventArgs e)
        {
            ChangeLupTipo();
        }



        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtArea_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }
        #endregion
    }
}
