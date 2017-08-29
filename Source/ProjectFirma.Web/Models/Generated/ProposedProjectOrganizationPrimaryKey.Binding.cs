//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectOrganization
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectOrganizationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectOrganization>
    {
        public ProposedProjectOrganizationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectOrganizationPrimaryKey(ProposedProjectOrganization proposedProjectOrganization) : base(proposedProjectOrganization){}

        public static implicit operator ProposedProjectOrganizationPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectOrganizationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectOrganizationPrimaryKey(ProposedProjectOrganization proposedProjectOrganization)
        {
            return new ProposedProjectOrganizationPrimaryKey(proposedProjectOrganization);
        }
    }
}