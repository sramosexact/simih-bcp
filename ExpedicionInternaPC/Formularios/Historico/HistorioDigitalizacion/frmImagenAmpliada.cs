using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmImagenAmpliada : frmChild
    {
        #region Variables

        public string NombreImagen;
        public string Documento;
        public string CodigoDocumento;
        public Image ImagenAdquirida;
        private string RUTA_IMAGEN_SERVIDOR = ""; //Settings.Default.RutaImagenServidor;

        #endregion

        #region Metodos

        private void CargarImagenTamañoOriginal()
        {
            this.Text = string.Format("{0} : {1}", Documento, CodigoDocumento);
            //ImagenAdquirida;
            picImagen.Image = ImagenAdquirida;
            picImagen.Properties.ContextMenuStrip = new ContextMenuStrip();
        }

        private void Ampliar()
        {
            picImagen.Properties.ZoomPercent = picImagen.Properties.ZoomPercent + 10;
        }

        private void Reducir()
        {
            picImagen.Properties.ZoomPercent = picImagen.Properties.ZoomPercent - 10;
        }

        private void Original()
        {
            picImagen.Properties.ZoomPercent = 100;
        }

        private void Ajustar()
        {
            int contenedor = 0;
            int contenido = 0;
            if (picImagen.Image.Height >= picImagen.Image.Width)
            {
                contenido = picImagen.Image.Height;
                contenedor = picImagen.Height;
            }
            else
            {
                contenido = picImagen.Image.Width;
                contenedor = picImagen.Width;
            }

            int porcentaje = (contenedor * 100) / contenido;
            picImagen.Properties.ZoomPercent = porcentaje;
        }

        #endregion

        public frmImagenAmpliada()
        {
            InitializeComponent();
        }

        private void frmImagenAmpliada_Load(object sender, EventArgs e)
        {
            CargarImagenTamañoOriginal();
        }

        private void btnAmpliar_Click(object sender, EventArgs e)
        {
            Ampliar();
        }

        private void btnReducir_Click(object sender, EventArgs e)
        {
            Reducir();
        }

        private void btnOriginal_Click(object sender, EventArgs e)
        {
            Original();
        }

        private void picImagen_Properties_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Math.Sign(e.Delta) == 1)
            {
                Ampliar();
            }
            else if (Math.Sign(e.Delta) == -1)
            {
                Reducir();
            }
        }

        private void btnAjustar_Click(object sender, EventArgs e)
        {
            Ajustar();
        }
    }
}
