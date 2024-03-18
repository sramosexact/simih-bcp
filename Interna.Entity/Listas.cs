using Interna.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Interna.Entity
{
    [Serializable]
    public class Listas : Interna.Core.Entity
    {
        public string Lista { get; set; }

        public string Descripcion { get; set; }

        public Listas()
        {
            Lista = "";
            Descripcion = "";
        }
        //2022
        public List<Listas> cargarListas(string upn, int idCasilla)
        {
            sql oSql = new sql();

            List<SqlParameter> oP = new List<SqlParameter>();
            oP.Add(new SqlParameter("@upn", upn));
            oP.Add(new SqlParameter("@IdCasilla", idCasilla));
            List<Listas> listas = oSql.TablaParametro<Listas>("SIMIH_R_ObtenerListados", oP);

            JArray jsonPreservar = JArray.Parse("[" + listas[0].Descripcion + "]");

            foreach (JObject jsonOperaciones in jsonPreservar.Children<JObject>())
            {
                //Aqui para poder identificar las propiedades y sus valores
                foreach (JProperty jsonOPropiedades in jsonOperaciones.Properties())
                {
                    string propiedad = jsonOPropiedades.Name;
                    if (propiedad.Equals("Nombre"))
                    {
                        //jsonOPropiedades.Value = encrypt.Desencriptar(jsonOPropiedades.Value.ToString());
                        listas[0].Descripcion = jsonOperaciones.ToString();
                    }
                }

            }

            JArray jsonPreservar2 = JArray.Parse(listas[1].Descripcion);

            foreach (JObject jsonOperaciones in jsonPreservar2.Children<JObject>())
            {
                foreach (JProperty jsonOPropiedades in jsonOperaciones.Properties())
                {

                    string propiedad = jsonOPropiedades.Name;
                    if (propiedad.Equals("Bandeja"))
                    {
                        jsonOPropiedades.Value = jsonOPropiedades.Value.ToString().Trim();
                        //listas[1].Descripcion = jsonOperaciones.ToString();
                    }
                }

            }

            listas[1].Descripcion = jsonPreservar2.ToString();

            return listas;
        }
    }
}
