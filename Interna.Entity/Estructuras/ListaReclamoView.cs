using System;
using System.Runtime.Serialization;

namespace Interna.Entity.Estructuras
{
    [Serializable]
    [DataContract]
    public class ListaReclamoView : Core.Entity
    {
        #region Propiedades

        [DataMember]
        public int iIdReclamo { get; set; }

        public DateTime dFechaRegistro { get; set; }


        private string fechaRegistroJson = "0001-01-01";

        [DataMember]
        public string FechaRegistroJson
        {
            get { return fechaRegistroJson; }
            set
            {
                dFechaRegistro = DateTime.Parse(value);
                fechaRegistroJson = value;
            }
        }
        [DataMember]
        public string sUsuarioCliente { get; set; }
        [DataMember]
        public string sArea { get; set; }
        [DataMember]
        public string sTipoReclamoUsuario { get; set; }
        [DataMember]
        public string sDocReferencia { get; set; }

        [DataMember]
        public string sDetalle { get; set; }

        public DateTime dFechaAtencion { get; set; }

        private string fechaAtencionJson = "0001-01-01";

        [DataMember]
        public string FechaAtencionJson
        {
            get { return fechaAtencionJson; }
            set
            {
                dFechaAtencion = DateTime.Parse(value);
                fechaAtencionJson = value;
            }
        }
        public DateTime dFechaSolucion { get; set; }

        private string fechaSolucionJson = "0001-01-01";

        [DataMember]
        public string FechaSolucionJson
        {
            get { return fechaSolucionJson; }
            set
            {
                dFechaSolucion = DateTime.Parse(value);
                fechaSolucionJson = value;
            }
        }
        public DateTime dFechaVerificacion { get; set; }

        private string fechaVerificacionJson = "0001-01-01";

        [DataMember]
        public string FechaVerificacionJson
        {
            get { return fechaVerificacionJson; }
            set
            {
                dFechaVerificacion = DateTime.Parse(value);
                fechaVerificacionJson = value;
            }
        }

        [DataMember]
        public string sEstadoReclamo { get; set; }

        [DataMember]
        public byte iFundado { get; set; }

        [DataMember]
        public string sFundado { get; set; }

        [DataMember]
        public string sTipoReclamoUTD { get; set; }

        [DataMember]
        public string sAccionInmediata { get; set; }

        [DataMember]
        public string sCausa { get; set; }

        [DataMember]
        public string sTipoResponsable { get; set; }

        [DataMember]
        public string sPersonaResponsable { get; set; }

        [DataMember]
        public string sUsuarioAtencion { get; set; }

        [DataMember]
        public string sEstadoVerificacion { get; set; }

        [DataMember]
        public byte iCalificacion { get; set; }

        [DataMember]
        public byte iObservado { get; set; }

        [DataMember]
        public string sObservacion { get; set; }

        [DataMember]
        public byte iIdEstadoReclamo { get; set; }

        [DataMember]
        public byte iIdTipoReclamoJefe { get; set; }

        [DataMember]
        public byte iIdEstadoVerificacion { get; set; }

        [DataMember]
        public string sExpedicion { get; set; }

        [DataMember]
        public string sSolucion { get; set; }

        [DataMember]
        public string sNecesitaCorreccion { get; set; }

        [DataMember]
        public string sCorreccion { get; set; }

        [DataMember]
        public int iCorreccion { get; set; }

        [DataMember]
        public int iIdTipoReclamoUTD { get; set; }

        [DataMember]
        public int iIdTipoResponsable { get; set; }

        #endregion
    }
}
