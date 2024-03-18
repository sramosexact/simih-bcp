using System.Web.Services.Protocols;

namespace Interna.Entity
{
    public class Auth : SoapHeader
    {
        public string usuario { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
}
