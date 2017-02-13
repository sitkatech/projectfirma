delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, TenantDomain) 
values 
(1, 'Sitka Technology Group', 'projectfirma.com'),
(2, 'Clackamas Partnership', 'clackamaspartnership.org')