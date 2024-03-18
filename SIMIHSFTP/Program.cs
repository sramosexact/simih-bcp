using Interna.Entity;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using SIMIHSFTP.FILES;
using SIMIHSFTP.HELPER;
using SIMIHSFTP.SFTP;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SIMIHSFTP
{
    class Program
    {
        static string host = ConfigurationManager.AppSettings["Host"];
        static string username = ConfigurationManager.AppSettings["UserName"];
        static string password = ConfigurationManager.AppSettings["Password"];
        static string localPath = ConfigurationManager.AppSettings["LocalPath"];
        static string fileName = ConfigurationManager.AppSettings["FileName"];
        static string serverPath = ConfigurationManager.AppSettings["ServerPath"];
        static string fileHeader = ConfigurationManager.AppSettings["FileHeader"];
        static string separatorCharacter = ConfigurationManager.AppSettings["SeparatorCharacter"];
        static string numberOfFields = ConfigurationManager.AppSettings["NumberOfFields"];

        static string Instance = ConfigurationManager.AppSettings["Instance"];
        static string Tenant = ConfigurationManager.AppSettings["Tenant"];
        static string ClientId = ConfigurationManager.AppSettings["ClientId"];
        static string ClientSecret = ConfigurationManager.AppSettings["ClientSecret"];
        static string CertificateName = ConfigurationManager.AppSettings["CertificateName"];
        static string CertificatePass = ConfigurationManager.AppSettings["CertificatePass"];
        static string ResourceId = ConfigurationManager.AppSettings["ResourceId"];
        static string UrlWebApi = ConfigurationManager.AppSettings["UrlWebApi"];
        static string Authority = $@"{Instance}{Tenant}";

        static Dictionary<int, string> formato = new Dictionary<int, string>();


        static void Main(string[] args)
        {
            RealizarDescarga();
            //string resultado = PruebaConexion().Result;

            //Console.WriteLine(resultado);
            //Console.Read();
            //ImportarArchivoExcel();

        }
        static async Task<string> PruebaConexion()
        {

            IConfidentialClientApplication app;
            X509Certificate2 certificate = ReadCertificate(CertificateName);
            app = ConfidentialClientApplicationBuilder.Create(ClientId).WithCertificate(certificate).WithAuthority(new Uri(Authority)).Build();
            var scopes = new[] { ResourceId };
            AuthenticationResult result;

            try
            {
                result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
                var baseAddress = new Uri($@"{UrlWebApi}api/Usuario/ListarUsuarioMantenimiento");
                var response = await httpClient.GetAsync(baseAddress);
                var content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (MsalUiRequiredException ex)
            {
                throw ex;
                // The application doesn't have sufficient permissions.
                // - Did you declare enough app permissions during app creation?
                // - Did the tenant admin grant permissions to the application?
            }
            catch (MsalServiceException ex) when (ex.Message.Contains("AADSTS70011"))
            {
                throw ex;
                // Invalid scope. The scope has to be in the form "https://resourceurl/.default"
                // Mitigation: Change the scope to be as expected.
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        static void RealizarDescarga()
        {
            try
            {
                string sourceFile = $@"{localPath}\{fileName}";
                string destFolder;

                DescargarArchivoSFTP();
                LogFile.WriteLog("Archivo descargado con éxito");

                DefinirFormatoArchivo();

                string json = ProcesarArchivo(sourceFile);

                if (json != null)
                {

                    if (CargarBaseIngestaUsuario(json))
                    {
                        LogFile.WriteLog($@"Archivo procesado {sourceFile}");
                        destFolder = $@"{localPath}\procesados";
                    }
                    else
                    {
                        LogFile.WriteLog($@"Archivo no procesado {sourceFile}");
                        destFolder = $@"{localPath}\no_procesados";
                    }
                }
                else
                {
                    LogFile.WriteLog($@"Archivo no procesado {sourceFile}");
                    destFolder = $@"{localPath}\no_procesados";
                }

                string destFileName = $@"{fileName.Substring(0, fileName.IndexOf('.'))}_{DateTime.Now:yyyyMMddHHmmss}.txt";
                File.Move(sourceFile, $@"{destFolder}\{destFileName}");
                LogFile.WriteLog($"Archivo movido a {$@"{destFolder}\{destFileName}"}");




            }
            catch (Exception ex)
            {
                LogFile.WriteLog(ex);
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }

        static void DescargarArchivoSFTP()
        {
            Renci.SshNet.PasswordConnectionInfo pci = new Renci.SshNet.PasswordConnectionInfo(host, username, password);
            Sftp sftp = new Sftp(pci);
            try
            {
                sftp.downloadFile(localPath, fileName, serverPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        static void DefinirFormatoArchivo()
        {
            formato.Add(1, "MATRICULA");
            formato.Add(2, "APELLIDO PATERNO");
            formato.Add(3, "APELLIDO MATERNO");
            formato.Add(4, "NOMBRES");
            formato.Add(5, "DNI");
            formato.Add(6, "UBICACION");
            formato.Add(7, "UNIDAD ORGANIZATIVA");
            formato.Add(8, "CODIGO AGENCIA");
            formato.Add(9, "SEDE");
            formato.Add(10, "CORREO");
        }


        static string ProcesarArchivo(string sourceFile)
        {
            List<UsuarioIngesta> usuarioIngestaList = new List<UsuarioIngesta>();
            int cantCampos = int.Parse(numberOfFields);
            int fila = 0;

            try
            {
                using (var sr = new StreamReader(sourceFile))
                {
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var values = line.Split(char.Parse(separatorCharacter));

                        if (values.Length != cantCampos)
                        {
                            LogFile.WriteLog($"La fila #{fila:000000} en archivo {sourceFile} no cumple con la cantidad de campos definida [{cantCampos} campos]");
                            return null;
                        }

                        fila++;

                        if (fileHeader.Equals("1") && fila == 1)
                        {
                            foreach (var item in formato)
                            {
                                if (!string.Equals(Helper.QuitarTildes(values[item.Key - 1]).ToUpper(), item.Value))
                                {
                                    LogFile.WriteLog($"El campo '{item.Value}' en el archivo {sourceFile} debe estar ubicado en la posición {item.Key}");
                                    return null;
                                }
                            }
                            continue;

                        }

                        usuarioIngestaList.Add(new UsuarioIngesta()
                        {
                            Matricula = values[formato.FirstOrDefault(x => x.Value == "MATRICULA").Key - 1],
                            ApellidoPaterno = $"{values[formato.FirstOrDefault(x => x.Value == "APELLIDO PATERNO").Key - 1]}",
                            ApellidoMaterno = $"{values[formato.FirstOrDefault(x => x.Value == "APELLIDO MATERNO").Key - 1]}",
                            Nombres = $"{values[formato.FirstOrDefault(x => x.Value == "NOMBRES").Key - 1]}",
                            Dni = $"{values[formato.FirstOrDefault(x => x.Value == "DNI").Key - 1]}",
                            UnidadOrganizativa = $"{values[formato.FirstOrDefault(x => x.Value == "UNIDAD ORGANIZATIVA").Key - 1]}",
                            CodigoAgencia = values[formato.FirstOrDefault(x => x.Value == "CODIGO AGENCIA").Key - 1],
                            Sede = $"{values[formato.FirstOrDefault(x => x.Value == "SEDE").Key - 1]}",
                            Correo = $"{values[formato.FirstOrDefault(x => x.Value == "CORREO").Key - 1]}",
                        });
                    }
                }

                if (usuarioIngestaList.Count > 0)
                {
                    return JsonConvert.SerializeObject(usuarioIngestaList);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                LogFile.WriteLog(ex);
                return null;
            }

        }

        static bool CargarBaseIngestaUsuario(string json)
        {
            if (json != null)
            {
                try
                {
                    //string resultado = IngestaUsuario(json).Result;
                    string resultado = IngestaUsuarioWS(json).Result;
                    if (int.Parse(resultado) == 1)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return false;
        }

        static async Task<string> IngestaUsuarioWS(string json)
        {
            var data = new Dictionary<string, object>() { { "json", json } };

            StringContent stringContent;
            stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.PostAsync($@"{UrlWebApi}/ws/UsuarioWS.asmx/IngestaUsuario", new StringContent(json));
            var content = await response.Content.ReadAsStringAsync();
            return content;

        }


        static async Task<string> IngestaUsuario(string json)
        {

            IConfidentialClientApplication app;
            X509Certificate2 certificate = ReadCertificate(CertificateName);
            app = ConfidentialClientApplicationBuilder.Create(ClientId).WithCertificate(certificate).WithAuthority(new Uri(Authority)).Build();
            var scopes = new[] { ResourceId };
            AuthenticationResult result;


            try
            {
                result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
                var baseAddress = new Uri($@"{UrlWebApi}/ws/UsuarioWS.asmx/IngestaUsuario");
                var response = await httpClient.PostAsync(baseAddress, new StringContent(json));
                var content = await response.Content.ReadAsStringAsync();
                return content;


            }
            catch (MsalUiRequiredException ex)
            {
                throw ex;
                // The application doesn't have sufficient permissions.
                // - Did you declare enough app permissions during app creation?
                // - Did the tenant admin grant permissions to the application?
            }
            catch (MsalServiceException ex) when (ex.Message.Contains("AADSTS70011"))
            {
                throw ex;
                // Invalid scope. The scope has to be in the form "https://resourceurl/.default"
                // Mitigation: Change the scope to be as expected.
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static X509Certificate2 ReadCertificate(string certificateName)
        {
            if (string.IsNullOrWhiteSpace(certificateName))
            {
                throw new ArgumentException("certificateName should not be empty. Please set the CertificateName setting in the appsettings.json", "certificateName");
            }

            X509Certificate2 cert = new X509Certificate2(certificateName, CertificatePass, X509KeyStorageFlags.PersistKeySet);
            X509Store store = new X509Store(StoreName.My);
            store.Open(OpenFlags.ReadWrite);
            store.Add(cert);
            return cert;


        }

        public class InvalidTokenException : Exception
        {

        }
    }
}
