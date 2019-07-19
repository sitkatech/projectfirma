//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[ContactTypeContactRelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static ContactTypeContactRelationshipType GetContactTypeContactRelationshipType(this IQueryable<ContactTypeContactRelationshipType> contactTypeContactRelationshipTypes, int contactTypeContactRelationshipTypeID)
        {
            var contactTypeContactRelationshipType = contactTypeContactRelationshipTypes.SingleOrDefault(x => x.ContactTypeContactRelationshipTypeID == contactTypeContactRelationshipTypeID);
            Check.RequireNotNullThrowNotFound(contactTypeContactRelationshipType, "ContactTypeContactRelationshipType", contactTypeContactRelationshipTypeID);
            return contactTypeContactRelationshipType;
        }

    }
}