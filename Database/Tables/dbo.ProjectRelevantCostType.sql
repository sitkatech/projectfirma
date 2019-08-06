SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectRelevantCostType](
	[ProjectRelevantCostTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[CostTypeID] [int] NOT NULL,
	[ProjectRelevantCostTypeGroupID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectRelevantCostType_ProjectRelevantCostTypeID] PRIMARY KEY CLUSTERED 
(
	[ProjectRelevantCostTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectRelevantCostType_ProjectID_CostTypeID_ProjectRelevantCostTypeGroupID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[CostTypeID] ASC,
	[ProjectRelevantCostTypeGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostType_CostType_CostTypeID] FOREIGN KEY([CostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostType] CHECK CONSTRAINT [FK_ProjectRelevantCostType_CostType_CostTypeID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostType_CostType_CostTypeID_TenantID] FOREIGN KEY([CostTypeID], [TenantID])
REFERENCES [dbo].[CostType] ([CostTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostType] CHECK CONSTRAINT [FK_ProjectRelevantCostType_CostType_CostTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostType_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostType] CHECK CONSTRAINT [FK_ProjectRelevantCostType_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostType_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostType] CHECK CONSTRAINT [FK_ProjectRelevantCostType_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostType_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupID] FOREIGN KEY([ProjectRelevantCostTypeGroupID])
REFERENCES [dbo].[ProjectRelevantCostTypeGroup] ([ProjectRelevantCostTypeGroupID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostType] CHECK CONSTRAINT [FK_ProjectRelevantCostType_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostType]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostType] CHECK CONSTRAINT [FK_ProjectRelevantCostType_Tenant_TenantID]