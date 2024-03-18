using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmMantenimientoColaboradorPisos : frmChild
    {
        private ColaboradorPisos colaboradorPisos;
        public frmMantenimientoColaboradorPisos()
        {
            InitializeComponent();
            colaboradorPisos = new ColaboradorPisos();
        }

        public frmMantenimientoColaboradorPisos(ColaboradorPisos colaboradorPisos)
        {
            InitializeComponent();
            this.colaboradorPisos = colaboradorPisos;
        }

        private void frmMantenimientoColaboradorPisos_Load(object sender, EventArgs e)
        {
            ListarSedes();
            ListarEstado();
            CargarCampos();
        }

        private void ListarSedes()
        {
            List<Sede> sedes = Metodos.ListarSede();
            cboSede.Properties.DataSource = sedes;
            cboSede.Properties.DisplayMember = "Nombre";
            cboSede.Properties.ValueMember = "Id";
            cboSede.Properties.DropDownRows = sedes.Count;
        }

        private void ListarEstado()
        {
            List<EstadoRecorridoPisos> estados = new List<EstadoRecorridoPisos>();
            estados.Add(new EstadoRecorridoPisos() { Id = false, Descripcion = "INACTIVO" });
            estados.Add(new EstadoRecorridoPisos() { Id = true, Descripcion = "ACTIVO" });
            cboEstado.Properties.DataSource = estados;
            cboEstado.Properties.DisplayMember = "Descripcion";
            cboEstado.Properties.ValueMember = "Id";
            cboEstado.Properties.DropDownRows = estados.Count;
        }

        private void CargarCampos()
        {
            txtNombres.Text = colaboradorPisos.Nombres;
            txtApellidoPaterno.Text = colaboradorPisos.ApellidoPaterno;
            txtApellidoMaterno.Text = colaboradorPisos.ApellidoMaterno;
            txtDni.Text = colaboradorPisos.Dni;
            cboSede.EditValue = colaboradorPisos.SedeId;
            cboEstado.EditValue = colaboradorPisos.Activo;
            if (this.colaboradorPisos.Id == 0)
            {
                cboEstado.EditValue = true;
                cboEstado.Enabled = false;
            }

        }

        private bool ValidarControles()
        {
            if (txtNombres.Text.Trim() == "" ||
                txtApellidoPaterno.Text.Trim() == "" ||
                txtApellidoMaterno.Text.Trim() == "" ||
                txtDni.Text.Trim() == "" ||
                (int)cboSede.EditValue < 1)
            {
                Program.mensaje("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarControles()) return;

            int resultado = 0;

            colaboradorPisos.Nombres = txtNombres.Text.Trim().ToUpper();
            colaboradorPisos.ApellidoPaterno = txtApellidoPaterno.Text.Trim().ToUpper();
            colaboradorPisos.ApellidoMaterno = txtApellidoMaterno.Text.Trim().ToUpper();
            colaboradorPisos.Dni = txtDni.Text.Trim().ToUpper();
            colaboradorPisos.SedeId = (int)cboSede.EditValue;
            colaboradorPisos.Activo = (bool)cboEstado.EditValue;


            if (colaboradorPisos.Id == 0) resultado = Metodos.RegistrarColaboradorPisos(colaboradorPisos);
            else resultado = Metodos.ActualizarColaboradorPisos(colaboradorPisos);


            if (resultado == 1)
            {
                Program.mensaje("Se guardaron los cambios correctamente.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (resultado == -1)
            {
                Program.mensaje("Existe otro colaborador con el mismo DNI registrado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Program.mensaje("Ha ocurrido un error al intentar actualizar la información del colaborador.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtApellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            Program.mayusculas(e);
        }
    }
}
