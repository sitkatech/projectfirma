if exists (select * from dbo.sysobjects where id = object_id('dbo.vGeospatialArea'))
	drop view dbo.vGeospatialArea
go

create view dbo.vGeospatialArea
as
select
	ga.GeospatialAreaID,
	ga.GeospatialAreaID as PrimaryKey,
	ga.GeospatialAreaName,
	t.TenantID,
	t.TenantName,
	gat.GeospatialAreaTypeName,
    gat.GeospatialAreaTypeID
	
from
	dbo.GeospatialArea ga
	join dbo.GeospatialAreaType gat on ga.GeospatialAreaTypeID = gat.GeospatialAreaTypeID
	join dbo.Tenant t on ga.TenantID = t.TenantID
go
--  select * from dbo.vGeospatialArea