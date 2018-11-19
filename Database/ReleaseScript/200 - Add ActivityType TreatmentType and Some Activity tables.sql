CREATE TABLE dbo.ActivityType(
	ActivityTypeID int NOT NULL constraint PK_ActivityType_ActivityTypeID primary key,
	ActivityTypeName varchar(50) NOT NULL constraint AK_ActivityType_ActivityTypeName unique,
	ActivityTypeDisplayName varchar(50) NOT NULL constraint AK_ActivityType_ActivityTypeDisplayName unique
)

CREATE TABLE dbo.TreatmentType(
	TreatmentTypeID int NOT NULL constraint PK_TreatmentType_TreatmentTypeID primary key,
	TreatmentTypeName varchar(50) NOT NULL constraint AK_TreatmentType_TreatmentTypeName unique,
	TreatmentTypeDisplayName varchar(50) NOT NULL constraint AK_TreatmentType_TreatmentTypeDisplayName unique
)

Insert into dbo.ActivityType (ActivityTypeID, ActivityTypeName, ActivityTypeDisplayName)
values
(1, 'Travel', 'Travel'),
(2, 'StaffTime', 'Staff Time'),
(3, 'Treatment', 'Treatment'),
(4, 'ContractorTime', 'Contractor Time'),
(5, 'Supplies', 'Supplies')

--TODO
Insert into dbo.TreatmentType (TreatmentTypeID, TreatmentTypeName, TreatmentTypeDisplayName)
values
(1, 'ToDo', 'To-do')

Create Table dbo.StaffTimeActivity(
	StaffTimeActivityID int not null identity(1,1) constraint PK_StaffTimeActivity_StaffTimeActivityID primary key,
	TenantID int not null constraint FK_StaffTimeActivity_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID int not null constraint FK_StaffTimeActivity_Project_ProjectID foreign key references dbo.Project(ProjectID),
	StaffTimeActivityHours int not null,
	StaffTimeActivityRate money not null,
	StaffTimeActivityTotalAmount money not null,
	StaffTimeActivityStartDate datetime not null,
	StaffTimeActivityEndDate datetime null,
	StaffTimeActivityNotes varchar(max) not null,
	Constraint AK_StaffTimeActivity_StaffTimeActivityID_TenantID unique(StaffTimeActivityID, TenantID),
	Constraint FK_StaffTimeActivity_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID)
)

Create Table dbo.TreatmentActivity(
	TreatmentActivityID int not null identity(1,1) constraint PK_TreatmentActivity_TreatmentActivityID primary key,
	TenantID int not null constraint FK_TreatmentActivity_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectID int not null constraint FK_TreatmentActivity_Project_ProjectID foreign key references dbo.Project(ProjectID),
	TreatmentActivityTypeID int not null constraint FK_TreatmentActivity_TreatmentType_TreatmentActivityTypeID foreign key references dbo.TreatmentType(TreatmentTypeID),
	TreatmentActivityAcresTreated decimal not null,
	TreatmentActivityStartDate datetime not null,
	TreatmentActivityEndDate datetime null,
	TreatmentActivityNotes varchar(max) not null,
	Constraint AK_TreatmentActivity_TreatmentActivityID_TenantID unique(TreatmentActivityID, TenantID),
	Constraint FK_TreatmentActivity_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID)
)