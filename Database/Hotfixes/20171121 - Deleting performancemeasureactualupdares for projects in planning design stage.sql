delete pauso
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
join dbo.PerformanceMeasureActualUpdate pau on pub.ProjectUpdateBatchID = pau.ProjectUpdateBatchID
join dbo.PerformanceMeasureActualSubcategoryOptionUpdate pauso on pau.PerformanceMeasureActualUpdateID = pauso.PerformanceMeasureActualUpdateID
where pu.ProjectStageID = 2 and p.ProjectStageID = 2


delete pau
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
join dbo.PerformanceMeasureActualUpdate pau on pub.ProjectUpdateBatchID = pau.ProjectUpdateBatchID
where pu.ProjectStageID = 2 and p.ProjectStageID = 2



update pu
set pu.ProjectStageID = 3
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
where pu.ProjectStageID = 2 and p.ProjectID = 55