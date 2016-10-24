using System;
using ProjectFirma.Web.Models;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.ProjectUpdate
{
    public class ReturnDialogFormViewModel : PartialViewModel
    {
        public string SectionComments { get; set; }
        public ProjectUpdateSectionEnum? ProjectUpdateSectionEnum { get; set; }

        public void UpdateModel(ProjectUpdateBatch projectUpdateBatch)
        {
            if (ProjectUpdateSectionEnum.HasValue)
            {
                switch (ProjectUpdateSectionEnum.Value)
                {
                    case ProjectUpdate.ProjectUpdateSectionEnum.Basics:
                        projectUpdateBatch.BasicsComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.Expenditures:
                        projectUpdateBatch.ExpendituresComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.EIPPerformanceMeasures:
                        projectUpdateBatch.EIPPerformanceMeasuresComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.LocationSimple:
                        projectUpdateBatch.LocationSimpleComment = SectionComments;
                        break;
                    case ProjectUpdate.ProjectUpdateSectionEnum.LocationDetailed:
                        projectUpdateBatch.LocationDetailedComment = SectionComments;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}