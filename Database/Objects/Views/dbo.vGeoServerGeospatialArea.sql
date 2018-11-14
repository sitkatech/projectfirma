if exists (select * from dbo.sysobjects where id = object_id('dbo.vGeoServerGeospatialArea'))
	drop view dbo.vGeoServerGeospatialArea
go

create view dbo.vGeoServerGeospatialArea
as
select
	w.GeospatialAreaID,
	w.GeospatialAreaID as PrimaryKey,
	w.GeospatialAreaName,
	w.GeospatialAreaFeature,
	w.GeospatialAreaFeature as Ogr_Geometry,
	t.TenantID,
	t.TenantName,
	coalesce(fdd.FieldDefinitionLabel, fd.FieldDefinitionDisplayName, 'GeospatialArea') as GeospatialAreaLabelName
	
from
	dbo.GeospatialArea w
	join dbo.Tenant t on w.TenantID = t.TenantID
	left join dbo.FieldDefinitionData fdd on fdd.TenantID = t.TenantID and fdd.FieldDefinitionID = 48
	left join dbo.FieldDefinition fd on fdd.FieldDefinitionID = fd.FieldDefinitionID
