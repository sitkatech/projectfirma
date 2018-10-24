//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonStewardOrganization
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PersonStewardOrganizationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonStewardOrganization>
    {
        public PersonStewardOrganizationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonStewardOrganizationPrimaryKey(PersonStewardOrganization personStewardOrganization) : base(personStewardOrganization){}

        public static implicit operator PersonStewardOrganizationPrimaryKey(int primaryKeyValue)
        {
            return new PersonStewardOrganizationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonStewardOrganizationPrimaryKey(PersonStewardOrganization personStewardOrganization)
        {
            return new PersonStewardOrganizationPrimaryKey(personStewardOrganization);
        }
    }
}