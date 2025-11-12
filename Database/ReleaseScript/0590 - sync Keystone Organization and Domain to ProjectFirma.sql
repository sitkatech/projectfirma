--Import Organization information from Keystone into ProjectFirma:
UPDATE pf
SET 
	pf.OrganizationName = ko.FullName,
	pf.OrganizationShortName = ko.ShortName,
	pf.OrganizationUrl = ko.URL,
	pf.IsActive = ko.IsActive
FROM ProjectFirma.dbo.Organization pf
INNER JOIN Keystone.dbo.Organization ko
    ON pf.KeystoneOrganizationGuid = ko.OrganizationGuid;
go

--Import Organization Domain information from Keystone into ProjectFirma:
select kf.OrganizationGuid, kd.Name
into #t1
from KeyStone.dbo.Organization kf
	join KeyStone.dbo.Domain kd
		on kf.OrganizationID = kd.OrganizationID
go

update pf 
SET 
	pf.Domain = #t1.Name
from #t1 
INNER JOIN ProjectFirma.dbo.Organization pf 
	on pf.KeystoneOrganizationGuid = #t1.OrganizationGuid
go
	
drop table #t1
go


