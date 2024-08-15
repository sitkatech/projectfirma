﻿/*-----------------------------------------------------------------------
<copyright file="ProposalSectionsStatus.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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

using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    public class ProposalSectionsStatus
    {
        public bool IsBasicsSectionComplete { get; set; }
        public bool IsPerformanceMeasureSectionComplete { get; set; }
        public bool IsProjectLocationSimpleSectionComplete { get; set; }
        public bool IsProjectLocationDetailedSectionComplete { get; set; }
        public bool IsGeospatialAreaSectionComplete { get; set; }
        public bool IsClassificationsComplete { get; set; }
        public bool IsAssessmentComplete { get; set; }
        public bool IsNotesSectionComplete { get; set; }
        public bool AreAllSectionsValid => IsBasicsSectionComplete && IsPerformanceMeasureSectionComplete && IsClassificationsComplete && IsAssessmentComplete && IsProjectLocationSimpleSectionComplete && IsProjectLocationDetailedSectionComplete && IsGeospatialAreaSectionComplete && IsNotesSectionComplete && IsExpectedFundingSectionComplete;
        public static bool AreAllSectionsValidForProject(ProjectFirmaModels.Models.Project project, FirmaSession currentFirmaSession)
        {
            if (project.ExternalID != null && new FirmaAdminFeature().HasPermissionByFirmaSession(currentFirmaSession))
            {
                // only need the Basics to be complete
                return ProjectCreateSection.Basics.IsComplete(project);
            }
            return project.GetApplicableProposalWizardSections(false, project.HasEditableCustomAttributes(currentFirmaSession)).All(x => x.IsComplete);
        }
        public bool IsExpectedFundingSectionComplete { get; set; }
        public bool IsProjectOrganizationsSectionComplete { get; set; }
        public bool IsProjectContactsSectionComplete { get; set; }
        public bool IsProjectCustomAttributesSectionComplete { get; set; }

        /// <summary>
        /// Method to check whether each section in a proposal is complete
        /// 
        /// </summary>
        /// <param name="project"></param>
        /// <param name="geospatialAreaTypes">Geospatial areas are defined per tenant, this is passed to check if the tenant has any and are complete</param>
        public ProposalSectionsStatus(ProjectFirmaModels.Models.Project project, List<GeospatialAreaType> geospatialAreaTypes, List<ProjectFirmaModels.Models.ClassificationSystem> classificationSystems, FirmaSession currentFirmaSession)
        {
            // Basics section
            var basicsResults = new BasicsViewModel(project).GetValidationResults();
            IsBasicsSectionComplete = !basicsResults.Any();

            // Custom Attributes section
            var customAttributesValidationResults = project.ValidateCustomAttributes(currentFirmaSession).GetWarningMessages();
            IsProjectCustomAttributesSectionComplete = !customAttributesValidationResults.Any();

            // Project Location simple section
            var locationSimpleValidationResults = new LocationSimpleViewModel(project).GetValidationResults();
            IsProjectLocationSimpleSectionComplete = !locationSimpleValidationResults.Any();

            // Project location detailed section
            IsProjectLocationDetailedSectionComplete = IsBasicsSectionComplete;

            // Geospatial Area section
            if (geospatialAreaTypes.Any())
            {
                var isGeospatialAreaSectionComplete = true;
                foreach (var geospatialAreaType in geospatialAreaTypes)
                {
                    var geospatialAreaIDs = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID).Select(x => x.GeospatialAreaID).ToList();
                    var editGeospatialAreaValidationResults = new EditProjectGeospatialAreasViewModel(geospatialAreaIDs, project.ProjectGeospatialAreaTypeNotes.SingleOrDefault(x => x.GeospatialAreaTypeID == geospatialAreaType.GeospatialAreaTypeID)?.Notes).GetValidationResults();
                    if (editGeospatialAreaValidationResults.Any())
                    {
                        isGeospatialAreaSectionComplete = false;
                        break;
                    }
                }

                IsGeospatialAreaSectionComplete = isGeospatialAreaSectionComplete;
            }
            else
            {
                IsGeospatialAreaSectionComplete = true;
            }

            // Performance Measure section
            IsPerformanceMeasureSectionComplete = IsBasicsSectionComplete;

            // Expected Funding section
            var expectedFundingValidationResults = new ExpectedFundingViewModel(project)
                .GetValidationResults();
            IsExpectedFundingSectionComplete = !expectedFundingValidationResults.Any();

            // Classifications section
            var isClassificationComplete = true;
            foreach (var classificationSystem in classificationSystems)
            {
                var proposalClassificationSimples = ProjectCreateController.GetProjectClassificationSimples(project, classificationSystem.ClassificationSystemID);
                var classificationValidationResults = new EditProposalClassificationsViewModel(proposalClassificationSimples, project, classificationSystem.IsRequired).GetValidationResults();
                isClassificationComplete = isClassificationComplete && !classificationValidationResults.Any();
            }

            IsClassificationsComplete = isClassificationComplete;

            // Assessment section
            IsAssessmentComplete = ProjectCreateController.GetProjectAssessmentQuestionSimples(project).All(simple => simple.Answer.HasValue);

            // Notes section
            IsNotesSectionComplete = IsBasicsSectionComplete; //there is no validation required on Notes
        }

        public ProposalSectionsStatus()
        {
            IsBasicsSectionComplete = false;
            IsPerformanceMeasureSectionComplete = false;
            IsClassificationsComplete = false;
            IsAssessmentComplete = false;
            IsProjectLocationSimpleSectionComplete = false;
            IsProjectLocationDetailedSectionComplete = false;
            IsGeospatialAreaSectionComplete = false;
            IsNotesSectionComplete = false;
        }
    }
}
