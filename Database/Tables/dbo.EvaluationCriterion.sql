SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluationCriterion](
	[EvaluationCriterionID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[EvaluationID] [int] NOT NULL,
	[EvaluationCriterionName] [varchar](120) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EvaluationCriterionDefinition] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_EvaluationCriterion_EvaluationCriterionID] PRIMARY KEY CLUSTERED 
(
	[EvaluationCriterionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EvaluationCriterion_EvaluationCriterionID_TenantID] UNIQUE NONCLUSTERED 
(
	[EvaluationCriterionID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EvaluationCriterion]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriterion_Evaluation_EvaluationID] FOREIGN KEY([EvaluationID])
REFERENCES [dbo].[Evaluation] ([EvaluationID])
GO
ALTER TABLE [dbo].[EvaluationCriterion] CHECK CONSTRAINT [FK_EvaluationCriterion_Evaluation_EvaluationID]
GO
ALTER TABLE [dbo].[EvaluationCriterion]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriterion_Evaluation_EvaluationID_TenantID] FOREIGN KEY([EvaluationID], [TenantID])
REFERENCES [dbo].[Evaluation] ([EvaluationID], [TenantID])
GO
ALTER TABLE [dbo].[EvaluationCriterion] CHECK CONSTRAINT [FK_EvaluationCriterion_Evaluation_EvaluationID_TenantID]
GO
ALTER TABLE [dbo].[EvaluationCriterion]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriterion_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[EvaluationCriterion] CHECK CONSTRAINT [FK_EvaluationCriterion_Tenant_TenantID]