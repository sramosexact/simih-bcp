using Interna.Entity;
using System.Collections.Generic;
using System.Web.Services;


namespace simihWS
{
    /// <summary>
    /// Descripción breve de IndicadoresWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class IndicadoresWS : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Indicadores> GetCuadro_Mando(int id, int dias)
        {
            Indicadores oObj = new Indicadores();
            return oObj.rCuadodeMando2(id, dias);
        }


        [WebMethod]
        public List<Indicadores> GetCuadro_Mando_recibido(int id, int dias)
        {
            Indicadores oObj = new Indicadores();
            return oObj.rCuadodeMando_Recibido(id, dias);
        }

        [WebMethod]
        public Indicadores GetCuadro_MandoPC()
        {
            Indicadores oObj = new Indicadores();
            return oObj.rCuadodeMandoPC();
        }

        [WebMethod]
        public List<Indicadores> GetCuadro_MandoPC_Detalle(int opc, int valor)
        {
            Indicadores oObj = new Indicadores();
            return oObj.rCuadodeMandoPC_Detalle(opc, valor);
        }
    }
}
