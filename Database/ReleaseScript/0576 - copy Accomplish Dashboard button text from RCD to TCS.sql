
update dbo.TenantAttribute set AccomplishmentsDashboardAccomplishmentsButtonText = (select AccomplishmentsDashboardAccomplishmentsButtonText from dbo.TenantAttribute where TenantID = 3) where TenantID = 14
update dbo.TenantAttribute set AccomplishmentsDashboardExpendituresButtonText = (select AccomplishmentsDashboardExpendituresButtonText from dbo.TenantAttribute where TenantID = 3) where TenantID = 14
update dbo.TenantAttribute set AccomplishmentsDashboardOrganizationsButtonText = (select AccomplishmentsDashboardOrganizationsButtonText from dbo.TenantAttribute where TenantID = 3) where TenantID = 14

