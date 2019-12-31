using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using LtInfo.Common.DesignByContract;
using ProjectFirmaModels.Models;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using SharpDocx;

namespace ProjectFirma.Web.Models
{
    public class DocxProjectModel
    {

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string> StringList { get; set; }

        public string ProjectImageUrl { get; set; }

        public List<OrganizationSimple> Organizations { get; set; }


        public SharpDocxImage Image { get; set; }

        public DocxProjectModel(Project project)
        {
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            StringList = new List<string>() {"test", "test2"};
            if (project.GetKeyPhoto() != null)
            {
                ProjectImageUrl = project.GetKeyPhoto().GetPhotoUrlScaledForPrint();
            }

            Organizations = new List<OrganizationSimple>();
            var organizations = project.ProjectOrganizations.ToList();
            foreach (var projectOrganization in organizations.Where(projectOrganization => projectOrganization.Organization != null))
            {
                Organizations.Add(new OrganizationSimple(projectOrganization.Organization));
            }

            if (project.GetKeyPhoto() != null)
            {
                var projectImage = project.GetKeyPhoto();
                var stream = new MemoryStream(projectImage.FileResource.FileResourceData);
                Image = new SharpDocxImage(stream, ImageHelper.GetImagePartType(projectImage.FileResource.OriginalFileExtension));
            }

        }

    }
    
    public class DocxTemplateModel
    {
        public List<DocxProjectModel> Projects { get; set; }
        public string Title { get; set; }

    }

}