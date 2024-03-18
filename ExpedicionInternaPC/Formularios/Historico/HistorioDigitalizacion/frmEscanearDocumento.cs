using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WIA;

namespace ExpedicionInternaPC
{
    public partial class frmEscanearDocumento : frmChild
    {

        #region Propiedades
        List<Interna.Entity.Scanner> escaneres = new List<Interna.Entity.Scanner>();

        #endregion

        #region Metodos

        public void ListarEscaneres()
        {
            DeviceManager deviceManager = new DeviceManager();

            escaneres = new List<Interna.Entity.Scanner>();

            foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos)
            {
                if (deviceInfo.Type == WiaDeviceType.ScannerDeviceType)
                {
                    escaneres.Add(new Interna.Entity.Scanner(deviceInfo));
                }
            }

            if (escaneres.Count == 0)
            {
                Program.mensaje("Configure algún escáner en su equipo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lueEscaneres.Properties.DataSource = escaneres;
            lueEscaneres.Properties.DisplayMember = "nombreEscaner";
            lueEscaneres.Properties.ValueMember = "nombreEscaner";
            lueEscaneres.Properties.DropDownRows = escaneres.Count;

        }

        public void Escanear(Interna.Entity.Scanner scanner)
        {
            //frmRegistroDigitalizacionDocumentos fx = (frmRegistroDigitalizacionDocumentos)Program.GetFormOpen("Digitalizar-documentos", typeof(frmRegistroDigitalizacionDocumentos));
            //frmRegistroDigitalizacionDocumentos fx = (frmRegistroDigitalizacionDocumentos)(Program.oMain.OwnedForms.Select(x=> x.Tag = "Digitalizar-documentos"));
            //fx.liberarRecurso();
            try
            {
                ImageFile imagen = new ImageFile();
                imagen = scanner.ScanJPEG();
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "scanSimih.jpeg";

                File.Delete(path);
                imagen.SaveFile(path);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception e)
            {
                Program.mensaje("Ha ocurrido un problema. Inténtelo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }

        /*public void AdquirirImagen()
        {
            try
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "scanSimih.jpeg";
                File.Delete(path);
                Image.FromFile(path);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception e)
            {
                Program.mensaje("Ha ocurrido un problema. Inténtelo nuevamente.", MessageBoxButtons.OK, MessageBoxIcon.Error);

                this.Close();
            }
        }*/

        #endregion


        public frmEscanearDocumento()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            try
            {
                Interna.Entity.Scanner escanerSeleccionado = (Interna.Entity.Scanner)lueEscaneres.GetSelectedDataRow();
                Escanear(escanerSeleccionado);
            }
            catch (Exception)
            {
                Program.mensaje("Debe seleccionar el escáner", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEscanearDocumento_Load(object sender, EventArgs e)
        {
            ListarEscaneres();
        }
    }
}
