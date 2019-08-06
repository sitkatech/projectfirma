SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectRelevantCostTypeUpdate](
	[ProjectRelevantCostTypeUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[CostTypeID] [int] NOT NULL,
	[ProjectRelevantCostTypeGroupID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectRelevantCostTypeUpdate_ProjectRelevantCostTypeUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectRelevantCostTypeUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatchID_CostTypeID_ProjectRelevantCostTypeGroupID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[CostTypeID] ASC,
	[ProjectRelevantCostTypeGroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_CostType_CostTypeID] FOREIGN KEY([CostTypeID])
REFERENCES [dbo].[CostType] ([CostTypeID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate] CHECK CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_CostType_CostTypeID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_CostType_CostTypeID_TenantID] FOREIGN KEY([CostTypeID], [TenantID])
REFERENCES [dbo].[CostType] ([CostTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate] CHECK CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_CostType_CostTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupID] FOREIGN KEY([ProjectRelevantCostTypeGroupID])
REFERENCES [dbo].[ProjectRelevantCostTypeGroup] ([ProjectRelevantCostTypeGroupID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate] CHECK CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_ProjectRelevantCostTypeGroup_ProjectRelevantCostTypeGroupID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate] CHECK CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate] CHECK CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectRelevantCostTypeUpdate] CHECK CONSTRAINT [FK_ProjectRelevantCostTypeUpdate_Tenant_TenantID]