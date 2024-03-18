using Interna.Entity;
using System;
using System.Collections.Generic;


namespace ExpedicionInternaPC
{
    public partial class frmTracking : frmChild
    {
        #region Variables

        public int ID = 0;
        public String Autogenerado = "";
        public string Estado = "";
        public Objeto oObjeto = null;
        public Objeto oObjetoImpresion = new Objeto();
        public List<ObjetoDetalle> listaObjetoDetalle;
        public List<Campo> listaCamposObjetoDetalle;

        #endregion

        // Revisado
        public frmTracking()
        {
            InitializeComponent();
        }
        // Revisado
        public frmTracking(int ID)
        {
            InitializeComponent();
            this.ID = ID;
        }
        //2022
        private void frmTracking_Load(object sender, EventArgs e)
        {

            /*Obtiene 3 listas de objetos ( Tracking del Autogenerado [0] | Cabecera del Autogenerado [1] | Detalle del Autogenerado [2] )*/
            try
            {
                List<String> lista = Metodos.VerTrackingAutogeneradoDesktop(this.ID);
                List<Objeto> tracking = Metodos.deserializarPrueba<Objeto>(lista[0]);
                List<Objeto> cabecera = Metodos.deserializarPrueba<Objeto>(lista[1]);
                List<Objeto> detalle = Metodos.deserializarPrueba<Objeto>(lista[2]);
                grdObjetoSeguimiento.DataSource = tracking;
                grdObjetoDetalle.DataSource = cabecera;
                grdDetalle.DataSource = detalle;
                this.Text = Program.titulo + " | Detalle de Autogenerado";
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
            catch (Exception)
            {
                Program.mensajeError("Ha ocurrido un error al intentar obtener el tracking del autogenerado.");
            }

        }

    }
}
