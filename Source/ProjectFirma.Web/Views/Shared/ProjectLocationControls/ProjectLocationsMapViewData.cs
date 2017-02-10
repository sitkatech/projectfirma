using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationsMapViewData : FirmaUserControlViewData
    {        
        public readonly string MapDivID;
        public readonly string LegendTitle;
        public readonly Dictionary<string, List<ProjectMapLegendElement>> LegendFormats;

        public ProjectLocationsMapViewData(string mapDivID, string legendTitle, List<Models.TaxonomyTierThree> taxonomyTierThrees)
        {
            MapDivID = mapDivID;
            LegendTitle = legendTitle;
            LegendFormats = ProjectMapLegendElement.BuildLegendFormatDictionary(taxonomyTierThrees);
        }

        public ProjectLocationsMapViewData(string mapDivID)
            : this(mapDivID, "Legend", HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList())
        {
            
        }
    }
}