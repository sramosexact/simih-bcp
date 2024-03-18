using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Agencia : Core.Entity
    {
        #region Propiedades

        /*Variable evaluada para colorear*/
        public int Base { set; get; }

        [DataMember]
        public int iId { get; set; }
        [DataMember]
        public string sCodigoAgencia { get; set; }
        [DataMember]
        public string sDescripcion { get; set; }
        [DataMember]
        public int iIdGeoDireccion { get; set; }
        [DataMember]
        public int iTipo { get; set; }
        [DataMember]
        public int iActivo { get; set; }

        [DataMember]
        public Int16 iIdEncargadoAgencia { get; set; }

        public DateTime dFechaHora { get; set; }

        [DataMember]
        public string sDireccion { get; set; }
        [DataMember]
        public int idDistrito { get; set; }
        [DataMember]
        public int idProvincia { get; set; }
        [DataMember]
        public int idDepartamento { get; set; }

        [DataMember]
        public string sTipo { get; set; }
        [DataMember]
        public string sActivo { get; set; }

        [DataMember]
        public int IdTurno { get; set; }

        [DataMember]
        public string sTurno { get; set; }

        #endregion

        #region Metodos
        public string listarAgenciasPorTurno(Turno oTurno)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID_TURNO", oTurno.iIdTurno));
            return oSql.TablaParametroJSON("PC_ENTREGAAGENCIA_R_LISTARAGENCIASPORTURNOS", lP);

        }
        //2022
        public string obtenerAgenciaPorCodigo()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@CODIGO_AGENCIA", this.sCodigoAgencia));
            return oSql.TablaTopJson("SIMIH_ENTREGAAGENCIA_R_AGENCIAPORCODIGO", lP);
        }
        //2022
        public int CrearEnvioAgencias(string upn, string xmlLote, int colaborador)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            //lP.Add(new SqlParameter("@EXPEDICION", exp.ID));
            lP.Add(new SqlParameter("@COLABORADOR", colaborador));
            lP.Add(new SqlParameter("@LOTE", xmlLote));
            lP.Add(new SqlParameter("@UPN", upn));
            //lP.Add(new SqlParameter("@USUARIO", iIdUsuarioLogeado));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ENTREGAAGENCIA_C_AGENCIALOTE", lP));
        }

        public String ObtenerListadoAgencia()
        {
            return new sql().TablaJSON("PC_COMUN_R_LISTARAGENCIAS");
        }

        //2022
        public string ListarAgencias()
        {
            return new sql().TablaJSON("SIMIH_MANTENIMIENTOAGENCIA_R_LISTAR");
        }

        //2022
        public int CrearAgencia()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@CodigoAgencia", sCodigoAgencia));
            lP.Add(new SqlParameter("@Agencia", sDescripcion));
            lP.Add(new SqlParameter("@IdGeoDireccion", iIdGeoDireccion));
            lP.Add(new SqlParameter("@IdGrupo", iTipo));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOAGENCIA_C_AGENCIA", lP));
        }

        //2022
        public int ModificarAgencia()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@Id", iId));
            lP.Add(new SqlParameter("@Agencia", sDescripcion));
            lP.Add(new SqlParameter("@IdEstado", iActivo));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOAGENCIA_U_AGENCIA", lP));
        }
        //2022
        public int CambiarEstadoAgencia()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@Id", iId));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOAGENCIA_D_CAMBIAR_ESTADO", lP));
        }

        //2022
        public String ListarAgenciasNoVinculadasTurno()
        {
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdTurno", IdTurno));
            return new sql().TablaParametroJSON("SIMIH_MANTENIMIENTOAGENCIATURNO_R_NOVINCULADAS", lP);
        }

        //2022
        public String ListarAgenciasVinculadasTurno()
        {
            return new sql().TablaJSON("SIMIH_MANTENIMIENTOAGENCIATURNO_R_VINCULADAS");
        }

        //2022
        public int VincularAgenciaTurno()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID", IdTurno));
            lP.Add(new SqlParameter("@LISTAAGENCIAS", sDescripcion));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOAGENCIATURNO_C_VINCULAR", lP));
        }

        //2022
        public int EliminarVinculoAgenciaTurno()
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@IdAgencia", iId));
            lP.Add(new SqlParameter("@IdTurno", IdTurno));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOAGENCIATURNO_D_VINCULO", lP));
        }
        //2022
        public string listarAgenciasPalomarTurno(Turno oTurno, Palomar oPalomar)
        {
            sql oSql = new sql();
            List<SqlParameter> lP = new List<SqlParameter>();
            lP.Add(new SqlParameter("@ID_TURNO", oTurno.iIdTurno));
            lP.Add(new SqlParameter("@ID_PALOMAR", oPalomar.ID));
            return oSql.TablaParametroJSON("SIMIH_ENTREGAAGENCIA_R_LISTARAGENCIASPALOMARTURNO", lP);

        }
        #endregion

        #region "RVA"

        //2024
        public string ListarAgenciasActivasPorTipo(int tipoAgencia)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@TIPO", tipoAgencia));
            return oSql.TablaParametroJSON("RVA_WEB_AGENCIA_R_LISTAR_ACTIVAS_POR_TIPO", oP);
        }

        #endregion

    }
}
