SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyTierThree](
	[TaxonomyTierThreeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TaxonomyTierThreeName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TaxonomyTierThreeDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ThemeColor] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaxonomyTierThreeCode] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_TaxonomyTierThree_TaxonomyTierThreeID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyTierThreeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierThree_TaxonomyTierThreeID_TenantID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierThreeID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierThree_TaxonomyTierThreeName_TenantID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierThreeName] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyTierThree]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierThree_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierThree] CHECK CONSTRAINT [FK_TaxonomyTierThree_Tenant_TenantID]