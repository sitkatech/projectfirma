alter table dbo.ProjectUpdateBatch add ExpectedPerformanceMeasureDiffLog dbo.html null;
alter table dbo.ProjectUpdateBatch add IsSimpleLocationUpdated bit null
alter table dbo.ProjectUpdateBatch add IsDetailedLocationUpdated bit null
alter table dbo.ProjectUpdateBatch add IsSpatialInformationUpdated bit null


exec sp_rename 'dbo.ProjectUpdateBatch.PerformanceMeasureDiffLog', 'ReportedPerformanceMeasureDiffLog', 'COLUMN';