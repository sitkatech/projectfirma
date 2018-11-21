SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectGeospatialAreaUpdate](
	[ProjectGeospatialAreaUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[GeospatialAreaID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectGeospatialAreaUpdate_ProjectGeospatialAreaUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectGeospatialAreaUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectGeospatialAreaUpdate_ProjectUpdateBatchID_GeospatialAreaID] UNIQUE NONCLUSTERED 
(
	[ProjectUpdateBatchID] ASC,
	[GeospatialAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaUpdate_GeospatialArea_GeospatialAreaID] FOREIGN KEY([GeospatialAreaID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaUpdate_GeospatialArea_GeospatialAreaID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaUpdate_GeospatialArea_GeospatialAreaID_TenantID] FOREIGN KEY([GeospatialAreaID], [TenantID])
REFERENCES [dbo].[GeospatialArea] ([GeospatialAreaID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaUpdate_GeospatialArea_GeospatialAreaID_TenantID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectGeospatialAreaUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectGeospatialAreaUpdate] CHECK CONSTRAINT [FK_ProjectGeospatialAreaUpdate_Tenant_TenantID]