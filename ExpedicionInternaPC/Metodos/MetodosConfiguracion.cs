using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static void listarConfiguracion()
        {


            Configuracion[] olCws = deserializarPrueba<Configuracion>(Requester.AuthorizationTask(RutaWS.ConfiguracionWS + "getConfiguracion", new Dictionary<string, object>{
                {"ID",0}
            })).ToArray();


            foreach (Configuracion oItem in olCws)
            {
                Configuracion oc = new Configuracion();
                oc.CopyToMe(oItem);
                Program.oConfi.Add(oc);
            }
        }

        //2022
        public static List<Configuracion> ListarIndicadores()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ConfiguracionWS + "ListarIndicadores", null);

                return deserializarPrueba<Configuracion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static int ModificarIndicador(int iId, int fValor)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ConfiguracionWS + "ModificarIndicador", new Dictionary<string, object>() {

                    { "iId", iId},
                    { "fValor", fValor}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Configuracion> ListarDiasConfirmacionAutomatica()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ConfiguracionWS + "ListarDiasConfirmacionAutomatica", null);

                return deserializarPrueba<Configuracion>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
