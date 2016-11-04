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