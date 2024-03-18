using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Palomar : Interna.Core.Entity
    {
        #region CONSTRUCTORES

        public Palomar(int ID, int IdPadre, String Descripcion)
        {
            this.Descripcion = Descripcion;
            this.IdPadre = IdPadre;
            this.ID = ID;
        }

        public Palomar(int ID, String Descripcion)
        {
            this.Descripcion = Descripcion;
            this.ID = ID;
        }

        public Palomar(int ID)
        {
            this.ID = ID;
        }

        public Palomar()
        {
            this.ID = 0;
        }

        #endregion

        #region ATRIBUTOS
        [DataMember]
        public String Descripcion { get; set; }

        [Info(Min = 1, Max = 3)]
        [DataMember]
        public int IdTipoPalomar { get; set; }

        [Info(Min = 0)]
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int IdPadre { get; set; }

        [Info(Min = 0, Max = 1)]
        [DataMember]
        public int IdSistema { get; set; }

        [Info(Min = 0)]
        [DataMember]
        public int IdExpedicion { get; set; }

        [Info(CompleteWith = '*', Length = 5)]
        [DataMember]
        public string nombre { get; set; }

        [DataMember]
        public int IdTipoDestino { get; set; }

        [DataMember]
        public int IdGrupo { set; get; }

        [DataMember]
        public string Grupo { set; get; }

        public string sTipoDestino
        {
            get
            {
                if (this.IdTipoDestino == 269)
                {
                    return "PISOS";
                }
                else if (this.IdTipoDestino == 270)
                {
                    return "AGENCIAS LIMA";

                }
                else if (this.IdTipoDestino == 272)
                {
                    return "SUCURSALES";
                }
                else if (this.IdTipoDestino == 271)
                {
                    return "AGENCIAS PROVINCIA";
                }
                else
                {
                    return "";
                }
            }
        }

        [DataMember]
        public int Base
        {
            set;
            get;
        }

        #endregion

        #region METODOS

        public List<Palomar> rLista()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", 0));
            return oSql.TablaParametro<Palomar>("EXI_R_PALOMAR", oP);
        }

        public int cPalomarGrupo(int IdExpedicion, int iTipoDestino)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@IdTipoDestino", iTipoDestino));
            return (int)oSql.Escalar("PEXI_C_PALOMAR_GRUPO", oP);
        }

        public int cPalomar(int IdPadre)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdPadre", IdPadre));
            return (int)oSql.Escalar("PEXI_C_PALOMAR", oP);
        }

        public List<Geo> rListaGeo(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return oSql.TablaParametro<Geo>("EXI_R_PALOMAR_GEO", oP);
        }

        public List<Geo> rListaGrupoGeo(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return oSql.TablaParametro<Geo>("EXI_R_PALOMAR_GRUPO_GEO", oP);
        }

        public List<Geo> rListaExpedicionGeo(int Id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return oSql.TablaParametro<Geo>("EXI_R_PALOMAR_EXPEDICION_GEO", oP);
        }

        public List<Geo> rListaGeoPorPalomar(int Id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", Id));
            return oSql.TablaParametro<Geo>("EXI_R_GEO_PORPALOMAR", oP);
        }

        public List<Geo> rListaGeoPorAsignar(int Id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", Id));
            return oSql.TablaParametro<Geo>("EXI_R_GEO_PORASIGNAR", oP);
        }

        public int rCrearPalomarGeo(int IdPalomar, int IdGeo, int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDPalomar", IdPalomar));
            oP.Add(new SqlParameter("@IDGeo", IdGeo));
            oP.Add(new SqlParameter("@IDExpedicion", IdExpedicion));
            return (int)oSql.Escalar("EXI_C_GEO_ASIGNARPALOMAR", oP);
        }

        public List<Palomar> rLista(int IdCliente, int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdExpedicion", IdExpedicion));
            return oSql.TablaParametro<Palomar>("EXI_R_PALOMAR", oP);
        }

        public List<Palomar> rListaGrupo(int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", IdExpedicion));
            return oSql.TablaParametro<Palomar>("EXI_R_PALOMAR_GRUPOS", oP);
        }

        public List<Palomar> rListaGrupoTipo(int IdExpedicion, int IdTipoPalomar)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@ID_TIPOPALOMAR", IdTipoPalomar));
            return oSql.TablaParametro<Palomar>("EXI_R_PALOMAR_GRUPOS_TIPOS", oP);
        }

        public List<Palomar> rListaPalomarHijo(int IdExpedicion, int IdPalomarPadre)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@ID_PALOMAR", IdPalomarPadre));
            return oSql.TablaParametro<Palomar>("EXI_R_PALOMAR_HIJOS", oP);
        }

        public int uPalomar()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DESCRIPCION", this.Descripcion));
            oP.Add(new SqlParameter("@ID", this.ID));
            oP.Add(new SqlParameter("@IDPADRE", this.IdPadre));
            return (int)oSql.Escalar("EXI_U_PALOMAR", oP);
        }

        public int dPalomar(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return (int)oSql.Escalar("EXI_D_PALOMAR", oP);
        }

        public int dPalomarGrupo(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return (int)oSql.Escalar("EXI_D_PALOMAR_GRUPO", oP);
        }


        #endregion

        public int dAsignacionPalomar(int Id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", Id));
            return (int)oSql.Escalar("EXI_D_PALOMAR_ASIGNACION", oP);
        }

        public List<Geo> rListarGeoPalomar(int Id, int RecordIndex, int Width)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", Id));
            oP.Add(new SqlParameter("@RECORDINDEX", RecordIndex));
            oP.Add(new SqlParameter("@WIDTH", Width));
            return oSql.TablaParametro<Geo>("EXI_R_LISTA_GEO_PORPALOMAR", oP);
        }

        public int rListarGeoPalomarContar(int Id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", Id));
            return (int)oSql.Escalar("EXI_R_LISTA_GEO_PORPALOMAR_CONTAR", oP);
        }
        //2022
        public String rListarPalomaresExpedicionJSON(int iExpedicion, int iTipoDestino)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@IDTIPODESTINO", iTipoDestino));
            return oSql.TablaParametroJSON("SIMH_R_PALOMARES_EXPEDICION", oP);
        }

        public string rListaPalomarJSON(int IdCliente, int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdExpedicion", IdExpedicion));
            return oSql.TablaParametroJSON("PEXI_R_PALOMAR", oP);
        }

        /*VILLARREAL 02/10/2015*/
        public string rListaPalomarGrupoJSON(int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            return oSql.TablaParametroJSON("PEXI_R_PALOMAR_GRUPO_DESTINO", oP);
        }
        //2022
        public string rListaPalomarGrupoPisosJSON(int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            return oSql.TablaParametroJSON("SIMIH_R_PALOMAR_GRUPO_DESTINO_PISOS", oP);
        }
        //2022
        public string rListaPalomarPorGrupoJSON(int idExpedicion, int idGrupo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            oP.Add(new SqlParameter("@IDGRUPO", idGrupo));
            return oSql.TablaParametroJSON("SIMIH_R_PALOMARDESTINO", oP);
        }


        public List<string> rListaGeoPorTipoDestinoJSON(int iExpedicion, int iPalomar, int iTipoDestino)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            oP.Add(new SqlParameter("@IDPALOMAR", iPalomar));
            oP.Add(new SqlParameter("@IDTIPODESTINO", iTipoDestino));
            return oSql.ListaTablaParametroJSON("PEXI_R_GEO_POR_DESTINO", oP); //PEXI_R_GEO_POR_DESTINO 19/10/015
        }

        //2022
        public string ListaPalomarHijo(int IdExpedicion, int IdPalomarPadre)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_EXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@ID_PALOMAR", IdPalomarPadre));
            return oSql.TablaParametroJSON("SIMIH_R_PALOMAR_HIJOS", oP);
        }


        public string rListaPalomarGrupoAgenciaJSON(int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            return oSql.TablaParametroJSON("PEXI_R_PALOMAR_GRUPO_AGENCIAS", oP);
        }
        //2022
        public string rObtenerPalomaresEntregaAsociados(int idEntrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDENTREGA", idEntrega));
            return oSql.TablaParametroJSON("SIMIH_R_LISTAR_PALOMARES_ENTREGA", oP);
        }
        //2022
        public int rVerificarAutogeneradoValidadosPorPalomares(String detalle, int entrega)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DETALLE", detalle));
            oP.Add(new SqlParameter("@IDENTREGA", entrega));
            return (int)oSql.Escalar("SIMIH_R_AUTOGENERADO_ASOC_PALOMARES", oP);
        }
        /*César 14/09/2016*/
        public List<string> ListarGeoPalomar()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdExpedicion", IdExpedicion));
            oP.Add(new SqlParameter("@IdPalomar", ID));
            return oSql.ListaTablaParametroJSON("PC_MANTENIMIENTOPALOMAR_R_GEOPORASOCIAR", oP);
        }
        //2022
        public int NuevoPalomarGrupo(int IdExpedicion, int iTipoDestino)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdExpedicion", IdExpedicion));
            oP.Add(new SqlParameter("@IdTipoDestino", iTipoDestino));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOPALOMAR_C_GRUPO", oP);
        }
        //2022
        public int NuevoPalomar(int IdPadre)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdPalomarGrupo", IdPadre));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOPALOMAR_C_PALOMAR", oP);
        }
        //2022
        public int VincularPalomarPuntoEntrega(int IdPalomar, int IdGeo, int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDPalomar", IdPalomar));
            oP.Add(new SqlParameter("@IDGeo", IdGeo));
            oP.Add(new SqlParameter("@IDExpedicion", IdExpedicion));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOPALOMAR_C_VINCULARPUNTOENTREGA", oP);
        }
        //2022
        public int EliminarPalomar(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOPALOMAR_D_PALOMAR", oP);
        }
        //2022
        public string ListarPalomares(int IdCliente, int IdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdExpedicion", IdExpedicion));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOPALOMAR_R_LISTARPALOMAR", oP);
        }
        //2022
        public int DesvincularPalomarPuntoEntrega(int Id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", Id));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOPALOMAR_D_DESVINCULARPUNTOENTREGA", oP);
        }
        //2022
        public int ModificarPalomar(string sDescripcion, int iId, int iIdPadre)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DESCRIPCION", sDescripcion));
            oP.Add(new SqlParameter("@ID", iId));
            oP.Add(new SqlParameter("@IDPADRE", iIdPadre));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOPALOMAR_U_EDITARPALOMAR", oP);
        }
        //2022
        public int EliminarGrupoPalomar(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", ID));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOPALOMAR_D_GRUPOPALOMAR", oP);
        }
        //2022
        public String ListarPalomaresAgencia(int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdExpedicion", iExpedicion));
            return oSql.TablaParametroJSON("SIMIH_ENTREGAAGENCIA_R_GRUPOPALOMARESAGENCIA", oP);
        }
        //2022
        public string ListarGeoPorPalomar(int iIdPalomar)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdPalomar", iIdPalomar));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOPALOMAR_R_LISTARGEOPALOMAR", oP);
        }
        //2022
        public string ListarGeoPorAsociarAlPalomar(int iIdExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdExpedicion", iIdExpedicion));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOPALOMAR_R_GEO_POR_ASOCIAR_AL_PALOMAR", oP);
        }

    }
}
