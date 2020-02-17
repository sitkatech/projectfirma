SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectEvaluation](
	[ProjectEvaluationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[EvaluationID] [int] NOT NULL,
	[Comments] [varchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_ProjectEvaluation_ProjectEvaluationID] PRIMARY KEY CLUSTERED 
(
	[ProjectEvaluationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectEvaluation_EvaluationID_ProjectID] UNIQUE NONCLUSTERED 
(
	[EvaluationID] ASC,
	[ProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectEvaluation_ProjectEvaluationID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectEvaluationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluation_Evaluation_EvaluationID] FOREIGN KEY([EvaluationID])
REFERENCES [dbo].[Evaluation] ([EvaluationID])
GO
ALTER TABLE [dbo].[ProjectEvaluation] CHECK CONSTRAINT [FK_ProjectEvaluation_Evaluation_EvaluationID]
GO
ALTER TABLE [dbo].[ProjectEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluation_Evaluation_EvaluationID_TenantID] FOREIGN KEY([EvaluationID], [TenantID])
REFERENCES [dbo].[Evaluation] ([EvaluationID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectEvaluation] CHECK CONSTRAINT [FK_ProjectEvaluation_Evaluation_EvaluationID_TenantID]
GO
ALTER TABLE [dbo].[ProjectEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluation_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectEvaluation] CHECK CONSTRAINT [FK_ProjectEvaluation_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluation_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectEvaluation] CHECK CONSTRAINT [FK_ProjectEvaluation_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectEvaluation]  WITH CHECK ADD  CONSTRAINT [FK_ProjectEvaluation_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectEvaluation] CHECK CONSTRAINT [FK_ProjectEvaluation_Tenant_TenantID]