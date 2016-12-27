using System.Collections.Generic;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared.ProjectLocationControls
{
    public class ProjectMapLegendElement
    {
        public readonly int LegendID;
        public readonly string LegendColor;
        public readonly string LegendText;

        public ProjectMapLegendElement(int legendID, string legendColor, string legendText)
        {
            LegendID = legendID;
            LegendColor = legendColor;
            LegendText = legendText;
        }

        public static Dictionary<string, List<ProjectMapLegendElement>> BuildLegendFormatDictionary()
        {
            var taxonomyTierThrees = HttpRequestStorage.DatabaseEntities.TaxonomyTierThrees.ToList(); //TODO: May not be best practice to hit database here?
            var legendFormats = new Dictionary<string, List<ProjectMapLegendElement>>
            {
                {
                    ProjectColorByType.ProjectStage.ProjectColorByTypeNameWithIdentifier,
                    ProjectStage.All.Where(x => x.ShouldShowOnMap()).OrderBy(x => x.SortOrder).Select(x => new ProjectMapLegendElement(x.ProjectStageID, x.ProjectStageColor, x.ProjectStageDisplayName)).ToList()
                },
                {
                    ProjectColorByType.TaxonomyTierThree.ProjectColorByTypeNameWithIdentifier,
                    taxonomyTierThrees.Select(x => new ProjectMapLegendElement(x.TaxonomyTierThreeID, x.TaxonomyTierThreeColor, x.TaxonomyTierThreeName)).ToList()
                }
            };

            return legendFormats;
        }
    }
}