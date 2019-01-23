/*-----------------------------------------------------------------------
<copyright file="SupportRequestLog.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Net.Mail;
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
            if (person != null && !person.IsAnonymousUser())
            {
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

        public void SendMessage(string ipAddress, string userAgent, string currentUrl, SupportRequestType supportRequestType, DatabaseEntities databaseEntities, int defaultSupportPersonID)
        {
            var subject = $"Support Request for Project Firma - {DateTime.Now.ToStringDateTime()}";
            var message = string.Format(@"
<div style='font-size: 12px; font-family: Arial'>
    <strong>{0}</strong><br />
    <br />
    <strong>From:</strong> {1} - {2}<br />
    <strong>Email:</strong> {3}<br />
    <strong>Phone:</strong> {4}<br />
    <br />
    <strong>Subject:</strong> {5}<br />
    <br />
    <strong>Description:</strong><br />
    {6}
    <br />
    <br />
    <br />
    <div style='font-size: 10px; color: gray'>
    OTHER DETAILS:<br />
    LOGIN: {7}<br />
    IP ADDRESS: {8}<br />
    USERAGENT: {9}<br />
    URL FROM: {10}<br />
    <br />
    </div>
    <div>You received this email because you are set up as a point of contact for support - if that's not correct, let us know: {11}</div>.
</div>
", subject, RequestPersonName, RequestPersonOrganization ?? "(not provided)", RequestPersonEmail, RequestPersonPhone ?? "(not provided)",
                supportRequestType.SupportRequestTypeDisplayName,
                RequestDescription.HtmlEncodeWithBreaks(),
                RequestPerson != null ? $"{RequestPerson.GetFullNameFirstLast()} (UserID {RequestPerson.PersonID})" : "(anonymous user)",
                ipAddress,
                userAgent,
                currentUrl,
                Common.FirmaWebConfiguration.SitkaSupportEmail);
            // Create Notification
            var mailMessage = new MailMessage {From = new MailAddress(Common.FirmaWebConfiguration.DoNotReplyEmail), Subject = subject, Body = message, IsBodyHtml = true};

            // Reply-To Header
            mailMessage.ReplyToList.Add(RequestPersonEmail);

            // TO field
            SupportRequestType.SetEmailRecipientsOfSupportRequest(databaseEntities, mailMessage, defaultSupportPersonID);

            SitkaSmtpClient.Send(mailMessage);
        }
    }
}
