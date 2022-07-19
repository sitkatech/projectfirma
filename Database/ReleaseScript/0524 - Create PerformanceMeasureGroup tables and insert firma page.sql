
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values
(87, 'ManagePerformanceMeasures', 'ManagePerformanceMeasures', 1)

-- just copy over the content from PerformanceMeasuresList for now
insert into dbo.FirmaPage (FirmaPageTypeID, TenantID,  FirmaPageContent)
select 87, TenantID, FirmaPageContent from dbo.FirmaPage where FirmaPageTypeID = 9

INSERT [dbo].[FieldDefinition] ([FieldDefinitionID], [FieldDefinitionName], [FieldDefinitionDisplayName]) 
VALUES 
(377, N'PerformanceMeasureGroup', N'Performance Measure Group')

insert into dbo.FieldDefinitionDefault (FieldDefinitionID, DefaultDefinition)
values
(377, 'A grouping of Performance Measures. These groups are used by the Accomplishment Dashboard.')


create table dbo.PerformanceMeasureGroup (
	PerformanceMeasureGroupID int identity(1,1) not null constraint PK_PerformanceMeasureGroup_PerformanceMeasureGroupID primary key,
	TenantID int not null constraint FK_PerformanceMeasureGroup_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	PerformanceMeasureGroupName varchar(200) not null,
	IconFileResourceInfoID int null constraint FK_PerformanceMeasureGroup_FileResourceInfo_IconFileResourceInfoID_FileResourceInfoID foreign key references dbo.FileResourceInfo(FileResourceInfoID),
	constraint AK_PerformanceMeasureGroup_PerformanceMeasureGroupID_TenantID unique (PerformanceMeasureGroupID, TenantID),
	constraint AK_PerformanceMeasureGroup_PerformanceMeasureGroupName_TenantID unique (PerformanceMeasureGroupName, TenantID)
)

/*
create table dbo.PerformanceMeasureGroupPerformanceMeasure (
	PerformanceMeasureGroupPerformanceMeasureID  int identity(1,1) not null constraint PK_PerformanceMeasureGroupPerformanceMeasure_PerformanceMeasureGroupPerformanceMeasureID primary key,
	TenantID int not null constraint FK_PerformanceMeasureGroupPerformanceMeasure_Tenant_TenantID foreign key references dbo.Tenant(TenantID),
	PerformanceMeasureGroupID int not null constraint FK_PerformanceMeasureGroupPerformanceMeasure_PerformanceMeasureGroup_PerformanceMeasureGroupID foreign key references dbo.PerformanceMeasureGroup(PerformanceMeasureGroupID),
	PerformanceMeasureID int not null constraint FK_PerformanceMeasureGroupPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID foreign key references dbo.PerformanceMeasure(PerformanceMeasureID),
	constraint AK_PerformanceMeasureGroupPerformanceMeasure_PerformanceMeasureGroupPerformanceMeasureID_TenantID unique (PerformanceMeasureGroupPerformanceMeasureID, TenantID)
)
*/

alter table dbo.PerformanceMeasure add PerformanceMeasureGroupID int null constraint FK_PerformanceMeasure_PerformanceMeasureGroup_PerformanceMeasureGroupID foreign key references dbo.PerformanceMeasureGroup(PerformanceMeasureGroupID)

alter table dbo.TenantAttribute add EnableSimpleAccomplishmentsDashboard bit null
go
update dbo.TenantAttribute set EnableSimpleAccomplishmentsDashboard = 0
alter table dbo.TenantAttribute alter column EnableSimpleAccomplishmentsDashboard bit not null 