delete pu from dbo.ProjectUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886

delete pu from dbo.ProjectOrganizationUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886

delete pu from dbo.ProjectUpdateHistory pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886

delete pu from dbo.ProjectImageUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886

delete pu from dbo.ProjectFundingSourceExpenditureUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886

delete pu from dbo.ProjectFundingSourceRequestUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886

delete pu from dbo.ProjectGeospatialAreaUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886

delete pu from dbo.ProjectLocationUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886


delete pu from dbo.ProjectExemptReportingYearUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886



delete pu from dbo.PerformanceMeasureActualSubcategoryOptionUpdate pu
join dbo.PerformanceMeasureActualUpdate pmau on pu.PerformanceMeasureActualUpdateID = pmau.PerformanceMeasureActualUpdateID
join dbo.ProjectUpdateBatch pub on pmau.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886


delete pu from dbo.PerformanceMeasureActualUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = 12598 and pub.ProjectUpdateBatchID = 5886



delete p
from dbo.ProjectUpdateBatch p
where p.ProjectID = 12598 and p.ProjectUpdateBatchID = 5886