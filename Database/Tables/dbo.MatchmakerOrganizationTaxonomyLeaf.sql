SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf](
	[MatchmakerOrganizationTaxonomyLeafID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[TaxonomyLeafID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MatchmakerOrganizationTaxonomyLeaf_MatchmakerOrganizationTaxonomyLeafID] PRIMARY KEY CLUSTERED 
(
	[MatchmakerOrganizationTaxonomyLeafID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerOrganizationTaxonomyLeaf_MatchmakerOrganizationTaxonomyLeafID_TenantID] UNIQUE NONCLUSTERED 
(
	[MatchmakerOrganizationTaxonomyLeafID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID] FOREIGN KEY([TaxonomyLeafID])
REFERENCES [dbo].[TaxonomyLeaf] ([TaxonomyLeafID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID_TenantID] FOREIGN KEY([TaxonomyLeafID], [TenantID])
REFERENCES [dbo].[TaxonomyLeaf] ([TaxonomyLeafID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_TaxonomyLeaf_TaxonomyLeafID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyLeaf] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyLeaf_Tenant_TenantID]