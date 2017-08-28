SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectWatershedUpdate](
	[ProjectWatershedUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[WatershedID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectWatershedUpdate_ProjectWatershedUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectWatershedUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectWatershedUpdate_ProjectUpdateBatchID_WatershedID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[WatershedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectWatershedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate] CHECK CONSTRAINT [FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate] CHECK CONSTRAINT [FK_ProjectWatershedUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershedUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate] CHECK CONSTRAINT [FK_ProjectWatershedUpdate_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershedUpdate_Watershed_WatershedID] FOREIGN KEY([WatershedID])
REFERENCES [dbo].[Watershed] ([WatershedID])
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate] CHECK CONSTRAINT [FK_ProjectWatershedUpdate_Watershed_WatershedID]
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershedUpdate_Watershed_WatershedID_TenantID] FOREIGN KEY([WatershedID], [TenantID])
REFERENCES [dbo].[Watershed] ([WatershedID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectWatershedUpdate] CHECK CONSTRAINT [FK_ProjectWatershedUpdate_Watershed_WatershedID_TenantID]