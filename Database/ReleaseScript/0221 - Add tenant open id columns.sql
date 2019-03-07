alter table dbo.TenantAttribute add KeystoneOpenIDClientIdentifier varchar(256) null, KeystoneOpenIDClientSecret varchar(256) null
GO

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'SitkaProjectFirma'
where TenantID = 1

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'ClackamasPartnership'
where TenantID = 2


update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'RCDProjectTracker'
where TenantID = 3

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'InternationYearOfTheSalmon'
where TenantID = 4

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'DemoProjectFirma'
where TenantID = 5

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'PeaksToPeople'
where TenantID = 6

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'JohnDayPartnership'
where TenantID = 7

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'AshlandForestAllLandsRestorationInitiative'
where TenantID = 8

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'IdahoAssociatonOfSoilConservationDistricts'
where TenantID = 9

update dbo.TenantAttribute
set KeystoneOpenIDClientIdentifier = 'ActionAgendaForPugetSound'
where TenantID = 11

update t
set t.KeystoneOpenIDClientSecret = c.ClientSecret
from dbo.TenantAttribute t 
join Keystone.dbo.Client c on t.KeystoneOpenIDClientIdentifier = c.ClientIdentifier

alter table dbo.TenantAttribute alter column KeystoneOpenIDClientIdentifier varchar(256) not null
alter table dbo.TenantAttribute alter column KeystoneOpenIDClientSecret varchar(256) not null



--select * from dbo.Tenant

--select 
--	c.ClientIdentifier,
--	c.ClientSecret, 
--	ta.TenantDisplayName
--from Keystone.dbo.Client c
--left join ProjectFirma.dbo.TenantAttribute ta on c.ClientIdentifier = ta.KeystoneOpenIDClientIdentifier
