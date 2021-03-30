
-- Remove before real deployment!!!!
update dbo.TenantAttribute
set FirmaSystemAuthenticationTypeID = 2




-- HACK to get things bootstrapped and tested. This will be expanded or replaced.
insert into dbo.PersonLoginAccount
(
PersonID,
TenantID,
PersonLoginAccountName,
CreateDate,
PasswordHash,
PasswordSalt,
LoginActive,
LoginCount,
FailedLoginCount
)
values 
(
7092, -- Clackamas Partnership
2, -- Clackamas Partnership
'stewart@sitkatech.com',
GETDATE(),
'UrFd2oinFLZ84RTumt7wHOF+F5G0jnLzDMjHY+M0FL0=',
'10000:nG0bXssoKynZKz6hKh+jeMEgLTgpggSAOIorUYlv6vg=',
1,
0,
0
)


select * from Keystone.dbo.[User]
where email = 'stewart@sitkatech.com'

/*

select * from  dbo.PersonLoginAccount
select * from  dbo.FirmaSession

select * from dbo.Person
where FirstName = 'Stewart'
and 
LastName = 'Loving-Gibbard'


PersonID
5512
5519
6013
6033
6046
6048
7090
7091
7092

select * from GeminiDB.dbo.SecUser
where LogonName = 'stewart@sitkatech.com'
*/
