update dbo.TenantAttribute
set MapServiceUrl = 'https://localhost-mapserver.projectfirma.com/geoserver/ProjectFirma/wms'
where TenantID in (4, 7)