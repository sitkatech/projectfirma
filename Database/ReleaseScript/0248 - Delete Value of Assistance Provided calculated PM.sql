
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
