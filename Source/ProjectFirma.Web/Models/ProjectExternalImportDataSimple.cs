using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LtInfo.Common;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProjectExternalImportDataSimple : IValidatableObject
    {
        public string ApplicationNumber { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }

        [Required]
        public string Description { get; set; }
        public string Permit { get; set; }
        public string Species { get; set; }
        public string Goal { get; set; }
        public string LandUse { get; set; }
        public string OSTAT { get; set; }
        public string Needed { get; set; }
        public string DEI { get; set; }
        public string StreamName { get; set; }
        public string Tributary { get; set; }
        public string Subbasin { get; set; }
        public string ReportedSubbasin { get; set; }
        public string Township { get; set; }
        public string Range { get; set; }
        public string Section { get; set; }
        public string County { get; set; }
        public string SpeciesBenefit { get; set; }
        public string MultiYear { get; set; }
        public string HasPermit { get; set; }
        public string ProjectNumber { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }
        public int ProjectID { get; set; }
        public string OGMSProjectID { get; set; }
        public string Cash { get; set; }
        public string Inkind { get; set; }
        public string StartMonth { get; set; }
        public string EndMonth { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
        public string HasPlan { get; set; }
        public string PlanName { get; set; }
        public string PlanBy { get; set; }
        public string PlanYear { get; set; }
        public string HasOtherSelection { get; set; }
        public string OtherSelection { get; set; }
        public string HUC { get; set; }
        public string ConservationEasementProtected { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            
            if (HttpRequestStorage.DatabaseEntities.Projects.Any(x => x.ProjectName.Equals(ProjectName)))
            {
                errors.Add(new SitkaValidationResult<ProjectExternalImportDataSimple, string>(
                    $"Project Name \"{ProjectName}\" is already in use.", m => m.ProjectName));
            }

            return errors;
        }

        public Project PopulateNewProject()
        {
            var taxonomyLeaf = HttpRequestStorage.DatabaseEntities.TaxonomyLeafs.First();
            var project = Project.CreateNewBlank(taxonomyLeaf,
                ProjectStage.PlanningDesign,
                ProjectLocationSimpleType.None,
                FundingType.OperationsAndMaintenance,
                ProjectApprovalStatus.Draft);

            project.ProjectName = ProjectName;
            project.ProjectDescription = Description;
            project.ProposingPerson = HttpRequestStorage.Person;

            return project;
        }
    }
}
