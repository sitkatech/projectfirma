using System.Collections.Generic;
using ProjectFirma.Web.Views;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectLocationsMapViewData : LakeTahoeInfoUserControlViewData
    {        
        public readonly string MapDivID;
        public readonly string LegendTitle;
        public readonly Dictionary<string, List<ProjectMapLegendElement>> LegendFormats;

        public ProjectLocationsMapViewData(string mapDivID, string legendTitle)
        {
            MapDivID = mapDivID;
            LegendTitle = legendTitle;
            LegendFormats = ProjectMapLegendElement.BuildLegendFormatDictionary();
        }

        public ProjectLocationsMapViewData(string mapDivID)
            : this(mapDivID, "Legend")
        {
            
        }
    }
}