SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationBoundaryStaging](
	[OrganizationBoundaryStagingID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[FeatureClassName] [varchar](255) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[GeoJson] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_OrganizationBoundaryStaging_OrganizationBoundaryStagingID] PRIMARY KEY CLUSTERED 
(
	[OrganizationBoundaryStagingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrganizationBoundaryStaging]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationBoundaryStaging_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[OrganizationBoundaryStaging] CHECK CONSTRAINT [FK_OrganizationBoundaryStaging_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[OrganizationBoundaryStaging]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationBoundaryStaging_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[OrganizationBoundaryStaging] CHECK CONSTRAINT [FK_OrganizationBoundaryStaging_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[OrganizationBoundaryStaging]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationBoundaryStaging_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[OrganizationBoundaryStaging] CHECK CONSTRAINT [FK_OrganizationBoundaryStaging_Tenant_TenantID]