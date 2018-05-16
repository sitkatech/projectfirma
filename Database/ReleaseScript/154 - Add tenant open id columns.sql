alter table dbo.Tenant add KeystoneOpenIDClientIdentifier varchar(256) null, KeystoneOpenIDClientSecret varchar(256) null
GO

update dbo.Tenant
set KeystoneOpenIDClientIdentifier = 'ProjectFirma',
KeystoneOpenIDClientSecret = '6C0D5ACB-EF45-4081-AFDA-754DA37A87BD'
where TenantID in (1, 4, 5, 6, 7, 8, 9)

update dbo.Tenant
set KeystoneOpenIDClientIdentifier = 'ClackamasPartnership',
KeystoneOpenIDClientSecret = '2F404371-D118-4C17-9F5E-C94713CAA1FB'
where TenantID = 2


update dbo.Tenant
set KeystoneOpenIDClientIdentifier = 'RCDProjectTracker',
KeystoneOpenIDClientSecret = '1C2E2422-2376-4F83-B75B-7DA2A4B3A106'
where TenantID = 3




alter table dbo.Tenant alter column KeystoneOpenIDClientIdentifier varchar(256) not null
alter table dbo.Tenant alter column KeystoneOpenIDClientSecret varchar(256) not null
