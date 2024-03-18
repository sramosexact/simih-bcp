using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Geo : Interna.Core.Entity
    {
        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public int IDCliente { get; set; }

        [DataMember]
        public int IDPadre { get; set; }

        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public String Pais { get; set; }

        [DataMember]
        public int IdPais { get; set; }

        [DataMember]
        public String Departamento { get; set; }

        [DataMember]
        public int IdDepartamento { get; set; }

        [DataMember]
        public String Provincia { get; set; }

        [DataMember]
        public int IdProvincia { get; set; }

        [DataMember]
        public String Distrito { get; set; }

        [DataMember]
        public int IdDistrito { get; set; }

        [DataMember]
        public String Calle { get; set; }

        [DataMember]
        public int IdCalle { get; set; }

        [DataMember]
        public String Oficina { get; set; }

        [DataMember]
        public int IdOficina { get; set; }

        [DataMember]
        public String Area { get; set; }

        [DataMember]
        public String Palomar { get; set; }


        public int IdPalomar { get; set; }

        [DataMember]
        public String Alias { get; set; }

        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public String Alias3 { get; set; }

        [DataMember]
        public int IdExpedicionDominio { get; set; }

        [DataMember]
        public string ExpedicionDominio { get; set; }

        // 21/05/2013 ACH: especial para frmBandejasAsociadasPuntoEntrega, frmGeo
        [DataMember]
        public String OficinaDescripcion { get; set; }
        // 22/05/2013 ACH: ahora se muestra la cantidad de bandejas asociadas en la grlla

        [DataMember]
        public int CantidadBandeja { get; set; }

        [DataMember]
        public string CodigoAgencia { get; set; }

        [DataMember]
        public string Agencia { get; set; }

        [DataMember]
        public int IdTipoDestino { get; set; }

        [DataMember]
        public string TipoDestino { get; set; }

        [DataMember]
        public int IdExpedicion { get; set; }

        [DataMember]
        public string Expedicion { get; set; }

        public List<Geo> rVerGeo()
        {
            sql oSql = new sql();
            return oSql.Tabla<Geo>("EXI_C_GEO");
        }


        public List<Geo> rVerGeo_puntoEntrega(int idUsuario, int idCliente)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            oP.Add(new SqlParameter("@IDCLIENTE", idCliente));
            return oSql.TablaParametro<Geo>("EXI_R_GEO_PUNTO_ENTREGA", oP);
        }

        public List<Geo> rVerGeo2(Interna.Entity.Cliente oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", oC.ID));
            return oSql.TablaParametro<Geo>("EXI_R_GEO", oP);
        }

        public List<Geo> rListarUbicaciones(int IdCliente)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));

            return oSql.TablaParametro<Geo>("EXI_R_GEO_UBICACIONES", oP);
        }

        public List<Geo> rListarOficinas(int IdCliente, int IdGeo, int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@IdExpedicion", idExpedicion));

            return oSql.TablaParametro<Geo>("EXI_R_GEO_OFICINAS", oP);
        }

        public int sCrearCalle(int IdCliente, string Calle, int IdDistrito)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@Calle", Calle));
            oP.Add(new SqlParameter("@IdDistrito", IdDistrito));

            return Convert.ToInt32(oSql.Escalar("EXI_C_GEO_GRABARCALLE", oP));
        }

        public List<Geo> sGrabarCalle(int IdCliente, int IdGeo, string Calle)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@Calle", Calle));

            return oSql.TablaParametro<Geo>("EXI_U_GEO_GRABARCALLE", oP);

        }
        //2022
        public int EliminarCalle(int IdCliente, int IdCalle)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdCalle", IdCalle));

            return Convert.ToInt32(oSql.Escalar("SIMIH_D_GEO_ELIMINARCALLE", oP));
        }

        public int sEliminarOficina(int IdCliente, int IdOficina)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", IdCliente));
            oP.Add(new SqlParameter("@IDAREA", IdOficina));

            return Convert.ToInt32(oSql.Escalar("PC_MANTENIMIENTOGEO_D_AREA", oP));
        }

        public List<Geo> sGrabarOficina(int IdCliente, int IdGeo, int iExpedicion, string Oficina, string Area)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdExpedicion", iExpedicion));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@Oficina", Oficina));
            oP.Add(new SqlParameter("@Area", Area));

            return oSql.TablaParametro<Geo>("PC_MANTENIMIENTOGEO_GRABARAREA", oP);
        }
        //2022
        public string CrearPuntoEntrega(int IdCliente, int IdGeo, int iExpedicion, string Oficina, string Area, string Agencia)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdExpedicion", iExpedicion));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@Oficina", Oficina));
            oP.Add(new SqlParameter("@Area", Area));
            oP.Add(new SqlParameter("@Agencia", Agencia));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOGEO_C_GRABARAREA", oP);
        }

        public Geo rGeo(int geo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdGeo", geo));
            return oSql.TablaTop<Geo>("EXI_R_GEOPADRE", oP);
        }

        //Control courier
        //Coordinacion
        public List<Geo> rListarUbicacion(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDPADRE", id));
            return oSql.TablaParametro<Geo>("EXI_R_UBICACION", oP);
        }
        /*César Baltazar - 24/08/2016 */
        public Expedicion uGeoExpedicionDominio()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDGEO", ID));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicionDominio));
            Expedicion oE = oSql.TablaTop<Expedicion>("PC_MANTENIMIENTOGEO_U_VINCULARDOMINIO", oP);
            return oE;
        }
        // Funcional - frmConsultaBandeja
        public string rObtenerDatosOficina(int IdGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", IdGeo));
            return oSql.TablaParametroJSON("EXI_R_OBTENER_DATOS_OFICINA", oP);
        }

        //Paginación Geo
        public List<Geo> rGeoLista(Geo oG, int RecordIndex, int Width)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", oG.IDCliente));
            oP.Add(new SqlParameter("@IdGeo", oG.ID));
            oP.Add(new SqlParameter("@IdExpedicion", oG.IdExpedicionDominio));
            oP.Add(new SqlParameter("@RECORDINDEX", RecordIndex));
            oP.Add(new SqlParameter("@WIDTH", Width));
            return oSql.TablaParametro<Geo>("EXI_R_GEO_PAG", oP);
        }

        public int rGeoListaContar(Geo oG)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", oG.IDCliente));
            oP.Add(new SqlParameter("@IdGeo", oG.ID));
            oP.Add(new SqlParameter("@IdExpedicion", oG.IdExpedicionDominio));
            return (int)oSql.Escalar("EXI_R_GEO_PAG_CONTAR", oP);
        }

        //Fin Paginación

        public List<Geo> sActualizarOficina(int IdCliente, int IdGeo, int IdOficina, string Oficina, string Area)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdOficina", IdOficina));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@Oficina", Oficina));
            oP.Add(new SqlParameter("@Area", Area));

            return oSql.TablaParametro<Geo>("PC_MANTENIMIENTOGEO_U_PUNTOENTREGA", oP);
        }


        public List<Geo> sActualizarOficina2(int IdCliente, int IdGeo, int IdOficina, string Oficina, string Area)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@Oficina", Oficina));
            oP.Add(new SqlParameter("@Area", Area));

            return oSql.TablaParametro<Geo>("EXI_U_GEO_OFICINA_AREA", oP);
        }

        public int sCrearDistrito(int IdCliente, string sGeo, int IdGeoPadre, int Nivel)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@sGeo", sGeo));
            oP.Add(new SqlParameter("@IdGeoPadre", IdGeoPadre));
            oP.Add(new SqlParameter("@iNivel", Nivel));

            return Convert.ToInt32(oSql.Escalar("EXI_C_GEO_2", oP)); //EXI_C_GEO_GRABAR_DISTRITO
        }

        public List<Geo> sGrabarDistrito(int IdCliente, int IdGeo, string sGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@sGeo", sGeo));

            return oSql.TablaParametro<Geo>("EXI_U_GEO_GRABAR_2", oP); //EXI_U_GEO_GRABAR_DISTRITO

        }
        //2022
        public string ListarUbicacionGeo(int IdCliente)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOGEO_R_LISTARGEO", oP);
        }
        //2022
        public string ListarPuntosEntrega(Geo oG)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", oG.IDCliente));
            oP.Add(new SqlParameter("@IdGeo", oG.ID));
            oP.Add(new SqlParameter("@IdExpedicion", oG.IdExpedicionDominio));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOGEO_R_LISTARAREA", oP);
        }

        public String cNuevaArea(int IdCliente, int IdGeo, int iExpedicion, string Oficina, string Area, string sCodigoAgencia, string sAgencia, int iTipo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdExpedicion", iExpedicion));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@Oficina", Oficina));
            oP.Add(new SqlParameter("@Area", Area));
            oP.Add(new SqlParameter("@CodigoAgencia", sCodigoAgencia));
            oP.Add(new SqlParameter("@Agencia", sAgencia));
            oP.Add(new SqlParameter("@TipoDestino", iTipo));
            return oSql.TablaParametroJSON("PC_MANTENIMIENTOGEO_C_GRABARAREA", oP);
        }

        public String uModificarArea(int IdCliente, int IdGeo, int iExpedicion, string Oficina, string Area, string sCodigoAgencia, string sAgencia, int iTipo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdExpedicion", iExpedicion));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@Oficina", Oficina));
            oP.Add(new SqlParameter("@Area", Area));
            oP.Add(new SqlParameter("@CodigoAgencia", sCodigoAgencia));
            oP.Add(new SqlParameter("@Agencia", sAgencia));
            oP.Add(new SqlParameter("@TipoDestino", iTipo));

            return oSql.TablaParametroJSON("PC_MANTENIMIENTOGEO_U_MODIFICARAREA", oP);
        }

        /*César 31/08/2016*/
        public String ListarPuntoEntregaExpedicion()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PC_MANTENIMIENTOEXPEDICION_R_LISTARGEO");
        }

        /*César 09/09/2016*/
        public String ListarPuntoEntregaAgencia()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PC_MANTENIMIENTOAGENCIA_R_LISTARGEO");
        }
        //2022
        public string ModificarPuntoEntrega(int IdCliente, int IdGeo, int IdGeoPadre, string Oficina, string Area, string Agencia)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCliente", IdCliente));
            oP.Add(new SqlParameter("@IdGeoPadre", IdGeoPadre));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            oP.Add(new SqlParameter("@Oficina", Oficina));
            oP.Add(new SqlParameter("@Area", Area));
            oP.Add(new SqlParameter("@Agencia", Agencia));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOGEO_U_PUNTOENTREGA", oP);
        }

        //2022
        public int EliminarPuntoEntrega(int iIdGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IIDGEO", iIdGeo));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOGEO_D_ELIMINARGEO", oP));
        }

        //2022
        public int ActualizarGeo()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdGeo", this.ID));
            oP.Add(new SqlParameter("@sDescripcion", this.Descripcion));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOGEO_U_GRABAR_GEO", oP));
        }
        //2022
        public int CrearGeo()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdGeoPadre", this.ID));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOGEO_C_GEO", oP));
        }
        //2022
        public string ListarDepartamento()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("SIMIH_MANTENIMIENTOUSUARIO_R_DEPARTAMENTOS");
        }
        //2022
        public string ListarProvincia(int IdDepartamento)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdDepartamento", IdDepartamento));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_PROVINCIAS", oP);
        }
        //2022
        public string ListarDistrito(int IdProvincia)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdProvincia", IdProvincia));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_DISTRITOS", oP);
        }
        //2022
        public string ListarCalle(int IdDistrito)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdDistrito", IdDistrito));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_CALLES", oP);
        }
        //2022
        public string ListarOficina(int IdCalle)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdCalle", IdCalle));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_OFICINAS", oP);
        }

        //2023 
        public int CrearBandejaFisica(string nombre, int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@nombre", nombre));
            oP.Add(new SqlParameter("@idExpedicion", idExpedicion));
            return Convert.ToInt32(oSql.Escalar("SIMIH_CREAR_BANDEJA_FISICA", oP));
        }

        //2023
        public string ListarBandejaFisica(int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idExpedicion", idExpedicion));
            return oSql.TablaParametroJSON("SIMIH_LISTAR_BANDEJA_FISICA", oP);
        }

        //2023
        public string ListarUbicacionesExpedicion(int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idExpedicion", idExpedicion));
            return oSql.TablaParametroJSON("SIMIH_LISTAR_UBICACIONES_EXPEDICION", oP);
        }

        //2023 
        public int AsociarUbicacionABandejaFisica(int idUbicacion, int idBandejaFisica)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idUbicacion", idUbicacion));
            oP.Add(new SqlParameter("@idBandejaFisica", idBandejaFisica));
            return Convert.ToInt32(oSql.Escalar("SIMIH_ASOCIAR_UBICACION_A_BANDEJA_FISICA", oP));
        }

        //2023 
        public int DesasociarUbicacionDeBandejaFisica(int idUbicacion, int idBandejaFisica)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idUbicacion", idUbicacion));
            oP.Add(new SqlParameter("@idBandejaFisica", idBandejaFisica));
            return Convert.ToInt32(oSql.Escalar("SIMIH_DESASOCIAR_UBICACION_DE_BANDEJA_FISICA", oP));
        }

        //2023
        public string ListarAreasPorExpedicion(int expedicionId)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@EXPEDICION", expedicionId));
            return oSql.TablaParametroJSON("SIMIH_WEB_AREAS_POR_EXPEDICION", oP);
        }
    }
}