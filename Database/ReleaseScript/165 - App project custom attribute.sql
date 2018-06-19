create table dbo.ProjectCustomAttributeDataType(
	ProjectCustomAttributeDataTypeID int not null constraint PK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeID primary key,
	ProjectCustomAttributeDataTypeName varchar(100) not null,
	ProjectCustomAttributeDataTypeDisplayName varchar(100) not null,
	constraint AK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeDisplayName unique (ProjectCustomAttributeDataTypeDisplayName),
	constraint AK_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeName unique (ProjectCustomAttributeDataTypeName)
)

create table dbo.ProjectCustomAttributeTypePurpose(
	ProjectCustomAttributeTypePurposeID int not null constraint PK_ProjectCustomAttributeTypePurpose_ProjectCustomAttributeTypePurposeID primary key (ProjectCustomAttributeTypePurposeID),
	ProjectCustomAttributeTypePurposeName varchar(60) not null,
	ProjectCustomAttributeTypePurposeDisplayName varchar(60) not null,
	constraint AK_ProjectCustomAttributeTypePurpose_ProjectCustomAttributeTypePurposeDisplayName unique (ProjectCustomAttributeTypePurposeDisplayName),
	constraint AK_ProjectCustomAttributeTypePurpose_ProjectCustomAttributeTypePurposeName unique (ProjectCustomAttributeTypePurposeName)
)

create table dbo.ProjectCustomAttributeType(
	ProjectCustomAttributeTypeID int identity(1,1) not null constraint PK_ProjectCustomAttributeType_ProjectCustomAttributeTypeID primary key (ProjectCustomAttributeTypeID),
	TenantID int not null constraint FK_ProjectCustomAttributeType_Tenant_TenantID foreign key references dbo.Tenant (TenantID),
	ProjectCustomAttributeTypeName varchar(100) not null constraint AK_ProjectCustomAttributeType_ProjectCustomAttributeTypeName unique,
	ProjectCustomAttributeDataTypeID int not null constraint FK_ProjectCustomAttributeType_ProjectCustomAttributeDataType_ProjectCustomAttributeDataTypeID foreign key references dbo.ProjectCustomAttributeDataType (ProjectCustomAttributeDataTypeID),
	MeasurementUnitTypeID int null constraint FK_ProjectCustomAttributeType_MeasurementUnitType_MeasurementUnitTypeID foreign key references dbo.MeasurementUnitType (MeasurementUnitTypeID),
	IsRequired bit not null,
	ProjectCustomAttributeTypeDescription varchar(200) null,
	ProjectCustomAttributeTypePurposeID int not null constraint FK_ProjectCustomAttributeType_ProjectCustomAttributeTypePurpose_ProjectCustomAttributeTypePurposeID foreign key references dbo.ProjectCustomAttributeTypePurpose (ProjectCustomAttributeTypePurposeID),
	ProjectCustomAttributeTypeOptionsSchema varchar(max) null,
	constraint AK_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID unique (ProjectCustomAttributeTypeID, TenantID),
	constraint CK_ProjectCustomAttributeType_PickListTypeOptionSchemaNotNull check (not (ProjectCustomAttributeDataTypeID = 6 or ProjectCustomAttributeDataTypeID = 5) and ProjectCustomAttributeTypeOptionsSchema is null or (ProjectCustomAttributeDataTypeID = 6 or ProjectCustomAttributeDataTypeID = 5) and ProjectCustomAttributeTypeOptionsSchema is not null)
)

create table dbo.ProjectCustomAttribute(
	ProjectCustomAttributeID int identity(1,1) not null constraint PK_ProjectCustomAttribute_ProjectCustomAttributeID primary key,
	TenantID int not null constraint FK_ProjectCustomAttribute_Tenant_TenantID foreign key references dbo.Tenant (TenantID),
	ProjectID int not null constraint FK_ProjectCustomAttribute_Project_ProjectID foreign key references dbo.Project (ProjectID),
	
	--TreatmentBMPTypeProjectCustomAttributeTypeID int not null constraint FK_ProjectCustomAttribute_TreatmentBMPTypeProjectCustomAttributeType_TreatmentBMPTypeProjectCustomAttributeTypeID foreign key references dbo.TreatmentBMPTypeProjectCustomAttributeType (TreatmentBMPTypeProjectCustomAttributeTypeID),
	--TreatmentBMPTypeID int not null constraint FK_ProjectCustomAttribute_TreatmentBMPType_TreatmentBMPTypeID foreign key references dbo.TreatmentBMPType (TreatmentBMPTypeID),
	
	ProjectCustomAttributeTypeID int not null constraint FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID foreign key references dbo.ProjectCustomAttributeType (ProjectCustomAttributeTypeID),
	constraint AK_ProjectCustomAttribute_ProjectCustomAttributeID_TenantID unique (ProjectCustomAttributeID, TenantID),
	
	--constraint AK_ProjectCustomAttribute_TreatmentBMPTypeID_TreatmentBMPTypeProjectCustomAttributeTypeID unique (ProjectID, TreatmentBMPTypeID, ProjectCustomAttributeTypeID),	
	
	constraint FK_ProjectCustomAttribute_ProjectCustomAttributeType_ProjectCustomAttributeTypeID_TenantID foreign key(ProjectCustomAttributeTypeID, TenantID) references dbo.ProjectCustomAttributeType (ProjectCustomAttributeTypeID, TenantID),
	constraint FK_ProjectCustomAttribute_Project_ProjectID_TenantID foreign key(ProjectID, TenantID) references dbo.Project (ProjectID, TenantID),

	--constraint FK_ProjectCustomAttribute_Project_ProjectID_TreatmentBMPTypeID foreign key(ProjectID, TreatmentBMPTypeID) references dbo.Project (ProjectID, TreatmentBMPTypeID),
	--constraint FK_ProjectCustomAttribute_TreatmentBMPType_TreatmentBMPTypeID_TenantID foreign key(TreatmentBMPTypeID, TenantID) references dbo.TreatmentBMPType (TreatmentBMPTypeID, TenantID),
	--constraint FK_ProjectCustomAttribute_TreatmentBMPTypeProjectCustomAttributeType_TreatmentBMPTypeID_ProjectCustomAttributeTypeID foreign key(TreatmentBMPTypeID, ProjectCustomAttributeTypeID) references dbo.TreatmentBMPTypeProjectCustomAttributeType (TreatmentBMPTypeID, ProjectCustomAttributeTypeID)
)

create table dbo.ProjectCustomAttributeValue(
	ProjectCustomAttributeValueID int identity(1,1) not null constraint PK_ProjectCustomAttributeValue_ProjectCustomAttributeValueID primary key,
	TenantID int not null constraint FK_ProjectCustomAttributeValue_Tenant_TenantID foreign key references dbo.Tenant (TenantID),
	ProjectCustomAttributeID int not null constraint FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID foreign key references dbo.ProjectCustomAttribute (ProjectCustomAttributeID),
	AttributeValue varchar(1000) not null,
	constraint FK_ProjectCustomAttributeValue_ProjectCustomAttribute_ProjectCustomAttributeID_TenantID foreign key(ProjectCustomAttributeID, TenantID) references dbo.ProjectCustomAttribute (ProjectCustomAttributeID, TenantID)
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
