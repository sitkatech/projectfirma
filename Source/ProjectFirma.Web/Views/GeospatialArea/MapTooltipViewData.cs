using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class MapTooltipViewData : FirmaViewData
    {
        public readonly Models.GeospatialArea GeospatialArea;
        public readonly HtmlString GeospatialAreaDetailLink;

        public MapTooltipViewData(Person currentPerson, Models.GeospatialArea geospatialArea) : base(currentPerson)
        {
            GeospatialArea = geospatialArea;
            GeospatialAreaDetailLink = SitkaRoute<GeospatialAreaController>
                .BuildLinkFromExpression(c => c.Detail(GeospatialArea), GeospatialArea.GetDisplayName()).ToHTMLFormattedString();
        }
    }
}
