SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk](
	[MatchmakerOrganizationTaxonomyTrunkID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[TaxonomyTrunkID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MatchmakerOrganizationTaxonomyTrunk_MatchmakerOrganizationTaxonomyTrunkID] PRIMARY KEY CLUSTERED 
(
	[MatchmakerOrganizationTaxonomyTrunkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerOrganizationTaxonomyTrunk_MatchmakerOrganizationTaxonomyTrunkID_TenantID] UNIQUE NONCLUSTERED 
(
	[MatchmakerOrganizationTaxonomyTrunkID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID] FOREIGN KEY([TaxonomyTrunkID])
REFERENCES [dbo].[TaxonomyTrunk] ([TaxonomyTrunkID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID] FOREIGN KEY([TaxonomyTrunkID], [TenantID])
REFERENCES [dbo].[TaxonomyTrunk] ([TaxonomyTrunkID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_TaxonomyTrunk_TaxonomyTrunkID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyTrunk] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyTrunk_Tenant_TenantID]