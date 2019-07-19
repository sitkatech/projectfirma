//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ContactTypeContactRelationshipType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ContactTypeContactRelationshipTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ContactTypeContactRelationshipType>
    {
        public ContactTypeContactRelationshipTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ContactTypeContactRelationshipTypePrimaryKey(ContactTypeContactRelationshipType contactTypeContactRelationshipType) : base(contactTypeContactRelationshipType){}

        public static implicit operator ContactTypeContactRelationshipTypePrimaryKey(int primaryKeyValue)
        {
            return new ContactTypeContactRelationshipTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ContactTypeContactRelationshipTypePrimaryKey(ContactTypeContactRelationshipType contactTypeContactRelationshipType)
        {
            return new ContactTypeContactRelationshipTypePrimaryKey(contactTypeContactRelationshipType);
        }
    }
}