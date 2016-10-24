using System.Collections.Generic;
using System.Web.Mvc;
using ProjectFirma.Web.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class SupportFormViewData
    {
        public readonly List<SupportRequestTypeSimple> SupportRequestTypeSimples;
        public readonly string SuccessMessage;
        public readonly bool IsUserAnonymous;
        public readonly IEnumerable<SelectListItem> SupportRequestTypes;

        public SupportFormViewData(string successMessage, bool isUserAnonymous, IEnumerable<SelectListItem> supportRequestTypes, List<SupportRequestTypeSimple> supportRequestTypeSimples)
        {
            SupportRequestTypeSimples = supportRequestTypeSimples;
            SuccessMessage = successMessage;
            IsUserAnonymous = isUserAnonymous;
            SupportRequestTypes = supportRequestTypes;
        }
    }
}