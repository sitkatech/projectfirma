SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TenantAttribute](
	[TenantAttributeID] [int] IDENTITY(1,1) NOT NULL,
	[TenantID] [int] NOT NULL,
	[TaxonomySystemName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TaxonomyTierOneDisplayNameForProject] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[PerformanceMeasureDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ClassificationDisplayName] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TenantSquareLogoUrl] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TenantBannerLogoUrl] [varchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[DefaultBoundingBox] [geometry] NOT NULL,
	[NumberOfTaxonomyTiersToUse] [int] NOT NULL,
	[MinimumYear] [int] NOT NULL,
	[TenantStyleSheetUrl] [varchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_TenantAttribute_TenantAttributeID] PRIMARY KEY CLUSTERED 
(
	[TenantAttributeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_TenantAttribute_TenantID] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [FK_TenantAttribute_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [FK_TenantAttribute_Tenant_TenantID]
GO
ALTER TABLE [dbo].[TenantAttribute]  WITH CHECK ADD  CONSTRAINT [CK_TenantAttribute_NumberOfTaxonomyTiersToUseBetweenOneAndThree] CHECK  (([NumberOfTaxonomyTiersToUse]<(4) AND [NumberOfTaxonomyTiersToUse]>(0)))
GO
ALTER TABLE [dbo].[TenantAttribute] CHECK CONSTRAINT [CK_TenantAttribute_NumberOfTaxonomyTiersToUseBetweenOneAndThree]