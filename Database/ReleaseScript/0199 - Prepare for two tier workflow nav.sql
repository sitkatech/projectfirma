CREATE TABLE dbo.ProjectWorkflowSectionGrouping(
	ProjectWorkflowSectionGroupingID int NOT NULL,
	ProjectWorkflowSectionGroupingName varchar(50) NOT NULL,
	ProjectWorkflowSectionGroupingDisplayName varchar(50) NOT NULL,
	SortOrder int NOT NULL,
 CONSTRAINT PK_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingID PRIMARY KEY CLUSTERED 
(
	ProjectWorkflowSectionGroupingID ASC
),
 CONSTRAINT AK_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingDisplayName UNIQUE NONCLUSTERED 
(
	ProjectWorkflowSectionGroupingDisplayName ASC
),
 CONSTRAINT AK_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingName UNIQUE NONCLUSTERED 
(
	ProjectWorkflowSectionGroupingName ASC
)
)
GO

delete from dbo.ProjectWorkflowSectionGrouping

insert into dbo.ProjectWorkflowSectionGrouping (ProjectWorkflowSectionGroupingID, ProjectWorkflowSectionGroupingName, ProjectWorkflowSectionGroupingDisplayName, SortOrder)
values
(1, 'Overview', 'Overview', 10),
(2, 'Location', 'Location', 20),
(3, 'PerformanceMeasures', 'Performance Measures', 30),
(4, 'Expenditures', 'Expenditures', 40),
(5, 'AdditionalData', 'Additional Data', 50)

Alter Table dbo.ProjectUpdateSection
add ProjectWorkflowSectionGroupingID int null
go

Alter Table dbo.ProjectUpdateSection
Add constraint FK_ProjectUpdateSection_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingID
Foreign Key (ProjectWorkflowSectionGroupingID) references dbo.ProjectWorkflowSectionGrouping(ProjectWorkflowSectionGroupingID)

Update dbo.ProjectUpdateSection
set ProjectWorkflowSectionGroupingID = 1

Alter Table dbo.ProjectUpdateSection
alter column ProjectWorkflowSectionGroupingID int not null
go


Alter Table dbo.ProjectCreateSection
add ProjectWorkflowSectionGroupingID int null
go

Alter Table dbo.ProjectCreateSection
Add constraint FK_ProjectCreateSection_ProjectWorkflowSectionGrouping_ProjectWorkflowSectionGroupingID
Foreign Key (ProjectWorkflowSectionGroupingID) references dbo.ProjectWorkflowSectionGrouping(ProjectWorkflowSectionGroupingID)

Update dbo.ProjectCreateSection
set ProjectWorkflowSectionGroupingID = 1

Alter Table dbo.ProjectCreateSection
alter column ProjectWorkflowSectionGroupingID int not null
go