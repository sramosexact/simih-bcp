using InTheHand.Net;
using InTheHand.Net.Sockets;
using System;
//using WindowsPortableDevicesLib;
//using WindowsPortableDevicesLib.Domain;
using System.Management;
using System.Security.Permissions;
using System.Threading;

namespace ExpedicionInternaPC
{
    public delegate void verficarDispositivosEventHandler();
    public static partial class Metodos
    {

        public static ThreadStart thPisos;
        public static Thread thrPisos;

        public static ThreadStart thAgencias;
        public static Thread thrAgencias;


        public static event verficarDispositivosEventHandler ConectadoEventHandler;
        public static event verficarDispositivosEventHandler DesconectadoEventHandler;
        public static event verficarDispositivosEventHandler ConectadoPDAEventHandler;
        public static event verficarDispositivosEventHandler DesconectadoPDAEventHandler;
        public static void inicializarThreadPisos()
        {
            thPisos = new ThreadStart(escuchandoDispositivo);
            thrPisos = new Thread(thPisos);
            thrPisos.Start();
        }

        public static void inicializarThreadAgencias()
        {
            thAgencias = new ThreadStart(escuchandoDispositivo);
            thrAgencias = new Thread(thAgencias);
            thrAgencias.Start();
        }

        private static void escuchandoDispositivo()
        {
            while (true)
            {
                verificar();
                Thread.Sleep(2000);

            }
        }

        private static void verificar()
        {
            //StandardWindowsPortableDeviceService pDeviceService = new StandardWindowsPortableDeviceService();
            //IList<WindowsPortableDevice> devices = pDeviceService.Devices;
            //if (devices.Count == 0)
            //{
            //    OnDesconectado();
            //    OnDesconectadoPDA();
            //    return;
            //}
            ////foreach (WindowsPortableDevice dispositivo in devices)
            //int j = 0;
            //int k = 0;
            //for (int i = 0; i < devices.Count; i++)           
            //{
            //    WindowsPortableDevice dispositivo = devices[i];
            //    dispositivo.ToString();
            //    if (dispositivo.DeviceType == 2)
            //    {
            //        j++;
            //    }

            //    if (dispositivo.DeviceType == 5)
            //    {
            //        k++;
            //    }
            //}

            //if (j != 1)
            //{
            //    OnDesconectado();
            //}
            //else
            //{
            //    OnConectado();

            //}

            //if (k != 1)
            //{
            //    OnDesconectadoPDA();
            //}
            //else
            //{
            //    OnConectadoPDA();

            //}


        }

        public static void OnConectado()
        {
            if (ConectadoEventHandler != null)
                ConectadoEventHandler();
        }

        public static void OnDesconectado()
        {
            if (DesconectadoEventHandler != null)
                DesconectadoEventHandler();
        }

        public static void OnConectadoPDA()
        {
            if (ConectadoPDAEventHandler != null)
                ConectadoPDAEventHandler();
        }

        public static void OnDesconectadoPDA()
        {
            if (DesconectadoPDAEventHandler != null)
                DesconectadoPDAEventHandler();
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public static void CerrarHiloPisos()
        {
            thrPisos.Abort();
        }
        // Funcional - frmListaEntregaAgencias
        public static void CerrarHiloAgencias()
        {
            thrAgencias.Abort();
        }

        public static void DescubrirDispositivosBluetooth()
        {
            try
            {
                // mac is mac address of local bluetooth device
                string mac = FindMACAddress();
                //long value = long.Parse(mac, NumberStyles.HexNumber, CultureInfo.GetCultureInfo("es-PE").NumberFormat);
                //byte[] macBytes = BitConverter.GetBytes(value);
                BluetoothAddress direccionMacBlueTooth = BluetoothAddress.Parse(mac);
                //BluetoothEndPoint localEndpoint = new BluetoothEndPoint(direccionMacBlueTooth, BluetoothService.SerialPort);
                // client is used to manage connections
                BluetoothClient localClient = new BluetoothClient();
                // component is used to manage device discovery
                //BluetoothComponent localComponent = new BluetoothComponent(localClient);
                //BluetoothDeviceInfo[] paired = localClient.DiscoverDevices(255, false, true, false, false);
                //foreach (BluetoothDeviceInfo item in paired)
                //{
                //    if (item.DeviceName == "Exact Movil")
                //    {
                //        Guid g = new Guid("00001101-0000-1000-8000-00805F9B34FB");
                //        var endP = new BluetoothEndPoint(item.DeviceAddress,g,1);
                //        localClient.Connect(endP);
                //    }
                //}
            }
            catch (Exception e)
            {

                throw;
            }

        }

        public static string FindMACAddress()
        {
            //create out management class object using the
            //Win32_NetworkAdapterConfiguration class to get the attributes
            //af the network adapter
            ManagementClass mgmt = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //create our ManagementObjectCollection to get the attributes with
            ManagementObjectCollection objCol = mgmt.GetInstances();
            string address = String.Empty;
            //My modification to the code
            var description = String.Empty;
            //loop through all the objects we find
            foreach (ManagementObject obj in objCol)
            {
                if (address == String.Empty)  // only return MAC Address from first card
                {
                    //grab the value from the first network adapter we find
                    //you can change the string to an array and get all
                    //network adapters found as well
                    if ((bool)obj["IPEnabled"] == true)
                    {
                        address = obj["MacAddress"].ToString();
                        description = obj["Description"].ToString();
                    }
                }
                //dispose of our object
                obj.Dispose();
            }
            //replace the ":" with an empty space, this could also
            //be removed if you wish
            //address = address.Replace(":", "");
            //return the mac address
            return address;
        }
    }
}
