CREATE TABLE [dbo].[ProjectStatus](
	[ProjectStatusID] [int] NOT NULL,
	[ProjectStatusName] [varchar](100) NOT NULL,
	[ProjectStatusDisplayName] [varchar](100) NOT NULL,
	[ProjectStatusSortOrder] [int] NOT NULL,
	[ProjectStatusColor] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ProjectStatus_ProjectStatusID] PRIMARY KEY CLUSTERED 
(
	[ProjectStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStatus_ProjectStatusDisplayName] UNIQUE NONCLUSTERED 
(
	[ProjectStatusDisplayName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [AK_ProjectStatus_ProjectStatusName] UNIQUE NONCLUSTERED 
(
	[ProjectStatusName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values 
(67, 'ProjectStatusFromTimelineDialog', 'Project Status Timeline Dialog', 2)
GO

insert into dbo.FirmaPageType(FirmaPageTypeID, FirmaPageTypeName, FirmaPageTypeDisplayName, FirmaPageRenderTypeID)
values 
(68, 'ProjectStatusFromGridDialog', 'Project Status Grid Dialog', 2)
GO

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 67, '<p>Adding a status update will add a new status history event with the date chosen to the project timeline. The status update with the most recent date will be displayed as the current status of the project. You can edit the details of status events from the project timeline on the project detail page.</p>' from Tenant t
GO

insert into dbo.FirmaPage (TenantID, FirmaPageTypeID, FirmaPageContent)
select TenantID, 68, '<p>Adding a status update will add a new status history event with the current date to the project timeline. This status because it is the most recent will be displayed as the current status of the project. You can edit the details of status events from the project timeline on the project detail page.</p>' from Tenant t
GO