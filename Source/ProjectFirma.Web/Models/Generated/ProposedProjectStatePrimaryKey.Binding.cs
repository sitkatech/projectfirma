//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectState
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectStatePrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectState>
    {
        public ProposedProjectStatePrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectStatePrimaryKey(ProposedProjectState proposedProjectState) : base(proposedProjectState){}

        public static implicit operator ProposedProjectStatePrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectStatePrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectStatePrimaryKey(ProposedProjectState proposedProjectState)
        {
            return new ProposedProjectStatePrimaryKey(proposedProjectState);
        }
    }
}