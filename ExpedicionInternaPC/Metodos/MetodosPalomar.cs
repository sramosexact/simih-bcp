using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        #region PALOMAR


        //2022
        public static List<Palomar> ListaPalomarExpedicionJSON(int IdExpedicion, int iTipoDestino)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "rPalomaresExpedicionJSON", new Dictionary<string, object>(){
                    {"iExpedicion", IdExpedicion},
                    {"iTipoDestino", iTipoDestino}
                });

                return deserializarPrueba<Palomar>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static List<Palomar> rListaPalomarPorGrupoJSON(int idExpedicion, int idGrupo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "rListaPalomarPorGrupoJSON", new Dictionary<string, object>(){
                    {"idExpedicion", idExpedicion},
                    {"idGrupo", idGrupo}
                });

                return deserializarPrueba<Palomar>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Palomar> rListaPalomarGrupoPisosJSON(int idExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "rListaPalomarGrupoPisosJSON", new Dictionary<string, object>(){
                    {"idExpedicion", idExpedicion}
                });

                return deserializarPrueba<Palomar>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static List<Palomar> rObtenerPalomaresEntregaAsociados(int idEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "rObtenerPalomaresEntregaAsociados", new Dictionary<string, object>(){
                    {"idEntrega", idEntrega}
                });

                return deserializarPrueba<Palomar>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int rVerificarAutogeneradoValidadosPorPalomares(string detalle, int idEntrega)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "rVerificarAutogeneradoValidadosPorPalomares", new Dictionary<string, object>(){
                    {"detalle", detalle},
                    {"identrega", idEntrega}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Palomar> ListarPalomaresAgencia()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "ListarPalomaresAgencia", new Dictionary<string, object>(){
                    {"iExpedicion", Program.oUsuario.IdExpedicion}
                });

                return deserializarPrueba<Palomar>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        #endregion

        #region GEO
        //2022
        public static List<Palomar> ListarPalomarExpedicion(int IdCliente, int IdExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "ListarPalomares", new Dictionary<string, object>(){
                    {"iCliente", IdCliente},
                    {"iExpedicion", IdExpedicion}
                });

                return deserializarPrueba<Palomar>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Palomar> ListaPalomares(int IdExpedicion, int IdPalomarPadre)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "ListaPalomarHijo", new Dictionary<string, object>(){
                    {"IdExpedicion", IdExpedicion},
                    {"IdPalomarPadre", IdPalomarPadre}
                });

                return deserializarPrueba<Palomar>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int NuevoPalomarGrupo(int IdExpedicion, int iTipoDestino)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "NuevoPalomarGrupo", new Dictionary<string, object>(){
                    {"IdExpedicion", IdExpedicion},
                    {"iTipoDestino", iTipoDestino}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int NuevoPalomar(int IdPadre)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "NuevoPalomar", new Dictionary<string, object>(){
                    {"IdPadre", IdPadre}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int VincularPalomarPuntoEntrega(int IdPalomar, int IdGeo, int IdExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "VincularPalomarPuntoEntrega", new Dictionary<string, object>(){
                    {"IdPalomar", IdPalomar},
                    {"IdGeo", IdGeo},
                    {"IdExpedicion", IdExpedicion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int EliminarPalomar(int ID)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "EliminarPalomar", new Dictionary<string, object>(){
                    {"Id", ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int DesvincularPalomarPuntoEntrega(int ID)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "DesvincularPalomarPuntoEntrega", new Dictionary<string, object>(){
                    {"Id", ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ModificarPalomar(Palomar oPalomar)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "ModificarPalomar", new Dictionary<string, object>(){
                    {"sDescripcion", oPalomar.Descripcion},
                    {"iId", oPalomar.ID},
                    {"iIdPadre", oPalomar.IdPadre}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int EliminarGrupoPalomar(int ID)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "EliminarGrupoPalomar", new Dictionary<string, object>(){
                    {"Id", ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Geo> ListarGeoPorPalomar(int iIdPalomar)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "ListarGeoPorPalomar", new Dictionary<string, object>(){
                    {"iIdPalomar", iIdPalomar}
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Geo> ListarGeoPorAsociarAlPalomar(int iIdExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PalomarWS + "ListarGeoPorAsociarAlPalomar", new Dictionary<string, object>(){
                    {"iIdExpedicion", iIdExpedicion}
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        #endregion

    }
}
