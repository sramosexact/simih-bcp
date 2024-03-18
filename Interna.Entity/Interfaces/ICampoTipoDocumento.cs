using System;

namespace Interna.Entity.Interfaces
{
    public interface ICampoTipoDocumento
    {
        int iIdCampoTipoDocumento { get; set; }
        Int16 iIdTipoDocumento { get; set; }
        string sNombreCampoTipoDocumento { get; set; }
        string sDescripcionCampoTipoDocumento { get; set; }
    }
}
