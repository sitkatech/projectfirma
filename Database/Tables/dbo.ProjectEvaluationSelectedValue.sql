SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectEvaluationSelectedValue](
	[ProjectEvaluationSelectedValueID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectEvaluationID] [int] NOT NULL,
	[EvaluationCriterionValueID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectEvaluationSelectedValue_ProjectEvaluationSelectedValueID] PRIMARY KEY CLUSTERED 
(
	[ProjectEvaluationSelectedValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectEvaluationSelectedValue_ProjectEvaluationSelectedValueID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectEvaluationSelectedValueID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluationSelectedValue_EvaluationCriterionValue_EvaluationCriterionValueID] FOREIGN KEY([EvaluationCriterionValueID])
REFERENCES [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID])
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue] CHECK CONSTRAINT [FK_ProjectEvaluationSelectedValue_EvaluationCriterionValue_EvaluationCriterionValueID]
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluationSelectedValue_EvaluationCriterionValue_EvaluationCriterionValueID_TenantID] FOREIGN KEY([EvaluationCriterionValueID], [TenantID])
REFERENCES [dbo].[EvaluationCriterionValue] ([EvaluationCriterionValueID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue] CHECK CONSTRAINT [FK_ProjectEvaluationSelectedValue_EvaluationCriterionValue_EvaluationCriterionValueID_TenantID]
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluationSelectedValue_ProjectEvaluation_ProjectEvaluationID] FOREIGN KEY([ProjectEvaluationID])
REFERENCES [dbo].[ProjectEvaluation] ([ProjectEvaluationID])
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue] CHECK CONSTRAINT [FK_ProjectEvaluationSelectedValue_ProjectEvaluation_ProjectEvaluationID]
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluationSelectedValue_ProjectEvaluation_ProjectEvaluationID_TenantID] FOREIGN KEY([ProjectEvaluationID], [TenantID])
REFERENCES [dbo].[ProjectEvaluation] ([ProjectEvaluationID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue] CHECK CONSTRAINT [FK_ProjectEvaluationSelectedValue_ProjectEvaluation_ProjectEvaluationID_TenantID]
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluationSelectedValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectEvaluationSelectedValue] CHECK CONSTRAINT [FK_ProjectEvaluationSelectedValue_Tenant_TenantID]