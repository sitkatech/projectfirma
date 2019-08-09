
insert into ProjectNoFundingSourceIdentified
select TenantID,
ProjectID,
2019 CalendarYear,
NoFundingSourceIdentifiedYet
from Project
where TenantID = 11 and FundingTypeID = 1 and NoFundingSourceIdentifiedYet is not null

update Project
set NoFundingSourceIdentifiedYet = null where TenantID = 11 and FundingTypeID = 1 and NoFundingSourceIdentifiedYet is not null


