using System;
using System.Web;
using LtInfo.Common.HealthMonitor;
using Microsoft.SqlServer.Types;

namespace ProjectFirma.Web.HealthMonitor
{
    internal static class SqlServerSpatialDllSeemsToWork
    {
        public static HealthCheckResult Run()
        {
            var result = new HealthCheckResult("SqlServerSpatialDllSeemsToWork");
            var currentHttpContext = HttpContext.Current;
            if (currentHttpContext == null)
            {
                result.HealthCheckStatus = HealthCheckStatus.Critical;
                result.AddResultMessage("Could not run check because missing HTTP context");
                return result;
            }

            string resultMessage;
            result.HealthCheckStatus = CanSuccessfullyAccessSqlServerSpatialDll(out resultMessage) ? HealthCheckStatus.OK : HealthCheckStatus.Critical;
            result.AddResultMessage(resultMessage);
            return result;
        }

        public static bool CanSuccessfullyAccessSqlServerSpatialDll(out string resultMessage)
        {
            resultMessage = "Successfully called Sql Server Spatial DLL";

            SqlGeometry geom1 = new SqlGeometry();
            SqlGeometry geom2 = new SqlGeometry();

            try
            {
                //DatabaseModels.Geometry.SqlGeometryUtilities.AreSqlGeometriesEqual(geom1, geom2);

            }
            catch (Exception e)
            {
                resultMessage = e.Message;
                return false;
            }
            return true;
        }

    }
}