SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationAreaWatershed](
	[ProjectLocationAreaWatershedID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectLocationAreaID] [int] NOT NULL,
	[WatershedID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationAreaWatershed_ProjectLocationAreaWatershedID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationAreaWatershedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectLocationAreaWatershed_ProjectLocationAreaID_WatershedID] UNIQUE NONCLUSTERED 
(
	[ProjectLocationAreaID] ASC,
	[WatershedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaWatershed_ProjectLocationArea_ProjectLocationAreaID] FOREIGN KEY([ProjectLocationAreaID])
REFERENCES [dbo].[ProjectLocationArea] ([ProjectLocationAreaID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed] CHECK CONSTRAINT [FK_ProjectLocationAreaWatershed_ProjectLocationArea_ProjectLocationAreaID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaWatershed_ProjectLocationArea_ProjectLocationAreaID_TenantID] FOREIGN KEY([ProjectLocationAreaID], [TenantID])
REFERENCES [dbo].[ProjectLocationArea] ([ProjectLocationAreaID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed] CHECK CONSTRAINT [FK_ProjectLocationAreaWatershed_ProjectLocationArea_ProjectLocationAreaID_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaWatershed_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed] CHECK CONSTRAINT [FK_ProjectLocationAreaWatershed_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaWatershed_Watershed_WatershedID] FOREIGN KEY([WatershedID])
REFERENCES [dbo].[Watershed] ([WatershedID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed] CHECK CONSTRAINT [FK_ProjectLocationAreaWatershed_Watershed_WatershedID]
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationAreaWatershed_Watershed_WatershedID_TenantID] FOREIGN KEY([WatershedID], [TenantID])
REFERENCES [dbo].[Watershed] ([WatershedID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationAreaWatershed] CHECK CONSTRAINT [FK_ProjectLocationAreaWatershed_Watershed_WatershedID_TenantID]