/*-----------------------------------------------------------------------
<copyright file="WebServiceOrganization.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;
using LtInfo.Common.DhtmlWrappers;
using LtInfo.Common.Models;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Service.ServiceModels
{
    [DataContract]
    public class WebServiceOrganization : SimpleModelObject
    {
        public WebServiceOrganization(Organization organization)
        {
            OrganizationID = organization.OrganizationID;
            OrganizationName = organization.OrganizationName;
            OrganizationShortName = organization.OrganizationShortName;
            OrganizationType = organization.OrganizationType?.OrganizationTypeName;
            PrimaryContact = organization.GetPrimaryContactPersonAsString();
            ProjectCount = organization.GetAllActiveProjectsAndProposals(null).Count;
            FundingSourceCount = organization.FundingSources.Count;
            UserCount = organization.People.Count;
            OrganizationSummaryUrl = organization.GetDetailUrl();
        }    

        [DataMember] public int OrganizationID { get; set; }
        [DataMember] public string OrganizationName { get; set; }
        [DataMember] public string OrganizationShortName { get; set; }
        [DataMember] public string OrganizationType { get; set; }
        
        [DataMember] public string PrimaryContact { get; set; }
        [DataMember] public int ProjectCount { get; set; }
        [DataMember] public int FundingSourceCount { get; set; }
        [DataMember] public int UserCount { get; set; }

        [DataMember] public string OrganizationSummaryUrl { get; set; }

        public static List<WebServiceOrganization> GetOrganizations()
        {
            var organizations = HttpRequestStorage.DatabaseEntities.Organizations.GetActiveOrganizations();
            return organizations.Select(x => new WebServiceOrganization(x)).OrderBy(x => x.OrganizationName).ToList();
        }
    }

    public class WebServiceOrganizationGridSpec : GridSpec<WebServiceOrganization>
    {
        public WebServiceOrganizationGridSpec()
        {
            Add("OrganizationID", a => a.OrganizationID, 0);
            Add("Organization", a => a.OrganizationName, 0);
            Add("OrganizationShortName", a => a.OrganizationShortName, 0);
            Add("OrganizationType", a => a.OrganizationType, 0);
            Add("PrimaryContact", a => a.PrimaryContact, 0);
            Add("NumberOfProjects", a => a.ProjectCount, 0);
            Add("NumberOfFundingSources", a => a.FundingSourceCount, 0);
            Add("NumberOfUsers", a => a.UserCount, 0);
            Add("OrganizationSummaryUrl", x => x.OrganizationSummaryUrl, 0);
        }
    }
}
