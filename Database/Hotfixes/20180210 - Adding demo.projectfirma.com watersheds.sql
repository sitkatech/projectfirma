insert into dbo.Watershed(WatershedName, WatershedFeature, TenantID)
select case when h4.Name = h4.HUC8 then h4.Name else concat(h4.Name, ' (', h4.HUC8, ')') end as WatershedName, h4.Shape as WatershedFeature, 5 as TenantID
from GeoCentral.dbo.HUC4 h4
where h4.States like '%OR%'