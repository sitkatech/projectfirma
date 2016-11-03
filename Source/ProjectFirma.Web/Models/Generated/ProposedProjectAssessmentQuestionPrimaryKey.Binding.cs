//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.ProposedProjectAssessmentQuestion
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Models
{
    public class ProposedProjectAssessmentQuestionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<ProposedProjectAssessmentQuestion>
    {
        public ProposedProjectAssessmentQuestionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public ProposedProjectAssessmentQuestionPrimaryKey(ProposedProjectAssessmentQuestion proposedProjectAssessmentQuestion) : base(proposedProjectAssessmentQuestion){}

        public static implicit operator ProposedProjectAssessmentQuestionPrimaryKey(int primaryKeyValue)
        {
            return new ProposedProjectAssessmentQuestionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator ProposedProjectAssessmentQuestionPrimaryKey(ProposedProjectAssessmentQuestion proposedProjectAssessmentQuestion)
        {
            return new ProposedProjectAssessmentQuestionPrimaryKey(proposedProjectAssessmentQuestion);
        }
    }
}