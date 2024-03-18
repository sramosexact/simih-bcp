using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmExpedicionDominio : frmChild
    {
        //
        public frmExpedicionDominio()
        {
            InitializeComponent();
        }
        public Expedicion oExpedicion;
        public Expedicion oEr;

        #region "Metodos"
        public void cargarListaExpedicion()
        {
            if (oExpedicion.Descripcion.Length > 0)
                btnQuitarDominio.Text = " " + oExpedicion.Descripcion;
            else
                btnQuitarDominio.Enabled = false;
            List<Expedicion> lEx = new List<Expedicion>();
            //lEx = Metodos.ListarExpedicionGeoDominio(oExpedicion);
            cboExpedicion.Properties.DataSource = lEx;
            cboExpedicion.Properties.DropDownRows = lEx.Count;
        }

        private void VincularDominio()
        {
            Geo oG = new Geo();
            oG.ID = oExpedicion.IdGeo;
            oG.IdExpedicionDominio = Convert.ToInt32(cboExpedicion.EditValue.ToString());

            oEr = new Expedicion();
            //oEr = Metodos.AsignarExpedicionDominio(oG);
            if (oEr == null)
            {
                MessageBox.Show("No se pudo realizar la acción.", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void DesvincularDominio()
        {
            if (oExpedicion.ID == 0)
            {
                MessageBox.Show("No existe Expedicion Dominio Asignado", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (MessageBox.Show("Va a desvincular la expedición de la zona geográfica seleccionada. ¿Desea continuar?.", Program.titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                Geo oG = new Geo();
                oG.ID = oExpedicion.IdGeo;
                oG.IdExpedicionDominio = 0;

                oEr = new Expedicion();
                //oEr = Metodos.AsignarExpedicionDominio(oG);
                if (oEr == null)
                {
                    MessageBox.Show("No se pudo realizar la acción.", Program.titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        #endregion

        private void frmExpedicionDominio_Load(object sender, EventArgs e)
        {
            cargarListaExpedicion();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            VincularDominio();
        }

        private void cboExpedicion_EditValueChanged(object sender, EventArgs e)
        {
            btnAceptar.Enabled = true;
            btnQuitarDominio.Enabled = false;
        }

        private void btnQuitarDominio_Click(object sender, EventArgs e)
        {
            DesvincularDominio();
        }
    }
}
