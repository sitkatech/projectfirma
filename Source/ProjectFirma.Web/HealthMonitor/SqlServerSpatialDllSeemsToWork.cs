using System;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.HealthMonitor;
using Microsoft.SqlServer.Types;
using ProjectFirma.Web.Common;

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
                // Pull some areas from DB...
                // --------------------------
                Check.Ensure(HttpRequestStorage.DatabaseEntities.GeospatialAreas.Any(),
                    "No Geospatial areas found in HttpRequestStorage.DatabaseEntities; expecting at least Watersheds for example. If this not true for your tenant, modify this health check.");

                var aGeoSpatialArea = HttpRequestStorage.DatabaseEntities.GeospatialAreas.First();
                Check.EnsureNotNull(aGeoSpatialArea);
                Check.EnsureNotNull(aGeoSpatialArea.GeospatialAreaFeature);

                // Make sure Sql Server Spatial DLL functions properly
                // These should not throw
                SqlGeometryUtilities.AreSqlGeometriesEqual(geom1, geom2);

            }
            catch (Exception e)
            {
                resultMessage = e.Message;
                return false;
            }
            return true;
        }


        public static class SqlGeometryUtilities
        {
            /// <summary>
            /// Checks if two <see cref="SqlGeometry"/> instances are equal, works on null also. Null equals Null in this case. Also handles <see cref="INullable.IsNull"/> so <see cref="SqlGeometry.Null"/> equals <see cref="SqlGeometry.Null"/> 
            /// </summary>
            public static bool AreSqlGeometriesEqual(SqlGeometry lhs, SqlGeometry rhs)
            {
                if (lhs == null && rhs == null)
                {
                    return true;
                }
                if (lhs == null ^ rhs == null)
                {
                    return false;
                }
                if (lhs.IsNull && rhs.IsNull)
                {
                    return true;
                }
                if (lhs.IsNull ^ rhs.IsNull)
                {
                    return false;
                }
                return lhs.STEquals(rhs).IsTrue;
            }
        }

    }
}