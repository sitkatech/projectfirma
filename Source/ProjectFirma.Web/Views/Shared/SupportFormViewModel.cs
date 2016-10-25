using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using ProjectFirma.Web.Common;
using ProjectFirma.Web.Models;
using LtInfo.Common;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Views.Shared
{
    public class SupportFormViewModel : FormViewModel, IValidatableObject
    {
        [Required]
        [DisplayName("Name")]
        [StringLength(SupportRequestLog.FieldLengths.RequestPersonName)]
        public String RequestPersonName { get; set; }

        [Required]
        [DisplayName("Email Address")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$",
            ErrorMessage = "Email supplied does not appear to be formatted correctly")]
        [StringLength(SupportRequestLog.FieldLengths.RequestPersonEmail)]
        public String RequestPersonEmail { get; set; }

        [Required]
        [DisplayName("Description")]
        [StringLength(SupportRequestLog.FieldLengths.RequestDescription)]
        public string RequestDescription { get; set; }

        [DisplayName("Organization")]
        [StringLength(SupportRequestLog.FieldLengths.RequestPersonOrganization)]
        public string RequestPersonOrganization { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(SupportRequestLog.FieldLengths.RequestPersonPhone)]
        public string RequestPersonPhone { get; set; }

        [Required]
        [DisplayName("Subject")]
        public SupportRequestTypeEnum? SupportRequestTypeEnum { get; set; }

        public string CurrentPageUrl { get; set; }

        // Needed by model binder
        public SupportFormViewModel()
        {
        }

        public SupportFormViewModel(string currentPageUrl, SupportRequestTypeEnum? supportRequestTypeEnum)
        {
            CurrentPageUrl = currentPageUrl;
            SupportRequestTypeEnum = supportRequestTypeEnum;
        }

        public void UpdateModel(SupportRequestLog supportRequestLog, Person updatePerson)
        {
            supportRequestLog.RequestPersonName = RequestPersonName;
            supportRequestLog.RequestPersonEmail = RequestPersonEmail;
            supportRequestLog.RequestPersonOrganization = RequestPersonOrganization;
            supportRequestLog.RequestPersonPhone = RequestPersonPhone;
            // ReSharper disable once PossibleInvalidOperationException
            supportRequestLog.SupportRequestTypeID = (int) SupportRequestTypeEnum.Value;
            supportRequestLog.RequestDescription = RequestDescription;
            supportRequestLog.RequestDate = DateTime.Now;
            if (updatePerson != null && !updatePerson.IsAnonymousUser)
            {
                supportRequestLog.RequestPersonID = updatePerson.PersonID;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            var httpContext = HttpContext.Current;
            if (!httpContext.User.Identity.IsAuthenticated) // this means we are anonymous
            {
                var ipAddress = string.Empty;
                if (httpContext != null)
                {
                    ipAddress = httpContext.Request.UserHostAddress;
                }
                var gRecaptchaResponse = httpContext.Request.Form["g-recaptcha-response"];
                if (
                    !RecaptchaValidator.IsValidResponse(gRecaptchaResponse,
                        ipAddress,
                        FirmaWebConfiguration.RecaptchaPrivateKey,
                        FirmaWebConfiguration.RecaptchaValidatorUrl,
                        SitkaLogger.Instance.LogDetailedErrorMessage))
                {
                    errors.Add(new ValidationResult("Your Captcha response is incorrect."));
                }
            }
            return errors;
        }
    }
}