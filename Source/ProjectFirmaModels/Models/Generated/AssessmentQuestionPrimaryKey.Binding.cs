//  IMPORTANT:
//  This file is generated. Your changes will be lost.
//  Use the corresponding partial class for customizations.
//  Source Table: dbo.AssessmentQuestion
using CodeFirstStoreFunctions;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Models;

namespace ProjectFirmaModels.Models
{
    public class AssessmentQuestionPrimaryKey : LtInfo.Common.EntityModelBinding.LtInfoEntityPrimaryKey<AssessmentQuestion>
    {
        public AssessmentQuestionPrimaryKey(int primaryKeyValue) : base(primaryKeyValue){}
        public AssessmentQuestionPrimaryKey(AssessmentQuestion assessmentQuestion) : base(assessmentQuestion){}

        public static implicit operator AssessmentQuestionPrimaryKey(int primaryKeyValue)
        {
            return new AssessmentQuestionPrimaryKey(primaryKeyValue);
        }

        public static implicit operator AssessmentQuestionPrimaryKey(AssessmentQuestion assessmentQuestion)
        {
            return new AssessmentQuestionPrimaryKey(assessmentQuestion);
        }
    }
}