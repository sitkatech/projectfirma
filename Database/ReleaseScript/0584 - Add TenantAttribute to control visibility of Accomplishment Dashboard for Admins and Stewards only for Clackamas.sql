
alter table dbo.TenantAttribute add AccomplishmentsDashboardVisibilityAdminOnly bit null
go
update dbo.TenantAttribute set AccomplishmentsDashboardVisibilityAdminOnly = 0 where TenantID != 2
update dbo.TenantAttribute set AccomplishmentsDashboardVisibilityAdminOnly = 1 where TenantID = 2

alter table dbo.TenantAttribute alter column AccomplishmentsDashboardVisibilityAdminOnly bit not null