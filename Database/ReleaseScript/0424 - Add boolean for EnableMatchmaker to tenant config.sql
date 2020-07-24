
alter table dbo.TenantAttribute
add EnableMatchmaker bit null
go

update dbo.TenantAttribute
set EnableMatchmaker = 0
go

alter table dbo.TenantAttribute
alter column EnableMatchmaker bit not null
go
