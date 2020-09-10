
-- Fix tables with 0 Spatial Reference IDS (SRids)
update dbo.ProjectLocation
set ProjectLocationGeometry.STSrid = 4326
GO

update dbo.ProjectLocationUpdate
set ProjectLocationUpdateGeometry.STSrid = 4326
GO

-- Lock all the tables down so they MUST be 4326.
ALTER TABLE dbo.ProjectLocation
WITH CHECK ADD  CONSTRAINT [CK_ProjectLocation_ProjectLocationGeometry_SpatialReferenceID_Must_Be_4326] 
CHECK  (ProjectLocationGeometry is null or ProjectLocationGeometry.STSrid = 4326)
GO

ALTER TABLE dbo.ProjectLocationUpdate
WITH CHECK ADD  CONSTRAINT [CK_ProjectLocation_ProjectLocationUpdateGeometry_SpatialReferenceID_Must_Be_4326] 
CHECK  (ProjectLocationUpdateGeometry is null or ProjectLocationUpdateGeometry.STSrid = 4326)
GO

ALTER TABLE dbo.County
WITH CHECK ADD  CONSTRAINT [CK_County_CountyFeature_SpatialReferenceID_Must_Be_4326] 
CHECK  (CountyFeature is null or CountyFeature.STSrid = 4326)
GO

-- dbo.GeospatialArea.GeospatialAreaFeature
ALTER TABLE dbo.GeospatialArea
WITH CHECK ADD  CONSTRAINT [CK_GeospatialArea_GeospatialAreaFeature_SpatialReferenceID_Must_Be_4326] 
CHECK  (GeospatialAreaFeature is null or GeospatialAreaFeature.STSrid = 4326)
GO

-- dbo.Organization.OrganizationBoundary
ALTER TABLE dbo.Organization
WITH CHECK ADD  CONSTRAINT [CK_Organization_OrganizationBoundary_SpatialReferenceID_Must_Be_4326] 
CHECK  (OrganizationBoundary is null or OrganizationBoundary.STSrid = 4326)
GO

-- dbo.Project.DefaultBoundingBox
ALTER TABLE dbo.Project
WITH CHECK ADD  CONSTRAINT [CK_Project_DefaultBoundingBox_SpatialReferenceID_Must_Be_4326] 
CHECK  (DefaultBoundingBox is null or DefaultBoundingBox.STSrid = 4326)
GO

-- dbo.Project.ProjectLocationPoint
ALTER TABLE dbo.Project
WITH CHECK ADD  CONSTRAINT [CK_Project_ProjectLocationPoint_SpatialReferenceID_Must_Be_4326] 
CHECK  (ProjectLocationPoint is null or ProjectLocationPoint.STSrid = 4326)
GO

-- dbo.ProjectUpdate.ProjectLocationPoint
ALTER TABLE dbo.ProjectUpdate
WITH CHECK ADD  CONSTRAINT [CK_ProjectUpdate_ProjectLocationPoint_SpatialReferenceID_Must_Be_4326] 
CHECK  (ProjectLocationPoint is null or ProjectLocationPoint.STSrid = 4326)
GO

-- dbo.StateProvince.StateProvinceFeature
ALTER TABLE dbo.StateProvince
WITH CHECK ADD  CONSTRAINT [CK_StateProvince_StateProvinceFeature_SpatialReferenceID_Must_Be_4326] 
CHECK  (StateProvinceFeature is null or StateProvinceFeature.STSrid = 4326)
GO

-- dbo.StateProvince.StateProvinceFeatureForAnalysis
ALTER TABLE dbo.StateProvince
WITH CHECK ADD  CONSTRAINT [CK_StateProvince_StateProvinceFeatureForAnalysis_SpatialReferenceID_Must_Be_4326] 
CHECK  (StateProvinceFeatureForAnalysis is null or StateProvinceFeatureForAnalysis.STSrid = 4326)
GO

-- dbo.TenantAttribute.DefaultBoundingBox
ALTER TABLE dbo.TenantAttribute
WITH CHECK ADD  CONSTRAINT [CK_TenantAttribute_DefaultBoundingBox_SpatialReferenceID_Must_Be_4326] 
CHECK  (DefaultBoundingBox is null or DefaultBoundingBox.STSrid = 4326)
GO



















