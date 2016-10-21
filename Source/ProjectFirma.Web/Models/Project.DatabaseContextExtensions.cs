using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static List<Project> GetProjectsWithGeoSpatialProperties(this IQueryable<Project> projects,
            List<Watershed> watersheds,
            List<Jurisdiction> jurisdictions,
            Func<Project, bool> filterFunction,
            List<StateProvince> stateProvinces)
        {
            var projectLocationAreas =
                HttpRequestStorage.DatabaseEntities.ProjectLocationAreas.Include(x => x.ProjectLocationAreaJurisdictions.Select(y => y.Jurisdiction))
                    .Include(x => x.ProjectLocationAreaWatersheds.Select(y => y.Watershed))
                    .Include(x => x.ProjectLocationAreaStateProvinces.Select(y => y.StateProvince))
                    .ToDictionary(x => x.ProjectLocationAreaID);

            var projectsList = projects.Include(x => x.ProjectImplementingOrganizations.Select(y => y.Organization)).Include(x => x.ProjectFundingSourceExpenditures).ToList();
            if (filterFunction != null)
            {
                projectsList = projectsList.Where(filterFunction).ToList();
            }
            projectsList.ForEach(x =>
            {
                x.SetProjectJurisdiction(jurisdictions, projectLocationAreas);
                x.SetProjectLocationStateProvince(stateProvinces, projectLocationAreas);
                x.SetProjectLocationWatershed(watersheds, projectLocationAreas);
            });
            return projectsList.OrderBy(x => x.ProjectNumberString).ToList();
        }

        public static List<Project> GetUpdatableProjectsThatHaveNotBeenSubmitted(this IQueryable<Project> projects)
        {
            return projects.ToList().GetUpdatableProjectsThatHaveNotBeenSubmitted();
        }

        public static List<Project> GetUpdatableProjectsThatHaveNotBeenSubmitted(this IList<Project> projects)
        {
            return projects.Where(x => x.IsUpdateMandatory && x.GetLatestUpdateState() != ProjectUpdateState.Submitted).ToList();
        }

        public static List<Person> GetPrimaryContactPeople(this IList<Project> projects)
        {
            return projects.Where(x => x.PrimaryContactPerson != null).Select(x => x.PrimaryContactPerson).Distinct(new HavePrimaryKeyComparer<Person>()).ToList();
        }

        public static Project GetProjectByProjectNumber(this IQueryable<Project> projects, string projectNumber)
        {
            return GetProjectByProjectNumber(projects, projectNumber, true);
        }

        public static Project GetProjectByProjectNumber(this IQueryable<Project> projects, string projectNumber, bool requireRecordFound)
        {
            var project = projects.ToList().SingleOrDefault(x => x.ProjectNumberString.Equals(projectNumber, StringComparison.InvariantCultureIgnoreCase));
            if (requireRecordFound)
            {
                Check.RequireNotNullThrowNotFound(project, projectNumber);
            }
            return project;
        }
    }
}