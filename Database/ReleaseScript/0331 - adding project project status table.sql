CREATE TABLE [dbo].[ProjectProjectStatus](
	[ProjectProjectStatusID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectID] [int] NOT NULL,
    [ProjectStatusID] [int] NOT NULL,
    [ProjectProjectStatusUpdateDate] [datetime] NOT NULL,
	[ProjectProjectStatusComment] varchar(2500) NOT NULL,
	[ProjectProjectStatusCreatePersonID] [int] NOT NULL,
    [ProjectProjectStatusCreateDate] [datetime] NOT NULL,
    [ProjectProjectStatusLastEditedPersonID] [int] NULL,
    [ProjectProjectStatusLastEditedDate] [datetime] NULL
 CONSTRAINT [PK_ProjectProjectStatus_ProjectProjectStatusID] PRIMARY KEY CLUSTERED 
(
	[ProjectProjectStatusID] ASC
) ON [PRIMARY],
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProjectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_ProjectProjectStatus_Project_ProjectID] FOREIGN KEY([ProjectID])
REFERENCES [dbo].[Project] ([ProjectID])
GO

ALTER TABLE [dbo].[ProjectProjectStatus] CHECK CONSTRAINT [FK_ProjectProjectStatus_Project_ProjectID]
GO


ALTER TABLE [dbo].[ProjectProjectStatus]  WITH CHECK ADD  CONSTRAINT [FK_ProjectProjectStatus_ProjectStatus_ProjectStatusID] FOREIGN KEY([ProjectStatusID])
REFERENCES [dbo].[ProjectStatus] ([ProjectStatusID])
GO

ALTER TABLE [dbo].[ProjectProjectStatus] CHECK CONSTRAINT [FK_ProjectProjectStatus_ProjectStatus_ProjectStatusID]
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


