SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttachmentTypeTaxonomyTrunk](
	[AttachmentTypeTaxonomyTrunkID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[AttachmentTypeID] [int] NOT NULL,
	[TaxonomyTrunkID] [int] NOT NULL,
 CONSTRAINT [PK_AttachmentTypeTaxonomyTrunk_AttachmentTypeTaxonomyTrunkID] PRIMARY KEY CLUSTERED 
(
	[AttachmentTypeTaxonomyTrunkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_AttachmentType_AttachmentTypeID] FOREIGN KEY([AttachmentTypeID])
REFERENCES [dbo].[AttachmentType] ([AttachmentTypeID])
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_AttachmentType_AttachmentTypeID]
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_AttachmentType_AttachmentTypeID_TenantID] FOREIGN KEY([AttachmentTypeID], [TenantID])
REFERENCES [dbo].[AttachmentType] ([AttachmentTypeID], [TenantID])
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_AttachmentType_AttachmentTypeID_TenantID]
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID] FOREIGN KEY([TaxonomyTrunkID])
REFERENCES [dbo].[TaxonomyTrunk] ([TaxonomyTrunkID])
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID]
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID] FOREIGN KEY([TaxonomyTrunkID], [TenantID])
REFERENCES [dbo].[TaxonomyTrunk] ([TaxonomyTrunkID], [TenantID])
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID]
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[AttachmentTypeTaxonomyTrunk] CHECK CONSTRAINT [FK_AttachmentTypeTaxonomyTrunk_Tenant_TenantID]