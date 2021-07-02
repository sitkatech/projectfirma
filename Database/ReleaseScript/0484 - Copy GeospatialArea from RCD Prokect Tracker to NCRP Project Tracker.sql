insert into dbo.GeospatialArea (TenantID, GeospatialAreaName, GeospatialAreaFeature, GeospatialAreaTypeID, GeospatialAreaDescriptionContent, GeospatialAreaShortName, ExternalID)
select 4, GeospatialAreaName, GeospatialAreaFeature, 2, GeospatialAreaDescriptionContent, GeospatialAreaShortName, ExternalID from dbo.GeospatialArea where TenantID = 3

update dbo.TenantAttribute set GeoServerNamespace = 'DemoProjectFirma' where TenantID = 4

update dbo.GeospatialAreaType
set GeospatialAreaLayerName = 'DemoProjectFirma:Watershed'
where GeospatialAreaTypeID = 2