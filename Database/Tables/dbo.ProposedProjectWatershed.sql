SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectWatershed](
	[ProposedProjectWatershedID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[WatershedID] [int] NOT NULL,
 CONSTRAINT [PK_ProposedProjectWatershed_ProposedProjectWatershedID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectWatershedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProjectWatershed_ProposedProjectID_WatershedID] UNIQUE NONCLUSTERED 
(
	[ProposedProjectID] ASC,
	[WatershedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectWatershed_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectWatershed] CHECK CONSTRAINT [FK_ProposedProjectWatershed_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectWatershed_ProposedProject_ProposedProjectID_TenantID] FOREIGN KEY([ProposedProjectID], [TenantID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectWatershed] CHECK CONSTRAINT [FK_ProposedProjectWatershed_ProposedProject_ProposedProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectWatershed_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectWatershed] CHECK CONSTRAINT [FK_ProposedProjectWatershed_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectWatershed_Watershed_WatershedID] FOREIGN KEY([WatershedID])
REFERENCES [dbo].[Watershed] ([WatershedID])
GO
ALTER TABLE [dbo].[ProposedProjectWatershed] CHECK CONSTRAINT [FK_ProposedProjectWatershed_Watershed_WatershedID]
GO
ALTER TABLE [dbo].[ProposedProjectWatershed]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectWatershed_Watershed_WatershedID_TenantID] FOREIGN KEY([WatershedID], [TenantID])
REFERENCES [dbo].[Watershed] ([WatershedID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectWatershed] CHECK CONSTRAINT [FK_ProposedProjectWatershed_Watershed_WatershedID_TenantID]