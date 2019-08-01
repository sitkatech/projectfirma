//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ProjectContact]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ProjectContact GetProjectContact(this IQueryable<ProjectContact> projectContacts, int projectContactID)
        {
            var projectContact = projectContacts.SingleOrDefault(x => x.ProjectContactID == projectContactID);
            Check.RequireNotNullThrowNotFound(projectContact, "ProjectContact", projectContactID);
            return projectContact;
        }

    }
}