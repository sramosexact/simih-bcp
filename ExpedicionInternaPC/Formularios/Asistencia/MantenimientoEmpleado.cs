using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class MantenimientoEmpleado : frmChild
    {
        private Empleado empleado;
        public MantenimientoEmpleado()
        {
            InitializeComponent();
            empleado = new Empleado();
        }

        public MantenimientoEmpleado(Empleado empleado)
        {
            InitializeComponent();
            this.empleado = empleado;
        }

        private void MantenimientoEmpleado_Load(object sender, EventArgs e)
        {
            ListarAreas();
            ListarEstado();
            CargarCampos();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarControles()) return;
            int resultado = 0;

            empleado.Nombres = txtNombres.Text.Trim().ToUpper();
            empleado.ApellidoPaterno = txtApellidoPaterno.Text.Trim().ToUpper();
            empleado.ApellidoMaterno = txtApellidoMaterno.Text.Trim().ToUpper();
            empleado.Dni = txtDni.Text.Trim().ToUpper();
            empleado.HoraIngreso = TimeSpan.Parse(txtHoraIngreso.Text);
            empleado.AreaId = (int)cboArea.EditValue;
            empleado.EstadoId = (int)cboEstado.EditValue;


            if (empleado.Id == 0) resultado = Metodos.RegistrarEmpleado(empleado);
            else resultado = Metodos.ActualizarEmpleado(empleado);


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

        private void ListarAreas()
        {
            List<Area> areas = Metodos.ListarArea();
            cboArea.Properties.DataSource = areas;
            cboArea.Properties.DisplayMember = "Nombre";
            cboArea.Properties.ValueMember = "Id";
            cboArea.Properties.DropDownRows = areas.Count;
        }

        private void ListarEstado()
        {
            List<EstadoAsistencia> estados = Metodos.ListarEstadoAsistencia();
            cboEstado.Properties.DataSource = estados;
            cboEstado.Properties.DisplayMember = "Descripcion";
            cboEstado.Properties.ValueMember = "Id";
            cboEstado.Properties.DropDownRows = estados.Count;
        }

        private void CargarCampos()
        {
            txtNombres.Text = empleado.Nombres;
            txtApellidoPaterno.Text = empleado.ApellidoPaterno;
            txtApellidoMaterno.Text = empleado.ApellidoMaterno;
            txtDni.Text = empleado.Dni;
            txtHoraIngreso.Text = empleado.HoraIngreso.ToString();
            cboArea.EditValue = empleado.AreaId;
            cboEstado.EditValue = empleado.EstadoId;
        }

        private bool ValidarControles()
        {
            if (txtNombres.Text.Trim() == "" ||
                txtApellidoPaterno.Text.Trim() == "" ||
                txtApellidoMaterno.Text.Trim() == "" ||
                txtDni.Text.Trim() == "" ||
                txtHoraIngreso.Text.Trim() == "" ||
                (int)cboArea.EditValue < 1 ||
                (int)cboEstado.EditValue < 1)
            {
                Program.mensaje("Debe completar todos los campos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
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
