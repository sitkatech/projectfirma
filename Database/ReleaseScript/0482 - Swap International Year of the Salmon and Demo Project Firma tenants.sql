
update dbo.Tenant
set TenantName = 'DemoProjectFirmaX',
CanonicalHostNameLocal = 'demo.localhost.projectfirma.com',
CanonicalHostNameQa = 'demo.qa.projectfirma.com',
CanonicalHostNameProd = 'demo.projectfirma.com',
TenantEnabled = 1
where TenantID = 4 

update dbo.Tenant
set TenantName = 'InternationYearOfTheSalmon',
CanonicalHostNameLocal = 'iysdemo.localhost.projectfirma.com',
CanonicalHostNameQa = 'iysdemo.qa.projectfirma.com',
CanonicalHostNameProd = 'iysdemo.projectfirma.com',
TenantEnabled = 0
where TenantID = 5

update dbo.Tenant
set TenantName = 'DemoProjectFirmaX',
CanonicalHostNameLocal = 'demo.localhost.projectfirma.com',
CanonicalHostNameQa = 'demo.qa.projectfirma.com',
CanonicalHostNameProd = 'demo.projectfirma.com',
TenantEnabled = 1
where TenantID = 4 

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'DemoProjectFirma',
KeystoneOpenIDClientSecret = '4A6D4335-4925-4BAF-A0A1-BB87E2C44096'
where TenantID = 4

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'InternationYearOfTheSalmon',
KeystoneOpenIDClientSecret = 'D3BAE523-0D42-471B-BBDD-54342AF22E54'
where TenantID = 5
