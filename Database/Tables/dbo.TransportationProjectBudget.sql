SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransportationProjectBudget](
	[TransportationProjectBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[TransportationProjectCostTypeID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[BudgetedAmount] [money] NOT NULL,
 CONSTRAINT [PK_TransportationProjectBudget_TransportationProjectBudgetID] PRIMARY KEY CLUSTERED 
(
	[TransportationProjectBudgetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TransportationProjectBudget_ProjectID_FundingSourceID_TransportationProjectCostTypeID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[FundingSourceID] ASC,
	[TransportationProjectCostTypeID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TransportationProjectBudget]  WITH CHECK ADD  CONSTRAINT [FK_TransportationProjectBudget_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[TransportationProjectBudget] CHECK CONSTRAINT [FK_TransportationProjectBudget_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[TransportationProjectBudget]  WITH CHECK ADD  CONSTRAINT [FK_TransportationProjectBudget_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[TransportationProjectBudget] CHECK CONSTRAINT [FK_TransportationProjectBudget_Project_ProjectID]
GO
ALTER TABLE [dbo].[TransportationProjectBudget]  WITH CHECK ADD  CONSTRAINT [FK_TransportationProjectBudget_TransportationProjectCostType_TransportationProjectCostTypeID] FOREIGN KEY([TransportationProjectCostTypeID])
REFERENCES [dbo].[TransportationProjectCostType] ([TransportationProjectCostTypeID])
GO
ALTER TABLE [dbo].[TransportationProjectBudget] CHECK CONSTRAINT [FK_TransportationProjectBudget_TransportationProjectCostType_TransportationProjectCostTypeID]