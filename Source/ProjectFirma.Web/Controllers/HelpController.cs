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
    public class HelpController : LakeTahoeInfoBaseController
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

            //Determine which area of the site they came from
            var currentRootUrlHost = Request.Url.Host;
            var currentLtInfoArea = LTInfoArea.All.SingleOrDefault(x => x.GetCanonicalHostName().Equals(currentRootUrlHost, StringComparison.InvariantCultureIgnoreCase));
            if (currentLtInfoArea == null)
            {
                //If we can't find the area, log and continue with default (LTInfo) area
                SitkaLogger.Instance.LogDetailedErrorMessage("Unknown domain: " + currentRootUrlHost);
                currentLtInfoArea = LTInfoArea.LTInfo;
            }

            var viewModel = new SupportFormViewModel(currentPageUrl, supportRequestTypeEnum, currentLtInfoArea.ToEnum);
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
                allSupportRequestTypes.Where(x => x.LTInfoAreaID == null || x.LTInfoAreaID == (int) viewModel.LakeTahoeInfoAreaEnum)
                    .OrderBy(x => x.SupportRequestTypeSortOrder)
                    .ToSelectListWithEmptyFirstRow(x => x.SupportRequestTypeID.ToString(CultureInfo.InvariantCulture), x => x.SupportRequestTypeDisplayName);
            
            var siteAreas = LTInfoArea.All.OrderBy(x => x.LTInfoAreaID).ToSelectList(x => x.LTInfoAreaID.ToString(CultureInfo.InvariantCulture), x => x.LTInfoAreaDisplayName);
            
            var viewData = new SupportFormViewData(successMessage, IsCurrentUserAnonymous(), supportRequestTypes, siteAreas, allSupportRequestTypes.Select(x => new SupportRequestTypeSimple(x)).ToList());
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
            HttpRequestStorage.DatabaseEntities.SupportRequestLogs.Add(supportRequestLog);
            supportRequestLog.SendMessage(Request.UserHostAddress, Request.UserAgent, viewModel.CurrentPageUrl, supportRequestLog.SupportRequestType, viewModel.LakeTahoeInfoAreaEnum);               
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
        public PartialViewResult ProposedProjectFeedback()
        {
            return ViewSupport(SupportRequestTypeEnum.ProvideFeedback, "Here is some feedback on the Proposed Project wizard: " + Environment.NewLine);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult ProposedProjectFeedback(SupportFormViewModel viewModel)
        {
            return Support(viewModel);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpGet]
        public PartialViewResult UpdateParcelInformation(ParcelPrimaryKey parcelPrimaryKey)
        {
            var parcel = parcelPrimaryKey.EntityObject;
            return ViewSupport(SupportRequestTypeEnum.UpdateParcelInformation, string.Format("Please update Parcel '{0}' with this information:{1}", parcel.ParcelNumber, Environment.NewLine));
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult UpdateParcelInformation(ParcelPrimaryKey parcelPrimaryKey, SupportFormViewModel viewModel)
        {
            return Support(viewModel);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpGet]
        public PartialViewResult RequestToBeAddedToFtipList(ProjectPrimaryKey projectPrimaryKey)
        {
            return ViewSupport(SupportRequestTypeEnum.RequestToBeAddedToFtipList, string.Empty);
        }

        [AnonymousUnclassifiedFeature]
        [CrossAreaRoute]
        [HttpPost]
        [AutomaticallyCallEntityFrameworkSaveChangesWhenModelValid]
        public ActionResult RequestToBeAddedToFtipList(ProjectPrimaryKey projectPrimaryKey, SupportFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return ViewSupportImpl(viewModel, string.Empty);
            }
            var supportRequestLog = SupportRequestLog.Create(CurrentPerson);
            viewModel.UpdateModel(supportRequestLog, CurrentPerson);
            HttpRequestStorage.DatabaseEntities.SupportRequestLogs.Add(supportRequestLog);
            supportRequestLog.SendMessage(Request.UserHostAddress, Request.UserAgent, viewModel.CurrentPageUrl, supportRequestLog.SupportRequestType, projectPrimaryKey.EntityObject, LTInfoAreaEnum.EIP);
            SetMessageForDisplay("Support request sent.");
            return new ModalDialogFormJsonResult();
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
    }
}