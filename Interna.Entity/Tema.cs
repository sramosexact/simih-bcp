using System;
namespace Interna.Entity
{

    [Serializable]
    public class Tema : Interna.Core.Entity
    {
        //BANBIF
        //NARANJA = bg-color-orange
        //AZUL    = bg-color-blue
        //VERDE   = bg-color-greenLight
        public String tmBgorange { get; set; }
        public String tmBgblue { get; set; }
        public String tmBggreenLight { get; set; }


        public String tmColorPrimary { get; set; }
        public String tmColorSecon { get; set; }
        public String tmColorTercer { get; set; }



    }
}
