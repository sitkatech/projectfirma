using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.ProjectCreate;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class ProjectCreateSection
    {
        public abstract bool IsComplete(Project project);
        public abstract string GetSectionUrl(Project project);
    }

    public partial class ProjectCreateSectionBasics
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            var basicsResults = new BasicsViewModel(project).GetValidationResults();
            return !basicsResults.Any();
        }

        public override string GetSectionUrl(Project project)
        {
            return project != null ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditBasics(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionLocationSimple
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }

            var locationSimpleValidationResults = new LocationSimpleViewModel(project).GetValidationResults();
            return !locationSimpleValidationResults.Any();            
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationSimple(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionLocationDetailed
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            return true;
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditLocationDetailed(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionExpectedPerformanceMeasures
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            var pmValidationResults = new ExpectedPerformanceMeasureValuesViewModel(project).GetValidationResults();
            return !pmValidationResults.Any();
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditExpectedPerformanceMeasureValues(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionReportedPerformanceMeasures
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            var pmValidationResults = new PerformanceMeasuresViewModel(
                project.PerformanceMeasureActuals.Select(x => new PerformanceMeasureActualSimple(x)).ToList(),
                project.PerformanceMeasureActualYearsExemptionExplanation,
                project.GetPerformanceMeasuresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList())
                {
                    ProjectID = project.ProjectID
                }.GetValidationResults();
            return !pmValidationResults.Any();
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.PerformanceMeasures(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionAssessment
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            var assessmentValidationResults = new EditAssessmentViewModel(project.ProjectAssessmentQuestions.Select(x => new ProjectAssessmentQuestionSimple(x)).ToList()).GetValidationResults();
            return !assessmentValidationResults.Any();
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditAssessment(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionClassifications
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }

            var projectClassificationSimples = ProjectCreateController.GetProjectClassificationSimples(project);

            var classificationValidationResults = new EditProposalClassificationsViewModel(projectClassificationSimples).GetValidationResults();
            return !classificationValidationResults.Any();
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.EditClassifications(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionPhotos
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            return Basics.IsComplete(project);
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Photos(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionNotesAndDocuments
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            return Basics.IsComplete(project);
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.DocumentsAndNotes(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionExpectedFunding
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            // todo: more complicated than that.
            return Basics.IsComplete(project);
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.ExpectedFunding(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionReportedExpenditures
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            var projectFundingSourceExpenditures = project.ProjectFundingSourceExpenditures.ToList();
            var validationResults = new ExpendituresViewModel(projectFundingSourceExpenditures,
                    projectFundingSourceExpenditures.CalculateCalendarYearRangeForExpenditures(project), project,
                    project.GetExpendituresExemptReportingYears().Select(x => new ProjectExemptReportingYearSimple(x)).ToList()) {ProjectID = project.ProjectID}
                .GetValidationResults();
            return !validationResults.Any();
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Expenditures(project.ProjectID)) : null;
        }
    }

    public partial class ProjectCreateSectionOrganizations
    {
        public override bool IsComplete(Project project)
        {
            if (project == null)
            {
                return false;
            }
            var validationResults = new OrganizationsViewModel(project, null).GetValidationResults().ToList();
            return !validationResults.Any();
        }

        public override string GetSectionUrl(Project project)
        {
            return Basics.IsComplete(project) ? SitkaRoute<ProjectCreateController>.BuildUrlFromExpression(x => x.Organizations(project.ProjectID)) : null;
        }
    }
}
