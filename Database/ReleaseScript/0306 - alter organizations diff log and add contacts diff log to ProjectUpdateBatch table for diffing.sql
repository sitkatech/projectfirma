-- alter the orgranizations diff log to be the html type
ALTER TABLE dbo.ProjectUpdateBatch
ALTER COLUMN [OrganizationsDiffLog] [dbo].[html] NULL
GO

-- add a column for the contacts diff log
ALTER TABLE dbo.ProjectUpdateBatch
ADD [ContactsDiffLog] [dbo].[html] NULL
GO