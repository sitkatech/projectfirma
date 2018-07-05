create table dbo.ProjectCustomAttributeDataType(
	ProjectCustomAttributeDataTypeID int not null constraint PK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeID primary key,
	ProjectCustomAttributeDataTypeName varchar(100) not null,
	ProjectCustomAttributeDataTypeDisplayName varchar(100) not null,
	constraint AK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeDisplayName unique (ProjectCustomAttributeDataTypeDisplayName),
	constraint AK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeName unique (ProjectCustomAttributeDataTypeName)
)

create table dbo.ProjectCustomAttributeType(
	ProjectCustomAttributeTypeID int identity(1,1) not null constraint PK_ProjectCustomAttributeType_ProjectCustomAttributeTypeID primary key (ProjectCustomAttributeTypeID),
	TenantID int not null constraint FK_ProjectCustomAttributeType_Tenant_TenantID foreign key references dbo.Tenant (TenantID),
	ProjectCustomAttributeTypeName varchar(100) not null constraint AK_ProjectCustomAttributeType_ProjectCustomAttributeTypeName unique,
	ProjectCustomAttributeDataTypeID int not null constraint FK_ProjectCustomAttributeType_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeID foreign key references dbo.ProjectCustomAttributeDataType (ProjectCustomAttributeDataTypeID),
	MeasurementUnitTypeID int null constraint FK_ProjectCustomAttributeType_MeasurementUnitType_MeasurementUnitTypeID foreign key references dbo.MeasurementUnitType (MeasurementUnitTypeID),
	IsRequired bit not null,
	ProjectCustomAttributeTypeDescription varchar(200) null,
	ProjectCustomAttributeTypeOptionsSchema varchar(max) null,
	constraint AK_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID unique (ProjectCustomAttributeTypeID, TenantID),
	constraint CK_ProjectCustomAttributeType_PickListTypeOptionSchemaNotNull check (not (ProjectCustomAttributeDataTypeID = 6 or ProjectCustomAttributeDataTypeID = 5) and ProjectCustomAttributeTypeOptionsSchema is null or (ProjectCustomAttributeDataTypeID = 6 or ProjectCustomAttributeDataTypeID = 5) and ProjectCustomAttributeTypeOptionsSchema is not null)
)

create table dbo.ProjectCustomAttribute(
	ProjectCustomAttributeID int identity(1,1) not null constraint PK_ProjectCustomAttribute_ProjectCustomAttributeID primary key,
	TenantID int not null constraint FK_ProjectCustomAttribute_Tenant_TenantID foreign key references dbo.Tenant (TenantID),
	ProjectID int not null constraint FK_ProjectCustomAttribute_Project_ProjectID foreign key references dbo.Project (ProjectID),
	
	ProjectCustomAttributeTypeID int not null constraint FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID foreign key references dbo.ProjectCustomAttributeType (ProjectCustomAttributeTypeID),
	constraint AK_ProjectCustomAttribute_ProjectCustomAttributeID_TenantID unique (ProjectCustomAttributeID, TenantID),
	
	constraint FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID foreign key(ProjectCustomAttributeTypeID, TenantID) references dbo.ProjectCustomAttributeType (ProjectCustomAttributeTypeID, TenantID),
	constraint FK_ProjectCustomAttribute_Project_ProjectID_TenantID foreign key(ProjectID, TenantID) references dbo.Project (ProjectID, TenantID)
)

alter table dbo.ProjectUpdate add constraint AK_ProjectUpdate_ProjectUpdateID_TenantID unique (ProjectUpdateID, TenantID)

create table dbo.ProjectCustomAttributeUpdate(
	ProjectCustomAttributeUpdateID int identity(1,1) not null constraint PK_ProjectCustomAttributeUpdate_ProjectCustomAttributeUpdateID primary key,
	TenantID int not null constraint FK_ProjectCustomAttributeUpdate_Tenant_TenantID foreign key references dbo.Tenant (TenantID),
	ProjectUpdateBatchID int not null constraint FK_ProjectCustomAttributeUpdate_ProjectUpdateBatch_ProjectUpdateBatchID foreign key references dbo.ProjectUpdateBatch (ProjectUpdateBatchID),
	
	ProjectCustomAttributeTypeID int not null constraint FK_ProjectCustomAttributeUpdate_ProjectCustomAttributeType_ProjectCustomAttributeTypeID foreign key references dbo.ProjectCustomAttributeType (ProjectCustomAttributeTypeID),
	constraint AK_ProjectCustomAttributeUpdate_ProjectCustomAttributeUpdateID_TenantID unique (ProjectCustomAttributeUpdateID, TenantID),
	
	constraint FK_ProjectCustomAttributeUpdate_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID foreign key(ProjectCustomAttributeTypeID, TenantID) references dbo.ProjectCustomAttributeType (ProjectCustomAttributeTypeID, TenantID),
	constraint FK_ProjectCustomAttributeUpdate_ProjectUpdate_ProjectUpdateID_TenantID foreign key(ProjectUpdateBatchID, TenantID) references dbo.ProjectUpdateBatch (ProjectUpdateBatchID, TenantID),
)

create table dbo.ProjectCustomAttributeValue(
	ProjectCustomAttributeValueID int identity(1,1) not null constraint PK_ProjectCustomAttributeValue_ProjectCustomAttributeValueID primary key,
	TenantID int not null constraint FK_ProjectCustomAttributeValue_Tenant_TenantID foreign key references dbo.Tenant (TenantID),
	ProjectCustomAttributeID int not null constraint FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID foreign key references dbo.ProjectCustomAttribute (ProjectCustomAttributeID),
	AttributeValue varchar(1000) not null,
	constraint FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID_TenantID foreign key(ProjectCustomAttributeID, TenantID) references dbo.ProjectCustomAttribute (ProjectCustomAttributeID, TenantID)
)

create table dbo.ProjectCustomAttributeUpdateValue(
	ProjectCustomAttributeUpdateValueID int identity(1,1) not null constraint PK_ProjectCustomAttributeUpdateValue_ProjectCustomAttributeUpdateValueID primary key,
	TenantID int not null constraint FK_ProjectCustomAttributeUpdateValue_Tenant_TenantID foreign key references dbo.Tenant (TenantID),
	ProjectCustomAttributeUpdateID int not null constraint FK_ProjectCustomAttributeUpdateValue_ProjectCustomAttributeUpdate_ProjectCustomAttributeUpdateID foreign key references dbo.ProjectCustomAttributeUpdate (ProjectCustomAttributeUpdateID),
	AttributeValue varchar(1000) not null,
	constraint FK_ProjectCustomAttributeUpdateValue_ProjectCustomAttributeUpdate_ProjectCustomAttributeUpdateID_TenantID foreign key(ProjectCustomAttributeUpdateID, TenantID) references dbo.ProjectCustomAttributeUpdate (ProjectCustomAttributeUpdateID, TenantID)
)

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(52, 'ManageProjectCustomAttributeTypeInstructions', 'Manage Project Custom Attribute Type Instructions', 2),
(53, 'ManageProjectCustomAttributeInstructions', 'Manage Project Custom Attribute Instructions', 2),
(54, 'ManageProjectCustomAttributeTypesList', 'Manage Project Custom Attribute Types List', 2)

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select
	TenantID,
	FirmaPageType = 52,
	FirmaPageContent = null
from dbo.Tenant
insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select
	TenantID,
	FirmaPageType = 53,
	FirmaPageContent = null
from dbo.Tenant
insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
select
	TenantID,
	FirmaPageType = 54,
	FirmaPageContent = null
from dbo.Tenant
