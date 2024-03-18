using Interna.Entity;
using Newtonsoft.Json;
using simihWS.Helper;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class GeoWS : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Geo> ListarUbicaciones(int IdCliente)
        {
            Geo oGeo = new Geo();
            return oGeo.rListarUbicaciones(IdCliente);
        }

        [WebMethod]
        public List<Geo> ListarOficinas(int IdCliente, int IdGeo, int idExpedicion)
        {
            Geo oGeo = new Geo();
            return oGeo.rListarOficinas(IdCliente, IdGeo, idExpedicion);
        }

        [WebMethod]
        public int CrearCalle(int IdCliente, string Calle, int IdDistrito)
        {
            Geo oGeo = new Geo();
            return oGeo.sCrearCalle(IdCliente, Calle, IdDistrito);
        }

        [WebMethod]
        public List<Geo> GrabarCalle(int IdCliente, int IdGeo, string Calle)
        {
            Geo oGeo = new Geo();
            return oGeo.sGrabarCalle(IdCliente, IdGeo, Calle);
        }
        //2022
        [WebMethod]
        public int EliminarCalle(int IdCliente, int IdCalle)
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

            Geo oGeo = new Geo();
            return oGeo.EliminarCalle(IdCliente, IdCalle);
        }

        [WebMethod]
        public List<Geo> GrabarOficinas(int IdCliente, int IdGeo, int IdExpedicion, string Oficina, string Area)
        {
            Geo oGeo = new Geo();
            return oGeo.sGrabarOficina(IdCliente, IdGeo, IdExpedicion, Oficina, Area);
        }
        //2022
        [WebMethod]
        public string CrearPuntoEntrega(int IdCliente, int IdGeo, int IdExpedicion, string Oficina, string Area, string Agencia)
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

            Geo oGeo = new Geo();
            return oGeo.CrearPuntoEntrega(IdCliente, IdGeo, IdExpedicion, Oficina, Area, Agencia);
        }

        [WebMethod]
        public int EliminarOficina(int IdCliente, int IdOficina)
        {
            Geo oGeo = new Geo();
            return oGeo.sEliminarOficina(IdCliente, IdOficina);
        }


        [WebMethod]
        public List<Geo> SetGeoFac(int idCliente, int idUsuario)
        {
            Fac oF = new Fac();
            return oF.rVerGeoFac(idCliente, idUsuario);
        }
        [WebMethod]
        public int getGeoPadre(int geo)
        {
            Geo g = new Geo();
            return g.rGeo(geo).IDPadre;
        }

        //Control courier
        //Coordinacion
        [WebMethod]
        public List<Geo> listarUbicacion(int id)
        {
            Geo oGeo = new Geo();
            return oGeo.rListarUbicacion(id);
        }
        /*
         CESAR 12/03/2014
         * EXI_U_GEO_EXPEDICION_DOMINIO
         */
        [WebMethod]
        public Expedicion setGeoExpedicionDominio(Geo oG)
        {
            Expedicion oE = oG.uGeoExpedicionDominio();
            return oE;
        }
        // Funcional - frmConsultaBandeja
        [WebMethod]
        public string getDatosOficina(int IdGeo)
        {
            Geo oU = new Geo();
            return oU.rObtenerDatosOficina(IdGeo);
        }

        [WebMethod]
        public List<Geo> rGeoLista(Geo oG, int RecordIndex, int Width)
        {
            Geo oGeo = new Geo();
            return oGeo.rGeoLista(oG, RecordIndex, Width);
        }

        [WebMethod]
        public int rGeoListaContar(Geo oG)
        {
            Geo G = new Geo();
            return G.rGeoListaContar(oG);
        }

        [WebMethod]
        public string ActualizarOficinas(int IdCliente, int IdGeo, int IdOficina, string Oficina, string Area)
        {
            Geo oGeo = new Geo();
            return JsonConvert.SerializeObject(oGeo.sActualizarOficina(IdCliente, IdGeo, IdOficina, Oficina, Area));
        }

        [WebMethod]
        public int CrearDistrito(int IdCliente, string sGeo, int IdGeoPadre, int Nivel)
        {
            Geo oGeo = new Geo();
            return oGeo.sCrearDistrito(IdCliente, sGeo, IdGeoPadre, Nivel);
        }

        [WebMethod]
        public List<Geo> GrabarDistrito(int IdCliente, int IdGeo, string sGeo)
        {
            Geo oGeo = new Geo();
            return oGeo.sGrabarDistrito(IdCliente, IdGeo, sGeo);
        }

        //2022
        [WebMethod]
        public string ListarUbicacionGeo(int IdCliente)
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

            Geo oGeo = new Geo();
            return oGeo.ListarUbicacionGeo(IdCliente);
        }
        //2022
        [WebMethod]
        public string ListarPuntosEntrega(int IDCliente, int ID, int IdExpedicionDominio)
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

            Geo oGeo = new Geo()
            {
                IDCliente = IDCliente,
                ID = ID,
                IdExpedicionDominio = IdExpedicionDominio
            };
            return oGeo.ListarPuntosEntrega(oGeo);
        }

        //Cesar 09/03/2016
        [WebMethod]
        public String cNuevaArea(int IdCliente, int IdGeo, int IdExpedicion, string Oficina, string Area, string sCodigoAgencia, string sAgencia, int iTipo)
        {
            Geo og = new Geo();
            return og.cNuevaArea(IdCliente, IdGeo, IdExpedicion, Oficina, Area, sCodigoAgencia, sAgencia, iTipo);
        }
        //Cesar 09/03/2016
        [WebMethod]
        public String uModificarArea(int IdCliente, int IdGeo, int IdExpedicion, string Oficina, string Area, string sCodigoAgencia, string sAgencia, int iTipo)
        {
            Geo oGeo = new Geo();
            return oGeo.uModificarArea(IdCliente, IdGeo, IdExpedicion, Oficina, Area, sCodigoAgencia, sAgencia, iTipo);
        }
        /*César 31/08/2016*/
        [WebMethod]
        public String ListarPuntoEntregaExpedicion()
        {
            Geo oGeo = new Geo();
            return oGeo.ListarPuntoEntregaExpedicion();
        }
        /*César 09/09/2016*/
        [WebMethod]
        public String ListarPuntoEntregaAgencia()
        {
            Geo oGeo = new Geo();
            return oGeo.ListarPuntoEntregaAgencia();
        }

        //2022
        [WebMethod]
        public string ModificarPuntoEntrega(int IdCliente, int IdGeo, int IdGeoPadre, string Oficina, string Area, string Agencia)
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

            Geo oGeo = new Geo();
            return oGeo.ModificarPuntoEntrega(IdCliente, IdGeo, IdGeoPadre, Oficina, Area, Agencia);
        }

        //2022
        [WebMethod]
        public int EliminarPuntoEntrega(int iIdGeo)
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

            Geo oGeo = new Geo();
            return oGeo.EliminarPuntoEntrega(iIdGeo);
        }

        //2022
        [WebMethod]
        public int ActualizarGeo(int ID, string Descripcion)
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

            Geo geo = new Geo()
            {
                ID = ID,
                Descripcion = Descripcion
            };
            return geo.ActualizarGeo();
        }

        //2022
        [WebMethod]
        public int CrearGeo(int ID)
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

            Geo geo = new Geo()
            {
                ID = ID
            };
            return geo.CrearGeo();
        }

        //2022
        [WebMethod]
        public string ListarDepartamento()
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
            Geo oGeo = new Geo();
            return oGeo.ListarDepartamento();
        }
        //2022
        [WebMethod]
        public string ListarProvincia(int IdDepartamento)
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
            Geo oGeo = new Geo();
            return oGeo.ListarProvincia(IdDepartamento);
        }
        //2022
        [WebMethod]
        public string ListarDistrito(int IdProvincia)
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
            Geo oGeo = new Geo();
            return oGeo.ListarDistrito(IdProvincia);
        }
        //2022
        [WebMethod]
        public string ListarCalle(int IdDistrito)
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
            Geo oGeo = new Geo();
            return oGeo.ListarCalle(IdDistrito);
        }
        //2022
        [WebMethod]
        public string ListarOficina(int IdCalle)
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
            Geo oGeo = new Geo();
            return oGeo.ListarOficina(IdCalle);
        }

        //2023
        [WebMethod]
        public int CrearBandejaFisica(string nombre, int idExpedicion)
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

            Geo geo = new Geo();
            return geo.CrearBandejaFisica(nombre, idExpedicion);
        }

        //2023
        [WebMethod]
        public string ListarBandejaFisica(int idExpedicion)
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
            Geo geo = new Geo();
            return geo.ListarBandejaFisica(idExpedicion);
        }


        //2023
        [WebMethod]
        public string ListarUbicacionesExpedicion(int idExpedicion)
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
            Geo geo = new Geo();
            return geo.ListarUbicacionesExpedicion(idExpedicion);
        }

        //2023
        [WebMethod]
        public int AsociarUbicacionABandejaFisica(int idUbicacion, int idBandejaFisica)
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

            Geo geo = new Geo();
            return geo.AsociarUbicacionABandejaFisica(idUbicacion, idBandejaFisica);
        }

        //2023
        [WebMethod]
        public int DesasociarUbicacionDeBandejaFisica(int idUbicacion, int idBandejaFisica)
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

            Geo geo = new Geo();
            return geo.DesasociarUbicacionDeBandejaFisica(idUbicacion, idBandejaFisica);
        }
    }
}