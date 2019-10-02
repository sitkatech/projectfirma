using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProjectFirma.Web.Common
{
    public class SqlHelpers
    {
        /// <summary>
        ///     This maps the C# possibilities of null, empty, non-empty to the Sql server side, where a table valued parameter can *never* be null.
        ///     C# side:        Sql Server Side:
        ///     --------        ----------------
        ///     null       =>   empty
        ///     empty      =>   { null }               (list with a single "null" row in it)
        ///     non-empty  =>   non-empty
        ///     That way the Sql Server side code can still detect the three cases. We are using C# null to mean ignore the list.
        ///     The empty list => list with one null row should never get a hit so it should be the same as empty list in
        /// </summary>
        /// <param name="integerList"></param>
        /// <returns></returns>
        public static DataTable IntListToDataTable(List<int> integerList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("ID", typeof(Int32)));
            if (integerList != null)
            {
                // Eventually the table ends up in SQL as:
                // declare @p1 dbo.IDList
                // insert into @p1 values(2)
                // insert into @p1 values(3)
                // insert into @p1 values(4)
                // insert into @p1 values(5)
                // insert into @p1 values(6)
                // insert into @p1 values(7)
                // insert into @p1 values(10)
                // insert into @p1 values(11)
                integerList.ForEach(id => dataTable.Rows.Add(id));
            }
            return dataTable;
        }

        /// <summary>
        ///     This maps the C# possibilities of null, empty, non-empty to the Sql server side, where a table valued parameter can *never* be null.
        ///     C# side:        Sql Server Side:
        ///     --------        ----------------
        ///     null       =>   empty
        ///     empty      =>   { null }               (list with a single "null" row in it)
        ///     non-empty  =>   non-empty
        ///     That way the Sql Server side code can still detect the three cases. We are using C# null to mean ignore the list.
        ///     The empty list => list with one null row should never get a hit so it should be the same as empty list in
        /// </summary>
        /// <param name="stringList"></param>
        /// <returns></returns>
        public static DataTable StringListToDataTable(List<string> stringList)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("StringValue", typeof(String)));
            if (stringList != null)
            {
                // Eventually the table ends up in SQL as:
                // declare @p1 dbo.StringList
                // insert into @p1 values('2')
                // insert into @p1 values('3')
                // insert into @p1 values('4')
                // insert into @p1 values('5')
                // insert into @p1 values('6')
                // insert into @p1 values('7')
                // insert into @p1 values('10')
                // insert into @p1 values('11')
                stringList.ForEach(stringValue => dataTable.Rows.Add(stringValue));
            }
            return dataTable;
        }

        public static string DataTableToTabDelimitedString(DataTable dataTable)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(String.Join("\t", dataTable.Columns.Cast<DataColumn>().Select(arg => arg.ColumnName)));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                stringBuilder.AppendLine(String.Join("\t", dataRow.ItemArray.Select(arg => arg.ToString())));
            }
            return stringBuilder.ToString();
        }

        public static string DataTableToFixedWidthString(DataTable dt)
        {
            var dataColumns = dt.Columns.Cast<DataColumn>().ToList();
            var dataRows = dt.Rows.Cast<DataRow>().ToList();
            return DataTableToFixedWidthString(dataColumns, dataRows);
        }

        public static string DataTableToFixedWidthString(IList<DataRow> dataRows)
        {
            if (!dataRows.Any())
            {
                return String.Empty;
            }
            var dataColumns = dataRows.First().Table.Columns.Cast<DataColumn>().ToList();
            return DataTableToFixedWidthString(dataColumns, dataRows);
        }

        private static string DataTableToFixedWidthString(IList<DataColumn> dataColumns, IList<DataRow> dataRows)
        {
            const string howNullLooks = "NULL";
            var maxLengths = new int[dataColumns.Count];
            for (var i = 0; i < dataColumns.Count; i++)
            {
                maxLengths[i] = dataColumns[i].ColumnName.Length;

                foreach (var row in dataRows)
                {
                    var dataValue = row.IsNull(i) ? howNullLooks : row[i].ToString();
                    var length = dataValue.Length;
                    if (length > maxLengths[i])
                    {
                        maxLengths[i] = length;
                    }
                }
            }
            var sw = new StringBuilder();
            for (var i = 0; i < dataColumns.Count; i++)
            {
                sw.Append(dataColumns[i].ColumnName.PadRight(maxLengths[i] + 2));
            }

            sw.AppendLine();
            foreach (var row in dataRows)
            {
                for (var i = 0; i < dataColumns.Count; i++)
                {
                    var dataValue = row.IsNull(i) ? howNullLooks : row[i].ToString();
                    sw.Append(dataValue.PadRight(maxLengths[i] + 2));
                }
                sw.AppendLine();
            }
            return sw.ToString();
        }

        /// <summary>
        /// This is a helper I kept pasting in while debugging so I thought I'd just check it in.  The idea is you have a hand built SqlCommand with a bunch of
        /// variables that get bound, this function replaces the variables with the actual values so you can print it or set a breakpoint and run the query independently.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static string SqlCommandToExecutableScript(SqlCommand cmd)
        {
            var qryText = cmd.CommandText;
            foreach (SqlParameter p in cmd.Parameters)
            {
                qryText = qryText.Replace(p.ParameterName, _SqlRepresentation(p));
            }
            return qryText;
        }

        private static string _SqlRepresentation(SqlParameter p)
        {
            if (p.Value == null)
            {
                return "null";
            }
            if (p.SqlDbType == SqlDbType.Bit)
            {
                return ((bool)p.Value) ? "1" : "0";
            }
            // probably a bunch of others types need to be quoted too
            var sqlTypesToQuote = new[] { SqlDbType.VarChar, SqlDbType.NVarChar, SqlDbType.DateTime };
            if (sqlTypesToQuote.Contains(p.SqlDbType))
            {
                return String.Format("'{0}'", p.Value);
            }
            return p.Value.ToString();
        }

        public static SqlConnection CreateAndOpenSqlConnection()
        {
            var db = new ProjectFirmaModels.UnitTestCommon.ProjectFirmaSqlDatabase();
            var sqlConnection = db.CreateConnection();
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}