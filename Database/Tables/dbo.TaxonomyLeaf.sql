SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyLeaf](
	[TaxonomyLeafID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TaxonomyBranchID] [int] NOT NULL,
	[TaxonomyLeafName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TaxonomyLeafDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaxonomyLeafCode] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ThemeColor] [varchar](7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaxonomyLeafSortOrder] [int] NULL,
 CONSTRAINT [PK_TaxonomyLeaf_TaxonomyLeafID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyLeafID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyLeaf_TaxonomyLeafID_TenantID] UNIQUE NONCLUSTERED 
(
	[TaxonomyLeafID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyLeaf_TaxonomyLeafName_TenantID] UNIQUE NONCLUSTERED 
(
	[TaxonomyLeafName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyLeaf_TaxonomyBranch_TaxonomyBranchID] FOREIGN KEY([TaxonomyBranchID])
REFERENCES [dbo].[TaxonomyBranch] ([TaxonomyBranchID])
GO
ALTER TABLE [dbo].[TaxonomyLeaf] CHECK CONSTRAINT [FK_TaxonomyLeaf_TaxonomyBranch_TaxonomyBranchID]
GO
ALTER TABLE [dbo].[TaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyLeaf_TaxonomyBranch_TaxonomyBranchID_TenantID] FOREIGN KEY([TaxonomyBranchID], [TenantID])
REFERENCES [dbo].[TaxonomyBranch] ([TaxonomyBranchID], [TenantID])
GO
ALTER TABLE [dbo].[TaxonomyLeaf] CHECK CONSTRAINT [FK_TaxonomyLeaf_TaxonomyBranch_TaxonomyBranchID_TenantID]
GO
ALTER TABLE [dbo].[TaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyLeaf_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyLeaf] CHECK CONSTRAINT [FK_TaxonomyLeaf_Tenant_TenantID]