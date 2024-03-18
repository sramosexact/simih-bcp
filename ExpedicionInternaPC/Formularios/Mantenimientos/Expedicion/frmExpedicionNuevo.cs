using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmExpedicionNuevo : frmChild
    {


        #region Variables

        private List<Geo> lGeo;
        private List<Geo> ListaDepartamento;
        private List<Geo> ListaProvincia;
        private List<Geo> ListaDistrito;
        private List<Geo> ListaDireccion;
        private List<Geo> ListaOficina;
        private List<Interna.Entity.TipoExpedicion> lTipoExpedicion;

        public Expedicion oExpedicion;

        private int opcion = 0;  // 1 - Nuevo /  2 - Editar

        #endregion

        #region Metodos
        //2022
        private void CargarTipoExpedicion()
        {
            try
            {
                lTipoExpedicion = Metodos.ListarTipoExpedicion();
                cboTipoExpedicion.Properties.DataSource = lTipoExpedicion;
                cboTipoExpedicion.Properties.ValueMember = "iIdTipoExpedicion";
                cboTipoExpedicion.Properties.DisplayMember = "sDescripcionTipoExpedicion";
                cboTipoExpedicion.Properties.DropDownRows = lTipoExpedicion.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar el tipo de expedición.");
            }

        }
        //2022
        private void CargarDepartamento()
        {
            try
            {
                ListaDepartamento = Metodos.ListarDepartamento();
                cboDepartamento.Properties.DataSource = ListaDepartamento;
                cboDepartamento.Properties.ValueMember = "ID";
                cboDepartamento.Properties.DisplayMember = "Descripcion";
                cboDepartamento.Properties.DropDownRows = ListaDepartamento.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de departamentos.");
            }
        }
        //2022
        private void CargarProvincia(Geo oDepartamento)
        {
            if (oDepartamento == null)
            {
                oDepartamento = new Geo();
            }

            try
            {
                ListaProvincia = Metodos.ListarProvincia(oDepartamento);
                cboProvincia.Properties.DataSource = ListaProvincia;
                cboProvincia.Properties.ValueMember = "ID";
                cboProvincia.Properties.DisplayMember = "Descripcion";
                cboProvincia.Properties.DropDownRows = ListaProvincia.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de provincias.");
            }
        }
        //2022
        private void CargarDistrito(Geo oProvincia)
        {
            if (oProvincia == null)
            {
                oProvincia = new Geo();
            }

            try
            {
                ListaDistrito = Metodos.ListarDistrito(oProvincia);
                cboDistrito.Properties.DataSource = ListaDistrito;
                cboDistrito.Properties.ValueMember = "ID";
                cboDistrito.Properties.DisplayMember = "Descripcion";
                cboDistrito.Properties.DropDownRows = ListaDistrito.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de distritos");
            }
        }
        //2022
        private void CargarDireccion(Geo oDistrito)
        {
            if (oDistrito == null)
            {
                oDistrito = new Geo();
            }

            try
            {
                ListaDireccion = Metodos.ListarCalle(oDistrito);
                cboDireccion.Properties.DataSource = ListaDireccion;
                cboDireccion.Properties.ValueMember = "ID";
                cboDireccion.Properties.DisplayMember = "Descripcion";
                cboDireccion.Properties.DropDownRows = ListaDireccion.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de direcciones.");
            }
        }
        //2022
        public void CargarDatos()
        {
            CargarTipoExpedicion();
            CargarDepartamento();
            if (oExpedicion != null)
            {
                opcion = 2;
                this.Text = "Modificar Expedición";
                btnGuardar.Text = "&Guardar";

                Geo oDep = new Geo();
                Geo oPro = new Geo();
                Geo oDis = new Geo();
                Geo oCal = new Geo();
                Geo oOfi = new Geo();

                oDep.ID = oExpedicion.idDepartamento;
                oPro.ID = oExpedicion.idProvincia;
                oDis.ID = oExpedicion.idDistrito;
                oCal.ID = oExpedicion.idCalle;
                oOfi.ID = oExpedicion.IdGeo;

                cboDepartamento.EditValue = oDep.ID;
                cboProvincia.EditValue = oPro.ID;
                cboDistrito.EditValue = oDis.ID;
                cboDireccion.EditValue = oCal.ID;
                txtOficina.Text = oExpedicion.Geo;
                cboTipoExpedicion.EditValue = (byte)(oExpedicion.idTipoExpedicion);
                txtExpedicion.Text = oExpedicion.Descripcion;
                txtPrefijo.Text = oExpedicion.Prefijo;
                txtExpedicion.Focus();

                cboTipoExpedicion.Enabled = false;
                /*Si es de tipo sucursal no se podrá cambiar el geo*/
                if ((byte)cboTipoExpedicion.EditValue == (byte)1)
                {
                    cboDepartamento.Enabled = false;
                    cboProvincia.Enabled = false;
                    cboDistrito.Enabled = false;
                    cboDireccion.Enabled = false;
                    txtOficina.Enabled = false;
                }
            }
            else
            {
                opcion = 1;
                this.Text = "Nueva Expedición";
                btnGuardar.Text = "&Crear";
                oExpedicion = new Expedicion();
            }
        }
        //2022
        private bool Validar()
        {
            if (cboDistrito.EditValue == null)
            {
                Program.mensaje("Debe elegir un distrito.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (cboDireccion.EditValue == null)
            {
                Program.mensaje("Debe elegir una dirección.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (txtOficina.Text.Trim().Length == 0)
            {
                Program.mensaje("Debe ingresar una oficina.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (txtExpedicion.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese el nombre de la Expedición.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (txtPrefijo.Text.Trim().Length < 3)
            {
                Program.mensaje("Ingrese un prefijo de 3 letras para la expedición.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (cboTipoExpedicion.EditValue == null)
            {
                Program.mensaje("Debe elegir un tipo.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            oExpedicion.idCalle = (int)cboDireccion.EditValue;
            oExpedicion.Geo = txtOficina.Text.Trim().ToUpper();
            oExpedicion.Descripcion = txtExpedicion.Text.Trim().ToUpper();
            oExpedicion.idTipoExpedicion = (byte)cboTipoExpedicion.EditValue;
            oExpedicion.IdCliente = Program.oUsuario.IdCliente;
            oExpedicion.Prefijo = txtPrefijo.Text.Trim().ToUpper();
            return false;
        }
        //2022
        private void EvaluarResultado(int resultado)
        {
            if (resultado > 0)
            {
                Program.mensaje("Operación realizada satisfactoriamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (resultado == -4)
            {
                Program.mensaje("No se puede modificar. Ya existe una sucursal en el punto de entrega seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resultado == -3)
            {
                Program.mensaje("No se puede crear la sucursal. Solo se puede crear una sucursal por dirección.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resultado == -2)
            {
                Program.mensaje("El nombre de la expedición ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resultado == -6)
            {
                Program.mensaje("El prefijo de la expedición ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (resultado == -1)
            {
                Program.mensaje("Error de conexión, intente nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //2022
        private void Guardar()
        {
            try
            {
                if (opcion == 1)
                {
                    if (Validar()) return;
                    int resultado = Metodos.NuevaExpedicion(oExpedicion);
                    EvaluarResultado(resultado);
                }
                else if (opcion == 2)
                {
                    if (Validar()) return;
                    int resultado = Metodos.ModificarExpedicion(oExpedicion);
                    EvaluarResultado(resultado);
                }
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar guardar los cambios.");
            }

        }
        //2022
        private void Cancelar()
        {
            Close();
        }

        #endregion

        public frmExpedicionNuevo()
        {
            InitializeComponent();
        }

        private void frmExpedicionNuevo_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDepartamento.GetSelectedDataRow();
            CargarProvincia(oGeo);
            CargarDistrito(null);
            CargarDireccion(null);
            txtOficina.Text = "";
            txtOficina.Enabled = false;
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboProvincia.GetSelectedDataRow();
            CargarDistrito(oGeo);
            CargarDireccion(null);
            txtOficina.Text = "";
            txtOficina.Enabled = false;
        }

        private void cboDistrito_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDistrito.GetSelectedDataRow();
            CargarDireccion(oGeo);
            txtOficina.Text = "";
            txtOficina.Enabled = false;
        }

        private void cboDireccion_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDireccion.GetSelectedDataRow();
            txtOficina.Text = "";
            txtOficina.Enabled = true;
        }

        private void txtExpedicion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtOficina_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }
    }
}
