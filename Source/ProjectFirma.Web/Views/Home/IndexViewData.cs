using System.Collections.Generic;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Views.Map;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Views.Home
{
    public class IndexViewData : EIPViewData
    {
        public readonly bool HasEditPermissions;
        public readonly HtmlString IntroNarrativeContent;
        public readonly HtmlString AdditionalInfoContent;
        public readonly List<Models.Project> FeaturedProjects;
        public readonly ProjectLocationsMapViewData ProjectLocationsMapViewData;
        public readonly ProjectLocationsMapInitJson ProjectLocationsMapInitJson;
        public readonly string FullMapUrl;

        public IndexViewData(Person currentPerson,
            Models.ProjectFirmaPage projectFirmaPage,
            bool hasEditPermissions,
            HtmlString introNarrativeContent,
            HtmlString additionalInfoContent,
            List<Models.Project> featuredProjects,
            ProjectLocationsMapViewData projectLocationsMapViewData,
            ProjectLocationsMapInitJson projectLocationsMapInitJson) : base(currentPerson, projectFirmaPage)
        {
            PageTitle = "Lake Tahoe EIP Project Tracker";

            HasEditPermissions = hasEditPermissions;
            IntroNarrativeContent = introNarrativeContent;
            AdditionalInfoContent = additionalInfoContent;
            FeaturedProjects = featuredProjects;
            ProjectLocationsMapViewData = projectLocationsMapViewData;
            ProjectLocationsMapInitJson = projectLocationsMapInitJson;
            FullMapUrl = SitkaRoute<ResultsController>.BuildUrlFromExpression(x => x.EipProjectMap());
        }
    }
}