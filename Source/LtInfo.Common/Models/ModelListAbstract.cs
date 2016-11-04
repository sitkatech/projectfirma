using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.MvcResults;
using LtInfo.Common.Views;

namespace LtInfo.Common.Models
{
    public static class ModelListAbstract
    {
        public const int UnlimitedRowLimit = -1;

        public static string ToXmlRowCell<T>(this List<T> list, GridSpec<T> spec)
        {
            return ToXmlRowCell(list, spec, UnlimitedRowLimit);
        }

        public static string ToXmlRowCell<T>(this List<T> list, GridSpec<T> spec, int rowLimit)
        {
            var rowID = 0;

            //we want to ensure that T implements are needed interface...

            using (var stream = new MemoryStream())
            {
                using (var writer = new XmlTextWriter(stream, null))
                {
                    writer.WriteStartElement("rows");

                    if (rowLimit != UnlimitedRowLimit && list.Count > rowLimit)
                    {
                        list.RemoveRange(rowLimit, list.Count - rowLimit);
                    }

                    list.ForEach(m => m.ToXmlRowCell(writer, ++rowID, spec));

                    writer.WriteFullEndElement();
                    writer.Flush();
                    var array = stream.ToArray();
                    var s = Encoding.UTF8.GetString(array);
                    return s;
                }
            }
        }

        public static DhtmlxGridJsonRow ToDhtmlxGridJsonRow<T>(this T thingToRead, int rowID, GridSpec<T> gridSpec)
        {
            var columnValues = gridSpec.Select(columnSpec => thingToRead.ToDhtmlxGridJsonCellData(columnSpec)).ToList();
            return new DhtmlxGridJsonRow(rowID, columnValues);
        }

        public static string ToDhtmlxGridJsonCellData<T>(this T dataObject, ColumnSpec<T> columnSpec)
        {
            var cellAttributes = new Dictionary<string, string>();
            cellAttributes.Add("value", columnSpec.CalculateStringValue(dataObject));

            var title = columnSpec.CalculateTitle(dataObject);
            if (!String.IsNullOrWhiteSpace(title))
            {
                cellAttributes.Add("title", title);
            }

            var cssClass = columnSpec.CalculateCellCssClass(dataObject);
            if (!String.IsNullOrWhiteSpace(cssClass))
            {
                cellAttributes.Add("class", cssClass);
            }

            // if we only have a value, no need for the brackets
            if (cellAttributes.Count == 1)
            {
                return cellAttributes.First().Value;
            }
            return string.Format("{{{0}}}", string.Join(",", cellAttributes.Select(x => string.Format("\"{0}\":\"{1}\"", x.Key, x.Value))));
        }
    }
}