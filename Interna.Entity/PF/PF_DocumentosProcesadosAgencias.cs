using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_DocumentosProcesadosAgencias : PF_Entity
    {
        #region Propiedades

        [DataMember]
        public int poderes { get; set; }
        [DataMember]
        public int amortizacionesAFP { get; set; }
        [DataMember]
        public int valeConsumo { get; set; }
        [DataMember]
        public int bolsasAutosellables { get; set; }
        [DataMember]
        public int solicitudesVisanet { get; set; }

        #endregion

        #region Metodos

        public PF_DocumentosProcesadosAgencias()
        {

        }

        public PF_DocumentosProcesadosAgencias(int iIdPeriodo, int poderes, int amortizacionesAFP, int valeConsumo, int bolsasAutosellables, int solicitudesVisanet)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.poderes = poderes;
            this.amortizacionesAFP = amortizacionesAFP;
            this.valeConsumo = valeConsumo;
            this.bolsasAutosellables = bolsasAutosellables;
            this.solicitudesVisanet = solicitudesVisanet;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@poderes", poderes));
            lP.Add(new SqlParameter("@amortizacionesAFP", amortizacionesAFP));
            lP.Add(new SqlParameter("@valeConsumo", valeConsumo));
            lP.Add(new SqlParameter("@bolsasAutosellables", bolsasAutosellables));
            lP.Add(new SqlParameter("@solicitudesVisanet", solicitudesVisanet));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_DOCUMENTOSPROCESADOSAGENCIAS", lP));
        }

        #endregion
    }
}
