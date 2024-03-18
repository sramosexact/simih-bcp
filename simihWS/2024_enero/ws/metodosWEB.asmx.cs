using Interna.Entity;
using simihWS.auth;
using simihWS.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de metodosWEB
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class metodosWEB : System.Web.Services.WebService
    {

        /*******encriptado-(31/Julio/2015)*******/
        [WebMethod]
        public string Encriptado(string a)
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            Interna.Core.Methods oM = new Interna.Core.Methods();
            oU.Descripcion = oM.Encriptar(a);

            return new JavaScriptSerializer().Serialize(oU);
        }
        /*******Desencriptado-(7/Agosto/2015)*******/
        [WebMethod]
        public string Desencriptado(string a)
        {
            Interna.Core.Methods oM = new Interna.Core.Methods();
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            oU.Descripcion = oM.Desencriptar(a);

            return new JavaScriptSerializer().Serialize(oU);
        }

        [WebMethod]
        public string Menu(int a)
        {
            Interna.Entity.Menu oM = new Interna.Entity.Menu();
            string resultado = new JavaScriptSerializer().Serialize(oM.rListadoTipo(a));
            return resultado;
        }

        [WebMethod]
        public string BandejaConfiguracion(string idCasilla)
        {
            Interna.Entity.Casilla oC = new Interna.Entity.Casilla();
            Interna.Entity.Casilla oCEntity = new Interna.Entity.Casilla();
            oCEntity.ID = Convert.ToInt16(idCasilla);
            return new JavaScriptSerializer().Serialize(oC.rCasillaConfiguracion(oCEntity));
        }


        [WebMethod]
        public string BandejaConfiguracionWEB(string jsonSTRING)
        {
            Interna.Entity.Casilla oC = new Interna.Entity.Casilla();
            return new JavaScriptSerializer().Serialize(oC.ConfiguracionBandejaWEB(jsonSTRING));
        }
        //2022
        [WebMethod]
        public string Bandejas(string b, int pagina)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Casilla oM = new Casilla();
            return new JavaScriptSerializer().Serialize(oM.rBuscarCasillas(b, pagina));
        }

        //confirmarEnvio
        [WebMethod]
        public string confirmarCorrespondencia(int idCasilla)
        {
            Interna.Entity.Objeto oM = new Interna.Entity.Objeto();

            return oM.rObtenerRecibidosJSON(idCasilla);
        }

        // JOS---correspondencia recibida
        [WebMethod]
        public string ingresoJOS(int idGeo, int opc, int idEntrega)
        {
            Interna.Entity.Fac oM = new Interna.Entity.Fac();
            return oM.rVerCorrespondenciaRecibidasFACJSON(idGeo, opc, idEntrega);
        }

        // PUNTO DE ENTREGA
        [WebMethod]
        public string puntoEntrega(int idCliente, int idUsuario)
        {
            Interna.Entity.Fac oM = new Interna.Entity.Fac();

            return oM.rVerGeoFacJSON(idCliente, idUsuario);
        }


        //2022 por eliminar
        [WebMethod]
        public string getSeguimiento(int id)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();
            return oM.rObjetoSeguimientoJSON(id, Convert.ToInt16(casilla));
        }

        //2023
        [WebMethod]
        public string CorrespondenciaSeguimiento(int CorrespondenciaId)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            Objeto oM = new Objeto();
            return oM.CorrespondenciaSeguimiento(CorrespondenciaId, accessToken.GetUpn());
        }

        //JOS---correspondencia salida
        [WebMethod]
        public string salidaJOS(int idGeo)
        {
            Interna.Entity.Fac oM = new Interna.Entity.Fac();

            return oM.rVerCorrespondenciaRecibidasFAC_SALIDAJSON(idGeo);
        }

        //2022 por eliminar
        [WebMethod]
        public string ActivosIngresos()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();

            return oM.ActivosIngresos(Convert.ToInt32(casilla));
        }

        //2022 por eliminar
        [WebMethod]
        public string ActivosSalida()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();

            return oM.ActivosSalida(Convert.ToInt32(casilla));
        }

        //2023
        [WebMethod]
        public string CorrespondenciaActivaBandejaSalida()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            return oM.CorrespondenciaActivaBandejaSalida(accessToken.GetUpn());
        }

        //2023
        [WebMethod]
        public string CorrespondenciaActivaBandejaEntrada()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            return oM.CorrespondenciaActivaBandejaEntrada(accessToken.GetUpn());
        }


        //2022 por eliminar
        [WebMethod]
        public string HistoricoIngreso(string fechaIni, string fechaFin)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();

            return oM.ObjetosHistoricoJSON(Convert.ToInt32(casilla), fechaIni, fechaFin);
        }

        //2023
        [WebMethod]
        public string CorrespondenciaHistoricaBandejaEntrada(string fechaDesde, string fechaHasta)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            return oM.CorrespondenciaHistoricaBandejaEntrada(accessToken.GetUpn(), fechaDesde, fechaHasta);
        }

        //2022 por eliminar
        [WebMethod]
        public string HistoricoSalida(string fechaIni, string fechaFin)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();

            return oM.ObjetosHistoricoSalidasJSON(Convert.ToInt32(casilla), fechaIni, fechaFin);
        }

        //2023
        [WebMethod]
        public string CorrespondenciaHistoricaBandejaSalida(string fechaDesde, string fechaHasta)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            return oM.CorrespondenciaHistoricaBandejaSalida(accessToken.GetUpn(), fechaDesde, fechaHasta);
        }


        //2022
        [WebMethod]
        public string HistoricoRetirado(string fechaIni, string fechaFin)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();

            return oM.ObjetosHistoricoRetiradoJSON(Convert.ToInt32(casilla), fechaIni, fechaFin);
        }

        //2023
        [WebMethod]
        public string CorrespondenciaHistoricaRetiradosBandejaEntrada(string fechaDesde, string fechaHasta)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();

            return oM.CorrespondenciaHistoricaRetiradosBandejaEntrada(accessToken.GetUpn(), fechaDesde, fechaHasta);
        }

        //2022
        [WebMethod]
        public string BandejaIndicadores(int tipo)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();
            return oM.rObjetosINDICADORESJSON(int.Parse(casilla), tipo);
        }

        //Bandeja-IndicadoresVISTOS
        [WebMethod]
        public string bandejaIndicadoresvistos(int idCasilla, int tipo)
        {
            Interna.Entity.Objeto oM = new Interna.Entity.Objeto();
            return oM.rObjetosINDICADORESVISTOSJSON(idCasilla, tipo);
        }


        [WebMethod]
        public string obtenerDocumentoContenido(int id)
        {
            Interna.Entity.Objeto oM = new Interna.Entity.Objeto();
            return oM.rObtenerDetalleJSON(id);
        }

        //2022
        [WebMethod]
        public string obtenerDocumentoContenido2(int id)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();
            return oM.rObtenerDetalleWEXIJSON(id, Convert.ToInt16(casilla));
        }
        //2023
        [WebMethod]
        public string CorrespondenciaDetalle(int correspondenciaId)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            return oM.CorrespondenciaDetalle(correspondenciaId, accessToken.GetUpn());
        }

        //2022
        [WebMethod]
        public string HijoCorrespondencia(int IdTipoCorrespondencia)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            int IdCasilla = int.Parse(accessToken.GetCasilla());

            Tipo oM = new Tipo();
            return new JavaScriptSerializer().Serialize(oM.rHijoDoc(IdTipoCorrespondencia, IdCasilla));

        }


        [WebMethod]
        public string Correspondencia(string a)
        {
            Interna.Entity.Tipo oM = new Interna.Entity.Tipo();
            oM.Alias = a;
            return new JavaScriptSerializer().Serialize(oM.rBuscaTipo_Formato_Documento(oM));
        }
        //2022
        [WebMethod]
        public string ObtenerListas()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string upn = accessToken.GetUpn();
            int casilla = int.Parse(accessToken.GetCasilla());

            Interna.Core.Methods oM = new Interna.Core.Methods();
            Listas oL = new Listas();
            return new JavaScriptSerializer().Serialize(oL.cargarListas(upn, casilla));
        }
        //2022
        [WebMethod]
        public string RegistrarCorrespondencia(
            string para,
            string detalle,
            int Seguimiento)
        {

            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string upn = accessToken.GetUpn();
            string casilla = accessToken.GetCasilla();

            Objeto oB = new Objeto();
            oB.IdCasillaDe = Convert.ToInt16(casilla);
            oB.IdCasillaPara = Convert.ToInt16(para);
            oB.idTipoValidacion = Seguimiento;
            oB.ListaXML = detalle;
            return new JavaScriptSerializer().Serialize(oB.RegistrarCorrespondencia(upn));
        }
        //jos historicos

        [WebMethod]
        public string correspondenciaFacHistoricaTotal(int opcion, int idGeo, string fecha_ini, string fecha_fin)
        {
            Interna.Entity.Fac oM = new Interna.Entity.Fac();
            return oM.rVerObjetoDocFACHistoricaTotal(opcion, idGeo, fecha_ini, fecha_fin);
        }


        //2022 por eliminar
        [WebMethod]
        public string documentosJSON()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();
            return oM.rObjetosDOCUMENTOSJSON(Convert.ToInt16(casilla));
        }

        //2023
        [WebMethod]
        public string CorrespondenciaPorConfirmar()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            return oM.CorrespondenciaPorConfirmar(accessToken.GetUpn());
        }

        //2022
        [WebMethod]
        public string DocumentosPorConfirmarJSONs(String valores)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            int r = oM.rObjetoPorConfirmarJSON(valores);
            return r.ToString();
        }

        //2023
        [WebMethod]
        public string CorrespondenciaConfirmar(String valores)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            int r = oM.CorrespondenciaConfirmar(valores, accessToken.GetUpn());
            return r.ToString();
        }

        [WebMethod]
        public string objectoRecibirFacJSON(String cadena, int de, int idUsuario, int idEntrega)
        {
            Interna.Entity.Objeto oM = new Interna.Entity.Objeto();
            int r = oM.uObjecto_Recibir_Fac_JSON(cadena, de, idUsuario, idEntrega);
            return r.ToString();
        }

        [WebMethod]
        public string objectoRecibirFacCreadosJSON(String cadena, int de, int idUsuario)
        {
            Interna.Entity.Objeto oM = new Interna.Entity.Objeto();
            int r = oM.uObjecto_Recibir_Fac_Creados_JSON(cadena, de, idUsuario);
            return r.ToString();
        }
        //2022 por eliminar
        [WebMethod]
        public string getObtenerIndicadoresInicio(String fechaI, String fechaF)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();
            return oM.rObtenerIndicadoresInicio(Convert.ToInt16(casilla), fechaI, fechaF);
        }
        //2023
        [WebMethod]
        public string ObtenerIndicadoresInicioPorUsuario(String fechaI, String fechaF)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string casilla = accessToken.GetCasilla();

            Objeto oM = new Objeto();
            return oM.ObtenerIndicadoresInicioPorUsuario(accessToken.GetUpn(), fechaI, fechaF);
        }
        //2022
        [WebMethod]
        public string getFacNotificacionesJson()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);


            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            Fac oM = new Fac();
            return oM.rFacNotificacionesJson(int.Parse(accessToken.GetIdUsuario()));
        }

        [WebMethod]
        public string TerminarEntrega(int idEntrega, int idExpedicion, int idUsuario)
        {
            Interna.Entity.Entrega oE = new Interna.Entity.Entrega();
            return new JavaScriptSerializer().Serialize(oE.uEntregaPisosTerminar(idEntrega, idExpedicion, idUsuario));
        }

        [WebMethod]
        public string ListarAgenciasVinculadasAlUsuario(int iIdUsuario)
        {
            Interna.Entity.Usuario oE = new Interna.Entity.Usuario();
            oE.ID = iIdUsuario;
            return new JavaScriptSerializer().Serialize(oE.ListarAgenciasVinculadasAlUsuario());
        }

        [WebMethod]
        public string ListarEntregasPorRecibirPorJOS(int iIdAgencia)
        {
            Interna.Entity.Entrega oE = new Interna.Entity.Entrega();
            return new JavaScriptSerializer().Serialize(oE.ListarEntregasPorRecibirPorJOS(iIdAgencia));
        }

        [WebMethod]
        public string ListarEntregaDetalleJOS(int iIdEntrega)
        {
            Interna.Entity.Entrega oE = new Interna.Entity.Entrega();
            oE.ID = iIdEntrega;
            return new JavaScriptSerializer().Serialize(oE.ListarEntregaDetalleJOS());
        }

        [WebMethod]
        public string ListarEntregasCerradasJOS(int iIdAgencia, string fecha_ini, string fecha_fin)
        {
            Interna.Entity.Entrega oE = new Interna.Entity.Entrega();
            return new JavaScriptSerializer().Serialize(oE.ListarEntregasCerradasJOS(iIdAgencia, fecha_ini, fecha_fin));
        }

        [WebMethod]
        public string ListarEntregaDetalleCerradasJOS(int iIdEntrega)
        {
            Interna.Entity.Entrega oE = new Interna.Entity.Entrega();
            oE.ID = iIdEntrega;
            return new JavaScriptSerializer().Serialize(oE.ListarEntregaDetalleCerradasJOS());
        }

        [WebMethod]
        public string ListarDocumentosActivosDigitalizacion(int idCasilla)
        {
            Documento oDocumento = new Documento();
            return oDocumento.ListarDocumentosActivosDigitalizacion(idCasilla);
        }

        [WebMethod]
        public string ListarDocumentosHistoricosDigitalizacion(int idCasilla, string FechaDesde, string FechaHasta)
        {
            DateTime dFechaDesde = Convert.ToDateTime(FechaDesde);
            DateTime dFechaHasta = Convert.ToDateTime(FechaHasta);
            Documento oDocumento = new Documento();
            return oDocumento.ListarDocumentosHistoricosDigitalizacion(idCasilla, dFechaDesde, dFechaHasta);
        }

        [WebMethod]
        public string verImagenDigitalizada(string ruta)
        {
            System.Drawing.Image im = System.Drawing.Image.FromFile(ruta);

            using (var ms = new MemoryStream())
            {
                im.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                byte[] b = ms.ToArray();
                return Convert.ToBase64String(b);
            }
        }

        [WebMethod]
        public string RecibirRechazarDocumentoDigitalizado(int iIdDocumento, int iIdUsuario, int iIdCasilla, int accion, string motivo)
        {
            Documento oDocumento = new Documento();
            return Convert.ToString(oDocumento.RecibirRechazarDocumentoDigitalizado(iIdDocumento, iIdUsuario, iIdCasilla, accion, motivo));
        }

        [WebMethod]
        public string ListarDetalleDocumento(int iIdDocumento)
        {
            CampoExterno campoExterno = new CampoExterno();
            campoExterno.iIdDocumento = iIdDocumento;
            return campoExterno.ListarDetalleDocumento(iIdDocumento);
        }

        [WebMethod]
        public string ListarTipoReclamoUsuario()
        {
            TipoReclamoUsuario tipoReclamoUsuario = new TipoReclamoUsuario();
            return tipoReclamoUsuario.ListarTipoReclamoUsuario();
        }

        [WebMethod]
        public string ListarAreaSedeUsuario(int a)
        {
            Interna.Entity.Usuario usuario = new Interna.Entity.Usuario();
            usuario.ID = a;
            return usuario.ListarAreaSedeUsuario();
        }

        [WebMethod]
        public int RegistrarReclamo(int iIdUsuario, byte iIdTipoReclamoUsuario, string sDocReferencia, string sDetalle)
        {
            Reclamo reclamo = new Reclamo(iIdUsuario, iIdTipoReclamoUsuario, sDocReferencia, sDetalle);
            reclamo.iIdUsuario = iIdUsuario;
            return reclamo.RegistrarReclamo();
        }

        [WebMethod]
        public string ListarReclamoUsuario(int iIdUsuario)
        {
            Reclamo reclamo = new Reclamo();
            reclamo.iIdUsuario = iIdUsuario;
            return reclamo.ListarReclamoUsuario();
        }

        [WebMethod]
        public string ListarCantidadPorTiposReclamo(DateTime fechaInicio, DateTime fechaFin)
        {
            TipoReclamoUTD tipoReclamoUTD = new TipoReclamoUTD();
            return tipoReclamoUTD.ListarCantidadPorTiposReclamo(fechaInicio, fechaFin);
        }

        [WebMethod]
        public string listarCantidadPorMotivoCambioEstado(DateTime fechaInicio, DateTime fechaFin)
        {
            MotivoCambioEstado motivoCambioEstado = new MotivoCambioEstado();
            return motivoCambioEstado.listarCantidadPorMotivoCambioEstado(fechaInicio, fechaFin);
        }

        [WebMethod]
        public string ListarReclamosPorRangoDeFecha(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return new Reclamo().ListarReclamosPorRangoDeFecha(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarRetiradosPorRangoDeFecha(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            return new Objeto().ListarRetiradosPorRango(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarCantidadEstadosIndicador(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ListarCantidadEstadosIndicador(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarEstadosIndicador(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ListarEstadosIndicador(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarCantidadEstadoAutogeneradoActual(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ListarCantidadEstadoAutogeneradoActual(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarDetalleEstadoAutogeneradoActual(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ListarDetalleEstadoAutogeneradoActual(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarCantidadEstadoAutogeneradoActualCustodia(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ListarCantidadEstadoAutogeneradoActualCustodia(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarDetalleEstadoAutogeneradoActualCustodia(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ListarDetalleEstadoAutogeneradoActualCustodia(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarCantidadEstadosIndicadorCustodia(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ListarCantidadEstadosIndicadorCustodia(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarEstadosIndicadorCustodia(DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ListarEstadosIndicadorCustodia(dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ReporteDocumentosEspeciales(int tipodocumento, DateTime dFechaInicial, DateTime dFechaFinal)
        {
            Objeto Oo = new Objeto();
            return Oo.ReporteDocumentosEspeciales(tipodocumento, dFechaInicial, dFechaFinal);
        }

        [WebMethod]
        public string ListarTipoDocumentoDigital()
        {
            TipoDocumento oTipoDocumento = new TipoDocumento();
            return oTipoDocumento.ListarTipoDocumentoDigital();
        }

        [WebMethod]
        public string ReporteProductividadParcial(DateTime fechaInicio, DateTime fechaFinal)
        {
            return ReporteProductividad.ReporteParcial(fechaInicio, fechaFinal);
        }

        [WebMethod]
        public string ReporteProductividadFinal(string reportes)
        {
            return ReporteProductividad.ReporteFinal(reportes);
        }

        [WebMethod]
        public string CargarReporteProductividad(DateTime fechaInicio, DateTime fechaFinal)
        {
            return ReporteProductividadGrupo.ListarReporteProductividadGrupo(fechaInicio, fechaFinal);
        }

        [WebMethod]
        public string ImportarReporteProductividad(string registros, string nombreArchivo)
        {
            ReporteProductividadGrupo oReporte = new ReporteProductividadGrupo();
            oReporte.xmlReporte = registros;
            return Convert.ToString(oReporte.ImportarReporteProductividad(nombreArchivo));
        }

        [WebMethod]
        public string EliminarReporteProductividad(int id)
        {
            ReporteProductividadGrupo oReporte = new ReporteProductividadGrupo();

            return Convert.ToString(oReporte.EliminarReporteProductividad(id));
        }
        //2022
        [WebMethod]
        public string ListarTiposCorrespondencia()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            TipoCorrespondencia oM = new TipoCorrespondencia();
            return oM.ListarTiposCorrespondenciaEnMesaDePartes();
        }
        //2022
        [WebMethod]
        public string CambiarBandeja(int casilla)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            string upn = accessToken.GetUpn();
            int idUsuario = int.Parse(accessToken.GetIdUsuario());
            List<GrupoAzure> grupoAzureList = accessToken.GetGroups();

            Usuario usuarioBD = new Usuario();
            usuarioBD = usuarioBD.ObtenerUsuarioPorCasilla(upn, casilla);

            if (usuarioBD == null || usuarioBD.ID == 0)
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Casilla oC = new Casilla();
            Interna.Core.Methods oM = new Interna.Core.Methods();

            usuarioBD.Descripcion = oM.Encriptar(usuarioBD.ID.ToString());
            usuarioBD.descripcionCasilla = new JavaScriptSerializer().Serialize(oC.CasillaUsuario(usuarioBD.ID));
            usuarioBD.alias = oC.rObtenerConfiguracionls(usuarioBD.idCasilla);
            usuarioBD.ID = 0;

            List<string> listaGrupos = new List<string>();
            grupoAzureList.ForEach(x => listaGrupos.Add(x.sValorGrupo));
            string[] gruposAzure = listaGrupos.ToArray();

            Dictionary<string, object> sClaims = new Dictionary<string, object>();
            sClaims.Add("upn", upn);
            sClaims.Add("groups", gruposAzure);
            sClaims.Add("casilla", usuarioBD.idCasilla.ToString());
            sClaims.Add("id", idUsuario.ToString());

            string[] tokens = RequestHandler.TokenBuilder(sClaims);

            Response response = new Response(tokens[0], tokens[1], usuarioBD);

            string respuestaJson = new JavaScriptSerializer().Serialize(response);

            TokenUsuario tokenUsuario = new TokenUsuario();

            tokenUsuario.RegistrarTokenUsuario(tokens[0], idUsuario);

            return respuestaJson;

        }

        //2022
        [WebMethod]
        public string LogOut()
        {
            string respuestaJson;

            HttpContext httpContext = HttpContext.Current;
            AccessToken accessToken = new AccessToken(httpContext);


            TokenUsuario tokenUsuario = new TokenUsuario(); int resultado;
            try
            {
                resultado = tokenUsuario.ActualizarTokenUsuario(int.Parse(accessToken.GetIdUsuario()));
            }
            catch (Exception)
            {
                resultado = 0;
            }

            if (resultado <= 0)
            {
                httpContext.Response.StatusCode = 500;
                httpContext.Response.AddHeader("WWW-Authenticate", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }



            Response response = new Response("", "", new Usuario());
            respuestaJson = new JavaScriptSerializer().Serialize(response);

            return respuestaJson;

        }

        //2023
        [WebMethod]
        public string RegistrarCorrespondenciaBandejaRemitente(
            int bandejaRemitenteId,
            string para,
            string detalle,
            int Seguimiento)
        {

            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            string upn = accessToken.GetUpn();
            string casilla = accessToken.GetCasilla();

            Objeto oB = new Objeto();
            //oB.IdCasillaDe = Convert.ToInt16(casilla);
            oB.IdCasillaDe = bandejaRemitenteId;
            oB.IdCasillaPara = Convert.ToInt16(para);
            oB.idTipoValidacion = Seguimiento;
            oB.ListaXML = detalle;
            return new JavaScriptSerializer().Serialize(oB.RegistrarCorrespondencia(upn));
        }
        //2023
        [WebMethod]
        public string ReportePorAutogenerado(string autogenerado)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto Oo = new Objeto();
            return Oo.ReportePorAutogenerado(autogenerado);
        }

        //2023
        [WebMethod]
        public string ReportePorMatricula(string matricula, DateTime fechaInicio, DateTime fechaFin)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto Oo = new Objeto();
            return Oo.ReportePorMatricula(matricula, fechaInicio, fechaFin);
        }

        //2023
        [WebMethod]
        public string ReportePorEstado(int estadoId, DateTime fechaInicio, DateTime fechaFin)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto Oo = new Objeto();
            return Oo.ReportePorEstado(estadoId, fechaInicio, fechaFin);
        }

        //2023
        [WebMethod]
        public string ReporteDocumentosEntreExpediciones(int expedicionOrigenId, int expedicionDestinoId, int areaOrigenId, int areaDestinoId, DateTime fechaInicio, DateTime fechaFin)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto Oo = new Objeto();
            return Oo.ReporteDocumentosEntreExpediciones(expedicionOrigenId, expedicionDestinoId, areaOrigenId, areaDestinoId, fechaInicio, fechaFin);
        }

        //2023
        [WebMethod]
        public string ReporteDocumentosHaciaAgencias(int tipoAgenciaId, DateTime fechaInicio, DateTime fechaFin)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto Oo = new Objeto();
            return Oo.ReporteDocumentosHaciaAgencias(tipoAgenciaId, fechaInicio, fechaFin);
        }

        //2023
        [WebMethod]
        public string ListarExpediciones()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Expedicion expedicion = new Expedicion();
            return expedicion.ListarExpediciones();
        }

        //2023
        [WebMethod]
        public string ListarAreasPorExpedicion(int expedicionId)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Geo geo = new Geo();
            return geo.ListarAreasPorExpedicion(expedicionId);
        }



        //2023
        [WebMethod]
        public string ReporteCorrespondenciaDetalle(int correspondenciaId)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Objeto oM = new Objeto();
            return oM.ReporteCorrespondenciaDetalle(correspondenciaId);
        }

        //2023
        [WebMethod]
        public string ReporteCorrespondenciaSeguimiento(int CorrespondenciaId)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_USUARIO);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }
            Objeto oM = new Objeto();
            return oM.ReporteCorrespondenciaSeguimiento(CorrespondenciaId);
        }
    }
}
