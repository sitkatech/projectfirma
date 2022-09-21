update dbo.Project set ProjectLocationPoint = geometry::Point(-123.89692, 41.77911, 4326), ProjectLocationSimpleTypeID = 2 where TenantID = 4 and ProjectID = 14346
update dbo.Project set ProjectLocationPoint = geometry::Point(-123.14047, 41.14252, 4326), ProjectLocationSimpleTypeID = 2 where TenantID = 4 and ProjectID = 16627

-- set proposing person to Katherine for all pending approval projects that don't have one set
update dbo.Project set ProposingPersonID = 8205 where TenantID = 4 and ProjectApprovalStatusID = 2 and ProposingPersonID is null