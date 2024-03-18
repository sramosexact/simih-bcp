using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {

        //2022
        public static List<Casilla> ListarCasillaOrigen(string texto)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "rBuscaTexto", new Dictionary<string, object>(){
                    { "IdCliente", Program.oCliente[0].ID},
                    { "texto", texto}
                });

                return JsonConvert.DeserializeObject<List<Casilla>>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                //return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }





        public static int VincularCasilla(int IdCasilla, int IdUsuario)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "VincularCasilla", new Dictionary<string, object>(){
                    {"IdCasilla", IdCasilla},
                    {"IdUsuario", IdUsuario}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<Casilla> CasillaUsuario(int IdUsuario)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "CasillaUsuario", new Dictionary<string, object>(){
                    {"IdUsuario", IdUsuario}
                });

                return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }



        //2022
        public static DataTable rObtenerDescripcion(string palabra)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "rDescripcion", new Dictionary<string, object>(){
                    {"palabra", palabra}
                });

                return JsonConvert.DeserializeObject<DataTable>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static List<Casilla> BandejasUsuarioExpedicion()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "BandejaUsuarioExpedicion", new Dictionary<string, object>(){
                    //{"iUsuario", Program.oUsuario.ID},
                    { "iExpedicion", Program.oUsuario.IdExpedicion}
                });

                return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //2022
        public static List<Casilla> ListarBandejaExpedicion(int iExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "ListarBandejaExpedicion", new Dictionary<string, object>(){
                    {"iExpedicion", iExpedicion}
                });

                return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Casilla> ListarBandeja()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "ListarBandeja", null);

                return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int CrearBandeja(Casilla oCasilla)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "CrearBandeja", new Dictionary<string, object>(){
                    {"sDescripcionBandeja", oCasilla.sDescripcion},
                    { "iIdGeo", oCasilla.IdGeo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static int ModificarBandeja(Casilla oCasilla)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "ModificarBandeja", new Dictionary<string, object>(){
                    {"sDescripcionBandeja", oCasilla.sDescripcion},
                    { "idGeo", oCasilla.IdGeo},
                    { "idBandeja", oCasilla.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }



        /*César 25/11/2016*/
        public static List<Casilla> ListarBandejaTipoDocumento()
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "ListarBandejaTipoDocumento", null);

                return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        /*César 12/01/2017*/
        public static int CambiarEstadoBandeja(Casilla oCasilla)
        {

            bool estado = false;

            if (oCasilla.iActivo > 0) estado = true;

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "CambiarEstadoBandeja", new Dictionary<string, object>(){
                    {"ID", oCasilla.ID}, {"estado", estado}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        /*Orlando Heredia 27/01/2017*/
        public static List<Casilla> ListarCasillasPorAsociarAlTipoDocumento(Casilla oCasilla)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "ListarCasillasPorAsociarAlTipoDocumento", new Dictionary<string, object>(){
                    {"sDescripcion", oCasilla.sDescripcion}
                });

                return deserializarPrueba<Casilla>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        public static List<Bandeja> ListarBandejasPorGeo(int IdGeo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.CasillaWS + "ListarBandejasPorGeo", new Dictionary<string, object>(){
                    {"IdGeo", IdGeo}
                });

                return JsonConvert.DeserializeObject<List<Bandeja>>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}
