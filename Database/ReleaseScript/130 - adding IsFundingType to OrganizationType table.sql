alter table dbo.OrganizationType add IsFundingType bit null
GO

update dbo.OrganizationType
set IsFundingType = 1

update dbo.OrganizationType
set IsFundingType = 0
where TenantID = 3 and OrganizationTypeName in ('State Assembly District', 'State Senate District')

alter table dbo.OrganizationType alter column IsFundingType bit not null
GO


