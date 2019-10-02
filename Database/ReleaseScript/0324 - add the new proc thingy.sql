IF EXISTS(SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID(N'dbo.pGeospatialAreaIndexGridData'))
    drop procedure dbo.pGeospatialAreaIndexGridData
go