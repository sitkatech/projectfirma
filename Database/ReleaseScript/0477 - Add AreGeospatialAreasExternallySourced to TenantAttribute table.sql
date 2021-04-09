
alter table dbo.TenantAttribute
add AreGeospatialAreasExternallySourced bit null
go 

update dbo.TenantAttribute
set AreGeospatialAreasExternallySourced = 0
go 

alter table dbo.TenantAttribute
alter column AreGeospatialAreasExternallySourced bit not null
go 

-- Enable for PSP only
update dbo.TenantAttribute
set AreGeospatialAreasExternallySourced = 1
where TenantID = 11