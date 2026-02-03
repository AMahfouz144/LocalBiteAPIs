//using ClosedXML.Excel;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Data;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Text.Json.Serialization;

//namespace Common
//{
//    public static class ExportDataExtensions
//    {
//        public static MemoryStream ExportExcelData<T>(this List<T> rows, string sheetname)
//        {
//            var dataTable = GetTable(rows);
//            return dataTable.ExportExcelData(sheetname);
//        }

//        public static MemoryStream ExportExcelData(this DataTable table, string sheetname)
//        {
//            if (sheetname == null)
//                sheetname = "report";

//            using var workbook = new XLWorkbook();
//            workbook.Style.Font.SetFontName("Times New Roman");
//            var ws = workbook.AddWorksheet(sheetname).FirstCell();
//            var worksheet = workbook.Worksheets.First();
//            ws.InsertTable(table.AsEnumerable());
//            worksheet.Rows().AdjustToContents();
//            worksheet.Rows().Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
//            MemoryStream memoryStream = new MemoryStream();
//            workbook.SaveAs(memoryStream);
//            memoryStream.Flush();
//            memoryStream.Seek(0, SeekOrigin.Begin);
//            return memoryStream;
//        }

//        public static MemoryStream ExportExcel<T>(this List<T> rows, string templatePath)
//        {
//            using var workbook = new XLWorkbook(templatePath);
//            workbook.Style.Font.SetFontName("Times New Roman");
//            var worksheet = workbook.Worksheets.First();
//            var info = typeof(T).GetProperties();
//            var currentRow = 1;
//            foreach (var obj in rows)
//            {
//                currentRow++;
//                int j = 0;
//                foreach (var prop in info)
//                {
//                    if (!prop.IsDefined(typeof(JsonIgnoreAttribute), false))
//                    {
//                        object val = prop.GetValue(obj);
//                        if (val != null && val.ToString() == "-")
//                        {
//                            val = "";
//                        }
//                        if (prop.Name == "DateString")
//                        {
//                            worksheet.Cell(currentRow, j + 1).Style.DateFormat.Format = "dd/MM/yyyy";
//                        }
//                        if (prop.Name == "TimeString")
//                        {
//                            worksheet.Cell(currentRow, j + 1).DataType = XLDataType.TimeSpan;
//                        }
//                        worksheet.Cell(currentRow, j + 1).Value = val;
//                        j++;
//                    }
//                }
//            }
//            worksheet.Rows().AdjustToContents();
//            worksheet.Rows().Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
//            MemoryStream memoryStream = new MemoryStream();
//            workbook.SaveAs(memoryStream);
//            memoryStream.Flush();
//            memoryStream.Seek(0, SeekOrigin.Begin);
//            return memoryStream;
//        }

//        public static MemoryStream ExportCsv<T>(this IEnumerable<T> data)
//        {
//            var sb = new StringBuilder();
//            var header = "";
//            var info = typeof(T).GetProperties();
//            foreach (var prop in info)
//            {
//                if (!prop.IsDefined(typeof(JsonIgnoreAttribute), false))
//                {
//                    string displayName = GetDisplayName(prop);
//                    header += $"{displayName},";
//                }
//            }
//            sb.AppendLine(header);
//            MemoryStream sw = new MemoryStream();
//            //\xEF\xBB\xBF
//            sw.WriteByte(0xef);
//            sw.WriteByte(0xbb);
//            sw.WriteByte(0xbf);
//            sw.Write(Encoding.UTF8.GetBytes(sb.ToString()));
//            foreach (var obj in data)
//            {
//                sb = new StringBuilder();
//                var line = "";
//                foreach (var prop in info)
//                {
//                    if (!prop.IsDefined(typeof(JsonIgnoreAttribute), false))
//                    {
//                        line += $"=\"{prop.GetValue(obj)}\",";
//                    }
//                }
//                sb.AppendLine(line);
//                sw.Write(Encoding.UTF8.GetBytes(sb.ToString()));
//            }
//            return sw;
//        }

//        private static readonly Type[] ValidTypes = new[]
//                         {
//                              typeof (Enum),
//                              typeof (String),
//                              typeof (Char),
//                              typeof (Guid),
//                              typeof (Boolean),
//                              typeof (Byte),
//                              typeof (Int16),
//                              typeof (Int32),
//                              typeof (Int64),
//                              typeof (Single),
//                              typeof (Double),
//                              typeof (Decimal),
//                              typeof (SByte),
//                              typeof (UInt16),
//                              typeof (UInt32),
//                              typeof (UInt64),
//                              typeof (DateTime),
//                              typeof (DateTimeOffset),
//                              typeof (TimeSpan),
//                          };
//        private static string GetDisplayName(PropertyInfo prop)
//        {
//            string displayName = prop.Name;

//            DisplayAttribute displayAttribute = (DisplayAttribute)(prop.GetCustomAttributes(typeof(DisplayAttribute), false)?.FirstOrDefault());
//            if (displayAttribute != null)
//            {
//                displayName = displayAttribute.Name;
//            }
//            return displayName;
//        }
//        private static bool IsValidType(Type type)
//        {
//            return (ValidTypes).Contains(type);
//        }
//        private static DataTable GetTable<T>(List<T> rows)
//        {
//            var table = new DataTable();
//            var properties = typeof(T).GetProperties();
//            foreach (var item in properties)
//            {
//                if (
//                    item.PropertyType.IsGenericType &&
//                    item.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
//                {
//                    var underLineType = Nullable.GetUnderlyingType(item.PropertyType);
//                    if (IsValidType(underLineType))
//                    {
//                        var datacolum = table.Columns.Add(item.Name, underLineType);
//                        datacolum.AllowDBNull = true;
//                    }
//                }
//                else
//                {
//                    if (IsValidType(item.PropertyType))
//                        table.Columns.Add(item.Name, item.PropertyType);
//                }

//            }

//            foreach (var obj in rows)
//            {
//                List<object> values = new List<object>();


//                foreach (DataColumn column in table.Columns)
//                {
//                    var prop = properties.FirstOrDefault(a => a.Name == column.ColumnName);
//                    object val = prop.GetValue(obj);

//                    if (val is DateTime dt && dt == DateTime.MinValue)
//                    {
//                        val = null;
//                    }
//                    values.Add(val);
//                }

//                table.Rows.Add(values.ToArray());
//            }
//            return table;
//        }
//    }
//}
