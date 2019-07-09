delete from dbo.ProjectWorkflowSectionGrouping

insert into dbo.ProjectWorkflowSectionGrouping (ProjectWorkflowSectionGroupingID, ProjectWorkflowSectionGroupingName, ProjectWorkflowSectionGroupingDisplayName, SortOrder)
values
(1, 'Overview', 'Overview', 10),
(2, 'SpatialInformation', 'Spatial Information', 20),
(3, 'Accomplishments', 'Accomplishments', 30),
(4, 'Financials', 'Financials', 40),
(5, 'AdditionalData', 'Additional Data', 50)