//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaStateProvince]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectLocationAreaStateProvince GetProjectLocationAreaStateProvince(this IQueryable<ProjectLocationAreaStateProvince> projectLocationAreaStateProvinces, int projectLocationAreaStateProvinceID)
        {
            var projectLocationAreaStateProvince = projectLocationAreaStateProvinces.SingleOrDefault(x => x.ProjectLocationAreaStateProvinceID == projectLocationAreaStateProvinceID);
            Check.RequireNotNullThrowNotFound(projectLocationAreaStateProvince, "ProjectLocationAreaStateProvince", projectLocationAreaStateProvinceID);
            return projectLocationAreaStateProvince;
        }

        public static void DeleteProjectLocationAreaStateProvince(this List<int> projectLocationAreaStateProvinceIDList)
        {
            if(projectLocationAreaStateProvinceIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationAreaStateProvinces.RemoveRange(HttpRequestStorage.DatabaseEntities.ProjectLocationAreaStateProvinces.Where(x => projectLocationAreaStateProvinceIDList.Contains(x.ProjectLocationAreaStateProvinceID)));
            }
        }

        public static void DeleteProjectLocationAreaStateProvince(this ICollection<ProjectLocationAreaStateProvince> projectLocationAreaStateProvincesToDelete)
        {
            if(projectLocationAreaStateProvincesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllProjectLocationAreaStateProvinces.RemoveRange(projectLocationAreaStateProvincesToDelete);
            }
        }

        public static void DeleteProjectLocationAreaStateProvince(this int projectLocationAreaStateProvinceID)
        {
            DeleteProjectLocationAreaStateProvince(new List<int> { projectLocationAreaStateProvinceID });
        }

        public static void DeleteProjectLocationAreaStateProvince(this ProjectLocationAreaStateProvince projectLocationAreaStateProvinceToDelete)
        {
            DeleteProjectLocationAreaStateProvince(new List<ProjectLocationAreaStateProvince> { projectLocationAreaStateProvinceToDelete });
        }
    }
}