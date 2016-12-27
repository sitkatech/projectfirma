//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectClassification
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectClassificationPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectClassification>
    {
        public ProposedProjectClassificationPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectClassificationPrimaryKey(ProposedProjectClassification proposedProjectClassification) : base(proposedProjectClassification){}

        public static implicit operator ProposedProjectClassificationPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectClassificationPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectClassificationPrimaryKey(ProposedProjectClassification proposedProjectClassification)
        {
            return new ProposedProjectClassificationPrimaryKey(proposedProjectClassification);
        }
    }
}