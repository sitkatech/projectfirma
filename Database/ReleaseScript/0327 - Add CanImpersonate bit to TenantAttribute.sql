--begin tran

alter table dbo.TenantAttribute
add ImpersonationEnabled bit null
GO

update dbo.TenantAttribute
set ImpersonationEnabled = 0
GO

alter table dbo.TenantAttribute
alter column ImpersonationEnabled bit not null
GO

-- Enabled only for BOR to start.
-- If you want to play too, add your tenant in.
update dbo.TenantAttribute
set ImpersonationEnabled = 1
where TenantID = 12

--rollback tran


--select * from dbo.Tenant