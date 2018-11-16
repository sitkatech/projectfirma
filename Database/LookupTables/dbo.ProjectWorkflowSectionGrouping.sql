delete from dbo.ProjectWorkflowSectionGrouping

insert into dbo.ProjectWorkflowSectionGrouping (ProjectWorkflowSectionGroupingID, ProjectWorkflowSectionGroupingName, ProjectWorkflowSectionGroupingDisplayName, SortOrder)
values
(1, 'Overview', 'Overview', 10),
(2, 'Location', 'Location', 20),
(3, 'PerformanceMeasures', 'Performance Measures', 30),
(4, 'Expenditures', 'Expenditures', 40),
(5, 'AdditionalData', 'Additional Data', 50)