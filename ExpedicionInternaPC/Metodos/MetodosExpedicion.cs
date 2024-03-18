using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {

        public static List<Expedicion> ListarExpediciones(int id)
        {
            //ServiceExpedicionWS.ExpedicionWS oUCALL = new ServiceExpedicionWS.ExpedicionWS();
            //ServiceExpedicionWS.Expedicion[] oArrayU = oUCALL.GetExpedicion_Cliente(id);
            //List<Expedicion> oExpedicion = new List<Expedicion>();
            //foreach (ServiceExpedicionWS.Expedicion oUs in oArrayU)
            //{
            //    Expedicion oU = new Expedicion();
            //    oU.Descripcion = oUs.Descripcion;
            //    oU.Geo = oUs.Geo;
            //    oU.ID = oUs.ID;
            //    oExpedicion.Add(oU);
            //}
            //return oExpedicion;

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ExpedicionWS + "GetExpedicion_Cliente", new Dictionary<string, object>(){
                    {"id",id}
                });

                return deserializarPrueba<Expedicion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static List<Expedicion> GetExpedicionListaUsuarioPrueba(Usuario usuario)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ExpedicionWS + "GetExpedicionListaUsuarioPrueba", new Dictionary<string, object>(){
                    {"id",usuario.ID}
                });

                return deserializarPrueba<Expedicion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static List<Expedicion> ListarExpedicionesListaJson()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ExpedicionWS + "ListarExpedicion", null);
                return deserializarPrueba<Expedicion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static List<Expedicion> rListarExpediciones()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ExpedicionWS + "rListarExpediciones", null);

                return deserializarPrueba<Expedicion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int NuevaExpedicion(Expedicion oExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ExpedicionWS + "NuevaExpedicion", new Dictionary<string, object>() {
                    { "ID", oExpedicion.ID},
                    { "idCalle", oExpedicion.idCalle},
                    { "idTipoExpedicion", oExpedicion.idTipoExpedicion},
                    { "IdCliente", oExpedicion.IdCliente},
                    { "Descripcion", oExpedicion.Descripcion},
                    { "Prefijo", oExpedicion.Prefijo},
                    { "Geo", oExpedicion.Geo}

                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int ModificarExpedicion(Expedicion oExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ExpedicionWS + "ModificarExpedicion", new Dictionary<string, object>() {
                    { "ID", oExpedicion.ID},
                    { "idCalle", oExpedicion.idCalle},
                    { "idTipoExpedicion", oExpedicion.idTipoExpedicion},
                    { "IdCliente", oExpedicion.IdCliente},
                    { "Descripcion", oExpedicion.Descripcion},
                    { "Prefijo", oExpedicion.Prefijo},
                    { "Geo", oExpedicion.Geo},
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int EliminarExpedicion(Expedicion oExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ExpedicionWS + "EliminarExpedicion", new Dictionary<string, object>() {
                    { "ID", oExpedicion.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int ActivarExpedicion(Expedicion oExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ExpedicionWS + "ActivarExpedicion", new Dictionary<string, object>() {
                    { "ID", oExpedicion.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}