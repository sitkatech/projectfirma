using System;
using System.Net.Mail;
using ProjectFirma.Web.Controllers;
using LtInfo.Common;
using LtInfo.Common.Email;
using LtInfo.Common.Views;

namespace ProjectFirma.Web.Models
{
    public partial class SupportRequestLog
    {
        public static SupportRequestLog Create(Person person)
        {
            var supportRequest = CreateNewBlank(SupportRequestType.Other);
            if (person != null && !person.IsAnonymousUser)
            {
                supportRequest.RequestPerson = person;
                supportRequest.RequestPersonID = person.PersonID;
                supportRequest.RequestPersonName = person.FullNameFirstLast;
                supportRequest.RequestPersonEmail = person.Email;
                if (person.Organization != null)
                {
                    supportRequest.RequestPersonOrganization = person.Organization.OrganizationName;
                }
                supportRequest.RequestPersonPhone = person.Phone;
            }
            return supportRequest;
        }

        public void SendMessage(string ipAddress, string userAgent, string currentUrl, SupportRequestType supportRequestType)
        {
            SendMessage(ipAddress, userAgent, currentUrl, supportRequestType, null);
        }

        public void SendMessage(string ipAddress, string userAgent, string currentUrl, SupportRequestType supportRequestType, Project project)
        {
            var subject = string.Format("Support Request for Project Firma - {0}", DateTime.Now.ToStringDateTime());
            var projectSummaryUrl = project == null
                ? string.Empty
                : string.Format("    <strong>Project:</strong> <a href=\"{0}\">{1}</a><br />",
                    SitkaRoute<ProjectController>.BuildAbsoluteUrlHttpsFromExpression(x => x.Detail(project), SitkaWebConfiguration.CanonicalHostName),
                    project.DisplayName);
            var message = string.Format(@"
<div style='font-size: 12px; font-family: Arial'>
    <strong>{0}</strong><br />
    <br />
    <strong>From:</strong> {1} - {2}<br />
    <strong>Email:</strong> {3}<br />
    <strong>Phone:</strong> {4}<br />
    {5}
    <br />
    <strong>Subject:</strong> {6}<br />
    <br />
    <strong>Description:</strong><br />
    {7}
    <br />
    <br />
    <br />
    <div style='font-size: 10px; color: gray'>
    OTHER DETAILS:<br />
    LOGIN: {8}<br />
    IP ADDRESS: {9}<br />
    USERAGENT: {10}<br />
    URL FROM: {11}<br />
    <br />
    </div>
    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {12}</div>.
</div>
", subject, RequestPersonName, RequestPersonOrganization ?? "(not provided)", RequestPersonEmail, RequestPersonPhone ?? "(not provided)", projectSummaryUrl,
                supportRequestType.SupportRequestTypeDisplayName,
                RequestDescription.HtmlEncodeWithBreaks(),
                RequestPerson != null ? string.Format("{0} (UserID {1})", RequestPerson.FullNameFirstLast, RequestPerson.PersonID) : "(anonymous user)",
                ipAddress,
                userAgent,
                currentUrl,
                Common.FirmaWebConfiguration.SitkaSupportEmail);
            // Create Notification
            var mailMessage = new MailMessage {From = new MailAddress(Common.FirmaWebConfiguration.DoNotReplyEmail), Subject = subject, Body = message, IsBodyHtml = true};

            // Reply-To Header
            mailMessage.ReplyToList.Add(RequestPersonEmail);

            // TO field
            SupportRequestType.SetEmailRecipientsOfSupportRequest(mailMessage);

            SitkaSmtpClient.Send(mailMessage);
        }
    }
}