using Interna.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Casilla : Interna.Core.Entity
    {
        /*
         * PAGINACION 
         * */

        #region Propiedades 
        public int PageRecordIndex { get; set; }
        public int PageWidth { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        public String Correo { get; set; }

        [Info(Min = 0)]
        [Column(Name = "iId")]
        [DataMember]
        public int ID { get; set; }

        [Info(Min = 0)]
        [DataMember]
        public int IdCasilla { get; set; }

        public String Telefono { get; set; }

        [Column(Name = "IDGEO")]
        [DataMember]
        public int IdGeo { get; set; }

        [DataMember]
        public int IdCalle { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public String tipoCasilla { get; set; }

        [DataMember]
        public byte IdTipoCasilla { get; set; }

        [DataMember]
        public string sActivo { get; set; }

        [DataMember]
        public String estadoCasilla { get; set; }

        [Column(Name = "ACTIVO")]
        [DataMember]
        public int iActivo { get; set; }

        [DataMember]
        public String Ubicacion { get; set; }
        public int Preferencia { get; set; }

        [DataMember]
        public String Descripcion2 { get; set; }
        public String Statuss { get; set; }

        public String OFI { get; set; }

        [DataMember]
        public String AREA { get; set; }

        public int Enviado { get; set; }
        public int Custodia { get; set; }
        public int Ruta { get; set; }
        public int Recibido { get; set; }
        public int Confirmado { get; set; }

        /* INGRESOS Y SALIDAS */
        [DataMember]
        public int ECreado { get; set; }

        [DataMember]
        public int ECustodia { get; set; }

        [DataMember]
        public int ERuta { get; set; }

        [DataMember]
        public int ERecibido { get; set; }

        [DataMember]
        public int EConfirmado { get; set; }

        [DataMember]
        public int ETotal { get; set; }

        [DataMember]
        public int SCreado { get; set; }

        [DataMember]
        public int SCustodia { get; set; }

        [DataMember]
        public int SRuta { get; set; }

        [DataMember]
        public int SRecibido { get; set; }

        [DataMember]
        public int SConfirmado { get; set; }

        [DataMember]
        public int STotal { get; set; }

        /* INGRESOS Y SALIDAS */


        [DataMember]
        public String sDescripcion { get; set; }

        public int iId { get; set; }

        [DataMember]
        public String dFecha { get; set; }

        [Column(Name = "ESTADO")]
        [DataMember]
        public String Estado { get; set; }

        [DataMember]
        public int idUsuarioCasilla { get; set; }

        public String Usuario { get; set; }
        public String fechaIni { get; set; }
        public String fechaFin { get; set; }

        [DataMember]
        public String calle { get; set; }

        [DataMember]
        public String distrito { get; set; }

        public List<Casilla> Detalle { get; set; }

        [DataMember]
        public String idUsu { get; set; }

        [DataMember]
        public String sUsuario { get; set; }

        [DataMember]
        public String TipoAcceso { get; set; }

        [DataMember]
        public String tieneFac { get; set; }


        public String puntoEntregaFac { get; set; }

        [Column(Name = "ALIAS")]
        [DataMember]
        public string Alias { get; set; }

        public String Valor1 { get; set; }
        public String Valor2 { get; set; }
        public String Valor3 { get; set; }
        public String Valor4 { get; set; }
        public String Valor5 { get; set; }
        public String Estilo { get; set; }

        //CAMPOS REQUERIDOS

        public String IDCALLE { get; set; }
        public String IDDEPARTAMENTO { get; set; }
        public String IDPROVINCIA { get; set; }
        public String TIPO { set; get; }


        [DataMember]
        public int TipoDocumentoAsociado { get; set; }

        [DataMember]
        public int IdDepartamento { get; set; }
        [DataMember]
        public int IdProvincia { get; set; }
        [DataMember]
        public int IdDistrito { get; set; }

        #endregion


        #region Metodos
        //2022
        public string rBuscaTexto(Cliente oC, String texto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", oC.ID));
            oP.Add(new SqlParameter("@TEXTO", texto));
            return oSql.TablaParametroJSON("SIMIH_R_CASILLA", oP);

        }

        public string FetchMailList(string mail)
        {
            Casilla oCasilla = new Casilla();
            Cliente oCli = new Cliente();
            oCli.ID = 1;
            var fetchEmail = Casilla.deserializarJson<Casilla>(oCasilla.rBuscaTexto(oCli, "")).Where(m => (m.Descripcion + "-" + m.AREA).ToLower().StartsWith(mail.ToLower()));
            return JsonConvert.SerializeObject(fetchEmail.ToList());
        }

        public Casilla rBuscaID(int ID)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", ID));
            return oSql.TablaTop<Casilla>("EXI_R_CASILLA_ID", oP);
        }

        public Casilla rBuscaID2(int idCasilla, int idUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            oP.Add(new SqlParameter("@IDUSUARIO", idUsuario));
            return oSql.TablaTop<Casilla>("EXI_R_CASILLA_ID2", oP);
        }

        public int uCasilla()
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", ID));
            oP.Add(new SqlParameter("@TELEFONO", Telefono));
            oP.Add(new SqlParameter("@CORREO", Correo));
            oP.Add(new SqlParameter("@IDGEO", IdGeo));
            oP.Add(new SqlParameter("@PREFERENCIA", Preferencia));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            return (new sql()).Exec("EXI_U_CASILLA2", oP);
        }

        public List<Casilla> rBuscaActivacionCasilla(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", oC.ID));
            return oSql.TablaParametro<Casilla>("EXI_R_CASILLA_ESTADOS", oP);
        }

        public List<Casilla> rBuscaMenu(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", oC.ID));
            return oSql.TablaParametro<Casilla>("EXI_R_CASILLA_MENU", oP);
        }

        public Casilla rBuscarCorreoIguales(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@CORREO", oC.Descripcion));
            return oSql.TablaTop<Casilla>("EXI_R_CASILLA_CORREO_IGUALES", oP);
        }

        public int rValidarUsuario(Usuario oOU)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", oOU.IdCliente));
            oP.Add(new SqlParameter("@USUARIO", oOU.Codigo));
            return (Int32)oSql.Escalar("EXI_R_USUARIO", oP);
        }

        public List<Casilla> rCasillaDesactivadas(Usuario oU)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", oU.IdTipoCasilla));
            return oSql.TablaParametro<Casilla>("EXI_R_CASILLA_DESACTIVADAS", oP);
        }



        public int rCasillaActivarNueva(Casilla oC)
        {
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", oC.ID));
            return (new sql()).Exec("EXI_U_CASILLA_DESACTIVADAS", oP);
        }

        public Casilla rCuadro_de_Mando(int Cas)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO_CASILLA", Cas));
            return oSql.TablaTop<Casilla>("EXI_R_CUADRO_DE_MANDO", oP);
        }


        public List<Casilla> rConsultaBandejaTotal(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@BANDEJA", oC.sDescripcion));
            oP.Add(new SqlParameter("@USUARIO", oC.Usuario));
            oP.Add(new SqlParameter("@FECHA_INI", oC.fechaIni));
            oP.Add(new SqlParameter("@FECHA_FIN", oC.fechaFin));
            return oSql.TablaParametro<Casilla>("EXI_R_BANDEJA_TOTAL", oP);
        }

        public List<Casilla> rConsultaBandejaTotal_Detalle(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", oC.ID));
            return oSql.TablaParametro<Casilla>("EXI_R_BANDEJA_TOTAL_DETALLE", oP);
        }


        public List<Casilla> rConsultaBandejaUsuFacTotal_Detalle()
        {
            sql oSql = new sql();
            return oSql.Tabla<Casilla>("EXI_R_FAC_TOTAL_DETALLE");
        }

        public List<Casilla> rPlantillaGeo()
        {
            sql oSql = new sql();
            return oSql.Tabla<Casilla>("EXI_R_PLANTILLA_GEO");
        }

        public List<Casilla> rConsultaPorGeo(int IdGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDGEO", IdGeo));
            return oSql.TablaParametro<Casilla>("EXI_R_BANDEJA_GEO", oP);
        }

        public List<Casilla> rConsultaPorGeo(int IdGeo, int IdGeo2)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDGEO", 0));
            oP.Add(new SqlParameter("@IDGEO2", IdGeo2));
            return oSql.TablaParametro<Casilla>("EXI_R_BANDEJA_GEO", oP);
        }

        public int uCasillaCambioGeo(int IdGeo, int IdNuevoGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDGEO", IdGeo));
            oP.Add(new SqlParameter("@IDNUEVOGEO", IdNuevoGeo));
            int x = -1;
            try
            {
                x = (int)oSql.Escalar("EXI_U_CASILLA_CAMBIO_GEO", oP);
            }
            catch (Exception) { }
            return x;
        }

        public List<Casilla> rCasillaTipo(int IdTipo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDTIPO", IdTipo));
            return oSql.TablaParametro<Casilla>("EXI_R_CASILLA_TIPO", oP);
        }

        public List<Casilla> rConsultaBandejaTotal_PAG(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@BANDEJA", oC.sDescripcion));
            oP.Add(new SqlParameter("@USUARIO", oC.Usuario));
            oP.Add(new SqlParameter("@RECORDINDEX", oC.PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", oC.PageWidth));
            oP.Add(new SqlParameter("@OPCION", oC.Preferencia));
            return oSql.TablaParametro<Casilla>("EXI_R_BANDEJA", oP);
        }

        public int GetConsultaBandejaTotalCONTAR(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@BANDEJA", oC.sDescripcion));
            oP.Add(new SqlParameter("@USUARIO", oC.Usuario));
            return (int)oSql.Escalar("EXI_R_BANDEJA_CONTAR", oP);

        }

        public List<Casilla> rConsultaBandejaActiva()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            return oSql.Tabla<Casilla>("EXI_R_BANDEJA_ACTIVA");
        }

        public int uVincularCasilla(int IdCasilla, int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", IdCasilla));
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            return (int)oSql.Escalar("EXI_U_CASILLA_VINCULAR", oP);
        }
        //2022
        public List<Casilla> CasillaUsuario(int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", IdUsuario));
            return oSql.TablaParametro<Casilla>("SIMIH_R_CASILLA_USUARIO", oP);
        }

        //2023
        public List<Casilla> BandejasUsuario(int usuarioId)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", usuarioId));
            return oSql.TablaParametro<Casilla>("SIMIH_WEB_BANDEJAS_USUARIO", oP);
        }

        public List<Casilla> CasillaActiva()
        {
            sql oSql = new sql();
            return oSql.Tabla<Casilla>("EXI_R_BANDEJA_ACTIVA");
        }


        public List<Casilla> rCasillaConfiguracion(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", oC.ID));
            return oSql.TablaParametro<Casilla>("EXI_R_CONFIGURACION_BANDEJA", oP);
        }
        //2022
        public List<Casilla> rBuscarCasillas(string texto, int pagina)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@Dato", texto));
            oP.Add(new SqlParameter("@Pagina", pagina));
            return oSql.TablaParametro<Casilla>("SIMIH_WEB_R_ObtenerBandejas", oP);
        }

        public List<Casilla> ConfiguracionBandejaWEB(string jsonSTRING)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@CADENA", jsonSTRING));
            return oSql.TablaParametro<Casilla>("WEXI_R_CONFIGURACION", oP);
        }

        //2022
        public String rObtenerDescripcion(string palabra)
        {
            sql Osql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@PALABRA", palabra));
            return Osql.TablaParametroJSON("SIMIH_BUSCA_R_BANDEJA", oP);
        }
        //2022
        public string rObtenerConfiguracionls(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", id));
            return oSql.TablaParametroJSON("SIMIH_R_CASILLA_USUARIO_CONFIGURACION", oP);
        }
        // Funcional - frmConsultaBandeja
        public List<string> rConsultaBandejaTotal_PAGJson(Casilla oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@BANDEJA", oC.sDescripcion));
            oP.Add(new SqlParameter("@OPCION", oC.Preferencia));
            return oSql.ListaTablaParametroJSON("PEXI_R_BANDEJA_PRUEBA", oP);
        }
        // Funcional - frmConsultaBandeja
        public string rConsultaPorGeoJson(int idGeo, int IdGeo2)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDGEO", 0));
            oP.Add(new SqlParameter("@IDGEO2", IdGeo2));
            return oSql.TablaParametroJSON("EXI_R_BANDEJA_GEO_PRUEBA", oP);
        }
        //2022
        public string BandejaUsuarioExpedicion(string upn, int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@UPN", upn));
            oP.Add(new SqlParameter("@IDEXPEDICION", iExpedicion));
            return oSql.TablaParametroJSON("SIMIH_R_BANDEJA_USUARIO_EXPEDICION", oP);
        }

        //2022
        public string ListarBandejaExpedicion(int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdExpedicion", iExpedicion));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_BANDEJAEXPEDICION", oP);
        }

        //2022
        public string ListarBandeja()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("SIMIH_MANTENIMIENTOBANDEJA_R_LISTAR");
        }

        //2022
        public int CrearBandeja()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@Descripcion", sDescripcion));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOBANDEJA_C_BANDEJA", oP);
        }

        //2022
        public int ModificarBandeja()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@NuevaDescripcion", sDescripcion));
            oP.Add(new SqlParameter("@IdBandeja", ID));
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            return (int)oSql.Escalar("SIMIH_MANTENIMIENTOBANDEJA_U_BANDEJA", oP);
        }

        /*César - 03/10/2016*/
        public string ListarBandejaNoAsociada(int iUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdUsuario", iUsuario));
            return oSql.TablaParametroJSON("PC_MANTENIMIENTOBANDEJA_R_LISTARNOASOCIADAS", oP);
        }


        /*César - 25/11/2016*/
        public string ListarBandejaTipoDocumento()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PC_MESAPARTES_R_BANDEJATIPODOCUMENTO");
        }

        /*César - 12/01/2017*/
        public int CambiarEstadoBandeja()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdBandeja", ID));
            if (iActivo == 1)
            {
                return (int)oSql.Escalar("PC_MANTENIMIENTOBANDEJA_U_DAR_DE_ALTA", oP);
            }
            else
            {
                return (int)oSql.Escalar("PC_MANTENIMIENTOBANDEJA_U_DAR_DE_BAJA", oP);
            }

        }

        public string ListarCasillasPorAsociarAlTipoDocumento()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@sDescripcionCasilla", sDescripcion));
            return oSql.TablaParametroJSON("PC_MANTENIMIENTOTIPODOCUMENTO_R_CASILLA_POR_ASOCIAR", oP);
        }

        public string ListarBandejasPorGeo(int IdGeo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdGeo", IdGeo));
            return oSql.TablaParametroJSON("PC_CASILLA_R_LISTAR_POR_GEO", oP);
        }

        #endregion
    }
}
