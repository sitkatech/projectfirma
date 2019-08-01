//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactRelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ContactRelationshipType GetContactRelationshipType(this IQueryable<ContactRelationshipType> contactRelationshipTypes, int contactRelationshipTypeID)
        {
            var contactRelationshipType = contactRelationshipTypes.SingleOrDefault(x => x.ContactRelationshipTypeID == contactRelationshipTypeID);
            Check.RequireNotNullThrowNotFound(contactRelationshipType, "ContactRelationshipType", contactRelationshipTypeID);
            return contactRelationshipType;
        }

    }
}