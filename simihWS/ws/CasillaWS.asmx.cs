using Interna.Entity;
using simihWS.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de CasillaWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class CasillaWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string rBuscaTexto(int IdCliente, string texto)
        {
            Cliente oCliente = new Cliente();
            oCliente.ID = IdCliente;
            Casilla oCasilla = new Casilla();
            return oCasilla.rBuscaTexto(oCliente, texto);
        }

        [WebMethod]
        public string FetchEmailList(string mail)
        {
            var emp = new Casilla();
            return emp.FetchMailList(mail);
        }

        [WebMethod]
        public string rBuscaTexto2(string texto)
        {
            Casilla oCasilla = new Casilla();
            Cliente oCliente = new Cliente();
            oCliente.ID = 1;
            return oCasilla.rBuscaTexto(oCliente, texto);
        }

        [WebMethod]
        public Casilla GetCasilla(int ID)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rBuscaID(ID);
        }


        [WebMethod]
        public Casilla GetCasilla2(int idUsuario, int idCasilla)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rBuscaID2(idCasilla, idUsuario);

        }


        [WebMethod]
        public List<Geo> GetGeo()
        {
            Geo oGeo = new Geo();
            return oGeo.rVerGeo();
        }

        [WebMethod]
        public List<Geo> GetGeo_puntoEntrega(int idUsuario, int idCliente)
        {
            Geo oGeo = new Geo();
            return oGeo.rVerGeo_puntoEntrega(idUsuario, idCliente);
        }

        [WebMethod]
        public List<Geo> GetGeo2(Interna.Entity.Cliente oC)
        {
            Geo oGeo = new Geo();
            return oGeo.rVerGeo2(oC);
        }

        [WebMethod]
        public int SetCasilla(Interna.Entity.Casilla oC)
        {
            return oC.uCasilla();
        }

        [WebMethod]
        public int SetCasillaCambioGeo(int IdGeo, int IdNuevoGeo)
        {
            Casilla oC = new Casilla();
            return oC.uCasillaCambioGeo(IdGeo, IdNuevoGeo);
        }

        [WebMethod]
        public List<Casilla> GetCasilla_Estados(Interna.Entity.Casilla oC)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rBuscaActivacionCasilla(oC);
        }

        [WebMethod]
        public List<Casilla> GetCasilla_Menu(Interna.Entity.Casilla oC)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rBuscaMenu(oC);
        }

        [WebMethod]
        public Casilla GetCasilla_CorreoIguales(Interna.Entity.Casilla oC)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rBuscarCorreoIguales(oC);

        }

        [WebMethod]
        public int GetUsuario_Validacion(Interna.Entity.Usuario oU)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rValidarUsuario(oU);
        }

        [WebMethod]
        public List<Casilla> GetCasillasDesactivadas(Interna.Entity.Usuario oC)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rCasillaDesactivadas(oC);
        }

        [WebMethod]
        public int SetCasillaActivarNueva(Interna.Entity.Casilla oC)
        {
            return oC.rCasillaActivarNueva(oC);
        }


        [WebMethod]
        public Casilla GetCuadroMando(int Cas)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rCuadro_de_Mando(Cas);
        }

        [WebMethod]
        public List<Casilla> GetCasillaListaPorGeo(int IdGeo)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaPorGeo(IdGeo);
        }

        [WebMethod]
        public List<Casilla> GetCasillaListaPorGeo2(int IdGeo2)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaPorGeo(0, IdGeo2);
        }

        [WebMethod]
        public List<Casilla> GetCasillaBandejaTotal(Interna.Entity.Casilla oC)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaBandejaTotal(oC);
        }

        [WebMethod]
        public List<Casilla> GetCasillaBandejaTotal_Detalle(Interna.Entity.Casilla oC)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaBandejaTotal_Detalle(oC);
        }


        [WebMethod]
        public List<Casilla> GetCasillaBandejaFacTotal_Detalle()
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaBandejaUsuFacTotal_Detalle();
        }

        [WebMethod]
        public List<Casilla> getPlantillaGeo()
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rPlantillaGeo();
        }

        /*Cesar 21/02/2014*/
        [WebMethod]
        public List<Casilla> getCasillaTipo(int IdTipoCasilla)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rCasillaTipo(IdTipoCasilla);
        }

        [WebMethod]
        public List<Casilla> GetConsultaBandejaTotal_PAG(Interna.Entity.Casilla oC)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaBandejaTotal_PAG(oC);
        }

        [WebMethod]
        public List<Casilla> GetConsultaBandejaActiva()
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaBandejaActiva();
        }

        [WebMethod]
        public int GetConsultaBandejaTotalCONTAR(Interna.Entity.Casilla oC)
        {
            Casilla oCasilla = new Casilla();

            return oCasilla.GetConsultaBandejaTotalCONTAR(oC);
        }

        [WebMethod]
        public int VincularCasilla(int IdCasilla, int IdUsuario)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.uVincularCasilla(IdCasilla, IdUsuario);
        }

        [WebMethod]
        public List<Casilla> CasillaUsuario(int IdUsuario)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.CasillaUsuario(IdUsuario);
        }

        [WebMethod]
        public List<Casilla> CasillaActiva()
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.CasillaActiva();
        }


        public String ConvertDataTableTojSonString(DataTable dataTable)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer =
                   new System.Web.Script.Serialization.JavaScriptSerializer();

            List<Dictionary<String, Object>> tableRows = new List<Dictionary<String, Object>>();

            Dictionary<String, Object> row;

            foreach (DataRow dr in dataTable.Rows)
            {
                row = new Dictionary<String, Object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                tableRows.Add(row);
            }
            return serializer.Serialize(tableRows);
        }

        public class HelloWorldData
        {
            public String Message;
        }

        [WebMethod]
        public int VerificarEstadoCasilla(Interna.Entity.Usuario oC)
        {
            return oC.VerificarEstadoCasilla();
        }
        //2022
        [WebMethod]
        public string rDescripcion(string palabra)
        {
            Casilla cs = new Casilla();
            return cs.rObtenerDescripcion(palabra);
        }
        // Funcional - frmConsultaBandeja
        [WebMethod]
        public List<String> GetConsultaBandejaTotal_PAGJson(Interna.Entity.Casilla oC)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaBandejaTotal_PAGJson(oC);
        }
        // Funcional - frmConsultaBandeja
        [WebMethod]
        public string GetCasillaListaPorGeo2Json(int IdGeo2)
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.rConsultaPorGeoJson(0, IdGeo2);
        }
        //2022
        [WebMethod]
        public string BandejaUsuarioExpedicion(int iExpedicion)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Casilla ca = new Casilla();
            return ca.BandejaUsuarioExpedicion(accessToken.GetUpn(), iExpedicion);
        }
        //2022
        [WebMethod]
        public string ListarBandejaExpedicion(int iExpedicion)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_COLABORADOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Casilla ca = new Casilla();
            return ca.ListarBandejaExpedicion(iExpedicion);
        }
        //2022
        [WebMethod]
        public string ListarBandeja()
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "";
            }

            Casilla ca = new Casilla();
            return ca.ListarBandeja();
        }

        //2022
        [WebMethod]
        public int CrearBandeja(int iIdGeo, string sDescripcionBandeja)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            Casilla oCasilla = new Casilla()
            {
                IdGeo = iIdGeo,
                sDescripcion = sDescripcionBandeja
            };
            return oCasilla.CrearBandeja();
        }

        //2022
        [WebMethod]
        public int ModificarBandeja(int idBandeja, int idGeo, string sDescripcionBandeja)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return -1;
            }

            Casilla oCasilla = new Casilla()
            {
                ID = idBandeja,
                IdGeo = idGeo,
                sDescripcion = sDescripcionBandeja
            };
            return oCasilla.ModificarBandeja();
        }

        /*César - 03/10/2016*/
        [WebMethod]
        public String ListarBandejaNoAsociada(int iUsuario)
        {
            Casilla ca = new Casilla();
            return ca.ListarBandejaNoAsociada(iUsuario);
        }

        /*César - 25/11/2016*/
        [WebMethod]
        public string ListarBandejaTipoDocumento()
        {
            Casilla oCasilla = new Casilla();
            return oCasilla.ListarBandejaTipoDocumento();
        }

        /*César - 12/01/2017*/
        [WebMethod]
        public int CambiarEstadoBandeja(int ID, bool estado)
        {
            int iestado = 0;
            if (estado) iestado = 1;

            Casilla oCasilla = new Casilla()
            {
                ID = ID,
                iActivo = iestado
            };
            return oCasilla.CambiarEstadoBandeja();
        }

        [WebMethod]
        public string ListarCasillasPorAsociarAlTipoDocumento(string sDescripcion)
        {
            Casilla oCasilla = new Casilla()
            {
                sDescripcion = sDescripcion
            };
            return oCasilla.ListarCasillasPorAsociarAlTipoDocumento();
        }

        [WebMethod]
        public string ListarBandejasPorGeo(int IdGeo)
        {
            Casilla casilla = new Casilla();
            return casilla.ListarBandejasPorGeo(IdGeo);
        }

    }
}