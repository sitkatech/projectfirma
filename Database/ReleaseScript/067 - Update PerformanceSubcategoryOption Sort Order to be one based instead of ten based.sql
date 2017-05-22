update pmsco
set pmsco.SortOrder = a.NewSortOrder
from dbo.PerformanceMeasureSubcategoryOption pmsco
join
(
	select PerformanceMeasureSubcategoryOptionID, PerformanceMeasureSubcategoryID, SortOrder, row_number() over(partition by PerformanceMeasureSubcategoryID order by SortOrder) as NewSortOrder
	from dbo.PerformanceMeasureSubcategoryOption
) a on pmsco.PerformanceMeasureSubcategoryOptionID = a.PerformanceMeasureSubcategoryOptionID