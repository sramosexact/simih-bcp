using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmMantenimientoEmpleadoAsistencia : frmChild
    {
        public frmMantenimientoEmpleadoAsistencia()
        {
            InitializeComponent();
        }

        private void frmMantenimientoEmpleadoAsistencia_Load(object sender, EventArgs e)
        {
            ListarEmpleadosMantenimiento();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MantenimientoEmpleado frm = new MantenimientoEmpleado();
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                ListarEmpleadosMantenimiento();
            }
        }


        private void HyperLinkModificar_Click(object sender, EventArgs e)
        {
            Empleado empleado = (Empleado)grvEmpleados.GetFocusedRow();

            MantenimientoEmpleado frm = new MantenimientoEmpleado(empleado);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                ListarEmpleadosMantenimiento();
            }

        }

        private void HyperLinkEliminar_Click(object sender, EventArgs e)
        {
            Empleado empleado = (Empleado)grvEmpleados.GetFocusedRow();
            if (Program.mensajeConfirmacion($"¿Desea eliminar el registro del colaborador '{empleado.ApellidoPaterno} {empleado.ApellidoMaterno}, {empleado.Nombres}'?") == DialogResult.Yes)
            {
                int resultado = Metodos.EliminarEmpleado(empleado.Id);
                if (resultado == 1)
                {
                    Program.mensaje("Se ha eliminado al colaborador seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (resultado == -1)
                {
                    Program.mensaje("El colaborador seleccionado no existe.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Program.mensaje("Ha ocurrido un error al intentar eliminar el registro del colaborador seleccionado.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ListarEmpleadosMantenimiento()
        {
            List<Empleado> empleados = Metodos.ListarEmpleadosMantenimiento();

            grdEmpleados.DataSource = empleados;


        }
    }
}
