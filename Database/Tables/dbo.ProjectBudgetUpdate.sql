SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectBudgetUpdate](
	[ProjectBudgetUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[ProjectCostTypeID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[BudgetedAmount] [money] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectBudgetUpdate_ProjectBudgetUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectBudgetUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectBudgetUpdate_ProjectUpdateBatchID_FundingSourceID_ProjectCostTypeID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[FundingSourceID] ASC,
	[ProjectCostTypeID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectBudgetUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetUpdate_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[ProjectBudgetUpdate] CHECK CONSTRAINT [FK_ProjectBudgetUpdate_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[ProjectBudgetUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetUpdate_ProjectCostType_ProjectCostTypeID] FOREIGN KEY([ProjectCostTypeID])
REFERENCES [dbo].[ProjectCostType] ([ProjectCostTypeID])
GO
ALTER TABLE [dbo].[ProjectBudgetUpdate] CHECK CONSTRAINT [FK_ProjectBudgetUpdate_ProjectCostType_ProjectCostTypeID]
GO
ALTER TABLE [dbo].[ProjectBudgetUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectBudgetUpdate] CHECK CONSTRAINT [FK_ProjectBudgetUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectBudgetUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectBudgetUpdate] CHECK CONSTRAINT [FK_ProjectBudgetUpdate_Tenant_TenantID]