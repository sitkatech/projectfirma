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
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectWatershedControls;

namespace ProjectFirma.Web.Views.ProjectCreate
{
    //public enum ProposalSectionEnum
    //{
    //    Instructions,
    //    Basics,
    //    PerformanceMeasures,
    //    LocationSimple,
    //    LocationDetailed,
    //    Watershed,
    //    Classifications,
    //    Assessment,
    //    Notes,
    //    History,
    //    Photos,
    //    ExpectedFunding
    //}

    public class ProposalSectionsStatus
    {
        public bool IsBasicsSectionComplete { get; set; }
        public bool IsPerformanceMeasureSectionComplete { get; set; }
        public bool IsProjectLocationSimpleSectionComplete { get; set; }
        public bool IsProjectLocationDetailedSectionComplete { get; set; }
        public bool IsWatershedSectionComplete { get; set; }
        public bool IsClassificationsComplete { get; set; }
        public bool IsAssessmentComplete { get; set; }
        public bool IsNotesSectionComplete { get; set; }
        public bool AreAllSectionsValid => IsBasicsSectionComplete && IsPerformanceMeasureSectionComplete && IsClassificationsComplete && IsAssessmentComplete && IsProjectLocationSimpleSectionComplete && IsProjectLocationDetailedSectionComplete && IsWatershedSectionComplete && IsNotesSectionComplete && IsExpectedFundingSectionComplete;
        public bool IsExpectedFundingSectionComplete { get; set; }

        public ProposalSectionsStatus(Models.Project proposal)
        {
            var basicsResults = new BasicsViewModel(proposal).GetValidationResults();
            IsBasicsSectionComplete = !basicsResults.Any();

            var locationSimpleValidationResults = new LocationSimpleViewModel(proposal).GetValidationResults();
            IsProjectLocationSimpleSectionComplete = !locationSimpleValidationResults.Any();

            IsProjectLocationDetailedSectionComplete = IsBasicsSectionComplete;

            var editWatershedValidationResults = new EditProjectWatershedsViewModel(proposal.ProjectWatersheds.Select(x => x.WatershedID).ToList(), proposal.ProjectWatershedNotes).GetValidationResults();
            IsWatershedSectionComplete = !editWatershedValidationResults.Any();

            var pmValidationResults = new ExpectedPerformanceMeasureValuesViewModel(proposal).GetValidationResults();
            IsPerformanceMeasureSectionComplete = !pmValidationResults.Any();

            var efValidationResults = new ExpectedFundingViewModel(proposal.ProjectFundingSourceRequests.ToList())
                .GetValidationResults();
            IsExpectedFundingSectionComplete = !efValidationResults.Any();

            var proposalClassificationSimples = ProjectCreateController.GetProjectClassificationSimples(proposal);
            var classificationValidationResults = new EditProposalClassificationsViewModel(proposalClassificationSimples).GetValidationResults();
            IsClassificationsComplete = !classificationValidationResults.Any();

            IsAssessmentComplete = ProjectCreateController.GetProjectAssessmentQuestionSimples(proposal).All(simple => simple.Answer.HasValue);

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
            IsWatershedSectionComplete = false;
            IsNotesSectionComplete = false;
        }
    }
}
