Alter Table dbo.TenantAttribute
Add EnableAccomplishmentsDashboard bit null
go

Update dbo.TenantAttribute
set EnableAccomplishmentsDashboard = 1

Alter Table dbo.TenantAttribute
Alter Column EnableAccomplishmentsDashboard bit not null