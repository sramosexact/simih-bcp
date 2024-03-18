using System;

namespace Interna.Entity.Interfaces
{
    public interface ITipoDocumento
    {
        Int16 iIdTipoDocumento { get; set; }
        String sDescripcionTipoDocumento { get; set; }
        Byte iMoneda { get; set; }
    }
}
