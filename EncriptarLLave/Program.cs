using System;
using System.IO;
using System.Text;

namespace EncriptarLLave
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyString = "6512342344132135";
            //string keyString = "9517537894561235";
            byte[] key = Encoding.ASCII.GetBytes(keyString);

            //string encoded = Encryption.Encryption.Encrypt("User ID=sa;Password=+Azure2021+;Initial Catalog=simprueba;Data Source=VM-ETHICAL-HACK\\SQLEXPRESS", key);
            //string encoded = Encryption.Encryption.Encrypt("User ID=sa;Password=123456;Initial Catalog=simbcp;Data Source=DESKTOP-2GVEGEA\\SQLEXPRESS", key);
            //string encoded = Encryption.Encryption.Encrypt("User ID=sa;Password=123456;Initial Catalog=simbcpago23;Data Source=DESKTOP-2GVEGEA\\SQLEXPRESS", key);
            //string encoded = Encryption.Encryption.Encrypt("User ID=adminexact;Password=E9iA9NDX8k8py4Go;Initial Catalog=simbcp;Data Source=sql-exact.database.windows.net", key);
            //string encoded = Encryption.Encryption.Encrypt("User ID=sa;Password=+Azure2021+;Initial Catalog=simbcpbkpiloto;Data Source=VM-ETHICAL-HACK\\SQLEXPRESS", key);
            //string encoded = Encryption.Encryption.Encrypt("User ID=sa;Password=+Azure2021+;Initial Catalog=simbfa;Data Source=VM-ETHICAL-HACK\\SQLEXPRESS", key);
            //string encoded = Encryption.Encryption.Encrypt("User ID=sa;Password=+Share12345;Initial Catalog=simfab;Data Source=EXACTSERVER04\\SQLEXPRESS", key);
            //string encoded = Encryption.Encryption.Encrypt("User ID=sa;Password=+Azure2021+;Initial Catalog=simbcpago23;Data Source=VM-ETHICAL-HACK\\SQLEXPRESS;Max Pool Size=50000;", key);
            //string encoded = Encryption.Encryption.Encrypt("User ID=adminexact;Password=E9iA9NDX8k8py4Go;Initial Catalog=simbcp;Data Source=sql-exact.database.windows.net;Max Pool Size=50000", key);
            string encoded = Encryption.Encryption.Encrypt("User ID=adminexact;Password=E9iA9NDX8k8py4Go;Initial Catalog=qa_simbcp_2024-03-11T21-54Z;Data Source=sql-exact.database.windows.net", key);

            string decoded = Encryption.Encryption.Decrypt("LAzlcQxwcwPhXAyQjt9kP5z5KPpZRLcZ54Mcj1zCA5ZxvraaE6qKE3V5tLsaEW0wya0TfgckLTGw99NjP8aqwB/5IqVXNAeomf7+eCAST+zU7xWZlWor57XPqYs3y9XZGNkHAUY3tPQ90NgY6JYe8rZOHSxryH+w27cBcMeeBixfxHLpqDuEpSoqe8WwKl97", key);
            Console.WriteLine("DECODIFICADO:");
            Console.WriteLine(decoded);
            //Console.WriteLine(encoded);
            Console.WriteLine("USUARIO:");
            Console.WriteLine(Encryption.Encryption.Encrypt("bvillar@exactsac.onmicrosoft.com",key));

            StreamWriter objWriter = new StreamWriter("C:/Llaves/llavecifrada.txt");

            objWriter.Write(encoded);
            Console.ReadLine();
            objWriter.Close();


        }
    }
}
