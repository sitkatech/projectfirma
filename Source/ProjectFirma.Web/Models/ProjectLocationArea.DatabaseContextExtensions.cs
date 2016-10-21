using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common.Mvc;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectList(this IQueryable<ProjectLocationArea> projectLocationAreas)
        {
            return projectLocationAreas.ToList()
                    .OrderBy(x => x.ProjectLocationAreaGroup.ProjectLocationAreaGroupType.DisplayOrder)
                    .ThenBy(x => x.ProjectLocationAreaDisplayName)
                    .ToSelectListWithGroups(x => x.ProjectLocationAreaID.ToString(), x => x.ProjectLocationAreaDisplayName, x => x.ProjectLocationAreaGroup.ProjectLocationAreaGroupType.ProjectLocationAreaGroupTypeDisplayName);
        }
    }
}