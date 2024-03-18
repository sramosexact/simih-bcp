using System;

namespace Interna.Entity
{
    [Serializable]
    public class Cliente : Interna.Core.Entity
    {
        public String Nombre { get; set; }
        public int ID { get; set; }
    }
}
