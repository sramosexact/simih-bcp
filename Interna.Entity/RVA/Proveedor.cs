using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Proveedor : Core.Entity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descripcion { get; set;}
        [DataMember]
        public int iActivo { get; set; }
        [DataMember]
        public string Activo { get; set; }

        public string ListarProveedores()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("SIMIH_MANTENIMIENTOPROVEEDOR_R_LISTAR");
        }
    }
}
