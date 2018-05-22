delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, TenantDomain, TenantSubdomain, KeystoneOpenIDClientIdentifier, KeystoneOpenIDClientSecret)
values 
(1, 'SitkaTechnologyGroup', 'projectfirma.com', 'sitka', 'SitkaProjectFirma', '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'),
(2, 'ClackamasPartnership', 'clackamaspartnership.org', null, 'ClackamasPartnership', '2F404371-D118-4C17-9F5E-C94713CAA1FB'),
(3, 'RCDProjectTracker', 'rcdprojects.org', null, 'RCDProjectTracker', '1C2E2422-2376-4F83-B75B-7DA2A4B3A106'),
(4, 'InternationYearOfTheSalmon', 'projectfirma.com', 'iysdemo', 'InternationYearOfTheSalmon', 'D3BAE523-0D42-471B-BBDD-54342AF22E54'),
(5, 'DemoProjectFirma', 'projectfirma.com', 'demo', 'DemoProjectFirma', '4A6D4335-4925-4BAF-A0A1-BB87E2C44096'),
(6, 'PeaksToPeople', 'projectfirma.com', 'peakstopeople', 'PeaksToPeople', 'A187BEF6-EE69-4113-9FBE-7CB1B39463D2'),
(7, 'JohnDayPartnership', 'projectfirma.com', 'johndaydemo', 'JohnDayPartnership', '6237EFB8-D605-47E1-9719-8D1CD1FEDA60'),
(8, 'AshlandForestAllLandsRestorationInitiative', 'projectfirma.com', 'ashlanddemo', 'AshlandForestAllLandsRestorationInitiative', '0A6AA4FC-A29A-44FA-8F61-F064D31BB5EE'),
(9, 'IdahoAssociatonOfSoilConservationDistricts', 'projectfirma.com', 'swcdemo', 'IdahoAssociatonOfSoilConservationDistricts', 'ABC8A0C7-EFDC-4DD8-9540-33C926ECC804')