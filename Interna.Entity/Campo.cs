using Interna.Core;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Interna.Entity
{
    [Serializable]
    public class Campo : Interna.Core.Entity
    {
        public int ID { get; set; }

        [Column(Name = "iId")]
        public int IdCampo { get; set; }

        public string Nombre { get; set; }
        public int IdCol { get; set; }
        public string Llave { get; set; }

        [Column(Name = "sCampoNombre")]
        public string Para { get; set; }

        public int IDTipoDocumento { get; set; }
        public int Plantilla { get; set; }
        public string Campobjeto { get; set; }

        // 17/07/2013
        // Josselin
        // Se agrega para visualizar campos en la vista previa
        // INICIO -->
        public int Display { get; set; }
        public Boolean DisplayBoolean
        {
            get
            {
                if (Display == 0) return false;
                return true;
            }
            set
            {
                if (value == false) this.Display = 0;
                else this.Display = 1;
            }
        }
        // <-- FIN

        // 18/07/2013
        // Alessandro Chipulina
        // Se agrega para soportar campos repetibles y agrupados
        // INICIO -->
        [Column(Name = "iRepetible")]
        [Info(Min = 0, Max = 1)]
        public int Repetible { get; set; }

        [Column(Name = "sCaracterDivisor")]
        [Info(Length = 1)]
        public String CaracterDivisor { get; set; }

        [Column(Name = "iGrupo")]
        [Info(Min = 1, Max = 12)]
        public int Grupo { get; set; }

        [Column(Name = "iImportancia")]
        [Info(Min = 0, Max = 5)]
        public int Importancia { get; set; }


        // <-- FIN


        public Campo()
        {
            Repetible = 0;
            Display = 0;
            CaracterDivisor = " ";
            Grupo = 1;
            Importancia = 0;
        }

        public List<Campo> rTipoCampo(int indicetipodoc)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@idTipoDocumento", indicetipodoc));
            return oSql.TablaParametro<Campo>("EXI_R_TIPO_CAMPO_2", oP);
        }



        //public List<Plantilla> loPlantillas()
        //{
        //    sql oSql = new sql();
        //    List<SqlParameter> oP = new List<SqlParameter>();

        //    oP.Add(new SqlParameter("@IDCLIENTE", Cliente));          
        //    return oSql.TablaParametro<Plantilla>("EXI_R_PLANTILLA_ACTIVA",oP);
        //}

        public static int ConvertirLlave(String columna, Worksheet ws)
        {

            int columnCount = ws.UsedRange.Columns.Count;

            for (int c = 1; c <= columnCount; c++)
            {
                string columnName = ws.Columns[c].Address;
                Regex reg = new Regex(@"(\$)(\w*):");
                if (reg.IsMatch(columnName))
                {
                    Match match = reg.Match(columnName);
                    columnName = match.Groups[2].Value;
                    if (columna.Equals(columnName))
                        return c;
                }
            }
            return 0;
        }

        public List<Campo> cargarCampos(int codplantilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDPLANTILLA", codplantilla));
            return oSql.TablaParametro<Campo>("EXI_R_PLANTILLA_DETALLE_ACTIVA", oP);
        }

        public List<Campo> cargarCamposObjDetalle(int IdObjeto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDOBJETO", IdObjeto));
            return oSql.TablaParametro<Campo>("EXI_R_CAMPOS_PLANTILLA_ACTIVOS", oP);
        }

        public List<Campo> CamposVisualesActivos(int IdTipoObjeto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@IDTIPOOBJETO", IdTipoObjeto));
            return oSql.TablaParametro<Campo>("EXI_R_CAMPOS_VISUALES_ACTIVOS", oP);
        }
    }
}
