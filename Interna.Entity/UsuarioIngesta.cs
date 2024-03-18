using Interna.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class UsuarioIngesta : Core.Entity
    {
        private string _Upn = "";
        private string _Usuario = "";
        [DataMember]
        public string Matricula { get; set; }
        [XmlIgnore]
        [DataMember]
        public string ApellidoPaterno { get; set; }
        [XmlIgnore]
        [DataMember]
        public string ApellidoMaterno { get; set; }
        [XmlIgnore]
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string Usuario
        {
            get
            {
                return $"{this.Nombres.Trim().ToUpper()} {this.ApellidoPaterno.Trim().ToUpper()} {this.ApellidoMaterno.Trim().ToUpper()}";
            }
            set
            {
                this._Usuario = value;
            }
        }
        [DataMember]
        public string Area { get; set; }
        [DataMember]
        public string Servicio { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember]
        public string Ubicacion { get; set; }
        [DataMember]
        public string UnidadOrganizativa { get; set; }
        [DataMember]
        public string CodigoAgencia { get; set; }
        [DataMember]
        public string Sede { get; set; }
        [XmlIgnore]
        [DataMember]
        public string Correo { get; set; }
        [DataMember]
        public string Upn
        {
            get
            {
                return this.Correo.Trim().ToLower();
            }
            set
            {
                this._Upn = value;
            }
        }

        public UsuarioIngesta()
        {

        }

        //2022
        public int IngestaUsuario(string json)
        {

            Objeto obj = new Objeto();
            List<UsuarioIngesta> usuarioIngestaList = JsonConvert.DeserializeObject<List<UsuarioIngesta>>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            string xml = obj.SerializeGenericObjectToXml<List<UsuarioIngesta>>(usuarioIngestaList);

            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DATA_XML", xml));
            return Convert.ToInt32(oSql.Escalar("SIMIH_USUARIOINGESTA_U_CARGA", oP));

        }


    }
}
