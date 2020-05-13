delete from dbo.DocumentCategory

insert into dbo.DocumentCategory(DocumentCategoryID, DocumentCategoryName, DocumentCategoryDisplayName, SortOrder) values 
(1, 'MeetingNotes', 'Meeting Notes', 10),
(2, 'MeetingAgendas', 'Meeting Agendas', 20),
(3, 'RequestForProposals', 'Request for Proposals', 30),
(4, 'ManualsAndGuidance', 'Manuals and Guidance', 40),
(5, 'Presentations', 'Presentations', 50),
(6, 'ProgramInformation', 'Program Information', 60),
(7, 'ProgramManagement', 'Program Management', 70),
(8, 'ProgressReport', 'Progress Report', 80),
(9, 'PoliciesAndPlans', 'Policies and Plans', 90),
(10, 'Monitoring', 'Monitoring', 100),
(11, 'Other', 'Other', 110)