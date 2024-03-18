using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class Tipo : Interna.Core.Entity
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Abrev { get; set; }
        [DataMember]
        public String Alias { get; set; }
        [DataMember]
        public int Activo { get; set; }
        [DataMember]
        public int iTipo { get; set; }
        [DataMember]
        public String sTipo { get; set; }

        public Tipo()
        {
        }

        public Tipo(string Descripcion)
        {
            this.Descripcion = Descripcion;
        }

        public Tipo(string Descripcion, int ID)
        {
            this.Descripcion = Descripcion;
            this.ID = ID;
        }

        public override string ToString()
        {
            return Descripcion;
        }

        public List<Tipo> rBuscaTipo_Formato_Documento(Tipo oC)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ALIAS", oC.Alias));
            return oSql.TablaParametro<Tipo>("EXI_R_TIPO_FORMATO_DOCUMENTO", oP);
        }

        //Obtiene los tipos de entrega - Recorrido de Pisos / Oficinas
        public List<Tipo> rBuscaTipo_Entrega()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_TIPO_ENTREGA");
        }
        public List<Tipo> rTipoDocumentoExterno()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_TIPO_DOCUMENTO");
        }

        public List<Tipo> rTipoDocumento()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@Modo", 1));
            return oSql.TablaParametro<Tipo>("EXI_R_TIPO_DOCUMENTO", oP);

        }

        public List<Tipo> rListaEstado()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_TIPO_ESTADO");
        }

        //SIM1
        public List<Tipo> rListaLotes()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idPadre", 66));
            return oSql.TablaParametro<Tipo>("EXI_R_TIPO_LOTE", oP);
        }

        public List<Tipo> rListaMotivosCarga()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idPadre", 69));
            return oSql.TablaParametro<Tipo>("EXI_R_MOTIVO_CARGA", oP);
        }

        public List<Tipo> rListaMotivosCarga(int Tipo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idPadre", Tipo));
            return oSql.TablaParametro<Tipo>("EXI_R_MOTIVO_CARGA", oP);
        }

        //Publicacion
        public List<Tipo> rListaTipoPublicacion()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idPadre", 74));
            return oSql.TablaParametro<Tipo>("EXI_R_TIPO_PUBLICACION", oP);
        }

        public string rListaEquipoCoordinador(int indice)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idPadre", 81));
            oP.Add(new SqlParameter("@indice", indice));
            return oSql.TablaParametroJSON("EXI_R_TIPO_EQUIPO_COORDINADOR", oP);
        }

        public List<Tipo> rListaMotivosRezago()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_MOTIVO_REZAGO");
        }

        public List<Tipo> rListaResultadoVisita()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_TIPO_RESULTADOVISITA");
        }

        public List<Tipo> rListaTipoIdc()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_TIPO_IDC");
        }

        public List<Tipo> rListaTipoVinculo()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_TIPO_VINCULO");
        }

        public List<Tipo> rListaRutas()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_LISTARUTAS");
        }

        public List<Tipo> rListaTipoServicio()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_TIPO_SERVICIO");
        }

        public List<Tipo> rListaTipoEstado()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_TIPO_ESTADO_TARJETA");
        }

        public List<Tipo> rListaTipoDestino(int d)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", d));
            return oSql.TablaParametro<Tipo>("EXI_R_TIPO_DESTINO", oP);
        }
        //2022
        public List<Tipo> rHijoDoc(int IdTipoCorrespondencia, int IdCasilla)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ID", IdTipoCorrespondencia));
            oP.Add(new SqlParameter("@IdCasilla", IdCasilla));
            return oSql.TablaParametro<Tipo>("SIMIH_R_ObtenerTipoHijo", oP);
        }

        public List<Tipo> rColaborador(Colaborador.Colaboradores c)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDTIPOCOLABORADOR", c));
            return oSql.TablaParametro<Tipo>("EXI_R_COLABORADOR", oP);
        }
        public List<Tipo> rProductoExterna()
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@idPadre", 208));
            return oSql.TablaParametro<Tipo>("EXI_R_MOTIVO_CARGA_EXTERNA", oP);
        }

        // Jhoel
        // 24-02-14
        public List<Tipo> rListarOpciones()
        {
            sql oSql = new sql();
            return oSql.Tabla<Tipo>("EXI_R_ENTREGA_EXTERNA_OPCION");
        }
        //fin
        public int cTipoDocumento(string descripcion, int tipo, string alias, string abreviatura)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@TIPO", tipo));
            oP.Add(new SqlParameter("@DESCRIPCION", descripcion));
            oP.Add(new SqlParameter("@ALIAS", alias));
            oP.Add(new SqlParameter("@ABREV", abreviatura));


            return Convert.ToInt32((new sql()).Escalar("EXI_C_TIPODOCUMENTO", oP));
        }

        public int uTipoDocumento(int id, string descripcion, int tipo, string alias, string abreviatura, int activo)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();

            oP.Add(new SqlParameter("@ID", id));
            oP.Add(new SqlParameter("@TIPO", tipo));
            oP.Add(new SqlParameter("@DESCRIPCION", descripcion));
            oP.Add(new SqlParameter("@ALIAS", alias));
            oP.Add(new SqlParameter("@ABREV", abreviatura));
            oP.Add(new SqlParameter("@ACTIVO", activo));
            return Convert.ToInt32((new sql()).Escalar("EXI_U_TIPODOCUMENTO", oP));
        }

        public string rTipoDocumentoMesaParte(string sAlias)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@ALIAS", sAlias));
            return oSql.TablaParametroJSON("EXI_R_TIPO_FORMATO_DOCUMENTO", oP);
        }

        public string ListarTipoEmpaque()
        {
            sql oSql = new sql();
            string s = oSql.TablaJSON("PC_NUEVOMESADEPARTES_R_TIPOEMPAQUE");
            return s;
        }

        public string ListarTipoDocumentoPorTipoEmpaque(int iIdTipoEmpaque)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IDTIPOEMPAQUE", iIdTipoEmpaque));
            return oSql.TablaParametroJSON("PC_NUEVOMESADEPARTES_R_TIPODOCUMENTO_POR_TIPOEMPAQUE", oP);
        }

    }
}