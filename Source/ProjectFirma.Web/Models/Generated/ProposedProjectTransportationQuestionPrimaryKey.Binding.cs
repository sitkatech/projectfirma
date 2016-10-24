//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectTransportationQuestion
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectTransportationQuestionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectTransportationQuestion>
    {
        public ProposedProjectTransportationQuestionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectTransportationQuestionPrimaryKey(ProposedProjectTransportationQuestion proposedProjectTransportationQuestion) : base(proposedProjectTransportationQuestion){}

        public static implicit operator ProposedProjectTransportationQuestionPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectTransportationQuestionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectTransportationQuestionPrimaryKey(ProposedProjectTransportationQuestion proposedProjectTransportationQuestion)
        {
            return new ProposedProjectTransportationQuestionPrimaryKey(proposedProjectTransportationQuestion);
        }
    }
}