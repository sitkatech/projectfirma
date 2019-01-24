//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.Person
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class PersonPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<Person>
    {
        public PersonPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonPrimaryKey(Person person) : base(person){}

        public static implicit operator PersonPrimaryKey(int primaryKeyValue)
        {
            return new PersonPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonPrimaryKey(Person person)
        {
            return new PersonPrimaryKey(person);
        }
    }
}