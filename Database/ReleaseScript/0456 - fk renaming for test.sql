--begin tran

exec sp_rename 'dbo.FK_ContactRelationshipRequiredMinimumProjectStageID_ProjectStage_ProjectStageID', 'FK_ContactRelationshipType_ProjectStage_IsContactRelationshipRequiredMinimumProjectStageID_ProjectStageID', 'OBJECT'

--rollback tran