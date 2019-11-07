/*-----------------------------------------------------------------------
<copyright file="ClassificationModelExtensions.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.PerformanceMeasure;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class ClassificationModelExtensions
    {
        public static string GetEditUrl(this Classification classification)
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(t => t.Edit(classification));
        }

        public static string GetDetailUrl(this Classification classification)
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(t => t.Detail(classification));
        }

        public static HtmlString GetDisplayNameAsUrl(this Classification classification)
        {
            return UrlTemplate.MakeHrefString(GetDetailUrl(classification), classification.GetDisplayName());
        }

        public static string GetDeleteUrl(this Classification classification)
        {
            return SitkaRoute<ClassificationController>.BuildUrlFromExpression(c => c.DeleteClassification(classification.ClassificationID));
        }

        public static bool IsDisplayNameUnique(IEnumerable<Classification> classifications, string displayName, int currentClassificationID)
        {
            var classification = classifications.SingleOrDefault(x => x.ClassificationID != currentClassificationID && String.Equals(x.DisplayName, displayName, StringComparison.InvariantCultureIgnoreCase));
            return classification == null;
        }

        public static PerformanceMeasureChartViewData GetPerformanceMeasureChartViewData(
            this Classification classification,
            PerformanceMeasure performanceMeasure, 
            FirmaSession currentFirmaSession)
        {
            var projects = classification.GetAssociatedProjects(currentFirmaSession);
            return new PerformanceMeasureChartViewData(performanceMeasure, currentFirmaSession, false, projects);
        }

        public static List<Project> GetAssociatedProjects(this Classification classification, FirmaSession currentFirmaSession)
        {
            return classification.ProjectClassifications.Select(ptc => ptc.Project).ToList().GetActiveProjectsAndProposals(currentFirmaSession.Person.CanViewProposals()).ToList();
        }

        public static string GetKeyImageUrlLarge(this Classification classification) => classification.KeyImageFileResource != null
            ? classification.KeyImageFileResource.GetFileResourceUrlScaledForPrint()
            : "http://placehold.it/280x210";
    }
}
