SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectExpenditureRelevantCostType](
	[ProjectExpenditureRelevantCostTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[CostTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectExpenditureRelevantCostType_ProjectExpenditureRelevantCostTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectExpenditureRelevantCostTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectExpenditureRelevantCostType_ProjectID_CostTypeID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[CostTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExpenditureRelevantCostType_CostType_CostTypeID] FOREIGN KEY([CostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType] CHECK CONSTRAINT [FK_ProjectExpenditureRelevantCostType_CostType_CostTypeID]
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExpenditureRelevantCostType_CostType_CostTypeID_TenantID] FOREIGN KEY([CostTypeID], [TenantID])
REFERENCES [dbo].[CostType] ([CostTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType] CHECK CONSTRAINT [FK_ProjectExpenditureRelevantCostType_CostType_CostTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExpenditureRelevantCostType_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType] CHECK CONSTRAINT [FK_ProjectExpenditureRelevantCostType_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExpenditureRelevantCostType_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType] CHECK CONSTRAINT [FK_ProjectExpenditureRelevantCostType_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectExpenditureRelevantCostType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectExpenditureRelevantCostType] CHECK CONSTRAINT [FK_ProjectExpenditureRelevantCostType_Tenant_TenantID]