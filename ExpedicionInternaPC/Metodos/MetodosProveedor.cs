using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<Proveedor> ListarProveedores()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.UsuarioWS + "ListarProveedores", null);
                List<Proveedor> listaProveedores = JsonConvert.DeserializeObject<List<Proveedor>>(response);
                return listaProveedores;
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
