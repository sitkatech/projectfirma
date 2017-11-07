DECLARE @unknownOrgID Table (OrgID int);
Insert Into @unknownOrgID Values (2),(7),(58)

INSERT INTO dbo.ProjectFundingSourceRequestUpdate (TenantID, ProjectUpdateBatchID, FundingSourceID, UnsecuredAmount, SecuredAmount)
SELECT p.TenantID as TenantID, p.ProjectUpdateBatchID as ProjectID, f.FundingSourceID as FundingSourceID, 0 as UnsecuredAmount, p.SecuredFunding as SecuredAmount
FROM dbo.ProjectUpdate p
join Organization o on p.TenantID = o.TenantID
join FundingSource f on o.OrganizationID = f.OrganizationID
WHERE p.SecuredFunding > 0
  AND o.OrganizationID in (select OrgID from @unknownOrgID)

if exists(
select ProjectUpdateBatchID, SecuredFunding from ProjectUpdate where SecuredFunding > 0
except 
select ProjectUpdateBatchID, SecuredAmount from ProjectFundingSourceRequestUpdate
union
select ProjectUpdateBatchID, SecuredAmount from ProjectFundingSourceRequestUpdate
except
select ProjectUpdateBatchID, SecuredFunding from ProjectUpdate where SecuredFunding > 0
)
begin
	raiserror('SecuredFunding did not migrate correctly', 16, 1)
end

ALTER TABLE dbo.ProjectUpdate DROP COLUMN SecuredFunding