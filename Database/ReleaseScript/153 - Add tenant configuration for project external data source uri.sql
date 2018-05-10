create table dbo.ImportExternalProjectStaging(
	ImportExternalProjectStagingID int not null identity(1, 1) constraint PK_ImportExternalProjectStaging_ImportExternalProjectStagingID primary key,
	TenantID int not null constraint FK_ImportExternalProjectStaging_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	CreatePersonID int not null constraint FK_ImportExternalProjectStaging_Person_CreatePersonID_PersonID foreign key references dbo.Person(PersonID),
		constraint FK_ImportExternalProjectStaging_Person_PersonID_TenantID foreign key (CreatePersonID, TenantID) references dbo.Person(PersonID, TenantID),
	CreateDate datetime not null,
	ProjectName varchar(140) null,
	Description varchar(4000) null,
	PlanningDesignStartYear smallint null,
	ImplementationStartYear smallint null,
	EndYear smallint null,
	EstimatedCost float null
)

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
