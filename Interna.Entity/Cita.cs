using System;
//using System.Drawing;

namespace Interna.Entity
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class CitaCampo : Attribute
    {
        public String Nombre { get; set; }
    }

    public struct CitaColor
    {
        public int R;
        public int G;
        public int B;
    }

    [Serializable]
    public class Cita : Interna.Core.Entity
    {
        public String IdCita { get; set; }
        public int Tipo { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public String Nombre { get; set; }
        public int Etiqueta { get; set; }
        public String Descripcion { get; set; }
        public String Lugar { get; set; }

        public int Categoria { get; set; }
        public String CategoriaDescripcion { get; set; }
        public CitaColor CategoriaColor { get; set; }
    }
}
