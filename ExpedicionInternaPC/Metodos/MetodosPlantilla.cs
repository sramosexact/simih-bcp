using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {


        public static List<PlantillaGeneral> PlantillaGeneralActiva()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PlantillaGeneralWS + "GetPlantillaGeneralActiva", new Dictionary<string, object>(){
                    {"IdCliente", Program.oUsuario.IdCliente}
                });

                return deserializarPrueba<PlantillaGeneral>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<Campo> CamposActivos(int codplantilla)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PlantillaGeneralWS + "GetCamposActivos", new Dictionary<string, object>(){
                    {"codPlantilla", codplantilla}
                });

                return deserializarPrueba<Campo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }



        public static List<Tipo> TipoDocumento()
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "GetTipoDocumento", null);

                return deserializarPrueba<Tipo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static List<Campo> TipoCampo(int indicetipodoc)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PlantillaWS + "GetTipoCampo", new Dictionary<string, object>(){
                    {"indicetipodoc", indicetipodoc}
                });

                return deserializarPrueba<Campo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //Plantilla Detalle
        public static int creaPlantillaGeneral(PlantillaGeneral oPlantillaGral)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PlantillaGeneralWS + "setPlantillaGeneral", new Dictionary<string, object>(){
                    {"IdCliente", oPlantillaGral.Cliente},
                    {"IdExpedicion", oPlantillaGral.Expedicion},
                    {"IdTipoDocumento", oPlantillaGral.TipoDocumento},
                    {"Nombre", oPlantillaGral.Nombre},
                    {"IdCreadoPor", oPlantillaGral.CreadoPor},
                    {"Detalle", oPlantillaGral.Detalle},
                    {"Posicion", oPlantillaGral.Posicion},
                    {"Ruta", oPlantillaGral.Ruta}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int desactivaPlantillaGeneral(PlantillaGeneral oPlantillaGral)
        {

            if (oPlantillaGral.Expedicion == Program.oUsuario.IdExpedicion)
            {
                try
                {
                    string response = Requester.AuthorizationTask(RutaWS.PlantillaGeneralWS + "setDesactivaPlantillaGeneral", new Dictionary<string, object>(){
                    {"IdPlantilla", oPlantillaGral.ID},
                    {"IdUsuario", oPlantillaGral.CreadoPor},
                    {"IdExpedicion", oPlantillaGral.Expedicion}

                });

                    return Convert.ToInt32(response);
                }
                catch (InvalidTokenException)
                {
                    throw;
                }
            }

            return -1;


        }

        public static int actualizaPlantillaGeneral(PlantillaGeneral oPlantillaGeneral)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PlantillaGeneralWS + "updatePlantillaGeneral", new Dictionary<string, object>(){
                    {"IdPlantilla", oPlantillaGeneral.ID},
                    {"IdExpedicion", oPlantillaGeneral.Expedicion},
                    {"Nombre", oPlantillaGeneral.Nombre},
                    {"IdUsuario", oPlantillaGeneral.CreadoPor},
                    {"Detalle", oPlantillaGeneral.Detalle},
                    {"Posicion", oPlantillaGeneral.Posicion},
                    {"Ruta", oPlantillaGeneral.Ruta}

                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        internal static int CargarDatosPlantilla(PlantillaGeneral objPlantillaGral, List<ObjetoDetalle> listaDatos)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.PlantillaGeneralWS + "setCargarDatos", new Dictionary<string, object>(){
                    {"IdPlantilla", objPlantillaGral.ID},
                    {"IdExpedicion", objPlantillaGral.Expedicion},
                    {"IdTipoServicio", objPlantillaGral.TipoServicio},
                    {"IdMensajeria", objPlantillaGral.IdMensajeria},
                    {"IdUsuario", objPlantillaGral.CreadoPor},
                    {"IdCasillaOrigen", objPlantillaGral.IdCasillaOrigen},
                    {"IdCasillaDestino", objPlantillaGral.IdCasillaDestino},
                    {"IdEstado", objPlantillaGral.IdEstado},
                    {"IdMotivoCarga", objPlantillaGral.MotivoCarga},
                    {"IdTipoLote", objPlantillaGral.TipoLote},
                    {"IdActualizacion", objPlantillaGral.Actualizacion},
                    {"Ruta", objPlantillaGral.Ruta},
                    {"Guia", objPlantillaGral.Guia},
                    {"Detalle", objPlantillaGral.Detalle}
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
