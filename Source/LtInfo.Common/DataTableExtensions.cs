/*-----------------------------------------------------------------------
<copyright file="DataTableExtensions.cs" company="Sitka Technology Group">
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
using System.Data;
using System.IO;
using System.Linq;

namespace LtInfo.Common
{
    /// <summary>
    /// Test functions for helping working with <see cref="DataTable"/> while running unit tests
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Converts the <see cref="DataTable"/> to an human readable string representation that is XML, for use in unit testing. Use this one if data has a lot of multiline stuff.
        /// </summary>
        public static string TableToHumanReadableXmlString(this DataTable dataTable)
        {
            if (dataTable == null)
            {
                return String.Empty;
            }
            var stringWriter = new StringWriter();
            dataTable.WriteXml(stringWriter);
            var resultAsString = stringWriter.ToString();
            return resultAsString;
        }

        /// <summary>
        /// Converts the <see cref="DataTable"/> to an human readable string representation, for use in unit testing
        /// </summary>
        public static string TableToHumanReadableString(this DataTable dataTable)
        {
            if (dataTable == null)
            {
                return String.Empty;
            }

            const string columnSeparator = "\t";
            var headerRow = String.Join(columnSeparator, dataTable.Columns.Cast<DataColumn>().Select(dc => dc.ColumnName).ToList());
            var dataRows = dataTable.Rows.Cast<DataRow>().Select(r => String.Join(columnSeparator, Enumerable.Range(0, dataTable.Columns.Count).Select(i => r[i].ToString()))).ToList();

            var allData = new List<string> { headerRow }.Union(dataRows).ToList();
            var tableToHumanReadableString = String.Join("\r\n", allData);
            return tableToHumanReadableString;
        }

        /// <summary>
        /// Converts the <see cref="DataTable"/> <see cref="DataColumn"/>definitions an xml string representation, for use in unit testing
        /// </summary>
        public static string TableShapeToHumanReadableString(this DataTable dataTable)
        {
            if (dataTable == null)
            {
                return String.Empty;
            }
            var columnDetails = dataTable.Columns.Cast<DataColumn>().Select(dc => String.Format("{0}\t{1}\t{2}\t{3}", dc.ColumnName, dc.DataType.Name, dc.AllowDBNull ? "null" : "not null", dc.MaxLength)).ToList();
            return String.Join("\r\n", columnDetails);
        }
    }
}
