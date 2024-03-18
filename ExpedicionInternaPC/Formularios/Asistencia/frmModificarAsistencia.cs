using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ExpedicionInternaPC
{
    public partial class frmModificarAsistencia : frmChild
    {
        public PerfilAsistencia Perfil;

        public frmModificarAsistencia()
        {
            InitializeComponent();
        }

        public frmModificarAsistencia(int perfil)
        {
            InitializeComponent();
            Perfil = Program.ObtenerPerfilAsistencia(perfil);
        }

        private void repositoryItemHyperLinkEdit1_Click(object sender, EventArgs e)
        {
            RegistroAsistencia registroAsistencia = (RegistroAsistencia)grvRegistrados.GetFocusedRow();

            if (registroAsistencia == null) return;

            if (registroAsistencia.Accion == "Registrar" && (Perfil == PerfilAsistencia.SUPERVISOR || Perfil == PerfilAsistencia.COLABORADOR))
            {
                Program.mensaje("El perfil asociado no tiene permisos para realizar la acción seleccionada.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (registroAsistencia.Accion == "Registrar")
            {
                registroAsistencia.FechaIngreso = cboFecha.EditValue.ToString();
                registroAsistencia.FechaSalida = cboFecha.EditValue.ToString();
                registroAsistencia.UbicacionId = (int)cboArea.EditValue;
            }


            frmEditarAsistencia frm = new frmEditarAsistencia();
            frm.Perfil = Perfil;
            frm.registroAsistencia = registroAsistencia;

            if (frm.ShowDialog(this.Parent) == DialogResult.OK)
            {
                Buscar();
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void frmModificarAsistencia_Load(object sender, EventArgs e)
        {
            cboFecha.EditValue = DateTime.Now;
            if (Perfil == PerfilAsistencia.SUPERVISOR || Perfil == PerfilAsistencia.COLABORADOR) cboFecha.Enabled = false;
            ListarAreas();
        }

        private void ListarAreas()
        {
            List<Area> areaList = Metodos.ListarAreaAsignada(Program.oUsuario.ID);

            cboArea.Properties.ValueMember = "Id";
            cboArea.Properties.DisplayMember = "Nombre";
            cboArea.Properties.DataSource = areaList;
            cboArea.EditValue = null;
        }

        private void Buscar()
        {
            if (cboArea.EditValue == null) return;

            int area_id = (int)cboArea.EditValue;


            List<RegistroAsistencia> registroAsistencia = Metodos.ListarRegistroAsistenciaDiarioPorArea(area_id, (DateTime)cboFecha.EditValue);

            grdRegistrados.DataSource = registroAsistencia;

        }

        private void cboArea_EditValueChanged(object sender, EventArgs e)
        {
            List<RegistroAsistencia> registroAsistencia = new List<RegistroAsistencia>();
            grdRegistrados.DataSource = registroAsistencia;
        }

        private void cboFecha_EditValueChanged(object sender, EventArgs e)
        {
            List<RegistroAsistencia> registroAsistencia = new List<RegistroAsistencia>();
            grdRegistrados.DataSource = registroAsistencia;
        }
    }
}
