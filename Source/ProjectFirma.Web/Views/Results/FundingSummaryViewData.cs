/*-----------------------------------------------------------------------
<copyright file="FundingSummaryViewData.cs" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/

using System;
using System.Linq;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class FundingSummaryViewData : FirmaUserControlViewData
    {
        public decimal TotalAwarded { get; }
        public decimal TotalMatched { get; }
        public decimal TotalInvestment { get; }

        public FundingSummaryViewData()
        {
            var fundingSourceCustomAttributeDictionary = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributes
                .GroupBy(x => x.FundingSourceID)
                .ToDictionary(x => x.Key, y => y.ToList());
            var fundingSourceCustomAttributeValueDictionary = HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeValues
                .GroupBy(x => x.FundingSourceCustomAttributeID)
                .ToDictionary(x => x.Key, y => y.ToList());


            // NCRP Award custom attribute
            var fundingSourceCustomAttributeType =
                HttpRequestStorage.DatabaseEntities.FundingSourceCustomAttributeTypes.SingleOrDefault(x =>
                    x.FundingSourceCustomAttributeTypeName.Equals("NCRP Award"));

            if (fundingSourceCustomAttributeType != null)
            {
                var fundingSources = HttpRequestStorage.DatabaseEntities.FundingSources.ToList();

                var awardFundingSourceIDs = fundingSources.Where(x =>
                    x.GetFundingSourceCustomAttributesValue(fundingSourceCustomAttributeType,
                        fundingSourceCustomAttributeDictionary, fundingSourceCustomAttributeValueDictionary).Equals("Yes")).Select(x => x.FundingSourceID).ToList();

                var matchedFundingSourceIDs = fundingSources.Where(x =>
                    x.GetFundingSourceCustomAttributesValue(fundingSourceCustomAttributeType,
                        fundingSourceCustomAttributeDictionary, fundingSourceCustomAttributeValueDictionary).Equals("No")).Select(x => x.FundingSourceID).ToList();

                var projects = HttpRequestStorage.DatabaseEntities.Projects.ToList();

                TotalAwarded = Math.Round(projects.Sum(x => x.GetSecuredFundingForFundingSources(awardFundingSourceIDs) ?? 0));
                TotalMatched = Math.Round(projects.Sum(x => x.GetSecuredFundingForFundingSources(matchedFundingSourceIDs) ?? 0));
                TotalInvestment = TotalAwarded + TotalMatched;
            }

        }
    }
}