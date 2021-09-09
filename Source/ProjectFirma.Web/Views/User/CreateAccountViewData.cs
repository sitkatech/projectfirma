/*-----------------------------------------------------------------------
<copyright file="CreateAccountViewData.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Web;
using System.Web.Mvc;
using LtInfo.Common.ModalDialog;
using LtInfo.Common.Mvc;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Controllers;

namespace ProjectFirma.Web.Views.User
{
    public class CreateAccountViewData : FirmaViewData
    {
        public IEnumerable<SelectListItem> OrganizationsSelectList { get; }
        public string CancelUrl { get; }
        public string IndexUrl { get; }

        public CreateAccountViewData(FirmaSession currentFirmaSession, ProjectFirmaModels.Models.FirmaPage psInfoPage) : base(currentFirmaSession, psInfoPage)
        {
            PageTitle = "Create Account";
            EntityName = "Users";

            CancelUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.Index());
            IndexUrl = SitkaRoute<UserController>.BuildUrlFromExpression(x => x.Index());

            var allOrganizations = HttpRequestStorage.DatabaseEntities.Organizations.ToList().OrderBy(x => x.OrganizationName).ToList();
            OrganizationsSelectList = allOrganizations.ToSelectList(x => x.OrganizationID.ToString(), x => x.OrganizationName);
        }



    }
}
