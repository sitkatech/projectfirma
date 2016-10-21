using System.Collections.Generic;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Areas.EIP.Views.ProposedProject
{
    public class EditProposedProjectThresholdCategoriesViewData : ProposedProjectViewData
    {
        public readonly List<ThresholdCategory> ThresholdCategories;
        public readonly string ProjectName;
        
        public EditProposedProjectThresholdCategoriesViewData(Person currentPerson, Models.ProposedProject proposedProject, List<ThresholdCategory> thresholdCategories, ProposedProjectSectionEnum proposedProjectSection, ProposalSectionsStatus proposalSectionsStatus)
            : base(currentPerson, proposedProject, proposedProjectSection, proposalSectionsStatus)
        {
            ProjectName = proposedProject.DisplayName;
            ThresholdCategories = thresholdCategories;
        }
    }
}