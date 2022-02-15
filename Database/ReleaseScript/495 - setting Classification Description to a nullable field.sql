

alter table dbo.[Classification]
alter column ClassificationDescription varchar(300) null



update dbo.[Classification]
set ClassificationDescription = null
where TenantID = 4 and ClassificationDescription like 'None'



