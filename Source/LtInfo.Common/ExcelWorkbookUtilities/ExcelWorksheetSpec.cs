/*-----------------------------------------------------------------------
<copyright file="ExcelWorksheetSpec.cs" company="Sitka Technology Group">
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

namespace LtInfo.Common.ExcelWorkbookUtilities
{
    public class ExcelWorksheetSpec<T>
    {
        private readonly List<ExcelColumnSpec<T>> _columns = new List<ExcelColumnSpec<T>>();

        public void AddColumn(string columnname, Func<T, string> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, int> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, int?> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, DateTime> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, DateTime?> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, decimal> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, decimal?> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, double> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, double?> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, short?> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, short> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, bool?> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public void AddColumn(string columnname, Func<T, bool> valueFunc)
        {
            _columns.Add(new ExcelColumnSpec<T>(columnname, valueFunc));
        }

        public List<ExcelColumnSpec<T>> Columnns
        {
            get { return _columns; }
        }
    }
}
