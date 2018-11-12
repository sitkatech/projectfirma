//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonStewardWatershed
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PersonStewardWatershedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonStewardWatershed>
    {
        public PersonStewardWatershedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonStewardWatershedPrimaryKey(PersonStewardWatershed personStewardWatershed) : base(personStewardWatershed){}

        public static implicit operator PersonStewardWatershedPrimaryKey(int primaryKeyValue)
        {
            return new PersonStewardWatershedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonStewardWatershedPrimaryKey(PersonStewardWatershed personStewardWatershed)
        {
            return new PersonStewardWatershedPrimaryKey(personStewardWatershed);
        }
    }
}