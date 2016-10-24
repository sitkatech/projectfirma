//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectThresholdCategory
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectThresholdCategoryPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectThresholdCategory>
    {
        public ProposedProjectThresholdCategoryPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectThresholdCategoryPrimaryKey(ProposedProjectThresholdCategory proposedProjectThresholdCategory) : base(proposedProjectThresholdCategory){}

        public static implicit operator ProposedProjectThresholdCategoryPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectThresholdCategoryPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectThresholdCategoryPrimaryKey(ProposedProjectThresholdCategory proposedProjectThresholdCategory)
        {
            return new ProposedProjectThresholdCategoryPrimaryKey(proposedProjectThresholdCategory);
        }
    }
}