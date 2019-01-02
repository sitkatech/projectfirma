delete from dbo.ProjectCreateSection

insert into dbo.ProjectCreateSection (ProjectCreateSectionID, ProjectCreateSectionName, ProjectCreateSectionDisplayName, SortOrder, HasCompletionStatus, ProjectWorkflowSectionGroupingID)
values
(2, 'Basics', 'Basics', 20, 1, 1),
(3, 'LocationSimple', 'Location - Simple', 30, 1, 1),
(4, 'Organizations', 'Organizations', 40, 1, 1),
(5, 'LocationDetailed', 'Location - Detailed', 40, 0, 2),
(6, 'ExpectedPerformanceMeasures', 'Expected Performance Measures', 60, 1, 3),
(7, 'ReportedPerformanceMeasures', 'Reported Performance Measures', 70, 1, 3),
(8, 'ExpectedFunding', 'Expected Funding', 80, 0, 4),
(9, 'ReportedExpenditures', 'Reported Expenditures', 90, 1, 4),
(11, 'Classifications', 'Classifications', 110, 1, 5),
(12, 'Assessment', 'Asssessment', 120, 1, 5),
(13, 'Photos', 'Photos', 130, 0, 5),
(14, 'NotesAndDocuments', 'Documents and Notes', 140, 0, 5)