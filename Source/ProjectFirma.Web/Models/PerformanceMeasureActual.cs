/*-----------------------------------------------------------------------
<copyright file="PerformanceMeasureActual.cs" company="Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class PerformanceMeasureActual : IAuditableEntity, IPerformanceMeasureValue
    {
        public string ActualValueDisplay
        {
            get { return GetActualValueDisplay(ActualValue, PerformanceMeasure); }
        }

        private static string GetActualValueDisplay(double expectedValue, PerformanceMeasure performanceMeasure)
        {
            return performanceMeasure.MeasurementUnitType.DisplayValue(expectedValue);
        }

        public string AuditDescriptionString
        {
            get
            {
                var project = HttpRequestStorage.DatabaseEntities.AllProjects.Find(ProjectID);
                var performanceMeasure = HttpRequestStorage.DatabaseEntities.AllPerformanceMeasures.Find(PerformanceMeasureID);
                var projectName = project != null ? project.AuditDescriptionString : ViewUtilities.NotFoundString;
                var performanceMeasureName = performanceMeasure != null ? performanceMeasure.AuditDescriptionString : ViewUtilities.NotFoundString;
                var actualValue = GetActualValueDisplay(ActualValue, performanceMeasure);
                return string.Format("Project: {0}, Performance Measure: {1}, Actual Value: {2}", projectName, performanceMeasureName, actualValue);
            }
        }

        public List<IPerformanceMeasureValueSubcategoryOption> PerformanceMeasureSubcategoryOptions
        {
            get { return new List<IPerformanceMeasureValueSubcategoryOption>(PerformanceMeasureActualSubcategoryOptions.ToList()); }
        }
        public double? ReportedValue
        {
            get { return ActualValue; }
        }

        public string PerformanceMeasureSubcategoriesAsString
        {
            get
            {
                if (PerformanceMeasure.HasRealSubcategories)
                {
                    return PerformanceMeasureActualSubcategoryOptions.Any()
                        ? string.Join("\r\n",
                            PerformanceMeasureActualSubcategoryOptions.OrderBy(x => x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName)
                                .Select(x => string.Format("{0}: {1}", x.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName, x.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName)))
                        : ViewUtilities.NoneString;
                }
                else
                {
                    return string.Empty;
                }
        }
        }
    }
}
