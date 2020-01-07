SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantAttribute](
	[TenantAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[DefaultBoundingBox] [geometry] NOT NULL,
	[MinimumYear] [int] NOT NULL,
	[PrimaryContactPersonID] [int] NULL,
	[TenantSquareLogoFileResourceID] [int] NULL,
	[TenantBannerLogoFileResourceID] [int] NULL,
	[TenantStyleSheetFileResourceID] [int] NULL,
	[TenantShortDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ToolDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ShowProposalsToThePublic] [bit] NOT NULL,
	[TaxonomyLevelID] [int] NOT NULL,
	[AssociatePerfomanceMeasureTaxonomyLevelID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[ProjectExternalDataSourceEnabled] [bit] NOT NULL,
	[AccomplishmentsDashboardFundingDisplayTypeID] [int] NOT NULL,
	[AccomplishmentsDashboardAccomplishmentsButtonText] [dbo].[html] NULL,
	[AccomplishmentsDashboardExpendituresButtonText] [dbo].[html] NULL,
	[AccomplishmentsDashboardOrganizationsButtonText] [dbo].[html] NULL,
	[AccomplishmentsDashboardIncludeReportingOrganizationType] [bit] NOT NULL,
	[ShowLeadImplementerLogoOnFactSheet] [bit] NOT NULL,
	[EnableAccomplishmentsDashboard] [bit] NOT NULL,
	[ProjectStewardshipAreaTypeID] [int] NULL,
	[EnableSecondaryProjectTaxonomyLeaf] [bit] NOT NULL,
	[KeystoneOpenIDClientIdentifier] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[KeystoneOpenIDClientSecret] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BudgetTypeID] [int] NOT NULL,
	[CanManageCustomAttributes] [bit] NOT NULL,
	[ExcludeTargetedFundingOrganizations] [bit] NOT NULL,
	[GoogleAnalyticsTrackingCode] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UseProjectTimeline] [bit] NOT NULL,
	[GeoServerNamespace] [varchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EnableEvaluations] [bit] NOT NULL,
 CONSTRAINT [PK_TenantAttribute_TenantAttributeID] PRIMARY KEY CLUSTERED 
(
	[TenantAttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TenantAttribute_TenantID] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TenantAttribute_TenantShortDisplayName] UNIQUE NONCLUSTERED 
(
	[TenantShortDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeID] FOREIGN KEY([AccomplishmentsDashboardFundingDisplayTypeID])
REFERENCES [dbo].[AccomplishmentsDashboardFundingDisplayType] ([AccomplishmentsDashboardFundingDisplayTypeID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_AccomplishmentsDashboardFundingDisplayType_AccomplishmentsDashboardFundingDisplayTypeID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_BudgetType_BudgetTypeID] FOREIGN KEY([BudgetTypeID])
REFERENCES [dbo].[BudgetType] ([BudgetTypeID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_BudgetType_BudgetTypeID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_FileResource_TenantBannerLogoFileResourceID_FileResourceID] FOREIGN KEY([TenantBannerLogoFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_FileResource_TenantBannerLogoFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_FileResource_TenantBannerLogoFileResourceID_TenantID_FileResourceID_TenantID] FOREIGN KEY([TenantBannerLogoFileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_FileResource_TenantBannerLogoFileResourceID_TenantID_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_FileResource_TenantSquareLogoFileResourceID_FileResourceID] FOREIGN KEY([TenantSquareLogoFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_FileResource_TenantSquareLogoFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_FileResource_TenantSquareLogoFileResourceID_TenantID_FileResourceID_TenantID] FOREIGN KEY([TenantSquareLogoFileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_FileResource_TenantSquareLogoFileResourceID_TenantID_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_FileResource_TenantStyleSheetFileResourceID_FileResourceID] FOREIGN KEY([TenantStyleSheetFileResourceID])
REFERENCES [dbo].[FileResource] ([FileResourceID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_FileResource_TenantStyleSheetFileResourceID_FileResourceID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_FileResource_TenantStyleSheetFileResourceID_TenantID_FileResourceID_TenantID] FOREIGN KEY([TenantStyleSheetFileResourceID], [TenantID])
REFERENCES [dbo].[FileResource] ([FileResourceID], [TenantID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_FileResource_TenantStyleSheetFileResourceID_TenantID_FileResourceID_TenantID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_Person_PrimaryContactPersonID_PersonID] FOREIGN KEY([PrimaryContactPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_Person_PrimaryContactPersonID_PersonID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_Person_PrimaryContactPersonID_TenantID_PersonID_TenantID] FOREIGN KEY([PrimaryContactPersonID], [TenantID])
REFERENCES [dbo].[Person] ([PersonID], [TenantID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_Person_PrimaryContactPersonID_TenantID_PersonID_TenantID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeID] FOREIGN KEY([ProjectStewardshipAreaTypeID])
REFERENCES [dbo].[ProjectStewardshipAreaType] ([ProjectStewardshipAreaTypeID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_ProjectStewardshipAreaType_ProjectStewardshipAreaTypeID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_TaxonomyLevel_AssociatePerfomanceMeasureTaxonomyLevelID_TaxonomyLevelID] FOREIGN KEY([AssociatePerfomanceMeasureTaxonomyLevelID])
REFERENCES [dbo].[TaxonomyLevel] ([TaxonomyLevelID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_TaxonomyLevel_AssociatePerfomanceMeasureTaxonomyLevelID_TaxonomyLevelID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_TaxonomyLevel_TaxonomyLevelID] FOREIGN KEY([TaxonomyLevelID])
REFERENCES [dbo].[TaxonomyLevel] ([TaxonomyLevelID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_TaxonomyLevel_TaxonomyLevelID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_Tenant_TenantID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [CK_TenantAttribute_AssociatedPerfomanceMeasureTaxonomyLevelLessThanEqualToTaxonomyLevelID] CHECK  (([AssociatePerfomanceMeasureTaxonomyLevelID]<=[TaxonomyLevelID]))
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [CK_TenantAttribute_AssociatedPerfomanceMeasureTaxonomyLevelLessThanEqualToTaxonomyLevelID]