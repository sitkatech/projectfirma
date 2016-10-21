if object_id('dbo.RTrimX') is not null DROP FUNCTION dbo.RTrimX
GO
CREATE FUNCTION dbo.RTrimX(@str VARCHAR(MAX)) RETURNS VARCHAR(MAX)
AS
BEGIN
RETURN REVERSE(dbo.LTrimX(REVERSE(@str)))
END
GO
