//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ContactType GetContactType(this IQueryable<ContactType> contactTypes, int contactTypeID)
        {
            var contactType = contactTypes.SingleOrDefault(x => x.ContactTypeID == contactTypeID);
            Check.RequireNotNullThrowNotFound(contactType, "ContactType", contactTypeID);
            return contactType;
        }

    }
}