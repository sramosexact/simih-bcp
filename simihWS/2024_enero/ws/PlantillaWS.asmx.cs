using Interna.Entity;
using System.Collections.Generic;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de PlantillaWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class PlantillaWS : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Plantilla> GetPlantillaActiva(Plantilla oPlantilla)
        {
            return oPlantilla.loPlantillas();
        }
        [WebMethod]
        public int setPlantilla(Plantilla oPlantilla)
        {
            return oPlantilla.cPlantilla();
        }
        [WebMethod]
        public int setDesactivaPlantilla(Plantilla oPlantilla)
        {
            return oPlantilla.uPlantilla();
        }

        //Plantilla General

        //[WebMethod]
        //public List<PlantillaGeneral> GetPlantillaGeneralActiva(PlantillaGeneral oPlantillaGeneral)
        //{
        //    return oPlantillaGeneral.loPlantillas();
        //}
        //[WebMethod]
        //public int setDesactivaPlantillaGeneral(PlantillaGeneral oPlantillaGeneral)
        //{
        //    return oPlantillaGeneral.uPlantillaGeneral();
        //}

        /*******************************/
        //[WebMethod]
        //public List<Campo> GetTipoCampo(int tipodocumento)
        //{
        //    Campo O = new Campo();
        //    return O.rTipoCampo(tipodocumento);
        //}

        [WebMethod]
        public List<Campo> GetTipoCampo(int indicetipodoc)
        {
            Campo O = new Campo();
            return O.rTipoCampo(indicetipodoc);
        }
        /*******************************/
    }
}
