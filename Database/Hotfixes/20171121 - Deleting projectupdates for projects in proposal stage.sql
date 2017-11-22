delete b
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.PerformanceMeasureActualUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
join dbo.PerformanceMeasureActualSubcategoryOptionUpdate b on a.PerformanceMeasureActualUpdateID = b.PerformanceMeasureActualUpdateID
where p.ProjectStageID = 1


delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.PerformanceMeasureActualUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete b
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.PerformanceMeasureActualUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
join dbo.PerformanceMeasureActualSubcategoryOptionUpdate b on a.PerformanceMeasureActualUpdateID = b.PerformanceMeasureActualUpdateID
where p.ProjectStageID = 1


delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectBudgetUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectExemptReportingYearUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectExternalLinkUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectFundingSourceExpenditureUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectFundingSourceRequestUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectImageUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectLocationStagingUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectLocationUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectNoteUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectUpdateHistory a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete a
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
join dbo.ProjectWatershedUpdate a on pub.ProjectUpdateBatchID = a.ProjectUpdateBatchID
where p.ProjectStageID = 1

delete pub
from dbo.Project p
join dbo.ProjectUpdateBatch pub on p.ProjectID = pub.ProjectID
where p.ProjectStageID = 1
