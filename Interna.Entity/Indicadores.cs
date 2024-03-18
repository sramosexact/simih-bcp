using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{

    [Serializable]
    public class Indicadores : Interna.Core.Entity
    {
        public String Envie { get; set; }
        public String Para { get; set; }
        public String Mensaje { get; set; }
        public String Fecha { get; set; }
        public int Creados { get; set; }
        public int Proceso { get; set; }
        public int Recepcionado { get; set; }
        public int Custodia { get; set; }
        public int Ruta { get; set; }
        public int Confirmado { get; set; }

        public String ASUNTO { get; set; }
        public String AUTOGENERADO { get; set; }

        public int recibir { get; set; }
        public int porrecibir { get; set; }
        public int totalREcibido { get; set; }

        public String De { get; set; }
        public String Mensaje2 { get; set; }
        public String Fecha2 { get; set; }


        public String diaTranscurridos { get; set; }
        public String fechaInicial { get; set; }
        public String fechaFin { get; set; }
        public String mesesTranscurridos { get; set; }
        public String anosTranscurridos { get; set; }
        public String mesInicial { get; set; }
        public String mesFinal { get; set; }
        public String anoInicial { get; set; }
        public String anoFinal { get; set; }
        public String PorRecojer { get; set; }

        public String Norecibido { get; set; }
        public String rPorError { get; set; }


        /*
         Variables del nuevo cuadro de mando
         */
        public int indicador1 { get; set; }
        public int indicador2 { get; set; }
        public int indicador3 { get; set; }
        public int indicador4 { get; set; }
        public int resultado { get; set; }

        public List<Indicadores> rCuadodeMando2(int icasilla, int dias)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO_CASILLA", icasilla));
            oP.Add(new SqlParameter("@NDIA", dias));
            return oSql.TablaParametro<Indicadores>("EXI_R_CUADRO_DE_MANDO2", oP);
        }

        public List<Indicadores> rCuadodeMando_Recibido(int icasilla, int dias)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO_CASILLA", icasilla));
            oP.Add(new SqlParameter("@NDIA", dias));
            return oSql.TablaParametro<Indicadores>("EXI_R_CUADRO_DE_MANDO_RECIBIDOS", oP);
        }

        public Indicadores rCuadodeMandoPC()
        {
            sql oSql = new sql();
            return oSql.TablaTop<Indicadores>("EXI_R_CUADRO_MANDO_PC");
        }

        public List<Indicadores> rCuadodeMandoPC_Detalle(int opc, int valor)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@OPC", opc));
            oP.Add(new SqlParameter("@VALOR", valor));
            return oSql.TablaParametro<Indicadores>("EXI_R_CUADRO_MANDO_PC_DETALLE", oP);
        }
    }
}
