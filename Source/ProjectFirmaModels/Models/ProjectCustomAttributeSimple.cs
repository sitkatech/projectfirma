using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirmaModels.Models
{
    public class ProjectCustomAttributeSimple
    {
        public int ProjectCustomAttributeTypeID { get; set; }
        public int ProjectCustomAttributeGroupID { get; set; }
        public IList<string> ProjectCustomAttributeValues { get; set; }

        /// <summary>
        /// Full Constructor
        /// </summary>
        /// <param name="projectCustomAttribute"></param>
        public ProjectCustomAttributeSimple(IProjectCustomAttribute projectCustomAttribute)
        {
            
            ProjectCustomAttributeTypeID = projectCustomAttribute.ProjectCustomAttributeTypeID;
            ProjectCustomAttributeGroupID = projectCustomAttribute.ProjectCustomAttributeType.ProjectCustomAttributeGroupID;
            ProjectCustomAttributeValues = projectCustomAttribute.GetCustomAttributeValues()
                .Select(y =>
                    y.GetIProjectCustomAttribute().ProjectCustomAttributeType.ProjectCustomAttributeDataType ==
                    ProjectCustomAttributeDataType.DateTime
                        ? DateTime.Parse(y.AttributeValue).ToShortDateString()
                        : y.AttributeValue)
                .ToList();
        }

        /// <summary>
        /// Empty Constructor
        /// </summary>
        public ProjectCustomAttributeSimple()
        {
            ProjectCustomAttributeValues = new List<string>();
        }
    }
}
