delete pw
from dbo.Watershed w
join dbo.ProjectWatershed pw on w.WatershedID = pw.WatershedID and w.TenantID = pw.TenantID
where w.TenantID = 1

delete pw
from dbo.Watershed w
join dbo.ProjectLocationAreaWatershed pw on w.WatershedID = pw.WatershedID and w.TenantID = pw.TenantID
where w.TenantID = 1

delete pw
from dbo.Watershed w
join dbo.ProjectLocationArea pw on w.WatershedID = pw.WatershedID and w.TenantID = pw.TenantID
where w.TenantID = 1

delete w
from dbo.Watershed w
where w.TenantID = 1


insert into dbo.Watershed(WatershedName, WatershedFeature, TenantID)
select concat(h6.Name, ' (', h6.HUC12, ')') as WatershedName, h6.Shape as WatershedFeature, 1 as TenantID
from GeoCentral.dbo.HUC6 h6
where h6.HUC12 like '17070201%' or 
h6.HUC12 like '17070202%' or 
h6.HUC12 like '17070203%' or 
h6.HUC12 like '17070204%'

insert into dbo.ProjectLocationArea(ProjectLocationAreaID, TenantID, ProjectLocationAreaGroupID, WatershedID)
select WatershedID as ProjectLocationAreaID, 1 as TenantID, 5 as ProjectLocationAreaGroupID, WatershedID
from dbo.Watershed
where TenantID = 1


select *
from dbo.Watershed w
join dbo.ProjectLocationArea pw on w.WatershedID = pw.WatershedID and w.TenantID = pw.TenantID
where w.TenantID = 1