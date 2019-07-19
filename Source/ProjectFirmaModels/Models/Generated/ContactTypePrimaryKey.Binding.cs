//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ContactType
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class ContactTypePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ContactType>
    {
        public ContactTypePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ContactTypePrimaryKey(ContactType contactType) : base(contactType){}

        public static implicit operator ContactTypePrimaryKey(int primaryKeyValue)
        {
            return new ContactTypePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ContactTypePrimaryKey(ContactType contactType)
        {
            return new ContactTypePrimaryKey(contactType);
        }
    }
}