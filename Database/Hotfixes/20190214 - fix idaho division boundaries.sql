

declare @DivisionIBoundary geometry
set @DivisionIBoundary =  (select geometry::UnionAggregate(o.OrganizationBoundary) from dbo.Organization o where o.OrganizationID in (1570, 1572, 1573, 1590))
update dbo.GeospatialArea set GeospatialAreaFeature = @DivisionIBoundary where GeospatialAreaName = 'Division I' and TenantID = 9

declare @DivisionIIBoundary geometry
set @DivisionIIBoundary =  (select geometry::UnionAggregate(o.OrganizationBoundary) from dbo.Organization o where o.OrganizationID in (1581,1589,1564,1592,1565))
update dbo.GeospatialArea set GeospatialAreaFeature = @DivisionIIBoundary where GeospatialAreaName = 'Division II' and TenantID = 9

declare @DivisionIIIBoundary geometry
set @DivisionIIIBoundary =  (select geometry::UnionAggregate(o.OrganizationBoundary) from dbo.Organization o where o.OrganizationID in (1566,1567,1574,1577,1585,1587,1598,1599,1605,1608,1609))
update dbo.GeospatialArea set GeospatialAreaFeature = @DivisionIIIBoundary where GeospatialAreaName = 'Division III' and TenantID = 9


declare @DivisionIVBoundary geometry
set @DivisionIVBoundary =  (select geometry::UnionAggregate(o.OrganizationBoundary) from dbo.Organization o where o.OrganizationID in (1568,1571,1576,1582,1588,1594,1596,1603,1607,1583,1611))
update dbo.GeospatialArea set GeospatialAreaFeature = @DivisionIVBoundary where GeospatialAreaName = 'Division IV' and TenantID = 9

declare @DivisionVBoundary geometry
set @DivisionVBoundary =  (select geometry::UnionAggregate(o.OrganizationBoundary) from dbo.Organization o where o.OrganizationID in (1569,1578,1579,1586,1595,1597,1601,1602,1604))
update dbo.GeospatialArea set GeospatialAreaFeature = @DivisionVBoundary where GeospatialAreaName = 'Division V' and TenantID = 9


declare @DivisionVIBoundaryWithHole geometry
set @DivisionVIBoundaryWithHole =  (select geometry::UnionAggregate(o.OrganizationBoundary) from dbo.Organization o where o.OrganizationID in (1575,1580,1562,1584,1563,1591,1593,1606,1610,1612))


DECLARE @g geometry;
DECLARE @hull geometry;
DECLARE @regions geometry;
DECLARE @boundary geometry;

SET @g = @DivisionVIBoundaryWithHole
SET @hull = @g.STConvexHull();
SET @regions = @hull.STDifference(@g);
SET @boundary = @hull.STBoundary();

WITH Geoms AS
(
    SELECT 1 i

    UNION ALL 

    SELECT i + 1
    FROM Geoms
    WHERE i < @regions.STNumGeometries()
)
SELECT @g = @g.STUnion(@regions.STGeometryN(i))
FROM Geoms
WHERE @regions.STGeometryN(i).STTouches(@boundary) = 0

declare @DivisionVIBoundary geometry
set @DivisionVIBoundary = @g


update dbo.GeospatialArea set GeospatialAreaFeature = @DivisionVIBoundary where GeospatialAreaName = 'Division VI' and TenantID = 9


delete from dbo.ProjectGeospatialArea where GeospatialAreaID in 
(
	select ga.GeospatialAreaID from dbo.GeospatialArea ga 
	join dbo.GeospatialAreaType gat on ga.GeospatialAreaTypeID = gat.GeospatialAreaTypeID 
	where gat.GeospatialAreaLayerName = 'SWCDemoProjectFirma:ISWCCDivision'
)


INSERT INTO dbo.ProjectGeospatialArea (TenantID, ProjectID, GeospatialAreaID)
select 9, s.ProjectID, s.GeospatialAreaID
from (
	select p.ProjectID, ga.GeospatialAreaID
	from dbo.Project p
	join dbo.GeospatialArea ga
	on p.ProjectLocationPoint.STWithin(ga.GeospatialAreaFeature) = 1
	join dbo.GeospatialAreaType gat on ga.GeospatialAreaTypeID = gat.GeospatialAreaTypeID
	where gat.GeospatialAreaLayerName = 'SWCDemoProjectFirma:ISWCCDivision' and p.TenantID = 9
	
) s


