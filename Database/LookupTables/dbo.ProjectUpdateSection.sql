--The sort order for these is for the entire table, NOT the sort order within the grouping
delete from dbo.ProjectUpdateSection

insert into dbo.ProjectUpdateSection (ProjectUpdateSectionID, ProjectUpdateSectionName, ProjectUpdateSectionDisplayName, SortOrder, HasCompletionStatus, ProjectWorkflowSectionGroupingID)
values
(2, 'Basics', 'Basics', 20, 1, 1),
(3, 'LocationSimple', 'Simple Location', 30, 1, 1),
(4, 'Organizations', 'Organizations', 40, 1, 1),
(5, 'LocationDetailed', 'Detailed Location', 31, 0, 1),
(6, 'ReportedAccomplishments', 'Reported Accomplishments', 80, 1, 3),
(7, 'Budget', 'Budget', 90, 0, 4),
(8, 'Expenditures', 'Expenditures', 100, 1, 4),
(9, 'Photos', 'Photos', 120, 0, 5),
(10, 'ExternalLinks', 'External Links', 135, 0, 5),
(12, 'ExpectedAccomplishments', 'Expected Accomplishments', 70, 1, 3),
(13, 'TechnicalAssistanceRequests', 'Technical Assistance Requests', 110, 0, 5),
(14, 'Contacts', 'Contacts', 50, 1, 1),
(15, 'AttachmentsAndNotes', 'Attachments and Notes', 130, 0, 5),
(16, 'CustomAttributes', 'Custom Attributes', 25, 1, 1),
(17, 'BulkSetSpatialInformation', 'Bulk Set Spatial Information',60, 0, 2)