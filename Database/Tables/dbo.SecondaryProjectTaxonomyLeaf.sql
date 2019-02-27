SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SecondaryProjectTaxonomyLeaf](
	[SecondaryProjectTaxonomyLeafID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[ProjectID] [int] NOT NULL,
	[TaxonomyLeafID] [int] NOT NULL,
 CONSTRAINT [PK_SecondaryProjectTaxonomyLeaf_SecondaryProjectTaxonomyLeafID] PRIMARY KEY CLUSTERED 
(
	[SecondaryProjectTaxonomyLeafID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SecondaryProjectTaxonomyLeaf_ProjectID_TaxonomyLeafID] UNIQUE NONCLUSTERED 
(
	[ProjectID] ASC,
	[TaxonomyLeafID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_SecondaryProjectTaxonomyLeaf_SecondaryProjectTaxonomyLeafID_TenantID] UNIQUE NONCLUSTERED 
(
	[SecondaryProjectTaxonomyLeafID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf] CHECK CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_Project_ProjectID]
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_Project_ProjectID_TenantID] FOREIGN KEY([ProjectID], [TenantID])
REFERENCES [dbo].[Project] ([ProjectID], [TenantID])
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf] CHECK CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_Project_ProjectID_TenantID]
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID] FOREIGN KEY([TaxonomyLeafID])
REFERENCES [dbo].[TaxonomyLeaf] ([TaxonomyLeafID])
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf] CHECK CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID]
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID_TenantID] FOREIGN KEY([TaxonomyLeafID], [TenantID])
REFERENCES [dbo].[TaxonomyLeaf] ([TaxonomyLeafID], [TenantID])
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf] CHECK CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID_TenantID]
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[SecondaryProjectTaxonomyLeaf] CHECK CONSTRAINT [FK_SecondaryProjectTaxonomyLeaf_Tenant_TenantID]