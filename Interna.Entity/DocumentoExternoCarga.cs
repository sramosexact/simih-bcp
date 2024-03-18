using Interna.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;


namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class DocumentoExternoCarga : DocumentoExterno
    {
        #region Propiedades

        [DataMember]
        public string sDestinatario { get; set; }

        public string estado { get; set; }

        #endregion

        #region Metodos

        //2022
        public string CargarDocumentosExternos(byte IdExpedicion, int IdUsuario, int IdCasillaOrigen, byte IdTipoDocumentoExterno, string XmlDocumentosExternos)
        {
            Objeto obj = new Objeto();
            string xml = obj.SerializeObjectWindows(JsonConvert.DeserializeObject<List<DocumentoExterno>>(XmlDocumentosExternos));
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdExpedicion", IdExpedicion));
            lP.Add(new SqlParameter("@IdUsuario", IdUsuario));
            lP.Add(new SqlParameter("@IdCasillaOrigen", IdCasillaOrigen));
            lP.Add(new SqlParameter("@IdTipoDocumentoExterno", IdTipoDocumentoExterno));
            lP.Add(new SqlParameter("@XmlDocumentosExternos", xml));
            return oSql.TablaParametroJSON("SIMIH_DOCUMENTOEXTERNO_C_CARGAR", lP);
        }
        //2024
        public string CargarDocumentosExternosLote(byte IdExpedicion, int IdUsuario, int IdCasillaOrigen, byte IdTipoDocumentoExterno, string XmlDocumentosExternos)
        {
            Objeto obj = new Objeto();
            string xml = obj.SerializeObjectWindows(JsonConvert.DeserializeObject<List<DocumentoExterno>>(XmlDocumentosExternos));
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdExpedicion", IdExpedicion));
            lP.Add(new SqlParameter("@IdUsuario", IdUsuario));
            lP.Add(new SqlParameter("@IdCasillaOrigen", IdCasillaOrigen));
            lP.Add(new SqlParameter("@IdTipoDocumentoExterno", IdTipoDocumentoExterno));
            lP.Add(new SqlParameter("@XmlDocumentosExternos", xml));
            return oSql.TablaParametroJSON("SIMIH_DOCUMENTOEXTERNO_C_CARGAR_LOTE", lP);
        }
        //2022
        public string RetirarDocumentosExternos(string upn, string documentos)
        {
            Objeto obj = new Objeto();
            string xml = obj.SerializeObjectWindows(JsonConvert.DeserializeObject<List<DocumentoExterno>>(documentos));
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@upn", upn));
            lP.Add(new SqlParameter("@XmlDocumentosExternos", xml));
            return oSql.TablaParametroJSON("SIMIH_DOCUMENTOEXTERNO_D_RETIRAR", lP);
        }

        #endregion

    }
}
