using Interna.Entity;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<ModuloCreacion> ListarModulosCreacion()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ModuloCreacionWS + "ListarModulosCreacion", null);

                return deserializarPrueba<ModuloCreacion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<ModuloCreacion> ListarModulosCreacionPorTipoDocumento(TipoDocumento oTipoDocumento)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ModuloCreacionWS + "ListarModulosCreacionPorTipoDocumento", new Dictionary<string, object>() {
                    { "iIdTipoDocumento", oTipoDocumento.iIdTipoDocumento}
                });

                return deserializarPrueba<ModuloCreacion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
