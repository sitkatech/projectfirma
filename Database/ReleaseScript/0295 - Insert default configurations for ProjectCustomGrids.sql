
delete from dbo.ProjectCustomGridConfiguration

-- Configs for standard columns
insert into dbo.ProjectCustomGridConfiguration
select t.TenantID,
pcgt.ProjectCustomGridTypeID,
pcgc.ProjectCustomGridColumnID,
null,
null,
1,
0
from dbo.Tenant t
cross join dbo.ProjectCustomGridColumn pcgc
cross join dbo.ProjectCustomGridType pcgt
where ProjectCustomGridColumnID <> 21 and ProjectCustomGridColumnID <> 22


-- Configs for Geospatial Areas
insert into dbo.ProjectCustomGridConfiguration
select t.TenantID,
pcgt.ProjectCustomGridTypeID,
pcgc.ProjectCustomGridColumnID,
null,
gat.GeospatialAreaTypeID,
1,
0
from dbo.Tenant t
cross join dbo.ProjectCustomGridColumn pcgc
cross join dbo.ProjectCustomGridType pcgt
inner join dbo.GeospatialAreaType gat on gat.TenantID = t.TenantID
where ProjectCustomGridColumnID = 21


-- Configs for Custom Attributes
insert into dbo.ProjectCustomGridConfiguration
select t.TenantID,
pcgt.ProjectCustomGridTypeID,
pcgc.ProjectCustomGridColumnID,
pcat.ProjectCustomAttributeTypeID,
null,
1,
0
from dbo.Tenant t
cross join dbo.ProjectCustomGridColumn pcgc
cross join dbo.ProjectCustomGridType pcgt
inner join dbo.ProjectCustomAttributeType pcat on pcat.TenantID = t.TenantID
where ProjectCustomGridColumnID = 22

-- Disable ProjectID for everyone except PSP
update dbo.ProjectCustomGridConfiguration
set IsEnabled = 0, SortOrder = null
where ProjectCustomGridColumnID = 23 and TenantID <> 11

-- Migrate IncludeInProject settings from ProjectCustomAttributeType
update dbo.ProjectCustomGridConfiguration
set dbo.ProjectCustomGridConfiguration.IsEnabled = 0, dbo.ProjectCustomGridConfiguration.SortOrder = null
from dbo.ProjectCustomGridConfiguration pcgc
inner join dbo.ProjectCustomAttributeType pcat on pcgc.ProjectCustomAttributeTypeID = pcat.ProjectCustomAttributeTypeID and pcgc.TenantID = pcat.TenantID
where pcat.IncludeInProjectGrid = 0
