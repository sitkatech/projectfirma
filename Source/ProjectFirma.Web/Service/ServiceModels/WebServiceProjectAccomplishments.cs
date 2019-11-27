/*-----------------------------------------------------------------------
<copyright file="WebServiceProjectAccomplishments.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceProjectAccomplishments : SimpleModelObject
    {
        public WebServiceProjectAccomplishments(PerformanceMeasureActual perfomanceMeasureActualValue)
        {
            var project = perfomanceMeasureActualValue.Project;
            var pm = perfomanceMeasureActualValue.PerformanceMeasure;
            ProjectID = project.ProjectID;

            PerformanceMeasureID = pm.PerformanceMeasureID;
            PerformanceMeasureName = pm.PerformanceMeasureDisplayName;
            PerformanceMeasureUnits = pm.MeasurementUnitType.MeasurementUnitTypeDisplayName;
            PerformanceMeasureProjectValue = perfomanceMeasureActualValue.ActualValue;
            PerformanceMeasureProjectYear = perfomanceMeasureActualValue.PerformanceMeasureReportingPeriod.PerformanceMeasureReportingPeriodCalendarYear;

            var currentPMSubcategoryIndex = 1;
            foreach (var perfomanceMeasureActualValueSubcategoryOption in perfomanceMeasureActualValue.PerformanceMeasureActualSubcategoryOptions)
            {
                if (currentPMSubcategoryIndex == 1)
                {
                    PMSubcategoryName1 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                    PMSubcategoryOption1 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 2)
                {
                    PMSubcategoryName2 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                    PMSubcategoryOption2 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 3)
                {
                    PMSubcategoryName3 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                    PMSubcategoryOption3 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                }
                else if (currentPMSubcategoryIndex == 4)
                {
                    PMSubcategoryName4 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategory.PerformanceMeasureSubcategoryDisplayName;
                    PMSubcategoryOption4 = perfomanceMeasureActualValueSubcategoryOption.PerformanceMeasureSubcategoryOption.PerformanceMeasureSubcategoryOptionName;
                }
                else
                {
                    throw new NotImplementedException($"Cannot handle more than four {FieldDefinitionEnum.PerformanceMeasureSubcategory.ToType().GetFieldDefinitionLabelPluralized()} on a {FieldDefinitionEnum.PerformanceMeasure.ToType().GetFieldDefinitionLabel()}");
                }
                currentPMSubcategoryIndex++;
            }
        }

      

        [DataMember] public int ProjectID { get; set; }
        [DataMember] public int PerformanceMeasureID { get; set; }
        [DataMember] public string PerformanceMeasureName { get; set; }
        [DataMember] public string PerformanceMeasureUnits { get; set; }
        [DataMember] public int PerformanceMeasureProjectYear { get; set; }
        [DataMember] public double PerformanceMeasureProjectValue { get; set; }
        
        [DataMember] public string PMSubcategoryName1 { get; set; }
        [DataMember] public string PMSubcategoryOption1 { get; set; }
        [DataMember] public string PMSubcategoryName2 { get; set; }
        [DataMember] public string PMSubcategoryOption2 { get; set; }
        [DataMember] public string PMSubcategoryName3 { get; set; }
        [DataMember] public string PMSubcategoryOption3 { get; set; }
        [DataMember] public string PMSubcategoryName4 { get; set; }
        [DataMember] public string PMSubcategoryOption4 { get; set; }    

        public static List<WebServiceProjectAccomplishments> GetProjectAccomplishments(int projectID)
        {
            var project = HttpRequestStorage.DatabaseEntities.Projects.GetProject(projectID);
            return project.PerformanceMeasureActuals.Select(x => new WebServiceProjectAccomplishments(x)).OrderBy(x => x.PerformanceMeasureName).ToList();
        }       
    }

    public class WebServiceProjectAccomplishmentsGridSpec : GridSpec<WebServiceProjectAccomplishments>
    {
        public WebServiceProjectAccomplishmentsGridSpec()
        {
            Add("ProjectID", x => x.ProjectID, 0);
            Add("PerformanceMeasureID", x => x.PerformanceMeasureID, 0);
            Add("PerformanceMeasureName", x => x.PerformanceMeasureName, 0);
            Add("PerformanceMeasureUnits", x => x.PerformanceMeasureUnits, 0);
            Add("PerformanceMeasureProjectYear", x => x.PerformanceMeasureProjectYear, 0);
            Add("PerformanceMeasureProjectValue", x => x.PerformanceMeasureProjectValue, 0);

            Add("PMSubcategoryName1", x => x.PMSubcategoryName1, 0);
            Add("PMSubcategoryOptionCount1", x => x.PMSubcategoryOption1, 0);
            Add("PMSubcategoryName2", x => x.PMSubcategoryName2, 0);
            Add("PMSubcategoryOptionCount2", x => x.PMSubcategoryOption2, 0);
            Add("PMSubcategoryName3", x => x.PMSubcategoryName3, 0);
            Add("PMSubcategoryOptionCount3", x => x.PMSubcategoryOption3, 0);
            Add("PMSubcategoryName4", x => x.PMSubcategoryName4, 0);
            Add("PMSubcategoryOptionCount4", x => x.PMSubcategoryOption4, 0);
        }
    }
}
