using System.Collections.Generic;
using System.Linq;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Api.Controllers
{
    public class ProjectCustomAttributeDto
    {
        public ProjectCustomAttributeDto()
        {
        }

        public ProjectCustomAttributeDto(ProjectCustomAttribute projectCustomAttribute)
        {
            ProjectCustomAttributeTypeName = projectCustomAttribute.ProjectCustomAttributeType.ProjectCustomAttributeTypeName;
            Values = projectCustomAttribute.ProjectCustomAttributeValues.Select(x => x.AttributeValue).ToList();
        }

        public string ProjectCustomAttributeTypeName { get; set; }
        public List<string> Values { get; set; }
    }
}