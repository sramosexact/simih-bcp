using Interna.Entity;
using System.Collections.Generic;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de PlantillaGeneralWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class PlantillaGeneralWS : System.Web.Services.WebService
    {

        [WebMethod]
        public int setPlantillaGeneral(int IdCliente, int IdExpedicion, int IdTipoDocumento, string Nombre, int IdCreadoPor, string Detalle, int Posicion, string Ruta)
        {
            PlantillaGeneral oPlantillaGeneral = new PlantillaGeneral();

            oPlantillaGeneral.Cliente = IdCliente;
            oPlantillaGeneral.Expedicion = IdExpedicion;
            oPlantillaGeneral.TipoDocumento = IdTipoDocumento;
            oPlantillaGeneral.Nombre = Nombre;
            oPlantillaGeneral.CreadoPor = IdCreadoPor;
            oPlantillaGeneral.Detalle = Detalle;
            oPlantillaGeneral.Posicion = Posicion;
            oPlantillaGeneral.Ruta = Ruta;

            return oPlantillaGeneral.cPlantillaGeneral();
        }

        [WebMethod]
        public int setDesactivaPlantillaGeneral(int IdPlantilla, int IdUsuario, int IdExpedicion)
        {
            PlantillaGeneral oPlantillaGral = new PlantillaGeneral();
            oPlantillaGral.ID = IdPlantilla;
            oPlantillaGral.CreadoPor = IdUsuario;
            oPlantillaGral.Expedicion = IdExpedicion;
            return oPlantillaGral.uPlantillaGeneral();
        }

        [WebMethod]
        public List<PlantillaGeneral> GetPlantillaGeneralActiva(int IdCliente)
        {
            PlantillaGeneral oPlantillaGral = new PlantillaGeneral();
            oPlantillaGral.Cliente = IdCliente;
            return oPlantillaGral.loPlantillasGeneral();
        }

        [WebMethod]
        public List<Campo> GetCamposActivos(int codplantilla)
        {
            Campo O = new Campo();
            return O.cargarCampos(codplantilla);
        }

        //Para objeto Detalle
        [WebMethod]
        public List<Campo> GetCamposActivosObjDetalle(int objeto)
        {
            Campo O = new Campo();
            return O.cargarCamposObjDetalle(objeto);
        }

        [WebMethod]
        public List<Campo> GetCamposVisualesActivos(int IdTipoObjeto)
        {
            Campo O = new Campo();
            return O.CamposVisualesActivos(IdTipoObjeto);
        }

        [WebMethod]
        public int updatePlantillaGeneral(int IdPlantilla, int IdExpedicion, string Nombre, int IdUsuario, string Detalle, int Posicion, string Ruta)
        {
            PlantillaGeneral oPlantillaGeneral = new PlantillaGeneral();
            oPlantillaGeneral.ID = IdPlantilla;
            oPlantillaGeneral.Expedicion = IdExpedicion;
            oPlantillaGeneral.Nombre = Nombre;
            oPlantillaGeneral.CreadoPor = IdUsuario;
            oPlantillaGeneral.Detalle = Detalle;
            oPlantillaGeneral.Posicion = Posicion;
            oPlantillaGeneral.Ruta = Ruta;
            return oPlantillaGeneral.aPlantillaGeneral();
        }

        [WebMethod]
        public int setCargarDatos(int IdPlantilla, int IdExpedicion, int IdTipoServicio, int IdMensajeria, int IdUsuario, int IdCasillaOrigen,
            int IdCasillaDestino, int IdEstado, int IdMotivoCarga, int IdTipoLote, int IdActualizacion, string Ruta, string Guia, string Detalle)
        {
            PlantillaGeneral oPlantillaGral = new PlantillaGeneral();
            oPlantillaGral.ID = IdPlantilla;
            oPlantillaGral.Expedicion = IdExpedicion;
            oPlantillaGral.TipoServicio = IdTipoServicio;
            oPlantillaGral.IdMensajeria = IdMensajeria;
            oPlantillaGral.CreadoPor = IdUsuario;
            oPlantillaGral.IdCasillaOrigen = IdCasillaOrigen;
            oPlantillaGral.IdCasillaDestino = IdCasillaDestino;
            oPlantillaGral.IdEstado = IdEstado;
            oPlantillaGral.MotivoCarga = IdMotivoCarga;
            oPlantillaGral.TipoLote = IdTipoLote;
            oPlantillaGral.Actualizacion = IdActualizacion;
            oPlantillaGral.Ruta = Ruta;
            oPlantillaGral.Guia = Guia;
            oPlantillaGral.Detalle = Detalle;
            return oPlantillaGral.CargarDatos();
        }

    }
}
