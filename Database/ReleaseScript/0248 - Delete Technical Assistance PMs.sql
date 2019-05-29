
-- Value of Technical Assistance Provided
select PerformanceMeasureSubcategoryID into #subcategoriesToDelete
from dbo.PerformanceMeasureSubcategory
where TenantID = 9 and PerformanceMeasureID = 2179
go

delete from dbo.PerformanceMeasureSubcategoryOption 
where PerformanceMeasureSubcategoryID in (select * from #subcategoriesToDelete)

delete from dbo.PerformanceMeasureSubcategory
where TenantID = 9 and PerformanceMeasureID = 2179
go 

delete from dbo.PerformanceMeasure
where TenantID = 9 and PerformanceMeasureID = 2179

drop table #subcategoriesToDelete

select PerformanceMeasureSubcategoryID into #subcategoriesToDelete
from dbo.PerformanceMeasureSubcategory
where TenantID = 9 and PerformanceMeasureID = 2147
go

-- Technical Assistance PM
delete from dbo.ClassificationPerformanceMeasure where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureActualSubcategoryOption where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureActualSubcategoryOptionUpdate where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureActualUpdate where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureActual where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureExpectedSubcategoryOption where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureExpectedSubcategoryOptionUpdate where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureExpectedUpdate where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureExpected where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureImage where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureNote where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasureSubcategoryOption where PerformanceMeasureSubcategoryID in (select * from #subcategoriesToDelete)
go
delete from dbo.PerformanceMeasureSubcategory where PerformanceMeasureID = 2147
go
delete from dbo.TaxonomyLeafPerformanceMeasure where PerformanceMeasureID = 2147
go
delete from dbo.ClassificationPerformanceMeasure where PerformanceMeasureID = 2147
go
delete from dbo.PerformanceMeasure where PerformanceMeasureID = 2147
go

drop table #subcategoriesToDelete
