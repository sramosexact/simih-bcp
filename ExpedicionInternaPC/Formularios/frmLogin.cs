using ExpedicionInternaPC.Properties;
using Interna.Entity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        Auth auth = new Auth();

        #region PROPIEDADES


        public int UsuarioIdCliente
        {
            get
            {
                try
                {
                    return int.Parse(Settings.Default["UsuarioIdCliente"].ToString());
                }
                catch (Exception) { }
                return 0;
            }
            set
            {
                if (value > 0)
                {
                    Settings.Default["UsuarioIdCliente"] = value.ToString();
                    Settings.Default.Save();
                }
            }
        }

        public int UsuarioModoValidacion
        {
            get
            {
                try
                {
                    return int.Parse(Settings.Default["UsuarioModoValidacion"].ToString());
                }
                catch (Exception) { }
                return 0;
            }
            set
            {
                if (value >= 0 && value < 2)
                {
                    Settings.Default["UsuarioModoValidacion"] = value.ToString();
                    Settings.Default.Save();
                }
            }
        }

        public int UsuarioRecordar
        {
            get
            {
                try
                {
                    return int.Parse(Settings.Default["UsuarioRecordar"].ToString());
                }
                catch (Exception) { }
                return 0;
            }
            set
            {
                if (value >= 0 && value < 2)
                {
                    Settings.Default["UsuarioRecordar"] = value.ToString();
                    Settings.Default.Save();
                }
            }
        }

        public String UsuarioPassword
        {
            get
            {
                try
                {
                    return Settings.Default["UsuarioPassword"].ToString();
                }
                catch (Exception) { }
                return "";
            }

            set
            {
                Settings.Default["UsuarioPassword"] = value.ToString();
                Settings.Default.Save();
            }
        }

        public String UsuarioCodigo
        {
            get
            {
                if (UsuarioModoValidacion == 0)
                {
                    try
                    {
                        if (Metodos.NombreUsuarioNT.Contains("\\"))
                            return Metodos.NombreUsuarioNT.Split('\\')[1];
                        return Metodos.NombreUsuarioNT;
                    }
                    catch (Exception) { }
                    return "";
                }
                else
                {
                    try
                    {
                        return Settings.Default["UsuarioCodigo"].ToString();
                    }
                    catch (Exception) { }
                    return "";
                }
            }
            set
            {
                Settings.Default["UsuarioCodigo"] = value.ToString();
                Settings.Default.Save();
            }
        }

        #endregion

        #region Metodos

        //2022
        private void subCargarModoAcceso()
        {
            List<ModoAcceso> lstModoAcceso = (new ModoAcceso()).subListarModoAcceso();
            List<ModoAcceso> lstModosAcceso = lstModoAcceso.FindAll(hol => (hol.swLogin == 1));
            cmbAcceso.Properties.DataSource = lstModosAcceso;
            cmbAcceso.Properties.DisplayMember = "modoAcceso";
            cmbAcceso.Properties.ValueMember = "IdModoAcceso";
            cmbAcceso.Properties.DropDownRows = lstModosAcceso.Count;
            cmbAcceso.EditValue = lstModosAcceso[0].IdModoAcceso;
        }
        //2022
        private void subCargarClientes()
        {
            try
            {
                List<Usuario> lstClientes = Metodos.ListarClientes();
                cmbCliente.Properties.DataSource = lstClientes;
                cmbCliente.Properties.DisplayMember = "Cliente";
                cmbCliente.Properties.ValueMember = "ID";
                cmbCliente.Properties.DropDownRows = lstClientes.Count;
                cmbCliente.EditValue = lstClientes[0].ID;
            }
            catch (Exception)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = " Hay problemas de conexion con la base de datos.";
            }
        }
        //2022
        private int subIniciarSesionNT()
        {
            if (chkRecordar.Checked) this.UsuarioRecordar = 1;
            else this.UsuarioRecordar = 0;

            lblMensaje.ForeColor = lblTitulo.ForeColor;
            lblMensaje.Text = "Iniciando validación.....";
            lblMensaje.Refresh();

            try
            {
                Domain m = Domain.GetComputerDomain();
                string nombreDominio = m.Name;
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                string username = windowsIdentity.Name.Split('\\')[1];

                Task<Usuario> tarea = Task.Run(async () => await Requester.AuthenticationRequest(RutaWS.SeguridadWS + "GetObtener_Usuario_Seguridad_NT", nombreDominio.Trim() + ":" + username.Trim(), 1, 1));
                tarea.Wait();
                Usuario oUsuario = new Usuario();
                oUsuario = tarea.Result;

                if (oUsuario != null)
                {
                    UsuarioCodigo = txtUsuario.Text.ToString().Trim();
                    UsuarioModoValidacion = oUsuario.Modo;
                    UsuarioPassword = txtPassword.Text.ToString().Trim();
                    UsuarioIdCliente = oUsuario.IdCliente;
                    // Crear objeto usuario de sesion para enviarlo a la propiedad Usuario en PROGRAM
                    Usuario vUsuario = new Usuario();
                    vUsuario.CopyToMe(oUsuario);

                    Program.oUsuario = vUsuario;
                    Program.oCliente = Metodos.ListarCliente(vUsuario.ID.ToString());

                    Program.oUsuario.IdCliente = Program.oCliente[0].IdCliente; //---------
                                                                                //Tipo de Usuario, se obtiene de la tabla tipoX
                                                                                //41 : NORMAL 
                                                                                //42 : OPERARIO
                                                                                //43 : SUPERVISOR
                                                                                //44 : ADMINISTRADOR SISTEMAS
                    if (oUsuario.IdTipoAcceso == 41)
                    {
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = "No cuenta con permisos para esta aplicación";
                        return 1;
                    }

                    // SALIR
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                    return 2;
                }
                else
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = " Usuario o clave incorrecta";
                }

            }
            catch (ActiveDirectoryObjectNotFoundException ee)
            {
                Program.mensaje(ee.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                Program.mensaje(e.StackTrace, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return 0;

        }
        //2022
        private int subIniciarSesion()
        {
            if (chkRecordar.Checked) this.UsuarioRecordar = 1;
            else this.UsuarioRecordar = 0;
            lblMensaje.ForeColor = lblTitulo.ForeColor;
            lblMensaje.Text = "  Iniciando validación .....";
            lblMensaje.Refresh();
            Usuario oUsuario;
            try
            {

                if (txtUsuario.Text.Length * txtPassword.Text.Length == 0)
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = "Ingrese los datos completos";
                    return 0;
                }

                Task<Usuario> tarea = Task.Run(async () => await Requester.AuthenticationRequest(RutaWS.SeguridadWS + "GetObtener_Usuario_Seguridad", txtUsuario.Text.Trim() + ":" + txtPassword.Text.Trim(), 1, 1));
                tarea.Wait();
                oUsuario = tarea.Result;


                if (oUsuario != null)
                {
                    UsuarioCodigo = txtUsuario.Text.ToString().Trim();
                    UsuarioModoValidacion = oUsuario.Modo;
                    UsuarioPassword = txtPassword.Text.ToString().Trim();
                    UsuarioIdCliente = oUsuario.IdCliente;
                    // Crear objeto usuario de sesion para enviarlo a la propiedad Usuario en PROGRAM
                    Usuario vUsuario = new Usuario();
                    vUsuario.CopyToMe(oUsuario);

                    Program.oUsuario = vUsuario;
                    Program.oCliente = Metodos.ListarCliente(vUsuario.ID.ToString());

                    Program.oUsuario.IdCliente = Program.oCliente[0].IdCliente; //---------
                                                                                //Tipo de Usuario, se obtiene de la tabla tipoX
                                                                                //41 : NORMAL 
                                                                                //42 : OPERARIO
                                                                                //43 : SUPERVISOR
                                                                                //44 : ADMINISTRADOR SISTEMAS
                    if (oUsuario.IdTipoAcceso == 41)
                    {
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = "No cuenta con permisos para esta aplicación";
                        return 1;
                    }

                    // SALIR
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                    return 2;
                }
                else
                {
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = " Usuario o clave incorrecta";
                }
            }
            catch (Exception e)
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = " Usuario o clave incorrecta";
            }
            return 0;
        }

        private void VerVentanaValidando(bool op)
        {
            picCargando.Visible = op;
            progressPanel1.Visible = op;
        }
        #endregion


        #region "AUTH"
        //2022
        private async Task<AuthenticationResult> Login()
        {
            AuthenticationResult authResult = null;
            var accounts = await Program.PublicClientApp.GetAccountsAsync();
            var firstAccount = accounts.FirstOrDefault();

            try
            {
                authResult = await Program.PublicClientApp.AcquireTokenSilent(Program.scopes, firstAccount)
                    .ExecuteAsync();
                ValidarUsuarioAzure(authResult.AccessToken);

            }
            catch (MsalUiRequiredException ex)
            {
                // A MsalUiRequiredException happened on AcquireTokenSilent.
                // This indicates you need to call AcquireTokenInteractive to acquire a token
                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {ex.Message}");

                try
                {
                    authResult = await Program.PublicClientApp.AcquireTokenInteractive(Program.scopes)
                        .WithAccount(accounts.FirstOrDefault())
                        .WithPrompt(Prompt.SelectAccount)
                        .ExecuteAsync();
                    ValidarUsuarioAzure(authResult.AccessToken);
                }
                catch (MsalException)
                {
                    //label1.Text = $"Error Acquiring Token:{System.Environment.NewLine}{msalex}";
                }
            }
            catch (Exception ex)
            {
                //label1.Text = $"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}";
            }
            return authResult;
        }
        //2022
        private async void ValidarUsuarioAzure(string accessToken)
        {
            VerVentanaValidando(true);

            Usuario oUsuario;
            try
            {
                Task<Usuario> tarea = Task.Run(async () => await Requester.AuthenticationAzureRequest(RutaWS.SeguridadAzureWS + "LoginDesktopAzure", accessToken));
                tarea.Wait();
                oUsuario = tarea.Result;

                if (oUsuario != null)
                {
                    //UsuarioCodigo = txtUsuario.Text.ToString().Trim();
                    //UsuarioModoValidacion = oUsuario.Modo;
                    //UsuarioPassword = txtPassword.Text.ToString().Trim();
                    //UsuarioIdCliente = oUsuario.IdCliente;
                    // Crear objeto usuario de sesion para enviarlo a la propiedad Usuario en PROGRAM
                    Usuario vUsuario = new Usuario();
                    vUsuario.CopyToMe(oUsuario);

                    Program.oUsuario = vUsuario;

                    Usuario usuario = new Usuario();
                    usuario.CopyToMe(vUsuario);
                    usuario.ID = vUsuario.IdCliente;
                    List<Usuario> clientes = new List<Usuario>();
                    clientes.Add(usuario);
                    Program.oCliente = clientes;

                    Program.oCliente = clientes;//Metodos.ListarCliente(vUsuario.ID.ToString());

                    Program.oUsuario.IdCliente = Program.oCliente[0].IdCliente; //---------
                                                                                //Tipo de Usuario, se obtiene de la tabla tipoX
                                                                                //41 : NORMAL 
                                                                                //42 : OPERARIO
                                                                                //43 : SUPERVISOR
                                                                                //44 : ADMINISTRADOR SISTEMAS
                    if (oUsuario.IdTipoAcceso == 41)
                    {
                        VerVentanaValidando(false);
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = "No cuenta con permisos para esta aplicación";
                        await Logout();
                        return;
                    }

                    // SALIR
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                    return;
                }
                else
                {
                    VerVentanaValidando(false);
                    lblMensaje.ForeColor = Color.Red;
                    lblMensaje.Text = " El usuario no está registrado en esta aplicación";
                    await Logout();
                    return;
                }
            }
            catch (Exception ex)
            {
                Program.mensajeError(ex.Message);
            }

        }
        //2022
        private async Task Logout()
        {

            var accounts = await Program.PublicClientApp.GetAccountsAsync();
            if (accounts.Any())
            {
                try
                {
                    await Program.PublicClientApp.RemoveAsync(accounts.FirstOrDefault());

                }
                catch (MsalException ex)
                {
                    throw new Exception($"Error signing-out user: {ex.Message}");
                }
            }
        }

        #endregion

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void frmLogin_Load(object sender, EventArgs e)
        {
            VerVentanaValidando(false);
            await Logout();
            //subCargarClientes();
            //subCargarModoAcceso();

            // Checkar modo de validacion
            // siempre intenta el modo windows primero
            int ret;

            if (this.UsuarioRecordar > 0)
            {
                txtPassword.Text = UsuarioPassword;
                txtUsuario.Text = UsuarioCodigo;
                cmbCliente.EditValue = UsuarioIdCliente.ToString();
                if (UsuarioModoValidacion == 0)
                    ret = subIniciarSesionNT();
                else
                    ret = subIniciarSesion();
            }
            else
            {
                // WINDOWS
                UsuarioModoValidacion = 0;
                txtUsuario.Text = UsuarioCodigo;
                txtPassword.Text = "";
            }
        }

        private void cmbCliente_EditValueChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
        }

        private void cmbAcceso_EditValueChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
            switch (int.Parse(cmbAcceso.EditValue.ToString()))
            {
                case 0:
                    txtUsuario.Text = this.UsuarioCodigo;
                    txtUsuario.Enabled = false;
                    txtPassword.Text = string.Empty;
                    txtPassword.Enabled = false;
                    btnEmpezar.Focus();
                    break;
                case 1:
                    txtUsuario.Text = this.UsuarioCodigo;
                    if (txtUsuario.Text.Trim().Length < 1)
                        txtUsuario.Text = this.UsuarioCodigo;
                    txtUsuario.Enabled = true;
                    txtPassword.Text = string.Empty;
                    txtPassword.Enabled = true;
                    txtUsuario.Focus();
                    break;
            }
        }

        private void txtUsuario_EditValueChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            lblMensaje.Text = string.Empty;
            if (e.KeyCode == Keys.Return)
            {
                switch (int.Parse(cmbAcceso.EditValue.ToString()))
                {
                    case 0:
                        UsuarioModoValidacion = 0;
                        subIniciarSesionNT();
                        break;
                    case 1:
                        UsuarioModoValidacion = 1;
                        subIniciarSesion();
                        break;
                }
            }
        }

        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            switch (int.Parse(cmbAcceso.EditValue.ToString()))
            {
                case 0:
                    UsuarioModoValidacion = 0;
                    subIniciarSesionNT();
                    break;
                case 1:
                    UsuarioModoValidacion = 1;
                    subIniciarSesion();
                    break;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            VerVentanaValidando(true);
            Program.authResult = await Login();
            if (Program.authResult == null)
            {
                Program.AD = false;
                await Logout();
            }
            else
            {
                Program.AD = true;
            }
            VerVentanaValidando(false);
        }
        private async void simpleButton2_Click(object sender, EventArgs e)
        {
            Program.AD = false;
            await Logout();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }
    }
}