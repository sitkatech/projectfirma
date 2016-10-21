SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jurisdiction](
	[JurisdictionID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[JurisdictionFeature] [geometry] NULL,
	[StateProvinceID] [int] NULL,
	[ResidentialAllocationAbbreviation] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Jurisdiction_JurisdictionID] PRIMARY KEY CLUSTERED 
(
	[JurisdictionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_Jurisdiction_OrganizationID] UNIQUE NONCLUSTERED 
(
	[OrganizationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Jurisdiction]  WITH CHECK ADD  CONSTRAINT [FK_Jurisdiction_Organization_OrganizationID] FOREIGN KEY([OrganizationID])
REFERENCES [dbo].[Organization] ([OrganizationID])
GO
ALTER TABLE [dbo].[Jurisdiction] CHECK CONSTRAINT [FK_Jurisdiction_Organization_OrganizationID]
GO
ALTER TABLE [dbo].[Jurisdiction]  WITH CHECK ADD  CONSTRAINT [FK_Jurisdiction_StateProvince_StateProvinceID] FOREIGN KEY([StateProvinceID])
REFERENCES [dbo].[StateProvince] ([StateProvinceID])
GO
ALTER TABLE [dbo].[Jurisdiction] CHECK CONSTRAINT [FK_Jurisdiction_StateProvince_StateProvinceID]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
CREATE SPATIAL INDEX [SPATIAL_Jurisdiction_JurisdictionFeature] ON [dbo].[Jurisdiction]
(
	[JurisdictionFeature]
)USING  GEOMETRY_AUTO_GRID 
WITH (BOUNDING_BOX =(-121, 38, -119, 40), 
CELLS_PER_OBJECT = 8, PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]