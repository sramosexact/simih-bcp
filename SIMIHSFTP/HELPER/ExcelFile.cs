using Interna.Entity;
using System;
using System.Collections.Generic;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace SIMIHSFTP.HELPER
{
    public static class ExcelFile
    {
        public static List<UsuarioIngesta> getExcelFile(string FullPath)
        {

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FullPath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            object[,] wArray = xlRange.get_Value(Excel.XlRangeValueDataType.xlRangeValueDefault);

            List<UsuarioIngesta> usuarioIngestaList = new List<UsuarioIngesta>();

            try
            {
                for (int row = 2; row < (wArray.GetLength(0) + 1); row++)
                {
                    if (Convert.ToString(wArray[row, 1]) == String.Empty &&
                        Convert.ToString(wArray[row, 2]) == String.Empty &&
                        Convert.ToString(wArray[row, 3]) == String.Empty &&
                        Convert.ToString(wArray[row, 4]) == String.Empty &&
                        Convert.ToString(wArray[row, 5]) == String.Empty &&
                        Convert.ToString(wArray[row, 6]) == String.Empty &&
                        Convert.ToString(wArray[row, 7]) == String.Empty &&
                        Convert.ToString(wArray[row, 8]) == String.Empty)
                    {
                        usuarioIngestaList = null;
                        break;
                    }

                    UsuarioIngesta usuarioIngesta = new UsuarioIngesta();
                    usuarioIngesta.ApellidoPaterno = Convert.ToString(wArray[row, 1]);
                    usuarioIngesta.Nombres = Convert.ToString(wArray[row, 2]);
                    usuarioIngesta.Area = Convert.ToString(wArray[row, 3]);
                    usuarioIngesta.Servicio = Convert.ToString(wArray[row, 4]);
                    usuarioIngesta.UnidadOrganizativa = Convert.ToString(wArray[row, 5]);
                    usuarioIngesta.CodigoAgencia = Convert.ToString(wArray[row, 6]);
                    usuarioIngesta.Sede = Convert.ToString(wArray[row, 7]);
                    usuarioIngesta.Correo = Convert.ToString(wArray[row, 8]);
                    usuarioIngestaList.Add(usuarioIngesta);

                }
            }
            catch (Exception ex)
            {
                usuarioIngestaList = null;
            }
            finally
            {
                //cleanup
                //GC.Collect();
                //GC.WaitForPendingFinalizers();

                ////rule of thumb for releasing com objects:
                ////  never use two dots, all COM objects must be referenced and released individually
                ////  ex: [somthing].[something].[something] is bad

                ////release com objects to fully kill excel process from running in the background
                //Marshal.ReleaseComObject(xlRange);
                //Marshal.ReleaseComObject(xlWorksheet);

                ////close and release
                //xlWorkbook.Close();
                //Marshal.ReleaseComObject(xlWorkbook);

                ////quit and release
                //xlApp.Quit();
                //Marshal.ReleaseComObject(xlApp);

                if (xlRange != null)
                {
                    xlRange = null;
                }

                if (xlWorkbook != null)
                {
                    xlWorkbook.Close(false, FullPath, Missing.Value);
                    xlWorkbook = null;
                }

                if (xlApp != null)
                {
                    xlApp.DisplayAlerts = true;
                    xlApp.Quit();
                    xlApp = null;
                }
            }

            return usuarioIngestaList;

        }
    }
}

