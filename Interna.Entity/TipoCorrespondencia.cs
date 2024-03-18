using Interna.Core;
using System;
using System.Runtime.Serialization;


namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class TipoCorrespondencia : Core.Entity, Interfaces.ITipoCorrespondencia
    {
        #region Propiedades

        [DataMember]
        public Byte iIdTipoCorrespondencia { get; set; }

        [DataMember]
        public string sDescripcionTipoCorrespondencia { get; set; }

        #endregion

        #region Metodos
        //2022
        public string ListarTiposCorrespondenciaEnMesaDePartes()
        {
            return new sql().TablaJSON("SIMIH_MESAPARTES_R_TIPOCORRESPONDENCIA");
        }
        //2022
        public string ListarTipoCorrespondencia()
        {
            return new sql().TablaJSON("SIMIH_MANTENIMIENTOTIPODOCUMENTO_R_TIPOCORRESPONDENCIA");
        }


        #endregion
    }
}
