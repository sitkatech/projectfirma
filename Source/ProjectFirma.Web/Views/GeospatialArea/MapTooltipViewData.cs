using System.Web;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.GeospatialArea
{
    public class MapTooltipViewData : FirmaViewData
    {
        public readonly ProjectFirmaModels.Models.GeospatialArea GeospatialArea;
        public readonly HtmlString GeospatialAreaDetailLink;

        public MapTooltipViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.GeospatialArea geospatialArea) : base(currentFirmaSession)
        {
            GeospatialArea = geospatialArea;
            GeospatialAreaDetailLink = SitkaRoute<GeospatialAreaController>
                .BuildLinkFromExpression(c => c.Detail(GeospatialArea), GeospatialArea.GetDisplayName()).ToHTMLFormattedString();
        }
    }
}
