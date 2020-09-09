--begin tran

alter table dbo.Organization
add UseOrganizationBoundaryForMatchmaker bit null
GO 

update dbo.Organization
set UseOrganizationBoundaryForMatchmaker = 1
GO

alter table dbo.Organization
alter column UseOrganizationBoundaryForMatchmaker bit not null
GO

--select * from dbo.Organization
--GO

--rollback tran