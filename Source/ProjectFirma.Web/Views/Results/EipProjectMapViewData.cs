using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;

namespace ProjectFirma.Web.Views.Results
{
    public class EipProjectMapViewData : FirmaViewData
    {
        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;

        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>> ProjectLocationFilterTypesAndValues;
        public readonly string ProjectLocationsUrl;
        public readonly string FilteredProjectsWithLocationAreasUrl;

        public EipProjectMapViewData(Person currentPerson,
            Models.FirmaPage firmaPage,
            ProjectLocationsMapInitJson projectLocationsMapInitJson,
            ProjectLocationsMapViewData projectLocationsMapViewData,
            Dictionary<ProjectLocationFilterType, IEnumerable<SelectListItem>> projectLocationFilterTypesAndValues,
            string projectLocationsUrl,
            string filteredProjectsWithLocationAreasUrl) : base(currentPerson, firmaPage)
        {
            PageTitle = "EIP Project Map";
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            ProjectLocationFilterTypesAndValues = projectLocationFilterTypesAndValues;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsUrl = projectLocationsUrl;
            FilteredProjectsWithLocationAreasUrl = filteredProjectsWithLocationAreasUrl;
        }
    }
}