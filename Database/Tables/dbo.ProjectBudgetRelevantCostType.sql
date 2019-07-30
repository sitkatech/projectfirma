SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectBudgetRelevantCostType](
	[ProjectBudgetRelevantCostTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[CostTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectBudgetRelevantCostType_ProjectBudgetRelevantCostTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectBudgetRelevantCostTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectBudgetRelevantCostType_ProjectID_CostTypeID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[CostTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetRelevantCostType_CostType_CostTypeID] FOREIGN KEY([CostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType] CHECK CONSTRAINT [FK_ProjectBudgetRelevantCostType_CostType_CostTypeID]
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetRelevantCostType_CostType_CostTypeID_TenantID] FOREIGN KEY([CostTypeID], [TenantID])
REFERENCES [dbo].[CostType] ([CostTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType] CHECK CONSTRAINT [FK_ProjectBudgetRelevantCostType_CostType_CostTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetRelevantCostType_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType] CHECK CONSTRAINT [FK_ProjectBudgetRelevantCostType_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetRelevantCostType_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType] CHECK CONSTRAINT [FK_ProjectBudgetRelevantCostType_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectBudgetRelevantCostType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectBudgetRelevantCostType] CHECK CONSTRAINT [FK_ProjectBudgetRelevantCostType_Tenant_TenantID]