/* 
select * from ProjectEvaluation

select * from ProjectEvaluationSelectedValue

select * from Evaluation
select * from EvaluationCriteriaValue 

delete from ProjectEvaluationSelectedValue where ProjectEvaluationSelectedValueID = 26
*/



ALTER TABLE [dbo].[ProjectEvaluationSelectedValue] ADD  CONSTRAINT [AK_ProjectEvaluationSelectedValue_TenantID_ProjectEvaluationID_EvaluationCriteriaValueID] UNIQUE NONCLUSTERED 
(
	TenantID,
    ProjectEvaluationID,
    EvaluationCriteriaValueID
    
)

go
