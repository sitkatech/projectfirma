
--ClackamasPartnership
update dbo.TenantAttribute
set GoogleAnalyticsTrackingCode = 'G-CVD313CKEV'
where TenantAttributeID = 2 and GoogleAnalyticsTrackingCode = 'UA-148742229-1' 

--JohnDayPartnership
update dbo.TenantAttribute
set GoogleAnalyticsTrackingCode = 'G-H6NZR1YHCR'
where TenantAttributeID = 7 and GoogleAnalyticsTrackingCode = 'UA-149847789-1' 

--NCRPProjectTracker
update dbo.TenantAttribute
set GoogleAnalyticsTrackingCode = 'G-HSDNSZ68EJ'
where TenantAttributeID = 1 and GoogleAnalyticsTrackingCode = 'UA-237174650-1'

--PeaksToPeople
update dbo.TenantAttribute
set GoogleAnalyticsTrackingCode = 'G-4SSPK2BKJK'
where TenantAttributeID = 6 and GoogleAnalyticsTrackingCode = 'UA-148761096-1'

--RCDProjectTracker
update dbo.TenantAttribute
set GoogleAnalyticsTrackingCode = 'G-S5CDQ4147H'
where TenantAttributeID = 3 and GoogleAnalyticsTrackingCode = 'UA-148723661-1'

--Everything else
update dbo.TenantAttribute
set GoogleAnalyticsTrackingCode = null
where TenantAttributeID not in (2, 7, 1, 6, 3) and GoogleAnalyticsTrackingCode is not null
