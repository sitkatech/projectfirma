update dbo.Project
set CompletionYear = 2017
where ProjectID = 3182

ALTER TABLE dbo.Project  DROP  CONSTRAINT CK_Project_CompletionYearHasToBeSetWhenStageIsInCompletedOrPostImplementation
GO

ALTER TABLE dbo.Project  ADD  CONSTRAINT CK_Project_CompletionYearHasToBeSetWhenStageIsInCompletedOrPostImplementation CHECK  ((ProjectStageID in (4, 8) and CompletionYear is not null) or ProjectStageID not in (4, 8))
GO



