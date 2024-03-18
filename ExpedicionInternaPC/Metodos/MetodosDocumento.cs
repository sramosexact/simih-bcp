using Interna.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        public static List<Objeto> RegistrarDocumento(Documento oDocumento, bool requiereAutogenerado, int IdDocumentoRechazado)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoWS + "RegistrarDocumento", new Dictionary<string, object>(){
                    {"IdCasillaDe", oDocumento.iIdCasillaDe},
                    {"IdCasillaPara", oDocumento.iIdCasillaPara},
                    {"IdUsuarioCreador", oDocumento.iIdUsuarioCreador},
                    {"IdTipoDocumento", oDocumento.iIdTipoDocumento},
                    {"CodigoDocumento", oDocumento.sCodigoDocumento},
                    {"Procedencia", oDocumento.sProcedencia},
                    {"Observacion", oDocumento.sObservacion},
                    {"iMoneda", oDocumento.iMoneda},
                    {"Monto", oDocumento.iMonto},
                    {"NombreImagen", oDocumento.sNombreImagen},
                    {"Descripcion", oDocumento.Descripcion},
                    {"Empaque", oDocumento.iIdEmpaque},
                    {"RequiereAutogenerado", requiereAutogenerado},
                    {"IdDocumentoRechazado", IdDocumentoRechazado}
                });
                return deserializarPrueba<Objeto>(response);
                //return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        // Funcional - frmDocumentosProcesados
        public static List<Documento> ListarDocumentosRegistrados()
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoWS + "ListarDocumentosRegistrados", null);

                return deserializarPrueba<Documento>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static List<Documento> ListarDocumentosAsociados()
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoWS + "ListarDocumentosAsociados", null);

                return deserializarPrueba<Documento>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        // Funcional - frmDocumentoSeguimiento
        public static List<Documento> ListarSeguimientoDocumento(Documento oDocumento)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoWS + "ListarSeguimientoDocumento", new Dictionary<string, object>(){
                    {"IdDocumento", oDocumento.iId}
                });

                return deserializarPrueba<Documento>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        // Funcional - frmDocumentosProcesados
        public static List<Documento> ListarDocumentosHistoricos(DateTime FechaDesde, DateTime FechaHasta)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoWS + "ListarDocumentosHistoricos", new Dictionary<string, object>(){
                    {"FechaDesde", FechaDesde},
                    {"FechaHasta", FechaHasta}
                });

                return deserializarPrueba<Documento>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        public static int ModificarDocumento(Documento oDocumento)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoWS + "ModificarDocumento", new Dictionary<string, object>(){
                    {"IdDocumento", oDocumento.iId},
                    {"IdCasillaDe", oDocumento.iIdCasillaDe},
                    {"IdCasillaPara", oDocumento.iIdCasillaPara},
                    {"IdUsuarioCreador", oDocumento.iIdUsuarioCreador},
                    {"IdTipoDocumento", oDocumento.iIdTipoDocumento},
                    {"CodigoDocumento", oDocumento.sCodigoDocumento},
                    {"Procedencia", oDocumento.sProcedencia},
                    {"Observacion", oDocumento.sObservacion},
                    {"iMoneda", oDocumento.iMoneda},
                    {"Monto", oDocumento.iMonto},
                    {"NombreImagen", oDocumento.sNombreImagen}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static int GuardarImagenServidor(FileStream imagen, string nombre)
        {
            //ServiceDocumentoWS.DocumentoWS wsDocumento = new ServiceDocumentoWS.DocumentoWS();
            //return wsDocumento.GuardarImagenDocumento(imagen, nombre);
            try
            {
                MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
                multipartFormDataContent.Add(new StreamContent(imagen), "file", nombre);
                string response = Requester.UploadTask("upload", multipartFormDataContent);
                return Convert.ToInt32(response);
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

        public static int GuardarPDFServidor(FileStream pdf, string nombre)
        {

            try
            {
                MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
                multipartFormDataContent.Add(new StreamContent(pdf), "file", nombre);
                string response = Requester.UploadTask("upload", multipartFormDataContent);
                return Convert.ToInt32(Boolean.Parse(response) ? 1 : 0);
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


        public static int RegistrarDocumentosEspecialesMasivo(Documento oDocumento, bool requiereAutogenerado)
        {

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.DocumentoWS + "RegistrarDocumentosEspecialesMasivo", new Dictionary<string, object>(){
                    {"IdCasillaDe", oDocumento.iIdCasillaDe},
                    {"IdCasillaPara", oDocumento.iIdCasillaPara},
                    {"IdUsuarioCreador", oDocumento.iIdUsuarioCreador},
                    {"IdTipoDocumento", oDocumento.iIdTipoDocumento},
                    {"CodigoDocumento", oDocumento.sCodigoDocumento},
                    {"Procedencia", oDocumento.sProcedencia},
                    {"Observacion", oDocumento.sObservacion},
                    {"iMoneda", oDocumento.iMoneda},
                    {"Monto", oDocumento.iMonto},
                    {"NombreImagen", oDocumento.sNombreImagen},
                    {"Descripcion", oDocumento.Descripcion},
                    {"Empaque", oDocumento.iIdEmpaque},
                    {"RequiereAutogenerado", requiereAutogenerado}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        public static string ObtenerAutogenerado(int IDOBJETO)
        {

            string response2 = Requester.AuthorizationTask(RutaWS.ObjetoWS + "GetObtener_Cabecera", new Dictionary<string, object>(){
                        {"IdObjeto", IDOBJETO}
                    });

            Objeto objeto = deserializarPrueba<Objeto>(response2)[0];

            if (objeto != null)
            {
                return objeto.Ticket;
            }
            else
            {
                return null;
            }

        }

    }
}
