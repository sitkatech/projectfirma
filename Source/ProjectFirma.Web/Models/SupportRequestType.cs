/*-----------------------------------------------------------------------
<copyright file="SupportRequestType.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
using System.Linq;
using System.Net.Mail;

namespace ProjectFirma.Web.Models
{
    public partial class SupportRequestType
    {
        public virtual string GetSubjectLine()
        {
            return SupportRequestTypeDisplayName;
        }

        public virtual void SetEmailRecipientsOfSupportRequest(DatabaseEntities databaseEntities,
            MailMessage mailMessage, int defaultSupportPersonID)
        {
            var supportPersons = databaseEntities.People.GetPeopleWhoReceiveSupportEmails();

            if (!supportPersons.Any())
            {
                var defaultSupportPerson = databaseEntities.People.GetPerson(defaultSupportPersonID);
                supportPersons.Add(defaultSupportPerson);
                mailMessage.Body = string.Format("<p style=\"font-weight:bold\">Note: No users are currently configured to receive support emails. Defaulting to User: {0}</p>{1}",
                    defaultSupportPerson.GetFullNameFirstLast(),
                    mailMessage.Body);
            }
            foreach (var supportPerson in supportPersons)
            {
                mailMessage.To.Add(supportPerson.Email);
            }            
        }
    }

    public partial class SupportRequestTypeReportBug
    {
    }

    public partial class SupportRequestTypeHelpWithProjectUpdate
    {
        public override string GetSubjectLine()
        {
            return $"Can't figure out how to update my {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}";
        }
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

    public partial class SupportRequestTypeProvideFeedback
    {
    }


    public partial class SupportRequestTypeRequestProjectPrimaryContactChange
    {
        public override string GetSubjectLine()
        {
            return $"Request a change to a {Models.FieldDefinition.Project.GetFieldDefinitionLabel()}'s primary contact";
        }
    }

    public partial class SupportRequestTypeRequestPermissionToAddProjects
    {
        public override string GetSubjectLine()
        {
            return $"Request permission to add {Models.FieldDefinition.Project.GetFieldDefinitionLabelPluralized()}";
        }
    }


    public partial class SupportRequestTypeRequestOrganizationNameChange
    {
    }
}
