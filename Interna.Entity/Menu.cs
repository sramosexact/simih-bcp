using Interna.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    [Serializable]
    public class Menu : Interna.Core.Entity
    {
        #region Propiedades
        public int Id { set; get; }
        public int IdPadre { get; set; }
        public string Nombre { get; set; }
        public string Href { get; set; }
        public string Glif { get; set; }
        public int Pos { get; set; }
        #endregion
        public Menu()
        {
            Id = 0;
            IdPadre = -1;
            Nombre = "";
            Href = "";
            Glif = "";
            Pos = 999;
        }
        public List<Interna.Entity.Menu> rListadoTipo(int perfil)
        {
            sql oSql = new sql();
            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@IdPerfil", perfil));
            List<Menu> oM = oSql.TablaParametro<Interna.Entity.Menu>("SP_WEXI_R_MenuPerfil", oP);
            return oM;
        }
    }
}
