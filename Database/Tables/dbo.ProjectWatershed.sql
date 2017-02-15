SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectWatershed](
	[ProjectWatershedID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[WatershedID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectWatershed_ProjectWatershedID] PRIMARY KEY CLUSTERED 
(
	[ProjectWatershedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectWatershed_ProjectID_WatershedID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[WatershedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershed_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectWatershed] CHECK CONSTRAINT [FK_ProjectWatershed_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershed_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectWatershed] CHECK CONSTRAINT [FK_ProjectWatershed_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershed_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectWatershed] CHECK CONSTRAINT [FK_ProjectWatershed_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershed_Watershed_WatershedID] FOREIGN KEY([WatershedID])
REFERENCES [dbo].[Watershed] ([WatershedID])
GO
ALTER TABLE [dbo].[ProjectWatershed] CHECK CONSTRAINT [FK_ProjectWatershed_Watershed_WatershedID]
GO
ALTER TABLE [dbo].[ProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectWatershed_Watershed_WatershedID_TenantID] FOREIGN KEY([WatershedID], [TenantID])
REFERENCES [dbo].[Watershed] ([WatershedID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectWatershed] CHECK CONSTRAINT [FK_ProjectWatershed_Watershed_WatershedID_TenantID]