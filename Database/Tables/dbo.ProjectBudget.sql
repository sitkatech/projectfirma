SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectBudget](
	[ProjectBudgetID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
	[FundingSourceID] [int] NOT NULL,
	[ProjectCostTypeID] [int] NOT NULL,
	[CalendarYear] [int] NOT NULL,
	[BudgetedAmount] [money] NOT NULL,
 CONSTRAINT [PK_ProjectBudget_ProjectBudgetID] PRIMARY KEY CLUSTERED 
(
	[ProjectBudgetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectBudget_ProjectID_FundingSourceID_ProjectCostTypeID_CalendarYear] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[FundingSourceID] ASC,
	[ProjectCostTypeID] ASC,
	[CalendarYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudget_FundingSource_FundingSourceID] FOREIGN KEY([FundingSourceID])
REFERENCES [dbo].[FundingSource] ([FundingSourceID])
GO
ALTER TABLE [dbo].[ProjectBudget] CHECK CONSTRAINT [FK_ProjectBudget_FundingSource_FundingSourceID]
GO
ALTER TABLE [dbo].[ProjectBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudget_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectBudget] CHECK CONSTRAINT [FK_ProjectBudget_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectBudget]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudget_ProjectCostType_ProjectCostTypeID] FOREIGN KEY([ProjectCostTypeID])
REFERENCES [dbo].[ProjectCostType] ([ProjectCostTypeID])
GO
ALTER TABLE [dbo].[ProjectBudget] CHECK CONSTRAINT [FK_ProjectBudget_ProjectCostType_ProjectCostTypeID]