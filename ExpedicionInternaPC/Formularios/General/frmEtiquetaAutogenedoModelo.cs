using Interna.Entity;
using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmEtiquetaAutogenedoModelo : Form
    {

        private Objeto objetoImpresion;
        public frmEtiquetaAutogenedoModelo(Objeto obj)
        {
            this.objetoImpresion = obj;
            InitializeComponent();
        }

        private void frmEtiquetaAutogenedoModelo_Load(object sender, EventArgs e)
        {
            EtiquetaCustodia etiqueta = new EtiquetaCustodia();

            etiqueta.De = objetoImpresion.De.ToUpper();
            etiqueta.AreaOrigen = objetoImpresion.AreaOrigen;
            etiqueta.Origen = objetoImpresion.Origen.ToUpper();
            etiqueta.Para = objetoImpresion.Para.ToUpper();
            etiqueta.AreaDestino = objetoImpresion.AreaDestino;
            etiqueta.Destino = objetoImpresion.sDestino;
            etiqueta.Autogenerado = objetoImpresion.Autogenerado.ToUpper();
            etiqueta.Prefijo = objetoImpresion.Prefijo.ToUpper();


            lblDe.Text = etiqueta.De;
            lblAreaOrigen.Text = etiqueta.AreaOrigen;
            lblPara.Text = etiqueta.Para;
            lblAreaDestino.Text = etiqueta.AreaDestino;
            lblDestino.Text = etiqueta.Destino;
            lblAutogenerado.Text = $"{etiqueta.Prefijo} - {etiqueta.Autogenerado.Substring(0, 6)} - {etiqueta.Autogenerado.Substring(6)}";
            lblAutogeneradoCB.Text = $"*{etiqueta.Autogenerado}*";
        }
    }
}
