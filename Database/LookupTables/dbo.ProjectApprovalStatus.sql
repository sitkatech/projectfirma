
delete from dbo.ProjectApprovalStatus

insert dbo.ProjectApprovalStatus (ProjectApprovalStatusID, ProjectApprovalStatusName, ProjectApprovalStatusDisplayName) 
values 
(1, 'Draft', 'Draft'),
(2, 'PendingApproval', 'Pending Approval'),
(3, 'Approved', 'Approved and Archived'),
(4, 'Rejected', 'Rejected'),
(5, 'Returned', 'Returned')
