/*-----------------------------------------------------------------------
<copyright file="TempDbSqlDatabase.cs" company="Sitka Technology Group">
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
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LtInfo.Common.GdalOgr
{
    public class TempDbSqlDatabase
    {
        public const string SqlParameterNameForReturnValue = "@RETURN_VALUE";
        public const string DatabaseConnectionStringToTempDb = "server=localhost;database=tempdb;Trusted_Connection=yes";

        private readonly string _sqlDatabaseConnectionString;

        public TempDbSqlDatabase()
        {
            _sqlDatabaseConnectionString = DatabaseConnectionStringToTempDb;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_sqlDatabaseConnectionString);
        }

        public DataSet ExecuteSqlCommandAndOpenNewConnection(SqlCommand comm)
        {
            var sqlConnection = CreateConnection();
            using (var conn = sqlConnection)
            {
                comm.Connection = conn;
                return ExecuteSqlCommand(comm);
            }
        }

        public static DataSet ExecuteSqlCommand(SqlCommand comm)
        {
            using (var adapter = new SqlDataAdapter(comm))
            {
                // Map C# null to DBNull on the way to Sql Server so that values come out as expected there
                var nullableParameters = comm.Parameters.Cast<SqlParameter>().Where(p => p.Value == null).ToList();
                nullableParameters.ForEach(p => p.Value = DBNull.Value);

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                return dataSet;
            }
        }
    }
}
