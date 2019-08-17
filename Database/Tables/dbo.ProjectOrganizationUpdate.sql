SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectOrganizationUpdate](
	[ProjectOrganizationUpdateID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectUpdateBatchID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[OrganizationRelationshipTypeID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectOrganizationUpdate_ProjectOrganizationUpdateID] PRIMARY KEY CLUSTERED 
(
	[ProjectOrganizationUpdateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectOrganizationUpdate_ProjectOrganizationUpdateID_TenantID] UNIQUE NONCLUSTERED 
(
	[ProjectOrganizationUpdateID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganizationUpdate_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate] CHECK CONSTRAINT [FK_ProjectOrganizationUpdate_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganizationUpdate_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate] CHECK CONSTRAINT [FK_ProjectOrganizationUpdate_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganizationUpdate_OrganizationRelationshipType_OrganizationRelationshipTypeID] FOREIGN KEY([OrganizationRelationshipTypeID])
REFERENCES [dbo].[OrganizationRelationshipType] ([OrganizationRelationshipTypeID])
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate] CHECK CONSTRAINT [FK_ProjectOrganizationUpdate_OrganizationRelationshipType_OrganizationRelationshipTypeID]
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganizationUpdate_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID] FOREIGN KEY([OrganizationRelationshipTypeID], [TenantID])
REFERENCES [dbo].[OrganizationRelationshipType] ([OrganizationRelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate] CHECK CONSTRAINT [FK_ProjectOrganizationUpdate_OrganizationRelationshipType_OrganizationRelationshipTypeID_TenantID]
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID] FOREIGN KEY([ProjectUpdateBatchID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID])
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate] CHECK CONSTRAINT [FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID]
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID] FOREIGN KEY([ProjectUpdateBatchID], [TenantID])
REFERENCES [dbo].[ProjectUpdateBatch] ([ProjectUpdateBatchID], [TenantID])
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate] CHECK CONSTRAINT [FK_ProjectOrganizationUpdate_ProjectUpdateBatch_ProjectUpdateBatchID_TenantID]
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate]  WITH CHECK ADD  CONSTRAINT [FK_ProjectOrganizationUpdate_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectOrganizationUpdate] CHECK CONSTRAINT [FK_ProjectOrganizationUpdate_Tenant_TenantID]