if exists (select * from dbo.sysobjects where id = object_id('dbo.vGeoServerGeospatialArea'))
	drop view dbo.vGeoServerGeospatialArea
go

create view dbo.vGeoServerGeospatialArea
as
select
	ga.GeospatialAreaID,
	ga.GeospatialAreaID as PrimaryKey,
	ga.GeospatialAreaName,
	ga.GeospatialAreaFeature,
	t.TenantID,
	t.TenantName,
	gat.GeospatialAreaTypeName
	
from
	dbo.GeospatialArea ga
	join dbo.GeospatialAreaType gat on ga.GeospatialAreaTypeID = gat.GeospatialAreaTypeID
	join dbo.Tenant t on ga.TenantID = t.TenantID
