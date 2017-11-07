DECLARE @unknownOrgID Table (OrgID int);
Insert Into @unknownOrgID Values (2),(7),(58)

INSERT INTO dbo.FundingSource (TenantID, OrganizationID, FundingSourceName, IsActive, FundingSourceDescription)
Select o.TenantID as TenantID, u.OrgID as OrganizationID, 'Unknown/Unassigned' as FundingSourceName, 1 as IsActive, 'Unknown funding source' as FundingSourceDescription
from @unknownOrgID u
join Organization o on u.OrgID = O.OrganizationID

INSERT INTO dbo.ProjectFundingSourceRequest (TenantID, ProjectID, FundingSourceID, UnsecuredAmount, SecuredAmount)
SELECT p.TenantID as TenantID, p.ProjectID as ProjectID, f.FundingSourceID as FundingSourceID, 0 as UnsecuredAmount, p.SecuredFunding as SecuredAmount
FROM dbo.Project p
join Organization o on p.TenantID = o.TenantID
join FundingSource f on o.OrganizationID = f.OrganizationID
WHERE p.SecuredFunding > 0
  AND o.OrganizationID in (select OrgID from @unknownOrgID)

if exists(
select ProjectID, SecuredFunding from Project where SecuredFunding > 0
except 
select ProjectID, SecuredAmount from ProjectFundingSourceRequest
union
select ProjectID, SecuredAmount from ProjectFundingSourceRequest
except
select ProjectID, SecuredFunding from Project where SecuredFunding > 0
)
begin
	raiserror('SecuredFunding did not migrate correct;y', 16, 1)
end

Alter Table dbo.Project Drop Constraint CK_Project_SecuredFundingForCapitalProjectsOnly
ALTER TABLE dbo.Project DROP COLUMN SecuredFunding