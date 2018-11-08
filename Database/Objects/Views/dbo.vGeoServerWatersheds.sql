if exists (select * from dbo.sysobjects where id = object_id('dbo.vGeoServerWatershed'))
	drop view dbo.vGeoServerWatershed
go

create view dbo.vGeoServerWatershed
as
select
	w.WatershedID,
	w.WatershedID as PrimaryKey,
	w.WatershedName,
	w.WatershedFeature,
	w.WatershedFeature as Ogr_Geometry,
	t.TenantID,
	t.TenantName,
	isnull(fdd.FieldDefinitionLabel, fd.FieldDefinitionDisplayName) as WatershedLabelName
	
from
	dbo.Watershed w
	join dbo.Tenant t on w.TenantID = t.TenantID
	join dbo.FieldDefinitionData fdd on fdd.TenantID = t.TenantID and fdd.FieldDefinitionID = 48
	join dbo.FieldDefinition fd on fdd.FieldDefinitionID = fd.FieldDefinitionID
