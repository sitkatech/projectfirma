Alter Table dbo.Project Add Constraint CK_Project_ProjectCannotHaveProjectStageProposalAndApprovalStatusApproved
CHECK (ProjectStageID != 1 OR ProjectApprovalStatusID != 3)