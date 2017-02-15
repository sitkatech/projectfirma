SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectLocationStaging](
	[ProposedProjectLocationStagingID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[PersonID] [int] NOT NULL,
	[FeatureClassName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeoJson] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SelectedProperty] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShouldImport] [bit] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProposedProjectLocationStaging_ProposedProjectLocationStagingID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectLocationStagingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProjectLocationStaging_ProposedProjectID_PersonID_FeatureClassName] UNIQUE NONCLUSTERED 
(
	[ProposedProjectID] ASC,
	[PersonID] ASC,
	[FeatureClassName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectLocationStaging]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectLocationStaging_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectLocationStaging] CHECK CONSTRAINT [FK_ProposedProjectLocationStaging_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectLocationStaging]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectLocationStaging_ProposedProject_ProposedProjectID_TenantID] FOREIGN KEY([ProposedProjectID], [TenantID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectLocationStaging] CHECK CONSTRAINT [FK_ProposedProjectLocationStaging_ProposedProject_ProposedProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectLocationStaging]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectLocationStaging_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectLocationStaging] CHECK CONSTRAINT [FK_ProposedProjectLocationStaging_Tenant_TenantID]