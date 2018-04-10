alter table dbo.Classification
Add ClassificationSortOrder int null
go

alter table dbo.TaxonomyTrunk
Add TaxonomyTrunkSortOrder int null
go

alter table dbo.TaxonomyBranch
Add TaxonomyBranchSortOrder int null
go

alter table dbo.TaxonomyLeaf
Add TaxonomyLeafSortOrder int null
go

alter table dbo.PerformanceMeasure
Add PerformanceMeasureSortOrder int null
go