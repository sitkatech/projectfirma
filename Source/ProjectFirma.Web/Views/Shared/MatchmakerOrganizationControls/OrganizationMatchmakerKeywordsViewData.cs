/*-----------------------------------------------------------------------
<copyright file="ProjectBasicsTagsViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using Newtonsoft.Json;

namespace ProjectFirma.Web.Views.Shared.MatchmakerOrganizationControls
{

    public class OrganizationMatchmakerKeywordJson
    {
        [JsonProperty(PropertyName = "keywords")]
        public List<string> Keywords { get; set; }

        public OrganizationMatchmakerKeywordJson(ProjectFirmaModels.Models.Organization organization)
        {
            Keywords = organization.OrganizationMatchmakerKeywords.Select(omk => omk.MatchmakerKeyword.MatchmakerKeywordName).ToList();
        }
    }


    public class OrganizationMatchmakerKeywordsViewData
    {
        public const string EditMatchmakerKeywordDialogFormID = "EditMatchmakerKeywordDialogFormID";

        public readonly ProjectFirmaModels.Models.Organization Organization;
        public readonly MatchmakerKeywordHelper MatchmakerKeywordHelper;
        public List<string> KeywordStrings;

        public OrganizationMatchmakerKeywordsViewData(ProjectFirmaModels.Models.Organization organization)
        {
            Organization = organization;
            MatchmakerKeywordHelper = new MatchmakerKeywordHelper(organization.OrganizationMatchmakerKeywords.Select(x => new BootstrapOrganizationMatchmakerKeyword(x.MatchmakerKeyword)).ToList());
            KeywordStrings = organization.OrganizationMatchmakerKeywords.Select(omk => omk.MatchmakerKeyword.MatchmakerKeywordName).OrderBy(k => k).ToList();
        }

        public string GetMatchmakerKeywordsAsJson()
        {
            List<string> matchmakerKeywordStrings = Organization.OrganizationMatchmakerKeywords.Select(mmk => mmk.MatchmakerKeyword.MatchmakerKeywordName).ToList();
            string matchmakerKeywordStringsAsJson = JsonConvert.SerializeObject(matchmakerKeywordStrings);
            return matchmakerKeywordStringsAsJson;
        }
    }

}
