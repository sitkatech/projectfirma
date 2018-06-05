alter table dbo.TenantAttribute add AccomplishmentsDashboardIncludeReportingOrganizationType bit null
go

update ta
set
	AccomplishmentsDashboardIncludeReportingOrganizationType = case
		when t.TenantName = 'RCDProjectTracker'
			then 0
			else 1
		end
from dbo.TenantAttribute ta
	join dbo.Tenant t on t.TenantID = ta.TenantID

go
alter table dbo.TenantAttribute alter column AccomplishmentsDashboardIncludeReportingOrganizationType bit not null
