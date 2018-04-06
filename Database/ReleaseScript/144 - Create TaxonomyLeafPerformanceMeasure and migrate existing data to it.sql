CREATE TABLE dbo.TaxonomyLeafPerformanceMeasure(
	TaxonomyLeafPerformanceMeasureID int IDENTITY(1,1) NOT NULL CONSTRAINT PK_TaxonomyLeafPerformanceMeasure_TaxonomyLeafPerformanceMeasureID PRIMARY KEY,
	TenantID int NOT NULL CONSTRAINT FK_TaxonomyLeafPerformanceMeasure_Tenant_TenantID FOREIGN KEY REFERENCES dbo.Tenant (TenantID),
	TaxonomyLeafID int NOT NULL CONSTRAINT FK_TaxonomyLeafPerformanceMeasure_TaxonomyLeaf_TaxonomyLeafID FOREIGN KEY REFERENCES dbo.TaxonomyLeaf (TaxonomyLeafID),
	PerformanceMeasureID int NOT NULL CONSTRAINT FK_TaxonomyLeafPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID FOREIGN KEY REFERENCES dbo.PerformanceMeasure (PerformanceMeasureID),
	IsPrimaryTaxonomyLeaf bit NOT NULL,
	CONSTRAINT AK_TaxonomyLeafPerformanceMeasure_TaxonomyLeafID_PerformanceMeasureID UNIQUE (TaxonomyLeafID, PerformanceMeasureID),
	CONSTRAINT FK_TaxonomyLeafPerformanceMeasure_PerformanceMeasure_PerformanceMeasureID_TenantID FOREIGN KEY(PerformanceMeasureID, TenantID) REFERENCES dbo.PerformanceMeasure (PerformanceMeasureID, TenantID),
	CONSTRAINT FK_TaxonomyLeafPerformanceMeasure_TaxonomyLeaf_TaxonomyLeafID_TenantID FOREIGN KEY(TaxonomyLeafID, TenantID) REFERENCES dbo.TaxonomyLeaf (TaxonomyLeafID, TenantID)
)	
GO

insert into dbo.TaxonomyLeafPerformanceMeasure(TenantID, TaxonomyLeafID, PerformanceMeasureID, IsPrimaryTaxonomyLeaf)
select tbpm.TenantID, tl.TaxonomyLeafID, tbpm.PerformanceMeasureID, tbpm.IsPrimaryTaxonomyBranch as IsPrimaryTaxonomyLeaf
from dbo.TaxonomyBranchPerformanceMeasure tbpm
join dbo.TaxonomyLeaf tl on tbpm.TaxonomyBranchID = tl.TaxonomyBranchID


drop table dbo.TaxonomyBranchPerformanceMeasure