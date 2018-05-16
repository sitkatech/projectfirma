delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, TenantDomain, TenantSubdomain, KeystoneOpenIDClientIdentifier, KeystoneOpenIDClientSecret)
values 
(1, 'SitkaTechnologyGroup', 'projectfirma.com', 'sitka', 'ProjectFirma', '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'),
(2, 'ClackamasPartnership', 'clackamaspartnership.org', null, 'ClackamasPartnership', '2F404371-D118-4C17-9F5E-C94713CAA1FB'),
(3, 'RCDProjectTracker', 'rcdprojects.org', null, 'RCDProjectTracker', '1C2E2422-2376-4F83-B75B-7DA2A4B3A106'),
(4, 'InternationYearOfTheSalmon', 'projectfirma.com', 'iysdemo', 'ProjectFirma', '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'),
(5, 'DemoProjectFirma', 'projectfirma.com', 'demo', 'ProjectFirma', '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'),
(6, 'PeaksToPeople', 'projectfirma.com', 'peakstopeople', 'ProjectFirma', '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'),
(7, 'JohnDayPartnership', 'projectfirma.com', 'johndaydemo', 'ProjectFirma', '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'),
(8, 'AshlandForestAllLandsRestorationInitiative', 'projectfirma.com', 'ashlanddemo', 'ProjectFirma', '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'),
(9, 'IdahoAssociatonOfSoilConservationDistricts', 'projectfirma.com', 'swcdemo', 'ProjectFirma', '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD')