using DevExpress.DirectX.Common.Direct2D;
using DevExpress.Xpf.Editors;
using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmCrearModificarUsuario : frmChild
    {
        #region Variables
        public Usuario oUsuario;
        private List<Usuario> lUsuario;
        private List<Geo> lGeo;
        private List<Geo> ListaDepartamento;
        private List<Geo> ListaProvincia;
        private List<Geo> ListaDistrito;
        private List<Geo> ListaDireccion;
        private List<Geo> ListaOficinaArea;
        private List<Casilla> ListaTipoBandeja;
        #endregion

        #region Metodos
        //2022
        private void CargarEstado()
        {
            lUsuario = new List<Usuario>();
            lUsuario.Add(new Usuario() { iActivo = 1, sActivo = "ACTIVO" });
            lUsuario.Add(new Usuario() { iActivo = 0, sActivo = "INACTIVO" });
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
        private void CargarOficinaArea(Geo oDireccion)
        {
            if (oDireccion == null)
            {
                oDireccion = new Geo();
            }
            try
            {
                ListaOficinaArea = Metodos.ListarOficina(oDireccion);
                glookOficinaArea.Properties.DataSource = ListaOficinaArea;
                glookOficinaArea.Properties.ValueMember = "ID";
                glookOficinaArea.Properties.DisplayMember = "Oficina";
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar la lista de oficinas.");
            }

        }
        //2022
        private void CargarModoAcceso()
        {
            List<ModoAcceso> lstModoAcceso = (new ModoAcceso()).subListarModoAcceso();
            cboTipoAutenticacion.Properties.DataSource = lstModoAcceso;
            cboTipoAutenticacion.Properties.DisplayMember = "modoAcceso";
            cboTipoAutenticacion.Properties.ValueMember = "IdModoAcceso";
            cboTipoAutenticacion.Properties.DropDownRows = lstModoAcceso.Count;
        }
        //2022
        private void CargarTipoUsuario()
        {
            TipoUsuario tipoUsuarioCreador = new TipoUsuario();
            tipoUsuarioCreador.iIdTipoUsuario = (byte)Program.oUsuario.IdTipoAcceso;
            try
            {
                List<TipoUsuario> lstTipoUsuario = Metodos.ListarTipoUsuario(tipoUsuarioCreador);
                //List<TipoUsuario> lstTipoUsuario2 = new List<TipoUsuario>();

                //if (oUsuario != null)
                //{
                //    if (oUsuario.IdTipoAcceso == (int)EnumTipoUsuario.OPERARIO)
                //    {
                //        lstTipoUsuario2 = lstTipoUsuario.FindAll(x => (x.iIdTipoUsuario != 41 && x.iIdTipoUsuario != 44)).ToList();
                //    }
                //    else if (oUsuario.IdTipoAcceso == (int)EnumTipoUsuario.SUPERVISOR)
                //    {
                //        lstTipoUsuario2 = lstTipoUsuario.FindAll(x => (x.iIdTipoUsuario != 41 && x.iIdTipoUsuario != 42 && x.iIdTipoUsuario != 44)).ToList();
                //    }
                //    else if (oUsuario.IdTipoAcceso == (int)EnumTipoUsuario.JEFE)
                //    {
                //        lstTipoUsuario2 = lstTipoUsuario.FindAll(x => (x.iIdTipoUsuario != 41 && x.iIdTipoUsuario != 42 && x.iIdTipoUsuario != 43 && x.iIdTipoUsuario != 44)).ToList();
                //    }
                //    else
                //    {
                //        lstTipoUsuario2 = lstTipoUsuario;
                //    }
                //}
                //else
                //{
                //    lstTipoUsuario2 = lstTipoUsuario;
                //}

                cboTipoUsuario.Properties.DataSource = lstTipoUsuario;
                cboTipoUsuario.Properties.DisplayMember = "sDescripcionTipoUsuario";
                cboTipoUsuario.Properties.ValueMember = "iIdTipoUsuario";
                cboTipoUsuario.Properties.DropDownRows = lstTipoUsuario.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar el tipo de usuario.");
            }

        }
        //2024
        private void CargarProveedor()
        {
            try
            {
                List<Proveedor> ListaProveedor = Metodos.ListarProveedores();
                cboProveedor.Properties.DataSource = ListaProveedor;
                cboProveedor.Properties.DisplayMember = "Descripcion";
                cboProveedor.Properties.ValueMember = "Id";
                cboProveedor.Properties.DropDownRows = ListaProveedor.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar las expediciones.");
            }
        }
        //2022
        private void CargarExpedicion()
        {
            try
            {
                List<Expedicion> ListaExpedicion = Metodos.ListarExpedicionesListaJson();
                if (Program.oUsuario.IdTipoAcceso != 44 && Program.oUsuario.IdTipoAcceso != 80 && Program.oUsuario.IdTipoAcceso != 43)
                {
                    ListaExpedicion.RemoveAll(x => x.ID != Program.oUsuario.IdExpedicion);
                }
                cboExpedicion.Properties.DataSource = ListaExpedicion;
                cboExpedicion.Properties.DisplayMember = "Descripcion";
                cboExpedicion.Properties.ValueMember = "ID";
                cboExpedicion.Properties.DropDownRows = ListaExpedicion.Count;
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar cargar las expediciones.");
            }

        }
        //2022
        private void CargarBandejaExpedicion(Expedicion oExpedicion)
        {
            List<Casilla> ListaBandejas = new List<Casilla>();

            if (oExpedicion == null)
            {
                ListaBandejas = new List<Casilla>();
            }
            else
            {
                try
                {
                    ListaBandejas = Metodos.ListarBandejaExpedicion(oExpedicion.ID);

                    TipoUsuario tipoUsuario2 = (TipoUsuario)cboTipoUsuario.GetSelectedDataRow();

                    if (tipoUsuario2.iIdTipoUsuario == (int)EnumTipoUsuario.SUPERVISOR)
                        ListaTipoBandeja = ListaBandejas.FindAll(x => x.Descripcion.Substring(0, 3).ToUpper() == "SUP");
                    else if (tipoUsuario2.iIdTipoUsuario == (int)EnumTipoUsuario.JEFE)
                        ListaTipoBandeja = new List<Casilla>();
                    else
                        ListaTipoBandeja = ListaBandejas.FindAll(x => x.Descripcion.Substring(0, 3).ToUpper() != "SUP");

                    cboBandeja.Properties.DataSource = ListaTipoBandeja;
                    cboBandeja.Properties.DisplayMember = "Descripcion";
                    cboBandeja.Properties.ValueMember = "ID";
                    cboBandeja.Properties.DropDownRows = ListaTipoBandeja.Count;
                    cboBandeja.EditValue = null;
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar cargar las bandejas de la Expedición.");
                }

            }


        }
        //2022
        private void CargarOpciones()
        {
            CargarEstado();
            CargarModoAcceso();
            CargarTipoUsuario();
            CargarProveedor();
            CargarExpedicion();
            CargarDepartamento();

            if (ListaDepartamento == null || ListaDepartamento.Count == 0)
            {
                return;
            }

            int IdTipoAcceso = Program.oUsuario.IdTipoAcceso;

            if (oUsuario == null) //Nuevo
            {
                this.Text = "Crear usuario.";
            }
            else //Editar
            {
                this.Text = "Modificar usuario";
                txtNombre.Text = oUsuario.Descripcion;
                txtMatricula.Text = oUsuario.sMatricula;
                txtDominio.Text = oUsuario.sDominio;
                txtDni.Text = oUsuario.sDni;
                txtCodigoUsuario.Text = oUsuario.Codigo;
                cboTipoAutenticacion.EditValue = oUsuario.Modo;

                if (oUsuario.Modo != 0) txtPassword.Text = oUsuario.Password;

                cboTipoUsuario.EditValue = (byte)oUsuario.IdTipoAcceso;

                if (oUsuario.IdTipoAcceso == (int)EnumTipoUsuario.USUARIO)
                {

                    cboDepartamento.EditValue = oUsuario.IdDepartamento;
                    cboProvincia.EditValue = oUsuario.IdProvincia;
                    cboDistrito.EditValue = oUsuario.IdDistrito;
                    glookDireccion.EditValue = oUsuario.IdCalle;
                    glookOficinaArea.EditValue = oUsuario.IdOficina;
                    lblBandejaPredeterminada.Text = oUsuario.descripcionCasilla;
                    cboDepartamento.Enabled = true;
                    cboProvincia.Enabled = true;
                    cboDistrito.Enabled = true;
                    glookDireccion.Enabled = true;
                    glookOficinaArea.Enabled = true;
                    cboTipoUsuario.Enabled = false;
                    cboExpedicion.Enabled = false;
                    cboBandeja.Enabled = false;
                }
                else
                {
                    if (oUsuario.IdTipoAcceso != (int)EnumTipoUsuario.JEFE)
                    {
                        try
                        {
                            cboExpedicion.EditValue = oUsuario.IdExpedicion;
                            cboBandeja.EditValue = oUsuario.idCasilla;
                        }
                        catch
                        {

                        }
                    }

                    lblBandejaPredeterminada.Text = "";
                    cboDepartamento.Enabled = false;
                    cboProvincia.Enabled = false;
                    cboDistrito.Enabled = false;
                    glookDireccion.Enabled = false;
                    glookOficinaArea.Enabled = false;

                    if ((IdTipoAcceso == (int)EnumTipoUsuario.JEFE || IdTipoAcceso == (int)EnumTipoUsuario.SUPERVISOR || IdTipoAcceso == (int)EnumTipoUsuario.ADMINISTRADOR) && oUsuario.IdTipoAcceso != (int)EnumTipoUsuario.JEFE)
                    {
                        cboTipoUsuario.Enabled = true;
                        cboExpedicion.Enabled = true;
                        cboBandeja.Enabled = true;
                    }
                    else
                    {
                        cboTipoUsuario.Enabled = false;
                        cboExpedicion.Enabled = false;
                        cboBandeja.Enabled = false;
                    }
                }

                txtDominio.Enabled = false;
                txtCodigoUsuario.Enabled = false;

                // Usuario con estado INACTIVO bloquea todos los controles
                if (oUsuario.iActivo == 0)
                {
                    txtNombre.Enabled = false;
                    txtMatricula.Enabled = false;
                    txtDni.Enabled = false;
                    cboTipoAutenticacion.Enabled = false;
                    txtPassword.Enabled = false;
                    btnGuardar.Enabled = false;
                    cboDepartamento.Enabled = false;
                    cboProvincia.Enabled = false;
                    cboDistrito.Enabled = false;
                    glookDireccion.Enabled = false;
                    glookOficinaArea.Enabled = false;
                    cboTipoUsuario.Enabled = false;
                    cboExpedicion.Enabled = false;
                    cboBandeja.Enabled = false;
                }
            }
        }
        //2022
        private bool ValidarCampos()
        {
            if (txtNombre.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese un nombre de usuario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (txtMatricula.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese la matrícula.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (txtDni.Text.Trim().Length < 8)
            {
                Program.mensaje("Ingrese un DNI válido.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (txtDominio.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese el dominio del usuario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (txtCodigoUsuario.Text.Trim().Length == 0)
            {
                Program.mensaje("Ingrese el código de usuario.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            if (((ModoAcceso)cboTipoAutenticacion.GetSelectedDataRow()).IdModoAcceso > 0)
            {
                if (txtPassword.Text.Trim().Length == 0)
                {
                    Program.mensaje("Ingrese un password.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
            }
            if (((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (byte)EnumTipoUsuario.USUARIO)
            {
                if (glookOficinaArea.EditValue == null)
                {
                    Program.mensaje("Debe seleccionar un área.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
            }
            if (((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (byte)EnumTipoUsuario.PROVEEDOR_RVA_TRANSPORTISTA ||
                ((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (byte)EnumTipoUsuario.PROVEEDOR_RVA_TRANSPORTISTA)
            {
                if (cboProveedor.EditValue == null)
                {
                    Program.mensaje("Debe seleccionar un proveedor.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
            }
            if (((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (int)EnumTipoUsuario.SUPERVISOR ||
                ((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (int)EnumTipoUsuario.OPERARIO)
            {
                if (cboExpedicion.EditValue == null)
                {
                    Program.mensaje("Debe seleccionar una expedición.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
                if (cboBandeja.EditValue == null)
                {
                    Program.mensaje("Debe seleccionar una bandeja de expedición.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return true;
                }
            }

            return false;
        }
        //2022
        private void Cancelar()
        {
            this.Close();
        }
        //2022
        private void Guardar()
        {
            Usuario _usuario = new Usuario();

            if (oUsuario == null) //Nuevo
            {
                if (ValidarCampos())
                {
                    return;
                }

                _usuario.ID = 0;
                _usuario.Descripcion = txtNombre.Text.Trim().ToUpper();
                _usuario.sMatricula = txtMatricula.Text.Trim().ToUpper();
                _usuario.sDni = txtDni.Text.Trim().ToUpper();
                _usuario.sDominio = txtDominio.Text.Trim().ToUpper();
                _usuario.Codigo = txtCodigoUsuario.Text.Trim().ToLower();
                _usuario.Modo = (int)cboTipoAutenticacion.EditValue;
                _usuario.Password = txtPassword.Text.Trim();
                _usuario.IdTipoAcceso = (byte)cboTipoUsuario.EditValue;
                if (_usuario.IdTipoAcceso == (int)EnumTipoUsuario.USUARIO)
                {
                    _usuario.IdExpedicion = 0;
                    _usuario.idCasilla = 0;
                    _usuario.idGeo = (int)glookOficinaArea.EditValue;
                }
                else if (_usuario.IdTipoAcceso == (int)EnumTipoUsuario.JEFE)
                {
                    _usuario.IdExpedicion = 0;
                    _usuario.idCasilla = 0;
                    _usuario.idGeo = 0;
                }
                else if (_usuario.IdTipoAcceso == (int)EnumTipoUsuario.PROVEEDOR_RVA_TRANSPORTISTA ||
                    _usuario.IdTipoAcceso == (int)EnumTipoUsuario.PROVEEDOR_RVA_GESTOR)
                {
                    _usuario.IdExpedicion = 0;
                    _usuario.idCasilla = 0;
                    _usuario.idGeo = 0;
                }
                else
                {
                    _usuario.IdExpedicion = (int)cboExpedicion.EditValue;
                    _usuario.idCasilla = (int)cboBandeja.EditValue;
                    _usuario.idGeo = 0;
                }

                try
                {
                    int resultado = Metodos.CrearUsuario(_usuario);

                    if (resultado > 0)
                    {
                        this.oUsuario = new Usuario();
                        this.oUsuario.CopyToMe(_usuario);
                        Program.mensaje("Usuario creado correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else if (resultado == -2)
                    {
                        Program.mensaje("No se puede crear el usuario.El DNI ingresado ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNombre.Focus();
                        txtNombre.SelectAll();
                    }
                    else if (resultado == -3)
                    {
                        Program.mensaje("No se puede crear el usuario. El código de usuario ingresado ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMatricula.Focus();
                        txtMatricula.SelectAll();
                    }
                    else if (resultado == -4)
                    {
                        Program.mensaje("No se puede crear el usuario.  La matrícula ingresada ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtCodigoUsuario.Focus();
                        txtCodigoUsuario.SelectAll();
                    }
                    else
                    {
                        Program.mensaje("Ha ocurrido un error, intente nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (InvalidTokenException)
                {
                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar crear el usuario.");
                }

            }
            else //Modificar
            {
                if (ValidarCampos()) return;

                _usuario.IdTipoAcceso = (byte)cboTipoUsuario.EditValue;

                if (_usuario.IdTipoAcceso == (int)EnumTipoUsuario.USUARIO)
                {
                    if (glookOficinaArea.EditValue == null)
                    {
                        Program.mensaje("Debe seleccionar una Oficina/Area.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    _usuario.idGeoCasilla = (int)glookOficinaArea.EditValue;
                    _usuario.Descripcion = txtNombre.Text.Trim().ToUpper();
                }
                else
                {
                    _usuario.idGeoCasilla = 0;
                    _usuario.Descripcion = txtNombre.Text.Trim().ToUpper();
                }

                _usuario.ID = oUsuario.ID;
                _usuario.sMatricula = txtMatricula.Text.Trim().ToUpper();
                _usuario.sDni = txtDni.Text.Trim().ToUpper();
                _usuario.Modo = (int)cboTipoAutenticacion.EditValue;
                _usuario.Password = txtPassword.Text.Trim();

                // --------------------------------------------------------

                if (_usuario.IdTipoAcceso == (int)EnumTipoUsuario.JEFE)
                {
                    _usuario.IdExpedicion = 0;
                    _usuario.idCasilla = 0;
                    _usuario.idGeo = 0;
                }
                else if (_usuario.IdTipoAcceso == (int)EnumTipoUsuario.OPERARIO || _usuario.IdTipoAcceso == (int)EnumTipoUsuario.SUPERVISOR)
                {
                    _usuario.IdExpedicion = (int)cboExpedicion.EditValue;
                    _usuario.idCasilla = (int)cboBandeja.EditValue;
                    _usuario.idGeo = 0;
                }

                try
                {
                    int resultado = Metodos.ModificarUsuario(_usuario);

                    if (resultado > 0)
                    {
                        Program.mensaje("Se actualizó correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else if (resultado == -2)
                    {
                        Program.mensaje("No se puede modificar el usuario.El nombre de usuario ingresado ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtNombre.Focus();
                        txtNombre.SelectAll();
                    }
                    else if (resultado == -3)
                    {
                        Program.mensaje("No se puede modificar el usuario. La matrícula ingresada ya existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        txtMatricula.Focus();
                        txtMatricula.SelectAll();
                    }
                }
                catch (InvalidTokenException)
                {

                    Program.mensajeTokenInvalido();
                }
                catch (Exception)
                {
                    Program.mensajeError("Ha ocurrido un error al intentar modificar el usuario.");
                }
            }
        }

        #endregion


        public frmCrearModificarUsuario()
        {
            InitializeComponent();
        }

        private void frmCrearModificarUsuario_Load(object sender, EventArgs e)
        {
            CargarOpciones();
        }

        private void cboTipoAutenticacion_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (((ModoAcceso)cboTipoAutenticacion.GetSelectedDataRow()).IdModoAcceso == 0)
                {
                    txtPassword.Text = "";
                    txtPassword.Enabled = false;
                }
                else
                {
                    txtPassword.Enabled = true;
                    txtPassword.Focus();
                    txtPassword.SelectAll();
                }
            }
            catch (Exception)
            {
                //Program.mensajeError("Ha ocurrido un error al intentar seleccionar.");
            }
        }

        private void cboTipoUsuario_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (int)EnumTipoUsuario.USUARIO)
                {
                    cboProveedor.EditValue = null;
                    cboProveedor.Enabled = false;
                    cboExpedicion.EditValue = null;
                    cboExpedicion.Enabled = false;
                    cboDepartamento.Enabled = true;
                    cboProvincia.Enabled = true;
                    cboDistrito.Enabled = true;
                    glookDireccion.Enabled = true;
                    glookOficinaArea.Enabled = true;
                    lblBandejaPredeterminada.Text = txtNombre.Text;
                }
                else if (((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (int)EnumTipoUsuario.JEFE)
                {
                    cboProveedor.EditValue = null;
                    cboProveedor.Enabled = false;
                    //cboExpedicion.EditValue = null;
                    //cboExpedicion.Enabled = false;
                    cboDepartamento.EditValue = null;
                    cboProvincia.EditValue = null;
                    cboDistrito.EditValue = null;
                    glookDireccion.EditValue = null;
                    glookOficinaArea.EditValue = null;

                    cboDepartamento.Enabled = false;
                    cboProvincia.Enabled = false;
                    cboDistrito.Enabled = false;
                    glookDireccion.Enabled = false;
                    glookOficinaArea.Enabled = false;

                    cboExpedicion.Enabled = true;

                    lblBandejaPredeterminada.Text = txtNombre.Text;
                    //lblBandejaPredeterminada.Text = "";
                }
                else if (((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (int)EnumTipoUsuario.PROVEEDOR_RVA_GESTOR)
                {

                    cboExpedicion.EditValue = null;
                    cboExpedicion.Enabled = false;

                    cboDepartamento.EditValue = null;
                    cboProvincia.EditValue = null;
                    cboDistrito.EditValue = null;
                    glookDireccion.EditValue = null;
                    glookOficinaArea.EditValue = null;

                    cboDepartamento.Enabled = false;
                    cboProvincia.Enabled = false;
                    cboDistrito.Enabled = false;
                    glookDireccion.Enabled = false;
                    glookOficinaArea.Enabled = false;

                    cboProveedor.Enabled = true;

                    lblBandejaPredeterminada.Text = txtNombre.Text;
                }
                else if (((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (int)EnumTipoUsuario.PROVEEDOR_RVA_TRANSPORTISTA)
                {
                    cboExpedicion.EditValue = null;
                    cboExpedicion.Enabled = false;

                    cboDepartamento.EditValue = null;
                    cboProvincia.EditValue = null;
                    cboDistrito.EditValue = null;
                    glookDireccion.EditValue = null;
                    glookOficinaArea.EditValue = null;

                    cboDepartamento.Enabled = false;
                    cboProvincia.Enabled = false;
                    cboDistrito.Enabled = false;
                    glookDireccion.Enabled = false;
                    glookOficinaArea.Enabled = false;

                    cboProveedor.Enabled = true;

                    lblBandejaPredeterminada.Text = txtNombre.Text;
                }
                else
                {
                    cboProveedor.EditValue = null;
                    cboProveedor.Enabled = false;
                    cboDepartamento.EditValue = null;
                    cboProvincia.EditValue = null;
                    cboDistrito.EditValue = null;
                    glookDireccion.EditValue = null;
                    glookOficinaArea.EditValue = null;

                    cboDepartamento.Enabled = false;
                    cboProvincia.Enabled = false;
                    cboDistrito.Enabled = false;
                    glookDireccion.Enabled = false;
                    glookOficinaArea.Enabled = false;

                    cboExpedicion.Enabled = true;

                    //if (((TipoUsuario)cboTipoUsuario.GetSelectedDataRow()).iIdTipoUsuario == (int)EnumTipoUsuario.SUPERVISOR)
                    //{
                    //    cboBandeja.Enabled = false;
                    //}
                    //else
                    //{
                    //    cboBandeja.Enabled = true;
                    //}

                    lblBandejaPredeterminada.Text = txtNombre.Text;
                    //lblBandejaPredeterminada.Text = "";
                }
                cboExpedicion.EditValue = null;
                cboBandeja.Properties.DataSource = null;
            }
            catch
            {

            }
        }

        private void cboExpedicion_EditValueChanged(object sender, EventArgs e)
        {
            Expedicion oExpedicion = (Expedicion)cboExpedicion.GetSelectedDataRow();
            CargarBandejaExpedicion(oExpedicion);
            if (oExpedicion != null)
            {

                TipoUsuario tipoUsuario2 = (TipoUsuario)cboTipoUsuario.GetSelectedDataRow();
                if (tipoUsuario2.iIdTipoUsuario == (int)EnumTipoUsuario.SUPERVISOR)
                {
                    if (ListaTipoBandeja == null || ListaTipoBandeja.Count == 0) return;
                    //cboBandeja.EditValue = ListaTipoBandeja[0].ID;
                    //cboBandeja.Enabled = false;
                    cboBandeja.Enabled = true;
                }
                else if (tipoUsuario2.iIdTipoUsuario == (int)EnumTipoUsuario.OPERARIO)
                {
                    cboBandeja.Enabled = true;
                }
                else
                {
                    //cboBandeja.Enabled = false;
                    cboBandeja.Enabled = true;
                    //cboBandeja.EditValue = null;
                }
            }
            else
            {
                cboBandeja.Enabled = false;
            }
        }

        private void cboDepartamento_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDepartamento.GetSelectedDataRow();
            CargarProvincia(oGeo);
            CargarDistrito(null);
            CargarDireccion(null);
            CargarOficinaArea(null);
        }

        private void cboProvincia_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboProvincia.GetSelectedDataRow();
            CargarDistrito(oGeo);
            CargarDireccion(null);
            CargarOficinaArea(null);
        }

        private void cboDistrito_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)cboDistrito.GetSelectedDataRow();
            CargarDireccion(oGeo);
            CargarOficinaArea(null);
        }

        private void glookDireccion_EditValueChanged(object sender, EventArgs e)
        {
            Geo oGeo = (Geo)glookDireccion.GetSelectedDataRow();
            CargarOficinaArea(oGeo);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtCodigoUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.minusculas(e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (cboTipoUsuario.EditValue == null)
            {
                lblBandejaPredeterminada.Text = txtNombre.Text.Trim().ToUpper();
            }
            else
            {
                if ((byte)cboTipoUsuario.EditValue == (byte)EnumTipoUsuario.USUARIO)
                {
                    lblBandejaPredeterminada.Text = txtNombre.Text.Trim().ToUpper();
                }
            }
        }

        private void txtDominio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }


    }
}
