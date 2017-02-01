SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyTierThreeImage](
	[TaxonomyTierThreeImageID] [int] IDENTITY(1,1) NOT NULL,
	[TaxonomyTierThreeID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_TaxonomyTierThreeImage_TaxonomyTierThreeImageID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyTierThreeImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierThreeImage_TaxonomyTierThreeImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierThreeImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyTierThreeImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierThreeImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TaxonomyTierThreeImage] CHECK CONSTRAINT [FK_TaxonomyTierThreeImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[TaxonomyTierThreeImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierThreeImage_TaxonomyTierThree_TaxonomyTierThreeID] FOREIGN KEY([TaxonomyTierThreeID])
REFERENCES [dbo].[TaxonomyTierThree] ([TaxonomyTierThreeID])
GO
ALTER TABLE [dbo].[TaxonomyTierThreeImage] CHECK CONSTRAINT [FK_TaxonomyTierThreeImage_TaxonomyTierThree_TaxonomyTierThreeID]
GO
ALTER TABLE [dbo].[TaxonomyTierThreeImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierThreeImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierThreeImage] CHECK CONSTRAINT [FK_TaxonomyTierThreeImage_Tenant_TenantID]