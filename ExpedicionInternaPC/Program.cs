using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraLayout;
using ExpedicionInternaPC.Helper;
using ExpedicionInternaPC.Properties;
using Interna.Entity;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Permissions;
using System.Threading;
///   using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    static class Program
    {
        #region AUTH-AZURE

        public static string ClientId = Settings.Default["ClientId"].ToString();//"57b3789e-9a55-4324-b028-f4460c70f468";//"d8934992-1ff3-4476-9c71-2ef38524d18f";//"0a1498b7-52c2-46f6-80c8-168daabc0eb0";
        public static string Tenant = Settings.Default["Tenant"].ToString();//"f26a3bc4-1409-43a2-ac2f-34ec8395d7ec";
        public static readonly string[] scopes = { Settings.Default["scopes"].ToString() };//{ "api://57b3789e-9a55-4324-b028-f4460c70f468/user_impersonation" }; //{ "api://b7521185-3ca4-474f-ae52-3934c87ae4f2/user_impersonation" }; 0a1498b7-52c2-46f6-80c8-168daabc0eb0
        private static IPublicClientApplication clientApp;
        public static IPublicClientApplication PublicClientApp { get { return clientApp; } }
        public static AuthenticationResult authResult;

        public static bool AD = false;
        #endregion

        // El usuario logueado en el sistema
        static public Usuario oUsuario = new Usuario();
        static public List<Usuario> oCliente = new List<Usuario>();
        static public string token;
        static public string refreshToken;
        static public string titulo = "SIMIH - Expedicion Interna";
        static public System.Media.SoundPlayer ok = new System.Media.SoundPlayer();
        static public frmMain oMain = null;
        static public int tipoAplicacion = 1;
        static public List<Configuracion> oConfi = new List<Configuracion>();
        static public int LONGITUD_CODIGO { get { return 30; } }


        static public int ExistePDA = int.Parse(Settings.Default["ExistePDA"].ToString());
        static public int ExisteDMA = int.Parse(Settings.Default["ExisteDMA"].ToString());
        static public int MinutosInactivo = int.Parse(Settings.Default["MinutosInactivo"].ToString());

        public static System.Windows.Forms.Timer IdleTimer = new System.Windows.Forms.Timer();
        //const int MinuteMicroseconds = MinutosInactivo * 60 * 1000;//3000000;//300000

        /// <summary>
        /// Punto de entrada principal para la aplicación
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.ExpressApp.FrameworkSettings.DefaultSettingsCompatibilityMode = DevExpress.ExpressApp.FrameworkSettingsCompatibilityMode.v20_1;
            InitializeAuh();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            int MinuteMicroseconds = MinutosInactivo * 60 * 1000;

            LeaveIdleMessageFilter limf = new LeaveIdleMessageFilter();
            Application.AddMessageFilter(limf);
            Application.Idle += new EventHandler(Application_Idle);
            IdleTimer.Interval = MinuteMicroseconds;
            IdleTimer.Tick += TimeDone;
            IdleTimer.Start();

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();

            string Look = "";
            try
            {
                Look = Settings.Default["Look"].ToString();
            }
            catch (Exception) { }

            if (Look.Length < 1)
                UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            else
                UserLookAndFeel.Default.SetSkinStyle(Look);

            oMain = new frmMain();
            Application.Run(oMain);
            Application.Idle -= new EventHandler(Application_Idle);
        }

        static private void Application_Idle(Object sender, EventArgs e)
        {
            if (!IdleTimer.Enabled)     // not yet idling?
                IdleTimer.Start();
        }

        static private void TimeDone(object sender, EventArgs e)
        {
            IdleTimer.Stop();   // not really necessary
            MessageBox.Show("Se ha cerrado la sesión por inactividad.");
            //oMain.cerrarSesion();            
            oMain.Close();

        }


        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public class LeaveIdleMessageFilter : IMessageFilter
        {
            const int WM_NCLBUTTONDOWN = 0x00A1;
            const int WM_NCLBUTTONUP = 0x00A2;
            const int WM_NCRBUTTONDOWN = 0x00A4;
            const int WM_NCRBUTTONUP = 0x00A5;
            const int WM_NCMBUTTONDOWN = 0x00A7;
            const int WM_NCMBUTTONUP = 0x00A8;
            const int WM_NCXBUTTONDOWN = 0x00AB;
            const int WM_NCXBUTTONUP = 0x00AC;
            const int WM_KEYDOWN = 0x0100;
            const int WM_KEYUP = 0x0101;
            const int WM_MOUSEMOVE = 0x0200;
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_LBUTTONUP = 0x0202;
            const int WM_RBUTTONDOWN = 0x0204;
            const int WM_RBUTTONUP = 0x0205;
            const int WM_MBUTTONDOWN = 0x0207;
            const int WM_MBUTTONUP = 0x0208;
            const int WM_XBUTTONDOWN = 0x020B;
            const int WM_XBUTTONUP = 0x020C;

            // The Messages array must be sorted due to use of Array.BinarySearch
            static int[] Messages = new int[] {WM_NCLBUTTONDOWN,
            WM_NCLBUTTONUP, WM_NCRBUTTONDOWN, WM_NCRBUTTONUP, WM_NCMBUTTONDOWN,
            WM_NCMBUTTONUP, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, WM_KEYDOWN, WM_KEYUP,
            WM_LBUTTONDOWN, WM_LBUTTONUP, WM_RBUTTONDOWN, WM_RBUTTONUP,
            WM_MBUTTONDOWN, WM_MBUTTONUP, WM_XBUTTONDOWN, WM_XBUTTONUP};

            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_MOUSEMOVE)  // mouse move is high volume
                    return false;
                if (!Program.IdleTimer.Enabled)     // idling?
                    return false;           // No
                if (Array.BinarySearch(Messages, m.Msg) >= 0)
                    Program.IdleTimer.Stop();
                return false;
            }
        }




        #region DISPOSITIVOS-MOVIL

        public static TipoDispositivoMovil seleccionarTipoDispositivoMovil()
        {
            frmSeleccionDispositivoMovil fx = new frmSeleccionDispositivoMovil();

            DialogResult res = fx.ShowDialog(Program.oMain);

            if (res == DialogResult.OK)
            {
                return TipoDispositivoMovil.MOVIL_PDA;
            }
            else if (res == DialogResult.Yes)
            {
                return TipoDispositivoMovil.MOVIL_ANDROID;
            }
            else
            {
                return TipoDispositivoMovil.TODOS;
            }
        }

        public static TipoDispositivoMovil obtenerTipoDispositivoMovilConfigurado()
        {
            TipoDispositivoMovil tipoDispositivoMovil;

            if (Program.ExistePDA == 1 && Program.ExisteDMA == 1)
            {
                tipoDispositivoMovil = TipoDispositivoMovil.TODOS;

            }
            else if (Program.ExistePDA == 1)
            {
                tipoDispositivoMovil = TipoDispositivoMovil.MOVIL_PDA;
            }
            else if (Program.ExisteDMA == 1)
            {
                tipoDispositivoMovil = TipoDispositivoMovil.MOVIL_ANDROID;
            }
            else
            {
                tipoDispositivoMovil = TipoDispositivoMovil.NO_CONFIGURADO;

            }
            return tipoDispositivoMovil;
        }


        #endregion


        private static void InitializeAuh()
        {
            clientApp = PublicClientApplicationBuilder.Create(ClientId)
                .WithRedirectUri("https://login.microsoftonline.com/common/oauth2/nativeclient")
                .WithAuthority(AzureCloudInstance.AzurePublic, Tenant)
                .Build();
            TokenCacheHelper.EnableSerialization(clientApp.UserTokenCache);
        }

        public static bool _HidePopWaitScreen = true;

        public static void HidePopWaitScreen()
        {
            _HidePopWaitScreen = true;
        }

        public static void ShowPopWaitScreen()
        {
            _HidePopWaitScreen = false;
            ThreadPool.QueueUserWorkItem((x) =>
            {
                using (var form = new frmWait())
                {
                    form.Show();
                    while (!_HidePopWaitScreen)
                        Application.DoEvents();
                    form.Close();
                }
                //using (var form = new frmMensajeWait())
                //{
                //    form.Show();
                //    while (!_HidePopWaitScreen)
                //        Application.DoEvents();
                //    form.Close();
                //}
            });
        }

        // Obtiene la version de publicacion de ClickOnce
        static public string GetCurrentPublishVersion()
        {
            string ver = "";
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                System.Deployment.Application.ApplicationDeployment ad = System.Deployment.Application.ApplicationDeployment.CurrentDeployment;
                ver = String.Format(" ({0}) ({1})", ad.CurrentVersion.ToString(), Application.ProductVersion);
            }
            else
                ver = " v" + Application.ProductVersion;
            return ver;
        }

        // retorna el formulario activo si el tipo es T
        static public Form GetFormActive(Form oMain, Form oFormComp)
        {
            if (oMain.ActiveMdiChild != null)
            {
                Type oTypeChild = oMain.ActiveMdiChild.GetType();
                Type oTypeComp = oFormComp.GetType();
                if (oTypeChild.FullName.Contains(oTypeComp.Name))
                    return oMain.ActiveMdiChild;
            }

            return null;
        }

        static public Form GetFormActive(Form oMain)
        {
            return oMain.ActiveMdiChild;
        }

        // retorna el formulario activo si el tag es igual
        static public Form GetFormActiveTag(string Tag, Form oMain)
        {
            if (Tag == null || oMain == null) return null;

            if (Tag.Length > 0)
            {
                if (oMain.ActiveMdiChild != null)
                    if (oMain.ActiveMdiChild.Tag != null)
                        if (oMain.ActiveMdiChild.Tag.Equals(Tag))
                            return oMain.ActiveMdiChild;
            }
            return null;
        }

        static public Form GetFormOpen(string Tag, Type t)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == t && frm.Tag.Equals(Tag))
                {
                    return frm;
                }
            }
            return null;
        }

        // Busca un formulario, retorna el que esta activo, sino busca el que sea igual y lo retorna
        static public Form GetFormActiveAny(String Tag, Form oMain)
        {
            if (GetFormActiveTag(Tag, oMain) != null)
            {
                return GetFormActiveTag(Tag, oMain);
            }
            else
            {
                foreach (Form oFrm2 in oMain.MdiChildren)
                    if (oFrm2.Tag != null)
                        if (oFrm2.Tag.ToString().ToUpper().Equals(Tag.ToUpper()))
                        {
                            oFrm2.Activate();
                            return oFrm2;
                        }
                return null;
            }
        }

        // Busca un formulario, si ya esta abierto lo enfoca, sino lo crea
        static public Form SetFormActive<T>(String Tag, Form oMain) where T : Form, new()
        {
            try
            {
                Form oFrm2 = GetFormActiveAny(Tag, oMain);
                if (oFrm2 != null) return oFrm2;

                T oF = new T();
                oF.MdiParent = oMain;
                oF.Tag = Tag;
                oF.Show();


                return oF;
            }
            catch (Exception)
            {
                // MessageBox.Show(e.Message, "Cartopac :: Ordenes de Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        static public String IPLocal()
        {
            try
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }
                return localIP;
            }
            catch (Exception) { }

            return "127.0.0.1";
        }
        static public void Actualizar()
        {
            foreach (Form oFrm2 in oMain.MdiChildren)
            {
                try
                {
                    frmChild oF = (frmChild)oFrm2;
                    oF.Actualizar("");
                }
                catch (Exception) { }
            }
        }
        static public void Actualizar(String CommandName)
        {
            foreach (Form oFrm2 in oMain.MdiChildren)
            {
                try
                {
                    frmChild oF = (frmChild)oFrm2;
                    oF.Actualizar(CommandName);
                }
                catch (Exception) { }
            }
        }
        static public void ComponentClear(LayoutControl obj, TextEdit focus)
        {
            foreach (Control misObjetos in obj.Controls)
            {
                if (misObjetos.GetType() == typeof(TextEdit) || misObjetos is TextBox)
                {
                    misObjetos.Text = "";
                    if (misObjetos.Name == focus.Name)
                    {
                        misObjetos.Select();
                        misObjetos.Focus();
                    }
                }
                if (misObjetos.GetType() == typeof(LookUpEdit))
                {
                    LookUpEdit e = (LookUpEdit)misObjetos;
                    e.ItemIndex = -1;

                }


            }
        }
        static public void ComponentClear(LayoutControl obj)
        {

            foreach (Control misObjetos in obj.Controls)
            {
                if (misObjetos.GetType() == typeof(TextEdit) || misObjetos is TextBox)
                {
                    misObjetos.Text = "";
                }
                if (misObjetos.GetType() == typeof(LookUpEdit))
                {
                    LookUpEdit e = (LookUpEdit)misObjetos;
                    e.ItemIndex = -1;

                }
            }
        }
        static public void obtenerRuta(String rutaInicio, TextEdit textoRuta, GridControl gridControlDatos)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Seleccionar archivo";
            op.Filter = "Todos los archivos Excel 2003 (*.xls)|*.xls|Todos los archivos Excel 2007 (*.xlsx)|*.xlsx";
            op.Multiselect = false;
            op.InitialDirectory = "C:\\";

            if (op.ShowDialog() == DialogResult.OK)
            {
                textoRuta.Text = op.FileName;
                if (rutaInicio != textoRuta.Text.Trim())
                {
                    gridControlDatos.DataSource = null;
                }
            }
            rutaInicio = op.FileName;
            //objPlantillaGral.Ruta = ruta;
        }
        static public DialogResult mensaje(string sMensaje, MessageBoxButtons mBoton, MessageBoxIcon mIcono)
        {
            return XtraMessageBox.Show(sMensaje, titulo, mBoton, mIcono);
        }
        static public DialogResult mensajeTokenInvalido()
        {
            return XtraMessageBox.Show("Su sesión ha expirado", titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        static public DialogResult mensajeError(string mensaje)
        {
            return XtraMessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        static public DialogResult mensajeConfirmacion(string mensaje)
        {
            return XtraMessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void soloNumeros(KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        public static void mayusculas(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.Parse(e.KeyChar.ToString().ToUpper());
            }
        }
        public static void minusculas(KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.KeyChar = char.Parse(e.KeyChar.ToString().ToLower());
            }
        }
        public static void alfanumericos(KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        public static void alfanumericosAndSpace(KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        public static void alfanumericosAndGuiones(KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(e.KeyChar == '-') && !(e.KeyChar == '_'))
            {
                e.Handled = true;
            }
        }
        public static void alfanumericosYGuionesBajo(KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && !(char.IsControl(e.KeyChar)) && !(e.KeyChar == '_'))
            {
                e.Handled = true;
            }
        }
        public static void limitarTexto(KeyPressEventArgs e, int tamanio, object txtEvaluar)
        {
            //if (txtEvaluar.Text.Count()>tamanio)
            //{
            //    e.Handled = true;
            //}
        }

        public static PerfilAsistencia ObtenerPerfilAsistencia(int perfil)
        {
            if (perfil == 1)
            {
                return PerfilAsistencia.ADMINISTRADOR;
            }
            else if (perfil == 2)
            {
                return PerfilAsistencia.JEFE;
            }
            else if (perfil == 3)
            {
                return PerfilAsistencia.SUPERVISOR;
            }
            else
            {
                return PerfilAsistencia.COLABORADOR;
            }

        }
    }

    public class InvalidTokenException : Exception
    {

    }
}
