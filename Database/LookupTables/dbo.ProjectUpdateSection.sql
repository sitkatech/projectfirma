delete from dbo.ProjectUpdateSection

insert into dbo.ProjectUpdateSection (ProjectUpdateSectionID, ProjectUpdateSectionName, ProjectUpdateSectionDisplayName, SortOrder, HasCompletionStatus)
values
(1, 'Instructions', 'Instructions', 10, 0),
(2, 'Basics', 'Basics', 20, 1),
(3, 'LocationSimple', 'Location - Simple', 30, 1),
(4, 'LocationDetailed', 'Location - Detailed', 40, 0),
(5, 'GeospatialAreas', 'GeospatialArea', 50, 1),
(6, 'PerformanceMeasures', 'Performance Measures', 60, 1),
(7, 'ExpectedFunding', 'Expected Funding', 70, 0),
(8, 'Expenditures', 'Expenditures', 80, 1),
(9, 'Photos', 'Photos', 100, 0),
(10, 'ExternalLinks', 'External Links', 125, 0),
(11, 'NotesAndDocuments', 'Documents and Notes', 120, 0),
(12, 'Organizations', 'Organizations', 55, 1)
