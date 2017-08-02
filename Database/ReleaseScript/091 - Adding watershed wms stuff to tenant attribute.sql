alter table dbo.TenantAttribute add MapServiceUrl varchar(255) null
alter table dbo.TenantAttribute add WatershedLayerName varchar(255) null

go

update dbo.TenantAttribute set MapServiceUrl = 'https://mapserver.projectfirma.com/geoserver/ProjectFirma/wms', WatershedLayerName = 'ProjectFirma:Watershed' where TenantID = 1
update dbo.TenantAttribute set MapServiceUrl = 'https://mapserver.projectfirma.com/geoserver/ClackamasPartnership/wms', WatershedLayerName = 'ClackamasPartnership:Watershed' where TenantID = 2
update dbo.TenantAttribute set MapServiceUrl = 'https://mapserver.projectfirma.com/geoserver/RCDProjectTracker/wms', WatershedLayerName = 'RCDProjectTracker:Watershed' where TenantID = 3
