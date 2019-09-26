alter table dbo.TenantAttribute 
add GoogleAnalyticsTrackingCode varchar(100) NULL;

GO

-- ActionAgendaForPugetSound
UPDATE dbo.TenantAttribute set GoogleAnalyticsTrackingCode = 'UA-148735991-1' where TenantID = 11

-- ClackamasPartnership
UPDATE dbo.TenantAttribute set GoogleAnalyticsTrackingCode = 'UA-148742229-1' where TenantID = 2

-- BureauOfReclamation
UPDATE dbo.TenantAttribute set GoogleAnalyticsTrackingCode = 'UA-148723662-1' where TenantID = 12

-- IdahoAssociatonOfSoilConservationDistricts
UPDATE dbo.TenantAttribute set GoogleAnalyticsTrackingCode = 'UA-148712961-1' where TenantID = 9

-- PeaksToPeople
UPDATE dbo.TenantAttribute set GoogleAnalyticsTrackingCode = 'UA-148761096-1' where TenantID = 6

-- RCDProjectTracker
UPDATE dbo.TenantAttribute set GoogleAnalyticsTrackingCode = 'UA-148723661-1' where TenantID = 3

GO