SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationTypeOrganizationRelationshipType](
	[OrganizationTypeOrganizationRelationshipTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationTypeID] [int] NOT NULL,
	[OrganizationRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_OrganizationTypeOrganizationRelationshipType_OrganizationTypeOrganizationRelationshipTypeID] PRIMARY KEY CLUSTERED 
(
	[OrganizationTypeOrganizationRelationshipTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_OrganizationTypeOrganizationRelationshipType_OrganizationTypeID_OrganizationRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[OrganizationTypeID] ASC,
	[OrganizationRelationshipTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_OrganizationTypeOrganizationRelationshipType_OrganizationTypeOrganizationRelationshipTypeID_TenantID] UNIQUE NONCLUSTERED 
(
	[OrganizationTypeOrganizationRelationshipTypeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_OrganizationRelationshipType_OrganizationRelationshipTypeID] FOREIGN KEY([OrganizationRelationshipTypeID])
REFERENCES [dbo].[OrganizationRelationshipType] ([OrganizationRelationshipTypeID])
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType] CHECK CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_OrganizationRelationshipType_OrganizationRelationshipTypeID]
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID] FOREIGN KEY([OrganizationRelationshipTypeID], [TenantID])
REFERENCES [dbo].[OrganizationRelationshipType] ([OrganizationRelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType] CHECK CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID]
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_OrganizationType_OrganizationTypeID] FOREIGN KEY([OrganizationTypeID])
REFERENCES [dbo].[OrganizationType] ([OrganizationTypeID])
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType] CHECK CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_OrganizationType_OrganizationTypeID]
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_OrganizationType_OrganizationTypeID_TenantID] FOREIGN KEY([OrganizationTypeID], [TenantID])
REFERENCES [dbo].[OrganizationType] ([OrganizationTypeID], [TenantID])
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType] CHECK CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_OrganizationType_OrganizationTypeID_TenantID]
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType]  WITH CHECK ADD  CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[OrganizationTypeOrganizationRelationshipType] CHECK CONSTRAINT [FK_OrganizationTypeOrganizationRelationshipType_Tenant_TenantID]