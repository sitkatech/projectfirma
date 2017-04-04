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
using System.Linq;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.MvcResults;
using ProjectFirma.Web.Common;
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
            var gridSpec = new IndexGridSpec
            {
                ObjectNameSingular = "Tenant",
                ObjectNamePlural = "Tenants",
                SaveFiltersInCookie = true
            };
            var gridName = "Tenants";
            var gridDataUrl = new SitkaRoute<TenantController>(c => c.IndexGridJsonData()).BuildUrlFromExpression();
            var viewData = new IndexViewData(CurrentPerson, gridSpec, gridName, gridDataUrl);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [SitkaAdminFeature]
        public GridJsonNetJObjectResult<Tenant> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            var tenants = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.ToList().Select(a => a.Tenant).ToList();
            return new GridJsonNetJObjectResult<Tenant>(tenants, gridSpec);
        }

        [SitkaAdminFeature]
        public ViewResult Detail(TenantPrimaryKey tenantPrimaryKey)
        {
            var tenant = tenantPrimaryKey.EntityObject;
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == tenant.TenantID);
            var indexUrl = new SitkaRoute<TenantController>(c => c.Index()).BuildUrlFromExpression();
            var editUrl = new SitkaRoute<TenantController>(c => c.Edit(tenantPrimaryKey)).BuildUrlFromExpression();
            var primaryContactLink = "primary contact link"; // TODO: will add once edit is in place and I know how to access primary contact
            var viewData = new DetailViewData(CurrentPerson, tenant, tenantAttribute, indexUrl, editUrl, primaryContactLink);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult Edit(TenantPrimaryKey tenantPrimaryKey)
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

        private PartialViewResult ViewEdit(EditViewModel viewModel, Tenant tenant)
        {
            var viewData = new EditViewData(CurrentPerson);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }
    }
}
