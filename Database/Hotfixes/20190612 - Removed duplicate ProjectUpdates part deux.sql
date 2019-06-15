declare @projectID int, @projectUpdateBatchID int
select @projectID = 13181, @projectUpdateBatchID = 6289

delete pu from dbo.ProjectUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectOrganizationUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectUpdateHistory pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectImageUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectFundingSourceExpenditureUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectFundingSourceRequestUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectGeospatialAreaUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectLocationUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID


delete pu from dbo.ProjectExemptReportingYearUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID



delete pu from dbo.PerformanceMeasureActualSubcategoryOptionUpdate pu
join dbo.PerformanceMeasureActualUpdate pmau on pu.PerformanceMeasureActualUpdateID = pmau.PerformanceMeasureActualUpdateID
join dbo.ProjectUpdateBatch pub on pmau.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID


delete pu from dbo.PerformanceMeasureActualUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectNoteUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectDocumentUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pcauv
from dbo.ProjectCustomAttributeUpdateValue pcauv
join dbo.ProjectCustomAttributeUpdate pu on pcauv.ProjectCustomAttributeUpdateID = pu.ProjectCustomAttributeUpdateID
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID

delete pu from dbo.ProjectCustomAttributeUpdate pu
join dbo.ProjectUpdateBatch pub on pu.ProjectUpdateBatchID = pub.ProjectUpdateBatchID
where pub.ProjectID = @projectID and pub.ProjectUpdateBatchID = @projectUpdateBatchID



delete p
from dbo.ProjectUpdateBatch p
where p.ProjectID = @projectID and p.ProjectUpdateBatchID = @projectUpdateBatchID