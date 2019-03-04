Alter Table dbo.ProjectCustomAttributeType 
	Add 
		EditableByRoleID int null Constraint FK_ProjectCustomAttribute_RoleID_EditableByRoleID_RoleID Foreign Key (EditableByRoleID) References dbo.Role (RoleID),
		ViewableByRoleID int null Constraint FK_ProjectCustomAttribute_RoleID_ViewableByRoleID_RoleID Foreign Key (ViewableByRoleID) References dbo.Role (RoleID),
		IncludeInNtaGrid bit null 