insert into dbo.ProjectLocationAreaGroup(ProjectLocationAreaGroupID, ProjectLocationAreaGroupTypeID, TenantID)
values(6, 4, 3)

insert into dbo.Watershed(WatershedName, WatershedFeature, TenantID)
select concat(h6.Name, ' (', h6.HUC12, ')') as WatershedName, h6.Shape as WatershedFeature, 3 as TenantID
from GeoCentral.dbo.HUC6 h6
where h6.States like '%CA%'

insert into dbo.ProjectLocationArea(ProjectLocationAreaID, TenantID, ProjectLocationAreaGroupID, WatershedID)
select WatershedID as ProjectLocationAreaID, 3 as TenantID, 6 as ProjectLocationAreaGroupID, WatershedID
from dbo.Watershed
where TenantID = 3
