SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonStewardWatershed](
	[PersonStewardWatershedID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[WatershedID] [int] NOT NULL,
 CONSTRAINT [PK_PersonStewardWatershed_PersonStewardWatershedID] PRIMARY KEY CLUSTERED 
(
	[PersonStewardWatershedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_PersonStewardWatershed_PersonStewardWatershedID_TenantID] UNIQUE NONCLUSTERED 
(
	[PersonStewardWatershedID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[PersonStewardWatershed]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardWatershed_Person_PersonID] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[PersonStewardWatershed] CHECK CONSTRAINT [FK_PersonStewardWatershed_Person_PersonID]
GO
ALTER TABLE [dbo].[PersonStewardWatershed]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardWatershed_Person_PersonID_TenantID] FOREIGN KEY([PersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[PersonStewardWatershed] CHECK CONSTRAINT [FK_PersonStewardWatershed_Person_PersonID_TenantID]
GO
ALTER TABLE [dbo].[PersonStewardWatershed]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardWatershed_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[PersonStewardWatershed] CHECK CONSTRAINT [FK_PersonStewardWatershed_Tenant_TenantID]
GO
ALTER TABLE [dbo].[PersonStewardWatershed]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardWatershed_Watershed_WatershedID] FOREIGN KEY([WatershedID])
REFERENCES [dbo].[Watershed] ([WatershedID])
GO
ALTER TABLE [dbo].[PersonStewardWatershed] CHECK CONSTRAINT [FK_PersonStewardWatershed_Watershed_WatershedID]
GO
ALTER TABLE [dbo].[PersonStewardWatershed]  WITH CHECK ADD  CONSTRAINT [FK_PersonStewardWatershed_WatershedID_TenantID] FOREIGN KEY([WatershedID], [TenantID])
REFERENCES [dbo].[Watershed] ([WatershedID], [TenantID])
GO
ALTER TABLE [dbo].[PersonStewardWatershed] CHECK CONSTRAINT [FK_PersonStewardWatershed_WatershedID_TenantID]