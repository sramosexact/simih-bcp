using Interna.Entity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExpedicionInternaPC
{
    public static class Requester
    {
        private static string apiHost = Properties.Settings.Default.rutaWS;
        private static string rvaHost = ""; // Properties.Settings.Default.rutaRVA;
        private static string uploadHost = ""; // Properties.Settings.Default.uploadHost;

        public static async Task<Usuario> AuthenticationRequest(string metodo, string credenciales, int idCliente, int modo)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                data.Add("iIdCliente", idCliente);
                data.Add("modoAutenticacion", modo);
                string dataJson = JsonConvert.SerializeObject(data);
                StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
                AuthenticationHeaderValue authenticationHeaderValue = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(credenciales)));

                HttpResponseMessage httpResponseMessage = await Post(apiHost + metodo, authenticationHeaderValue, stringContent);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if ((int)httpResponseMessage.StatusCode == 401)
                    {
                        return null;
                    }
                }

                string respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
                JContainer oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
                JToken d = oRespuesta.First.First;

                Response response = JsonConvert.DeserializeObject<Response>(d.ToString());

                Program.token = response.token;
                Program.refreshToken = response.refreshToken;

                return response.usuario;


            }
            catch (WebException we)
            {

                throw we;
            }
        }

        public static async Task<string> AuthorizationRequest(string metodo, Dictionary<string, object> data)
        {
            StringContent stringContent;
            if (data == null)
            {
                stringContent = new StringContent("", Encoding.UTF8, "application/json");
            }
            else
            {
                stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }
            AuthenticationHeaderValue authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", Convert.ToBase64String(Encoding.ASCII.GetBytes(Program.token)));

            HttpResponseMessage httpResponseMessage = await Post(apiHost + metodo, authenticationHeaderValue, stringContent);
            HttpResponseMessage httpResponseMessage2;
            string respuesta;
            JContainer oRespuesta;
            JToken d;

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if ((int)httpResponseMessage.StatusCode == 498)
                {
                    if (await RefreshToken())
                    {
                        if (data == null)
                        {
                            stringContent = new StringContent("", Encoding.UTF8, "application/json");
                        }
                        else
                        {
                            stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                        }
                        authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", Convert.ToBase64String(Encoding.ASCII.GetBytes(Program.token)));
                        httpResponseMessage2 = await Post(apiHost + metodo, authenticationHeaderValue, stringContent);
                        respuesta = await httpResponseMessage2.Content.ReadAsStringAsync();
                        oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
                        d = oRespuesta.First.First;
                        return d.ToString();
                    }
                    else
                    {
                        throw new InvalidTokenException();
                    }
                }
                else
                {

                }
            }

            respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
            oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
            d = oRespuesta.First.First;
            return d.ToString();

        }

        public static async Task<string> AuthorizationUpload(string metodo, MultipartFormDataContent form)
        {


            AuthenticationHeaderValue authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", Convert.ToBase64String(Encoding.ASCII.GetBytes(Program.token)));
            HttpResponseMessage httpResponseMessage = await FormDataPost(apiHost + metodo, authenticationHeaderValue, form);
            HttpResponseMessage httpResponseMessage2;
            string respuesta;
            JContainer oRespuesta;
            JToken d;

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if ((int)httpResponseMessage.StatusCode == 498)
                {
                    if (await RefreshToken())
                    {
                        authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", Convert.ToBase64String(Encoding.ASCII.GetBytes(Program.token)));
                        httpResponseMessage2 = await FormDataPost(apiHost + metodo, authenticationHeaderValue, form);
                        respuesta = await httpResponseMessage2.Content.ReadAsStringAsync();
                        oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
                        d = oRespuesta.First.First;
                        return d.ToString();
                    }
                    else
                    {
                        throw new InvalidTokenException();
                    }
                }
                else
                {

                }
            }

            respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
            oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
            d = oRespuesta.First.First;
            return d.ToString();

        }

        public static async Task<string> SimpleRequest(string metodo, Dictionary<string, object> data)
        {
            StringContent stringContent;
            if (data == null)
            {
                stringContent = new StringContent("", Encoding.UTF8, "application/json");
            }
            else
            {
                stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage httpResponseMessage = await Post(apiHost + metodo, null, stringContent);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if ((int)httpResponseMessage.StatusCode == 401)
                {
                    return null;
                }

                return null;
            }

            string respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
            JContainer oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
            JToken d = oRespuesta.First.First;
            return d.ToString();

        }

        public static async Task<string> SimpleRequestRVA(string metodo, Dictionary<string, object> data)
        {
            StringContent stringContent;
            if (data == null)
            {
                stringContent = new StringContent("", Encoding.UTF8, "application/json");
            }
            else
            {
                stringContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage httpResponseMessage = await Post(rvaHost + metodo, null, stringContent);
            string respuesta;
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                if ((int)httpResponseMessage.StatusCode == 401)
                {
                    return null;
                }
                respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
                return null;
            }

            respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
            JContainer oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
            JToken d = oRespuesta.First.First;
            return d.ToString();

        }

        public static async Task<bool> RefreshToken()
        {

            StringContent stringContent = new StringContent("", Encoding.UTF8, "application/json");
            AuthenticationHeaderValue authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", Convert.ToBase64String(Encoding.ASCII.GetBytes(Program.refreshToken)));
            HttpResponseMessage httpResponseMessage = await Post(apiHost + RutaWS.AuthWS + "refreshToken", authenticationHeaderValue, stringContent);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return false;
            }

            string respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
            JContainer oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
            JToken d = oRespuesta.First.First;
            Dictionary<string, string> tokens = JsonConvert.DeserializeObject<Dictionary<string, string>>(d.ToString());
            Program.token = tokens.Values.ToList()[0];
            Program.refreshToken = tokens.Values.ToList()[1];
            return true;

        }


        public static async Task<HttpResponseMessage> Post(string url, AuthenticationHeaderValue authenticationHeaderValue, StringContent stringContent)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
            try
            {
                return await httpClient.PostAsync(url, stringContent);
            }
            catch (WebException we)
            {
                throw we;
            }
        }

        public static async Task<HttpResponseMessage> FormDataPost(string url, AuthenticationHeaderValue authenticationHeaderValue, MultipartFormDataContent form)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
            try
            {
                return await httpClient.PostAsync(url, form);
            }
            catch (WebException we)
            {
                throw we;
            }
        }

        public static string AuthorizationTask(string url, Dictionary<string, object> data)
        {

            try
            {
                Task<string> tarea = Task.Run(async () => await AuthorizationRequest(url, data));

                tarea.Wait();

                return tarea.Result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }




        }

        public static string UploadTask(string url, MultipartFormDataContent form)
        {

            try
            {
                Task<string> tarea = Task.Run(async () => await SimpleUploadRequest(url, form));

                tarea.Wait();

                return tarea.Result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }




        }

        public static string SimpleTask(string url, Dictionary<string, object> data)
        {

            Task<string> tarea = Task.Run(async () => await SimpleRequest(url, data));

            tarea.Wait();

            return tarea.Result;
        }

        public static string SimpleTaskRVA(string url, Dictionary<string, object> data)
        {
            Task<string> tarea = Task.Run(async () => await SimpleRequestRVA(url, data));

            tarea.Wait();

            return tarea.Result;
        }



        public static async Task<string> SimpleUploadRequest(string metodo, MultipartFormDataContent form)
        {
            HttpResponseMessage httpResponseMessage = await SimpleFormDataPost(uploadHost + metodo, form);
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                return "-1";
            }
            string respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
            return respuesta;
        }


        public static async Task<HttpResponseMessage> SimpleFormDataPost(string url, MultipartFormDataContent form)
        {

            HttpClientHandler handler = new HttpClientHandler();
            IWebProxy proxy = WebRequest.GetSystemWebProxy();
            proxy.Credentials = CredentialCache.DefaultCredentials;
            handler.Proxy = proxy;

            HttpClient httpClient = new HttpClient();
            try
            {
                return await httpClient.PostAsync(url, form);
            }
            catch (WebException we)
            {
                throw we;
            }
        }

        public static string SimpleUploadTask(string url, MultipartFormDataContent form)
        {
            try
            {
                Task<string> tarea = Task.Run(async () => await SimpleUploadRequest(url, form));
                tarea.Wait();
                return tarea.Result;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerException;
            }
        }


        public static async Task<Usuario> AuthenticationAzureRequest(string metodo, string accessToken)
        {
            try
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                string dataJson = JsonConvert.SerializeObject(data);
                StringContent stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

                AuthenticationHeaderValue authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", accessToken);

                HttpResponseMessage httpResponseMessage = await Post(apiHost + metodo, authenticationHeaderValue, stringContent);

                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    if ((int)httpResponseMessage.StatusCode == 401)
                    {
                        return null;
                    }
                }

                string respuesta = await httpResponseMessage.Content.ReadAsStringAsync();
                JContainer oRespuesta = (JContainer)JsonConvert.DeserializeObject(respuesta);
                JToken d = oRespuesta.First.First;

                Response response = JsonConvert.DeserializeObject<Response>(d.ToString());

                Program.token = response.token;
                Program.refreshToken = response.refreshToken;

                return response.usuario;


            }
            catch (WebException we)
            {

                throw we;
            }
        }

    }
}
