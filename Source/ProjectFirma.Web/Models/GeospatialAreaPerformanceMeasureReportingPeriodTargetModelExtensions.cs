using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class GeospatialAreaPerformanceMeasureReportingPeriodTargetModelExtensions
    {

        public static GeospatialAreaPerformanceMeasureReportingPeriodTarget GetOrCreateGeospatialAreaPerformanceMeasureReportingPeriodTarget(PerformanceMeasure performanceMeasure, GeospatialArea geospatialArea, PerformanceMeasureReportingPeriod performanceMeasureReportingPeriod)
        {
            var reportingPeriodTarget = HttpRequestStorage.DatabaseEntities.GeospatialAreaPerformanceMeasureReportingPeriodTargets.SingleOrDefault(pmrpt => pmrpt.PerformanceMeasureID == performanceMeasure.PerformanceMeasureID && pmrpt.GeospatialAreaID == geospatialArea.GeospatialAreaID);
            if (reportingPeriodTarget == null)
            {
                reportingPeriodTarget = new GeospatialAreaPerformanceMeasureReportingPeriodTarget(geospatialArea, performanceMeasure, performanceMeasureReportingPeriod);
            }

            return reportingPeriodTarget;
        }

    }
}