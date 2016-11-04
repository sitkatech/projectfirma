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