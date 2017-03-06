/*-----------------------------------------------------------------------
<copyright file="DatabaseDirectAccessTestFixtureBase.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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

namespace LtInfo.Common.GdalOgr
{
    /// <summary>
    /// Maintains a direct and consistent database connection across tests so that temp tables can be used in the tests
    /// </summary>
    public class DatabaseDirectAccessTestFixtureBase : IDisposable
    {
        /// <summary>
        /// Connection to open and maintain for lifetime of the test
        /// </summary>
        protected SqlConnection SQLConnection;

        protected void BaseFixtureSetup()
        {
            var db = new TempDbSqlDatabase();
            SQLConnection = db.CreateConnection();
            SQLConnection.Open();
        }

        protected void BaseFixtureTeardown()
        {
            Dispose();
        }

        protected DataTable ExecAdHocSql(string sqlStatements)
        {
            return ExecuteSql(sqlStatements, SQLConnection);
        }

        private const int CommandTimeoutInSeconds = 60;

        private static DataTable ExecuteSql(string sqlStatements, SqlConnection connection)
        {
            using (var comm = new SqlCommand(sqlStatements, connection))
            {
                comm.CommandType = CommandType.Text;
                comm.CommandTimeout = CommandTimeoutInSeconds;
                var sqlResult = TempDbSqlDatabase.ExecuteSqlCommand(comm);
                if (sqlResult.Tables.Count > 0)
                {
                    return sqlResult.Tables[0];
                }
                return null;
            }
        }

        public void Dispose()
        {
            DisposeOfSqlConnection(ref SQLConnection);
        }

        private static void DisposeOfSqlConnection(ref SqlConnection sqlConnection)
        {
            if (sqlConnection == null)
            {
                return;
            }
            sqlConnection.Close();
            sqlConnection.Dispose();
            sqlConnection = null;
        }
    }
}
