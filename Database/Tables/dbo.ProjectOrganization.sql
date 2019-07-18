SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectOrganization](
	[ProjectOrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[OrganizationRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectOrganization_ProjectOrganizationID] PRIMARY KEY CLUSTERED 
(
	[ProjectOrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectOrganization_ProjectOrganizationID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectOrganizationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganization_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[ProjectOrganization] CHECK CONSTRAINT [FK_ProjectOrganization_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[ProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganization_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectOrganization] CHECK CONSTRAINT [FK_ProjectOrganization_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[ProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganization_OrganizationRelationshipType_OrganizationRelationshipTypeID] FOREIGN KEY([OrganizationRelationshipTypeID])
REFERENCES [dbo].[OrganizationRelationshipType] ([OrganizationRelationshipTypeID])
GO
ALTER TABLE [dbo].[ProjectOrganization] CHECK CONSTRAINT [FK_ProjectOrganization_OrganizationRelationshipType_OrganizationRelationshipTypeID]
GO
ALTER TABLE [dbo].[ProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganization_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID] FOREIGN KEY([OrganizationRelationshipTypeID], [TenantID])
REFERENCES [dbo].[OrganizationRelationshipType] ([OrganizationRelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectOrganization] CHECK CONSTRAINT [FK_ProjectOrganization_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganization_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectOrganization] CHECK CONSTRAINT [FK_ProjectOrganization_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganization_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectOrganization] CHECK CONSTRAINT [FK_ProjectOrganization_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[ProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganization_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectOrganization] CHECK CONSTRAINT [FK_ProjectOrganization_Tenant_TenantID]