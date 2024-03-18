using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace ExpedicionInternaPC
{

    public partial class frmBuscarCasilla : Form
    {
        private int IdUsuario = 0;

        public frmBuscarCasilla()
        {
            InitializeComponent();
        }

        public frmBuscarCasilla(int IdUsuario)
        {
            InitializeComponent();
            this.IdUsuario = IdUsuario;
        }

        private void BuscarCasilla_Load(object sender, EventArgs e)
        {
            //bsCasilla.DataSource = Metodos.GetConsultaBandejaActiva();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {



            //int IdCasilla = (int)seaBandeja.EditValue;
            int IdCasilla = (int)cboBandeja.SelectedValue;
            int res = 0;

            try
            {
                res = Metodos.VincularCasilla(IdCasilla, IdUsuario);
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
                return;
            }

            if (res > 0)
            {
                MessageBox.Show("Vinculacion exitosa", Program.titulo);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            if (res == -1)
            {
                MessageBox.Show("Vinculacion ya existe", Program.titulo);
                return;
            }

            if (res == -2)
            {
                MessageBox.Show("Usuario no existe", Program.titulo);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            if (res == -3)
            {
                MessageBox.Show("Casilla no existe", Program.titulo);
                return;
            }

        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            frmBuscarBandejaOrigen frmBBO = new frmBuscarBandejaOrigen();
            frmBBO.ShowDialog();
            if (frmBBO.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                List<Casilla> lC = new List<Casilla>();
                lC.Add(frmBBO.oC);

                cboBandeja.DataSource = lC;
                cboBandeja.DisplayMember = "Descripcion";
                cboBandeja.ValueMember = "ID";

            }
        }
    }

}
