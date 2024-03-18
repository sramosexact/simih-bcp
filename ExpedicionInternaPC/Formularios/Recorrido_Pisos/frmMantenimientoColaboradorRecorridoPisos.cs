using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmMantenimientoColaboradorRecorridoPisos : frmChild
    {
        public frmMantenimientoColaboradorRecorridoPisos()
        {
            InitializeComponent();
        }

        private void HyperLinkModificar_Click(object sender, EventArgs e)
        {
            ColaboradorPisos colaboradorPisos = (ColaboradorPisos)grvColaboradores.GetFocusedRow();

            frmMantenimientoColaboradorPisos frm = new frmMantenimientoColaboradorPisos(colaboradorPisos);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                ListarColaboradoresPisoMantenimiento();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmMantenimientoColaboradorPisos frm = new frmMantenimientoColaboradorPisos();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                ListarColaboradoresPisoMantenimiento();
            }
        }

        private void frmMantenimientoColaboradorRecorridoPisos_Load(object sender, EventArgs e)
        {
            ListarColaboradoresPisoMantenimiento();
        }

        private void ListarColaboradoresPisoMantenimiento()
        {
            List<ColaboradorPisos> colaboradoresPisos = Metodos.ListarColaboradoresPisoMantenimiento();

            grdColaboradores.DataSource = colaboradoresPisos;


        }
    }
}
