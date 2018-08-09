-- I just want to say, even though I'm deleting this AK, I'm not happy with how uninformative its name is.
DROP INDEX AK_TableName_ColumnName ON dbo.PerformanceMeasureSubcategoryOption

ALTER TABLE dbo.PerformanceMeasureSubcategoryOption
DROP COLUMN ShortName