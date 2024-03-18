using Interna.Entity;
using System;
using System.IO;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de DocumentoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class DocumentoWS : System.Web.Services.WebService
    {
        public string rutaDigital = System.Web.Configuration.WebConfigurationManager.AppSettings.GetValues("RutaDigital")[0];

        [WebMethod]
        public string RegistrarDocumento(int IdCasillaDe, int IdCasillaPara, int IdUsuarioCreador, int IdTipoDocumento, string CodigoDocumento, string Procedencia, string Observacion, int iMoneda, decimal Monto, string NombreImagen, string Descripcion, int Empaque, bool RequiereAutogenerado, int IdDocumentoRechazado)
        {
            Documento oDocumento = new Documento();

            oDocumento.iIdCasillaDe = IdCasillaDe;
            oDocumento.iIdCasillaPara = IdCasillaPara;
            oDocumento.iIdUsuarioCreador = IdUsuarioCreador;
            oDocumento.iIdTipoDocumento = IdTipoDocumento;
            oDocumento.sProcedencia = Procedencia;
            oDocumento.sObservacion = Observacion;
            oDocumento.iMoneda = iMoneda;
            oDocumento.iMonto = Monto;
            oDocumento.sNombreImagen = NombreImagen;
            oDocumento.Descripcion = Descripcion;
            oDocumento.iIdEmpaque = Empaque;
            return oDocumento.RegistrarDocumento(RequiereAutogenerado, IdDocumentoRechazado);
        }
        // Funcional - frmDocumentosProcesados
        [WebMethod]
        public string ListarDocumentosRegistrados()
        {
            Documento oDocumento = new Documento();
            return oDocumento.ListarDocumentosRegistrados();
        }

        [WebMethod]
        public string ListarDocumentosAsociados()
        {
            Documento oDocumento = new Documento();
            return oDocumento.ListarDocumentosAsociados();
        }

        [WebMethod]
        public string ListarDocumentosRechazados()
        {
            Documento oDocumento = new Documento();
            return oDocumento.ListarDocumentosRechazados();
        }

        [WebMethod]
        public int RecibirRechazarDocumento(Documento oDocumento)
        {
            return oDocumento.RecibirRechazarDocumento();
        }
        // Funcional - frmDocumentoSeguimiento
        [WebMethod]
        public string ListarSeguimientoDocumento(int IdDocumento)
        {
            Documento oDocumento = new Documento();
            return oDocumento.ListarSeguimientoDocumento(IdDocumento);
        }
        // Funcional - frmDocumentosProcesados
        [WebMethod]
        public string ListarDocumentosHistoricos(DateTime FechaDesde, DateTime FechaHasta)
        {
            Documento oDocumento = new Documento();
            return oDocumento.ListarDocumentosHistoricos(FechaDesde, FechaHasta);
        }

        [WebMethod]
        public int ModificarDocumento(int IdDocumento, int IdCasillaDe, int IdCasillaPara, int IdUsuarioCreador, int IdTipoDocumento, string CodigoDocumento, string Procedencia, string Observacion, int iMoneda, decimal Monto, string NombreImagen)
        {
            Documento oDocumento = new Documento();
            oDocumento.iId = IdDocumento;
            oDocumento.iIdCasillaDe = IdCasillaDe;
            oDocumento.iIdCasillaPara = IdCasillaPara;
            oDocumento.iIdUsuarioCreador = IdUsuarioCreador;
            oDocumento.iIdTipoDocumento = IdTipoDocumento;
            oDocumento.sCodigoDocumento = CodigoDocumento;
            oDocumento.sProcedencia = Procedencia;
            oDocumento.sObservacion = Observacion;
            oDocumento.iMoneda = iMoneda;
            oDocumento.iMonto = Monto;
            oDocumento.sNombreImagen = NombreImagen;
            return oDocumento.ModificarDocumento();
        }


        [WebMethod]
        public int BorrarImagenDocumento(string nombre)
        {
            try
            {
                File.Delete(rutaDigital + nombre);
                return 1;
            }
            catch (Exception e)
            {
                return -1;
            }

        }


        [WebMethod]
        public int RegistrarDocumentosEspecialesMasivo(int IdCasillaDe, int IdCasillaPara, int IdUsuarioCreador, int IdTipoDocumento, string CodigoDocumento, string Procedencia, string Observacion, int iMoneda, decimal Monto, string NombreImagen, string Descripcion, int Empaque, bool RequiereAutogenerado)
        {
            Documento oDocumento = new Documento();

            oDocumento.iIdCasillaDe = IdCasillaDe;
            oDocumento.iIdCasillaPara = IdCasillaPara;
            oDocumento.iIdUsuarioCreador = IdUsuarioCreador;
            oDocumento.iIdTipoDocumento = IdTipoDocumento;
            oDocumento.sProcedencia = Procedencia;
            oDocumento.sObservacion = Observacion;
            oDocumento.iMoneda = iMoneda;
            oDocumento.iMonto = Monto;
            oDocumento.sNombreImagen = NombreImagen;
            oDocumento.Descripcion = Descripcion;
            oDocumento.iIdEmpaque = Empaque;
            return oDocumento.RegistrarDocumentosEspecialesMasivo(RequiereAutogenerado);
        }

    }
}
