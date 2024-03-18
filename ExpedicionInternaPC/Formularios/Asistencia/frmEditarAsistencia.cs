using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmEditarAsistencia : frmChild
    {
        public RegistroAsistencia registroAsistencia;
        public PerfilAsistencia Perfil;
        public frmEditarAsistencia()
        {
            InitializeComponent();
        }

        private void frmEditarAsistencia_Load(object sender, EventArgs e)
        {
            ListarEstado();
            ListarUbicacion();
            CargarControles();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void CargarControles()
        {
            txtColaborador.Text = registroAsistencia.Colaborador.ToUpper();
            cboFechaIngreso.EditValue = registroAsistencia.FechaIngreso;
            txtHoraIngreso.Text = registroAsistencia.HoraIngreso;
            cboFechaSalida.EditValue = registroAsistencia.FechaSalida;
            txtHoraSalida.Text = registroAsistencia.HoraSalida;
            cboUbicacion.EditValue = registroAsistencia.UbicacionId;
            cboEstado.EditValue = registroAsistencia.EstadoId;
            txtObservacion.Text = registroAsistencia.Observacion.ToUpper();

            txtColaborador.Enabled = false;
            cboFechaIngreso.Enabled = false;
            txtHoraIngreso.Enabled = false;
            cboFechaSalida.Enabled = false;
            txtHoraSalida.Enabled = false;
            cboUbicacion.Enabled = false;
            cboEstado.Enabled = false;
            txtObservacion.Enabled = false;

            if (registroAsistencia.Id == 0)
            {
                if (Perfil == PerfilAsistencia.JEFE || Perfil == PerfilAsistencia.ADMINISTRADOR)
                {
                    cboUbicacion.Enabled = true;
                    cboEstado.Enabled = true;
                    txtObservacion.Enabled = true;
                }
            }
            else
            {
                if (Perfil == PerfilAsistencia.JEFE || Perfil == PerfilAsistencia.ADMINISTRADOR)
                {
                    cboUbicacion.Enabled = true;
                    cboEstado.Enabled = true;
                    txtObservacion.Enabled = true;
                }
                else if (Perfil == PerfilAsistencia.SUPERVISOR)
                {
                    cboEstado.Enabled = true;
                    txtObservacion.Enabled = true;
                }
            }


        }

        private void Guardar()
        {
            RegistroAsistencia asistencia = new RegistroAsistencia();

            asistencia.Id = registroAsistencia.Id;
            asistencia.EmpleadoId = registroAsistencia.EmpleadoId;
            asistencia.FechaIngreso = cboFechaIngreso.EditValue.ToString();
            asistencia.HoraIngreso = txtHoraIngreso.Text;
            asistencia.FechaSalida = cboFechaSalida.EditValue.ToString();
            asistencia.HoraSalida = txtHoraSalida.Text;
            asistencia.EstadoId = (int)cboEstado.EditValue;
            asistencia.UbicacionId = (int)cboUbicacion.EditValue;
            asistencia.Observacion = txtObservacion.Text;

            if (registroAsistencia.Id == 0)
            {
                int registrar = Metodos.RegistrarAsistencia(asistencia);
                if (registrar == 1)
                {
                    Program.mensaje("Se guardaron los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Program.mensaje("Ocurrió un problema al intentar guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                }
            }
            else
            {
                int modificar = Metodos.ModificarAsistencia(asistencia);
                if (modificar == 1)
                {
                    Program.mensaje("Se guardaron los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    Program.mensaje("Ocurrió un problema al intentar guardar los cambios.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.No;
                }
            }
        }

        private void ListarUbicacion()
        {
            List<Area> AreaList = Metodos.ListarArea();
            cboUbicacion.Properties.ValueMember = "Id";
            cboUbicacion.Properties.DisplayMember = "Nombre";
            cboUbicacion.Properties.DataSource = AreaList;
        }

        private void ListarEstado()
        {
            List<EstadoAsistencia> EstadoAsistenciaList = Metodos.ListarEstadoAsistencia();
            cboEstado.Properties.ValueMember = "Id";
            cboEstado.Properties.DisplayMember = "Descripcion";
            cboEstado.Properties.DataSource = EstadoAsistenciaList;
        }
    }
}
