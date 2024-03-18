using System;
using System.Runtime.Serialization;

namespace Interna.Entity
{
    [Serializable]
    [DataContract]
    public class UsuarioPerfil
    {
        public int UsuarioId { get; set; }
        public string Usuario { get; set; }
        public int PerfilId { get; set; }
        public string Perfil { get; set; }
    }
}
