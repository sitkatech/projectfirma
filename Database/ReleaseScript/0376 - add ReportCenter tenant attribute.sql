--begin tran

ALTER TABLE dbo.TenantAttribute
ADD EnableReportCenter bit null

go

UPDATE dbo.TenantAttribute
    set EnableReportCenter = 0 
    where EnableReportCenter is null

go 

ALTER TABLE dbo.TenantAttribute
ALTER COLUMN EnableReportCenter bit not null

go
--rollback tran