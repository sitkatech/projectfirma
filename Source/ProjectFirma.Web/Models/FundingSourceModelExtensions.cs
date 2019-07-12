using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class FundingSourceModelExtensions
    {
        public static string GetEditUrl(this FundingSource fundingSource)
        {
            return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(t => t.Edit(fundingSource.FundingSourceID));
        }

        public static string GetDeleteUrl(this FundingSource fundingSource)
        {
            return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(c => c.DeleteFundingSource(fundingSource.FundingSourceID));
        }

        public static HtmlString GetDisplayNameAsUrl(this FundingSource fundingSource) => UrlTemplate.MakeHrefString(fundingSource.GetDetailUrl(), fundingSource.GetDisplayName());

        public static string GetDetailUrl(this FundingSource fundingSource)
        {
            return SitkaRoute<FundingSourceController>.BuildUrlFromExpression(x => x.Detail(fundingSource.FundingSourceID));
        }

        public static List<Project> GetAssociatedProjects(this FundingSource fundingSource, Person person)
        {
            return fundingSource.ProjectFundingSourceExpenditures.Select(x => x.Project).ToList().GetActiveProjectsAndProposals(person.CanViewProposals());
        }

        public static string GetDisplayName(this FundingSource fundingSource) =>
            $"{fundingSource.FundingSourceName} ({fundingSource.Organization.GetOrganizationShortNameIfAvailable()}){(!fundingSource.IsActive ? " (Inactive)" : string.Empty)}";

        public static string GetFixedLengthDisplayName(this FundingSource fundingSource)
        {
            if (fundingSource.Organization.IsUnknown())
            {
                return fundingSource.Organization.GetOrganizationShortNameIfAvailable();
            }

            var organizationShortNameIfAvailable = $"({fundingSource.Organization.GetOrganizationShortNameIfAvailable()})";
            return organizationShortNameIfAvailable.Length < 45
                ? $"{fundingSource.FundingSourceName.ToEllipsifiedString(45 - organizationShortNameIfAvailable.Length)} {organizationShortNameIfAvailable}"
                : $"{fundingSource.FundingSourceName} {organizationShortNameIfAvailable}";
        }


        public static bool IsFundingSourceNameUnique(IEnumerable<FundingSource> fundingSources, string fundingSourceName, int currentFundingSourceID)
        {
            var fundingSource =
                fundingSources.SingleOrDefault(x => x.FundingSourceID != currentFundingSourceID && String.Equals(x.FundingSourceName, fundingSourceName, StringComparison.InvariantCultureIgnoreCase));
            return fundingSource == null;
        }

        public static int? GetProjectsWhereYouAreTheFundingSourceMinCalendarYear(this FundingSource fundingSource)
        {
            return fundingSource.ProjectFundingSourceExpenditures.Any()
                ? fundingSource.ProjectFundingSourceExpenditures.Min(x => x.CalendarYear)
                : (int?)null;
        }

        public static int? GetProjectsWhereYouAreTheFundingSourceMaxCalendarYear(this FundingSource fundingSource)
        {
            return fundingSource.ProjectFundingSourceExpenditures.Any()
                ? fundingSource.ProjectFundingSourceExpenditures.Max(x => x.CalendarYear)
                : (int?)null;
        }

        public static string GetFundingSourceCustomAttributesValue(this FundingSource fundingSource, FundingSourceCustomAttributeType fundingSourceCustomAttributeType)
        {
            var fundingSourceCustomAttribute = fundingSource.FundingSourceCustomAttributes.SingleOrDefault(x => x.FundingSourceCustomAttributeTypeID == fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID);
            if (fundingSourceCustomAttribute != null)
            {
                if (fundingSourceCustomAttributeType.FundingSourceCustomAttributeDataType == FundingSourceCustomAttributeDataType.DateTime)
                {
                    return DateTime.TryParse(fundingSourceCustomAttribute.GetCustomAttributeValues().Single().AttributeValue, out var date) ? date.ToShortDateString() : null;
                }
                else
                {
                    return string.Join(", ",
                        fundingSourceCustomAttribute.FundingSourceCustomAttributeValues.Select(x => x.AttributeValue));
                }
            }
            else
            {
                return "None";
            }
        }

    }
}