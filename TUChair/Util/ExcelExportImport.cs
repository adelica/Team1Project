﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TUChair.Util
{
    class ExcelExportImport
    {
        public static string ExportToDataGridView<T>(List<T> dataList, string exceptColumns)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Application.Workbooks.Add(true);

                int columnIndex = 0;

                foreach (PropertyInfo prop in typeof(T).GetProperties())
                {
                    if (!exceptColumns.Contains(prop.Name))
                    {
                        columnIndex++;
                        excel.Cells[1, columnIndex] = prop.Name;
                    }
                }

                int rowIndex = 0;

                foreach (T data in dataList)
                {
                    rowIndex++;
                    columnIndex = 0;
                    foreach (PropertyInfo prop in typeof(T).GetProperties())
                    {
                        if (!exceptColumns.Contains(prop.Name))
                        {
                            columnIndex++;
                            if (prop.GetValue(data, null) != null)
                            {
                                excel.Cells[rowIndex + 1, columnIndex] = prop.GetValue(data, null).ToString();
                            }
                        }
                    }
                }

                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)excel.ActiveSheet;
                worksheet.Activate();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}