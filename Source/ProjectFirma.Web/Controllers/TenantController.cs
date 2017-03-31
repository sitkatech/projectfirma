/*-----------------------------------------------------------------------
<copyright file="TenantController.cs" company="Tahoe Regional Planning Agency">
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
using System.Collections.Generic;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security;
using ProjectFirma.Web.Views.Tenant;

namespace ProjectFirma.Web.Controllers
{
    public class TenantController : FirmaBaseController
    {
        [SitkaAdminFeature]
        public ViewResult Index()
        {
            var viewData = new IndexViewData(CurrentPerson);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [SitkaAdminFeature]
        public GridJsonNetJObjectResult<Tenant> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            List<Tenant> tenants = new List<Tenant>();
            return new GridJsonNetJObjectResult<Tenant>(tenants, gridSpec);
        }

        [SitkaAdminFeature]
        public ViewResult Detail(TenantPrimaryKey tenantPrimaryKey)
        {
            var tenant = tenantPrimaryKey.EntityObject;
            var viewData = new DetailViewData(CurrentPerson, tenant);

            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public ViewResult Edit(TenantPrimaryKey tenantPrimaryKey)
        {
            var tenant = tenantPrimaryKey.EntityObject;
            var viewModel = new EditViewModel(tenant);
            return ViewEdit(viewModel, tenant);
        }

        [HttpPost]
        [SitkaAdminFeature]
        public ActionResult Edit(TenantPrimaryKey tenantPrimaryKey, EditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var tenant = tenantPrimaryKey.EntityObject;
                return ViewEdit(viewModel, tenant);
            }

            viewModel.UpdateModel();
            return Redirect(new SitkaRoute<TenantController>(c => c.Detail(tenantPrimaryKey)).BuildUrlFromExpression());
        }

        private ViewResult ViewEdit(EditViewModel viewModel, Tenant tenant)
        {
            var viewData = new EditViewData(CurrentPerson);
            return RazorView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }
    }
}
