--begin tran

alter table dbo.ContactRelationshipType
add IsContactRelationshipRequiredMinimumProjectStageID int null
GO

ALTER TABLE [dbo].[ContactRelationshipType]
WITH CHECK ADD  CONSTRAINT [FK_ContactRelationshipRequiredMinimumProjectStageID_ProjectStage_ProjectStageID] FOREIGN KEY(IsContactRelationshipRequiredMinimumProjectStageID)
REFERENCES [dbo].ProjectStage (ProjectStageID)
GO

update  dbo.ContactRelationshipType
set IsContactRelationshipRequiredMinimumProjectStageID = 3 -- Implementation
where ContactRelationshipTypeID in (5,6,7) and TenantID = 12 -- Tech lead, Project manager, contract manager for Reclamation. Just being emphatic here for clarity.

--rollback tran

--select * from ContactRelationshipType

--select * from dbo.Tenant

--select * from dbo.ProjectStage

