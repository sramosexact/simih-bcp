using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public partial class frmReporteAsistencia : frmChild
    {

        List<Area> ListaAreas;
        List<Empleado> ListaEmpleados;

        public frmReporteAsistencia()
        {
            InitializeComponent();
        }

        private void frmReporteAsistencia_Load(object sender, EventArgs e)
        {
            cboFechaInicio.EditValue = DateTime.Now;
            cboFechaFinal.EditValue = DateTime.Now;

            ListaAreas = new List<Area>();
            Area area = new Area();
            area.Id = 0;
            area.Nombre = "TODOS";
            ListaAreas.Add(area);


            cboArea.Properties.DisplayMember = "Nombre";
            cboArea.Properties.ValueMember = "Id";
            cboArea.EditValue = (object)0;

            var lista = Metodos.ListarArea();
            ListaAreas.AddRange(lista);
            cboArea.Properties.DataSource = ListaAreas;

            InicializaListaEmpleados();

        }

        private void InicializaListaEmpleados()
        {
            ListaEmpleados = new List<Empleado>();
            Empleado empleado = new Empleado();
            empleado.Id = 0;
            empleado.Nombres = "TODOS";
            ListaEmpleados.Add(empleado);

            cboEmpleado.Properties.ValueMember = "Id";
            cboEmpleado.Properties.DisplayMember = "Nombres";
            cboEmpleado.EditValue = (object)0;
            cboEmpleado.Properties.DataSource = ListaEmpleados;
        }

        private void ListarEmpleado(int area_id)
        {
            InicializaListaEmpleados();
            var lista = Metodos.ListarEmpleado(area_id);
            ListaEmpleados.AddRange(lista);
            cboEmpleado.Properties.DataSource = ListaEmpleados;
        }

        private void cboArea_EditValueChanged(object sender, EventArgs e)
        {
            ListarEmpleado((int)(cboArea.EditValue));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ReporteAsistencia> reporte = new List<ReporteAsistencia>();
            reporte = Metodos.ReporteAsistencia((int)cboArea.EditValue, (int)cboEmpleado.EditValue, (DateTime)cboFechaInicio.EditValue, (DateTime)cboFechaFinal.EditValue);
            grdReporte.DataSource = reporte;
            grdReporte.RefreshDataSource();
            grvReporte.RefreshData();
        }
    }
}
