SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyTrunk](
	[TaxonomyTrunkID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TaxonomyTrunkName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TaxonomyTrunkDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ThemeColor] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaxonomyTrunkCode] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaxonomyTrunkSortOrder] [int] NULL,
 CONSTRAINT [PK_TaxonomyTrunk_TaxonomyTrunkID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyTrunkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTrunk_TaxonomyTrunkID_TenantID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTrunkID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTrunk_TaxonomyTrunkName_TenantID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTrunkName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTrunk_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTrunk] CHECK CONSTRAINT [FK_TaxonomyTrunk_Tenant_TenantID]