
create table dbo.ProjectCustomGridType (
	ProjectCustomGridTypeID int not null constraint PK_ProjectCustomGridType_ProjectCustomGridTypeID primary key,
	ProjectCustomGridTypeName varchar(100) not null constraint AK_ProjectCustomGridType_ProjectCustomGridTypeName unique,
	ProjectCustomGridTypeDisplayName varchar(100) not null constraint AK_ProjectCustomGridType_ProjectCustomGridTypeDisplayName unique
);

insert into dbo.ProjectCustomGridType(ProjectCustomGridTypeID, ProjectCustomGridTypeName, ProjectCustomGridTypeDisplayName)
values
(1, 'Default', 'Default'),
(2, 'Full', 'Full')

create table dbo.ProjectCustomGridColumn (
	ProjectCustomGridColumnID int not null constraint PK_ProjectCustomGridColumn_ProjectCustomGridColumnID primary key,
	ProjectCustomGridColumnName varchar(100) not null constraint AK_ProjectCustomGridColumn_ProjectCustomGridColumnName unique,
	ProjectCustomGridColumnDisplayName varchar(100) not null constraint AK_ProjectCustomGridColumn_ProjectCustomGridColumnDisplayName unique
);

insert into dbo.ProjectCustomGridColumn(ProjectCustomGridColumnID, ProjectCustomGridColumnName, ProjectCustomGridColumnDisplayName)
values
(1, 'PerformanceMeasureCount', 'Performance Measure Count'),
(2, 'GeospatialAreaName', 'Geospatial Area Name'),
(3, 'CustomAttribute', 'Custom Attribute')

create table dbo.ProjectCustomGridConfiguration (
	ProjectCustomGridConfigurationID int not null identity(1,1) constraint PK_ProjectCustomGridConfiguration_ProjectCustomGridConfigurationID primary key,
	TenantID int not null constraint FK_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	ProjectCustomGridTypeID int not null constraint FK_ProjectCustomGridType_ProjectCustomGridTypeID foreign key references dbo.ProjectCustomGridType(ProjectCustomGridTypeID),
	ProjectCustomGridColumnID int not null constraint FK_ProjectCustomGridColumn_ProjectCustomGridColumnID foreign key references dbo.ProjectCustomGridColumn(ProjectCustomGridColumnID),
	ProjectCustomAttributeTypeID int null constraint FK_ProjectCustomAttributeType_ProjectCustomAttributeTypeID foreign key references dbo.ProjectCustomAttributeType(ProjectCustomAttributeTypeID),
	GeospatialAreaTypeID int null constraint FK_GeospatialAreaType_GeospatialAreaTypeID foreign key references dbo.GeospatialAreaType(GeospatialAreaTypeID),
	IsEnabled bit not null,
	SortOrder int null
);

alter table dbo.ProjectCustomGridConfiguration
add constraint CK_ProjectCustomGridConfiguration_SortOrder_OnlyIf_IsEnabled check ((IsEnabled = 1 and SortOrder is not null) or (IsEnabled = 0 and SortOrder is null))
go

insert into dbo.ProjectCustomGridConfiguration(TenantID, ProjectCustomGridTypeID, ProjectCustomGridColumnID, ProjectCustomAttributeTypeID, GeospatialAreaTypeID, IsEnabled, SortOrder)
values
(11, 2, 1, null, null, 1, 10),
(11, 2, 2, null, 19, 1, 20)
