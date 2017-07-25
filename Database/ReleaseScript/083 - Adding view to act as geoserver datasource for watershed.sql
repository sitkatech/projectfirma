create view dbo.vGeoServerWatershed
as
select
	w.WatershedID,
	w.TenantID,
	w.WatershedName,
	w.WatershedFeature
from
	dbo.Watershed w
go

alter table dbo.TenantAttribute add WatershedMapServiceUrl varchar(255) null
