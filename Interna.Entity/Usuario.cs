using Interna.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Usuario : Interna.Core.Entity
    {
        #region PROPIEDADES
        /*
         * PAGINACION 
         * */
        public int PageRecordIndex { get; set; }
        public int PageWidth { get; set; }
        // Codigo tal como lo conoce el cliente
        // Ej: cbaltazar, U15467
        //Valor del campo sUsuario de la tabla Usuario
        [Column(Name = "Usuario")]
        [DataMember]
        public String Codigo { get; set; }

        [DataMember]
        public String sMatricula { get; set; }

        //Valor del campo sCodigo de la tabla Usuario
        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public int IdCliente { get; set; }

        [DataMember]
        public int ID { get; set; }

        // Tipo de Casilla Permitido para este usuario
        [DataMember]
        public int IdTipoCasilla { get; set; }

        [DataMember]
        public int iActivo { get; set; }

        [DataMember]
        public string sActivo { get; set; }

        // Permisos activos sobre la aplicacion
        // Valor del campo iIdTipoAcceso de la tabla Usuario
        [DataMember]
        public int IdTipoAcceso { get; set; }

        [DataMember]
        public byte iUsaPDA { get; set; }

        [DataMember]
        public int SoportaCasilla { get; set; }

        [DataMember]
        public int IdExpedicion { get; set; }

        [DataMember]
        public int Modo { get; set; }

        public string Aplicacion { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Expedicion { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public string Usu { get; set; }

        [DataMember]
        public string Correo { get; set; }

        [DataMember]
        public string Geo { get; set; }

        [DataMember]
        public string Estado { get; set; }
        public string sCodigo { get; set; }

        [DataMember]
        public string Cliente { get; set; }

        [DataMember]
        public string esFAc { get; set; }

        [DataMember]
        public int NROCASILLA { get; set; }

        [DataMember]
        public int idCasilla { get; set; }

        [DataMember]
        public int idGeo { get; set; }

        public string Cas { get; set; }

        [DataMember]
        public string alias { get; set; }

        public int usuFac { get; set; }

        [DataMember]
        public int Preferida { get; set; }

        [DataMember]
        public string area { get; set; }

        public string oficina { get; set; }

        [DataMember]
        public int idGeoCasilla { set; get; }

        [DataMember]
        public string descripcionCasilla { get; set; }

        [DataMember]
        public string idCas { get; set; }

        public int idEquipo { get; set; }

        public int iCesado { get; set; }

        [DataMember]
        public string sCesado { get; set; }

        [DataMember]
        public int IdTipoExpedicion { get; set; }

        [DataMember]
        public string sDominio { get; set; }

        [DataMember]
        public string sDni { get; set; }

        [DataMember]
        public int IdDepartamento { get; set; }
        [DataMember]
        public int IdProvincia { get; set; }
        [DataMember]
        public int IdDistrito { get; set; }
        [DataMember]
        public int IdCalle { get; set; }
        [DataMember]
        public int IdOficina { get; set; }

        [DataMember]
        public string sCodigoAgencia { get; set; }
        [DataMember]
        public string sAgencia { get; set; }
        [DataMember]
        public int iIdProveedor { get; set; }

        #endregion
        public List<Usuario> Detalle { get; set; }




        public Usuario()
        {

            Codigo = string.Empty;
            //Descripcion = string.Empty;
            IdCliente = 0;
            //ID = 0;
            //IdTipoCasilla = 0;
            iActivo = 0;
            IdTipoAcceso = 0;
            SoportaCasilla = 0;
            IdExpedicion = 0;
            Modo = 0;
            Aplicacion = string.Empty;
            //Nombre = string.Empty;
            Password = string.Empty;
            Expedicion = string.Empty;
            Tipo = string.Empty;
            Usu = string.Empty;
            Correo = string.Empty;
            Geo = string.Empty;
            Estado = string.Empty;
            sCodigo = string.Empty;
            Cliente = string.Empty;
            NROCASILLA = 0;
            idCasilla = 0;
            idGeo = 0;
            Cas = string.Empty;
            usuFac = 0;
            Preferida = 0;
            iCesado = 0;
            IdTipoExpedicion = 0;
        }

        public List<Interna.Entity.Usuario> rListadoTipo()
        {
            sql oSql = new sql();
            return oSql.Tabla<Interna.Entity.Usuario>("EXI_R_USUARIO_TIPOS");
        }
        //2022
        public List<Interna.Entity.Usuario> rListadoCliente(String id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@USUARIO", id));
            return oSql.TablaParametro<Interna.Entity.Usuario>("SIMIH_R_CLIENTE", oP);
        }
        //2022
        public string ListarCliente(String id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@USUARIO", id));
            return oSql.TablaParametroJSON("SIMIH_R_CLIENTE", oP);
        }

        public string Usuarios(String id, int PageRecordIndex, int PageWidth)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@CLIENTE", id));
            oP.Add(new SqlParameter("@RECORDINDEX", PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", PageWidth));
            return oSql.TablaParametroJSON("EXI_R_USUARIOS", oP);
        }

        public int UsuariosCONTAR(String id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@CLIENTE", id));
            return (int)oSql.Escalar("EXI_R_USUARIOS_CONTAR", oP);
        }

        public string rListadoUsuario_Casilla(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDSUARIO", id));
            return oSql.TablaParametroJSON("EXI_R_USUARIO_CASILLA", oP);
        }

        public int c_Usuario()
        {
            int res = 0;
            sql oSql = new sql("1");
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@APLICACION", Aplicacion));
            oP.Add(new SqlParameter("@CLIENTE", Cliente));
            oP.Add(new SqlParameter("@USUARIO", Usu));
            oP.Add(new SqlParameter("@PASSWORD", Password));
            oP.Add(new SqlParameter("@CORREO", Correo));
            oP.Add(new SqlParameter("@SOPORTA_CASILLA", SoportaCasilla));
            oP.Add(new SqlParameter("@TIPO_USUARIO", IdTipoAcceso));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@CODIGO", sCodigo));
            oP.Add(new SqlParameter("@MODO", Modo));
            oP.Add(new SqlParameter("@EQUIPO", idEquipo));
            oP.Add(new SqlParameter("@CESADO", iCesado));
            res = Convert.ToInt32(oSql.Escalar("SEG_C_USUARIO", oP));
            return res;
        }

        public int u_Casilla_Desvinculacion()
        {
            sql oSql = new sql("1");
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", ID));
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            return (Int32)oSql.Escalar("SEG_U_CASILLA_DESVINCULAR", oP);
        }

        public int u_Casilla(int opcion, int idoficina)
        {
            sql oSql = new sql("1");
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            oP.Add(new SqlParameter("@ALIAS", alias));
            //oP.Add(new SqlParameter("@DEPARTAMENTO", oG.IdDepartamento));
            //oP.Add(new SqlParameter("@PROVINCIA", oG.IdProvincia));
            //oP.Add(new SqlParameter("@DISTRITO", oG.IdDistrito));
            //oP.Add(new SqlParameter("@CALLE", oG.IdCalle));
            oP.Add(new SqlParameter("@IDOFICINA", idoficina));
            oP.Add(new SqlParameter("@OPCION", opcion));
            oP.Add(new SqlParameter("@BANDEJA", Descripcion));
            return (Int32)oSql.Escalar("SEG_R_CASILLA", oP);
        }

        public int u_Usuario()
        {
            sql oSql = new sql("1");
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", ID));
            oP.Add(new SqlParameter("@CODIGO", Codigo));
            oP.Add(new SqlParameter("@USUARIO", Usu));
            oP.Add(new SqlParameter("@AUTENTICACION", Modo));
            oP.Add(new SqlParameter("@SOPORTA_CASILLA", SoportaCasilla));
            oP.Add(new SqlParameter("@CORREO", Correo));
            oP.Add(new SqlParameter("@PASSWORD", Password));
            oP.Add(new SqlParameter("@ACTIVO", iActivo));
            oP.Add(new SqlParameter("@IDEXPEDICION", IdExpedicion));
            oP.Add(new SqlParameter("@EQUIPO", idEquipo));
            oP.Add(new SqlParameter("@CESADO", iCesado));
            return (Int32)oSql.Escalar("SEG_U_USUARIO", oP);
        }

        public int d_Usuario()
        {
            sql oSql = new sql("1");
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", ID));
            return (Int32)oSql.Escalar("SEG_D_USUARIO", oP);
        }

        public Usuario rObtenerUsuario(int id)
        {
            sql oSql = new sql("1");
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", id));
            return oSql.TablaTop<Usuario>("EXI_R_OBTENER_USUARIO", oP);
        }

        //2022
        public Usuario rUsuario_Val()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            if (Usu == null) Usu = "";
            if (Password == null) Password = "";
            oP.Add(new SqlParameter("@IDCLIENTE", IdCliente));
            oP.Add(new SqlParameter("@USUARIO", Usu.ToLower()));
            oP.Add(new SqlParameter("@PASSWORD", Password));
            oP.Add(new SqlParameter("@MODO", Modo));
            Usuario oUsuario = oSql.TablaTop<Usuario>("SIMIH_USUARIOSEGURIDAD_R_VALIDAR", oP);
            return oUsuario;
        }
        //2022
        public Usuario rUsuario_Val_NT()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", IdCliente));
            oP.Add(new SqlParameter("@USUARIO", Usu));
            oP.Add(new SqlParameter("@DOMINIO", sDominio));
            return oSql.TablaTop<Usuario>("SIMIH_USUARIO_SEGURIDAD_R_VALIDAR_NT", oP); //SIMIH_USUARIO_SEGURIDAD_R_VALIDAR_NT2
        }


        public int c_Casilla()
        {
            sql oSql = new sql("1");
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", ID));
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            oP.Add(new SqlParameter("@CASILLA", Cas));
            oP.Add(new SqlParameter("@IDGEO", idGeo));
            oP.Add(new SqlParameter("@ALIAS", alias));
            return Convert.ToInt32(oSql.Escalar("SEG_C_CASILLA", oP));
        }

        public int d_Casilla()
        {
            sql oSql = new sql("1");
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            oP.Add(new SqlParameter("@IDUSUARIO", ID));
            return (Int32)oSql.Escalar("SEG_D_CASILLA", oP);
        }

        public List<Interna.Entity.Usuario> rObtenerCasillas(int idCliente, String texto, int idUS)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", idCliente));
            oP.Add(new SqlParameter("@TEXTO", texto));
            oP.Add(new SqlParameter("@IDUSUARIO", idUS));
            return oSql.TablaParametro<Usuario>("EXI_R_CASILLA_2", oP);
        }


        public List<Interna.Entity.Usuario> rObtenerCasillas2(int idCliente, String texto)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCLIENTE", idCliente));
            oP.Add(new SqlParameter("@TEXTO", texto));
            return oSql.TablaParametro<Usuario>("EXI_R_CASILLA_PC", oP);
        }


        public int u_Usuario_Fac()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", ID));
            oP.Add(new SqlParameter("@IDGEO", idGeo));
            return (Int32)oSql.Escalar("EXI_U_USUARIO_FAC", oP);
        }

        public int d_Usuario_Fac(Interna.Entity.Usuario us)
        {
            Usuario u = us;
            sql oSql = new sql();

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDUSUARIO", u.ID));
            oP.Add(new SqlParameter("@IDGEO", u.idGeo));
            return (Int32)oSql.Escalar("EXI_D_USUARIO_FAC", oP);
        }

        public List<Interna.Entity.Usuario> rListarUsuarioFac()
        {
            sql oSql = new sql();
            return oSql.Tabla<Usuario>("EXI_R_FAC_TOTAL");
        }

        public List<Usuario> rConsultaBandejaUsuFacTotal_Detalle2()
        {
            sql oSql = new sql();
            return oSql.Tabla<Usuario>("EXI_R_FAC_TOTAL_DETALLE");
        }

        public List<Usuario> r_Consulta_FAC_TOTAL(Usuario oUsu)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@RECORDINDEX", oUsu.PageRecordIndex));
            oP.Add(new SqlParameter("@WIDTH", oUsu.PageWidth));
            return oSql.TablaParametro<Usuario>("EXI_R_CONSULTA_FAC_TOTAL", oP);
        }

        public int GetConsulta_FAC_TOTALCONTAR()
        {
            sql oSql = new sql();
            return (int)oSql.Escalar("EXI_R_CONSULTA_FAC_TOTAL_CONTAR");
        }

        public int VerificarEstadoCasilla()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDCASILLA", idCasilla));
            return (Int32)oSql.Escalar("EXI_U_VERIFICAR_CASILLA", oP);
        }

        public List<Interna.Entity.Usuario> rObtenerUsuarioDato(String Dato)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DATO", Dato));
            return oSql.TablaParametro<Usuario>("EXI_R_USUARIO_DATOS", oP);
        }
        //2022
        public List<Usuario> rObtenerUsuarioDato1(String Dato, int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DATO", Dato));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            return oSql.TablaParametro<Usuario>("SIMIH_R_USUARIO_DATOS", oP);
        }
        //2022
        public Interna.Entity.Usuario Login(String a, String b)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@Usuario", a.ToLower().Trim()));
            oP.Add(new SqlParameter("@Clave", b.Trim()));
            return oSql.TablaTop<Usuario>("SIMIH_R_ObtenerUsuario", oP);
        }
        //INTRODUCIDO 26/08/2015
        public String UsuariosJson(String id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@CLIENTE", id));
            return oSql.TablaParametroJSON("EXI_R_USUARIOS_PRUEBA", oP);
        }
        public String rListadoUsuario_CasillaJson(int id)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDSUARIO", id));
            return oSql.TablaParametroJSON("EXI_R_USUARIO_CASILLA_PRUEBA", oP);
        }
        /*Villarreal 02/10/2015*/
        public String rListaOperativos(int idExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            return oSql.TablaParametroJSON("PEXI_R_OPERATIVO", oP);
        }

        public String rValidarSup(int idExpedicion, String dato)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DATO", dato));
            oP.Add(new SqlParameter("@IDEXPEDICION", idExpedicion));
            return oSql.TablaParametroJSON("PEXI_R_USUARIO_DATOS", oP);
        }
        //2022
        public String ListarColaboradoresExpedicion(int iExpedicion)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdExpedicion", iExpedicion));
            return oSql.TablaParametroJSON("SIMIH_ENTREGAAGENCIA_R_COLABORADORES", oP);
        }

        /*César - 20/09/2016*/
        public String ListarUsuarios()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PC_MANTENIMIENTOUSUARIO_R_LISTAR");
        }

        /*César - 21/09/2016*/
        public String ListarTipoUsuario()
        {
            sql oSql = new sql();
            return oSql.TablaJSON("PC_MANTENIMIENTOUSUARIO_R_TIPOUSUARIO");
        }
        //2022
        public int CrearUsuario()
        {
            sql oSql = new sql();

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@NombreUsuario", Descripcion));
            oP.Add(new SqlParameter("@NombreBandeja", Descripcion));
            oP.Add(new SqlParameter("@Matricula", sMatricula));
            oP.Add(new SqlParameter("@Dominio", sDominio));
            oP.Add(new SqlParameter("@CodigoUsuario", Codigo));
            oP.Add(new SqlParameter("@TipoAutenticacion", Modo));
            oP.Add(new SqlParameter("@Password", Password));
            oP.Add(new SqlParameter("@TipoAcceso", IdTipoAcceso));
            oP.Add(new SqlParameter("@Expedicion", IdExpedicion));
            oP.Add(new SqlParameter("@BandejaExpedicion", idCasilla));
            oP.Add(new SqlParameter("@OficinaArea", idGeo));
            oP.Add(new SqlParameter("@Dni", sDni));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_C_USUARIO", oP));
        }
        //2022
        public int ModificarUsuario()
        {
            sql oSql = new sql();

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdUsuario", ID));
            oP.Add(new SqlParameter("@NombreUsuario", Descripcion));
            oP.Add(new SqlParameter("@NombreBandeja", Descripcion));
            oP.Add(new SqlParameter("@Matricula", sMatricula));
            oP.Add(new SqlParameter("@TipoAutenticacion", Modo));
            oP.Add(new SqlParameter("@Password", Password));
            oP.Add(new SqlParameter("@iIdGeo", idGeoCasilla));
            oP.Add(new SqlParameter("@TipoAcceso", IdTipoAcceso));
            oP.Add(new SqlParameter("@Expedicion", IdExpedicion));
            oP.Add(new SqlParameter("@BandejaExpedicion", idCasilla));
            oP.Add(new SqlParameter("@Dni", sDni));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_U_USUARIO", oP));
        }

        //2022
        public string ListarUsuarioBandejaAsociado()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdBandeja", idCasilla));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOBANDEJA_R_USUARIOASOCIADO", oP);
        }

        //2022
        public string ListarUsuarioBandejaNoAsociado()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdBandeja", idCasilla));
            oP.Add(new SqlParameter("@sDescripcionUsuario", Descripcion));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOBANDEJA_R_USUARIONOASOCIADO", oP);
        }

        /*César - 03/10/2016*/
        public List<String> ListarUsuarioBandejaResponsable()
        {
            sql oSql = new sql();

            Encryption.Encrypt encrypt = new Encryption.Encrypt();

            List<string> listas = oSql.ListaTablaJSON("PC_MANTENIMIENTOUSUARIO_R_USUARIOBANDEJAFAC");
            List<Dictionary<string, object>> Encriptados0 = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(listas[0]);
            List<Dictionary<string, object>> Desencriptados0 = encrypt.Desencriptar(Encriptados0, "Descripcion", "sMatricula", "Codigo", "sDni");
            List<string> listasD = new List<string>();
            listasD.Add(JsonConvert.SerializeObject(Desencriptados0));
            listasD.Add(listas[1]);
            listasD.Add(listas[2]);
            return listasD;
        }
        //2022
        public List<string> ListarBandejaAsociada(int idUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID_USUARIO", idUsuario));
            return oSql.ListaTablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_USUARIOBANDEJAFAC", oP);
        }
        //2022
        public int DarDeBajaUsuario(int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", IdUsuario));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_U_DAR_DE_BAJA", oP));
        }

        //2022
        public int DarDeAltaUsuario(int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", IdUsuario));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_U_DAR_DE_ALTA", oP));
        }

        //2022
        public int VincularUsuarioBandeja()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdBandeja", idCasilla));
            oP.Add(new SqlParameter("@iIdUsuario", ID));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_U_VINCULAR_USUARIO_BANDEJA", oP));
        }
        //2022
        public int DesvincularUsuarioBandeja()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdBandeja", idCasilla));
            oP.Add(new SqlParameter("@iIdUsuario", ID));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_U_DESVINCULAR_USUARIO_BANDEJA", oP));
        }
        //2022
        public string ListarBandejasAsociadasAlUsuario()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", ID));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_BANDEJASASOCIADAS", oP);
        }
        //2022
        public string ListarBandejasNoAsociadasAlUsuario()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", ID));
            oP.Add(new SqlParameter("@sDescripcionBandeja", descripcionCasilla));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_BANDEJASNOASOCIADAS", oP);
        }
        //2022
        public string ListarAgenciasVinculadasAlUsuario()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", ID));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_AGENCIASASOCIADAS", oP);
        }
        //2022
        public string ListarAgenciasNoVinculadasAlUsuario()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", ID));
            oP.Add(new SqlParameter("@sDescripcionAgencia", Descripcion));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_AGENCIASNOASOCIADAS", oP);
        }
        //2022
        public int VincularEncargadoAgencia(EncargadoAgencia encargadoAgencia)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", encargadoAgencia.iIdUsuario));
            oP.Add(new SqlParameter("@iIdAgencia", encargadoAgencia.iIdAgencia));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_U_VINCULAR_ENCARGADO_AGENCIA", oP));
        }
        //2022
        public int DesvincularEncargadoAgencia(EncargadoAgencia encargadoAgencia)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdEncargado_Agencia", encargadoAgencia.iIdEncargadoAgencia));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_D_DESVINCULAR_ENCARGADO_AGENCIA", oP));
        }
        //2022
        public int VerificarSiUsuarioEsDeAgencia(int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", IdUsuario));
            return Convert.ToInt32(oSql.Escalar("SIMIH_MANTENIMIENTOUSUARIO_VERIFICARUSUARIOAGENCIA", oP));

        }
        //2022
        public string UsuarioSeleccionado(int IdUsuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdUsuario", IdUsuario));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_USUARIO", oP);
        }

        public string ListarAreaSedeUsuario()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@iIdUsuario", ID));
            return oSql.TablaParametroJSON("WEB_RECLAMO_LISTAR_SEDEAREA_BANDEJA_PREDETERMINADA", oP);
        }

        public string UsuarioAD(string usuarioAD)
        {
            char delimiter = '\\';
            string[] usuario_ad = usuarioAD.Split(delimiter);

            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@DOMINIO", usuario_ad[0]));
            oP.Add(new SqlParameter("@USUARIO", usuario_ad[1]));
            return oSql.TablaTopJson("WEB_USUARIO_R_OBTENER_USUARIO_AD", oP);
        }



        public string ListarUsuariosPorNombreOMatricula(string sValor, int iIdExpedicion)
        {
            sql oSql = new sql();
            //byte[] llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
            Encryption.Encrypt encrypt = new Encryption.Encrypt();

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@sValor", sValor));
            oP.Add(new SqlParameter("@iIdExpedicion", iIdExpedicion));
            //return oSql.TablaParametroJSON("PC_COMUN_R_LISTAR_USUARIOS_EXPEDICION", oP);
            List<Dictionary<string, object>> Encriptados = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(oSql.TablaParametroJSON("PC_COMUN_R_LISTAR_USUARIOS_EXPEDICION", oP));
            List<Dictionary<string, object>> Desencriptados = encrypt.Desencriptar(Encriptados, "Descripcion", "sMatricula");
            return JsonConvert.SerializeObject(Desencriptados);
        }
        //2022
        public Usuario ValidarUsuarioAzure(string upn, List<GrupoAzure> groups, int casilla)
        {
            string gruposXML = this.SerializeObjectWindows(groups);
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@upn", upn.ToLower()));
            oP.Add(new SqlParameter("@groups", gruposXML));
            oP.Add(new SqlParameter("@casilla", casilla));
            Usuario usuario = oSql.TablaTop<Usuario>("SIMIH_R_ValidarUsuarioAzure", oP);
            return usuario;
        }
        //2022
        public Usuario ValidarUsuarioAzureDesktop(string upn, List<GrupoAzure> groups)
        {
            string gruposXML = this.SerializeObjectWindows(groups);
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@upn", upn.ToLower()));
            oP.Add(new SqlParameter("@groups", gruposXML));
            Usuario oUsuario = oSql.TablaTop<Usuario>("SIMIH_USUARIOSEGURIDAD_R_VALIDAR_AZURE", oP);
            return oUsuario;
        }
        //2022
        public TipoUsuario ObtenerTipoUsuario(string upn)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@USUARIO", upn.ToLower()));
            return oSql.TablaTop<TipoUsuario>("SIMIH_TIPOUSUARIO_R_OBTENER_TIPO", oP);
        }
        //2022
        public Usuario ObtenerUsuarioPorCasilla(string upn, int casilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@upn", upn.ToLower()));
            oP.Add(new SqlParameter("@casilla", casilla));
            return oSql.TablaTop<Usuario>("SIMIH_R_UsuarioPorCasilla", oP);
        }
        //2002
        public string BuscarUsuarios(string usuario)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@USUARIO", usuario));
            return oSql.TablaParametroJSON("SIMIH_MANTENIMIENTOUSUARIO_R_BUSCARPORNOMBRE", oP);
        }


    }
}

