namespace Interna.Entity
{
    public struct Response
    {
        public string token;
        public string refreshToken;
        public Usuario usuario;

        public Response(string token, string refreshToken, Usuario usuario)
        {
            this.token = token;
            this.refreshToken = refreshToken;
            this.usuario = usuario;
        }

    }
}
