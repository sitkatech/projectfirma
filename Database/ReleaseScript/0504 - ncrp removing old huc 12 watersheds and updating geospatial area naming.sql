
delete from dbo.ProjectGeospatialArea where TenantID = 4

delete from dbo.GeospatialArea where TenantID = 4 and GeospatialAreaTypeID = 2


update dbo.GeospatialAreaType set
GeospatialAreaTypeName = 'Watershed - HUC 12', GeospatialAreaTypeNamePluralized = 'Watersheds - HUC 12', GeospatialAreaLayerName = 'NCRPProjectTracker:WatershedHuc12'
where TenantID = 4 and GeospatialAreaTypeID = 2


/*

select * from dbo.GeospatialAreaType where TenantID = 4

*/