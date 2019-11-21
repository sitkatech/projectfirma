CREATE TABLE [dbo].[ProjectStatus](
	[ProjectStatusID] [int] IDENTITY(1,1) NOT NULL,
    [TenantID] [int] NOT NULL,
	[ProjectStatusName] [varchar](100) NOT NULL,
    [ProjectStatusDescription] [varchar](100) NULL,
	[ProjectStatusDisplayName] [varchar](100) NOT NULL,
	[ProjectStatusSortOrder] [int] NOT NULL,
	[ProjectStatusColor] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ProjectStatus_ProjectStatusID] PRIMARY KEY CLUSTERED 
(
	[ProjectStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStatus_TenantID_ProjectStatusName] UNIQUE NONCLUSTERED 
(
	[TenantID] ASC,
    [ProjectStatusName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
)
GO

ALTER TABLE [dbo].[ProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_ProjectStatus_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO

INSERT INTO dbo.ProjectStatus (TenantID, ProjectStatusName, ProjectStatusDisplayName, ProjectStatusDescription, ProjectStatusSortOrder, ProjectStatusColor)
select TenantID, 'Green', 'Green', null, 5, '#04AF70' from Tenant

INSERT INTO dbo.ProjectStatus (TenantID, ProjectStatusName, ProjectStatusDisplayName, ProjectStatusDescription, ProjectStatusSortOrder, ProjectStatusColor)
select TenantID, 'Yellow', 'Yellow', null, 20, '#D0B001' from Tenant

INSERT INTO dbo.ProjectStatus (TenantID, ProjectStatusName, ProjectStatusDisplayName, ProjectStatusDescription, ProjectStatusSortOrder, ProjectStatusColor)
select TenantID, 'Red', 'Red', null, 30, '#FF0000' from Tenant

INSERT INTO dbo.ProjectStatus (TenantID, ProjectStatusName, ProjectStatusDisplayName, ProjectStatusDescription, ProjectStatusSortOrder, ProjectStatusColor)
select TenantID, 'OnHold', 'On Hold', null, 50, '#800080' from Tenant


insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values 
(67, 'ProjectStatusFromTimelineDialog', 'Project Status Timeline Dialog', 2)
GO

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 67, '<p>Adding a status update will add a new status history event with the date chosen to the project timeline. The status update with the most recent date will be displayed as the current status of the project. You can edit the details of status events from the project timeline on the project detail page.</p>' from Tenant t
GO

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values 
(68, 'ProjectStatusFromGridDialog', 'Project Status Grid Dialog', 2)
GO

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 68, '<p>Adding a status update will add a new status history event with the current date to the project timeline. This status because it is the most recent will be displayed as the current status of the project. You can edit the details of status events from the project timeline on the project detail page.</p>' from Tenant t
GO

/* Project Status list editor */
insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values 
(69, 'ProjectStatusListEditor', 'Project Status List Editor', 2)
GO

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 69, '<p>Add or edit project statuses that can be applied to project''s from the Project Grid or within the Project Timeline on a project detail page.</p>' from Tenant t
GO