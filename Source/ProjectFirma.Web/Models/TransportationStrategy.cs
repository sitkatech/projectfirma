using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Areas.EIP.Controllers;
using ProjectFirma.Web.Areas.EIP.Views.Shared.ProjectLocationControls;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class TransportationStrategy : IAuditableEntity
    {
        public string DisplayName
        {
            get { return TransportationStrategyName; }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(x => x.Summary(TransportationStrategyID)); }
        }

        public string CustomizedMapUrl
        {
            get { return ProjectMapCustomization.BuildCustomizedUrl(ProjectLocationFilterType.TransportationStrategy, TransportationStrategyID.ToString(), ProjectColorByType.ProjectStage); }
        }


        public string DeleteUrl
        {
            get { return SitkaRoute<TransportationStrategyController>.BuildUrlFromExpression(c => c.DeleteTransportationStrategy(TransportationStrategyID)); }
        }

        public static bool IsTransportationStrategyNameUnique(IEnumerable<TransportationStrategy> transportationStrategies, string transportationStrategyName, int currentTransportationStrategyID)
        {
            var actionPriority =
                transportationStrategies.SingleOrDefault(
                    x =>
                        x.TransportationStrategyID != currentTransportationStrategyID &&
                        string.Equals(x.TransportationStrategyName, transportationStrategyName, StringComparison.InvariantCultureIgnoreCase));
            return actionPriority == null;
        }

        public ICollection<Project> Projects
        {
            get { return TransportationObjectives.SelectMany(x => x.Projects).ToList(); }
        }

        public string AuditDescriptionString
        {
            get { return TransportationStrategyName; }
        }

        public FancyTreeNode ToFancyTreeNode()
        {
            var fancyTreeNode = new FancyTreeNode(UrlTemplate.MakeHrefString(SummaryUrl, TransportationStrategyName), TransportationStrategyID.ToString(), true)
            {
                ThemeColor = TransportationStrategyColor,
                MapUrl = CustomizedMapUrl,
                Children = TransportationObjectives.Select(x => x.ToFancyTreeNode()).ToList()
            };
            return fancyTreeNode;
        }
    }
}