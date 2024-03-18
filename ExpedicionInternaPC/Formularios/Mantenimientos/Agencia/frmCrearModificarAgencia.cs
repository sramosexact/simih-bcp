using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmCrearModificarAgencia : frmChild
    {

        #region Variables

        private List<Geo> lGeo;
        private List<Geo> ListaDepartamento;
        private List<Geo> ListaProvincia;
        private List<Geo> ListaDistrito;
        private List<Geo> ListaDireccion;

        public Agencia oAgencia;
        public int iAccion = 0;
        #endregion

        #region Metodos
        //2022
        private void CargarGrupo()
        {
            Tipo oGrupo1 = new Tipo();
            Tipo oGrupo2 = new Tipo();

            oGrupo1.ID = 270;
            oGrupo1.Descripcion = "LIMA";
            oGrupo2.ID = 271;
            oGrupo2.Descripcion = "PROVINCIA";

            List<Tipo> ListaGrupo = new List<Tipo>();
            ListaGrupo.Add(oGrupo1);
            ListaGrupo.Add(oGrupo2);

            cboGrupo.Properties.DataSource = ListaGrupo;
            cboGrupo.Properties.DisplayMember = "Descripcion";
            cboGrupo.Properties.ValueMember = "ID";
            cboGrupo.Properties.DropDownRows = 2;
        }
        //2022
        private void CargarEstado()
        {
            Agencia oEstado1 = new Agencia();
            Agencia oEstado2 = new Agencia();
            oEstado1.iActivo = 1;
            oEstado1.sActivo = "ACTIVO";
            oEstado2.iActivo = 0;
            oEstado2.sActivo = "INACTIVO";

            List<Agencia> ListaEstado = new List<Agencia>();
            ListaEstado.Add(oEstado1);
            ListaEstado.Add(oEstado2);

            cboEstado.Properties.DataSource = ListaEstado;
            cboEstado.Properties.DisplayMember = "sActivo";
            cboEstado.Properties.ValueMember = "iActivo";
            cboEstado.Properties.DropDownRows = 2;

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
                glookDireccion.Properties.DataSource = ListaDireccion;
                glookDireccion.Properties.ValueMember = "ID";
                glookDireccion.Properties.DisplayMember = "Descripcion";
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

            CargarGrupo();
            CargarEstado();
            CargarDepartamento();
            if (oAgencia != null)
            {
                iAccion = 2;
                this.Text = "Modificar Agencia";
                btnGuardar.Text = "&Guardar";

                Geo oDep = new Geo();
                Geo oPro = new Geo();
                Geo oDis = new Geo();
                Geo oCal = new Geo();
                Geo oOfi = new Geo();

                oDep.ID = oAgencia.idDepartamento;
                oPro.ID = oAgencia.idProvincia;
                oDis.ID = oAgencia.idDistrito;
                oCal.ID = oAgencia.iIdGeoDireccion;


                cboDepartamento.EditValue = oDep.ID;
                cboProvincia.EditValue = oPro.ID;
                cboDistrito.EditValue = oDis.ID;
                glookDireccion.EditValue = oCal.ID;
                cboGrupo.EditValue = oAgencia.iTipo;
                cboEstado.EditValue = oAgencia.iActivo;
                txtCodigo.Text = oAgencia.sCodigoAgencia;
                txtAgencia.Text = oAgencia.sDescripcion;

                txtCodigo.Enabled = false;
                cboDepartamento.Enabled = false;
                cboProvincia.Enabled = false;
                cboDistrito.Enabled = false;
                glookDireccion.Enabled = false;
                cboGrupo.Enabled = false;
                txtAgencia.Enabled = true;
                cboEstado.Enabled = false;
                txtAgencia.Focus();

            }
            else
            {
                iAccion = 1;
                txtCodigo.Enabled = true;
                cboDepartamento.Enabled = true;
                cboProvincia.Enabled = true;
                cboDistrito.Enabled = true;
                glookDireccion.Enabled = true;
                cboGrupo.EditValue = true;
                txtAgencia.Enabled = true;
                cboEstado.Enabled = false;
                this.Text = "Nueva Agencia";
                btnGuardar.Text = "&Crear";
                oAgencia = new Agencia();
                txtCodigo.Focus();
            }
        }
        //2022
        private bool ValidarCampos()
        {
            if (txtCodigo.Text.Trim().Length < 6)
            {
                Program.mensaje("Ingrese un código de 6 dígitos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCodigo.Focus();
                txtCodigo.SelectAll();
                return true;
            }
            if (txtAgencia.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese el nombre de la agencia.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtAgencia.Focus();
                txtAgencia.SelectAll();
                return true;
            }
            if (cboDepartamento.EditValue == null)
            {
                Program.mensaje("Seleccione un departamento.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDepartamento.Focus();
                return true;
            }
            if (cboProvincia.EditValue == null)
            {
                Program.mensaje("Seleccione una provincia.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboProvincia.Focus();
                return true;
            }
            if (cboDistrito.EditValue == null)
            {
                Program.mensaje("Seleccione un distrito.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboDistrito.Focus();
                return true;
            }
            if (glookDireccion.EditValue == null)
            {
                Program.mensaje("Seleccione una dirección.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                glookDireccion.Focus();
                return true;
            }
            if (cboGrupo.EditValue == null)
            {
                Program.mensaje("Elija un grupo.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cboGrupo.Focus();
                return true;
            }

            return false;
        }
        //2022
        private void Guardar()
        {
            if (ValidarCampos())
            {
                return;
            }

            if (iAccion == 1)
            {
                Agencia o_Agencia = new Agencia();
                o_Agencia.sCodigoAgencia = txtCodigo.Text.Trim().ToUpper();
                o_Agencia.sDescripcion = txtAgencia.Text.Trim().ToUpper();
                o_Agencia.iIdGeoDireccion = (int)glookDireccion.EditValue;
                o_Agencia.iTipo = (int)cboGrupo.EditValue;

                try
                {
                    int resultado = Metodos.CrearAgencia(o_Agencia);

                    if (resultado == 1)
                    {
                        Program.mensaje("Agencia creada correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else if (resultado == -1)
                    {
                        Program.mensaje("Error de conexión. Vuelva a intentarlo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado == -2)
                    {
                        Program.mensaje("El código de la agencia ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (resultado == -3)
                    {
                        Program.mensaje("El nombre de la agencia ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (resultado == -4)
                    {
                        Program.mensaje("No se pudo crear la agencia. Ya existe una agencia vinculada a la dirección seleccionada.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else if (resultado == -5)
                    {
                        Program.mensaje("No se pudo crear la agencia. Ya existe una sucursal vinculada a la dirección seleccionada.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Program.mensaje("Error de conexión. Vuelva a intentarlo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar crear la agencia.");
                }
            }

            else if (iAccion == 2)
            {
                Agencia o_Agencia = new Agencia();
                o_Agencia.iId = oAgencia.iId;
                o_Agencia.sDescripcion = txtAgencia.Text.Trim().ToUpper();
                o_Agencia.iActivo = (int)cboEstado.EditValue;

                try
                {
                    int resultado = Metodos.ModificarAgencia(o_Agencia);

                    if (resultado == 1)
                    {
                        Program.mensaje("Agencia modificada correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        this.Close();
                    }
                    else if (resultado == -1)
                    {
                        Program.mensaje("Error de conexión. Vuelva a intentarlo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (resultado == -2)
                    {
                        Program.mensaje("El nombre de la agencia ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        Program.mensaje("Error de conexión. Vuelva a intentarlo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar modificar la agencia.");
                }

            }
        }
        //2022
        private void Cancelar()
        {
            this.Close();
        }
        #endregion

        public frmCrearModificarAgencia()
        {
            InitializeComponent();
        }

        private void frmCrearModificarAgencia_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDepartamento.GetSelectedDataRow();
            CargarProvincia(oGeo);
            CargarDistrito(null);
            CargarDireccion(null);
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboProvincia.GetSelectedDataRow();
            CargarDistrito(oGeo);
            CargarDireccion(null);
        }

        private void cboDistrito_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDistrito.GetSelectedDataRow();
            CargarDireccion(oGeo);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.soloNumeros(e);
        }

        private void txtAgencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }
    }
}
