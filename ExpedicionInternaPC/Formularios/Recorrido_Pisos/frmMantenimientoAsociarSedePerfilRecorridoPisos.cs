using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public partial class frmMantenimientoAsociarSedePerfilRecorridoPisos : frmChild
    {
        private List<Sede> SedesList = new List<Sede>();
        private List<Sede> SedeUsuarioList = new List<Sede>();
        private void ListarSedes()
        {
            SedesList = Metodos.ListarSede();
            cboListaSedes.Properties.DisplayMember = "Nombre";
            cboListaSedes.Properties.ValueMember = "Id";
            cboListaSedes.Properties.DropDownRows = SedesList.Count;
            cboListaSedes.EditValue = null;
        }

        //private void ListarSedesAsignadas()
        //{
        //    List<Sede> SedesAsignadasList = Metodos.ListarSedesAsignadas();
        //}

        //private void ListarUsuarioPerfil()
        //{
        //    List<UsuarioPerfil> UsuarioPerfilList = Metodos.
        //}

        public frmMantenimientoAsociarSedePerfilRecorridoPisos()
        {
            InitializeComponent();
        }

        private void frmMantenimientoAsociarSedePerfilRecorridoPisos_Load(object sender, EventArgs e)
        {
            ListarSedes();
        }

        private void btnAgregarSede_Click(object sender, EventArgs e)
        {
            Sede sede = (Sede)cboListaSedes.GetSelectedDataRow();
            if (SedeUsuarioList.Contains(sede)) SedeUsuarioList.Add(sede);


        }
    }
}
