using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Interna.Entity
{
    public class SIMServer : Interna.Core.Entity
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public delegate void DelegadoMensaje(string mensaje);
        public event DelegadoMensaje MensajeNuevo;

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    //blocks until a client sends a message
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    //a socket error has occured
                    break;
                }

                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    break;
                }

                //message has successfully been received
                ASCIIEncoding encoder = new ASCIIEncoding();
                this.MensajeNuevo(encoder.GetString(message, 0, bytesRead));
            }

            tcpClient.Close();
        }

        private void ListenForClients()
        {
            tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                TcpClient client = tcpListener.AcceptTcpClient();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        public int Run()
        {
            tcpListener = new TcpListener(IPAddress.Any, 80);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            listenThread.Start();

            return 1;
        }
    }
}
