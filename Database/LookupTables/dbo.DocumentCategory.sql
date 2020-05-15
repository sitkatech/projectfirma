delete from dbo.DocumentCategory

insert into dbo.DocumentCategory(DocumentCategoryID, DocumentCategoryName, DocumentCategoryDisplayName, SortOrder) values 
(1, 'ManualsAndGuidance', 'Manuals and Guidance', 10),
(2, 'MeetingAgendas', 'Meeting Agendas', 20),
(3, 'MeetingNotes', 'Meeting Notes', 30),
(4, 'Monitoring', 'Monitoring', 40),
(5, 'PoliciesAndPlans', 'Policies and Plans', 50),
(6, 'Presentations', 'Presentations', 60),
(7, 'ProgramInformation', 'Program Information', 70),
(8, 'ProgramManagement', 'Program Management', 80),
(9, 'ProgressReport', 'Progress Report', 90),
(10, 'RequestForProposals', 'Request for Proposals', 100),
(11, 'Other', 'Other', 110)