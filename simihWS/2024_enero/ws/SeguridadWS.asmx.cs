using Interna.Entity;
using simihWS.auth;
using System;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de SeguridadWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class SeguridadWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string GetObtener_Usuario_Seguridad(int iIdCliente, int modoAutenticacion)
        {
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader.Contains("Basic"))
            {
                string credenciales64 = authHeader.Substring(6);
                byte[] credencialesByte = Convert.FromBase64String(credenciales64);
                string credencialesString = Encoding.ASCII.GetString(credencialesByte);
                string usuario = credencialesString.Split(':')[0];
                string password = credencialesString.Split(':')[1];

                Usuario oU = new Usuario();

                oU.Usu = usuario;
                oU.Password = password;
                oU.IdCliente = iIdCliente;
                oU.Modo = modoAutenticacion;

                Usuario usuarioBD = oU.rUsuario_Val();

                if (usuarioBD == null || usuarioBD.ID == 0)
                {
                    httpContext.Response.StatusCode = 401;
                    httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                    return "";
                }

                string[] tokens = RequestHandler.TokenBuilder(null);

                Response response = new Response(tokens[0], tokens[1], usuarioBD);

                string respuestaJson = new JavaScriptSerializer().Serialize(response);

                return respuestaJson;

            }
            else
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }



        }
        //2022
        [WebMethod]
        public string GetObtener_Usuario_Seguridad_NT(int iIdCliente)
        {
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader.Contains("Basic"))
            {
                string credenciales64 = authHeader.Substring(6);
                byte[] credencialesByte = Convert.FromBase64String(credenciales64);
                string credencialesString = Encoding.ASCII.GetString(credencialesByte);
                string dominio = credencialesString.Split(':')[0];
                string usuario = credencialesString.Split(':')[1];
                Usuario oU = new Usuario();

                oU.Usu = usuario;
                oU.IdCliente = iIdCliente;
                oU.sDominio = dominio;

                Usuario usuarioBD = oU.rUsuario_Val_NT();

                if (usuarioBD == null || usuarioBD.ID == 0)
                {
                    httpContext.Response.StatusCode = 401;
                    httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                    return "";
                }

                string[] tokens = RequestHandler.TokenBuilder(null);

                Response response = new Response(tokens[0], tokens[1], usuarioBD);

                string respuestaJson = new JavaScriptSerializer().Serialize(response);

                return respuestaJson;

            }
            else
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }



        }
        //2022
        [WebMethod]
        public string LoginWeb()
        {
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader.Contains("Basic"))
            {
                string credenciales64 = authHeader.Substring(6);
                byte[] credencialesByte = Convert.FromBase64String(credenciales64);
                string credencialesString = Encoding.ASCII.GetString(credencialesByte);
                string usuario = credencialesString.Split(':')[0];
                string password = credencialesString.Split(':')[1];
                Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
                Casilla oC = new Casilla();
                Interna.Core.Methods oM = new Interna.Core.Methods();
                oU = oU.Login(usuario, password);
                oU.Descripcion = oM.Encriptar(oU.ID.ToString());
                oU.descripcionCasilla = new JavaScriptSerializer().Serialize(oC.CasillaUsuario(oU.ID));
                oU.alias = oC.rObtenerConfiguracionls(oU.idCasilla);
                oU.ID = 0;
                string[] tokens = RequestHandler.TokenBuilder(null);

                Response response = new Response(tokens[0], tokens[1], oU);

                string respuestaJson = new JavaScriptSerializer().Serialize(response);

                return respuestaJson;
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
        }

        [WebMethod]
        public string WinLoginWeb()
        {
            HttpContext httpContext = HttpContext.Current;
            string authHeader = httpContext.Request.Headers["Authorization"];

            if (authHeader.Contains("Basic"))
            {
                string credenciales64 = authHeader.Substring(6);
                byte[] credencialesByte = Convert.FromBase64String(credenciales64);
                string credencialesString = Encoding.ASCII.GetString(credencialesByte);
                string dominio = credencialesString.Split(':')[0];
                string usuario = credencialesString.Split(':')[1];
                Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
                Casilla oC = new Casilla();
                Interna.Core.Methods oM = new Interna.Core.Methods();
                oU.Usu = usuario;
                oU.IdCliente = 1;
                oU.sDominio = dominio;

                Usuario usuarioBD = oU.rUsuario_Val_NT();

                if (usuarioBD == null || usuarioBD.ID == 0 || usuarioBD.IdTipoAcceso == 42)
                {
                    httpContext.Response.StatusCode = 401;
                    httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                    return "";
                }

                usuarioBD.Descripcion = oM.Encriptar(oU.ID.ToString());
                usuarioBD.descripcionCasilla = new JavaScriptSerializer().Serialize(oC.CasillaUsuario(usuarioBD.ID));
                usuarioBD.alias = oC.rObtenerConfiguracionls(oU.idCasilla);
                usuarioBD.ID = 0;
                string[] tokens = RequestHandler.TokenBuilder(null);

                Response response = new Response(tokens[0], tokens[1], usuarioBD);

                string respuestaJson = new JavaScriptSerializer().Serialize(response);

                return respuestaJson;
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
        }


    }
}
