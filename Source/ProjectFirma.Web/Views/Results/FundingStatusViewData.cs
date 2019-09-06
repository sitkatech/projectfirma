/*-----------------------------------------------------------------------
<copyright file="FundingStatusViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
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
using ProjectFirma.Web.Views.Shared;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Views.Results
{
    public class FundingStatusViewData : FirmaViewData
    {
        public ViewPageContentViewData FundingStatusFooterViewPageContentViewData { get; }
        public readonly ViewGoogleChartViewData SummaryViewGoogleChartViewData;
        public readonly ViewGoogleChartViewData StatusByOwnerOrgTypeViewGoogleChartViewData;

        public FundingStatusViewData(Person currentPerson, ProjectFirmaModels.Models.FirmaPage firmaPage, ProjectFirmaModels.Models.FirmaPage fundingStatusFooter, GoogleChartJson summaryGoogleChart, GoogleChartJson orgTypeGoogleChart) : base(currentPerson, firmaPage)
        {
            FundingStatusFooterViewPageContentViewData = new ViewPageContentViewData(fundingStatusFooter, currentPerson);
            SummaryViewGoogleChartViewData = new ViewGoogleChartViewData(summaryGoogleChart, summaryGoogleChart.GoogleChartConfiguration.Title, 350, true, true);
            StatusByOwnerOrgTypeViewGoogleChartViewData = new ViewGoogleChartViewData(orgTypeGoogleChart, orgTypeGoogleChart.GoogleChartConfiguration.Title, 400, true);
        }
    }
}