using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    [Serializable]
    public class PlantillaGeneral : Interna.Core.Entity
    {
        #region Propiedades
        public int ID { get; set; }
        public int Cliente { get; set; }
        public int Expedicion { get; set; }
        public int CreadoPor { get; set; }
        public string NombreCreador { get; set; }
        public DateTime CreadoEl { get; set; }
        public int Plantilla { get; set; }
        public string Nombre { get; set; }
        public int TipoDocumento { get; set; }
        public string Documento { get; set; }
        public int Posicion { get; set; }
        public int Hoja { get; set; }
        public string Detalle { get; set; }
        public int Activo { get; set; }
        public string Cargar { get; set; }
        public string Eliminar { get; set; }
        public string Ruta { get; set; }

        public int Fila { get; set; }

        [Info(Length = 6, NoLeadingSpaces = true)]
        public string Guia { get; set; }
        public int MotivoCarga { get; set; }
        public int TipoLote { get; set; }
        public int TipoServicio { get; set; }
        //25/02/2014
        public int IdMensajeria { get; set; }
        public int IdCasillaOrigen { get; set; }
        public int IdCasillaDestino { get; set; }
        public int IdEstado { get; set; }
        public int Actualizacion { get; set; }

        #endregion

        public PlantillaGeneral()
        {
            Posicion = 1;
        }

        public int cPlantillaGeneral()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDCLIENTE", Cliente));
            oP.Add(new SqlParameter("@IDEXPEDICION", Expedicion));
            oP.Add(new SqlParameter("@TIPODOCUMENTO", TipoDocumento));
            oP.Add(new SqlParameter("@NOMBRE", Nombre.Trim()));
            oP.Add(new SqlParameter("@CREADOPOR", CreadoPor));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim().ToUpper().Replace('Ñ', 'N')));
            oP.Add(new SqlParameter("@POSICION", Posicion));
            oP.Add(new SqlParameter("@RUTA", Ruta.Trim()));

            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            int i = Convert.ToInt32((new sql()).Escalar("EXI_C_PLANTILLAGENERAL", oP));
            return i;
            //return iKey;
        }

        public int aPlantillaGeneral()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@CODIGO", ID));
            oP.Add(new SqlParameter("@IDEXPEDICION", Expedicion));
            oP.Add(new SqlParameter("@NOMBRE", Nombre.Trim()));
            oP.Add(new SqlParameter("@CREADOPOR", CreadoPor));
            oP.Add(new SqlParameter("@DETALLE", Detalle.Trim().ToUpper().Replace('Ñ', 'N')));
            oP.Add(new SqlParameter("@POSICION", Posicion));
            oP.Add(new SqlParameter("@RUTA", Ruta.Trim()));

            //iKey = Convert.ToInt32(oSql.Escalar("EXI_C_OBJETO_EXTERNO", oP));
            int i = Convert.ToInt32((new sql()).Escalar("EXI_U_PLANTILLAGENERAL", oP));
            return i;
            //return iKey;
        }

        public List<PlantillaGeneral> loPlantillasGeneral()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDCLIENTE", Cliente));
            return oSql.TablaParametro<PlantillaGeneral>("EXI_R_PLANTILLA_ACTIVA", oP);
        }

        public int uPlantillaGeneral()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@CODIGO", ID));
            oP.Add(new SqlParameter("@IDUSUARIO", CreadoPor));
            oP.Add(new SqlParameter("@IDEXPEDICION", Expedicion));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_PLANTILLA_DESACTIVA", oP));
        }

        public int CargarDatos()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDPLANTILLA", ID));
            oP.Add(new SqlParameter("@IDEXPEDICION", Expedicion));
            oP.Add(new SqlParameter("@IDSERVICIO", TipoServicio));
            oP.Add(new SqlParameter("@IDMENSAJERIA", IdMensajeria));
            oP.Add(new SqlParameter("@IDUSUARIO", CreadoPor));////////////////////
            oP.Add(new SqlParameter("@IDCASILLA_ORIGEN", IdCasillaOrigen));
            oP.Add(new SqlParameter("@IDCASILLA_DESTINO", IdCasillaDestino));
            oP.Add(new SqlParameter("@IDESTADO", IdEstado));
            oP.Add(new SqlParameter("@IDMOTIVOCARGA", MotivoCarga));


            oP.Add(new SqlParameter("@COORDINACION", TipoLote));
            oP.Add(new SqlParameter("@ACTUALIZACION", Actualizacion));
            oP.Add(new SqlParameter("@RUTA_ARCHIVO", Ruta));

            oP.Add(new SqlParameter("@GUIA", Guia));



            ////oP.Add(new SqlParameter("@IDPLANTILLA", ID));
            ////oP.Add(new SqlParameter("@IDEXPEDICION", Expedicion));
            ////oP.Add(new SqlParameter("@IDUSUARIO", CreadoPor));
            ////oP.Add(new SqlParameter("@MOTIVOCARGA", MotivoCarga));

            /////* UNICOS O INDIVIDUALeS ??? */
            ////oP.Add(new SqlParameter("@TIPOLOTE", TipoLote));
            ////// individual
            ////oP.Add(new SqlParameter("@TIPOSERVICIO", TipoServicio));
            ////oP.Add(new SqlParameter("@GUIA", Guia));

            // DETALLE
            Detalle = Detalle.Trim().ToUpper();

            for (int i = 21; i < 256; i++)
            {
                Char c = Char.ConvertFromUtf32(i)[0];
                String cc = Char.ConvertFromUtf32(i);
                if (!Char.IsLetterOrDigit(c))
                {
                    if (c != '@' && c != '#' && c != '<' && c != '>' && c != '/' && c != ':' && c != '.' && c != '-')
                        Detalle = Detalle.Replace(c, ' ');
                }
            }

            oP.Add(new SqlParameter("@DETALLE", Detalle));

            //  ()-./:<>@¿
            return Convert.ToInt32((new sql()).Escalar("EXI_C_PLANTILLA_CARGA_DATOS", oP));

        }


    }
}
