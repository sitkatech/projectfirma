delete from dbo.ProjectCreateSection

insert into dbo.ProjectCreateSection (ProjectCreateSectionID, ProjectCreateSectionName, ProjectCreateSectionDisplayName, SortOrder, HasCompletionStatus)
values
(1, 'Instructions', 'Instructions', 10, 0),
(2, 'Basics', 'Basics', 20, 1),
(3, 'LocationSimple', 'Location - Simple', 30, 1),
(4, 'LocationDetailed', 'Location - Detailed', 40, 0),
(5, 'Watershed', 'Watersheds', 50, 1),
(6, 'PerformanceMeasures', 'Performance Measures', 60, 1),
(7, 'ExpectedFunding', 'Expected Funding', 70, 0),
(8, 'Classifications', 'Project Themes', 80, 1),
(9, 'Assessment', 'Asssessment', 90, 1),
(10, 'Photos', 'Photos', 100, 0),
(11, 'Notes', 'Notes', 110, 0)