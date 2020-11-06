----99999 - Add ContactRelationshipRequiredMinimumProjectStageID

--begin tran

alter table dbo.ContactRelationshipType
add IsContactRelationshipRequiredMinimumProjectStageID int null
GO

ALTER TABLE [dbo].[ContactRelationshipType]  
WITH CHECK ADD  CONSTRAINT [FK_ContactRelationshipRequiredMinimumProjectStageID_ProjectStage_ProjectStageID] FOREIGN KEY(IsContactRelationshipRequiredMinimumProjectStageID)
REFERENCES [dbo].ProjectStage (ProjectStageID)
GO

update dbo.ContactRelationshipType
set IsContactRelationshipRequiredMinimumProjectStageID = 1 -- Proposal
GO

update  dbo.ContactRelationshipType
set IsContactRelationshipRequiredMinimumProjectStageID = 3 -- Implementation
where ContactRelationshipTypeID in (5,6,7) -- Tech lead, Project manager, contract manager





--rollback tran

--select * from ContactRelationshipType

--select * from dbo.Project

--select * from dbo.ProjectStage

