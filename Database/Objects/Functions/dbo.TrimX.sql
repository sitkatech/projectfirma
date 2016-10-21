if object_id('dbo.TrimX') is not null DROP FUNCTION dbo.TrimX
GO
CREATE FUNCTION dbo.TrimX(@str VARCHAR(MAX)) RETURNS VARCHAR(MAX)
AS
BEGIN
RETURN dbo.LTrimX(dbo.RTrimX(@str))
END

GO
