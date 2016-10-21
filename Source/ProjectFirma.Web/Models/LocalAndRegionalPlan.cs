using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;

namespace ProjectFirma.Web.Models
{
    public partial class LocalAndRegionalPlan : IAuditableEntity
    {
        public string DeleteUrl
        {
            get { return SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(t => t.DeleteLocalAndRegionalPlan(LocalAndRegionalPlanID)); }
        }

        public string EditUrl
        {
            get { return SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(t => t.Edit(LocalAndRegionalPlanID)); }
        }

        public HtmlString DisplayNameAsUrl
        {
            get { return UrlTemplate.MakeHrefString(SummaryUrl, DisplayName); }
        }

        public string DisplayName
        {
            get { return LocalAndRegionalPlanName; }
        }

        public string SummaryUrl
        {
            get { return SitkaRoute<LocalAndRegionalPlanController>.BuildUrlFromExpression(x => x.Summary(LocalAndRegionalPlanID)); }
        }

        public List<Project> AssociatedProjects
        {
            get { return ProjectLocalAndRegionalPlans.Select(ptc => ptc.Project).Distinct().ToList(); }
        }

        public static bool IsLocalAndRegionalPlanNameUnique(IEnumerable<LocalAndRegionalPlan> localAndRegionalPlans, string localAndRegionalPlanName, int currentLocalAndRegionalPlanID)
        {
            var localAndRegionalPlan =
                localAndRegionalPlans.SingleOrDefault(
                    x => x.LocalAndRegionalPlanID != currentLocalAndRegionalPlanID && String.Equals(x.LocalAndRegionalPlanName, localAndRegionalPlanName, StringComparison.InvariantCultureIgnoreCase));
            return localAndRegionalPlan == null;
        }

        public string AuditDescriptionString
        {
            get { return LocalAndRegionalPlanName; }
        }
    }
}