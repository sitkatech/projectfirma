//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonLoginAccount
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PersonLoginAccountPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonLoginAccount>
    {
        public PersonLoginAccountPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonLoginAccountPrimaryKey(PersonLoginAccount personLoginAccount) : base(personLoginAccount){}

        public static implicit operator PersonLoginAccountPrimaryKey(int primaryKeyValue)
        {
            return new PersonLoginAccountPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonLoginAccountPrimaryKey(PersonLoginAccount personLoginAccount)
        {
            return new PersonLoginAccountPrimaryKey(personLoginAccount);
        }
    }
}