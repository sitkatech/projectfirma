
INSERT INTO dbo.ProjectGeospatialArea (TenantID, ProjectID, GeospatialAreaID)
select 9, s.ProjectID, s.GeospatialAreaID
from (
	select p.ProjectID, ga.GeospatialAreaID
	from dbo.Project p
	join dbo.GeospatialArea ga
	on p.ProjectLocationPoint.STWithin(ga.GeospatialAreaFeature) = 1
	join dbo.GeospatialAreaType gat on ga.GeospatialAreaTypeID = gat.GeospatialAreaTypeID
	where gat.GeospatialAreaLayerName = 'SWCDemoProjectFirma:LegislativeDistrict' and p.TenantID = 9
	
) s


INSERT INTO dbo.ProjectGeospatialArea (TenantID, ProjectID, GeospatialAreaID)
select 9, s.ProjectID, s.GeospatialAreaID
from (
	select p.ProjectID, ga.GeospatialAreaID
	from dbo.Project p
	join dbo.GeospatialArea ga
	on p.ProjectLocationPoint.STWithin(ga.GeospatialAreaFeature) = 1
	join dbo.GeospatialAreaType gat on ga.GeospatialAreaTypeID = gat.GeospatialAreaTypeID
	where gat.GeospatialAreaLayerName = 'SWCDemoProjectFirma:CongressionalDistrict' and p.TenantID = 9
	
) s
