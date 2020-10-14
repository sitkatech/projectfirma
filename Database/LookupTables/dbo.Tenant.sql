delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, CanonicalHostNameLocal, CanonicalHostNameQa, CanonicalHostNameProd, ReportingYearStartDate, UseFiscalYears, UsesTechnicalAssistanceParameters, ArePerformanceMeasuresExternallySourced, AreOrganizationsExternallySourced, AreFundingSourcesExternallySourced, TenantEnabled)
values 
(1, 'SitkaTechnologyGroup', 'sitka.localhost.projectfirma.com', 'sitka.qa.projectfirma.com', 'sitka.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 0, 1),
(2, 'ClackamasPartnership', 'clackamaspartnership.localhost.projectfirma.com', 'qa.clackamaspartnership.org', 'www.clackamaspartnership.org', '1/1/1990', 0, 0, 0, 0, 0, 1),
(3, 'RCDProjectTracker', 'rcdprojects.localhost.projectfirma.com', 'qa.rcdprojects.org', 'www.rcdprojects.org', '1/1/1990', 0, 0, 0, 0, 0, 1),
(4, 'InternationYearOfTheSalmon', 'iysdemo.localhost.projectfirma.com', 'iysdemo.qa.projectfirma.com', 'iysdemo.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 0, 0),
(5, 'DemoProjectFirma', 'demo.localhost.projectfirma.com', 'demo.qa.projectfirma.com', 'demo.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 0, 1),
(6, 'PeaksToPeople', 'peakstopeople.localhost.projectfirma.com', 'qa-outcomes.peakstopeople.org', 'outcomes.peakstopeople.org', '1/1/1990', 0, 0, 0, 0, 0, 1),
(7, 'JohnDayBasinPartnership', 'johndaybasinpartnership.localhost.projectfirma.com', 'qa.johndaybasinpartnership.org', 'www.johndaybasinpartnership.org', '1/1/1990', 0, 0, 0, 0, 0, 1),
(8, 'AshlandForestAllLandsRestorationInitiative', 'ashlanddemo.localhost.projectfirma.com', 'ashlanddemo.qa.projectfirma.com', 'ashlanddemo.projectfirma.com', '1/1/1990', 0, 0, 0, 0, 0, 0),
(9, 'IdahoAssociatonOfSoilConservationDistricts', 'swcdemo.localhost.projectfirma.com', 'swcdemo.qa.projectfirma.com', 'conservation.idaho.gov', '7/1/1990', 1, 1, 0, 0, 0, 1),
(11, 'ActionAgendaForPugetSound', 'actionagendatracker.localhost.projectfirma.com', 'qa-actionagenda.pugetsoundinfo.wa.gov', 'actionagenda.pugetsoundinfo.wa.gov', '1/1/1990', 0, 0, 1, 1, 1, 1),
-- This will work until the inevitable vanity URLs arrive:
(12, 'BureauOfReclamation', 'OBSOLETE_HOSTED_INDEPENDENTLY_bor.localhost.projectfirma.com', 'OBSOLETE_HOSTED_INDEPENDENTLY_bor.qa.projectfirma.com', 'OBSOLETE_HOSTED_INDEPENDENTLY_bor.projectfirma.com', '1990-01-01', 0, 0, 0, 0, 0, 0)