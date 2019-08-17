SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectFundingSourceExpenditureUpdate](
	[ProjectFundingSourceExpenditureUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[ExpenditureAmount] [money] NOT NULL,
	[CostTypeID] [int] NULL,
 CONSTRAINT [PK_ProjectFundingSourceExpenditureUpdate_ProjectFundingSourceExpenditureUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectFundingSourceExpenditureUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatchID_FundingSourceID_CostTypeID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[FundingSourceID] ASC,
	[CostTypeID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_CostType_CostTypeID] FOREIGN KEY([CostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_CostType_CostTypeID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_CostType_CostTypeID_TenantID] FOREIGN KEY([CostTypeID], [TenantID])
REFERENCES [dbo].[CostType] ([CostTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_CostType_CostTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_FundingSource_FundingSourceID_TenantID] FOREIGN KEY([FundingSourceID], [TenantID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_FundingSource_FundingSourceID_TenantID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectFundingSourceExpenditureUpdate] CHECK CONSTRAINT [FK_ProjectFundingSourceExpenditureUpdate_Tenant_TenantID]