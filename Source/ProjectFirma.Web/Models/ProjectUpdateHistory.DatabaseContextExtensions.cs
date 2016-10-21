using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectUpdateHistory GetLatestProjectUpdateHistory(this IEnumerable<ProjectUpdateHistory> projectUpdateHistories)
        {
            return projectUpdateHistories.OrderByDescending(x => x.TransitionDate).FirstOrDefault();
        }

        public static ProjectUpdateHistory GetLatestProjectUpdateHistory(this IEnumerable<ProjectUpdateHistory> projectUpdateHistories, ProjectUpdateState projectUpdateState)
        {
            return projectUpdateHistories.OrderByDescending(x => x.TransitionDate).FirstOrDefault(x => x.ProjectUpdateState == projectUpdateState);
        }
    }
}