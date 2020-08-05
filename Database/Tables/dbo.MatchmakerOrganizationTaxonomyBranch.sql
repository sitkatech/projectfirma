SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch](
	[MatchmakerOrganizationTaxonomyBranchID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[TaxonomyBranchID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MatchmakerOrganizationTaxonomyBranch_MatchmakerOrganizationTaxonomyBranchID] PRIMARY KEY CLUSTERED 
(
	[MatchmakerOrganizationTaxonomyBranchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_MatchmakerOrganizationTaxonomyBranch_MatchmakerOrganizationTaxonomyBranchID_TenantID] UNIQUE NONCLUSTERED 
(
	[MatchmakerOrganizationTaxonomyBranchID] ASC,
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_Organization_OrganizationID_TenantID] FOREIGN KEY([OrganizationID], [TenantID])
REFERENCES [dbo].[Organization] ([OrganizationID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_Organization_OrganizationID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID] FOREIGN KEY([TaxonomyBranchID])
REFERENCES [dbo].[TaxonomyBranch] ([TaxonomyBranchID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID_TenantID] FOREIGN KEY([TaxonomyBranchID], [TenantID])
REFERENCES [dbo].[TaxonomyBranch] ([TaxonomyBranchID], [TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_TaxonomyBranch_TaxonomyBranchID_TenantID]
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch]  WITH CHECK ADD  CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[MatchmakerOrganizationTaxonomyBranch] CHECK CONSTRAINT [FK_MatchmakerOrganizationTaxonomyBranch_Tenant_TenantID]