-- this script is used by nant to update the TenantAttribute table to make certain fields be environment aware
use ${db-name}
if (@@error != 0) goto failed

if(exists(select 1 from sys.columns c join sys.tables t on c.object_id = t.object_id where c.name = 'MapServiceUrl' and t.name = 'TenantAttribute'))
begin
	declare @sql nvarchar(max)
	set @sql = 'update dbo.TenantAttribute set MapServiceUrl = replace(MapServiceUrl, ''mapserver'', ''@ENVIRONMENT@-mapserver'')'
	exec sp_executesql @sql
	if (@@error != 0) goto failed
end

goto goodbye

failed:

raiserror('The database update tenant attributes script failed. Additional error details should be available above.', 16, 1)

goodbye:

use master


