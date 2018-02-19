delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, TenantDomain, TenantSubdomain)
values 
(1, 'SitkaTechnologyGroup', 'projectfirma.com', 'sitka'),
(2, 'ClackamasPartnership', 'clackamaspartnership.org', null),
(3, 'RCDProjectTracker', 'rcdprojects.org', null),
(4, 'InternationYearOfTheSalmon', 'projectfirma.com', 'iysdemo'),
(5, 'DemoProjectFirma', 'projectfirma.com', 'demo'),
(6, 'NationalForestFoundation', 'projectfirma.com', 'nffdemo'),
(7, 'JohnDayPartnership', 'projectfirma.com', 'johndaydemo'),
(8, 'AshlandForestAllLandsRestorationInitiative', 'projectfirma.com', 'ashlanddemo'),
(9, 'IdahoAssociatonOfSoilConservationDistricts', 'projectfirma.com', 'swcdemo')