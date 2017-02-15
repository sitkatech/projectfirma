SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyTierTwoImage](
	[TaxonomyTierTwoImageID] [int] IDENTITY(1,1) NOT NULL,
	[TaxonomyTierTwoID] [int] NOT NULL,
	[FileResourceID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_TaxonomyTierTwoImage_TaxonomyTierTwoImageID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyTierTwoImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierTwoImage_TaxonomyTierTwoImageID_FileResourceID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierTwoImageID] ASC,
	[FileResourceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwoImage_FileResource_FileResourceID] FOREIGN KEY([FileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage] CHECK CONSTRAINT [FK_TaxonomyTierTwoImage_FileResource_FileResourceID]
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwoImage_FileResource_FileResourceID_TenantID] FOREIGN KEY([FileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage] CHECK CONSTRAINT [FK_TaxonomyTierTwoImage_FileResource_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwoImage_TaxonomyTierTwo_TaxonomyTierTwoID] FOREIGN KEY([TaxonomyTierTwoID])
REFERENCES [dbo].[TaxonomyTierTwo] ([TaxonomyTierTwoID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage] CHECK CONSTRAINT [FK_TaxonomyTierTwoImage_TaxonomyTierTwo_TaxonomyTierTwoID]
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwoImage_TaxonomyTierTwo_TaxonomyTierTwoID_TenantID] FOREIGN KEY([TaxonomyTierTwoID], [TenantID])
REFERENCES [dbo].[TaxonomyTierTwo] ([TaxonomyTierTwoID], [TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage] CHECK CONSTRAINT [FK_TaxonomyTierTwoImage_TaxonomyTierTwo_TaxonomyTierTwoID_TenantID]
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwoImage_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwoImage] CHECK CONSTRAINT [FK_TaxonomyTierTwoImage_Tenant_TenantID]