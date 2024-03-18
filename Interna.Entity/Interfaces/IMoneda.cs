namespace Interna.Entity.Interfaces
{
    public interface IMoneda
    {
        byte iIdMoneda { get; set; }

        string sDescripcionMoneda { get; set; }

        string sSimbolo { get; set; }

        float fTipoCambio { get; set; }
    }
}
