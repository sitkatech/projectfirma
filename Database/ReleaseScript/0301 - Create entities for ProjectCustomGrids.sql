
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
	ProjectCustomGridColumnDisplayName varchar(100) not null constraint AK_ProjectCustomGridColumn_ProjectCustomGridColumnDisplayName unique,
	IsOptional bit not null,

);

insert into dbo.ProjectCustomGridColumn(ProjectCustomGridColumnID, ProjectCustomGridColumnName, ProjectCustomGridColumnDisplayName, IsOptional)
values
(1, 'ProjectName', 'Project Name', 0),
(2, 'PrimaryContactOrganization', 'Primary Contact Organization', 0),
(3, 'ProjectStage', 'Project Stage', 0),
(4, 'NumberOfReportedPerformanceMeasures', 'Number of Reported Performance Measures', 1),
(5, 'ProjectsStewardOrganizationRelationshipToProject', 'Projects Steward Organization Relationship To Project', 1),
(6, 'ProjectPrimaryContact', 'Project Primary Contact', 1),
(7, 'ProjectPrimaryContactEmail', 'Project Primary Contact Email', 1),
(8, 'PlanningDesignStartYear', 'Planning Design Start Year', 1),
(9, 'ImplementationStartYear', 'Implementation Start Year', 1),
(10, 'CompletionYear', 'Completion Year', 1),
(11, 'PrimaryTaxonomyLeaf', 'Primary Taxonomy Leaf', 1),
(12, 'SecondaryTaxonomyLeaf', 'Secondary Taxonomy Leaf', 1),
(13, 'NumberOfReportedExpenditures', 'Number of Reported Expenditures', 1),
(14, 'FundingType', 'Funding Type', 1),
(15, 'EstimatedTotalCost', 'Estimated Total Cost', 1),
(16, 'SecuredFunding', 'Secured Funding', 1),
(17, 'TargetedFunding', 'Targeted Funding', 1),
(18, 'NoFundingSourceIdentified', 'No Funding Source Identified', 1),
(19, 'ProjectDescription', 'Project Description', 1),
(20, 'NumberOfPhotos', 'Number of Photos', 1),
(21, 'GeospatialAreaName', 'Geospatial Area Name', 1),
(22, 'CustomAttribute', 'Custom Attribute', 1),
(23, 'ProjectID', 'ProjectID', 1)



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
-- SortOrder must be not null if enabled, otherwise null
alter table dbo.ProjectCustomGridConfiguration
add constraint CK_ProjectCustomGridConfiguration_SortOrder_OnlyIf_IsEnabled check ((IsEnabled = 1 and SortOrder is not null) or (IsEnabled = 0 and SortOrder is null))
go

-- Create FirmaPage to Manage page
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(64, 'ManageProjectCustomGrids', 'Manage Project Custom Grids', 1)
go

insert into dbo.FirmaPage(TenantID, FirmaPageTypeID, FirmaPageContent)
values
(11, 64, '<p>Manage Project Custom Grids introductory text.</p>')
