DECLARE @TenantID int
SET @TenantID = 11

UPDATE dbo.TaxonomyBranch
SET TaxonomyBranchName = REPLACE (TaxonomyBranchName, 'Test Branch - ','')
WHERE TenantID <> @TenantID

UPDATE dbo.TaxonomyLeaf
SET TaxonomyLeafName = REPLACE (TaxonomyLeafName, 'Test Leaf - ','')
WHERE TenantID <> @TenantID
