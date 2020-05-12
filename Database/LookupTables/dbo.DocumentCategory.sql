delete from dbo.DocumentCategory

insert into dbo.DocumentCategory(DocumentCategoryID, DocumentCategoryName, DocumentCategoryDisplayName, SortOrder) values 
(1, 'ManualsAndGuidance', 'Manuals and Guidance', 10),
(2, 'Presentations', 'Presentations', 20),
(3, 'ProgramInformation', 'Program Information', 30),
(4, 'ProgramManagement', 'Program Management', 40),
(5, 'ProgressReport', 'Progress Report', 50),
(6, 'PoliciesAndPlans', 'Policies and Plans', 60),
(7, 'ResearchAndMonitoring', 'Research and Monitoring', 70),
(8, 'Other', 'Other', 80)