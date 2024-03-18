
namespace SIMIHSFTP.HELPER
{
    public static class Helper
    {
        public static string QuitarTildes(string texto)
        {
            return texto
                .Replace('á', 'a')
                .Replace('é', 'e')
                .Replace('í', 'i')
                .Replace('ó', 'o')
                .Replace('ú', 'u')
                .Replace('Á', 'A')
                .Replace('É', 'E')
                .Replace('Í', 'I')
                .Replace('Ó', 'O')
                .Replace('Ú', 'U');
        }
    }
}
