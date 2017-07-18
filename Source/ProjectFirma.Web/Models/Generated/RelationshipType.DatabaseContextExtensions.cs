//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: [dbo].[RelationshipType]
using System.Collections.Generic;
using System.Linq;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public static partial class DatabaseContextExtensions
    {
        public static RelationshipType GetRelationshipType(this IQueryable<RelationshipType> relationshipTypes, int relationshipTypeID)
        {
            var relationshipType = relationshipTypes.SingleOrDefault(x => x.RelationshipTypeID == relationshipTypeID);
            Check.RequireNotNullThrowNotFound(relationshipType, "RelationshipType", relationshipTypeID);
            return relationshipType;
        }

        public static void DeleteRelationshipType(this List<int> relationshipTypeIDList)
        {
            if(relationshipTypeIDList.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllRelationshipTypes.RemoveRange(HttpRequestStorage.DatabaseEntities.RelationshipTypes.Where(x => relationshipTypeIDList.Contains(x.RelationshipTypeID)));
            }
        }

        public static void DeleteRelationshipType(this ICollection<RelationshipType> relationshipTypesToDelete)
        {
            if(relationshipTypesToDelete.Any())
            {
                HttpRequestStorage.DatabaseEntities.AllRelationshipTypes.RemoveRange(relationshipTypesToDelete);
            }
        }

        public static void DeleteRelationshipType(this int relationshipTypeID)
        {
            DeleteRelationshipType(new List<int> { relationshipTypeID });
        }

        public static void DeleteRelationshipType(this RelationshipType relationshipTypeToDelete)
        {
            DeleteRelationshipType(new List<RelationshipType> { relationshipTypeToDelete });
        }
    }
}