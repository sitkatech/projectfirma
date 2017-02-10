SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyTierOneImage](
	[TaxonomyTierOneImageID] [int] IDENTITY(1,1) NOT NULL,
	[TaxonomyTierOneID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_TaxonomyTierOneImage_TaxonomyTierOneImageID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyTierOneImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierOneImage_TaxonomyTierOneImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierOneImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyTierOneImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierOneImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TaxonomyTierOneImage] CHECK CONSTRAINT [FK_TaxonomyTierOneImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[TaxonomyTierOneImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierOneImage_TaxonomyTierOne_TaxonomyTierOneID] FOREIGN KEY([TaxonomyTierOneID])
REFERENCES [dbo].[TaxonomyTierOne] ([TaxonomyTierOneID])
GO
ALTER TABLE [dbo].[TaxonomyTierOneImage] CHECK CONSTRAINT [FK_TaxonomyTierOneImage_TaxonomyTierOne_TaxonomyTierOneID]
GO
ALTER TABLE [dbo].[TaxonomyTierOneImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierOneImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierOneImage] CHECK CONSTRAINT [FK_TaxonomyTierOneImage_Tenant_TenantID]