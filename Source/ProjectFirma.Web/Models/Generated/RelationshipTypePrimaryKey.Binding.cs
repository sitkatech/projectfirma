//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.RelationshipType
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class RelationshipTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<RelationshipType>
    {
        public RelationshipTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public RelationshipTypePrimaryKey(RelationshipType relationshipType) : base(relationshipType){}

        public static implicit operator RelationshipTypePrimaryKey(int primaryKeyValue)
        {
            return new RelationshipTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator RelationshipTypePrimaryKey(RelationshipType relationshipType)
        {
            return new RelationshipTypePrimaryKey(relationshipType);
        }
    }
}