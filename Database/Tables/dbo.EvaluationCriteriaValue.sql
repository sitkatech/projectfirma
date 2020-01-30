SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluationCriteriaValue](
	[EvaluationCriteriaValueID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[EvaluationCriteriaID] [int] NOT NULL,
	[EvaluationCriteriaValueRating] [varchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EvaluationCriteriaValueDescription] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_EvaluationCriteriaValue_EvaluationCriteriaValueID] PRIMARY KEY CLUSTERED 
(
	[EvaluationCriteriaValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EvaluationCriteriaValue_EvaluationCriteriaValueID_TenantID] UNIQUE NONCLUSTERED 
(
	[EvaluationCriteriaValueID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EvaluationCriteriaValue]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriteriaValue_EvaluationCriteria_EvaluationCriteriaID] FOREIGN KEY([EvaluationCriteriaID])
REFERENCES [dbo].[EvaluationCriteria] ([EvaluationCriteriaID])
GO
ALTER TABLE [dbo].[EvaluationCriteriaValue] CHECK CONSTRAINT [FK_EvaluationCriteriaValue_EvaluationCriteria_EvaluationCriteriaID]
GO
ALTER TABLE [dbo].[EvaluationCriteriaValue]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriteriaValue_EvaluationCriteria_EvaluationCriteriaID_TenantID] FOREIGN KEY([EvaluationCriteriaID], [TenantID])
REFERENCES [dbo].[EvaluationCriteria] ([EvaluationCriteriaID], [TenantID])
GO
ALTER TABLE [dbo].[EvaluationCriteriaValue] CHECK CONSTRAINT [FK_EvaluationCriteriaValue_EvaluationCriteria_EvaluationCriteriaID_TenantID]
GO
ALTER TABLE [dbo].[EvaluationCriteriaValue]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriteriaValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[EvaluationCriteriaValue] CHECK CONSTRAINT [FK_EvaluationCriteriaValue_Tenant_TenantID]