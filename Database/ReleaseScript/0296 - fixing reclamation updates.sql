

select * from dbo.Project
where TenantID = 12


update dbo.ProjectUpdate
set FundingTypeID = 1
where TenantID = 12 and FundingTypeID is null


update dbo.Project
set FundingTypeID = 1
where TenantID = 12 and FundingTypeID is null
