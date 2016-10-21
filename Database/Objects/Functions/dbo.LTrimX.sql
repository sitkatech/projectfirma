if object_id('dbo.LTrimX') is not null DROP FUNCTION dbo.LTrimX
GO
CREATE FUNCTION dbo.LTrimX(@str VARCHAR(MAX)) RETURNS VARCHAR(MAX)
AS
BEGIN
DECLARE @trimchars VARCHAR(255)
SET @trimchars = CHAR(9) + -- Tab \t
                 CHAR(10) + -- Newline \n
                 CHAR(11) + -- Vertical tab \v
                 CHAR(12) + -- Form feed \f
                 CHAR(13) + -- Carriage return \r
                 CHAR(32) -- Space
IF @str LIKE '' + @trimchars + '%' SET @str = SUBSTRING(@str, PATINDEX('%^' + @trimchars + '%', @str), DATALENGTH(@str))
RETURN @str
END
GO
