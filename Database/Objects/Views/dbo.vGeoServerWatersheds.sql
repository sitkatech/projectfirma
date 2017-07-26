if exists (select * from dbo.sysobjects where id = object_id('dbo.vGeoServerWatershed'))
	drop view dbo.vGeoServerWatershed
go

create view dbo.vGeoServerWatershed
as
select
	w.WatershedID,
	w.WatershedName,
	w.WatershedFeature,
	t.TenantID,
	t.TenantName
from
	dbo.Watershed w
	join dbo.Tenant t on w.TenantID = t.TenantID
