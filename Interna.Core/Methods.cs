using System;
using System.Security.Cryptography;
using System.Text;

namespace Interna.Core
{
    public class Methods
    {
        #region EncriptarF1
        private string[] Entrada = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string[] Entrada2 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private string Salida = "2547896310";
        private string Reflector = "9856723410";
        public int vuelta = 0;
        public void Next()
        {
            string valor = Entrada[0];
            for (int i = 1; i < Entrada.Length; i++)
            {
                Entrada[i - 1] = Entrada[i];
            }
            Entrada[Entrada.Length - 1] = valor;
        }
        public void Back()
        {
            string[] ent = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Entrada = ent;
        }
        public string Codificar(string a)
        {
            string valor = "";
            for (int j = 0; j < a.Length; j++)
            {
                for (int i = 0; i < Entrada.Length; i++)
                {
                    if (Entrada[i] == a[j].ToString())
                    {
                        for (int k = 0; k < Entrada.Length; k++)
                        {
                            if (Entrada2[k] == Salida[i].ToString())
                            {
                                for (int l = 0; l < Entrada.Length; l++)
                                {
                                    if (Salida[l].ToString() == Reflector[k].ToString())
                                    {
                                        valor = valor + Entrada[l].ToString();
                                        l = Entrada.Length;
                                        k = Entrada.Length;
                                        i = Entrada.Length;
                                    }
                                }
                            }
                        }
                    }
                }
                Next();
            }
            return valor;
        }
        #endregion
        #region EncriptarF2
        public string Encriptar(String Cadena)
        {
            String key = "MLKOPZAQIJSWEDCXNTYGHURFVB0785412369qscazxwdvpoilkjmnbuhgfrty";
            Byte[] keyArray;
            Byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(Cadena);
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.ANSIX923;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            Byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);
            tdes.Clear();
            return Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
        }
        public string Desencriptar(String Cadena)
        {
            try
            {
                String key = "MLKOPZAQIJSWEDCXNTYGHURFVB0785412369qscazxwdvpoilkjmnbuhgfrty";
                Byte[] keyArray;
                Byte[] Arreglo_a_Descifrar = Convert.FromBase64String(Cadena);
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.ANSIX923;
                ICryptoTransform cTransform = tdes.CreateDecryptor();
                Byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Descifrar, 0, Arreglo_a_Descifrar.Length);
                tdes.Clear();
                return UTF8Encoding.UTF8.GetString(ArrayResultado);

            }
            catch
            {
                return "";
            }
        }
        #endregion
    }
}
