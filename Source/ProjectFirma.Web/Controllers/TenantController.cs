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
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
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
            var gridSpec = new IndexGridSpec {ObjectNameSingular = "Tenant", ObjectNamePlural = "Tenants", SaveFiltersInCookie = true};
            var gridName = "Tenants";
            var gridDataUrl = new SitkaRoute<TenantController>(c => c.IndexGridJsonData()).BuildUrlFromExpression();
            var viewData = new IndexViewData(CurrentPerson, gridSpec, gridName, gridDataUrl);
            return RazorView<Index, IndexViewData>(viewData);
        }

        [SitkaAdminFeature]
        public GridJsonNetJObjectResult<Tenant> IndexGridJsonData()
        {
            var gridSpec = new IndexGridSpec();
            var tenants = Tenant.All.ToList();
            return new GridJsonNetJObjectResult<Tenant>(tenants, gridSpec);
        }

        [SitkaAdminFeature]
        public ViewResult Detail(TenantPrimaryKey tenantPrimaryKey)
        {
            var tenant = tenantPrimaryKey.EntityObject;
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == tenant.TenantID);
            var indexUrl = new SitkaRoute<TenantController>(c => c.Index()).BuildUrlFromExpression();
            var editUrl = new SitkaRoute<TenantController>(c => c.Edit(tenantPrimaryKey)).BuildUrlFromExpression();
            var viewData = new DetailViewData(CurrentPerson, tenant, tenantAttribute, indexUrl, editUrl);
            return RazorView<Detail, DetailViewData>(viewData);
        }

        [HttpGet]
        [SitkaAdminFeature]
        public PartialViewResult Edit(TenantPrimaryKey tenantPrimaryKey)
        {
            var tenant = tenantPrimaryKey.EntityObject;
            var tenantAttribute = HttpRequestStorage.DatabaseEntities.AllTenantAttributes.Single(a => a.TenantID == tenant.TenantID);
            var viewModel = new EditViewModel(tenant, tenantAttribute);
            return ViewEdit(viewModel, tenant);
        }

        [HttpPost]
        [SitkaAdminFeature]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]//todo need to figure out if there's a way to bypass tenant safe check on saving
        public ActionResult Edit(TenantPrimaryKey tenantPrimaryKey, EditViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var tenant = tenantPrimaryKey.EntityObject;
                return ViewEdit(viewModel, tenant);
            }

            viewModel.UpdateModel(CurrentPerson);
            return new ModalDialogFormJsonResult(new SitkaRoute<TenantController>(c => c.Detail(tenantPrimaryKey)).BuildUrlFromExpression());
        }

        private PartialViewResult ViewEdit(EditViewModel viewModel, Tenant tenant)
        {
            var adminFeature = new AdminFeature();
            var tenantPeople = HttpRequestStorage.DatabaseEntities.AllPeople.Where(x => x.TenantID == tenant.TenantID).ToList().Where(x => adminFeature.HasPermissionByPerson(x)).ToList();
            var viewData = new EditViewData(CurrentPerson, tenantPeople);
            return RazorPartialView<Edit, EditViewData, EditViewModel>(viewData, viewModel);
        }

        [Route("Content/style-{tenantName}.css")]
        public ActionResult Style(string tenantName)
        {
            var tenant = Tenant.All.SingleOrDefault(t => t.TenantName == tenantName);
            if (tenant == default(Tenant))
            {
                return HttpNotFound();
            }

            var tenantAttribute = HttpRequestStorage.DatabaseEntities.TenantAttributes.Single(a => a.TenantID == HttpRequestStorage.Tenant.TenantID);
            var fileResource = tenantAttribute.TenantStyleSheetFileResource;

            Check.Assert(fileResource != null, "Tenant Attribute must have an associated Tenant Style Sheet File Resource.");

            // ReSharper disable once PossibleNullReferenceException -- Check.Assert above covers us here
            return new FileStreamResult(new MemoryStream(fileResource.FileResourceData), fileResource.FileResourceMimeType.FileResourceMimeTypeContentTypeName);
        }
    }
}
