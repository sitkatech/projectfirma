delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, TenantDomain, IsSubDomain) 
values 
(1, 'SitkaTechnologyGroup', 'sitka.projectfirma.com', 1),
(2, 'ClackamasPartnership', 'clackamaspartnership.org', 0),
(3, 'RCDProjectTracker', 'rcdprojects.org', 0),
(4, 'InternationYearOfTheSalmon', 'iysdemo.projectfirma.com', 1),
(5, 'DemoProjectFirma', 'demo.projectfirma.com', 1),
(6, 'NationalForestFoundation', 'nffdemo.projectfirma.com', 1)