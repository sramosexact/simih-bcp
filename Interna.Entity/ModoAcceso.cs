using System;
using System.Collections.Generic;

namespace Interna.Entity
{
    [Serializable]
    public class ModoAcceso
    {
        public int IdModoAcceso { get; set; }
        public string modoAcceso { get; set; }
        public int swLogin { get; set; }
        public int swMantUsuario { get; set; }
        //2022
        public List<ModoAcceso> subListarModoAcceso()
        {
            List<ModoAcceso> lstModoAcceso = new List<ModoAcceso>();
            ModoAcceso ItemModoWindows = new ModoAcceso();
            ItemModoWindows.IdModoAcceso = 0;
            ItemModoWindows.modoAcceso = "Usuario Windows (Automatico)";
            ItemModoWindows.swLogin = 1;
            ItemModoWindows.swMantUsuario = 1;
            lstModoAcceso.Add(ItemModoWindows);

            ModoAcceso ItemModoForm = new ModoAcceso();
            ItemModoForm.IdModoAcceso = 1;
            ItemModoForm.modoAcceso = "Usuario Particular (Usuario y Clave)";
            ItemModoForm.swLogin = 1;
            ItemModoForm.swMantUsuario = 1;
            lstModoAcceso.Add(ItemModoForm);

            ModoAcceso ItemModoAmbos = new ModoAcceso();
            ItemModoAmbos.IdModoAcceso = 2;
            ItemModoAmbos.modoAcceso = "Ambos (Windows y Particular)";
            ItemModoAmbos.swLogin = 0;
            ItemModoAmbos.swMantUsuario = 1;
            lstModoAcceso.Add(ItemModoAmbos);

            return lstModoAcceso;
        }
    }
}