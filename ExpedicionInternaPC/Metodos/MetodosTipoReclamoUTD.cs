using Interna.Entity;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<TipoReclamoUTD> ListarTipoReclamoUTDActivo()
        {
            //ServiceTipoReclamoUTDWS.TipoReclamoUTDWS tipoReclamoUTDWS = new ServiceTipoReclamoUTDWS.TipoReclamoUTDWS();
            //return deserializarPrueba<TipoReclamoUTD>(tipoReclamoUTDWS.ListarTipoReclamoUTDActivo());

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoReclamoUTDWS + "ListarTipoReclamoUTDActivo", null);

                return deserializarPrueba<TipoReclamoUTD>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static List<ListaTipoReclamoUTDView> ListarResumenTipoReclamoMes(DateTime fecha)
        {
            //ServiceTipoReclamoUTDWS.TipoReclamoUTDWS tipoReclamoUTDWS = new ServiceTipoReclamoUTDWS.TipoReclamoUTDWS();
            //return deserializarPrueba<ListaTipoReclamoUTDView>(tipoReclamoUTDWS.ListarResumenTipoReclamoMes(fecha));

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoReclamoUTDWS + "ListarResumenTipoReclamoMes", new Dictionary<string, object>(){
                    {"fecha", fecha}
                });

                return deserializarPrueba<ListaTipoReclamoUTDView>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

    }
}
