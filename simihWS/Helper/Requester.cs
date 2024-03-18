using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace simihWS
{
    public static class Requester
    {
        private static string uploadHost = WebConfigurationManager.AppSettings.GetValues("uploadHost")[0].ToString();

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

    }
}
