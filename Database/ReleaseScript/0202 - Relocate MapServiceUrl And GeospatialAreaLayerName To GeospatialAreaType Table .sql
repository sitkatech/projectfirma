
-- Delete the record for tenant without a GeospatialArea defined
delete from dbo.GeospatialAreaType
where TenantID = 11

-- Add fields to GeospatialAreaType
alter table dbo.GeospatialAreaType add MapServiceUrl varchar(255) null
alter table dbo.GeospatialAreaType add GeospatialAreaLayerName varchar(255) null
go

-- Move over attributes from TenantAttribute
update  gat
set gat.MapServiceUrl = ta.MapServiceUrl, gat.GeospatialAreaLayerName = ta.GeospatialAreaLayerName
from dbo.GeospatialAreaType gat
join dbo.TenantAttribute ta on gat.TenantID = ta.TenantID
where ta.MapServiceUrl is not null

-- Set fields to non-nullable now that they're populated
alter table dbo.GeospatialAreaType alter column MapServiceUrl varchar(255) not null
alter table dbo.GeospatialAreaType alter column GeospatialAreaLayerName varchar(255) not null

-- Drop unneeded fields from TenantAttribute
alter table dbo.TenantAttribute drop column MapServiceUrl
alter table dbo.TenantAttribute drop column GeospatialAreaLayerName
