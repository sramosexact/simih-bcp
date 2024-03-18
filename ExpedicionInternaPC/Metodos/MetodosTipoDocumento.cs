using Interna.Entity;
using Interna.Entity.Estructuras;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        //2022
        public static List<TipoDocumento> ListarTipoDocumentoPorTipoCorrespondenciaMesaDePartes(TipoDocumento oTipoDocumento)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "ListarTipoDocumentoPorTipoCorrespondenciaMesaDePartes", new Dictionary<string, object>(){
                    { "IdTipoCorrespondencia", oTipoDocumento.iIdTipoCorrespondencia}
                });

                return deserializarPrueba<TipoDocumento>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static List<ListaTipoDocumentoView> ListarTipoDocumentoRegistrados()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "ListarTipoDocumentoRegistrados", null);

                return deserializarPrueba<ListaTipoDocumentoView>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int RegistrarTipoDocumento(TipoDocumento oTipoDocumento)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "RegistrarTipoDocumento", new Dictionary<string, object>() {
                    { "sDescripcionTipoDocumento", oTipoDocumento.sDescripcionTipoDocumento},
                    { "iIdTipoCorrespondencia", oTipoDocumento.iIdTipoCorrespondencia},
                    { "iMoneda", oTipoDocumento.iMoneda},
                    { "entregaPersonalizada", oTipoDocumento.entregaPersonalizada}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int ModificarTipoDocumento(TipoDocumento oTipoDocumento)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "ModificarTipoDocumento", new Dictionary<string, object>() {
                    { "iIdTipoDocumento", oTipoDocumento.iIdTipoDocumento},
                    { "sDescripcionTipoDocumento", oTipoDocumento.sDescripcionTipoDocumento},
                    { "iIdTipoCorrespondencia", oTipoDocumento.iIdTipoCorrespondencia},
                    { "iMoneda", oTipoDocumento.iMoneda },
                    { "entregaPersonalizada", oTipoDocumento.entregaPersonalizada}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int AsociarModulo(ModuloCreacion oModulo, TipoDocumento oTipoDocumento, Casilla oCasilla, string campos)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "AsociarModulo", new Dictionary<string, object>() {
                    { "iIdModulo", oModulo.iId},
                    { "iIdTipoDocumento", oTipoDocumento.iIdTipoDocumento},
                    { "iIdCasilla", oCasilla.ID},
                    { "requiereDigitalizacion", oTipoDocumento.requiereDigitalizacion},
                    { "camposJson", campos}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int QuitarAsociacionModulo(ModuloCreacion oModulo, TipoDocumento oTipoDocumento)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "QuitarAsociacionModulo", new Dictionary<string, object>() {
                    { "IdModulo", oModulo.iId},
                    { "IdTipoDocumento", oTipoDocumento.iIdTipoDocumento}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        /*César Baltazar 26/01/2017*/
        public static List<TipoDocumento> ListarTipoDocumentoDigital()
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "ListarTipoDocumentoDigital", null);

                return deserializarPrueba<TipoDocumento>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        public static int EditarCamposDocumentosEspeciales(TipoDocumento oTipoDocumento, string campos)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "EditarCamposDocumentosEspeciales", new Dictionary<string, object>() {
                    { "iIdTipoDocumento", oTipoDocumento.iIdTipoDocumento},
                    { "requiereDigitalizacion", oTipoDocumento.requiereDigitalizacion},
                    { "camposJson", campos}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<TipoDocumento> ListarTipoDocumentoSinDigitalizar()
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.TipoDocumentoWS + "ListarTipoDocumentoSinDigitalizar", null);

                return deserializarPrueba<TipoDocumento>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
    }
}
