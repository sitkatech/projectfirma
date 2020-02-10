SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluationCriteria](
	[EvaluationCriteriaID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[EvaluationID] [int] NOT NULL,
	[EvaluationCriteriaName] [varchar](120) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EvaluationCriteriaDefinition] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_EvaluationCriteria_EvaluationCriteriaID] PRIMARY KEY CLUSTERED 
(
	[EvaluationCriteriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EvaluationCriteria_EvaluationCriteriaID_TenantID] UNIQUE NONCLUSTERED 
(
	[EvaluationCriteriaID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EvaluationCriteria]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriteria_Evaluation_EvaluationID] FOREIGN KEY([EvaluationID])
REFERENCES [dbo].[Evaluation] ([EvaluationID])
GO
ALTER TABLE [dbo].[EvaluationCriteria] CHECK CONSTRAINT [FK_EvaluationCriteria_Evaluation_EvaluationID]
GO
ALTER TABLE [dbo].[EvaluationCriteria]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriteria_Evaluation_EvaluationID_TenantID] FOREIGN KEY([EvaluationID], [TenantID])
REFERENCES [dbo].[Evaluation] ([EvaluationID], [TenantID])
GO
ALTER TABLE [dbo].[EvaluationCriteria] CHECK CONSTRAINT [FK_EvaluationCriteria_Evaluation_EvaluationID_TenantID]
GO
ALTER TABLE [dbo].[EvaluationCriteria]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriteria_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[EvaluationCriteria] CHECK CONSTRAINT [FK_EvaluationCriteria_Tenant_TenantID]