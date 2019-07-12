/*-----------------------------------------------------------------------
<copyright file="ProposalSectionsStatus.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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

using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectGeospatialAreaControls;
using ProjectFirmaModels.Models;
using System.Collections.Generic;
using System.Linq;

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
        public static bool AreAllSectionsValidForProject(ProjectFirmaModels.Models.Project project)
        {
            return project.GetApplicableProposalWizardSections(false).All(x => x.IsComplete);
        }
        public bool IsExpectedFundingSectionComplete { get; set; }
        public bool IsProjectOrganizationsSectionComplete { get; set; }

        public ProposalSectionsStatus(ProjectFirmaModels.Models.Project project, List<GeospatialAreaType> geospatialAreaTypes)
        {
            var basicsResults = new BasicsViewModel(project).GetValidationResults();
            IsBasicsSectionComplete = !basicsResults.Any();

            var locationSimpleValidationResults = new LocationSimpleViewModel(project).GetValidationResults();
            IsProjectLocationSimpleSectionComplete = !locationSimpleValidationResults.Any();

            IsProjectLocationDetailedSectionComplete = IsBasicsSectionComplete;

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

            IsPerformanceMeasureSectionComplete = IsBasicsSectionComplete;

            var expectedFundingValidationResults = new ExpectedFundingViewModel(project)
                .GetValidationResults();
            IsExpectedFundingSectionComplete = !expectedFundingValidationResults.Any();

            var proposalClassificationSimples = ProjectCreateController.GetProjectClassificationSimples(project);
            var classificationValidationResults = new EditProposalClassificationsViewModel(proposalClassificationSimples).GetValidationResults();
            IsClassificationsComplete = !classificationValidationResults.Any();

            IsAssessmentComplete = ProjectCreateController.GetProjectAssessmentQuestionSimples(project).All(simple => simple.Answer.HasValue);

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
