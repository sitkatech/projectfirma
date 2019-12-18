using System.Collections.Generic;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public class DocxProjectModel
    {

        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public List<string> StringList { get; set; }


        public DocxProjectModel(Project project)
        {
            ProjectName = project.ProjectName;
            ProjectDescription = project.ProjectDescription;
            StringList = new List<string>() {"test", "test2"};
        }

    }

    public class DocxTemplateModel
    {
        public List<DocxProjectModel> Projects { get; set; }
        public string Title { get; set; }

    }

}