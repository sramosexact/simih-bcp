using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public static partial class Metodos
    {
        /*César Baltazar - modificado - 06/10/2016*/
        public static List<Agencia> ListarAgenciasPorTurno(Turno oTurno)
        {
            //ServiceAgenciaWS.Turno oWSTurno = new ServiceAgenciaWS.Turno() { iIdTurno = oTurno.iIdTurno };
            //ServiceAgenciaWS.AgenciaWS oAgenciaWS = new ServiceAgenciaWS.AgenciaWS();

            //return deserializarPrueba<Agencia>(oAgenciaWS.listarAgenciasPorTurno(oWSTurno));

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "obtenerAgenciaPorCodigo", new Dictionary<string, object>() {
                    { "iIdTurno", oTurno.iIdTurno }
                });

                return deserializarPrueba<Agencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }
        // Funcional - frmNuevaEntregaAgencia
        public static Agencia ObtenerAgenciaPorCodigo(string sCodigoAgencia)
        {
            List<Agencia> lAgencia = new List<Agencia>();
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "obtenerAgenciaPorCodigo", new Dictionary<string, object>() {
                    { "sCodigoAgencia", sCodigoAgencia }
                });

                lAgencia = deserializarPrueba<Agencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

            if (lAgencia.Count > 0)
            {
                return lAgencia[0];
            }
            else
            {
                return null;
            }
        }
        //2022
        public static int CrearEnvioAgencias(String xmlLote, Usuario oColaborador, int iIdUsuarioLogeado)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "crearEnvioAgencias", new Dictionary<string, object>() {
                    //{ "idExpedicion", Program.oUsuario.IdExpedicion },
                    { "IdColaboradorSeleccionado", oColaborador.ID },
                    { "xmlLote", xmlLote}
                    //{ "iIdUsuarioLogeado", iIdUsuarioLogeado}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }


        public static List<Agencia> ObtenerListadoAgencia()
        {
            //ServiceAgenciaWS.AgenciaWS oAgenciaWS = new ServiceAgenciaWS.AgenciaWS();
            //return Metodos.deserializarPrueba<Agencia>(oAgenciaWS.ObtenerListadoAgencia());

            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "ObtenerListadoAgencia", null);

                return deserializarPrueba<Agencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Agencia> ListarAgencias()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "ListarAgencias", null);

                return deserializarPrueba<Agencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static int CrearAgencia(Agencia oAgencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "CrearAgencia", new Dictionary<string, object>() {

                    { "sCodigoAgencia", oAgencia.sCodigoAgencia},
                    { "sDescripcion", oAgencia.sDescripcion },
                    { "iIdGeoDireccion", oAgencia.iIdGeoDireccion},
                    { "iTipo", oAgencia.iTipo }

                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static int ModificarAgencia(Agencia oAgencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "ModificarAgencia", new Dictionary<string, object>() {

                    { "iIdAgencia", oAgencia.iId},
                    { "sDescripcion", oAgencia.sDescripcion },
                    { "iActivo", oAgencia.iActivo}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static int CambiarEstadoAgencia(Agencia oAgencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "CambiarEstadoAgencia", new Dictionary<string, object>() {
                    { "idAgencia", oAgencia.iId}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static List<Agencia> ListarAgenciasNoVinculadasTurno(Turno oTurno)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "ListarAgenciasNoVinculadasTurno", new Dictionary<string, object>() {
                    { "IdTurno", oTurno.iIdTurno}
                });

                return deserializarPrueba<Agencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static List<Agencia> ListarAgenciasVinculadasTurno()
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "ListarAgenciasVinculadasTurno", null);

                return deserializarPrueba<Agencia>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }

        }

        //2022
        public static int VincularAgenciaTurno(Agencia oAgencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "VincularAgenciaTurno", new Dictionary<string, object>() {
                    { "IdTurno", oAgencia.IdTurno},
                    { "listaAgencias", oAgencia.sDescripcion}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }

        //2022
        public static int EliminarVinculoAgenciaTurno(Agencia oAgencia)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "EliminarVinculoAgenciaTurno", new Dictionary<string, object>() {
                    { "idAgencia", oAgencia.iId},
                    { "IdTurno", oAgencia.IdTurno}
                });

                return Convert.ToInt32(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
        // Funcional - frmNuevaEntregaAgencia
        public static List<AgenciaLote> ListarAgenciasPalomarTurno(Turno oTurno, Palomar oPalomar)
        {
            try
            {
                string response = Requester.AuthorizationTask(RutaWS.AgenciaWS + "listarAgenciasPalomarTurno", new Dictionary<string, object>() {
                    { "iIdTurno", oTurno.iIdTurno },
                    { "idPalomar", oPalomar.ID}
                });

                return deserializarPrueba<AgenciaLote>(response);
            }
            catch (InvalidTokenException)
            {
                throw;
            }
        }
    }
}