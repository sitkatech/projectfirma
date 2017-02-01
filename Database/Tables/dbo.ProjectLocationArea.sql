SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectLocationArea](
	[ProjectLocationAreaID] [int] NOT NULL,
	[StateProvinceID] [int] NULL,
	[ProjectLocationAreaGroupID] [int] NULL,
	[MappedRegionID] [int] NULL,
	[JurisdictionID] [int] NULL,
	[WatershedID] [int] NULL,
	[TenantID] [int] NOT NULL,
 CONSTRAINT [PK_ProjectLocationArea_ProjectLocationAreaID] PRIMARY KEY CLUSTERED 
(
	[ProjectLocationAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectLocationArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationArea_Jurisdiction_JurisdictionID] FOREIGN KEY([JurisdictionID])
REFERENCES [dbo].[Jurisdiction] ([JurisdictionID])
GO
ALTER TABLE [dbo].[ProjectLocationArea] CHECK CONSTRAINT [FK_ProjectLocationArea_Jurisdiction_JurisdictionID]
GO
ALTER TABLE [dbo].[ProjectLocationArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationArea_MappedRegion_MappedRegionID] FOREIGN KEY([MappedRegionID])
REFERENCES [dbo].[MappedRegion] ([MappedRegionID])
GO
ALTER TABLE [dbo].[ProjectLocationArea] CHECK CONSTRAINT [FK_ProjectLocationArea_MappedRegion_MappedRegionID]
GO
ALTER TABLE [dbo].[ProjectLocationArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationArea_ProjectLocationAreaGroup_ProjectLocationAreaGroupID] FOREIGN KEY([ProjectLocationAreaGroupID])
REFERENCES [dbo].[ProjectLocationAreaGroup] ([ProjectLocationAreaGroupID])
GO
ALTER TABLE [dbo].[ProjectLocationArea] CHECK CONSTRAINT [FK_ProjectLocationArea_ProjectLocationAreaGroup_ProjectLocationAreaGroupID]
GO
ALTER TABLE [dbo].[ProjectLocationArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationArea_StateProvince_StateProvinceID] FOREIGN KEY([StateProvinceID])
REFERENCES [dbo].[StateProvince] ([StateProvinceID])
GO
ALTER TABLE [dbo].[ProjectLocationArea] CHECK CONSTRAINT [FK_ProjectLocationArea_StateProvince_StateProvinceID]
GO
ALTER TABLE [dbo].[ProjectLocationArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationArea_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectLocationArea] CHECK CONSTRAINT [FK_ProjectLocationArea_Tenant_TenantID]
GO
ALTER TABLE [dbo].[ProjectLocationArea]  WITH CHECK ADD  CONSTRAINT [FK_ProjectLocationArea_Watershed_WatershedID] FOREIGN KEY([WatershedID])
REFERENCES [dbo].[Watershed] ([WatershedID])
GO
ALTER TABLE [dbo].[ProjectLocationArea] CHECK CONSTRAINT [FK_ProjectLocationArea_Watershed_WatershedID]
GO
ALTER TABLE [dbo].[ProjectLocationArea]  WITH CHECK ADD  CONSTRAINT [CK_Only_One_Geometry_Foreign_Key_Relationship] CHECK  (([StateProvinceID] IS NOT NULL AND [MappedRegionID] IS NULL AND [JurisdictionID] IS NULL AND [WatershedID] IS NULL OR [StateProvinceID] IS NULL AND [MappedRegionID] IS NOT NULL AND [JurisdictionID] IS NULL AND [WatershedID] IS NULL OR [StateProvinceID] IS NULL AND [MappedRegionID] IS NULL AND [JurisdictionID] IS NOT NULL AND [WatershedID] IS NULL OR [StateProvinceID] IS NULL AND [MappedRegionID] IS NULL AND [JurisdictionID] IS NULL AND [WatershedID] IS NOT NULL))
GO
ALTER TABLE [dbo].[ProjectLocationArea] CHECK CONSTRAINT [CK_Only_One_Geometry_Foreign_Key_Relationship]