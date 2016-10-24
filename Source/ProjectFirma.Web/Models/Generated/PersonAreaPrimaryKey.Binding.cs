//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonArea
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PersonAreaPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonArea>
    {
        public PersonAreaPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonAreaPrimaryKey(PersonArea personArea) : base(personArea){}

        public static implicit operator PersonAreaPrimaryKey(int primaryKeyValue)
        {
            return new PersonAreaPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonAreaPrimaryKey(PersonArea personArea)
        {
            return new PersonAreaPrimaryKey(personArea);
        }
    }
}