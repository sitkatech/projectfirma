//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectLocationAreaStateProvince]
using System.Collections.Generic;
using System.Linq;
using Z.EntityFramework.Plus;
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

        public static void DeleteProjectLocationAreaStateProvince(this IQueryable<ProjectLocationAreaStateProvince> projectLocationAreaStateProvinces, List<int> projectLocationAreaStateProvinceIDList)
        {
            if(projectLocationAreaStateProvinceIDList.Any())
            {
                projectLocationAreaStateProvinces.Where(x => projectLocationAreaStateProvinceIDList.Contains(x.ProjectLocationAreaStateProvinceID)).Delete();
            }
        }

        public static void DeleteProjectLocationAreaStateProvince(this IQueryable<ProjectLocationAreaStateProvince> projectLocationAreaStateProvinces, ICollection<ProjectLocationAreaStateProvince> projectLocationAreaStateProvincesToDelete)
        {
            if(projectLocationAreaStateProvincesToDelete.Any())
            {
                var projectLocationAreaStateProvinceIDList = projectLocationAreaStateProvincesToDelete.Select(x => x.ProjectLocationAreaStateProvinceID).ToList();
                projectLocationAreaStateProvinces.Where(x => projectLocationAreaStateProvinceIDList.Contains(x.ProjectLocationAreaStateProvinceID)).Delete();
            }
        }

        public static void DeleteProjectLocationAreaStateProvince(this IQueryable<ProjectLocationAreaStateProvince> projectLocationAreaStateProvinces, int projectLocationAreaStateProvinceID)
        {
            DeleteProjectLocationAreaStateProvince(projectLocationAreaStateProvinces, new List<int> { projectLocationAreaStateProvinceID });
        }

        public static void DeleteProjectLocationAreaStateProvince(this IQueryable<ProjectLocationAreaStateProvince> projectLocationAreaStateProvinces, ProjectLocationAreaStateProvince projectLocationAreaStateProvinceToDelete)
        {
            DeleteProjectLocationAreaStateProvince(projectLocationAreaStateProvinces, new List<ProjectLocationAreaStateProvince> { projectLocationAreaStateProvinceToDelete });
        }
    }
}