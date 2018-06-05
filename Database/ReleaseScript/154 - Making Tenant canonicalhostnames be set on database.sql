alter table dbo.Tenant add CanonicalHostNameLocal varchar(100) null, CanonicalHostNameQa varchar(100) null, CanonicalHostNameProd varchar(100) null
GO

update dbo.Tenant
set CanonicalHostNameLocal = 'sitka.localhost.projectfirma.com',
	CanonicalHostNameQa = 'sitka.qa.projectfirma.com',
	CanonicalHostNameProd = 'sitka.projectfirma.com'
where TenantID = 1

update dbo.Tenant
set CanonicalHostNameLocal = 'localhost.clackamaspartnership.org',
	CanonicalHostNameQa = 'qa.clackamaspartnership.org',
	CanonicalHostNameProd = 'www.clackamaspartnership.org'
where TenantID = 2

update dbo.Tenant
set CanonicalHostNameLocal = 'localhost.rcdprojects.org',
	CanonicalHostNameQa = 'qa.rcdprojects.org',
	CanonicalHostNameProd = 'www.rcdprojects.org'
where TenantID = 3

update dbo.Tenant
set CanonicalHostNameLocal = 'iysdemo.localhost.projectfirma.com',
	CanonicalHostNameQa = 'iysdemo.qa.projectfirma.com',
	CanonicalHostNameProd = 'iysdemo.projectfirma.com'
where TenantID = 4

update dbo.Tenant
set CanonicalHostNameLocal = 'demo.localhost.projectfirma.com',
	CanonicalHostNameQa = 'demo.qa.projectfirma.com',
	CanonicalHostNameProd = 'demo.projectfirma.com'
where TenantID = 5

update dbo.Tenant
set CanonicalHostNameLocal = 'peakstopeople.localhost.projectfirma.com',
	CanonicalHostNameQa = 'peakstopeople.qa.projectfirma.com',
	CanonicalHostNameProd = 'outcomes.peakstopeople.org'
where TenantID = 6

update dbo.Tenant
set CanonicalHostNameLocal = 'johndaydemo.localhost.projectfirma.com',
	CanonicalHostNameQa = 'johndaydemo.qa.projectfirma.com',
	CanonicalHostNameProd = 'johndaydemo.projectfirma.com'
where TenantID = 7

update dbo.Tenant
set CanonicalHostNameLocal = 'ashlanddemo.localhost.projectfirma.com',
	CanonicalHostNameQa = 'ashlanddemo.qa.projectfirma.com',
	CanonicalHostNameProd = 'ashlanddemo.projectfirma.com'
where TenantID = 8

update dbo.Tenant
set CanonicalHostNameLocal = 'swcdemo.localhost.projectfirma.com',
	CanonicalHostNameQa = 'swcdemo.qa.projectfirma.com',
	CanonicalHostNameProd = 'swcdemo.projectfirma.com'
where TenantID = 9

alter table dbo.Tenant alter column CanonicalHostNameLocal varchar(100) not null
alter table dbo.Tenant alter column CanonicalHostNameQa varchar(100) not null
alter table dbo.Tenant alter column CanonicalHostNameProd varchar(100) not null
ALTER TABLE dbo.Tenant DROP CONSTRAINT AK_Tenant_TenantDomain_TenantSubdomain
alter table dbo.Tenant drop column TenantDomain
alter table dbo.Tenant drop column TenantSubdomain


update dbo.TenantAttribute
set IsActive = 1
where TenantID = 9