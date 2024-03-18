using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace Encryption
{
    public class Encrypt
    {
        byte[] llave;

        public Encrypt()
        {
            //this.llave = llave;
            llave = Encoding.ASCII.GetBytes(File.ReadAllText(ConfigurationManager.AppSettings["rutaLlave"].ToString()));
        }

        public string Encriptar(string datoDesencriptado)
        {
            return Encryption.Encrypt(datoDesencriptado, llave);
        }

        public string Desencriptar(string datoEncriptado)
        {
            return Encryption.Decrypt(datoEncriptado, llave);
        }

        public List<Dictionary<string, object>> Encriptar(List<Dictionary<string, object>> lista, params string[] atributos)
        {
            List<Dictionary<string, object>> listaEncriptada = new List<Dictionary<string, object>>();
            lista.ForEach(elemento =>
            {
                Dictionary<string, object> nuevoElemento = new Dictionary<string, object>();
                foreach (KeyValuePair<string, object> dataEntry in elemento)
                {
                    bool encuentra = false;
                    foreach (string atributo in atributos)
                    {
                        if (atributo.Equals(dataEntry.Key))
                        {
                            nuevoElemento[dataEntry.Key] = dataEntry.Value == null || dataEntry.Value.Equals("") ? "" : Encryption.Encrypt(dataEntry.Value.ToString(), llave);
                            encuentra = true;
                            break;
                        }
                    }
                    if (!encuentra)
                    {
                        nuevoElemento[dataEntry.Key] = dataEntry.Value;
                    }
                }
                listaEncriptada.Add(nuevoElemento);
            });
            return listaEncriptada;
        }

        public List<Dictionary<string, object>> Desencriptar(List<Dictionary<string, object>> lista, params string[] atributos)
        {
            List<Dictionary<string, object>> listaEncriptada = new List<Dictionary<string, object>>();
            lista.ForEach(elemento =>
            {
                Dictionary<string, object> nuevoElemento = new Dictionary<string, object>();
                foreach (KeyValuePair<string, object> dataEntry in elemento)
                {
                    bool encuentra = false;
                    foreach (string atributo in atributos)
                    {
                        if (atributo.Equals(dataEntry.Key))
                        {
                            nuevoElemento[dataEntry.Key] = dataEntry.Value == null || dataEntry.Value.Equals("") ? "" : Encryption.Decrypt(dataEntry.Value.ToString(), llave);
                            encuentra = true;
                            break;
                        }
                    }
                    if (!encuentra)
                    {
                        nuevoElemento[dataEntry.Key] = dataEntry.Value;
                    }
                }
                listaEncriptada.Add(nuevoElemento);
            });
            return listaEncriptada;
        }
    }
}
