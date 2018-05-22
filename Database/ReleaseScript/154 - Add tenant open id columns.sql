--alter table dbo.Tenant add KeystoneOpenIDClientIdentifier varchar(256) null, KeystoneOpenIDClientSecret varchar(256) null
--GO

--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'SitkaProjectFirma',
--KeystoneOpenIDClientSecret = '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'
--where TenantID = 1

--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'ClackamasPartnership',
--KeystoneOpenIDClientSecret = '2F404371-D118-4C17-9F5E-C94713CAA1FB'
--where TenantID = 2


--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'RCDProjectTracker',
--KeystoneOpenIDClientSecret = '1C2E2422-2376-4F83-B75B-7DA2A4B3A106'
--where TenantID = 3

--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'IdahoAssociatonOfSoilConservationDistricts',
--KeystoneOpenIDClientSecret = 'ABC8A0C7-EFDC-4DD8-9540-33C926ECC804'
--where TenantID = 4

--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'DemoProjectFirma',
--KeystoneOpenIDClientSecret = '4A6D4335-4925-4BAF-A0A1-BB87E2C44096'
--where TenantID = 5

--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'PeaksToPeople',
--KeystoneOpenIDClientSecret = 'A187BEF6-EE69-4113-9FBE-7CB1B39463D2'
--where TenantID = 6


--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'JohnDayPartnership',
--KeystoneOpenIDClientSecret = '6237EFB8-D605-47E1-9719-8D1CD1FEDA60'
--where TenantID = 7

--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'AshlandForestAllLandsRestorationInitiative',
--KeystoneOpenIDClientSecret = '0A6AA4FC-A29A-44FA-8F61-F064D31BB5EE'
--where TenantID = 8

--update dbo.Tenant
--set KeystoneOpenIDClientIdentifier = 'IdahoAssociatonOfSoilConservationDistricts',
--KeystoneOpenIDClientSecret = 'ABC8A0C7-EFDC-4DD8-9540-33C926ECC804'
--where TenantID = 9


--alter table dbo.Tenant alter column KeystoneOpenIDClientIdentifier varchar(256) not null
--alter table dbo.Tenant alter column KeystoneOpenIDClientSecret varchar(256) not null
