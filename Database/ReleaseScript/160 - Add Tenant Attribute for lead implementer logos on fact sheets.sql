alter table dbo.TenantAttribute
Add ShowLeadImplementerLogoOnFactSheet bit null
go

update dbo.TenantAttribute
set ShowLeadImplementerLogoOnFactSheet = 0

alter table dbo.TenantAttribute
alter column ShowLeadImplementerLogoOnFactSheet bit not null