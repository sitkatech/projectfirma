delete from dbo.ProjectCreateSection

insert into dbo.ProjectCreateSection (ProjectCreateSectionID, ProjectCreateSectionName, ProjectCreateSectionDisplayName, SortOrder, HasCompletionStatus, ProjectWorkflowSectionGroupingID)
values
(2, 'Basics', 'Basics', 20, 1, 1),
(3, 'LocationSimple', 'Simple Location', 30, 1, 1),
(4, 'Organizations', 'Organizations', 40, 1, 1),
(5, 'LocationDetailed', 'Detailed Location', 31, 0, 1),
(6, 'ExpectedAccomplishments', 'Expected Accomplishments', 60, 0, 3),
(7, 'ReportedAccomplishments', 'Reported Accomplishments', 70, 1, 3),
(8, 'Budget', 'Budget', 80, 0, 4),
(9, 'ReportedExpenditures', 'Reported Expenditures', 90, 1, 4),
(11, 'Classifications', 'Classifications', 110, 1, 5),
(12, 'Assessment', 'Asssessment', 120, 1, 5),
(13, 'Photos', 'Photos', 130, 0, 5),
(15, 'Contacts', 'Contacts', 45, 1, 1),
(16, 'AttachmentsAndNotes', 'Attachments and Notes', 140, 0, 5),
(17, 'CustomAttributes', 'Custom Attributes', 25, 1, 1),
(18, 'BulkSetSpatialInformation', 'Bulk Set Spatial Information', 10, 0, 2)