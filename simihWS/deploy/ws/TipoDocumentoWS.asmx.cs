using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Interna.Entity;
using Interna.Entity.Estructuras;
using simihWS.Helper;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de TipoDocumentoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class TipoDocumentoWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string ListarTipoDocumentoPorTipoCorrespondenciaMesaDePartes(int IdTipoCorrespondencia)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            TipoDocumento oTipoDocumento = new TipoDocumento();
            return oTipoDocumento.ListarTipoDocumentoPorTipoCorrespondenciaMesaDePartes(IdTipoCorrespondencia);
        }
        //2022
        [WebMethod]
        public string ListarTipoDocumentoRegistrados()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            TipoDocumento oTipoDocumento = new TipoDocumento();
            return oTipoDocumento.ListarTipoDocumentoRegistrados();
        }
        //2022
        [WebMethod]
        public int RegistrarTipoDocumento(string sDescripcionTipoDocumento, byte iIdTipoCorrespondencia, byte iMoneda, bool entregaPersonalizada)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();            
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            TipoDocumento oTipoDocumento = new TipoDocumento()
            {
                sDescripcionTipoDocumento = sDescripcionTipoDocumento,
                iIdTipoCorrespondencia = iIdTipoCorrespondencia,
                iMoneda = iMoneda,
                entregaPersonalizada = entregaPersonalizada
            };

            return oTipoDocumento.RegistrarTipoDocumento();
        }
        //2022
        [WebMethod]
        public int ModificarTipoDocumento(short iIdTipoDocumento, string sDescripcionTipoDocumento, byte iIdTipoCorrespondencia, byte iMoneda, bool entregaPersonalizada)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            TipoDocumento oTipoDocumento = new TipoDocumento()
            {
                iIdTipoDocumento = iIdTipoDocumento,
                sDescripcionTipoDocumento = sDescripcionTipoDocumento,
                iIdTipoCorrespondencia = iIdTipoCorrespondencia,
                iMoneda = iMoneda,
                entregaPersonalizada = entregaPersonalizada
            };
            return oTipoDocumento.ModificarTipoDocumento();
        }

        //2022
        [WebMethod]
        public int AsociarModulo(int iIdModulo, short iIdTipoDocumento, int iIdCasilla, bool requiereDigitalizacion,string camposJson)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            ModuloCreacion oModulo = new ModuloCreacion()
            {
                iId = iIdModulo
            };

            TipoDocumento oTipoDocumento = new TipoDocumento()
            {
                iIdTipoDocumento = iIdTipoDocumento,
                requiereDigitalizacion = requiereDigitalizacion
            };

            Casilla oCasilla = new Casilla() {
                ID = iIdCasilla
            };

            return oTipoDocumento.AsociarModulo(oModulo, oCasilla, camposJson);
        }
        //2022
        [WebMethod]
        public int QuitarAsociacionModulo(int IdModulo, int IdTipoDocumento)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }
            TipoDocumento oTipoDocumento = new TipoDocumento();
            return oTipoDocumento.QuitarAsociacionModulo(IdModulo, IdTipoDocumento);
        }

        [WebMethod]
        public string ListarTipoDocumentoDigital()
        {
            TipoDocumento oTipoDocumento = new TipoDocumento();
            return oTipoDocumento.ListarTipoDocumentoDigital();
        }

        // Funcional - frmEditarCamposDinamicos
        [WebMethod]
        public int EditarCamposDocumentosEspeciales(short iIdTipoDocumento, bool requiereDigitalizacion, string camposJson)
        {            

            TipoDocumento oTipoDocumento = new TipoDocumento()
            {
                iIdTipoDocumento = iIdTipoDocumento,
                requiereDigitalizacion = requiereDigitalizacion
            };
            
            return oTipoDocumento.EditarCamposDocumentosEspeciales(camposJson);
        }

        [WebMethod]
        public string ListarTipoDocumentoSinDigitalizar()
        {
            return TipoDocumento.ListarTipoDocumentoSinDigitalizacion();
        }
    }
}
