using Interna.Entity;
using System;
using System.Collections.Generic;

namespace ExpedicionInternaPC
{
    public partial class frmReporteEntregaIntersucursales : frmChild
    {
        public override void ExportExcel(string FileName)
        {
            grvReporte.ExportToXlsx(FileName);
        }
        private void consultar(DateTime desde, DateTime hasta)
        {
            List<ReporteEntregaIntersucursales> reporteEntregaIntersucursales = Metodos.ReporteEntregaIntersucursales(desde, hasta);
            grdReporte.DataSource = reporteEntregaIntersucursales;
        }

        public frmReporteEntregaIntersucursales()
        {
            InitializeComponent();
        }

        private void frmReporteEntregaIntersucursales_Load(object sender, EventArgs e)
        {
            dtpDesde.EditValue = DateTime.Now;
            dtpHasta.EditValue = DateTime.Now;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if ((DateTime)dtpDesde.EditValue > (DateTime)dtpHasta.EditValue)
            {
                Program.mensajeError("La fecha 'Desde' no puede ser mayor a la fecha 'Hasta'");
                return;
            }
            consultar((DateTime)dtpDesde.EditValue, (DateTime)dtpHasta.EditValue);
        }
    }
}
