SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluationCriterionValue](
	[EvaluationCriterionValueID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[EvaluationCriterionID] [int] NOT NULL,
	[EvaluationCriterionValueRating] [varchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[EvaluationCriterionValueDescription] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SortOrder] [int] NULL,
 CONSTRAINT [PK_EvaluationCriterionValue_EvaluationCriterionValueID] PRIMARY KEY CLUSTERED 
(
	[EvaluationCriterionValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_EvaluationCriterionValue_EvaluationCriterionValueID_TenantID] UNIQUE NONCLUSTERED 
(
	[EvaluationCriterionValueID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[EvaluationCriterionValue]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriterionValue_EvaluationCriterion_EvaluationCriterionID] FOREIGN KEY([EvaluationCriterionID])
REFERENCES [dbo].[EvaluationCriterion] ([EvaluationCriterionID])
GO
ALTER TABLE [dbo].[EvaluationCriterionValue] CHECK CONSTRAINT [FK_EvaluationCriterionValue_EvaluationCriterion_EvaluationCriterionID]
GO
ALTER TABLE [dbo].[EvaluationCriterionValue]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriterionValue_EvaluationCriterion_EvaluationCriterionID_TenantID] FOREIGN KEY([EvaluationCriterionID], [TenantID])
REFERENCES [dbo].[EvaluationCriterion] ([EvaluationCriterionID], [TenantID])
GO
ALTER TABLE [dbo].[EvaluationCriterionValue] CHECK CONSTRAINT [FK_EvaluationCriterionValue_EvaluationCriterion_EvaluationCriterionID_TenantID]
GO
ALTER TABLE [dbo].[EvaluationCriterionValue]  WITH CHECK ADD  CONSTRAINT [FK_EvaluationCriterionValue_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[EvaluationCriterionValue] CHECK CONSTRAINT [FK_EvaluationCriterionValue_Tenant_TenantID]