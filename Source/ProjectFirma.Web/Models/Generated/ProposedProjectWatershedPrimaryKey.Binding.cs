//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectWatershed
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectWatershedPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectWatershed>
    {
        public ProposedProjectWatershedPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectWatershedPrimaryKey(ProposedProjectWatershed proposedProjectWatershed) : base(proposedProjectWatershed){}

        public static implicit operator ProposedProjectWatershedPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectWatershedPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectWatershedPrimaryKey(ProposedProjectWatershed proposedProjectWatershed)
        {
            return new ProposedProjectWatershedPrimaryKey(proposedProjectWatershed);
        }
    }
}