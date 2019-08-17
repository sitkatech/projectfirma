//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ContactRelationshipType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ContactRelationshipTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ContactRelationshipType>
    {
        public ContactRelationshipTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ContactRelationshipTypePrimaryKey(ContactRelationshipType contactRelationshipType) : base(contactRelationshipType){}

        public static implicit operator ContactRelationshipTypePrimaryKey(int primaryKeyValue)
        {
            return new ContactRelationshipTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ContactRelationshipTypePrimaryKey(ContactRelationshipType contactRelationshipType)
        {
            return new ContactRelationshipTypePrimaryKey(contactRelationshipType);
        }
    }
}