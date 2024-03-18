using Interna.Core;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_Periodo : PF_Entity
    {

        #region Propiedades

        [DataMember]
        public string sFechaPeriodo = "";

        public DateTime dFechaPeriodo;

        [DataMember]
        public string fechaPeriodo
        {

            get
            {
                return sFechaPeriodo;
            }

            set
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
                sFechaPeriodo = DateTime.Parse(value).ToString("MMMM - yyyy").ToUpper();
                dFechaPeriodo = DateTime.Parse(value);
            }
        }

        [DataMember]
        public string anioPeriodo { get; set; }

        #endregion



        #region Metodos

        public string ListarPeriodos()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PF_PERIODO_R_LISTAR");
        }

        public string ListarAnioPeriodos()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PF_PERIODO_R_LISTAR_ANIO");
        }

        #endregion




    }
}
