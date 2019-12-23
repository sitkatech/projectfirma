-- Add the GeoServerNamespace column
ALTER TABLE dbo.TenantAttribute
ADD GeoServerNamespace varchar(256) null

GO

-- Seed current values for the GeoServerNamespace column
UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'ProjectFirma'
WHERE TenantID = 1

UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'ClackamasPartnership'
WHERE TenantID = 2

UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'RCDProjectTracker'
WHERE TenantID = 3

UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'DemoProjectFirma'
WHERE TenantID = 5

UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'PeaksToPeople'
WHERE TenantID = 6

UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'JohnDayBasinPartnership'
WHERE TenantID = 7

UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'SWCDemoProjectFirma'
WHERE TenantID = 9

UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'PSPActionAgenda'
WHERE TenantID = 11

UPDATE dbo.TenantAttribute
SET GeoServerNamespace = 'AshlandDemoProjectFirma'
WHERE TenantID = 8