using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity.PF
{
    [Serializable]
    [DataContract]
    public class PF_MesaPartesLMO : PF_Entity
    {
        #region Propiedades
        [DataMember]
        public int cartasCTS { get; set; }
        [DataMember]
        public int avisosNoPago { get; set; }
        [DataMember]
        public int sbs { get; set; }
        [DataMember]
        public int activosFijos { get; set; }
        [DataMember]
        public int facturasFisicas { get; set; }
        [DataMember]
        public int facturasElectronicas { get; set; }

        #endregion

        #region Metodos

        public PF_MesaPartesLMO()
        {

        }

        public PF_MesaPartesLMO(int iIdPeriodo, int cartasCTS, int avisosNoPago, int sbs, int activosFijos, int facturasFisicas, int facturasElectronicas)
        {
            this.iIdPeriodo = iIdPeriodo;
            this.cartasCTS = cartasCTS;
            this.avisosNoPago = avisosNoPago;
            this.sbs = sbs;
            this.activosFijos = activosFijos;
            this.facturasElectronicas = facturasElectronicas;
            this.facturasFisicas = facturasFisicas;
        }

        public int actualizar()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@iIdPeriodo", iIdPeriodo));
            lP.Add(new SqlParameter("@cartasCTS", cartasCTS));
            lP.Add(new SqlParameter("@avisosNoPago", avisosNoPago));
            lP.Add(new SqlParameter("@sbs", sbs));
            lP.Add(new SqlParameter("@activosFijos", activosFijos));
            lP.Add(new SqlParameter("@facturasFisicas", facturasFisicas));
            lP.Add(new SqlParameter("@facturasElectronicas", facturasElectronicas));
            return Convert.ToInt32(oSql.Escalar("PF_UTD_U_MESAPARTESLMO", lP));
        }

        #endregion
    }
}
