using Interna.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        #region GEO

        public static List<Geo> ReadGeoPalomar(Palomar oP)
        {
            //ServiceGeoWS.GeoWS oGeoCallWS = new ServiceGeoWS.GeoWS();
            //ServiceGeoWS.Geo[] oListaGeoWS = oGeoCallWS.GetGeoPalomar(oP.ID);
            //List<Geo> oLista = new List<Geo>();
            //foreach (ServiceGeoWS.Palomar oGeoWS in oListaGeoWS)
            //{
            //    Geo oGeo = new Geo();
            //    oGeo.CopyToMe(oGeoWS);
            //    oLista.Add(oGeo);
            //}
            //return oLista;

            return null;
        }

        #endregion

        //2022
        public static int EliminarCalles(Geo pGeo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "EliminarCalle", new Dictionary<string, object>(){
                    { "IdCliente", pGeo.IDCliente},
                    { "IdCalle", pGeo.ID }
                });

                return Convert.ToInt32(response);

            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int EliminarOficinas(Geo pGeo)
        {
            int intResultado = 0;
            try
            {


                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "EliminarOficina", new Dictionary<string, object>(){
                    { "IdCliente", pGeo.IDCliente},
                    { "IdOficina", pGeo.ID }
                });

                intResultado = Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
            catch
            {
                intResultado = -1;
            }
            return intResultado;
        }

        //2022
        public static List<Geo> CrearPuntoEntrega(Geo pGeo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "CrearPuntoEntrega", new Dictionary<string, object>(){
                    { "IdCliente", pGeo.IDCliente},
                    { "IdGeo", pGeo.ID },
                    { "IdExpedicion", pGeo.IdExpedicion},
                    { "Oficina", pGeo.Oficina},
                    { "Area", pGeo.Area},
                    { "Agencia", pGeo.Agencia}
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }



        public static List<Geo> listarUbicacion(int id)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "listarUbicacion", new Dictionary<string, object>(){
                    { "id", id}
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        // Funcional - frmConsultaBandeja
        public static Geo ObtenerDatosOficina(int IdGeo)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "getDatosOficina", new Dictionary<string, object>(){
                    { "IdGeo", IdGeo}
                });

                return deserializarPrueba<Geo>(response)[0];
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }



        public static List<Geo> ActualizarOficinas(Geo pGeo)
        {


            try
            {
                string response = Requester.AuthorizationTask(RutaWS.ObjetoWS + "ActualizarOficinas", new Dictionary<string, object>(){
                    { "IdCliente", pGeo.IDCliente},
                    { "IdGeo", pGeo.ID },
                    { "IdOficina", pGeo.IdOficina},
                    { "Oficina", pGeo.Oficina},
                    { "Area", pGeo.Area}
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static List<Geo> ListarUbicacionesJson(int IdCliente)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarUbicacionGeo", new Dictionary<string, object>() {
                    { "IdCliente", IdCliente}
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Geo> ListarPuntosEntrega(Geo oG)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarPuntosEntrega", new Dictionary<string, object>() {
                    { "IDCliente", oG.IDCliente},
                    { "ID", oG.ID},
                    { "IdExpedicionDominio", oG.IdExpedicionDominio}
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        /*César 31/08/2016*/
        public static List<Geo> ListarPuntoEntregaExpedicion()
        {
            //ServiceGeoWS.GeoWS owsGeo = new ServiceGeoWS.GeoWS();
            //return deserializarPrueba<Geo>(owsGeo.ListarPuntoEntregaExpedicion());
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarPuntoEntregaExpedicion", null);

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        /*César 09/09/2016*/
        public static List<Geo> ListarPuntoEntregaAgencia()
        {
            //ServiceGeoWS.GeoWS owsGeo = new ServiceGeoWS.GeoWS();
            //return deserializarPrueba<Geo>(owsGeo.ListarPuntoEntregaAgencia());

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarPuntoEntregaAgencia", null);

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        //2022
        public static List<Geo> ModificarPuntoEntrega(Geo pGeo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ModificarPuntoEntrega", new Dictionary<string, object>() {
                    { "IdCliente", pGeo.IDCliente},
                    { "IdGeo", pGeo.ID},
                    { "IdGeoPadre", pGeo.IdCalle},
                    { "Oficina", pGeo.Oficina},
                    { "Area", pGeo.Area},
                    { "Agencia", pGeo.Agencia}
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int EliminarPuntoEntrega(int iIdGeo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "EliminarPuntoEntrega", new Dictionary<string, object>() {
                    { "iIdGeo", iIdGeo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int ActualizarGeo(Geo geo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ActualizarGeo", new Dictionary<string, object>() {
                    { "ID", geo.ID},
                    { "Descripcion", geo.Descripcion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int CrearGeo(Geo geo)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "CrearGeo", new Dictionary<string, object>() {
                    { "ID", geo.ID}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        //2022
        public static List<Geo> ListarDepartamento()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarDepartamento", null);

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Geo> ListarProvincia(Geo departamento)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarProvincia", new Dictionary<string, object>() {
                    { "IdDepartamento", departamento.ID }
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Geo> ListarDistrito(Geo provincia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarDistrito", new Dictionary<string, object>() {
                    { "IdProvincia", provincia.ID }
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Geo> ListarCalle(Geo distrito)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarCalle", new Dictionary<string, object>() {
                    { "IdDistrito", distrito.ID }
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        //2022
        public static List<Geo> ListarOficina(Geo calle)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarOficina", new Dictionary<string, object>() {
                    { "IdCalle", calle.ID }
                });

                return deserializarPrueba<Geo>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2023
        public static int CrearBandejaFisica(string nombre, int idExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "CrearBandejaFisica", new Dictionary<string, object>() {
                    { "nombre", nombre },
                    { "idExpedicion", idExpedicion }
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2023
        public static List<BandejaFisica> ListarBandejaFisica(int idExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarBandejaFisica", new Dictionary<string, object>() {
                    { "idExpedicion", idExpedicion }
                });

                return deserializarPrueba<BandejaFisica>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2023
        public static List<Ubicacion> ListarUbicacionesExpedicion(int idExpedicion)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "ListarUbicacionesExpedicion", new Dictionary<string, object>() {
                    { "idExpedicion", idExpedicion }
                });

                return JsonConvert.DeserializeObject<List<Ubicacion>>(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2023
        public static int AsociarUbicacionABandejaFisica(int idUbicacion, int idBandejaFisica)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "AsociarUbicacionABandejaFisica", new Dictionary<string, object>() {
                    { "idUbicacion", idUbicacion },
                    { "idBandejaFisica", idBandejaFisica }
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2023
        public static int DesasociarUbicacionDeBandejaFisica(int idUbicacion, int idBandejaFisica)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.GeoWS + "DesasociarUbicacionDeBandejaFisica", new Dictionary<string, object>() {
                    { "idUbicacion", idUbicacion },
                    { "idBandejaFisica", idBandejaFisica }
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
