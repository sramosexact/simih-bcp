using Renci.SshNet;
using System;
using System.IO;

namespace SIMIHSFTP.SFTP
{
    public class Sftp
    {
        private PasswordConnectionInfo pci;

        public Sftp(PasswordConnectionInfo pci)
        {
            this.pci = pci;
        }

        public void uploadFile(string localPath, string fileName, string serverPath = @"\public")
        {
            try
            {
                using (SftpClient client = new SftpClient(pci))
                {
                    client.Connect();

                    string localFile = $@"{localPath}\{fileName}";
                    string serverFile = $@"{serverPath}\{fileName}";

                    using (Stream stream = File.OpenRead(localFile))
                    {
                        client.UploadFile(stream, serverFile, x => Console.WriteLine(x));
                    }

                    client.Disconnect();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void downloadFile(string localPath, string fileName, string serverPath = @"\public")
        {
            try
            {
                using (SftpClient client = new SftpClient(pci))
                {
                    client.Connect();

                    string localFile = $@"{localPath}\{fileName}";
                    string serverFile = $@"{serverPath}\{fileName}";

                    using (Stream stream = File.OpenWrite(localFile))
                    {
                        client.DownloadFile(serverFile, stream, x => Console.WriteLine(x));
                    }

                    client.Disconnect();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
