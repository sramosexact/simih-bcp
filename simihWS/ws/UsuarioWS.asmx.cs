using Interna.Entity;
using Newtonsoft.Json;
using simihWS.Helper;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de UsuarioWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class UsuarioWS : System.Web.Services.WebService
    {

        //Funcional
        [WebMethod]
        public List<Interna.Entity.Usuario> GetUsuario()
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.rListadoTipo();
        }

        //2022
        [WebMethod]
        public string GetCliente(String id)
        {
            Usuario oU = new Usuario();
            return oU.ListarCliente(id);
        }

        [WebMethod]
        public string Usuarios(String id, int PageRecordIndex, int PageWidth)
        {
            Usuario oUsuario = new Usuario();
            return oUsuario.Usuarios(id, PageRecordIndex, PageWidth);
        }

        [WebMethod]
        public int UsuariosCONTAR(String id)
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.UsuariosCONTAR(id);
        }


        [WebMethod]
        public string GetUsuario_Casillas(int id)
        {
            Usuario oUsuario = new Usuario();
            return oUsuario.rListadoUsuario_Casilla(id);
        }


        [WebMethod]
        public int SetUsuario(string Aplicacion, string Cliente, string sUsuario, string Password, string Correo,
            int SoportaCasilla, int IdTipoAcceso, int IdExpedicion, string Codigo, int Modo, int IdEquipo, int iCesado)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.Aplicacion = Aplicacion;
            oUsuario.Cliente = Cliente;
            oUsuario.Usu = sUsuario;
            oUsuario.Password = Password;
            oUsuario.Correo = Correo;
            oUsuario.SoportaCasilla = SoportaCasilla;
            oUsuario.IdTipoAcceso = IdTipoAcceso;
            oUsuario.IdExpedicion = IdExpedicion;
            oUsuario.sCodigo = Codigo;
            oUsuario.Modo = Modo;
            oUsuario.idEquipo = IdEquipo;
            oUsuario.iCesado = iCesado;
            return oUsuario.c_Usuario();
        }

        [WebMethod]
        public Usuario GetObtener_Usuario(int id)
        {
            Usuario oUsuario = new Usuario();
            return oUsuario.rObtenerUsuario(id);
        }

        [WebMethod]
        public int SetUsuario_UPDATE(int IdUsuario, string Codigo, string sUsuario, int Modo,
            int SoportaCasilla, string Correo, string Password, int iActivo, int IdExpedicion, int IdEquipo, int iCesado)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.ID = IdUsuario;
            oUsuario.Codigo = Codigo;
            oUsuario.Usu = sUsuario;
            oUsuario.Modo = Modo;
            oUsuario.SoportaCasilla = SoportaCasilla;
            oUsuario.Correo = Correo;
            oUsuario.Password = Password;
            oUsuario.iActivo = iActivo;
            oUsuario.IdExpedicion = IdExpedicion;
            oUsuario.idEquipo = IdEquipo;
            oUsuario.iCesado = iCesado;
            return oUsuario.u_Usuario();
        }

        [WebMethod]
        public int SetUsuario_DELETE(Interna.Entity.Usuario oU)
        {
            return oU.d_Usuario();
        }


        [WebMethod]
        public int SetCasilla_INSERT(int IdUsuario, int IdCasilla, string Casilla, int IdGeo, string Alias)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.ID = IdUsuario;
            oUsuario.idCasilla = IdCasilla;
            oUsuario.Cas = Casilla;
            oUsuario.idGeo = IdGeo;
            oUsuario.alias = Alias;
            return oUsuario.c_Casilla();
        }


        [WebMethod]
        public int SetCasilla_Desvinculacion(int IdUsuario, int IdCasilla)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.ID = IdUsuario;
            oUsuario.idCasilla = IdCasilla;
            return oUsuario.u_Casilla_Desvinculacion();
        }

        [WebMethod]
        public int SetCasilla_UPDATE(int IdCasilla, string Alias, string Descripcion, int opcion, int idoficina)
        {
            Usuario oUsuario = new Usuario();

            oUsuario.idCasilla = IdCasilla;
            oUsuario.alias = Alias;
            oUsuario.Descripcion = Descripcion;
            return oUsuario.u_Casilla(opcion, idoficina);
        }


        [WebMethod]
        public List<Interna.Entity.Usuario> rObtenerCasillas(int idCliente, String texto, int idUS)
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.rObtenerCasillas(idCliente, texto, idUS);
        }

        [WebMethod]
        public List<Interna.Entity.Usuario> rObtenerCasillas2(int idCliente, String texto)
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.rObtenerCasillas2(idCliente, texto);
        }


        [WebMethod]
        public int SetCasilla_DELETE(int IdCasilla, int IdUsuario)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.idCasilla = IdCasilla;
            oUsuario.ID = IdUsuario;
            return oUsuario.d_Casilla();
        }


        [WebMethod]
        public int SetUsuarioFacAsignacion(int IdUsuario, int IdGeo)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.ID = IdUsuario;
            oUsuario.idGeo = IdGeo;
            return oUsuario.u_Usuario_Fac();
        }

        [WebMethod]
        public int SetUsuarioFacDesvincular(int IdUsuario, int IdGeo)
        {
            Usuario oUsuario = new Usuario();
            oUsuario.ID = IdUsuario;
            oUsuario.idGeo = IdGeo;
            return oUsuario.d_Usuario_Fac(oUsuario);
        }

        [WebMethod]
        public List<Interna.Entity.Usuario> GetBandejaUsuFac(int id)
        {
            Interna.Entity.Fac oU = new Interna.Entity.Fac();
            return oU.rVerBandejasUsuFac(id);
        }

        [WebMethod]
        public List<Interna.Entity.Usuario> GetUsuarioFacTotal()
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.rListarUsuarioFac();
        }
        [WebMethod]
        public List<Interna.Entity.Usuario> GetCasillaBandejaFacTotal_Detalle()
        {
            Interna.Entity.Usuario oCasilla = new Interna.Entity.Usuario();
            return oCasilla.rConsultaBandejaUsuFacTotal_Detalle2();
        }

        [WebMethod]
        public List<Interna.Entity.Usuario> GetConsulta_FAC_TOTAL(Interna.Entity.Usuario oP)
        {
            Interna.Entity.Usuario oUsuario = new Interna.Entity.Usuario();
            return oUsuario.r_Consulta_FAC_TOTAL(oP);
        }

        [WebMethod]
        public int GetConsulta_FAC_TOTALCONTAR()
        {
            Interna.Entity.Usuario oUsuario = new Interna.Entity.Usuario();

            return oUsuario.GetConsulta_FAC_TOTALCONTAR();
        }


        [WebMethod]
        public List<Interna.Entity.Usuario> GetConsultaUsuarioDato(String Dato)
        {
            Interna.Entity.Usuario oUsuario = new Interna.Entity.Usuario();
            return oUsuario.rObtenerUsuarioDato(Dato);
        }

        //introducido 27/08/2015

        [WebMethod]
        public String UsuariosJson(String id)
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.UsuariosJson(id);
        }

        [WebMethod]
        public String GetUsuario_CasillasJson(int id)
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.rListadoUsuario_CasillaJson(id);
        }

        [WebMethod]
        public String GetBandejaUsuFacJson(int id)
        {
            Interna.Entity.Fac oU = new Interna.Entity.Fac();
            return oU.rVerBandejasUsuFacJson(id);
        }

        [WebMethod]
        public String rListaOperativos(int idExpedicion)
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.rListaOperativos(idExpedicion);
        }

        [WebMethod]
        public String rValidarSup(int idExpedicion, String dato)
        {
            Interna.Entity.Usuario oU = new Interna.Entity.Usuario();
            return oU.rValidarSup(idExpedicion, dato);
        }
        //2022
        [WebMethod]
        public string GetConsultaUsuarioDatoJs(String Dato, int idExpedicion)
        {
            Usuario oUsuario = new Usuario();
            return JsonConvert.SerializeObject(oUsuario.rObtenerUsuarioDato1(Dato, idExpedicion));
        }

        /*César - 20/09/2016*/
        [WebMethod]
        public String ListarUsuarios()
        {
            Usuario oUsuario = new Usuario();
            return oUsuario.ListarUsuarios();
        }

        /*César - 21/09/2016*/
        [WebMethod]
        public String ListarTipoUsuario()
        {
            Usuario oUsuario = new Usuario();
            return oUsuario.ListarTipoUsuario();
        }

        //2022
        [WebMethod]
        public int CrearUsuario(string Descripcion, string sMatricula, string sDominio, string Codigo,
            int Modo, string Password, int IdTipoAcceso, int IdExpedicion, int idCasilla, int idGeo, string sDni)
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

            Usuario oUsuario = new Usuario()
            {
                Descripcion = Descripcion,
                sMatricula = sMatricula,
                sDominio = sDominio,
                Codigo = Codigo,
                Modo = Modo,
                Password = Password,
                IdTipoAcceso = IdTipoAcceso,
                IdExpedicion = IdExpedicion,
                idCasilla = idCasilla,
                idGeo = idGeo,
                sDni = sDni
            };

            return oUsuario.CrearUsuario();
        }

        //2022
        [WebMethod]
        public int ModificarUsuario(int ID, string Descripcion, string sMatricula,
            int Modo, string Password, int idGeoCasilla, int IdTipoAcceso, int IdExpedicion, int idCasilla, string sDni)
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

            Usuario oUsuario = new Usuario()
            {
                ID = ID,
                Descripcion = Descripcion,
                sMatricula = sMatricula,
                Modo = Modo,
                Password = Password,
                idGeoCasilla = idGeoCasilla,
                IdTipoAcceso = IdTipoAcceso,
                IdExpedicion = IdExpedicion,
                idCasilla = idCasilla,
                sDni = sDni
            };

            return oUsuario.ModificarUsuario();
        }

        //2022
        [WebMethod]
        public string ListarUsuarioBandejaAsociado(int idCasilla)
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

            Usuario oUsuario = new Usuario();
            oUsuario.idCasilla = idCasilla;
            return oUsuario.ListarUsuarioBandejaAsociado();
        }

        //2022
        [WebMethod]
        public string ListarUsuarioBandejaNoAsociado(int idCasilla, string Descripcion)
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

            Usuario usuario = new Usuario()
            {
                idCasilla = idCasilla,
                Descripcion = Descripcion
            };
            return usuario.ListarUsuarioBandejaNoAsociado();
        }

        //2022
        [WebMethod]
        public string ListarColaboradoresExpedicion(int iExpedicion)
        {
            Usuario oU = new Usuario();
            return oU.ListarColaboradoresExpedicion(iExpedicion);
        }
        //2022
        [WebMethod]
        public List<string> ListarBandejaAsociada(int idUsuario)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return new List<string>();
            }

            Usuario oUsuario = new Usuario();
            return oUsuario.ListarBandejaAsociada(idUsuario);
        }
        //2022
        [WebMethod]
        public int DarDeBajaUsuario(int IdUsuario)
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

            Usuario usuario = new Usuario();
            return usuario.DarDeBajaUsuario(IdUsuario);
        }

        //2022
        [WebMethod]
        public int DarDeAltaUsuario(int IdUsuario)
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

            Usuario usuario = new Usuario();
            return usuario.DarDeAltaUsuario(IdUsuario);
        }

        //2022
        [WebMethod]
        public int VincularUsuarioBandeja(int ID, int idCasilla)
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

            Usuario usuario = new Usuario()
            {
                ID = ID,
                idCasilla = idCasilla
            };

            return usuario.VincularUsuarioBandeja();
        }

        //2022
        [WebMethod]
        public int DesvincularUsuarioBandeja(int idCasilla, int ID)
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

            Usuario usuario = new Usuario()
            {
                idCasilla = idCasilla,
                ID = ID
            };

            return usuario.DesvincularUsuarioBandeja();
        }

        //2022
        [WebMethod]
        public string ListarBandejasAsociadasAlUsuario(int ID)
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

            Usuario usuario = new Usuario()
            {
                ID = ID
            };
            return usuario.ListarBandejasAsociadasAlUsuario();
        }

        //2022
        [WebMethod]
        public string ListarBandejasNoAsociadasAlUsuario(int ID, string descripcionCasilla)
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

            Usuario usuario = new Usuario()
            {
                ID = ID,
                descripcionCasilla = descripcionCasilla
            };
            return usuario.ListarBandejasNoAsociadasAlUsuario();
        }

        //2022
        [WebMethod]
        public string ListarAgenciasVinculadasAlUsuario(int ID)
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

            Usuario usuario = new Usuario()
            {
                ID = ID
            };
            return usuario.ListarAgenciasVinculadasAlUsuario();
        }

        //2022
        [WebMethod]
        public string ListarAgenciasNoVinculadasAlUsuario(int ID, string descripcionAgencia)
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

            Usuario usuario = new Usuario()
            {
                ID = ID,
                Descripcion = descripcionAgencia
            };

            return usuario.ListarAgenciasNoVinculadasAlUsuario();
        }

        //2022
        [WebMethod]
        public int VincularEncargadoAgencia(int iIdUsuario, int iIdAgencia)
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

            EncargadoAgencia encargadoAgencia = new EncargadoAgencia()
            {
                iIdUsuario = iIdUsuario,
                iIdAgencia = iIdAgencia
            };
            Usuario usuario = new Usuario();
            return usuario.VincularEncargadoAgencia(encargadoAgencia);
        }

        //2022
        [WebMethod]
        public int DesvincularEncargadoAgencia(short iIdEncargadoAgencia)
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

            EncargadoAgencia encargadoAgencia = new EncargadoAgencia()
            {
                iIdEncargadoAgencia = iIdEncargadoAgencia
            };

            Usuario usuario = new Usuario();
            return usuario.DesvincularEncargadoAgencia(encargadoAgencia);
        }
        //2022
        [WebMethod]
        public int VerificarSiUsuarioEsDeAgencia(int IdUsuario)
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
            Usuario usuario = new Usuario();
            return usuario.VerificarSiUsuarioEsDeAgencia(IdUsuario);
        }
        //2022
        [WebMethod]
        public string UsuarioSeleccionado(int IdUsuario)
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
            Usuario oUsuario = new Usuario();
            return oUsuario.UsuarioSeleccionado(IdUsuario);
        }

        [WebMethod]
        public string ListarUsuariosPorNombreOMatricula(string sValor, int iIdExpedicion)
        {
            Usuario usuario = new Usuario();
            return usuario.ListarUsuariosPorNombreOMatricula(sValor, iIdExpedicion);
        }

        //2022
        [WebMethod]
        public string BuscarUsuarios(string usuario)
        {
            AccessToken accessToken = new AccessToken(HttpContext.Current);
            List<TipoUsuarioEnum> tipoUsuarios = new List<TipoUsuarioEnum>();
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_JEFE);
            tipoUsuarios.Add(TipoUsuarioEnum.SIMIH_SUPERVISOR);

            if (!Helper.Helper.ValidarTipoUsuario(accessToken.GetUpn(), tipoUsuarios))
            {
                HttpContext.Current.Response.StatusCode = 401;
                HttpContext.Current.Response.Headers.Add("Unauthorized", "Basic realm=\"Acceso al sistema SIMIH\", charset=\"UTF-8\"");
                return "-1";
            }

            string upn = accessToken.GetUpn();
            Usuario oU = new Usuario();
            return oU.BuscarUsuarios(usuario.Trim().ToUpper());
        }

        [WebMethod]
        public int IngestaUsuario(string json)
        {
            UsuarioIngesta usuario = new UsuarioIngesta();
            return usuario.IngestaUsuario(json);
        }

        [WebMethod]
        public string ListarProveedores()
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

            Proveedor proveedor = new Proveedor();
            return proveedor.ListarProveedores();
        }
    }
}
