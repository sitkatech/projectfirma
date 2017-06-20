delete from dbo.Tenant
go

insert into dbo.Tenant(TenantID, TenantName, TenantDomain) 
values 
(1, 'SitkaTechnologyGroup', 'projectfirma.com'),
(2, 'ClackamasPartnership', 'clackamaspartnership.org'),
(3, 'CaliforniaAssocationOfResourceConversationDistricts', 'rcdprojects.org')
