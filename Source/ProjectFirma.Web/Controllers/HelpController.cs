/*-----------------------------------------------------------------------
<copyright file="HelpController.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using ProjectFirma.Web.Security.Shared;
using ProjectFirma.Web.Views.Shared;
using LtInfo.Common;
using LtInfo.Common.Mvc;
using LtInfo.Common.MvcResults;

namespace ProjectFirma.Web.Controllers
{
    public class HelpController : FirmaBaseController
    {
        public const string MessageForContactSubmittedSuccessfully = "Thank you for contacting us. We will get back to you soon!";

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpGet]
        public PartialViewResult Support()
        {
            return ViewSupport(null, "");
        }
        
        private PartialViewResult ViewSupport(SupportRequestTypeEnum? supportRequestTypeEnum, string optionalPrepopulatedDescription)
        {
            var currentPageUrl = string.Empty;
            if (Request.UrlReferrer != null)
            {
                currentPageUrl = Request.UrlReferrer.ToString();
            }
            else if (Request.Url != null)
            {
                currentPageUrl = Request.Url.ToString();
            }

            var viewModel = new SupportFormViewModel(currentPageUrl, supportRequestTypeEnum);
            if (!IsCurrentUserAnonymous())
            {
                viewModel.RequestPersonName = CurrentPerson.FullNameFirstLast;
                viewModel.RequestPersonEmail = CurrentPerson.Email;
                if (CurrentPerson.Organization != null)
                {
                    viewModel.RequestPersonOrganization = CurrentPerson.Organization.OrganizationName;
                }
                viewModel.RequestPersonPhone = CurrentPerson.Phone;
            }
            viewModel.RequestDescription = optionalPrepopulatedDescription;
            return ViewSupportImpl(viewModel, string.Empty);
        }

        private PartialViewResult ViewSupportImpl(SupportFormViewModel viewModel, string successMessage)
        {
            var allSupportRequestTypes = SupportRequestType.All.OrderBy(x => x.SupportRequestTypeSortOrder);

            var supportRequestTypes =
                allSupportRequestTypes.OrderBy(x => x.SupportRequestTypeSortOrder)
                    .ToSelectListWithEmptyFirstRow(x => x.SupportRequestTypeID.ToString(CultureInfo.InvariantCulture), x => x.SupportRequestTypeDisplayName);
            
            var viewData = new SupportFormViewData(successMessage, IsCurrentUserAnonymous(), supportRequestTypes, allSupportRequestTypes.Select(x => new SupportRequestTypeSimple(x)).ToList());
            return RazorPartialView<SupportForm, SupportFormViewData, SupportFormViewModel>(viewData, viewModel);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult Support(SupportFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewSupportImpl(viewModel, string.Empty);
            }
            var supportRequestLog = SupportRequestLog.Create(CurrentPerson);
            viewModel.UpdateModel(supportRequestLog, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllSupportRequestLogs.Add(supportRequestLog);
            supportRequestLog.SendMessage(Request.UserHostAddress, Request.UserAgent, viewModel.CurrentPageUrl, supportRequestLog.SupportRequestType);               
            SetMessageForDisplay("Support request sent.");
            return new ModalDialogFormJsonResult();
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpGet]
        public PartialViewResult MissingFundingSource()
        {
            return ViewSupport(SupportRequestTypeEnum.NewOrganizationOrFundingSource, string.Empty);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult MissingFundingSource(SupportFormViewModel viewModel)
        {
            return Support(viewModel);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpGet]
        public PartialViewResult ProposalFeedback()
        {
            return ViewSupport(SupportRequestTypeEnum.ProvideFeedback, $"Here is some feedback on the {FieldDefinition.Proposal.GetFieldDefinitionLabel()} wizard: " + Environment.NewLine);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ProposalFeedback(SupportFormViewModel viewModel)
        {
            return Support(viewModel);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpGet]
        public PartialViewResult RequestOrganizationNameChange()
        {
            return ViewSupport(SupportRequestTypeEnum.RequestOrganizationNameChange, string.Empty);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RequestOrganizationNameChange(SupportFormViewModel viewModel)
        {
            return Support(viewModel);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpGet]
        public PartialViewResult RequestProjectPrimaryContactChange(ProjectPrimaryKey projectPrimaryKey)
        {
            return ViewSupport(SupportRequestTypeEnum.RequestProjectPrimaryContactChange, string.Empty);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RequestProjectPrimaryContactChange(ProjectPrimaryKey projectPrimaryKey, SupportFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewSupportImpl(viewModel, string.Empty);
            }
            var supportRequestLog = SupportRequestLog.Create(CurrentPerson);
            viewModel.UpdateModel(supportRequestLog, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.AllSupportRequestLogs.Add(supportRequestLog);
            supportRequestLog.SendMessage(Request.UserHostAddress, Request.UserAgent, viewModel.CurrentPageUrl, supportRequestLog.SupportRequestType, projectPrimaryKey.EntityObject);
            SetMessageForDisplay("Support request sent.");
            return new ModalDialogFormJsonResult();
        }
    }
}
