


-- HACK to get things bootstrapped and tested. This will be expanded or replaced.
-- temp create accounts for all users
insert into dbo.PersonLoginAccount
(
PersonID,
PersonLoginAccountName,
CreateDate,
PasswordHash,
PasswordSalt,
LoginActive,
LoginCount,
FailedLoginCount
)
select 
    p.PersonID, 
    p.Email,
    GETDATE(),
    'UrFd2oinFLZ84RTumt7wHOF+F5G0jnLzDMjHY+M0FL0=',
    '10000:nG0bXssoKynZKz6hKh+jeMEgLTgpggSAOIorUYlv6vg=',
    1,
    0,
    0
from dbo.Person as p




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
