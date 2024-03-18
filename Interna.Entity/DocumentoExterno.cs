using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class DocumentoExterno
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Destino { get; set; }


        //public string ListarDuplicados(string xml)
        //{
        //    sql oSql = new sql();
        //    List<SqlParameter> lP = new List<SqlParameter>();
        //    lP.Add(new SqlParameter("@LOTEXML", xml));
        //    return oSql.TablaTopJson("PC_DOCUMENTOEXTERNO_R_LISTAR_DUPLICADOS", lP);
        //}
    }
}
