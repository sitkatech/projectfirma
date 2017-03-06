/*-----------------------------------------------------------------------
<copyright file="ProposedProjectGridSpec.cs" company="Tahoe Regional Planning Agency">
Copyright (c) Tahoe Regional Planning Agency. All rights reserved.
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
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.HtmlHelperExtensions;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Views.ProposedProject
{
    public class ProposedProjectGridSpec : GridSpec<Models.ProposedProject>
    {
        public ProposedProjectGridSpec(Person currentPerson)
        {
            //TODO: Need distinct privs here - Admins can always delete and edit, but end user can only delete and edit at certain times. Need to work out rules.
            var userHasDeletePermissions = new ProposedProjectEditFeature().HasPermissionByPerson(currentPerson);
            var userHasEditPermissions = new ProposedProjectEditFeature().HasPermissionByPerson(currentPerson); 

            if (userHasDeletePermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeDeleteIconAndLinkBootstrap(x.GetDeleteUrl(), true, x.CanDelete().HasPermission), 30);
            }
            
            if (userHasEditPermissions)
            {
                Add(string.Empty, x => DhtmlxGridHtmlHelpers.MakeEditIconAsHyperlinkBootstrap(x.GetEditUrl(), userHasEditPermissions), 30);
            }

            Add(Models.FieldDefinition.ProjectName.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.GetDetailUrl(), x.ProjectName), 300, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.TaxonomyTierOneName.ToGridHeaderString(), x => x.TaxonomyTierOne == null ? string.Empty : x.TaxonomyTierOne.DisplayName, 300, DhtmlxGridColumnFilterType.Html);
            Add(Models.FieldDefinition.LeadImplementer.ToGridHeaderString(), x => UrlTemplate.MakeHrefString(x.LeadImplementerOrganization.GetDetailUrl(), x.LeadImplementerOrganization.DisplayName), 175);
            Add(Models.FieldDefinition.PlanningDesignStartYear.ToGridHeaderString(), x => x.PlanningDesignStartYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.ImplementationStartYear.ToGridHeaderString(), x => x.ImplementationStartYear, 115, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.CompletionYear.ToGridHeaderString(), x => x.CompletionYear, 90, DhtmlxGridColumnFormatType.None);
            Add(Models.FieldDefinition.EstimatedTotalCost.ToGridHeaderString(), x => x.EstimatedTotalCost, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.SecuredFunding.ToGridHeaderString(), x => x.SecuredFunding, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add(Models.FieldDefinition.UnfundedNeed.ToGridHeaderString(), x => x.UnfundedNeed, 100, DhtmlxGridColumnFormatType.Currency, DhtmlxGridColumnAggregationType.Total);
            Add("Submittal Status", a => a.ProposedProjectState.ToEnum.ToString(), 80, DhtmlxGridColumnFilterType.SelectFilterStrict);
            Add("Proposed By", a => a.ProposingPerson.GetFullNameFirstLastAndOrgAsUrl(), 200);
            Add("Proposed Date", a => a.ProposingDate, 120);
            Add("Submitted Date", a => a.SubmissionDate, 120);                     
            Add("Last Updated", a => a.LastUpdateDate, 120);
            Add(Models.FieldDefinition.Region.ToGridHeaderString(), a => a.ProjectLocationTypeDisplay, 90, DhtmlxGridColumnFilterType.SelectFilterStrict);
            //Add("State", a => a.ProjectLocationStateProvince, 95, DhtmlxGridColumnFilterType.Text);
            //Add("Jurisdiction", a => a.ProjectLocationJurisdiction, 95, DhtmlxGridColumnFilterType.Text);
            //Add("Watershed", a => a.ProjectLocationWatershed, 95, DhtmlxGridColumnFilterType.Text);
            Add(Models.FieldDefinition.ProjectDescription.ToGridHeaderString(), x => x.ProjectDescription, 300);
        }
    }
}
