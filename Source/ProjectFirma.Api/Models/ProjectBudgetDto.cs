using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Models
{
    public class ProjectBudgetDto
    {
        public ProjectBudgetDto(Project project, decimal? securedFunding, decimal? targetedFunding)
        {
            ProjectDto = new ProjectDto(project);
            SecuredFunding = securedFunding;
            TargetedFunding = targetedFunding; 
        }

        public ProjectBudgetDto()
        {
        }

        public ProjectDto ProjectDto { get; set; }
        public decimal? SecuredFunding { get; set; }
        public decimal? TargetedFunding { get; set; }

    }
}