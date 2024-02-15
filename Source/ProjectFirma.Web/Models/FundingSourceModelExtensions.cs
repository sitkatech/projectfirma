﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;
using ProjectFirma.Web.Views.PerformanceMeasure;
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

        public static List<Project> GetAssociatedProjects(this FundingSource fundingSource, FirmaSession firmaSession)
        {
            return GetAssociatedProjects(fundingSource, firmaSession, fundingSource.ProjectFundingSourceExpenditures.ToList());
        }

        public static List<Project> GetAssociatedProjects(this FundingSource fundingSource, FirmaSession firmaSession, List<ProjectFundingSourceExpenditure> projectFundingSourceExpenditures)
        {
            return projectFundingSourceExpenditures.Select(x => x.Project).ToList().GetActiveProjectsAndProposals(firmaSession.CanViewProposals(), firmaSession);
        }

        public static List<Project> GetAssociatedProjectsWithSecuredFunding(this FundingSource fundingSource, FirmaSession firmasession, List<ProjectFundingSourceBudget> projectFundingSourceBudgets, Dictionary<int,Project> projectDictionary)
        {
            return projectFundingSourceBudgets.Where(x => x.SecuredAmount > 0).Select(x => projectDictionary[x.ProjectID]).ToList().GetActiveProjectsAndProposals(firmasession.CanViewProposals(), firmasession);
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
            return organizationShortNameIfAvailable.Length < 35
                ? $"{fundingSource.FundingSourceName.ToEllipsifiedString(35 - organizationShortNameIfAvailable.Length)} {organizationShortNameIfAvailable}"
                : $"{organizationShortNameIfAvailable}";
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

        public static string GetFundingSourceCustomAttributesValue(this FundingSource fundingSource
            , FundingSourceCustomAttributeType fundingSourceCustomAttributeType
            , Dictionary<int,List<FundingSourceCustomAttribute>> fundingSourceCustomAttributeDictionary
            , Dictionary<int,List<FundingSourceCustomAttributeValue>> fundingSourceCustomAttributeValueDictionary)
        {
            var fundingSourceCustomAttributesList =
                fundingSourceCustomAttributeDictionary.ContainsKey(fundingSource.FundingSourceID)
                    ? fundingSourceCustomAttributeDictionary[fundingSource.FundingSourceID]
                    : new List<FundingSourceCustomAttribute>();
            var fundingSourceCustomAttribute = fundingSourceCustomAttributesList.SingleOrDefault(x => x.FundingSourceCustomAttributeTypeID == fundingSourceCustomAttributeType.FundingSourceCustomAttributeTypeID);
            if (fundingSourceCustomAttribute != null)
            {
                var fundingSourceCustomAttributeValues =
                    fundingSourceCustomAttributeValueDictionary.ContainsKey(fundingSourceCustomAttribute
                        .FundingSourceCustomAttributeID)
                        ? fundingSourceCustomAttributeValueDictionary[
                            fundingSourceCustomAttribute.FundingSourceCustomAttributeID]
                        : new List<FundingSourceCustomAttributeValue>();

                if (fundingSourceCustomAttributeType.FundingSourceCustomAttributeDataType == FundingSourceCustomAttributeDataType.DateTime)
                {
                    return DateTime.TryParse(fundingSourceCustomAttributeValues.Single().AttributeValue, out var date) ? date.ToShortDateString() : null;
                }
                else
                {
                    return string.Join(", ",
                        fundingSourceCustomAttributeValues.Select(x => x.AttributeValue));
                }
            }
            else
            {
                return "None";
            }
        }

        public static PerformanceMeasureChartViewData GetPerformanceMeasureChartViewData(this FundingSource fundingSource,
            PerformanceMeasure performanceMeasure,
            FirmaSession firmaSession)
        {
            var projects = fundingSource.GetAssociatedProjects(firmaSession).ToList();
            return new PerformanceMeasureChartViewData(performanceMeasure, firmaSession, false, projects, false);
        }
    }
}