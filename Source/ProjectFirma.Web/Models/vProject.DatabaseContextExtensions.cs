using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<vProject> GetProjectFindResultsForProjectNameAndDescriptionAndNumber(this IQueryable<vProject> projects, string projectKeyword)
        {
            return
                projects.Where(x => x.ProjectName.Contains(projectKeyword) || x.ProjectDescription.Contains(projectKeyword) || x.ProjectNumberFull.StartsWith(projectKeyword))
                    .OrderBy(x => x.ProjectNumberFull)
                    .ToList();
        }
    }
}