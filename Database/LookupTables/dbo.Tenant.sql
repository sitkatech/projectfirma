delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, CanonicalHostNameLocal, CanonicalHostNameQa, CanonicalHostNameProd)
values 
(1, 'SitkaTechnologyGroup', 'sitka.localhost.projectfirma.com', 'sitka.qa.projectfirma.com', 'sitka.projectfirma.com'),
(2, 'ClackamasPartnership', 'localhost.clackamaspartnership.org', 'qa.clackamaspartnership.org', 'www.clackamaspartnership.org'),
(3, 'RCDProjectTracker', 'localhost.rcdprojects.org', 'qa.rcdprojects.org', 'www.rcdprojects.org'),
(4, 'InternationYearOfTheSalmon', 'iysdemo.localhost.projectfirma.com', 'iysdemo.qa.projectfirma.com', 'iysdemo.projectfirma.com'),
(5, 'DemoProjectFirma', 'demo.localhost.projectfirma.com', 'demo.qa.projectfirma.com', 'demo.projectfirma.com'),
(6, 'PeaksToPeople', 'peakstopeople.localhost.projectfirma.com', 'qa-outcomes.peakstopeople.org', 'outcomes.peakstopeople.org'),
(7, 'JohnDayPartnership', 'johndaydemo.localhost.projectfirma.com', 'johndaydemo.qa.projectfirma.com', 'johndaydemo.projectfirma.com'),
(8, 'AshlandForestAllLandsRestorationInitiative', 'ashlanddemo.localhost.projectfirma.com', 'ashlanddemo.qa.projectfirma.com', 'ashlanddemo.projectfirma.com'),
(9, 'IdahoAssociatonOfSoilConservationDistricts', 'swcdemo.localhost.projectfirma.com', 'swcdemo.qa.projectfirma.com', 'swcdemo.projectfirma.com')