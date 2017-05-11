insert into dbo.Watershed(WatershedName, WatershedFeature, TenantID)
select h6.Name as WatershedName, h6.Shape as WatershedFeature, 1 as TenantID
from GeoCentral.dbo.HUC6 h6
where h6.HUC12 like '17020011%'

insert into dbo.ProjectLocationAreaGroup(ProjectLocationAreaGroupID, TenantID, ProjectLocationAreaGroupTypeID)
values(5, 1, 4)

insert into dbo.ProjectLocationArea(ProjectLocationAreaID, TenantID, ProjectLocationAreaGroupID, WatershedID)
select WatershedID as ProjectLocationAreaID, 1 as TenantID, 5 as ProjectLocationAreaGroupID, WatershedID
from dbo.Watershed
where TenantID = 1