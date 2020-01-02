

update dbo.Person
set OrganizationID = 6447, UpdateDate = CURRENT_TIMESTAMP
where PersonID = 5988

select * 
from Person 
where PersonID = 5988
