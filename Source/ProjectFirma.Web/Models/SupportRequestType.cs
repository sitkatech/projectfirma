using System.Linq;
using System.Net.Mail;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class SupportRequestType
    {
        public virtual void SetEmailRecipientsOfSupportRequest(LTInfoArea ltInfoArea, MailMessage mailMessage)
        {
            var supportPersons = ltInfoArea.GetSupportRequestRecipients().ToList();

            if (!supportPersons.Any())
            {
                var defaultSupportPerson = HttpRequestStorage.DatabaseEntities.People.GetPerson(ProjectFirmaWebConfiguration.DefaultSupportPersonID);
                supportPersons.Add(defaultSupportPerson);
                mailMessage.Body = string.Format("<p style=\"font-weight:bold\">Note: No users are currently configured to receive support emails for Area {0}. Defaulting to User: {1}</p>{2}",
                    ltInfoArea.LTInfoAreaDisplayName,
                    defaultSupportPerson.FullNameFirstLast,
                    mailMessage.Body);
            }
            foreach (var supportPerson in supportPersons)
            {
                mailMessage.To.Add(supportPerson.Email);
            }            
        }
    }

    public partial class SupportRequestTypeQuestionAboutPolicies
    {
    }

    public partial class SupportRequestTypeReportBug
    {
    }

    public partial class SupportRequestTypeHelpWithProjectUpdate
    {
    }

    public partial class SupportRequestTypeForgotLoginInfo
    {
    }

    public partial class SupportRequestTypeNewOrganizationOrFundingSource
    {
    }

    public partial class SupportRequestTypeOther
    {
    }

    public partial class SupportRequestTypeRequestToBeAddedToFtipList
    {
    }

    public partial class SupportRequestTypeNewResidentialAllocationNumber
    {
    }

    public partial class SupportRequestTypeProvideFeedback
    {
    }

    public partial class SupportRequestTypeRequestOrganizationNameChange
    {
        public override void SetEmailRecipientsOfSupportRequest(LTInfoArea ltInfoArea, MailMessage mailMessage)
        {
            mailMessage.To.Add(ProjectFirmaWebConfiguration.SitkaSupportEmail);
        }
    }
}