drop table dbo.ProjectProjectStatus

go


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectProjectStatus](
	[ProjectProjectStatusID] [int] IDENTITY(1,1) NOT NULL,
    [TenantID] int NOT NULL,
	[ProjectID] [int] NOT NULL,
	[ProjectStatusID] [int] NOT NULL,
	[ProjectProjectStatusUpdateDate] [datetime] NOT NULL,
	[ProjectProjectStatusComment] [varchar](2500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ProjectProjectStatusCreatePersonID] [int] NOT NULL,
	[ProjectProjectStatusCreateDate] [datetime] NOT NULL,
	[ProjectProjectStatusLastEditedPersonID] [int] NULL,
	[ProjectProjectStatusLastEditedDate] [datetime] NULL,
 CONSTRAINT [PK_ProjectProjectStatus_ProjectProjectStatusID] PRIMARY KEY CLUSTERED 
(
	[ProjectProjectStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[ProjectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_ProjectProjectStatus_Person_ProjectProjectStatusCreatePersonID_PersonID] FOREIGN KEY([ProjectProjectStatusCreatePersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectProjectStatus] CHECK CONSTRAINT [FK_ProjectProjectStatus_Person_ProjectProjectStatusCreatePersonID_PersonID]
GO
ALTER TABLE [dbo].[ProjectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_ProjectProjectStatus_Person_ProjectProjectStatusLastEditedPersonID_PersonID] FOREIGN KEY([ProjectProjectStatusLastEditedPersonID])
REFERENCES [dbo].[Person] ([PersonID])
GO
ALTER TABLE [dbo].[ProjectProjectStatus] CHECK CONSTRAINT [FK_ProjectProjectStatus_Person_ProjectProjectStatusLastEditedPersonID_PersonID]
GO
ALTER TABLE [dbo].[ProjectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_ProjectProjectStatus_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO
ALTER TABLE [dbo].[ProjectProjectStatus] CHECK CONSTRAINT [FK_ProjectProjectStatus_Project_ProjectID]
GO
ALTER TABLE [dbo].[ProjectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_ProjectProjectStatus_Tenant_TenantID] FOREIGN KEY([TenantID])
REFERENCES [dbo].[Tenant] ([TenantID])
GO
ALTER TABLE [dbo].[ProjectProjectStatus] CHECK CONSTRAINT [FK_ProjectProjectStatus_Tenant_TenantID]
GO


ALTER TABLE [dbo].[ProjectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_ProjectProjectStatus_ProjectStatus_ProjectStatusID] FOREIGN KEY([ProjectStatusID])
REFERENCES [dbo].[ProjectStatus] ([ProjectStatusID])
GO
ALTER TABLE [dbo].[ProjectProjectStatus] CHECK CONSTRAINT [FK_ProjectProjectStatus_ProjectStatus_ProjectStatusID]

go

alter table dbo.ProjectProjectStatus add constraint FK_ProjectProjectStatus_Person_ProjectProjectStatusCreatePersonID_TenantID foreign key (ProjectProjectStatusCreatePersonID, TenantID) references dbo.Person(PersonID, TenantID)
alter table dbo.ProjectProjectStatus add constraint FK_ProjectProjectStatus_Person_ProjectProjectStatusLastEditedPersonID_TenantID foreign key (ProjectProjectStatusLastEditedPersonID, TenantID) references dbo.Person(PersonID, TenantID)
alter table dbo.ProjectProjectStatus add constraint FK_ProjectProjectStatus_Project_ProjectID_TenantID foreign key (ProjectID, TenantID) references dbo.Project(ProjectID, TenantID)