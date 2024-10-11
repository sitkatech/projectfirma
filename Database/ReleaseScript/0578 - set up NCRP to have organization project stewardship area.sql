update dbo.TenantAttribute set ProjectStewardshipAreaTypeID = 1 where TenantID = 4

insert into dbo.[OrganizationRelationshipType](TenantID, OrganizationRelationshipTypeName, CanStewardProjects, IsPrimaryContact, IsOrganizationRelationshipTypeRequired, OrganizationRelationshipTypeDescription, ReportInAccomplishmentsDashboard, ShowOnFactSheet)
values
(4, 'Project Stewarding Organization', 1, 0, 1, 'Project Stewarding Organization', 0, 1)

declare @newID int
set @newID = SCOPE_IDENTITY()

insert into dbo.[OrganizationTypeOrganizationRelationshipType] (TenantID, OrganizationTypeID, OrganizationRelationshipTypeID)
values
(4, 1, @newID),
(4, 2, @newID),
(4, 3, @newID),
(4, 4, @newID),
(4, 5, @newID),
(4, 1093, @newID),
(4, 1094, @newID),
(4, 1095, @newID),
(4, 1096, @newID),
(4, 1097, @newID),
(4, 1099, @newID),
(4, 1100, @newID),
(4, 1101, @newID),
(4, 1102, @newID),
(4, 1104, @newID),
(4, 1105, @newID),
(4, 1106, @newID),
(4, 1116, @newID)