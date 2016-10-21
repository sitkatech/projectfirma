//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectLocationStaging
using ProjectFirma.Web.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectLocationStagingPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectLocationStaging>
    {
        public ProposedProjectLocationStagingPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectLocationStagingPrimaryKey(ProposedProjectLocationStaging proposedProjectLocationStaging) : base(proposedProjectLocationStaging){}

        public static implicit operator ProposedProjectLocationStagingPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectLocationStagingPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectLocationStagingPrimaryKey(ProposedProjectLocationStaging proposedProjectLocationStaging)
        {
            return new ProposedProjectLocationStagingPrimaryKey(proposedProjectLocationStaging);
        }
    }
}