delete from dbo.ProjectCreateSection

insert into dbo.ProjectCreateSection (ProjectCreateSectionID, ProjectCreateSectionName, ProjectCreateSectionDisplayName, SortOrder, HasCompletionStatus)
values
(1, 'Instructions', 'Instructions', 10, 0),
(2, 'Basics', 'Basics', 20, 1),
(3, 'LocationSimple', 'Location - Simple', 30, 1),
(4, 'LocationDetailed', 'Location - Detailed', 40, 0),
(5, 'Watershed', 'Watersheds', 50, 1),
(6, 'ExpectedPerformanceMeasures', 'Expected Performance Measures', 60, 1),
(7, 'ReportedPerformanceMeasures', 'Reported Performance Measures', 70, 1),
(8, 'ExpectedFunding', 'Expected Funding', 80, 0),
(9, 'ReportedExpenditures', 'Reported Expenditures', 90, 1),
(11, 'Classifications', 'Project Themes', 110, 1),
(12, 'Assessment', 'Asssessment', 120, 1),
(13, 'Photos', 'Photos', 130, 0),
(14, 'Notes', 'Notes', 140, 0),
(15, 'Organizations', 'Organizations', 25, 1)