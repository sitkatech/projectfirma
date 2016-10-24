using System.Linq;
using System.Net.Mail;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public partial class SupportRequestType
    {
        public virtual void SetEmailRecipientsOfSupportRequest(MailMessage mailMessage)
        {
            var supportPersons = HttpRequestStorage.DatabaseEntities.People.GetPeopleWhoReceiveSupportEmails();

            if (!supportPersons.Any())
            {
                var defaultSupportPerson = HttpRequestStorage.DatabaseEntities.People.GetPerson(ProjectFirmaWebConfiguration.DefaultSupportPersonID);
                supportPersons.Add(defaultSupportPerson);
                mailMessage.Body = string.Format("<p style=\"font-weight:bold\">Note: No users are currently configured to receive support emails. Defaulting to User: {0}</p>{1}",
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

    public partial class SupportRequestTypeProvideFeedback
    {
    }

    public partial class SupportRequestTypeRequestOrganizationNameChange
    {
        public override void SetEmailRecipientsOfSupportRequest(MailMessage mailMessage)
        {
            mailMessage.To.Add(ProjectFirmaWebConfiguration.SitkaSupportEmail);
        }
    }
}