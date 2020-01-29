--begin tran

ALTER TABLE dbo.Project 
ADD ProjectTypeID int not null DEFAULT 1
GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectType_ProjectTypeID] FOREIGN KEY([ProjectTypeID])
REFERENCES [dbo].[ProjectType] ([ProjectTypeID])
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectType_ProjectTypeID]
GO

--rollback tran