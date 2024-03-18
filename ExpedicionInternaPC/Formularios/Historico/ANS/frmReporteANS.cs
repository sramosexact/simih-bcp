using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExpedicionInternaPC
{
    public partial class frmReporteANS : frmChild
    {
        #region Propiedades

        List<IndicadorANS> ListaIndicadorANS = new List<IndicadorANS>();
        List<IndicadorANS> ListaEfectividadEntregaDetalle = new List<IndicadorANS>();
        List<IndicadorANS> ListaProcesadosMesaPartesDetalle = new List<IndicadorANS>();
        List<IndicadorANS> ListaGestionOportunaDetalle = new List<IndicadorANS>();
        List<IndicadorANS> ListaReportesDeServiciosDetalle = new List<IndicadorANS>();

        #endregion

        #region MetodosExcel

        private void exportarExcel()
        {
            // Creamos un objeto Excel.            
            Excel.Application Mi_Excel = default(Excel.Application);
            // Creamos un objeto WorkBook. Para crear el documento Excel.           
            Excel.Workbook LibroExcel = default(Excel.Workbook);
            // Creamos un objeto WorkSheet. Para crear la hoja del documento.
            Excel.Worksheet myWorksheet = default(Excel.Worksheet);
            //Crear instancia a Excel
            Mi_Excel = new Excel.Application();
            // Creamos una instancia del Workbooks de excel.            
            LibroExcel = Mi_Excel.Workbooks.Add();
            Mi_Excel.Sheets.Add();
            // Creamos una instancia de la primera hoja de trabajo de excel            
            myWorksheet = LibroExcel.Worksheets[1];
            //Cambiar el nombre de la hoja
            myWorksheet.Name = "Facturación";

            generarReporteANS(myWorksheet);

            Mi_Excel.Application.ActiveWindow.DisplayGridlines = false;
            Mi_Excel.Visible = true;
        }

        private void generarReporteANS(Excel.Worksheet myWorksheet)
        {
            //Reporte de ANS

            /* 
             * ***************************************************************************************************************
             * Título General            
             * ***************************************************************************************************************
            */
            myWorksheet.Range["A1", "F3"].Merge();
            //myWorksheet.Cells[1, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkSlateBlue);
            myWorksheet.Cells[1, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(17, 97, 164));
            myWorksheet.Cells[1, "A"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            myWorksheet.Cells[1, "A"].Font.Size = 18;
            myWorksheet.Cells[1, "A"].Font.Bold = true;
            myWorksheet.Range["A1", "A1"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            myWorksheet.Range["A1", "A1"].Style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            myWorksheet.Cells[1, "A"] = "REPORTE ANS";


            /* 
             * ***************************************************************************************************************
             * Resumen - Título            
             * ***************************************************************************************************************
            */
            myWorksheet.Range["A5", "F5"].Merge();
            //myWorksheet.Cells[5, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
            myWorksheet.Cells[5, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(17, 97, 164));
            myWorksheet.Cells[5, "A"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            myWorksheet.Cells[5, "A"].Font.Size = 14;
            myWorksheet.Cells[5, "A"].Font.Bold = true;
            myWorksheet.Cells[5, "A"] = "Resumen";

            //Cabecera de tabla
            myWorksheet.Cells[7, "A"] = "Indicador";
            myWorksheet.Cells[7, "B"] = "Unidad de medida";
            myWorksheet.Cells[7, "C"] = "Peligro";
            myWorksheet.Cells[7, "D"] = "Meta";
            myWorksheet.Cells[7, "E"] = "Valor obtenido";
            myWorksheet.Cells[7, "F"] = "Resumen";

            //Datos de tabla
            Dictionary<string, string> listaCampoColumnaResumen = new Dictionary<string, string>();
            listaCampoColumnaResumen.Add("A", "sDescripcion");
            listaCampoColumnaResumen.Add("B", "sUnidadMedida");
            listaCampoColumnaResumen.Add("C", "sPeligro");
            listaCampoColumnaResumen.Add("D", "sMeta");
            listaCampoColumnaResumen.Add("E", "sUltimoPeriodo");
            listaCampoColumnaResumen.Add("F", "sPenultimoPeriodo");

            generarTablasExcel(ListaIndicadorANS, myWorksheet, 7, listaCampoColumnaResumen);

            /* 
             * ***************************************************************************************************************
             * Efectividad de entrega de documento - Título            
             * ***************************************************************************************************************
            */
            myWorksheet.Range["A14", "D14"].Merge();
            //myWorksheet.Cells[14, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
            myWorksheet.Cells[14, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(17, 97, 164));
            myWorksheet.Cells[14, "A"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            myWorksheet.Cells[14, "A"].Font.Size = 14;
            myWorksheet.Cells[14, "A"].Font.Bold = true;
            myWorksheet.Cells[14, "A"] = "Efectividad de entrega de documento";

            //Cabecera de tabla
            myWorksheet.Cells[16, "A"] = "Indicador";
            myWorksheet.Cells[16, "B"] = "Antepenúltimo periodo";
            myWorksheet.Cells[16, "C"] = "Penúltimo periodo";
            myWorksheet.Cells[16, "D"] = "Último periodo";

            //Datos de tabla
            Dictionary<string, string> listaCampoColumnaEfectividad = new Dictionary<string, string>();
            listaCampoColumnaEfectividad.Add("A", "sDescripcion");
            listaCampoColumnaEfectividad.Add("B", "sAntepenultimoPeriodo");
            listaCampoColumnaEfectividad.Add("C", "sPenultimoPeriodo");
            listaCampoColumnaEfectividad.Add("D", "sUltimoPeriodo");

            generarTablasExcel(ListaEfectividadEntregaDetalle, myWorksheet, 16, listaCampoColumnaEfectividad);

            /* 
             * ***************************************************************************************************************
             * Gestión oportuna en la entrega de documentos            
             * ***************************************************************************************************************
            */
            myWorksheet.Range["A21", "D21"].Merge();
            //myWorksheet.Cells[21, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
            myWorksheet.Cells[21, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(17, 97, 164));
            myWorksheet.Cells[21, "A"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            myWorksheet.Cells[21, "A"].Font.Size = 14;
            myWorksheet.Cells[21, "A"].Font.Bold = true;
            myWorksheet.Cells[21, "A"] = "Gestión oportuna en la entrega de documentos";

            //Cabecera de tabla
            myWorksheet.Cells[23, "A"] = "Indicador";
            myWorksheet.Cells[23, "B"] = "Antepenúltimo periodo";
            myWorksheet.Cells[23, "C"] = "Penúltimo periodo";
            myWorksheet.Cells[23, "D"] = "Último periodo";

            //Datos de tabla
            Dictionary<string, string> listaCampoColumnaGestion = new Dictionary<string, string>();
            listaCampoColumnaGestion.Add("A", "sDescripcion");
            listaCampoColumnaGestion.Add("B", "sAntepenultimoPeriodo");
            listaCampoColumnaGestion.Add("C", "sPenultimoPeriodo");
            listaCampoColumnaGestion.Add("D", "sUltimoPeriodo");

            generarTablasExcel(ListaGestionOportunaDetalle, myWorksheet, 23, listaCampoColumnaGestion);

            /* 
             * ***************************************************************************************************************
             * Reportes de Servicios             
             * ***************************************************************************************************************
            */
            myWorksheet.Range["A27", "D27"].Merge();
            //myWorksheet.Cells[27, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
            myWorksheet.Cells[27, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(17, 97, 164));
            myWorksheet.Cells[27, "A"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            myWorksheet.Cells[27, "A"].Font.Size = 14;
            myWorksheet.Cells[27, "A"].Font.Bold = true;
            myWorksheet.Cells[27, "A"] = "Reportes de Servicios";

            //Cabecera de tabla
            myWorksheet.Cells[29, "A"] = "Indicador";
            myWorksheet.Cells[29, "B"] = "Antepenúltimo periodo";
            myWorksheet.Cells[29, "C"] = "Penúltimo periodo";
            myWorksheet.Cells[29, "D"] = "Último periodo";

            //Datos de tabla
            Dictionary<string, string> listaCampoColumnaReportes = new Dictionary<string, string>();
            listaCampoColumnaReportes.Add("A", "sDescripcion");
            listaCampoColumnaReportes.Add("B", "sAntepenultimoPeriodo");
            listaCampoColumnaReportes.Add("C", "sPenultimoPeriodo");
            listaCampoColumnaReportes.Add("D", "sUltimoPeriodo");

            generarTablasExcel(ListaReportesDeServiciosDetalle, myWorksheet, 29, listaCampoColumnaReportes);

            /* 
             * ***************************************************************************************************************
             * Documentos procesados por Mesa de Partes             
             * ***************************************************************************************************************
            */
            myWorksheet.Range["A38", "D38"].Merge();
            //myWorksheet.Cells[38, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
            myWorksheet.Cells[38, "A"].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(17, 97, 164));
            myWorksheet.Cells[38, "A"].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
            myWorksheet.Cells[38, "A"].Font.Size = 14;
            myWorksheet.Cells[38, "A"].Font.Bold = true;
            myWorksheet.Cells[38, "A"] = "Documentos procesados por Mesa de Partes";

            //Cabecera de tabla
            myWorksheet.Cells[40, "A"] = "Indicador";
            myWorksheet.Cells[40, "B"] = "Antepenúltimo periodo";
            myWorksheet.Cells[40, "C"] = "Penúltimo periodo";
            myWorksheet.Cells[40, "D"] = "Último periodo";

            //Datos de tabla
            Dictionary<string, string> listaCampoColumnaProcesados = new Dictionary<string, string>();
            listaCampoColumnaProcesados.Add("A", "sDescripcion");
            listaCampoColumnaProcesados.Add("B", "sAntepenultimoPeriodo");
            listaCampoColumnaProcesados.Add("C", "sPenultimoPeriodo");
            listaCampoColumnaProcesados.Add("D", "sUltimoPeriodo");

            generarTablasExcel(ListaProcesadosMesaPartesDetalle, myWorksheet, 40, listaCampoColumnaProcesados);

            myWorksheet.Columns.AutoFit();
        }

        private void generarTablasExcel(List<IndicadorANS> listaReporte, dynamic myWorksheet, int filaInicioTabla, Dictionary<string, string> listaCampoColumna)
        {

            int ii = filaInicioTabla;
            int jj = filaInicioTabla + listaReporte.Count;

            string colIni = "";
            string colFin = "";

            foreach (IndicadorANS obj in listaReporte)
            {
                ii++;

                int k = 1;

                foreach (KeyValuePair<string, string> entry in listaCampoColumna)
                {
                    if (k == 1) colIni = entry.Key;
                    if (k == listaCampoColumna.Count) colFin = entry.Key;

                    myWorksheet.Cells[ii, entry.Key] = obj.GetPropertyValue(entry.Value);

                    k++;
                }

            }

            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Font.Size = 10;

            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDot;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlEdgeTop].LineStyle = Excel.XlLineStyle.xlDot;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlEdgeRight].LineStyle = Excel.XlLineStyle.xlDot;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Excel.XlLineStyle.xlDot;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Excel.XlLineStyle.xlDot;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlInsideVertical].LineStyle = Excel.XlLineStyle.xlDot;

            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlEdgeBottom].Color = System.Drawing.Color.Black;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlEdgeTop].Color = System.Drawing.Color.Black;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlEdgeRight].Color = System.Drawing.Color.Black;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlEdgeLeft].Color = System.Drawing.Color.Black;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlInsideHorizontal].Color = System.Drawing.Color.Black;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].Borders[Excel.XlBordersIndex.xlInsideVertical].Color = System.Drawing.Color.Black;

            myWorksheet.Range[colIni + filaInicioTabla, colFin + jj].HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

            //myWorksheet.Range[colIni + filaInicioTabla, colFin + filaInicioTabla].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.DarkSlateBlue);
            myWorksheet.Range[colIni + filaInicioTabla, colFin + filaInicioTabla].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(38, 159, 192));
            //myWorksheet.Range[colIni + filaInicioTabla, colFin + filaInicioTabla].Interior.Color = System.Drawing.Color.FromArgb(151, 149, 154); // System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.FromArgb(151, 149, 154));            
            myWorksheet.Range[colIni + filaInicioTabla, colFin + filaInicioTabla].Font.Size = 11;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + filaInicioTabla].Font.Bold = true;
            myWorksheet.Range[colIni + filaInicioTabla, colFin + filaInicioTabla].Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            myWorksheet.Range[colIni + filaInicioTabla, colFin + filaInicioTabla].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

        }

        #endregion

        #region Metodos

        public void ListarIndicadoresANS(int iIdPeriodo)
        {
            try
            {
                ListaIndicadorANS = Metodos.ListarIndicadores(iIdPeriodo);
                gcResumen.DataSource = ListaIndicadorANS;
                gcResumen.Refresh();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
        }

        public void ListarGestionOportunaDetalle(int iIdPeriodo)
        {
            try
            {
                ListaGestionOportunaDetalle = Metodos.ListarGestionOportunaDetalle(iIdPeriodo);
                gcGestionOportuna.DataSource = ListaGestionOportunaDetalle;
                gcGestionOportuna.Refresh();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
        }

        public void ListarEfectividadEntregaDetalle(int iIdPeriodo)
        {
            try
            {
                ListaEfectividadEntregaDetalle = Metodos.ListarGestionOportunaDetalle(iIdPeriodo);
                ListaEfectividadEntregaDetalle.Add(new IndicadorANS()
                {

                    sDescripcion = "Total de Autogenerados Creados",
                    sUltimoPeriodo = ListaEfectividadEntregaDetalle.Sum(x => Convert.ToInt32(x.sUltimoPeriodo)).ToString(),
                    sPenultimoPeriodo = ListaEfectividadEntregaDetalle.Sum(x => Convert.ToInt32(x.sPenultimoPeriodo)).ToString(),
                    sAntepenultimoPeriodo = ListaEfectividadEntregaDetalle.Sum(x => Convert.ToInt32(x.sAntepenultimoPeriodo)).ToString()
                });
                gcEfectividad.DataSource = ListaEfectividadEntregaDetalle;
                gcEfectividad.Refresh();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
        }

        public void ListarProcesadosMesaPartesDetalle(int iIdPeriodo)
        {
            try
            {
                ListaProcesadosMesaPartesDetalle = Metodos.ListarProcesadosMesaPartesDetalle(iIdPeriodo);
                gcProcesadosMesaPartes.DataSource = ListaProcesadosMesaPartesDetalle;
                gcProcesadosMesaPartes.Refresh();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
        }

        public void ListarReporteDeServiciosDetalle(int iIdPeriodo)
        {
            try
            {
                ListaReportesDeServiciosDetalle = Metodos.ListarReportesDeServiciosDetalle(iIdPeriodo);
                gcReportesDeServicios.DataSource = ListaReportesDeServiciosDetalle;
                gcReportesDeServicios.Refresh();
            }
            catch (InvalidTokenException)
            {
                Program.mensajeTokenInvalido();
            }
        }

        #endregion


        public frmReporteANS()
        {
            InitializeComponent();
        }

        private void frmReporteANS_Load(object sender, EventArgs e)
        {
            luePeriodo.ListarPeriodos();
            ListarIndicadoresANS((int)luePeriodo.EditValue);
            ListarEfectividadEntregaDetalle((int)luePeriodo.EditValue);
            ListarGestionOportunaDetalle((int)luePeriodo.EditValue);
            ListarProcesadosMesaPartesDetalle((int)luePeriodo.EditValue);
            ListarReporteDeServiciosDetalle((int)luePeriodo.EditValue);
        }

        private void luePeriodo_EditValueChanged(object sender, EventArgs e)
        {
            ListarIndicadoresANS((int)luePeriodo.EditValue);
            ListarEfectividadEntregaDetalle((int)luePeriodo.EditValue);
            ListarGestionOportunaDetalle((int)luePeriodo.EditValue);
            ListarProcesadosMesaPartesDetalle((int)luePeriodo.EditValue);
            ListarReporteDeServiciosDetalle((int)luePeriodo.EditValue);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }
    }
}
