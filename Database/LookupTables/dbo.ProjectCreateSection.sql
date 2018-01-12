delete from dbo.ProjectCreateSection

insert into dbo.ProjectCreateSection (ProjectCreateSectionID, ProjectCreateSectionName, ProjectCreateSectionDisplayName, SortOrder, HasCompletionStatus)
values
(1, 'Instructions', 'Instructions', 10, 0),
(2, 'ProjectType', 'Project Type', 20, 1),
(3, 'Basics', 'Basics', 30, 1),
(4, 'LocationSimple', 'Location - Simple', 40, 1),
(5, 'LocationDetailed', 'Location - Detailed', 50, 1),
(6, 'PerformanceMeasures', 'Performance Measures', 60, 1),
(7, 'ThresholdCategories', 'Threshold Categories', 70, 1),
(8, 'TransportationAssessment', 'Transportation Assessment', 80, 1),
(9, 'Photos', 'Photos', 90, 0),
(10, 'Notes', 'Notes', 100, 0),
(11, 'ExpectedFunding', 'Expected Funding', 55, 0)