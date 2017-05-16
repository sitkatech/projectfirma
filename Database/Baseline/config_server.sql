if not exists (select * from master.dbo.syslogins where loginname = N'${db-user}')
BEGIN
	CREATE LOGIN [${db-user}] FROM WINDOWS
END
GO
