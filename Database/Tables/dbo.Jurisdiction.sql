SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jurisdiction](
	[JurisdictionID] [int] NOT NULL,
	[OrganizationID] [int] NOT NULL,
	[JurisdictionFeature] [geometry] NULL,
	[StateProvinceID] [int] NULL,
	[TenantID] [int] NOT NULL,
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
ALTER TABLE [dbo].[Jurisdiction]  WITH CHECK ADD  CONSTRAINT [FK_Jurisdiction_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[Jurisdiction] CHECK CONSTRAINT [FK_Jurisdiction_Tenant_TenantID]