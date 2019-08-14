using System;
using System.Linq;
using System.Net.Mail;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SupportRequestTypeModelExtensions
    {
        public static string GetSubjectLine(this SupportRequestType supportRequestType)
        {
            var a = FieldDefinitionEnum.Project.ToType();
            switch (supportRequestType.ToEnum)
            {
                case SupportRequestTypeEnum.ReportBug:
                case SupportRequestTypeEnum.ForgotLoginInfo:
                case SupportRequestTypeEnum.ProvideFeedback:
                case SupportRequestTypeEnum.RequestOrganizationNameChange:
                case SupportRequestTypeEnum.Other:
                    return supportRequestType.SupportRequestTypeDisplayName;
                case SupportRequestTypeEnum.NewOrganizationOrFundingSource:
                    return $"Need an {FieldDefinitionEnum.Organization.ToType().GetFieldDefinitionLabel()} or {FieldDefinitionEnum.FundingSource.ToType().GetFieldDefinitionLabel()} added to the list";
                case SupportRequestTypeEnum.HelpWithProjectUpdate:
                    return $"Can't figure out how to update my {a.GetFieldDefinitionLabel()}";
                case SupportRequestTypeEnum.RequestProjectPrimaryContactChange:
                    return $"Request a change to a {a.GetFieldDefinitionLabel()}'s {FieldDefinitionEnum.ProjectPrimaryContact.ToType().GetFieldDefinitionLabel()}";
                case SupportRequestTypeEnum.RequestPermissionToAddProjects:
                    return $"Request permission to add { a.GetFieldDefinitionLabelPluralized()}";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void SetEmailRecipientsOfSupportRequest(DatabaseEntities databaseEntities, MailMessage mailMessage, int defaultSupportPersonID)
        {
            var supportPersons = databaseEntities.People.GetPeopleWhoReceiveSupportEmails();

            if (!supportPersons.Any())
            {
                var defaultSupportPerson = databaseEntities.People.GetPerson(defaultSupportPersonID);
                supportPersons.Add(defaultSupportPerson);
                mailMessage.Body =
                    $"<p style=\"font-weight:bold\">Note: No users are currently configured to receive support emails. Defaulting to User: {defaultSupportPerson.GetFullNameFirstLast()}</p>{mailMessage.Body}";
            }
            foreach (var supportPerson in supportPersons)
            {
                mailMessage.To.Add(supportPerson.Email);
            }
        }
    }
}