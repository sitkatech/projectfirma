using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class ProjectDto
    {
        public ProjectDto(Project project)
        {
            ProjectID = project.ProjectID;
            ProjectName = project.ProjectName;
            PrimaryContact = project.PrimaryContactPerson?.GetFullNameFirstLast();
            OwnerOrganization = project.GetPrimaryContactOrganization()?.OrganizationName;
            ProjectStage = project.ProjectStage.ProjectStageDisplayName;
            ImplementationStartYear = project.ImplementationStartYear;
            CompletionYear = project.CompletionYear;
            TaxonomyTrunk = project.TaxonomyLeaf.TaxonomyBranch.TaxonomyTrunk.GetDisplayName();
            var taxonomyLeafs = new List<string> {project.TaxonomyLeaf.GetDisplayName()};
            if (project.SecondaryProjectTaxonomyLeafs.Any())
            {
                taxonomyLeafs.AddRange(project.SecondaryProjectTaxonomyLeafs.Select(x => x.TaxonomyLeaf.GetDisplayName()));
            }
            TaxonomyLeafs = string.Join(", ", taxonomyLeafs.OrderBy(x => x));
            Classifications = project.ProjectClassifications.Any() ? string.Join(", ", project.ProjectClassifications.Select(x => x.Classification.DisplayName).OrderBy(x => x)) : null;
            var leadEntities = project.ProjectGeospatialAreas.Where(x => x.GeospatialArea.GeospatialAreaType.GeospatialAreaTypeName == "Lead Entity").ToList();
            LeadEntities = project.ProjectGeospatialAreas.Any() ? string.Join(", ", leadEntities.Select(x => x.GeospatialArea.GeospatialAreaName).OrderBy(x => x)) : null;
            DetailUrl = $"/Project/Detail/{project.ProjectID}";
        }

        public ProjectDto()
        {
        }

        public int ProjectID { get; set; }
        public string OwnerOrganization { get; set; }
        public string ProjectStage { get; set; }

        public string ProjectName { get; set; }
        public string TaxonomyTrunk { get; set; }
        public int? ImplementationStartYear { get; set; }
        public string PrimaryContact { get; set; }
        public string LeadEntities { get; set; }

        public string Classifications { get; set; }

        public int? CompletionYear { get; set; }

        public string TaxonomyLeafs { get; set; }
        public string DetailUrl { get; set; }
    }
}