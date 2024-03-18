using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Expedicion : Interna.Core.Entity
    {
        #region Propiedades
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string Prefijo { get; set; }
        [DataMember]
        public int IdGeo { get; set; }
        [DataMember]
        public string Geo { get; set; }
        [DataMember]
        public int IdCliente { get; set; }
        [DataMember]
        public int idCalle { get; set; }
        [DataMember]
        public string Ubicacion { get; set; }
        [DataMember]
        public int idDistrito { get; set; }
        [DataMember]
        public int idProvincia { get; set; }
        [DataMember]
        public int idDepartamento { get; set; }
        [DataMember]
        public int idTipoExpedicion { get; set; }
        [DataMember]
        public string TipoExpedicion { get; set; }

        [DataMember]
        public int iActivo { get; set; }

        public string sActivo
        {
            get
            {
                if (this.iActivo == 0)
                {
                    return "INACTIVO";
                }
                else
                {
                    return "ACTIVO";
                }
            }
        }

        // indicadors
        [Column(Name = "PORCUSTODIAR")]
        [DataMember]
        public int PorCustodiar { get; set; }

        [Column(Name = "CUSTODIA")]
        [DataMember]
        public int Custodia { get; set; }

        [Column(Name = "RUTA")]
        [DataMember]
        public int Ruta { get; set; }

        [DataMember]
        public String Cliente { get; set; }

        [DataMember]
        public String Casilla { get; set; }
        #endregion

        #region METODOS
        public string rListadoExpedicion(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", id));
            return oSql.TablaParametroJSON("EXI_R_EXPEDICION", oP);
        }
        public Expedicion rExpedicion(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idExpedicion", id));
            return oSql.TablaTop<Expedicion>("EXI_R_EXPEDICION_GEO", oP);
        }

        public List<Expedicion> rListadoExpedicionListaUsuario(Usuario O)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", O.ID));
            return oSql.TablaParametro<Expedicion>("EXI_R_EXPEDICION_LISTA_USUARIO", oP);
        }

        public List<Expedicion> rListadoExpedicionLista(Expedicion O, int RecordIndex, int Width)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", O.IdCliente));
            oP.Add(new SqlParameter("@EXPEDICION", O.Descripcion));
            oP.Add(new SqlParameter("@CASILLA", O.Casilla));
            oP.Add(new SqlParameter("@GEO", O.Geo));
            oP.Add(new SqlParameter("@RECORDINDEX", RecordIndex));
            oP.Add(new SqlParameter("@WIDTH", Width));
            return oSql.TablaParametro<Expedicion>("EXI_R_EXPEDICION_LISTA", oP);
        }

        public int ListaExpedicionCONTAR()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_R_EXPEDICION_LISTA_CONTAR");
        }

        //EXI_C_EXPEDICION

        public int cuGrabar(Expedicion oE)
        {
            int result = 0;
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", oE.IdCliente));
            oP.Add(new SqlParameter("@DESCRIPCION", oE.Descripcion));
            oP.Add(new SqlParameter("@TIPOEXPEDICION", oE.idTipoExpedicion));
            if (ID > 0) oP.Add(new SqlParameter("@IDGEO", oE.ID));
            else oP.Add(new SqlParameter("@IDGEO", oE.IdGeo));
            if (ID == 0)
                result = Convert.ToInt32(oSql.Escalar("EXI_C_EXPEDICION", oP));
            else
                result = Convert.ToInt32(oSql.Escalar("EXI_U_EXPEDICION", oP));
            return result;
        }
        public List<Expedicion> rExpedicionGeo()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDGEO", IdGeo));
            return oSql.TablaParametro<Expedicion>("EXI_R_EXPEDICION_DOMINIO", oP);
        }


        public String rListadoExpedicionListaUsuarioPrueba(Usuario O)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", O.ID));
            return oSql.TablaParametroJSON("EXI_R_EXPEDICION_LISTA_USUARIO", oP);
        }

        //2022
        public string ListarExpedicion()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("SIMIH_MANTENIMIENTOEXPEDICION_R_LISTAR");
        }
        //2022
        public String rListarExpediciones()
        {
            return new sql().TablaJSON("SIMIH_COMUN_R_LISTAREXPEDICIONES");
        }
        //2022
        public int NuevaExpedicion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@IdGeoDireccion", idCalle));
            oP.Add(new SqlParameter("@IdTipo", idTipoExpedicion));
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@Descripcion", Descripcion));
            oP.Add(new SqlParameter("@Prefijo", Prefijo));
            oP.Add(new SqlParameter("@Ubicacion", Geo));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOEXPEDICION_C_EXPEDICION", oP));
        }

        //2022
        public int ModificarExpedicion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            oP.Add(new SqlParameter("@IdGeoDireccion", idCalle));
            oP.Add(new SqlParameter("@IdTipo", idTipoExpedicion));
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@Descripcion", Descripcion));
            oP.Add(new SqlParameter("@Prefijo", Prefijo));
            oP.Add(new SqlParameter("@Ubicacion", Geo));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOEXPEDICION_U_EXPEDICION", oP));
        }

        //2022
        public int EliminarExpedicion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOEXPEDICION_D_EXPEDICION", oP));
        }

        //2022
        public int ActivarExpedicion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOEXPEDICION_U_ACTIVAR_EXPEDICION", oP));
        }

        //2023
        public string ListarExpediciones()
        {
            return new sql().TablaJSON("SIMIH_WEB_EXPEDICIONES_LISTAR");
        }


        #endregion
    }
}
