SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaxonomyTierOne](
	[TaxonomyTierOneID] [int] IDENTITY(1,1) NOT NULL,
	[TaxonomyTierTwoID] [int] NOT NULL,
	[TaxonomyTierOneName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TaxonomyTierOneDescription] [dbo].[html] NULL,
	[TaxonomyTierOneCode] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_TaxonomyTierOne_TaxonomyTierOneID] PRIMARY KEY CLUSTERED 
(
	[TaxonomyTierOneID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TaxonomyTierOne_TaxonomyTierOneName] UNIQUE NONCLUSTERED 
(
	[TaxonomyTierOneName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[TaxonomyTierOne]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierOne_TaxonomyTierTwo_TaxonomyTierTwoID] FOREIGN KEY([TaxonomyTierTwoID])
REFERENCES [dbo].[TaxonomyTierTwo] ([TaxonomyTierTwoID])
GO
ALTER TABLE [dbo].[TaxonomyTierOne] CHECK CONSTRAINT [FK_TaxonomyTierOne_TaxonomyTierTwo_TaxonomyTierTwoID]
GO
ALTER TABLE [dbo].[TaxonomyTierOne]  WITH CHECK ADD  CONSTRAINT [FK_TaxonomyTierOne_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TaxonomyTierOne] CHECK CONSTRAINT [FK_TaxonomyTierOne_Tenant_TenantID]