using Interna.Core;
using System;
using System.Collections.Generic;

namespace Interna.Entity
{
    [Serializable]
    public class Servicio : Interna.Core.Entity
    {

        public int ID { get; set; }
        public string Descripcion { get; set; }
        public int IdMensajeria { get; set; }


        public List<Servicio> rServicio()
        {
            sql oSql = new sql();

            return oSql.Tabla<Servicio>("EXI_R_TIPO_SERVICIO_EXTERNA");
        }


    }
}
