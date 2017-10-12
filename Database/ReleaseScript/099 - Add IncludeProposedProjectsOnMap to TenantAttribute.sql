ALTER TABLE dbo.TenantAttribute ADD IncludeProposedProjectsOnMap bit null
GO

UPDATE dbo.TenantAttribute
SET IncludeProposedProjectsOnMap = 0

ALTER TABLE dbo.TenantAttribute ALTER COLUMN IncludeProposedProjectsOnMap bit not null