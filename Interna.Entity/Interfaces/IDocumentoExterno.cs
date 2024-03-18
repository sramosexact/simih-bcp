namespace Interna.Entity.Interfaces
{
    public interface IDocumentoExterno
    {
        int iIdDocumentoExterno { get; set; }
        string sNumeroDocumento { get; set; }
        string sIdentificadorDestinatario { get; set; }
        string sDestinatario { get; set; }
    }
}
