/*-----------------------------------------------------------------------
<copyright file="ModelListAbstract.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
<date>Wednesday, February 22, 2017</date>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
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
