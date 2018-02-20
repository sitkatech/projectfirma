insert into dbo.Watershed(WatershedName, WatershedFeature, TenantID)
select case when h4.Name = h4.HUC8 then h4.Name else concat(h4.Name, ' (', h4.HUC8, ')') end as WatershedName, h4.Shape as WatershedFeature, 8 as TenantID
from GeoCentral.dbo.HUC4 h4
where h4.States like '%OR%'


insert into dbo.Watershed(WatershedName, WatershedFeature, TenantID)
select concat(h6.Name, ' (', h6.HUC12, ')') as WatershedName, h6.Shape as WatershedFeature, 9 as TenantID
from GeoCentral.dbo.HUC6 h6
where h6.States like '%ID%'