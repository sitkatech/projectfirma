//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[RelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static RelationshipType GetRelationshipType(this IQueryable<RelationshipType> relationshipTypes, int relationshipTypeID)
        {
            var relationshipType = relationshipTypes.SingleOrDefault(x => x.RelationshipTypeID == relationshipTypeID);
            Check.RequireNotNullThrowNotFound(relationshipType, "RelationshipType", relationshipTypeID);
            return relationshipType;
        }

    }
}