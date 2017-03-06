/*-----------------------------------------------------------------------
<copyright file="ProposalSectionsStatus.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using System.Linq;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public enum ProposedProjectSectionEnum
    {
        Instructions,
        Basics,
        PerformanceMeasures,
        LocationSimple,
        LocationDetailed,
        Classifications,
        Assessment,
        Notes,
        History,
        Photos
    }

    public class ProposalSectionsStatus
    {
        public bool IsBasicsSectionComplete { get; set; }
        public bool IsPerformanceMeasureSectionComplete { get; set; }
        public bool IsProjectLocationSimpleSectionComplete { get; set; }
        public bool IsProjectLocationDetailedSectionComplete { get; set; }
        public bool IsClassificationsComplete { get; set; }
        public bool IsAssessmentComplete { get; set; }
        public bool IsNotesSectionComplete { get; set; }
        public bool AreAllSectionsValid
        {
            get
            {
                return IsBasicsSectionComplete && IsPerformanceMeasureSectionComplete && IsClassificationsComplete && IsAssessmentComplete && IsProjectLocationSimpleSectionComplete && IsProjectLocationSimpleSectionComplete && IsNotesSectionComplete;
            }
        }

        public ProposalSectionsStatus(Models.ProposedProject proposedProject)
        {
            var basicsResults = new BasicsViewModel(proposedProject).GetValidationResults();
            IsBasicsSectionComplete = !basicsResults.Any();

            var locationSimpleValidationResults = new LocationSimpleViewModel(proposedProject).GetValidationResults();
            IsProjectLocationSimpleSectionComplete = !locationSimpleValidationResults.Any();

            IsProjectLocationDetailedSectionComplete = IsBasicsSectionComplete;

            var pmValidationResults = new ExpectedPerformanceMeasureValuesViewModel(proposedProject).GetValidationResults();
            IsPerformanceMeasureSectionComplete = !pmValidationResults.Any();

            var proposedProjectClassificationSimples = ProposedProjectController.GetProposedProjectClassificationSimples(proposedProject);
            var classificationValidationResults = new EditProposedProjectClassificationsViewModel(proposedProjectClassificationSimples).GetValidationResults();
            IsClassificationsComplete = !classificationValidationResults.Any();

            IsAssessmentComplete = ProposedProjectController.GetProposedProjectAssessmentQuestionSimples(proposedProject).All(simple => simple.Answer.HasValue);

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
            IsNotesSectionComplete = false;
        }
    }
}
