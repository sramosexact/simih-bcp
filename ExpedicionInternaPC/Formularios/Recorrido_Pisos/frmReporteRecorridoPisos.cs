using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public partial class frmReporteRecorridoPisos : frmChild
    {
        List<Sede> ListaSedes;
        List<ColaboradorPisos> ListaColaboradorPisos;

        public frmReporteRecorridoPisos()
        {
            InitializeComponent();
        }

        private void frmReporteRecorridoPisos_Load(object sender, EventArgs e)
        {
            cboFechaInicio.EditValue = DateTime.Now;
            cboFechaFinal.EditValue = DateTime.Now;

            ListaSedes = new List<Sede>();
            Sede sede = new Sede();
            sede.Id = 0;
            sede.Nombre = "TODOS";
            ListaSedes.Add(sede);


            cboSede.Properties.DisplayMember = "Nombre";
            cboSede.Properties.ValueMember = "Id";
            cboSede.EditValue = (object)0;

            var lista = Metodos.ListarSede();
            ListaSedes.AddRange(lista);
            cboSede.Properties.DataSource = ListaSedes;
        }

        private void cboSede_EditValueChanged(object sender, EventArgs e)
        {
            ListarColaboradorPisos((int)(cboSede.EditValue));
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<ReporteRecorridoPisos> reporte = new List<ReporteRecorridoPisos>();
            reporte = Metodos.ReporteRecorridoPisos((int)cboSede.EditValue, (int)cboColaboradorPisos.EditValue, (DateTime)cboFechaInicio.EditValue, (DateTime)cboFechaFinal.EditValue);
            grdReporte.DataSource = reporte;
            grdReporte.RefreshDataSource();
            grvReporte.RefreshData();
        }

        private void InicializaListaEmpleados()
        {
            ListaColaboradorPisos = new List<ColaboradorPisos>();
            ColaboradorPisos colaboradorPisos = new ColaboradorPisos();
            colaboradorPisos.Id = 0;
            colaboradorPisos.Nombres = "TODOS";
            ListaColaboradorPisos.Add(colaboradorPisos);

            cboColaboradorPisos.Properties.ValueMember = "Id";
            cboColaboradorPisos.Properties.DisplayMember = "Nombres";
            cboColaboradorPisos.EditValue = (object)0;
            cboColaboradorPisos.Properties.DataSource = ListaColaboradorPisos;
        }

        private void ListarColaboradorPisos(int area_id)
        {
            InicializaListaEmpleados();
            var lista = Metodos.ListarColaboradorPisos(area_id);
            ListaColaboradorPisos.AddRange(lista);
            cboColaboradorPisos.Properties.DataSource = ListaColaboradorPisos;
        }
    }
}
