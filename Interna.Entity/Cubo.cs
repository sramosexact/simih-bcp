using Interna.Core;
using System;
using System.Collections.Generic;

namespace Interna.Entity
{
    [Serializable]
    public class Cubo : Interna.Core.Entity
    {
        public int ID { get; set; }

        public String AUTOGENERADO { get; set; }

        [Column(Name = "TipoEstado")]
        public String ESTADO { get; set; }

        [Column(Name = "FechaCreacionDia")]
        public int FECHA_CREACION_DIA { get; set; }

        [Column(Name = "FechaCreacionMes")]
        public int FECHA_CREACION_MES { get; set; }

        [Column(Name = "FechaCreacionAnio")]
        public int FECHA_CREACION_ANIO { get; set; }

        [Column(Name = "FechaCustodiaDia")]
        public int FECHA_CUSTODIA_DIA { get; set; }

        [Column(Name = "FechaCustodiaMes")]
        public int FECHA_CUSTODIA_MES { get; set; }

        [Column(Name = "FechaCustodiaAnio")]
        public int FECHA_CUSTODIA_ANIO { get; set; }

        [Column(Name = "FechaRutaDia")]
        public int FECHA_RUTA_DIA { get; set; }

        [Column(Name = "FechaRutaMes")]
        public int FECHA_RUTA_MES { get; set; }

        [Column(Name = "FechaRutaAnio")]
        public int FECHA_RUTA_ANIO { get; set; }

        [Column(Name = "FechaRecepcionadoDia")]
        public int FECHA_RECEPCIONADO_DIA { get; set; }

        [Column(Name = "FechaRecepcionadoMes")]
        public int FECHA_RECEPCIONADO_MES { get; set; }

        [Column(Name = "FechaRecepcionadoAnio")]
        public int FECHA_RECEPCIONADO_ANIO { get; set; }

        [Column(Name = "FechaConfirmadoDia")]
        public DateTime FECHA_CONFIRMADO_DIA { get; set; }

        [Column(Name = "FechaConfirmadoMes")]
        public DateTime FECHA_CONFIRMADO_MES { get; set; }

        [Column(Name = "FechaConfirmadoAnio")]
        public DateTime FECHA_CONFIRMADO_ANIO { get; set; }

        [Column(Name = "TipoObjeto")]
        public String TIPO_OBJETO { get; set; }

        [Column(Name = "CasillaDe")]
        public String CASILLA_DE { get; set; }

        [Column(Name = "AreaDe")]
        public String AREA_DE { get; set; }

        [Column(Name = "OficinaDe")]
        public String OFICINA_DE { get; set; }

        [Column(Name = "DistritoDe")]
        public String DISTRITO_DE { get; set; }

        [Column(Name = "ProvinciaDe")]
        public String PROVINCIA_DE { get; set; }

        [Column(Name = "CasillaPara")]
        public String CASILLA_PARA { get; set; }

        [Column(Name = "AreaPara")]
        public String AREA_PARA { get; set; }

        [Column(Name = "OficinaPara")]
        public String OFICINA_PARA { get; set; }

        [Column(Name = "DistritoPara")]
        public String DISTRITO_PARA { get; set; }

        [Column(Name = "ProvinciaPara")]
        public String PROVINCIA_PARA { get; set; }

        [Column(Name = "Expedicion")]
        public String EXPEDICION { get; set; }



        [Column(Name = "Observado")]
        public String OBSERVADO { get; set; }

        [Column(Name = "RecibidoPor")]
        public String RECIBIDO_POR { get; set; }

        [Column(Name = "EntregadoPor")]
        public String ENTREGADO_POR { get; set; }

        public List<Cubo> rPrueba()
        {
            sql oSql = new sql();
            return oSql.Tabla<Cubo>("PcdPrueba");
        }
    }

}
