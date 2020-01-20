--begin tran

ALTER TABLE dbo.[ProjectCustomAttributeGroup] 
ADD ProjectTypeID int not null DEFAULT 1
GO

ALTER TABLE [dbo].[ProjectCustomAttributeGroup]  WITH CHECK ADD  CONSTRAINT [FK_ProjectCustomAttributeGroup_ProjectType_ProjectTypeID] FOREIGN KEY([ProjectTypeID])
REFERENCES [dbo].[ProjectType] ([ProjectTypeID])
GO

ALTER TABLE [dbo].[ProjectCustomAttributeGroup] CHECK CONSTRAINT [FK_ProjectCustomAttributeGroup_ProjectType_ProjectTypeID]
GO

--rollback tran