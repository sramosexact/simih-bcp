using Interna.Entity;
using System;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmObjetoEtiqueta : frmChild
    {
        public frmObjetoEtiqueta()
        {
            InitializeComponent();
        }

        public Objeto obj;


        private void frmObjetoEtiqueta_Load(object sender, EventArgs e)
        {
            if (obj != null)
            {
                this.Text = "Autogenerado : " + obj.Autogenerado;

                bccCodigoBarra.Text = obj.Autogenerado;
                txtAutogenerado.Text = txtAutogenerado.Text = $"{obj.Prefijo}-{obj.Autogenerado}";
                txt_destino.Text = obj.Destino + " - " + obj.CasillaPara;
                txt_para.Text = obj.Para;
                txt_origen.Text = obj.Origen + " - " + obj.CasillaDe;
                txt_de.Text = obj.De;

                btnAceptar.Focus();
                btnAceptar.Select();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
