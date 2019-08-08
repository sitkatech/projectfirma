SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk](
	[AttachmentRelationshipTypeTaxonomyTrunkID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AttachmentRelationshipTypeID] [int] NOT NULL,
	[TaxonomyTrunkID] [int] NOT NULL,
 CONSTRAINT [PK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipTypeTaxonomyTrunkID] PRIMARY KEY CLUSTERED 
(
	[AttachmentRelationshipTypeTaxonomyTrunkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID] FOREIGN KEY([AttachmentRelationshipTypeID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID]
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID] FOREIGN KEY([AttachmentRelationshipTypeID], [TenantID])
REFERENCES [dbo].[AttachmentRelationshipType] ([AttachmentRelationshipTypeID], [TenantID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_AttachmentRelationshipType_AttachmentRelationshipTypeID_TenantID]
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID] FOREIGN KEY([TaxonomyTrunkID])
REFERENCES [dbo].[TaxonomyTrunk] ([TaxonomyTrunkID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID]
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID] FOREIGN KEY([TaxonomyTrunkID], [TenantID])
REFERENCES [dbo].[TaxonomyTrunk] ([TaxonomyTrunkID], [TenantID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID]
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AttachmentRelationshipTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentRelationshipTypeTaxonomyTrunk_Tenant_TenantID]