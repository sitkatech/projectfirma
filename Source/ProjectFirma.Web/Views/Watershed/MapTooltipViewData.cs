using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Watershed
{
    public class MapTooltipViewData : FirmaViewData
    {
        public readonly Models.Watershed Watershed;
        public readonly HtmlString WatershedDetailLink;

        public MapTooltipViewData(Person currentPerson, Models.Watershed watershed) : base(currentPerson)
        {
            Watershed = watershed;
            WatershedDetailLink = SitkaRoute<WatershedController>
                .BuildLinkFromExpression(c => c.Detail(Watershed), Watershed.DisplayName).ToHTMLFormattedString();
        }
    }
}
