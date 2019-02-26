﻿using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class PerformanceMeasureExpectedValueFromProjectFirma
    {
        public double? ExpectedValue { get; set; }

        public int PerformanceMeasureID { get; set; }

        public string PerformanceMeasureName { get; set; }
        public string ProjectStage { get; set; }

        public string ProjectName { get; set; }
        public string ProjectDetailUrl { get; set; }
        public string LeadImplementer { get; set; }
        public string MeasurementUnitType { get; set; }

        public List<PerformanceMeasureSubcategoryOptionFromProjectFirma> PerformanceMeasureSubcategoryOptions { get; set; }

        public PerformanceMeasureExpectedValueFromProjectFirma()
        {
        }

        public PerformanceMeasureExpectedValueFromProjectFirma(PerformanceMeasureExpected performanceMeasureExpected)
        {
            PerformanceMeasureID = performanceMeasureExpected.PerformanceMeasureID;
            PerformanceMeasureName = performanceMeasureExpected.PerformanceMeasure.PerformanceMeasureDisplayName;
            ExpectedValue = performanceMeasureExpected.GetReportedValue();
            MeasurementUnitType = performanceMeasureExpected.PerformanceMeasure.MeasurementUnitType.MeasurementUnitTypeDisplayName;
            ProjectStage = performanceMeasureExpected.Project.ProjectStage.ProjectStageDisplayName;
            LeadImplementer = performanceMeasureExpected.Project.GetPrimaryContactOrganization()?.OrganizationShortName;
            ProjectName = performanceMeasureExpected.Project.GetDisplayName();
            ProjectDetailUrl = $"/Project/Detail/{performanceMeasureExpected.Project.ProjectID}";
            PerformanceMeasureSubcategoryOptions = performanceMeasureExpected
                .PerformanceMeasureExpectedSubcategoryOptions.Select(x => new PerformanceMeasureSubcategoryOptionFromProjectFirma(x))
                .ToList();
        }
    }
}