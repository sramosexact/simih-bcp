using Interna.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Estado
    {
        [DataMember]
        public int IdEstado { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public int iActivo { get; set; }

        public List<Estado> subListarEstadoActivo()
        {
            List<Estado> lstEstado = new List<Estado>();
            Estado ItemEstadoInactivo = new Estado();
            ItemEstadoInactivo.IdEstado = 0;
            ItemEstadoInactivo.estado = "INACTIVO";
            lstEstado.Add(ItemEstadoInactivo);

            Estado ItemEstadoActivo = new Estado();
            ItemEstadoActivo.IdEstado = 1;
            ItemEstadoActivo.estado = "ACTIVO";
            lstEstado.Add(ItemEstadoActivo);

            return lstEstado;
        }
        //2022
        public string ListarEstados()
        {
            return new sql().TablaJSON("SIMIH_COMUN_R_LISTARESTADOELEMENTOS");
        }

        public string ListarEstadoEntrega()
        {
            return new sql().TablaJSON("PC_ESTADOENTREGA_R_LISTAR");
        }
    }
}
