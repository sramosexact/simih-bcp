using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {



        //2022
        public static List<Usuario> ListarCliente(String id)
        {
            string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "GetCliente", new Dictionary<string, object>(){
                {"id",id}
            });

            return deserializarPrueba<Usuario>(response);

        }

        //2022
        public static List<Usuario> ListarClientes()
        {
            string response = Requester.SimpleTask(RutaWS.PublicWS + "ListarClientes", null);
            return deserializarPrueba<Usuario>(response);
        }

        public static List<Usuario> Usuarios(String id, int PageRecordIndex, int PageWidth)
        {

            string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "Usuarios", new Dictionary<string, object>(){
                {"id",id},
                {"PageRecordIndex",PageRecordIndex},
                {"PageWidth",PageWidth}
            });

            return deserializarPrueba<Usuario>(response);
        }



        public static List<Usuario> ListarUsuario_Casilla(int id)
        {


            string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "GetUsuario_Casillas", new Dictionary<string, object>(){
                {"id",id}
            });

            return deserializarPrueba<Usuario>(response);
        }

        public static int GrabarUsuario(Usuario oUsuario)
        {

            string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "SetUsuario", new Dictionary<string, object>(){
                {"Aplicacion", oUsuario.Aplicacion},
                {"Cliente", oUsuario.Cliente},
                {"sUsuario", oUsuario.Usu},
                {"Password", oUsuario.Correo},
                {"Correo", oUsuario.Correo},
                {"SoportaCasilla", oUsuario.SoportaCasilla},
                {"IdTipoAcceso", oUsuario.IdTipoAcceso},
                {"IdExpedicion", oUsuario.IdExpedicion},
                {"Codigo", oUsuario.sCodigo},
                {"Modo", oUsuario.Modo},
                {"IdEquipo", oUsuario.idEquipo},
                {"iCesado", oUsuario.iCesado}
            });

            return Convert.ToInt32(response);
        }


        public static int VincularUsuarioFac(Usuario oUsuario)
        {
            //ServiceUsuarioWS.UsuarioWS oWSCALL = new ServiceUsuarioWS.UsuarioWS();
            //ServiceUsuarioWS.Usuario oUS = new ServiceUsuarioWS.Usuario();
            //oUsuario.CloneToObject(oUS);            
            //return oWSCALL.SetUsuarioFacAsignacion(oUS);

            string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "SetUsuarioFacAsignacion", new Dictionary<string, object>(){
                {"IdUsuario", oUsuario.ID},
                {"IdGeo", oUsuario.idGeo}
            });

            return Convert.ToInt32(response);
        }


        public static int DesvincularUsuarioFac(Usuario oUsuario)
        {
            //ServiceUsuarioWS.UsuarioWS oWSCALL = new ServiceUsuarioWS.UsuarioWS();
            //ServiceUsuarioWS.Usuario oUS = new ServiceUsuarioWS.Usuario();
            //oUsuario.CloneToObject(oUS);
            //return oWSCALL.SetUsuarioFacDesvincular(oUS);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "SetUsuarioFacDesvincular", new Dictionary<string, object>(){
                    { "IdUsuario", oUsuario.ID},
                    { "IdGeo", oUsuario.idGeo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int ActualizarUsuario(Usuario oUsuario)
        {
            //ServiceUsuarioWS.UsuarioWS oWSCALL = new ServiceUsuarioWS.UsuarioWS();
            //ServiceUsuarioWS.Usuario oUS = new ServiceUsuarioWS.Usuario();
            //oUsuario.CloneToObject(oUS);
            //return oWSCALL.SetUsuario_UPDATE(oUS);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "SetUsuario_UPDATE", new Dictionary<string, object>(){
                    { "IdUsuario", oUsuario.ID},
                    { "Codigo", oUsuario.Codigo},
                    { "sUsuario", oUsuario.Usu},
                    { "Modo", oUsuario.Modo},
                    { "SoportaCasilla", oUsuario.SoportaCasilla},
                    { "Correo", oUsuario.Correo},
                    { "Password", oUsuario.Password},
                    { "iActivo", oUsuario.iActivo},
                    { "IdExpedicion", oUsuario.IdExpedicion},
                    { "IdEquipo", oUsuario.idEquipo},
                    { "iCesado", oUsuario.iCesado}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int ActualizarCasilla(Usuario oUsuario, int opcion, int idOficina)
        {
            //ServiceUsuarioWS.UsuarioWS oWSCALL = new ServiceUsuarioWS.UsuarioWS();
            //ServiceUsuarioWS.Usuario oUS = new ServiceUsuarioWS.Usuario();
            //oUsuario.CloneToObject(oUS);
            //return oWSCALL.SetCasilla_UPDATE(oUS, opcion, idOficina);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "SetCasilla_UPDATE", new Dictionary<string, object>(){
                    { "IdCasilla", oUsuario.idCasilla},
                    { "Alias", oUsuario.alias},
                    { "Descripcion", oUsuario.Descripcion},
                    { "opcion", opcion},
                    { "idoficina", idOficina}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int EliminarCasilla(Usuario oUsuario)
        {
            //ServiceUsuarioWS.UsuarioWS oWSCALL = new ServiceUsuarioWS.UsuarioWS();
            //ServiceUsuarioWS.Usuario oUS = new ServiceUsuarioWS.Usuario();
            //oUsuario.CloneToObject(oUS);
            //return oWSCALL.SetCasilla_DELETE(oUS);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "SetCasilla_DELETE", new Dictionary<string, object>(){
                    { "IdCasilla", oUsuario.idCasilla},
                    { "IdUsuario", oUsuario.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static Usuario ObtenerUsuario(int id)
        {
            //ServiceUsuarioWS.UsuarioWS oUCALL = new ServiceUsuarioWS.UsuarioWS();
            //ServiceUsuarioWS.Usuario oArrayU = new ServiceUsuarioWS.Usuario();
            //oArrayU = oUCALL.GetObtener_Usuario(id);
            //Usuario oO = new Usuario();
            //oO.CopyToMe(oArrayU);
            //return oO;

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "GetObtener_Usuario", new Dictionary<string, object>(){
                    { "id", id}
                });

                return deserializarPrueba<Usuario>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }



        public static int GrabarCasilla(Usuario oUsuario)
        {
            //ServiceUsuarioWS.UsuarioWS oWSCALL = new ServiceUsuarioWS.UsuarioWS();
            //ServiceUsuarioWS.Usuario oUS = new ServiceUsuarioWS.Usuario();
            //oUsuario.CloneToObject(oUS);
            //return oWSCALL.SetCasilla_INSERT(oUS);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "SetCasilla_INSERT", new Dictionary<string, object>(){
                    { "IdUsuario", oUsuario.ID},
                    { "IdCasilla", oUsuario.idCasilla},
                    { "Casilla", oUsuario.Cas},
                    { "IdGeo", oUsuario.idGeo},
                    { "Alias", oUsuario.alias}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }






        public static int Desvincular_Casilla_usuario(Usuario oUsuario)
        {
            //ServiceUsuarioWS.UsuarioWS oWSCALL = new ServiceUsuarioWS.UsuarioWS();
            //ServiceUsuarioWS.Usuario oUS = new ServiceUsuarioWS.Usuario();
            //oUsuario.CloneToObject(oUS);
            //return oWSCALL.SetCasilla_Desvinculacion(oUS);

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "SetCasilla_Desvinculacion", new Dictionary<string, object>(){
                    { "IdUsuario", oUsuario.ID},
                    { "IdCasilla", oUsuario.idCasilla}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }













        //introducido 27/08/2015

        public static List<Usuario> UsuariosJson(String id)
        {
            //ServiceUsuarioWS.UsuarioWS oUCALL = new ServiceUsuarioWS.UsuarioWS();
            //return Metodos.deserializarPrueba<Usuario>(oUCALL.UsuariosJson(id));

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "UsuariosJson", new Dictionary<string, object>(){
                    { "id", id}
                });

                return Metodos.deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        public static List<Usuario> ListarUsuario_CasillaJson(int id)
        {
            //ServiceUsuarioWS.UsuarioWS oUCALL = new ServiceUsuarioWS.UsuarioWS();
            //return Metodos.deserializarPrueba<Usuario>(oUCALL.GetUsuario_CasillasJson(id));

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "GetUsuario_CasillasJson", new Dictionary<string, object>(){
                    { "id", id}
                });

                return Metodos.deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<Usuario> ListarPuntodeEntregaJson(int id)
        {
            //ServiceUsuarioWS.UsuarioWS oCCALL = new ServiceUsuarioWS.UsuarioWS();
            //return Metodos.deserializarPrueba<Usuario>(oCCALL.GetBandejaUsuFacJson(id));
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "GetBandejaUsuFacJson", new Dictionary<string, object>(){
                    { "id", id}
                });

                return Metodos.deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static List<Usuario> ListarUsuarioDato1(String Dato, int idExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "GetConsultaUsuarioDatoJs", new Dictionary<string, object>(){
                    {"Dato", Dato},
                    {"idExpedicion", idExpedicion}
                });

                Usuario[] oArrayU = deserializarPrueba<Usuario>(response).ToArray<Usuario>();
                List<Usuario> oUsuario = new List<Usuario>();
                foreach (Usuario oUs in oArrayU)
                {
                    Usuario oU = new Usuario();
                    oU.CopyToMe(oUs);
                    oUsuario.Add(oU);
                }
                return oUsuario;
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }

        /*César - 20/09/2016*/
        public static List<Usuario> ListarUsuarios()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarUsuarios", null);
                return deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<Usuario> ListarTipoUsuario()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarTipoUsuario", null);

                return deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int CrearUsuario(Usuario oUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "CrearUsuario", new Dictionary<string, object>(){
                    { "Descripcion", oUsuario.Descripcion},
                    { "sMatricula", oUsuario.sMatricula},
                    { "sDominio", oUsuario.sDominio},
                    { "Codigo", oUsuario.Codigo},
                    { "Modo", oUsuario.Modo},
                    { "Password", oUsuario.Password},
                    { "IdTipoAcceso", oUsuario.IdTipoAcceso},
                    { "IdExpedicion", oUsuario.IdExpedicion},
                    { "idCasilla", oUsuario.idCasilla},
                    { "idGeo", oUsuario.idGeo},
                    { "sDni", oUsuario.sDni}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }


        }

        //2022
        public static int ModificarUsuario(Usuario oUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ModificarUsuario", new Dictionary<string, object>(){
                    { "ID", oUsuario.ID},
                    { "Descripcion", oUsuario.Descripcion},
                    { "sMatricula", oUsuario.sMatricula},
                    { "Modo", oUsuario.Modo},
                    { "Password", oUsuario.Password},
                    { "idGeoCasilla", oUsuario.idGeoCasilla},
                    { "IdTipoAcceso", oUsuario.IdTipoAcceso},
                    { "IdExpedicion", oUsuario.IdExpedicion},
                    { "idCasilla", oUsuario.idCasilla},
                    { "sDni", oUsuario.sDni}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static List<Usuario> ListarUsuarioBandejaAsociado(Usuario oUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarUsuarioBandejaAsociado", new Dictionary<string, object>(){

                    { "idCasilla", oUsuario.idCasilla}
                });

                return deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Usuario> ListarUsuarioBandejaNoAsociado(Usuario oUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarUsuarioBandejaNoAsociado", new Dictionary<string, object>(){
                    {"idCasilla", oUsuario.idCasilla},
                    { "Descripcion", oUsuario.Descripcion}
                });

                return deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static List<String> ListarBandejaAsociada(int idUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarBandejaAsociada", new Dictionary<string, object>(){
                    {"idUsuario", idUsuario}
                });

                List<string> listaJson = new List<string>();
                listaJson = deserializarPrueba<String>(response);
                return listaJson;
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Usuario> ListarColaboradoresExpedicion()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarColaboradoresExpedicion", new Dictionary<string, object>(){
                    {"iExpedicion", Program.oUsuario.IdExpedicion}
                });

                return deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int DarDeBajaUsuario(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "DarDeBajaUsuario", new Dictionary<string, object>(){
                    {"IdUsuario", usuario.ID}
                });
                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int DarDeAltaUsuario(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "DarDeAltaUsuario", new Dictionary<string, object>(){
                    {"IdUsuario", usuario.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int VincularUsuarioBandeja(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "VincularUsuarioBandeja", new Dictionary<string, object>(){
                    {"ID", usuario.ID},
                    { "idCasilla", usuario.idCasilla}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int DesvincularUsuarioBandeja(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "DesvincularUsuarioBandeja", new Dictionary<string, object>(){
                    {"ID", usuario.ID},
                    { "idCasilla", usuario.idCasilla}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Casilla> ListarBandejasAsociadasAlUsuario(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarBandejasAsociadasAlUsuario", new Dictionary<string, object>(){
                    {"ID", usuario.ID}
                });
                return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Casilla> ListarBandejasNoAsociadasAlUsuario(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarBandejasNoAsociadasAlUsuario", new Dictionary<string, object>(){
                    {"ID", usuario.ID},
                    { "descripcionCasilla", usuario.descripcionCasilla}
                });

                return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Agencia> ListarAgenciasVinculadasAlUsuario(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarAgenciasVinculadasAlUsuario", new Dictionary<string, object>(){
                    {"ID", usuario.ID}
                });

                return deserializarPrueba<Agencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Agencia> ListarAgenciasNoVinculadasAlUsuario(Usuario usuario, string agencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarAgenciasNoVinculadasAlUsuario", new Dictionary<string, object>(){
                    {"ID", usuario.ID},
                    { "descripcionAgencia", agencia}
                });

                return deserializarPrueba<Agencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static int VincularEncargadoAgencia(EncargadoAgencia encargadoAencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "VincularEncargadoAgencia", new Dictionary<string, object>(){
                    {"iIdUsuario", encargadoAencia.iIdUsuario},
                    { "iIdAgencia", encargadoAencia.iIdAgencia}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int DesvincularEncargadoAgencia(EncargadoAgencia encargadoAencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "DesvincularEncargadoAgencia", new Dictionary<string, object>(){
                    {"iIdEncargadoAgencia", encargadoAencia.iIdEncargadoAgencia}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int VerificarSiUsuarioEsDeAgencia(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "VerificarSiUsuarioEsDeAgencia", new Dictionary<string, object>(){
                    {"IdUsuario", usuario.ID}
                });
                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Usuario> UsuarioSeleccionado(Usuario oUsuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "UsuarioSeleccionado", new Dictionary<string, object>()
                {
                    {"IdUsuario", oUsuario.ID }
                });
                return deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<Usuario> ListarUsuariosPorNombreOMatricula(string sValor, int iIdExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarUsuariosPorNombreOMatricula", new Dictionary<string, object>()
                {
                    {"sValor", sValor},
                    { "iIdExpedicion", iIdExpedicion}
                });

                return deserializarPrueba<Usuario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Usuario> BuscarUsuarios(string texto)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "BuscarUsuarios", new Dictionary<string, object>(){
                    { "usuario", texto }
                });
                return deserializarPrueba<Usuario>(response); ;
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static string IngestaUsuario(string json)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "IngestaUsuario", new Dictionary<string, object>()
                {
                    { "json", json }
                });

                return response;
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

    }
}
