using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TransportationObjective : IAuditableEntity
    {
        public string DisplayName
        {
            get { return TransportationObjectiveName; }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(x => x.Summary(TransportationObjectiveID)); }
        }

        public string CustomizedMapUrl
        {
            get
            {
                return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TransportationObjective, TransportationObjectiveID.ToString(), ProjectColorByType.ProjectStage);
            }
        }


        public string DeleteUrl
        {
            get { return SitkaRoute<TransportationObjectiveController>.BuildUrlFromExpression(c => c.DeleteTransportationObjective(TransportationObjectiveID)); }
        }

        public static bool IsTransportationObjectiveNameUnique(IEnumerable<TransportationObjective> transportationObjectives, string transportationObjectiveName, int currentTransportationObjectiveID)
        {
            var transportationObjective =
                transportationObjectives.SingleOrDefault(
                    x =>
                        x.TransportationObjectiveID != currentTransportationObjectiveID &&
                        string.Equals(x.TransportationObjectiveName, transportationObjectiveName, StringComparison.InvariantCultureIgnoreCase));
            return transportationObjective == null;
        }

        public string AuditDescriptionString
        {
            get { return TransportationObjectiveName; }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(UrlTemplate.MakeHrefString(SummaryUrl, TransportationObjectiveName), TransportationObjectiveID.ToString(), false)
            {
                ThemeColor = TransportationStrategy.TransportationStrategyColor,
                MapUrl = CustomizedMapUrl,
                Children = Projects.Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}