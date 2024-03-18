using Interna.Core;
using Interna.Entity.Interfaces;
using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Moneda : Core.Entity, IMoneda
    {
        #region Propiedades 

        [DataMember]
        public byte iIdMoneda { get; set; }

        [DataMember]
        public string sDescripcionMoneda { get; set; }

        [DataMember]
        public string sSimbolo { get; set; }

        [DataMember]
        public float fTipoCambio { get; set; }

        #endregion

        #region Metodos

        //2022
        public string ListarMonedasMesaDePartes()
        {
            return new sql().TablaJSON("SIMIH_MESAPARTES_R_LISTARMONEDAS");
        }

        #endregion
    }
}
