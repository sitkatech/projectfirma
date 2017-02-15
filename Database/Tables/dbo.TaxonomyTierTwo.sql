SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyTierTwo](
	[TaxonomyTierTwoID] [int] IDENTITY(1,1) NOT NULL,
	[TaxonomyTierThreeID] [int] NOT NULL,
	[TaxonomyTierTwoName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TaxonomyTierTwoDescription] [varchar](4000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ThemeColor] [varchar](7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaxonomyTierTwoCode] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_TaxonomyTierTwo_TaxonomyTierTwoID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyTierTwoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierTwo_TaxonomyTierTwoID_TenantID] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierTwoID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierTwo_TaxonomyTierTwoName] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierTwoName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyTierTwo]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwo_TaxonomyTierThree_TaxonomyTierThreeID] FOREIGN KEY([TaxonomyTierThreeID])
REFERENCES [dbo].[TaxonomyTierThree] ([TaxonomyTierThreeID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwo] CHECK CONSTRAINT [FK_TaxonomyTierTwo_TaxonomyTierThree_TaxonomyTierThreeID]
GO
ALTER TABLE [dbo].[TaxonomyTierTwo]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwo_TaxonomyTierThree_TaxonomyTierThreeID_TenantID] FOREIGN KEY([TaxonomyTierThreeID], [TenantID])
REFERENCES [dbo].[TaxonomyTierThree] ([TaxonomyTierThreeID], [TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwo] CHECK CONSTRAINT [FK_TaxonomyTierTwo_TaxonomyTierThree_TaxonomyTierThreeID_TenantID]
GO
ALTER TABLE [dbo].[TaxonomyTierTwo]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierTwo_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierTwo] CHECK CONSTRAINT [FK_TaxonomyTierTwo_Tenant_TenantID]