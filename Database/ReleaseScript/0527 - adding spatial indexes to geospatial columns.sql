-- for [ProjectFirma].[dbo].[County].[CountyFeature]
    -- No rows in table, cannot suggest index bounds: [SPATIAL_County_CountyFeature]
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_GeospatialArea_GeospatialAreaFeature')
                          create spatial index [SPATIAL_GeospatialArea_GeospatialAreaFeature] on [ProjectFirma].[dbo].[GeospatialArea]([GeospatialAreaFeature])
                          with (BOUNDING_BOX=(-125, 32, -105, 51))
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_GeospatialAreaStaging_Geometry')
                          create spatial index [SPATIAL_GeospatialAreaStaging_Geometry] on [ProjectFirma].[dbo].[GeospatialAreaStaging]([Geometry])
                          with (BOUNDING_BOX=(-125, 46, -120, 50))
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_MatchMakerAreaOfInterestLocation_MatchMakerAreaOfInterestLocationGeometry')
                          create spatial index [SPATIAL_MatchMakerAreaOfInterestLocation_MatchMakerAreaOfInterestLocationGeometry] on [ProjectFirma].[dbo].[MatchMakerAreaOfInterestLocation]([MatchMakerAreaOfInterestLocationGeometry])
                          with (BOUNDING_BOX=(-125, 32, -111, 44))
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_Organization_OrganizationBoundary')
                          create spatial index [SPATIAL_Organization_OrganizationBoundary] on [ProjectFirma].[dbo].[Organization]([OrganizationBoundary])
                          with (BOUNDING_BOX=(-125, 32, -110, 50))
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_Project_DefaultBoundingBox')
                          create spatial index [SPATIAL_Project_DefaultBoundingBox] on [ProjectFirma].[dbo].[Project]([DefaultBoundingBox])
                          with (BOUNDING_BOX=(-126, 34, -111, 50))
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_Project_ProjectLocationPoint')
                          create spatial index [SPATIAL_Project_ProjectLocationPoint] on [ProjectFirma].[dbo].[Project]([ProjectLocationPoint])
                          with (BOUNDING_BOX=(-126, 33, -104, 340))
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_ProjectLocation_ProjectLocationGeometry')
                          create spatial index [SPATIAL_ProjectLocation_ProjectLocationGeometry] on [ProjectFirma].[dbo].[ProjectLocation]([ProjectLocationGeometry])
                          with (BOUNDING_BOX=(-125, 33, -105, 50))
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_ProjectLocationUpdate_ProjectLocationUpdateGeometry')
                          create spatial index [SPATIAL_ProjectLocationUpdate_ProjectLocationUpdateGeometry] on [ProjectFirma].[dbo].[ProjectLocationUpdate]([ProjectLocationUpdateGeometry])
                          with (BOUNDING_BOX=(-126, 33, -105, 50))
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_ProjectUpdate_ProjectLocationPoint')
                          create spatial index [SPATIAL_ProjectUpdate_ProjectLocationPoint] on [ProjectFirma].[dbo].[ProjectUpdate]([ProjectLocationPoint])
                          with (BOUNDING_BOX=(-126, 33, -104, 50))
-- for [ProjectFirma].[dbo].[StateProvince].[StateProvinceFeature]
    -- No rows in table, cannot suggest index bounds: [SPATIAL_StateProvince_StateProvinceFeature]
-- for [ProjectFirma].[dbo].[StateProvince].[StateProvinceFeatureForAnalysis]
    -- No rows in table, cannot suggest index bounds: [SPATIAL_StateProvince_StateProvinceFeatureForAnalysis]
IF NOT EXISTS (SELECT name FROM sysindexes WHERE name = 'SPATIAL_TenantAttribute_DefaultBoundingBox')
                          create spatial index [SPATIAL_TenantAttribute_DefaultBoundingBox] on [ProjectFirma].[dbo].[TenantAttribute]([DefaultBoundingBox])
                          with (BOUNDING_BOX=(-125, 32, -104, 50))

