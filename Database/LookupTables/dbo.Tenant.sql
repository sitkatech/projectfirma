delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, CanonicalHostNameLocal, CanonicalHostNameQa, CanonicalHostNameProd, ReportingYearStartDate, UseFiscalYears, UsesTechnicalAssistanceParameters, ArePerformanceMeasuresExternallySourced)
values 
(1, 'SitkaTechnologyGroup', 'sitka.localhost.projectfirma.com', 'sitka.qa.projectfirma.com', 'sitka.projectfirma.com', '1/1/1990', 0, 0, 0),
(2, 'ClackamasPartnership', 'localhost.clackamaspartnership.org', 'qa.clackamaspartnership.org', 'www.clackamaspartnership.org', '1/1/1990', 0, 0, 0),
(3, 'RCDProjectTracker', 'localhost.rcdprojects.org', 'qa.rcdprojects.org', 'www.rcdprojects.org', '1/1/1990', 0, 0, 0),
(4, 'InternationYearOfTheSalmon', 'iysdemo.localhost.projectfirma.com', 'iysdemo.qa.projectfirma.com', 'iysdemo.projectfirma.com', '1/1/1990', 0, 0, 0),
(5, 'DemoProjectFirma', 'demo.localhost.projectfirma.com', 'demo.qa.projectfirma.com', 'demo.projectfirma.com', '1/1/1990', 0, 0, 0),
(6, 'PeaksToPeople', 'peakstopeople.localhost.projectfirma.com', 'qa-outcomes.peakstopeople.org', 'outcomes.peakstopeople.org', '1/1/1990', 0, 0, 0),
(7, 'JohnDayPartnership', 'johndaydemo.localhost.projectfirma.com', 'johndaydemo.qa.projectfirma.com', 'johndaydemo.projectfirma.com', '1/1/1990', 0, 0, 0),
(8, 'AshlandForestAllLandsRestorationInitiative', 'ashlanddemo.localhost.projectfirma.com', 'ashlanddemo.qa.projectfirma.com', 'ashlanddemo.projectfirma.com', '1/1/1990', 0, 0, 0),
(9, 'IdahoAssociatonOfSoilConservationDistricts', 'swcdemo.localhost.projectfirma.com', 'swcdemo.qa.projectfirma.com', 'conservation.idaho.gov', '7/1/1990', 1, 1, 0),
(11, 'ActionAgendaForPugetSound', 'actionagendatracker.localhost.projectfirma.com', 'qa-actionagenda.pugetsoundinfo.wa.gov', 'actionagenda.pugetsoundinfo.wa.gov', '1/1/1990', 0, 0, 1),
-- This will work until the inevitable vanity URLs arrive:
(12, 'BureauOfReclamation', 'OBSOLETE_HOSTED_INDEPENDENTLY_bor.localhost.projectfirma.com', 'OBSOLETE_HOSTED_INDEPENDENTLY_bor.qa.projectfirma.com', 'OBSOLETE_HOSTED_INDEPENDENTLY_bor.projectfirma.com', '1990-01-01', 0, 0, 0)