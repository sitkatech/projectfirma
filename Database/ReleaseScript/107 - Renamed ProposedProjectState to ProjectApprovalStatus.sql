exec sp_rename 'dbo.FK_Project_ProposedProjectState_ProposedProjectStateID', 'FK_Project_ProjectApprovalStatus_ProjectApprovalStatusID', 'OBJECT';
exec sp_rename 'dbo.PK_ProposedProjectState_ProposedProjectStateID', 'PK_ProjectApprovalStatus_ProjectApprovalStatusID', 'OBJECT';
exec sp_rename 'dbo.AK_ProposedProjectState_ProposedProjectStateName', 'AK_ProjectApprovalStatus_ProjectApprovalStatusName', 'OBJECT';
exec sp_rename 'dbo.AK_ProposedProjectState_ProposedProjectStateDisplayName', 'AK_ProjectApprovalStatus_ProjectApprovalStatusDisplayName', 'OBJECT';
exec sp_rename 'dbo.ProposedProjectState.ProposedProjectStateDisplayName', 'ProjectApprovalStatusDisplayName', 'COLUMN';
exec sp_rename 'dbo.ProposedProjectState.ProposedProjectStateID', 'ProjectApprovalStatusID', 'COLUMN';
exec sp_rename 'dbo.ProposedProjectState.ProposedProjectStateName', 'ProjectApprovalStatusName', 'COLUMN';
exec sp_rename 'dbo.Project.ProposedProjectStateID', 'ProjectApprovalStatusID', 'COLUMN';
exec sp_rename 'dbo.ProposedProjectState', 'ProjectApprovalStatus';