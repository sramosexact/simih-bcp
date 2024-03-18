using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Interna.Core
{
    public class sql
    {
        private SqlConnection cnPer;
        private string TipoConexion = "0";
        private readonly SqlDataAdapter sqlAdapter = new SqlDataAdapter();
        private SqlCommand sqlCommand;
        private DataTable oDataTable;
        private DataSet oDataSet;
        //private byte[] llave;
        private string cadenaConexionSIM;
        private string cadenaConexionSEG;

        private void WriteToEventLog(string message)
        {
            try
            {
                string cs = "SIM - Expedicion Interna";
                EventLog elog = new EventLog();
                if (!EventLog.SourceExists(cs))
                {
                    EventLog.CreateEventSource(cs, cs);
                }
                elog.Source = cs;
                elog.EnableRaisingEvents = true;
                elog.WriteEntry(message, EventLogEntryType.Error);
            }
            catch (Exception) { }
        }

        public sql()
        {
            // IsNullConnection();
            //llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
            cadenaConexionSIM = ConfigurationManager.AppSettings["cadenaConexion"].ToString();
            cadenaConexionSEG = ""; // ConfigurationManager.AppSettings["cadenaConexion2"].ToString();
        }

        public sql(string TipoConexion)
        {
            this.TipoConexion = TipoConexion;
            // IsNullConnection();
            //llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
            cadenaConexionSIM = ConfigurationManager.AppSettings["cadenaConexion"].ToString();
            cadenaConexionSEG = ""; // ConfigurationManager.AppSettings["cadenaConexion2"].ToString();
        }

        private void OpenClose(ConnectionState estado)
        {
            String z = "";
            switch (estado)
            {
                case ConnectionState.Open:
                    if (cnPer != null)
                    {
                        cnPer.Close();
                        cnPer = null;
                    }

                    if (cnPer == null)
                    {
                        try
                        {
                            z = CadenaConexion(TipoConexion);
                            cnPer = new SqlConnection(z);
                            cnPer.Open();
                        }
                        catch (Exception e)
                        {
                            WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** CS: " + z);
                        }
                    }
                    break;

                case ConnectionState.Closed:
                    if (cnPer != null)
                        if (cnPer.State == ConnectionState.Open)
                        {
                            try
                            {
                                cnPer.Close();
                            }
                            catch (Exception) { }
                        }
                    break;

                default:
                    break;
            }
        }

        private String CadenaConexion(String TipoConexion)
        {
            string strRootPath = "SOFTWARE";
            string strRootKey = "EXACT";
            RegistryKey registryAccess = null;
            int intTipoAutenticacion = -1;
            bool RegistryOK = false;

            try
            {
                registryAccess = Registry.LocalMachine;
                if (registryAccess != null)
                    registryAccess = registryAccess.OpenSubKey(strRootPath, true);
                if (registryAccess != null)
                    registryAccess = registryAccess.CreateSubKey(strRootKey, RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (registryAccess != null) RegistryOK = true;
            }
            catch (Exception e)
            {
                WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** FLAG:1 ");
            }

            try
            {
                intTipoAutenticacion = int.Parse(System.Configuration.ConfigurationManager.AppSettings["TipoAutenticacion"]);
            }
            catch (Exception e)
            {
                WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** FLAG:2 ");
            }

            String strConnection = "";
            Encryption.Encrypt encrypt = new Encryption.Encrypt();

            if (this.TipoConexion.Equals("1"))
            {
                //strConnection = Encryption.Encryp(cadenaConexionSEG, llave);
                strConnection = encrypt.Desencriptar(cadenaConexionSEG);
            }
            else
            {
                strConnection = encrypt.Desencriptar(cadenaConexionSIM);
                //strConnection = Encryption.Encryption.Decrypt(cadenaConexionSIM, llave);
            }


            //try
            //{
            //    String strServidor = string.Empty;
            //    String strBaseSIM = string.Empty;
            //    String strBaseSeguridad = string.Empty;
            //    String strUsuario = string.Empty;
            //    String strPassword = string.Empty;

            //    //if (intTipoAutenticacion == -1 && RegistryOK) intTipoAutenticacion = 0;
            //    //if (TipoConexion.Equals("0"))
            //    //    strConnection = "Data Source=LTORRES-PC,1433;Initial Catalog=BIFSIM;Integrated Security=SSPI;";
            //    //    strConnection = "User ID=sa;Password=+Share12345;Initial Catalog=BIFSIM;Data Source=192.168.1.5";
            //    //else
            //    //    strConnection = "User ID=sa;Password=+ExactTI2015+;Initial Catalog=BIFSEGURIDAD;Data Source=192.168.1.224";
            //    //strConnection = "Data Source=LTORRES-PC,1433;Initial Catalog=BIFSEGURIDAD;Integrated Security=SSPI;";


            //    switch (intTipoAutenticacion)
            //    {
            //        case 0: // Registro
            //            strServidor = registryAccess.GetValue("AppServidor").ToString();
            //            strBaseSIM = registryAccess.GetValue("AppDBSim").ToString();
            //            strBaseSeguridad = registryAccess.GetValue("AppDBSecurity").ToString();
            //            strUsuario = registryAccess.GetValue("AppUserName").ToString();
            //            strPassword = registryAccess.GetValue("AppPassword").ToString();
            //            strConnection = "Data Source={0};Initial Catalog={1};User ID={2};Password={3};";

            //            if (TipoConexion.Equals("1"))
            //                strConnection = string.Format(strConnection, strServidor, strBaseSeguridad, strUsuario, strPassword);
            //            else
            //                strConnection = string.Format(strConnection, strServidor, strBaseSIM, strUsuario, strPassword);

            //            break;

            //        // System.Configuration.ConfigurationManager.

            //        case 1: // Config
            //            strServidor = System.Configuration.ConfigurationSettings.AppSettings["AppServidor"];
            //            strBaseSIM = System.Configuration.ConfigurationSettings.AppSettings["AppDBSim"];
            //            strBaseSeguridad = System.Configuration.ConfigurationSettings.AppSettings["AppDBSecurity"];
            //            strUsuario = System.Configuration.ConfigurationSettings.AppSettings["AppUserName"];
            //            strPassword = System.Configuration.ConfigurationSettings.AppSettings["AppPassword"];
            //            strConnection = "Data Source={0};Initial Catalog={1};User ID={2};Password={3};";

            //            if (TipoConexion.Equals("1"))
            //                strConnection = string.Format(strConnection, strServidor, strBaseSeguridad, strUsuario, strPassword);
            //            else
            //                strConnection = string.Format(strConnection, strServidor, strBaseSIM, strUsuario, strPassword);

            //            break;

            //        default:
            //            if (TipoConexion.Equals("0"))
            //                //strConnection = "Data Source=.,1433;Initial Catalog=BIFSIM;Integrated Security=SSPI;";
            //                strConnection = "User ID=sa;Password=+Share12345;Initial Catalog=BIFSIM;Data Source=192.168.1.224";
            //            //strConnection = "User ID=sa;Password=123456;Initial Catalog=BIFSIM;Data Source=.";
            //            else
            //                strConnection = "User ID=sa;Password=+Share12345;Initial Catalog=BIFSEGURIDAD;Data Source=192.168.1.224";
            //                //strConnection = "Data Source=.,1433;Initial Catalog=BIFSEGURIDAD;Integrated Security=SSPI;";

            //            break;
            //    }
            //}
            //catch (Exception e)
            //{
            //    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** FLAG:3 ");
            //}

            return strConnection;
        }

        public int Exec(string Procedimiento)
        {
            int intResult = 0;

            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer) { CommandType = CommandType.StoredProcedure };

                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** EXEC");
                intResult = -1;
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return intResult;
        }

        public int Exec(string Procedimiento, List<SqlParameter> oListParameter)
        {
            int intResult = 0;
            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer) { CommandType = CommandType.StoredProcedure };
                foreach (SqlParameter oParametro in oListParameter) sqlCommand.Parameters.Add(oParametro);

                return sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** EXEC " + Procedimiento);
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** EXEC ");
                }
                intResult = -1;
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return intResult;
        }

        public DataTable Tabla(string Procedimiento)
        {
            oDataTable = new DataTable();
            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer) { CommandType = CommandType.StoredProcedure };
                sqlAdapter.SelectCommand = sqlCommand;

                sqlAdapter.Fill(oDataTable);
            }
            catch (Exception e)
            {
                WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TABLA " + Procedimiento);
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return oDataTable;
        }

        public DataTable TablaParametro(string Procedimiento, object valor)
        {

            oDataTable = new DataTable();
            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(String.Format("EXEC {0} {1}", Procedimiento, valor), cnPer) { CommandType = CommandType.Text };
                sqlAdapter.SelectCommand = sqlCommand;

                sqlAdapter.Fill(oDataTable);
            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro " + Procedimiento + "," + valor.ToString());
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro ");
                }
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return oDataTable;
        }

        public List<Entity> TablaParametro(string Procedimiento, object valor, Entity oMolde)
        {
            return Fill(this.TablaParametro(Procedimiento, valor), oMolde);
        }

        public List<Entity> TablaParametro(string Procedimiento, List<SqlParameter> Parametros, Entity oMolde)
        {
            return Fill(this.TablaParametro(Procedimiento, Parametros), oMolde);
        }

        public List<Entity> Tabla(string Procedimiento, Entity oMolde)
        {
            return Fill(this.Tabla(Procedimiento), oMolde);
        }

        public DataTable TablaParametro(string Procedimiento, List<SqlParameter> Parametros)
        {
            oDataTable = new DataTable();
            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer);
                foreach (SqlParameter oParametro in Parametros)
                {
                    sqlCommand.Parameters.Add(oParametro);
                    //sqlCommand.Parameters.Clear();
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.SelectCommand = sqlCommand;

                sqlAdapter.Fill(oDataTable);
            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro " + Procedimiento);
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro ");
                }
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return oDataTable;
        }
        /*Metodo en Prueba Benji Villarreal*/
        //public string TablaParametroJson(string Procedimiento, List<SqlParameter> Parametros)
        //{
        //    oDataTable = new DataTable();
        //    try
        //    {
        //        OpenClose(ConnectionState.Open);
        //        sqlCommand = new SqlCommand(Procedimiento, cnPer);
        //        foreach (SqlParameter oParametro in Parametros)
        //        {
        //            sqlCommand.Parameters.Add(oParametro);
        //            sqlCommand.Parameters.Clear();
        //        }
        //        sqlCommand.CommandType = CommandType.StoredProcedure;
        //        sqlAdapter.SelectCommand = sqlCommand;

        //        sqlAdapter.Fill(oDataTable);
        //    }
        //    catch (Exception e)
        //    {
        //        try
        //        {
        //            WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro " + Procedimiento);
        //        }
        //        catch (Exception)
        //        {
        //            WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro ");
        //        }
        //    }
        //    finally
        //    {
        //        OpenClose(ConnectionState.Closed);
        //    }

        //    return JsonConvert.SerializeObject(oDataTable);
        //}

        public object Escalar(string Procedimiento, List<SqlParameter> Parametros)
        {
            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer);
                foreach (SqlParameter oParametro in Parametros) sqlCommand.Parameters.Add(oParametro);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 32000;

                int i = 0;
                object x = sqlCommand.ExecuteScalar();
                if (x != null)
                    if (int.TryParse(x.ToString(), out i)) return i;
                return 0;
            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** ESCALAR " + Procedimiento);
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** ESCALAR ");
                }
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }

            return null;
        }

        public object escalar(string Procedimiento)
        {
            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer) { CommandType = CommandType.Text };

                return sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** ESCALAR " + Procedimiento);
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** ESCALAR ");
                }
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return null;
        }

        public object Escalar(string Procedimiento)
        {
            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer) { CommandType = CommandType.StoredProcedure };

                return sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** ESCALAR " + Procedimiento);
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** ESCALAR ");
                }
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return null;
        }

        public object Escalar(string Procedimiento, object valor)
        {
            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(String.Format("EXEC {0} {1}", Procedimiento, valor), cnPer) { CommandType = CommandType.Text };

                return sqlCommand.ExecuteScalar();
            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** ESCALAR " + Procedimiento + "," + valor.ToString());
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** ESCALAR ");
                }
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return null;
        }

        public List<Entity> Fill(DataTable oTable, Entity oMolde)
        {
            var oList = new List<Entity>();
            int indexRow = 0;

            foreach (var oRow in oTable.Rows)
            {
                int index = 0;
                Entity oEntity = null;
                oEntity = (Entity)oMolde.ShallowCopy();

                foreach (object oValue in ((DataRow)oRow).ItemArray)
                    try
                    {
                        if (oValue == null) continue;
                        if (String.Compare(oValue.GetType().Name, "DBNull", false) == 0) continue;
                        if (!oEntity.SetAttributeValue(oTable.Columns[index].Caption, oValue))
                            oEntity.SetPropertyValue(oTable.Columns[index].Caption, oValue);
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        index++;
                    }
                oEntity.Format();
                oList.Add(oEntity);
                indexRow++;
            }
            return oList;
        }

        public List<T> TablaParametro<T>(string Procedimiento, List<SqlParameter> Parametros) where T : Entity, new()
        {
            var oList = new List<T>();
            DataTable oTable = this.TablaParametro(Procedimiento, Parametros);
            if (oTable == null) return oList;

            int indexRow = 0;

            foreach (var oRow in oTable.Rows)
            {
                T oEntity = new T();
                int index = 0;
                foreach (object oValue in ((DataRow)oRow).ItemArray)
                    try
                    {
                        if (oValue == null) continue;
                        if (String.Compare(oValue.GetType().Name, "DBNull", false) == 0) continue;
                        if (!oEntity.SetAttributeValue(oTable.Columns[index].Caption, oValue))
                            oEntity.SetPropertyValue(oTable.Columns[index].Caption, oValue);
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        index++;
                    }
                oEntity.Format();
                oList.Add(oEntity);
                indexRow++;
            }
            return oList;
        }

        public static double GetCurrentMilli()
        {
            DateTime Jan1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan javaSpan = DateTime.UtcNow - Jan1970;
            return javaSpan.TotalMilliseconds;
        }
        //PROCEDIMIENTO EN EVALUACION
        public string TablaParametroJSON(string Procedimiento, List<SqlParameter> Parametros)
        {

            DataTable oTable = this.TablaParametro(Procedimiento, Parametros);
            if (oTable == null) return null;
            return JsonConvert.SerializeObject(oTable);

        }

        public string TablaJSON(string Procedimiento)
        {

            DataTable oTable = this.Tabla(Procedimiento);
            if (oTable == null) return null;
            return JsonConvert.SerializeObject(oTable);

        }


        public List<T> Tabla<T>(string Procedimiento) where T : Entity, new()
        {
            var oList = new List<T>();
            DataTable oTable = this.Tabla(Procedimiento);
            if (oTable == null) return oList;

            int indexRow = 0;

            foreach (var oRow in oTable.Rows)
            {
                T oEntity = new T();
                int index = 0;
                foreach (object oValue in ((DataRow)oRow).ItemArray)
                    try
                    {
                        if (oValue == null) continue;
                        if (String.Compare(oValue.GetType().Name, "DBNull", false) == 0) continue;
                        if (!oEntity.SetAttributeValue(oTable.Columns[index].Caption, oValue))
                            oEntity.SetPropertyValue(oTable.Columns[index].Caption, oValue);
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        index++;
                    }
                oEntity.Format();
                oList.Add(oEntity);
                indexRow++;
            }
            return oList;
        }

        public T TablaTop<T>(string Procedimiento, List<SqlParameter> oP) where T : Entity, new()
        {
            DataTable oTable;

            if (oP == null)
                oTable = this.Tabla(Procedimiento);
            else
                oTable = this.TablaParametro(Procedimiento, oP);

            if (oTable == null) return null;
            T oEntity = new T();

            foreach (var oRow in oTable.Rows)
            {
                int index = 0;
                foreach (object oValue in ((DataRow)oRow).ItemArray)
                    try
                    {
                        if (oValue == null) continue;
                        if (String.Compare(oValue.GetType().Name, "DBNull", false) == 0) continue;
                        if (!oEntity.SetAttributeValue(oTable.Columns[index].Caption, oValue))
                            oEntity.SetPropertyValue(oTable.Columns[index].Caption, oValue);
                    }
                    catch (Exception)
                    {
                    }
                    finally
                    {
                        index++;
                    }
                oEntity.Format();
                break;
            }
            return oEntity;
        }

        public T TablaTop<T>(string StoreProcedure) where T : Entity, new()
        {
            return TablaTop<T>(StoreProcedure, null);
        }


        public string TablaTopJson(string Procedimiento, List<SqlParameter> oP)
        {
            DataTable oTable;

            if (oP == null)
                oTable = this.Tabla(Procedimiento);
            else
                oTable = this.TablaParametro(Procedimiento, oP);

            return JsonConvert.SerializeObject(oTable);

        }

        public List<string> ListaTablaParametroJSON(string Procedimiento, List<SqlParameter> Parametros)
        {
            List<string> oListaString = new List<string>();
            DataSet oListaTable = this.ListaTablaParametro(Procedimiento, Parametros);
            if (oListaTable == null) return null;
            foreach (DataTable dt in oListaTable.Tables)
            {
                oListaString.Add(JsonConvert.SerializeObject(dt));
            }

            return oListaString;
        }

        public List<string> ListaTablaJSON(string Procedimiento)
        {
            List<string> oListaString = new List<string>();
            DataSet oListaTable = this.ListaTabla(Procedimiento);
            if (oListaTable == null) return null;
            foreach (DataTable dt in oListaTable.Tables)
            {
                oListaString.Add(JsonConvert.SerializeObject(dt));
            }

            return oListaString;
        }

        public DataSet ListaTablaParametro(string Procedimiento, List<SqlParameter> Parametros)
        {
            oDataSet = new DataSet();

            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer);
                foreach (SqlParameter oParametro in Parametros)
                {
                    sqlCommand.Parameters.Add(oParametro);
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.SelectCommand = sqlCommand;

                sqlAdapter.Fill(oDataSet);
                if (oDataSet.Tables.Count == 0) return null;


            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro " + Procedimiento);
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro ");
                }
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return oDataSet;
        }

        public DataSet ListaTabla(string Procedimiento)
        {
            oDataSet = new DataSet();

            try
            {
                OpenClose(ConnectionState.Open);
                sqlCommand = new SqlCommand(Procedimiento, cnPer);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlAdapter.SelectCommand = sqlCommand;

                sqlAdapter.Fill(oDataSet);
                if (oDataSet.Tables.Count == 0) return null;


            }
            catch (Exception e)
            {
                try
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro " + Procedimiento);
                }
                catch (Exception)
                {
                    WriteToEventLog("DATA: " + e.Data + " ** MESSAGE: " + e.Message + " ** SOURCE: " + e.Source + " ** TablaParametro ");
                }
            }
            finally
            {
                OpenClose(ConnectionState.Closed);
            }
            return oDataSet;
        }
    }



}