using System.Collections.Generic;

namespace ProjectFirma.Web.Views.Home
{
    public class FeaturedProjectsViewData : FirmaUserControlViewData
    {
        public readonly List<Models.Project> FeaturedProjects;

        public FeaturedProjectsViewData(List<Models.Project> featureProjects )
        {
            FeaturedProjects = featureProjects;
        }
    }
}