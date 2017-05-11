update pmsco
set pmsco.SortOrder = NewSortOrder
from dbo.PerformanceMeasureSubcategoryOption pmsco
join 
(
	select PerformanceMeasureSubcategoryOptionID, rank() over (partition by PerformanceMeasureSubcategoryID order by PerformanceMeasureSubcategoryOptionName) * 10 as NewSortOrder
	from dbo.PerformanceMeasureSubcategoryOption pmsco
) a on pmsco.PerformanceMeasureSubcategoryOptionID = a.PerformanceMeasureSubcategoryOptionID
