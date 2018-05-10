insert into dbo.FirmaPageType
values
(50, 'ProjectCreateImportExternal', 'ProjectCreateImportExternal', 1)
insert into dbo.FirmaPage(FirmaPageTypeID, TenantID, FirmaPageContent)
select
	FirmaPageTypeID = 50,
	TenantID,
	FirmaPageContent = '<p>Enter a REST URI in the form below to continue to the create project workflow using information pulled from the provided endpoint.</p>'
from dbo.Tenant

alter table dbo.TenantAttribute add ProjectExternalDataSourceEnabled bit null
go
update dbo.TenantAttribute set ProjectExternalDataSourceEnabled = 0
go
alter table dbo.TenantAttribute alter column ProjectExternalDataSourceEnabled bit not null
