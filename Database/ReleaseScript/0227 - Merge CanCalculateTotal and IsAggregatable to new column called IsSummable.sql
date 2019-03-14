alter table dbo.PerformanceMeasure drop column CanCalculateTotal
exec sp_rename 'dbo.PerformanceMeasure.IsAggregatable', 'IsSummable', 'COLUMN'
