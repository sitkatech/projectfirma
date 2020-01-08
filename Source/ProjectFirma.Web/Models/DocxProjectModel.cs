using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using LtInfo.Common;
using SharpDocx;
using SharpDocx.Extensions;
using Color = DocumentFormat.OpenXml.Wordprocessing.Color;

namespace ProjectFirma.Web.Models
{
    public class DocxProjectModel
    {

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public string ApprovalDate { get; set; }
        public string SubmissionDate { get; set; }
        public string CompletionYear { get; set; }
        public string ImplementationStartYear { get; set; }
        public string ProjectStatusColor { get; set; }
        public string ProjectStatusName { get; set; }
        public string ProjectStage { get; set; }
        public string EstimatedTotalCost { get; set; }

        private List<ProjectContact> ProjectContacts { get; set; }
        private List<ProjectOrganization> ProjectOrganizations { get; set; }

        public DocxProjectModel(Project project)
        {
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            ApprovalDate = project.ApprovalDate.ToString();
            SubmissionDate = project.SubmissionDate.ToString();
            CompletionYear = project.CompletionYear.ToString();
            ImplementationStartYear = project.ImplementationStartYear.ToString();

            var projectStatus = project.GetCurrentProjectStatus();
            if (projectStatus != null)
            {
                ProjectStatusColor = projectStatus.ProjectStatusColor;
                ProjectStatusName = projectStatus.ProjectStatusDisplayName;
            }

            ProjectContacts = project.ProjectContacts.ToList();
            ProjectOrganizations = project.ProjectOrganizations.ToList();

            ProjectStage = project.ProjectStage.ProjectStageDisplayName;

            EstimatedTotalCost = project.GetEstimatedTotalRegardlessOfFundingType().ToStringCurrency();

        }

        public string GetProjectContactNamesByType(string contactTypeName)
        {
            var projectContactsInType = ProjectContacts.Where(x => x.ContactRelationshipType.ContactRelationshipTypeName == contactTypeName).ToList();
            var projectContactNames = projectContactsInType.Select(x => x.Contact.GetFullNameFirstLast()).ToList();
            return $"{string.Join(", ", projectContactNames)}";
        }

        public string GetProjectOrganizationNamesByType(string organizationTypeName)
        {
            var organizationsInType = ProjectOrganizations.Where(x => x.OrganizationRelationshipType.OrganizationRelationshipTypeName == organizationTypeName).ToList();
            var organizationNames = organizationsInType.Select(x => x.Organization.GetDisplayName()).ToList();
            return $"{string.Join(", ", organizationNames)}";
        }

    }
    
    public class DocxTemplateModel
    {
        public List<DocxProjectModel> Projects { get; set; }
        public string Title { get; set; }

    }

    public abstract class ProjectFirmaDocxDocument : DocumentBase
    {
        public string MyProperty { get; set; }

        public new static List<string> GetUsingDirectives()
        {
            return new List<string>
            {
                "using ProjectFirma.Web.Models;",
                "using System.Linq;"

            };
        }

        // referencing required assemblies
        public new static List<string> GetReferencedAssemblies()
        {
            return new List<string>
            {
                "System.Core.dll",
            };
        }

        protected void SetCellColor(string color)
        {
            if (color == null) return;
            color = color.Replace("#", "");

            var cell = CurrentCodeBlock.Placeholder.GetParent<TableCell>();
            if (cell == null) return;
            cell.TableCellProperties.Shading = new Shading
            {
                Fill = color,
                Color = "auto",
                Val = new EnumValue<ShadingPatternValues>(ShadingPatternValues.Clear)
            };
        }

        protected void SetTextColor(string color)
        {
            var run = CurrentCodeBlock.Placeholder.GetParent<Run>();
            if (run == null) return;
            run.RunProperties.Color = new Color { Val = color };
        }
    }
}