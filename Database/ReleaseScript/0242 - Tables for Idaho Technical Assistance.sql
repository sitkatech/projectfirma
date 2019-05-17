
-- Technical Assitance type lookup table
create table dbo.TechnicalAssistanceType (
	TechnicalAssistanceTypeID int not null constraint PK_TechnicalAssistanceType_TechnicalAssistanceTypeID primary key,
	TechnicalAssistanceTypeName varchar(100) not null constraint AK_TechnicalAssistanceType_TechnicalAssistanceTypeName unique,
	TechnicalAssistanceTypeDisplayName varchar(100) not null constraint AK_TechnicalAssistanceType_TechnicalAssistanceTypeDisplayName unique
);
insert into dbo.TechnicalAssistanceType(TechnicalAssistanceTypeID, TechnicalAssistanceTypeName, TechnicalAssistanceTypeDisplayName)
values
	(1, 'CapacityBuilding', 'Capacity Building'),
	(2, 'EducationOutreach', 'Education/Outreach'),
	(3, 'Engineering', 'Engineering'),
	(4, 'Operations', 'Operations'),
	(5, 'TechnicalAssistance', 'Technical Assistance')
go

-- Technical Assistance Request table
create table dbo.TechnicalAssistanceRequest (
	TechnicalAssistanceRequestID int not null identity(1,1) constraint PK_TechnicalAssistanceRequest_TechnicalAssistanceRequestID primary key,
	TenantID int not null constraint FK_TechnicalAssitanceRequest_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID int not null constraint FK_TechnicalAssistanceRequest_Project_ProjectID foreign key references dbo.Project(ProjectID),
	FiscalYear int not null,
	PersonID int null constraint FK_TechnicalAssistanceRequest_Person_PersonID foreign key references dbo.Person(PersonID),
	TechnicalAssistanceTypeID int not null constraint FK_TechnicalAssistanceRequest_TechnicalAssistanceType_TechnicalAssistanceTypeID foreign key references dbo.TechnicalAssistanceType(TechnicalAssistanceTypeID),
	HoursRequested int null,
	HoursAllocated int null,
	HoursProvided int null,
	Notes varchar(max) null
);

-- Technical Assistance Request Update table
create table dbo.TechnicalAssistanceRequestUpdate (
	TechnicalAssistanceRequestUpdateID int not null identity(1,1) constraint PK_TechnicalAssistanceRequestUpdate_TechnicalAssistanceRequestUpdateID primary key,
    TenantID int not null constraint FK_TechnicalAssitanceRequestUpdate_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectUpdateBatchID int not null constraint FK_TechnicalAssistanceRequestUpdate_ProjectUpdateBatch_ProjectUpdateBatchID foreign key references dbo.ProjectUpdateBatch(ProjectUpdateBatchID),
	FiscalYear int not null,
	PersonID int null constraint FK_TechnicalAssistanceRequestUpdate_Person_PersonID foreign key references dbo.Person(PersonID),
	TechnicalAssistanceTypeID int not null constraint FK_TechnicalAssistanceRequestUpdate_TechnicalAssistanceType_TechnicalAssistanceTypeID foreign key references dbo.TechnicalAssistanceType(TechnicalAssistanceTypeID),
	HoursRequested int null,
	HoursAllocated int null,
	HoursProvided int null,
	Notes varchar(max) null
);

-- Add needed fields to ProjectUpdateBatch

alter table dbo.ProjectUpdateBatch
add TechnicalAssistanceRequestsComment varchar(1000) null
go
alter table dbo.ProjectUpdateBatch
add TechnicalAssistanceRequestsDiffLog varchar(max) null
go
