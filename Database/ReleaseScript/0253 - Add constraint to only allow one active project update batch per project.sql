
-- Only allow one active update per tenant/project
create unique index OnlyOneActiveUpdatePerProject on dbo.ProjectUpdateBatch(TenantID, ProjectID) where ProjectUpdateStateID < 4
go