SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationProjectBudgetUpdate](
	[TransportationProjectBudgetUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[TransportationProjectCostTypeID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[BudgetedAmount] [money] NULL,
 CONSTRAINT [PK_TransportationProjectBudgetUpdate_TransportationProjectBudgetUpdateID] PRIMARY KEY CLUSTERED 
(
	[TransportationProjectBudgetUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationProjectBudgetUpdate_ProjectUpdateBatchID_FundingSourceID_TransportationProjectCostTypeID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[FundingSourceID] ASC,
	[TransportationProjectCostTypeID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TransportationProjectBudgetUpdate]  WITH CHECK ADD  CONSTRAINT [FK_TransportationProjectBudgetUpdate_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[TransportationProjectBudgetUpdate] CHECK CONSTRAINT [FK_TransportationProjectBudgetUpdate_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[TransportationProjectBudgetUpdate]  WITH CHECK ADD  CONSTRAINT [FK_TransportationProjectBudgetUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[TransportationProjectBudgetUpdate] CHECK CONSTRAINT [FK_TransportationProjectBudgetUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[TransportationProjectBudgetUpdate]  WITH CHECK ADD  CONSTRAINT [FK_TransportationProjectBudgetUpdate_TransportationProjectCostType_TransportationProjectCostTypeID] FOREIGN KEY([TransportationProjectCostTypeID])
REFERENCES [dbo].[TransportationProjectCostType] ([TransportationProjectCostTypeID])
GO
ALTER TABLE [dbo].[TransportationProjectBudgetUpdate] CHECK CONSTRAINT [FK_TransportationProjectBudgetUpdate_TransportationProjectCostType_TransportationProjectCostTypeID]