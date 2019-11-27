using System;
using System.Net.Mail;
using LtInfo.Common;
using LtInfo.Common.Email;
using LtInfo.Common.Views;
using ProjectFirma.Web.Common;
using ProjectFirmaModels.Models;

namespace ProjectFirma.Web.Models
{
    public static class SupportRequestLogModelExtensions
    {
        public static SupportRequestLog Create(FirmaSession currentFirmaSession)
        {
            var supportRequest = SupportRequestLog.CreateNewBlank(SupportRequestType.Other);
            if (!currentFirmaSession.IsAnonymousUser())
            {
                var person = currentFirmaSession.Person;
                supportRequest.RequestPerson = person;
                supportRequest.RequestPersonID = person.PersonID;
                supportRequest.RequestPersonName = person.GetFullNameFirstLast();
                supportRequest.RequestPersonEmail = person.Email;
                if (person.Organization != null)
                {
                    supportRequest.RequestPersonOrganization = person.Organization.OrganizationName;
                }
                supportRequest.RequestPersonPhone = person.Phone;
            }
            return supportRequest;
        }

        public static void SendMessage(SupportRequestLog supportRequestLog, string ipAddress, string userAgent, string currentUrl, SupportRequestType supportRequestType, DatabaseEntities databaseEntities, int defaultSupportPersonID)
        {
            var subject = $"Support Request for Project Firma - {DateTime.Now.ToStringDateTime()}";
            var message = $@"
<div style='font-size: 12px; font-family: Arial'>
    <strong>{subject}</strong><br />
    <br />
    <strong>From:</strong> {supportRequestLog.RequestPersonName} - {supportRequestLog.RequestPersonOrganization ?? "(not provided)"}<br />
    <strong>Email:</strong> {supportRequestLog.RequestPersonEmail}<br />
    <strong>Phone:</strong> {supportRequestLog.RequestPersonPhone ?? "(not provided)"}<br />
    <br />
    <strong>Subject:</strong> {supportRequestType.SupportRequestTypeDisplayName}<br />
    <br />
    <strong>Description:</strong><br />
    {supportRequestLog.RequestDescription.HtmlEncodeWithBreaks()}
    <br />
    <br />
    <br />
    <div style='font-size: 10px; color: gray'>
    OTHER DETAILS:<br />
    LOGIN: {(supportRequestLog.RequestPerson != null ? $"{supportRequestLog.RequestPerson.GetFullNameFirstLast()} (UserID {supportRequestLog.RequestPerson.PersonID})" : "(anonymous user)")}<br />
    IP ADDRESS: {ipAddress}<br />
    USERAGENT: {userAgent}<br />
    URL FROM: {currentUrl}<br />
    <br />
    </div>
    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {FirmaWebConfiguration.SitkaSupportEmail}</div>.
</div>
";
            // Create Notification
            var mailMessage = new MailMessage {From = new MailAddress(FirmaWebConfiguration.DoNotReplyEmail), Subject = subject, Body = message, IsBodyHtml = true};

            // Reply-To Header
            mailMessage.ReplyToList.Add(supportRequestLog.RequestPersonEmail);

            // TO field
            SupportRequestTypeModelExtensions.SetEmailRecipientsOfSupportRequest(databaseEntities, mailMessage, defaultSupportPersonID);

            SitkaSmtpClient.Send(mailMessage);
        }
    }
}