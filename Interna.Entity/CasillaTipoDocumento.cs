using System;
using System.Runtime.Serialization;
namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class CasillaTipoDocumento : Interna.Core.Entity, Interfaces.ICasillaTipoDocumento
    {
        #region Propiedades

        public int iIdCasillaTipoDocumento { get; set; }
        public int iIdCasilla { get; set; }
        public Int16 iIdTipoDocumento { get; set; }

        #endregion

        #region Metodos


        #endregion
    }
}
