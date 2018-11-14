//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.PersonStewardTaxonomyBranch
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class PersonStewardTaxonomyBranchPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<PersonStewardTaxonomyBranch>
    {
        public PersonStewardTaxonomyBranchPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public PersonStewardTaxonomyBranchPrimaryKey(PersonStewardTaxonomyBranch personStewardTaxonomyBranch) : base(personStewardTaxonomyBranch){}

        public static implicit operator PersonStewardTaxonomyBranchPrimaryKey(int primaryKeyValue)
        {
            return new PersonStewardTaxonomyBranchPrimaryKey(primaryKeyValue);
        }

        public static implicit operator PersonStewardTaxonomyBranchPrimaryKey(PersonStewardTaxonomyBranch personStewardTaxonomyBranch)
        {
            return new PersonStewardTaxonomyBranchPrimaryKey(personStewardTaxonomyBranch);
        }
    }
}