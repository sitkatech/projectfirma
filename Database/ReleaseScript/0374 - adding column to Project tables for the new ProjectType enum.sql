--begin tran

ALTER TABLE dbo.Project 
ADD ProjectCategoryID int not null DEFAULT 1
GO

ALTER TABLE [dbo].[Project]  WITH CHECK ADD  CONSTRAINT [FK_Project_ProjectCategory_ProjectCategoryID] FOREIGN KEY([ProjectCategoryID])
REFERENCES [dbo].[ProjectCategory] ([ProjectCategoryID])
GO

ALTER TABLE [dbo].[Project] CHECK CONSTRAINT [FK_Project_ProjectCategory_ProjectCategoryID]
GO

--rollback tran