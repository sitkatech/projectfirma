ALTER TABLE dbo.ProposedProject DROP CONSTRAINT AK_ProposedProject_ProjectID
GO


CREATE UNIQUE NONCLUSTERED INDEX AK_ProposedProject_ProjectID ON dbo.ProposedProject (ProjectID) WHERE (ProjectID IS NOT NULL)