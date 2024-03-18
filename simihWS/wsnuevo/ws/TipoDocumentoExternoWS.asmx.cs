﻿using Interna.Entity;
using System.Web.Services;

namespace simihWS
{
    /// <summary>
    /// Descripción breve de TipoDocumentoExternoWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class TipoDocumentoExternoWS : System.Web.Services.WebService
    {
        //2022
        [WebMethod]
        public string ListarTipoDocumentoExterno()
        {
            TipoDocumentoExterno oTipoDocumentoExterno = new TipoDocumentoExterno();
            return oTipoDocumentoExterno.ListarTipoDocumentoExterno();
        }
    }
}