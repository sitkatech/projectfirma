
--ALTER TABLE dbo.TenantAttribute ADD RequireLessonsLearnedForCompletedProjects bit 

--go

--update dbo.TenantAttribute 
--set RequireLessonsLearnedForCompletedProjects = 1
--go


--ALTER TABLE dbo.TenantAttribute ALTER COLUMN RequireLessonsLearnedForCompletedProjects bit NOT NULL