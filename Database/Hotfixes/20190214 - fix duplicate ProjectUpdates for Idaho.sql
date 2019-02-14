delete pu
from dbo.ProjectUpdateBatch pub
join dbo.ProjectUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
where pub.ProjectID = 6348 and pub.ProjectUpdateBatchID = 5702

delete pu
from dbo.ProjectUpdateBatch pub
join dbo.ProjectOrganizationUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
where pub.ProjectID = 6348 and pub.ProjectUpdateBatchID = 5702

delete pu
from dbo.ProjectUpdateBatch pub
join dbo.ProjectUpdateHistory pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
where pub.ProjectID = 6348 and pub.ProjectUpdateBatchID = 5702

delete pus
from dbo.ProjectUpdateBatch pub
join dbo.PerformanceMeasureActualUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
join dbo.PerformanceMeasureActualSubcategoryOptionUpdate pus on pu.PerformanceMeasureActualUpdateID = pus.PerformanceMeasureActualUpdateID
where pub.ProjectID = 6348 and pub.ProjectUpdateBatchID = 5702


delete pu
from dbo.ProjectUpdateBatch pub
join dbo.PerformanceMeasureActualUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
where pub.ProjectID = 6348 and pub.ProjectUpdateBatchID = 5702

delete pu
from dbo.ProjectUpdateBatch pub
join dbo.ProjectGeospatialAreaUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
where pub.ProjectID = 6348 and pub.ProjectUpdateBatchID = 5702

delete pu
from dbo.ProjectUpdateBatch pub
join dbo.ProjectExemptReportingYearUpdate pu on pub.ProjectUpdateBatchID = pu.ProjectUpdateBatchID
where pub.ProjectID = 6348 and pub.ProjectUpdateBatchID = 5702


delete pub
from dbo.ProjectUpdateBatch pub
where pub.ProjectID = 6348 and pub.ProjectUpdateBatchID = 5702