--begin tran

ALTER TABLE [dbo].[ProjectEvaluation] ADD  CONSTRAINT [AK_ProjectEvaluation_EvaluationID_ProjectID] UNIQUE NONCLUSTERED 
(
	[EvaluationID] ASC,
	[ProjectID] ASC
)
GO

--rollback tran