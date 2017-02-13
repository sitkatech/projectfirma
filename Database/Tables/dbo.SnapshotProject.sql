SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SnapshotProject](
	[SnapshotProjectID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[SnapshotID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[SnapshotProjectTypeID] [int] NOT NULL,
 CONSTRAINT [PK_SnapshotProject_SnapshotProjectID] PRIMARY KEY CLUSTERED 
(
	[SnapshotProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SnapshotProject]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotProject_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[SnapshotProject] CHECK CONSTRAINT [FK_SnapshotProject_Project_ProjectID]
GO
ALTER TABLE [dbo].[SnapshotProject]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotProject_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[SnapshotProject] CHECK CONSTRAINT [FK_SnapshotProject_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[SnapshotProject]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotProject_Snapshot_SnapshotID] FOREIGN KEY([SnapshotID])
REFERENCES [dbo].[Snapshot] ([SnapshotID])
GO
ALTER TABLE [dbo].[SnapshotProject] CHECK CONSTRAINT [FK_SnapshotProject_Snapshot_SnapshotID]
GO
ALTER TABLE [dbo].[SnapshotProject]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotProject_Snapshot_SnapshotID_TenantID] FOREIGN KEY([SnapshotID], [TenantID])
REFERENCES [dbo].[Snapshot] ([SnapshotID], [TenantID])
GO
ALTER TABLE [dbo].[SnapshotProject] CHECK CONSTRAINT [FK_SnapshotProject_Snapshot_SnapshotID_TenantID]
GO
ALTER TABLE [dbo].[SnapshotProject]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotProject_SnapshotProjectType_SnapshotProjectTypeID] FOREIGN KEY([SnapshotProjectTypeID])
REFERENCES [dbo].[SnapshotProjectType] ([SnapshotProjectTypeID])
GO
ALTER TABLE [dbo].[SnapshotProject] CHECK CONSTRAINT [FK_SnapshotProject_SnapshotProjectType_SnapshotProjectTypeID]
GO
ALTER TABLE [dbo].[SnapshotProject]  WITH CHECK ADD  CONSTRAINT [FK_SnapshotProject_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SnapshotProject] CHECK CONSTRAINT [FK_SnapshotProject_Tenant_TenantID]