using Interna.Entity;
using System;
using System.Collections.Generic;

namespace simihWS.Helper
{
    public static class Helper
    {
        public static bool ValidarTipoUsuario(string upn, List<TipoUsuarioEnum> tiposUsuarioList)
        {
            Usuario usuario = new Usuario();
            TipoUsuario tu = usuario.ObtenerTipoUsuario(upn);
            int iTipoUsuario;
            if (tu == null) iTipoUsuario = 0;
            else iTipoUsuario = tu.iIdTipoUsuario;

            if (Enum.IsDefined(typeof(TipoUsuarioEnum), iTipoUsuario))
            {
                foreach (TipoUsuarioEnum t in tiposUsuarioList)
                {
                    if ((int)t == iTipoUsuario)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        public static bool ValidarCasillaPerteneceUsuario(string upn, int casilla)
        {
            Usuario usuario = new Usuario();
            Usuario usuarioCasilla = usuario.ObtenerUsuarioPorCasilla(upn, casilla);

            return usuarioCasilla == null ? false : true;


        }
    }
}