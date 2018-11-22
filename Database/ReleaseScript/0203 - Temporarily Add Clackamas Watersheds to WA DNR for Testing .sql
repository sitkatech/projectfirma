-- Temporarily add a second (dummy) geospatial area type to WA DNR for testing

insert into dbo.GeospatialAreaType
values (10, 'Watershed', 'Watersheds', 'Welcome to WA DNRs dummy watersheds page', 'These are dummy watersheds for WA DNR', 'https://localhost-mapserver.projectfirma.com/geoserver/ClackamasPartnership/wms', 'WADNRForestHealth:Watershed') 

-- Copy Clackamas watershed GeospatialAreas into WA DNR

insert into GeospatialArea
select 10 as TenantID,
ga.GeospatialAreaName,
ga.GeospatialAreaFeature, 
12 as GeospatialAreaTypeID
from dbo.GeospatialArea ga
where TenantID = 2