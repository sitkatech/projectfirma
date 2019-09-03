using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeSimple
    {
        public ProjectCustomAttributeSimple(IProjectCustomAttribute projectCustomAttribute)
        {
            
            ProjectCustomAttributeTypeID = projectCustomAttribute.ProjectCustomAttributeTypeID;
            ProjectCustomAttributeValues = projectCustomAttribute.GetCustomAttributeValues()
                .Select(y =>
                    y.GetIProjectCustomAttribute().ProjectCustomAttributeType.ProjectCustomAttributeDataType ==
                    ProjectCustomAttributeDataType.DateTime
                        ? DateTime.Parse(y.AttributeValue).ToShortDateString()
                        : y.AttributeValue)
                .ToList();
        }

        public ProjectCustomAttributeSimple()
        {
            ProjectCustomAttributeValues = new List<string>();
        }

        public int ProjectCustomAttributeTypeID { get; set; }
        public IList<string> ProjectCustomAttributeValues { get; set; }
    }
}
