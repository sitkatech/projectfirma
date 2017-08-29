SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProposedProjectOrganization](
	[ProposedProjectOrganizationID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProposedProjectID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[RelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProposedProjectOrganization_ProposedProjectOrganizationID] PRIMARY KEY CLUSTERED 
(
	[ProposedProjectOrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProposedProjectOrganization_ProposedProjectOrganization_TenantID] UNIQUE NONCLUSTERED 
(
	[ProposedProjectOrganizationID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProposedProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectOrganization_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[ProposedProjectOrganization] CHECK CONSTRAINT [FK_ProposedProjectOrganization_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[ProposedProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectOrganization_Organization_OrganizationID_Tenant_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectOrganization] CHECK CONSTRAINT [FK_ProposedProjectOrganization_Organization_OrganizationID_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectOrganization_ProposedProject_ProposedProjectID] FOREIGN KEY([ProposedProjectID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID])
GO
ALTER TABLE [dbo].[ProposedProjectOrganization] CHECK CONSTRAINT [FK_ProposedProjectOrganization_ProposedProject_ProposedProjectID]
GO
ALTER TABLE [dbo].[ProposedProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectOrganization_ProposedProject_ProposedProjectID_Tenant_TenantID] FOREIGN KEY([ProposedProjectID], [TenantID])
REFERENCES [dbo].[ProposedProject] ([ProposedProjectID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectOrganization] CHECK CONSTRAINT [FK_ProposedProjectOrganization_ProposedProject_ProposedProjectID_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectOrganization_RelationshipType_RelationshipTypeID] FOREIGN KEY([RelationshipTypeID])
REFERENCES [dbo].[RelationshipType] ([RelationshipTypeID])
GO
ALTER TABLE [dbo].[ProposedProjectOrganization] CHECK CONSTRAINT [FK_ProposedProjectOrganization_RelationshipType_RelationshipTypeID]
GO
ALTER TABLE [dbo].[ProposedProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectOrganization_RelationshipType_RelationshipTypeID_Tenant_TenantID] FOREIGN KEY([RelationshipTypeID], [TenantID])
REFERENCES [dbo].[RelationshipType] ([RelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectOrganization] CHECK CONSTRAINT [FK_ProposedProjectOrganization_RelationshipType_RelationshipTypeID_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProposedProjectOrganization]  WITH CHECK ADD  CONSTRAINT [FK_ProposedProjectOrganization_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProposedProjectOrganization] CHECK CONSTRAINT [FK_ProposedProjectOrganization_Tenant_TenantID]