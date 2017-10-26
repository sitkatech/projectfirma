
delete from dbo.ProposedProjectState

insert dbo.ProposedProjectState (ProposedProjectStateID, ProposedProjectStateName, ProposedProjectStateDisplayName) values (1, 'Draft', 'Draft')
insert dbo.ProposedProjectState (ProposedProjectStateID, ProposedProjectStateName, ProposedProjectStateDisplayName) values (2, 'PendingApproval', 'Pending Approval')
insert dbo.ProposedProjectState (ProposedProjectStateID, ProposedProjectStateName, ProposedProjectStateDisplayName) values (3, 'Approved', 'Approved and Archived')
insert dbo.ProposedProjectState (ProposedProjectStateID, ProposedProjectStateName, ProposedProjectStateDisplayName) values (4, 'Rejected', 'Rejected')
