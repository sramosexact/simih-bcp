using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        #region OPERARIO

        //2022
        public static String NombreUsuarioNT
        {
            get
            {
                return System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString().ToUpper();
            }
        }
        //2022
        public static List<Operario> listaOperarioJSON(int iExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.OperarioWS + "GetOperarios", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion}
                });

                return deserializarPrueba<Operario>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        #endregion

    }
}
