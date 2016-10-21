using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<ProposedProject> GetProposedProjectsWithGeoSpatialProperties(this IQueryable<ProposedProject> proposedProjects,
            List<Watershed> watersheds,
            List<Jurisdiction> jurisdictions,
            List<StateProvince> stateProvinces,
            Func<ProposedProject, bool> filterFunction)
        {
            var projectsList = proposedProjects.ToList();
            if (filterFunction != null)
            {
                projectsList = projectsList.Where(filterFunction).ToList();
            }
            projectsList.ForEach(x =>
            {
                x.SetProjectLocationJurisdiction(jurisdictions);
                x.SetProjectLocationStateProvince(stateProvinces);
                x.SetProjectLocationWatershed(watersheds);
            });
            return projectsList.OrderBy(x => x.DisplayName).ToList();
        }
    }
}