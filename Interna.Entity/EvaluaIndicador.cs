using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    [Serializable]
    public class EvaluaIndicador : Interna.Core.Entity
    {
        public int CREADO_OFICINA_AMARILLO { get; set; }
        public int CREADO_OFICINA_ROJO { get; set; }
        public int CUSTODIA_PISO_AMARILLO { get; set; }
        public int CUSTODIA_PISO_ROJO { get; set; }
        public int RUTA_OFICINA_AMARILLO { get; set; }
        public int RUTA_OFICINA_ROJO { get; set; }
        public int CREADO_PISO_AMARILLO { get; set; }
        public int CREADO_PISO_ROJO { get; set; }
        public int RUTA_PISO_AMARILLO { get; set; }
        public int RUTA_PISO_ROJO { get; set; }
        public int MAXIMO_TIEMPO_RECIBIDO { get; set; }
        public int RECEPCION_GENERAL_AMARILLO { get; set; }
        public int RECEPCION_GENERAL_ROJO { get; set; }


        public List<EvaluaIndicador> Indicadores { get; set; }


        public List<EvaluaIndicador> rBuscaTexto(Cliente oC, String texto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", oC.ID));
            oP.Add(new SqlParameter("@TEXTO", texto));
            return oSql.TablaParametro<EvaluaIndicador>("EXI_R_CASILLA", oP);
        }
    }
}
