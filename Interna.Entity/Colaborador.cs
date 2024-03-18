using System;

namespace Interna.Entity
{
    [Serializable]
    public class Colaborador : Interna.Core.Entity
    {
        public int ID { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }
        public string Nombres { get; set; }
        public int IdTipoColaborador { get; set; }
        public int Activo { get; set; }
        public string Descripcion
        {
            get { return Paterno + " " + Materno + ", " + Nombres; }

            set { }
        }

        public enum Colaboradores
        {
            Motorizado = 167,
            Caminante = 168,
            Chofer = 169,
        }

        //public List<Colaborador> rColaborador(Colaborador.Colaboradores c)
        //{
        //    sql oSql = new sql();
        //    List<SqlParameter> oP = new List<SqlParameter>();
        //    oP.Add(new SqlParameter("@IDTIPOCOLABORADOR", c));
        //    return oSql.TablaParametro<Colaborador>("EXI_R_COLABORADOR", oP);
        //}


    }

}
