declare @auditEventID uniqueidentifier
set @auditEventID = newid()
insert into Keystone.dbo.AuditEvent(EventDate, Notes, AuditEventID)
values('7/20/2017 5:15 PM', 'Loading in CA RCD users and organizations', @auditEventID)

update dbo.Organization
set OrganizationUrl = 'http://www.rcdsantabarbara.org/'
where OrganizationName = 'Cachuma Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.crcd.org/'
where OrganizationName = 'Coarsegold Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://honeylakevalleyrcd.us/'
where OrganizationName = 'Honey Lake Valley Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.humboldtrcd.org/'
where OrganizationName = 'Humboldt County Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.yolorcd.org/'
where OrganizationName = 'Yolo County Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://acrcd.org/'
where OrganizationName = 'Alameda County Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.ccrcd.org/'
where OrganizationName = 'Contra Costa Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'https://www.iercd.org/'
where OrganizationName = 'Inland Empire Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.marinrcd.org/'
where OrganizationName = 'Marin Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.sanmateorcd.org/'
where OrganizationName = 'San Mateo County Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.rcdsmm.org/'
where OrganizationName = 'Santa Monica Mountains Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.tcrcd.net/'
where OrganizationName = 'Trinity County Resource Conservation District'
update dbo.Organization
set OrganizationUrl = 'http://www.us-ltrcd.org/'
where OrganizationName = 'Upper Salinas - Las Tablas Resource Conservation District'

insert into Keystone.dbo.Organization(FullName, ShortName, OrganizationGuid, IsActive, AuditEventIDCreate, AuditEventIDUpdate, RealmID, [URL])
select o.OrganizationName, o.OrganizationAbbreviation, newid() as OrganizationGuid, 1 as IsActive, @auditEventID, @auditEventID, 2 as RealmID, o.OrganizationUrl
from dbo.Organization o
left join Keystone.dbo.Organization ko on o.OrganizationName = ko.FullName
where TenantID = 3 and o.OrganizationAbbreviation like '%RCD%' and ko.OrganizationID is null

insert into Keystone.dbo.Domain([Name], OrganizationID)
select 'ccrcd.org', ko.OrganizationID
from Keystone.dbo.Organization ko
where ko.FullName = 'Contra Costa Resource Conservation District'

insert into Keystone.dbo.Domain([Name], OrganizationID)
select 'tcrcd.net', ko.OrganizationID
from Keystone.dbo.Organization ko
where ko.FullName = 'Trinity County Resource Conservation District'

insert into Keystone.dbo.Domain([Name], OrganizationID)
select 'rcdsantabarbara.org', ko.OrganizationID
from Keystone.dbo.Organization ko
where ko.FullName = 'Cachuma Resource Conservation District'

insert into Keystone.dbo.Domain([Name], OrganizationID)
select 'marinrcd.org', ko.OrganizationID
from Keystone.dbo.Organization ko
where ko.FullName = 'Marin Resource Conservation District'

update o
set o.OrganizationGuid = ko.OrganizationGuid
from dbo.Organization o
join Keystone.dbo.Organization ko on ko.FullName = o.OrganizationName


update ku
set ku.OrganizationID = o.OrganizationID, ku.UserSpecifiedOrganizationName = null, ku.OrganizationIsReviewed = 1
from Keystone.dbo.[User] ku
join Keystone.dbo.Organization o on ku.UserSpecifiedOrganizationName = o.FullName or ku.UserSpecifiedOrganizationName = o.ShortName
where o.AuditEventIDCreate = @auditEventID

update p
set p.OrganizationID = o.OrganizationID
from dbo.Person p
join Keystone.dbo.[User] ku on p.PersonGuid = ku.UserGuid
join Keystone.dbo.Organization ko on ku.OrganizationID = ko.OrganizationID
join dbo.Organization o on ko.OrganizationGuid = o.OrganizationGuid
where p.OrganizationID = 58

